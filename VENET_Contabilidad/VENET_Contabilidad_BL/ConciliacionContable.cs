using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json;
using VENET_DataEntity;

namespace VENET_Contabilidad_BL
{
    public sealed class ConciliacionDocumento
    {
        public OperatoriaContable Operatoria { get; set; }
        public int Documento { get; set; }
        public int Sucursal { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal? Gestion { get; set; }
        public decimal? OrigenRegistrado { get; set; }
        public decimal? DebeRegistrado { get; set; }
        public decimal? HaberRegistrado { get; set; }
        public int? Lote { get; set; }
        public bool Anulado { get; set; }
        public bool Revertido { get; set; }
        public string Estado { get; set; }
    }
    public sealed class ConciliacionCaja
    {
        public int Caja { get; set; }
        public string Nombre { get; set; }
        public int Moneda { get; set; }
        public int Cuenta { get; set; }
        public decimal? Gestion { get; set; }
        public decimal? Contabilidad { get; set; }
        public decimal? Diferencia { get; set; }
        public string Observacion { get; set; }
    }
    public sealed class InformeClasificado
    {
        public int Cuenta { get; set; }
        public string Nombre { get; set; }
        public ClaseCuenta? Clase { get; set; }
        public string Rubro { get; set; }
        public decimal Saldo { get; set; }
        public decimal Presentacion { get; set; }
    }
    public sealed partial class ContabilidadService
    {
        public List<ClasificacionCuenta> Clasificaciones(int empresa)
        {
            using (var db = Abrir())
            {
                ExigirInstalacionProductiva(db);
                return LeerClasificaciones(db, null, empresa);
            }
        }
        private static List<ClasificacionCuenta> LeerClasificaciones(GestionContext db, DbContextTransaction tx, int empresa)
        {
            using (var cmd = Comando(db, tx, "SELECT Cuenta,Clase,Rubro FROM dbo.ContabilidadClasificacion WHERE Empresa=@empresa ORDER BY Cuenta", ("empresa", empresa)))
            using (var r = cmd.ExecuteReader())
            {
                var result = new List<ClasificacionCuenta>();
                while (r.Read()) result.Add(new ClasificacionCuenta { Cuenta = r.GetInt32(0), Clase = (ClaseCuenta)r.GetInt32(1), Rubro = r.GetString(2) });
                return result;
            }
        }
        public List<VinculoCaja> CajasContables(int empresa)
        {
            using (var db = Abrir())
            {
                ExigirInstalacionProductiva(db);
                return LeerCajasContables(db, null, empresa);
            }
        }
        private static List<VinculoCaja> LeerCajasContables(GestionContext db, DbContextTransaction tx, int empresa)
        {
            using (var cmd = Comando(db, tx, "SELECT Caja,Cuenta FROM dbo.ContabilidadCajas WHERE Empresa=@empresa ORDER BY Caja", ("empresa", empresa)))
            using (var r = cmd.ExecuteReader())
            {
                var result = new List<VinculoCaja>();
                while (r.Read()) result.Add(new VinculoCaja { Caja = r.GetInt32(0), Cuenta = r.GetInt32(1) });
                return result;
            }
        }
        public void GuardarClasificaciones(int empresa, List<ClasificacionCuenta> clasificaciones, List<VinculoCaja> cajas, string motivo, int usuario)
        {
            ValidarMotivo(motivo);
            if (clasificaciones == null || cajas == null || clasificaciones.Count > 20000 || cajas.Count > 1000
                || clasificaciones.Any(c => c == null || c.Cuenta <= 0 || !Enum.IsDefined(typeof(ClaseCuenta), c.Clase) || string.IsNullOrWhiteSpace(c.Rubro) || c.Rubro.Length > 100)
                || clasificaciones.GroupBy(c => c.Cuenta).Any(g => g.Count() > 1)
                || cajas.Any(c => c == null || c.Caja <= 0 || c.Cuenta <= 0) || cajas.GroupBy(c => c.Caja).Any(g => g.Count() > 1)
                || cajas.GroupBy(c => c.Cuenta).Any(g => g.Count() > 1))
                throw new ValidationException("Clasificaciones o vinculos de cajas invalidos/duplicados. Cada caja requiere su propia cuenta.");
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db); Bloquear(db, tx, empresa); ExigirUsuario(db, tx, usuario, "ContabilidadConfiguracion", "Modificar");
                var cuentas = Cuentas(db);
                if (clasificaciones.Any(c => !cuentas.Contains(c.Cuenta)) || cajas.Any(c => !cuentas.Contains(c.Cuenta)))
                    throw new ValidationException("Cuenta no imputable, inexistente o inactiva.");
                foreach (var c in cajas)
                    if (!db.Cajas.Any(x => x.Id == c.Caja && x.UserDel == null && db.Sucursales.Any(s => s.Id == x.Id_Sucursal && s.Id_Empresa == empresa)))
                        throw new ValidationException("Caja ajena a la empresa o inactiva.");
                Ejecutar(db, tx, "DELETE dbo.ContabilidadClasificacion WHERE Empresa=@empresa; DELETE dbo.ContabilidadCajas WHERE Empresa=@empresa", ("empresa", empresa));
                foreach (var c in clasificaciones) Ejecutar(db, tx, "INSERT dbo.ContabilidadClasificacion VALUES(@empresa,@cuenta,@clase,@rubro)",
                    ("empresa", empresa), ("cuenta", c.Cuenta), ("clase", (int)c.Clase), ("rubro", c.Rubro));
                foreach (var c in cajas) Ejecutar(db, tx, "INSERT dbo.ContabilidadCajas VALUES(@empresa,@caja,@cuenta)",
                    ("empresa", empresa), ("caja", c.Caja), ("cuenta", c.Cuenta));
                Auditar(db, tx, empresa, usuario, "Clasificacion y cajas", empresa.ToString(), motivo, new { clasificaciones, cajas });
                tx.Commit();
            }
        }
        public List<ConciliacionDocumento> ConciliarDocumentos(int empresa, DateTime desde, DateTime hasta, List<int> sucursales)
        {
            ValidarPeriodo(desde, hasta);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db);
                var result = new List<ConciliacionDocumento>();
                using (var cmd = Comando(db, tx, @"SELECT TOP(501) o.Operatoria,o.Documento,o.Sucursal,o.Fecha,o.Descripcion,o.Importe,o.Anulacion,o.Baja,l.Id,l.Datos,
                    CASE WHEN EXISTS(SELECT 1 FROM dbo.ContabilidadLotes rev WHERE rev.ReversionDe=l.Id) THEN 1 ELSE 0 END
                    FROM dbo.ContabilidadOrigenes o LEFT JOIN dbo.ContabilidadLotes l ON l.Empresa=o.Empresa AND l.Operatoria=o.Operatoria AND l.Documento=o.Documento AND l.ReversionDe IS NULL
                    WHERE o.Empresa=@empresa AND o.Sucursal IN(SELECT Id FROM @sucursales) AND o.Fecha>=@desde AND o.Fecha<@hasta ORDER BY o.Fecha,o.Operatoria,o.Documento",
                    ("empresa", empresa), ("desde", desde.Date), ("hasta", hasta.Date.AddDays(1))))
                using (var r = LeerConSucursales(cmd, sucursales))
                    while (r.Read())
                    {
                        var registro = r.IsDBNull(9) ? null : JsonConvert.DeserializeObject<RegistroContable>(r.GetString(9));
                        result.Add(new ConciliacionDocumento
                        {
                            Operatoria = (OperatoriaContable)r.GetInt32(0),
                            Documento = r.GetInt32(1),
                            Sucursal = r.GetInt32(2),
                            Fecha = r.GetDateTime(3),
                            Descripcion = r.IsDBNull(4) ? null : r.GetString(4),
                            Gestion = r.IsDBNull(5) ? (decimal?)null : r.GetDecimal(5),
                            Anulado = !r.IsDBNull(6) || !r.IsDBNull(7),
                            Lote = r.IsDBNull(8) ? (int?)null : r.GetInt32(8),
                            OrigenRegistrado = registro?.Simulacion.Hecho.Total,
                            Revertido = r.GetInt32(10) == 1
                        });
                    }
                if (result.Count > 500) throw new ValidationException("Mas de 500 documentos para conciliar. Reduzca el periodo.");
                foreach (var c in result)
                {
                    if (c.Lote.HasValue)
                    {
                        var ids = new List<int>();
                        using (var cmd = Comando(db, tx, "SELECT Asiento FROM dbo.ContabilidadAsientos WHERE Lote=@lote", ("lote", c.Lote.Value)))
                        using (var r = cmd.ExecuteReader()) while (r.Read()) ids.Add(r.GetInt32(0));
                        var filas = db.AsientosDetalle.Where(d => ids.Contains(d.Id_Asiento) && d.UserDel == null && d.Asiento.UserDel == null && d.Asiento.FechaAnulacion == null);
                        c.DebeRegistrado = filas.Select(d => (decimal?)d.Debe).Sum() ?? 0;
                        c.HaberRegistrado = filas.Select(d => (decimal?)d.Haber).Sum() ?? 0;
                    }
                    c.Estado = EstadoConciliacion(c);
                }
                return result;
            }
        }
        public static string EstadoConciliacion(ConciliacionDocumento c)
        {
            if (c.Anulado) return c.Lote.HasValue && !c.Revertido ? "Anulado contabilizado: requiere reversion" : "Anulado sin impacto pendiente";
            if (!c.Lote.HasValue) return "Sin contabilizar";
            if (c.Revertido) return "Revertido con origen vigente: revisar";
            if (c.DebeRegistrado != c.HaberRegistrado || c.DebeRegistrado == 0) return "Asientos alterados o sin movimientos";
            if (!c.Gestion.HasValue || !c.OrigenRegistrado.HasValue) return "Importe local no disponible: no comparable";
            if (decimal.Round(c.Gestion.Value, 2) != decimal.Round(c.OrigenRegistrado.GetValueOrDefault(), 2))
                return "Diferencia de origen";
            return "Conciliado por origen y balance";
        }
        public List<ConciliacionCaja> ConciliarCajas(int empresa, int moneda, DateTime desde, DateTime hasta, List<int> sucursales)
        {
            ValidarPeriodo(desde, hasta);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db); ValidarLibro(db, empresa, moneda);
                var vinculos = LeerCajasContables(db, tx, empresa);
                var saldos = LeerSaldos(db, empresa, moneda, desde.Date, hasta.Date, null);
                var result = new List<ConciliacionCaja>();
                if (sucursales == null) throw new ValidationException("Faltan sucursales autorizadas.");
                var cajas = db.Cajas.Where(c => c.UserDel == null && sucursales.Contains(c.Id_Sucursal) && db.Sucursales.Any(s => s.Id == c.Id_Sucursal && s.Id_Empresa == empresa)).ToList();
                foreach (var caja in cajas)
                {
                    var vinculo = vinculos.SingleOrDefault(v => v.Caja == caja.Id);
                    var c = new ConciliacionCaja { Caja = caja.Id, Nombre = caja.Descripcion, Moneda = caja.Id_Especie, Cuenta = vinculo?.Cuenta ?? 0 };
                    c.Gestion = db.EspeciesCtaCte.Where(m => m.Id_Caja == caja.Id && m.UserDel == null && m.Fecha < hasta.Date.AddDays(1))
                        .Select(m => (decimal?)(m.Debito - m.Credito)).Sum() ?? 0;
                    if (vinculo == null) c.Observacion = "Sin cuenta contable vinculada";
                    else if (caja.Id_Especie != moneda) c.Observacion = "Monedas distintas: saldo nativo no comparable; requiere valuacion historica explicita";
                    else
                    {
                        c.Contabilidad = saldos.SingleOrDefault(s => s.Cuenta == vinculo.Cuenta)?.Saldo ?? 0;
                        c.Diferencia = c.Gestion - c.Contabilidad;
                        c.Observacion = c.Diferencia == 0 ? "Conciliado" : "Diferencia: revisar saldo inicial y movimientos no contabilizados";
                    }
                    result.Add(c);
                }
                return result;
            }
        }
        public List<InformeClasificado> InformeBalance(int empresa, int moneda, DateTime desde, DateTime hasta)
        {
            ValidarPeriodo(desde, hasta);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db); ValidarLibro(db, empresa, moneda);
                var clases = LeerClasificaciones(db, tx, empresa).ToDictionary(c => c.Cuenta);
                return LeerSaldos(db, empresa, moneda, desde.Date, hasta.Date, null).Select(s =>
                {
                    clases.TryGetValue(s.Cuenta, out var c);
                    return new InformeClasificado
                    {
                        Cuenta = s.Cuenta,
                        Nombre = s.Nombre,
                        Clase = c?.Clase,
                        Rubro = c?.Rubro ?? "Sin clasificar",
                        Saldo = s.Saldo,
                        Presentacion = c != null && (c.Clase == ClaseCuenta.Pasivo || c.Clase == ClaseCuenta.Patrimonio || c.Clase == ClaseCuenta.Ingreso) ? -s.Saldo : s.Saldo
                    };
                }).ToList();
            }
        }
        public List<Dictionary<string, object>> Auditoria(int empresa)
        {
            using (var db = Abrir())
            {
                ExigirInstalacionProductiva(db);
                using (var cmd = Comando(db, null, "SELECT TOP(500) Id,Usuario,Fecha,Accion,Referencia,Motivo FROM dbo.ContabilidadAuditoria WHERE Empresa=@empresa ORDER BY Id DESC", ("empresa", empresa)))
                using (var r = cmd.ExecuteReader())
                {
                    var result = new List<Dictionary<string, object>>();
                    while (r.Read()) result.Add(Enumerable.Range(0, r.FieldCount).ToDictionary(r.GetName, i => r.IsDBNull(i) ? null : r.GetValue(i)));
                    return result;
                }
            }
        }
    }
}
