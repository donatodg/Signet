using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using VENET_Common;
using VENET_DataEntity;

namespace VENET_Contabilidad_BL
{
    public sealed partial class ContabilidadService
    {
        public List<SaldoCuenta> Saldos(int empresa, int moneda, DateTime desde, DateTime hasta)
        {
            ValidarPeriodo(desde, hasta);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ValidarLibro(db, empresa, moneda);
                return LeerSaldos(db, empresa, moneda, desde.Date, hasta.Date, null);
            }
        }
        public MayorContable Mayor(int empresa, int moneda, int cuenta, DateTime desde, DateTime hasta)
        {
            ValidarPeriodo(desde, hasta);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ValidarLibro(db, empresa, moneda);
                if (!db.CuentasContables.Any(c => c.Id == cuenta)) throw new ValidationException("Cuenta no encontrada.");
                var filas = Lineas(db, empresa, moneda, hasta.Date.AddDays(1)).Where(x => x.Id_CuentaContable == cuenta);
                var saldo = filas.Where(x => x.Asiento.Fecha < desde.Date).Select(x => (decimal?)(x.Debe - x.Haber)).Sum() ?? 0m;
                var movimientos = filas.Where(x => x.Asiento.Fecha >= desde.Date).OrderBy(x => x.Asiento.Fecha).ThenBy(x => x.Asiento.Numero).ThenBy(x => x.Id)
                    .Take(2001).Select(x => new MovimientoMayor
                    {
                        Asiento = x.Id_Asiento,
                        Numero = x.Asiento.Numero,
                        Fecha = x.Asiento.Fecha,
                        Descripcion = x.Asiento.Descripcion,
                        Debe = x.Debe,
                        Haber = x.Haber
                    }).ToList();
                if (movimientos.Count > 2000) throw new ValidationException("Hay mas de 2000 movimientos. Reduzca el periodo.");
                var anterior = saldo;
                foreach (var m in movimientos) { saldo += m.Debe - m.Haber; m.Saldo = saldo; }
                return new MayorContable { Anterior = anterior, Movimientos = movimientos, Saldo = saldo };
            }
        }
        private static void ValidarPeriodo(DateTime desde, DateTime hasta)
        {
            if (desde.Year < 1753 || hasta.Year >= 9999 || hasta < desde || (hasta - desde).TotalDays > 366)
                throw new ValidationException("Consulte un periodo valido de hasta un año.");
        }
        private static void ValidarLibro(GestionContext db, int empresa, int moneda)
        {
            if (!db.Empresas.Any(e => e.Id == empresa && e.UserDel == null) || !db.Especies.Any(e => e.Id == moneda && e.UserDel == null))
                throw new ValidationException("Empresa o moneda no valida para el libro.");
        }
        private static IQueryable<AsientosDetalle> Lineas(GestionContext db, int empresa, int moneda, DateTime fin) =>
            db.AsientosDetalle.Where(x => x.UserDel == null && x.Asiento.UserDel == null && x.Asiento.FechaAnulacion == null
                && x.Asiento.Id_Empresa == empresa && x.Asiento.Id_Especie == moneda && x.Asiento.Fecha < fin);

        private static List<SaldoCuenta> LeerSaldos(GestionContext db, int empresa, int moneda, DateTime desde, DateTime hasta, List<int> excluir)
        {
            var filas = Lineas(db, empresa, moneda, hasta.AddDays(1));
            if (excluir != null && excluir.Count > 0) filas = filas.Where(x => !excluir.Contains(x.Id_Asiento));
            var result = filas.GroupBy(x => x.Id_CuentaContable).Select(g => new SaldoCuenta
            {
                Cuenta = g.Key,
                Anterior = g.Sum(x => x.Asiento.Fecha < desde ? x.Debe - x.Haber : 0),
                Debe = g.Sum(x => x.Asiento.Fecha >= desde ? x.Debe : 0),
                Haber = g.Sum(x => x.Asiento.Fecha >= desde ? x.Haber : 0)
            }).OrderBy(x => x.Cuenta).ToList();
            var nombres = db.CuentasContables.ToList().ToDictionary(c => c.Id, c => c.Titulo + "." + c.Capitulo + "." + c.Rubro + "." + c.Cuenta + "." + c.Subcuenta + " - " + c.Descripcion);
            foreach (var s in result) s.Nombre = nombres[s.Cuenta];
            return result;
        }
        public DocumentoContable PrepararEjercicio(int empresa, int ejercicioOrigen, OperatoriaContable op, int sucursal, DateTime fecha, Guid clave, int usuario)
        {
            if (clave == Guid.Empty || usuario <= 0 || (op != OperatoriaContable.Apertura && op != OperatoriaContable.Cierre))
                throw new ValidationException("Solicitud de apertura/cierre no valida.");
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                Bloquear(db, tx, empresa);
                var previo = DocumentoPorClave(db, tx, empresa, clave);
                if (previo != null)
                {
                    if (previo.EjercicioOrigen != ejercicioOrigen || previo.Hecho.Operatoria != op || previo.Hecho.Sucursal != sucursal || previo.Hecho.Fecha != fecha.Date)
                        throw new ValidationException("La clave de reintento ya pertenece a otra solicitud de ejercicio.");
                    return previo;
                }
                var config = LeerConfiguracion(db, tx, empresa) ?? throw new ValidationException("Falta configuracion contable.");
                var ejercicio = db.EjerciciosContables.SingleOrDefault(e => e.Id == ejercicioOrigen && e.Id_Empresa == empresa && e.UserDel == null)
                    ?? throw new ValidationException("Ejercicio de origen no encontrado.");
                if (!db.Sucursales.Any(s => s.Id == sucursal && s.Id_Empresa == empresa && s.UserDel == null))
                    throw new ValidationException("Sucursal ajena a la empresa.");
                Ejercicio(db, empresa, fecha.Date);
                var hecho = HechoSaldos(db, empresa, config.MonedaBase, ejercicio, op, fecha.Date, sucursal);
                var doc = new DocumentoContable
                {
                    Clave = clave,
                    Hecho = hecho,
                    Moneda = config.MonedaBase,
                    Respaldo = "Saldos del ejercicio #" + ejercicio.Id,
                    EjercicioOrigen = ejercicio.Id,
                    FirmaSaldos = MotorContable.Firma(hecho.Partidas),
                    Usuario = usuario,
                    Creado = Sistema.ObtenerFechaHora()
                };
                InsertarDocumento(db, tx, doc);
                tx.Commit(); return doc;
            }
        }
        private static HechoContable HechoSaldos(GestionContext db, int empresa, int moneda, EjerciciosContables ejercicio, OperatoriaContable op, DateTime fecha, int sucursal)
        {
            if (ejercicio.VigenciaHasta.Year >= 9999) throw new ValidationException("La fecha final del ejercicio excede el rango admitido.");
            if (op == OperatoriaContable.Cierre && (ejercicio.Cerrado || fecha != ejercicio.VigenciaHasta.Date)
                || op == OperatoriaContable.Apertura && (!ejercicio.Cerrado || fecha <= ejercicio.VigenciaHasta.Date
                    || !db.EjerciciosContables.Any(e => e.Id_Empresa == empresa && e.UserDel == null && !e.Cerrado && e.VigenciaDesde == fecha)))
                throw new ValidationException("Cierre: ultimo dia de un ejercicio abierto. Apertura: primer dia de un ejercicio posterior a uno cerrado.");
            var fin = ejercicio.VigenciaHasta.Date.AddDays(1);
            if (db.Asientos.Any(a => a.Id_Empresa == empresa && a.UserDel == null && a.FechaAnulacion == null
                && a.Fecha >= ejercicio.VigenciaDesde && a.Fecha < fin && a.Id_Especie != moneda))
                throw new ValidationException("El ejercicio contiene otras monedas; deben convertirse mediante asientos explicitos antes del cierre.");
            var excluir = new List<int>();
            var sql = @"SELECT ca.Asiento FROM dbo.ContabilidadAsientos ca
                INNER JOIN dbo.ContabilidadLotes l ON l.Id=ca.Lote
                INNER JOIN dbo.ContabilidadDocumentos d ON d.Id=l.Documento AND d.Empresa=l.Empresa AND d.Operatoria=l.Operatoria
                WHERE l.Empresa=@empresa AND l.Operatoria=@op AND d.EjercicioOrigen=@ejercicio";
            using (var cmd = Comando(db, db.Database.CurrentTransaction, sql, ("empresa", empresa), ("op", (int)OperatoriaContable.Cierre), ("ejercicio", ejercicio.Id)))
            using (var r = cmd.ExecuteReader()) while (r.Read()) excluir.Add(r.GetInt32(0));
            var saldos = LeerSaldos(db, empresa, moneda, ejercicio.VigenciaDesde.Date, ejercicio.VigenciaHasta.Date, excluir);
            // Cada ejercicio lleva su apertura; no se arrastran nuevamente los movimientos de ejercicios anteriores.
            foreach (var s in saldos) s.Anterior = 0;
            return DesdeSaldos(empresa, op, fecha, sucursal, saldos);
        }
        public static HechoContable DesdeSaldos(int empresa, OperatoriaContable op, DateTime fecha, int sucursal, IEnumerable<SaldoCuenta> saldos)
        {
            var filas = saldos.Where(s => s.Saldo != 0).OrderBy(s => s.Cuenta).ToList();
            if (filas.Count < 2 || filas.Sum(s => s.Saldo) != 0) throw new ValidationException("Los saldos del ejercicio no estan balanceados o no tienen movimientos.");
            return new HechoContable
            {
                Empresa = empresa,
                Operatoria = op,
                Fecha = fecha,
                Sucursal = sucursal,
                Descripcion = op + " del ejercicio",
                Partidas = filas.Select(s => new PartidaOrigen
                {
                    Origen = OrigenContable.Saldos,
                    CuentaOrigen = s.Cuenta,
                    Referencia = "Saldo cuenta #" + s.Cuenta,
                    SaldoDeudor = Math.Max(s.Saldo, 0),
                    SaldoAcreedor = Math.Max(-s.Saldo, 0)
                }).ToList()
            };
        }
        public static void VerificarSaldos(SimulacionContable sim)
        {
            var signo = sim.Hecho.Operatoria == OperatoriaContable.Cierre ? -1m : 1m;
            var esperados = sim.Hecho.Partidas.ToDictionary(p => p.CuentaOrigen.Value, p => signo * (p.SaldoDeudor - p.SaldoAcreedor));
            var obtenidos = sim.Asientos.SelectMany(a => a.Renglones).GroupBy(r => r.Cuenta).ToDictionary(g => g.Key, g => g.Sum(r => r.Debe - r.Haber));
            if (obtenidos.Count != esperados.Count || esperados.Any(s => !obtenidos.ContainsKey(s.Key) || obtenidos[s.Key] != s.Value))
                throw new ValidationException("Las plantillas de apertura/cierre deben trasladar exactamente los saldos, sin duplicaciones ni cambios de cuenta.");
        }
    }
}
