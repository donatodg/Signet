using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json;
using VENET_Common;
using VENET_DataEntity;

namespace VENET_Contabilidad_BL
{
    public sealed class RegistroContable
    {
        public int Id { get; set; }
        public int Empresa { get; set; }
        public OperatoriaContable Operatoria { get; set; }
        public int Documento { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
        public int? ReversionDe { get; set; }
        public List<int> Asientos { get; set; }
        public SimulacionContable Simulacion { get; set; }
    }

    public sealed partial class ContabilidadService
    {
        public ConfiguracionContable Configuracion(int empresa)
        {
            using (var db = Abrir())
                return LeerConfiguracion(db, null, empresa) ?? new ConfiguracionContable { Empresa = empresa };
        }

        public ConfiguracionContable GuardarConfiguracion(ConfiguracionContable config, int usuario)
        {
            MotorContable.ValidarConfiguracion(config);
            if (usuario <= 0) throw new ValidationException("Usuario no valido.");
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                Bloquear(db, tx, config.Empresa);
                var anterior = LeerConfiguracion(db, tx, config.Empresa);
                if (db.Database.SqlQuery<int>("SELECT CASE WHEN OBJECT_ID('dbo.ContabilidadOperativa','U') IS NULL THEN 0 ELSE 1 END").Single() == 1)
                {
                    var operativa = LeerOperativa(db, tx, config.Empresa);
                    if (operativa.Activa && operativa.Moneda != config.MonedaBase)
                        throw new ValidationException("Desactive la integracion operativa antes de cambiar la moneda base.");
                }
                if ((anterior?.Version ?? 0) != config.Version)
                    throw new ValidationException("Otro usuario modifico la configuracion. Recargue antes de guardar.");
                var cuentas = Cuentas(db);
                if (config.Asignaciones.Any(a => !cuentas.Contains(a.Cuenta))
                    || config.Plantillas.SelectMany(p => p.Reglas).Any(r => r.CuentaFija.HasValue && !cuentas.Contains(r.CuentaFija.Value)))
                    throw new ValidationException("Hay cuentas dadas de baja, inexistentes o no imputables.");
                ValidarReferencias(db, config);
                if (!db.Especies.Any(e => e.Id == config.MonedaBase && e.UserDel == null))
                    throw new ValidationException("Seleccione la especie correspondiente a la moneda local de las cotizaciones.");
                if (config.Plantillas.Any(p => p.Sucursal.HasValue && !db.Sucursales.Any(s => s.Id == p.Sucursal && s.Id_Empresa == config.Empresa && s.UserDel == null)
                    || p.TipoComprobante.HasValue && !db.TipoComprobante.Any(t => t.Id == p.TipoComprobante && t.UserDel == null)))
                    throw new ValidationException("Una sucursal o tipo de comprobante de las plantillas no esta habilitado.");
                var copia = JsonConvert.DeserializeObject<ConfiguracionContable>(JsonConvert.SerializeObject(config));
                copia.Version++;
                Ejecutar(db, tx, "INSERT dbo.ContabilidadConfiguraciones(Empresa,Version,Datos,Usuario,Fecha) VALUES(@empresa,@version,@datos,@usuario,@fecha)",
                    ("empresa", copia.Empresa), ("version", copia.Version), ("datos", JsonConvert.SerializeObject(copia)),
                    ("usuario", usuario), ("fecha", Sistema.ObtenerFechaHora()));
                tx.Commit();
                return copia;
            }
        }

        public SimulacionContable Simular(int empresa, OperatoriaContable operacion, int documento)
        {
            using (var db = Abrir())
            {
                var config = LeerConfiguracion(db, null, empresa) ?? throw new ValidationException("Guarde una configuracion contable para esta empresa.");
                var hecho = ObtenerHecho(db, null, empresa, operacion, documento, config.MonedaBase);
                if (hecho.Empresa != empresa) throw new ValidationException("El documento no pertenece a la empresa seleccionada.");
                Ejercicio(db, empresa, hecho.Fecha);
                var simulacion = MotorContable.Simular(config, hecho, Cuentas(db));
                if (operacion == OperatoriaContable.Apertura || operacion == OperatoriaContable.Cierre) VerificarSaldos(simulacion);
                return simulacion;
            }
        }

        public RegistroContable Registrar(int empresa, OperatoriaContable operacion, int documento, string firma, int usuario)
        {
            if (string.IsNullOrWhiteSpace(firma) || usuario <= 0) throw new ValidationException("Debe simular y revisar antes de registrar.");
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                Bloquear(db, tx, empresa);
                var registro = RegistrarDentro(db, tx, empresa, operacion, documento, firma, usuario, false);
                if (db.Database.SqlQuery<int>("SELECT CASE WHEN OBJECT_ID('dbo.ContabilidadCola','U') IS NULL THEN 0 ELSE 1 END").Single() == 1)
                    MarcarRegistrado(db, tx, registro);
                tx.Commit();
                return registro;
            }
        }
        private static RegistroContable RegistrarDentro(GestionContext db, DbContextTransaction tx, int empresa, OperatoriaContable operacion, int documento, string firma, int usuario, bool automatico)
        {
            var existente = LeerRegistro(db, tx, empresa, operacion, documento);
            if (existente != null) return existente;
            var config = LeerConfiguracion(db, tx, empresa) ?? throw new ValidationException("Falta la configuracion contable.");
            if (!Complementario(operacion)) BloquearOrigen(db, tx, operacion == OperatoriaContable.CostoVentaAutomatico ? OperatoriaContable.Venta : operacion, documento);
            var hecho = ObtenerHecho(db, tx, empresa, operacion, documento, config.MonedaBase);
            if (hecho.Empresa != empresa) throw new ValidationException("El documento no pertenece a esta empresa.");
            Ejercicio(db, empresa, hecho.Fecha);
            var simulacion = MotorContable.Simular(config, hecho, Cuentas(db));
            if (simulacion.Firma != firma) throw new ValidationException("Cambiaron el documento, las cuentas o la configuracion. Simule nuevamente.");
            VerificarAprobacion(db, tx, simulacion, usuario, automatico);
            if (operacion == OperatoriaContable.Apertura || operacion == OperatoriaContable.Cierre)
                VerificarSaldos(simulacion);
            var registro = GuardarLote(db, tx, simulacion, config.MonedaBase, usuario, null);
            if (operacion == OperatoriaContable.Cierre)
            {
                using (var cmd = Comando(db, tx, "SELECT EjercicioOrigen FROM dbo.ContabilidadDocumentos WHERE Id=@id AND Empresa=@empresa",
                    ("id", documento), ("empresa", empresa)))
                {
                    var ejercicio = Convert.ToInt32(cmd.ExecuteScalar());
                    var cerrado = db.EjerciciosContables.Single(e => e.Id == ejercicio && e.Id_Empresa == empresa);
                    cerrado.Cerrado = true; cerrado.UserMod = usuario; cerrado.FechaMod = Sistema.ObtenerFechaHora();
                    db.SaveChanges();
                }
            }
            return registro;
        }

        public RegistroContable Revertir(int empresa, int lote, DateTime fecha, string motivo, int usuario)
        {
            if (fecha.Year < 1753 || string.IsNullOrWhiteSpace(motivo) || motivo.Length > 200 || usuario <= 0)
                throw new ValidationException("Indique fecha y motivo de reversion (hasta 200 caracteres).");
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                Bloquear(db, tx, empresa);
                var original = ObtenerRegistro(db, tx, empresa, lote);
                if (original.ReversionDe.HasValue) throw new ValidationException("No se revierte una reversion.");
                using (var cmd = Comando(db, tx, "SELECT Datos FROM dbo.ContabilidadLotes WHERE Empresa=@empresa AND ReversionDe=@id", ("empresa", empresa), ("id", lote)))
                {
                    var previo = cmd.ExecuteScalar() as string;
                    if (previo != null) return JsonConvert.DeserializeObject<RegistroContable>(previo);
                }
                Ejercicio(db, empresa, fecha.Date);
                var simulacion = JsonConvert.DeserializeObject<SimulacionContable>(JsonConvert.SerializeObject(original.Simulacion));
                simulacion.Hecho.Fecha = fecha.Date;
                simulacion.Hecho.Descripcion = "Reversion lote " + lote + ": " + motivo.Trim();
                foreach (var a in simulacion.Asientos)
                {
                    a.Descripcion = "Reversion: " + a.Descripcion;
                    foreach (var r in a.Renglones) { var debe = r.Debe; r.Debe = r.Haber; r.Haber = debe; }
                    var total = a.Debe; a.Debe = a.Haber; a.Haber = total;
                }
                simulacion.Firma = null;
                simulacion.Firma = MotorContable.Firma(simulacion);
                var moneda = db.Asientos.Where(a => original.Asientos.Contains(a.Id)).Select(a => a.Id_Especie).Distinct().Single();
                var registro = GuardarLote(db, tx, simulacion, moneda, usuario, lote);
                tx.Commit();
                return registro;
            }
        }

        public List<RegistroContable> Diario(int empresa, DateTime desde, DateTime hasta)
        {
            if (desde.Year < 1753 || hasta.Year >= 9999 || hasta < desde || (hasta - desde).TotalDays > 366)
                throw new ValidationException("Consulte un periodo valido de hasta un año.");
            using (var db = Abrir())
            using (var cmd = Comando(db, null, "SELECT TOP(501) Datos FROM dbo.ContabilidadLotes WHERE Empresa=@empresa AND Fecha>=@desde AND Fecha<@hasta ORDER BY Id DESC",
                ("empresa", empresa), ("desde", desde.Date), ("hasta", hasta.Date.AddDays(1))))
            using (var reader = cmd.ExecuteReader())
            {
                var result = new List<RegistroContable>();
                while (reader.Read()) result.Add(JsonConvert.DeserializeObject<RegistroContable>(reader.GetString(0)));
                if (result.Count > 500) throw new ValidationException("Hay mas de 500 lotes. Reduzca el periodo.");
                return result;
            }
        }

        private static RegistroContable GuardarLote(GestionContext db, DbContextTransaction tx, SimulacionContable sim, int moneda, int usuario, int? reversion)
        {
            var ahora = Sistema.ObtenerFechaHora();
            var registro = new RegistroContable
            {
                Empresa = sim.Hecho.Empresa,
                Operatoria = sim.Hecho.Operatoria,
                Documento = sim.Hecho.Documento,
                Fecha = sim.Hecho.Fecha,
                Usuario = usuario,
                ReversionDe = reversion,
                Simulacion = sim,
                Asientos = new List<int>()
            };
            foreach (var propuesta in sim.Asientos)
            {
                var asiento = new Asientos
                {
                    Id_Empresa = sim.Hecho.Empresa,
                    Fecha = sim.Hecho.Fecha,
                    Id_Especie = moneda,
                    Descripcion = (propuesta.Descripcion + " / " + sim.Hecho.Descripcion).Substring(0, Math.Min(500, (propuesta.Descripcion + " / " + sim.Hecho.Descripcion).Length)),
                    Numero = (db.Asientos.Where(a => a.Id_Empresa == sim.Hecho.Empresa).Select(a => (int?)a.Numero).Max() ?? 0) + 1,
                    FechaAdd = ahora,
                    UserAdd = usuario,
                    Detalle = new List<AsientosDetalle>()
                };
                int orden = 0;
                foreach (var r in propuesta.Renglones)
                    asiento.Detalle.Add(new AsientosDetalle
                    {
                        Id_CuentaContable = r.Cuenta,
                        Orden = ++orden,
                        Debe = r.Debe,
                        Haber = r.Haber,
                        FechaAdd = ahora,
                        UserAdd = usuario
                    });
                db.Asientos.Add(asiento);
                db.SaveChanges();
                registro.Asientos.Add(asiento.Id);
            }
            using (var cmd = Comando(db, tx, "INSERT dbo.ContabilidadLotes(Empresa,Operatoria,Documento,Fecha,ReversionDe,Datos) OUTPUT INSERTED.Id VALUES(@empresa,@op,@doc,@fecha,@rev,N'')",
                ("empresa", registro.Empresa), ("op", (int)registro.Operatoria), ("doc", registro.Documento), ("fecha", registro.Fecha), ("rev", reversion)))
                registro.Id = Convert.ToInt32(cmd.ExecuteScalar());
            Ejecutar(db, tx, "UPDATE dbo.ContabilidadLotes SET Datos=@datos WHERE Id=@id",
                ("datos", JsonConvert.SerializeObject(registro)), ("id", registro.Id));
            foreach (var id in registro.Asientos)
                Ejecutar(db, tx, "INSERT dbo.ContabilidadAsientos(Lote,Asiento) VALUES(@lote,@asiento)", ("lote", registro.Id), ("asiento", id));
            return registro;
        }

        public static void ProtegerAsiento(GestionContext db, int id)
        {
            var existe = db.Database.SqlQuery<int>("IF OBJECT_ID('dbo.ContabilidadAsientos','U') IS NULL SELECT 0 ELSE SELECT COUNT(*) FROM dbo.ContabilidadAsientos WHERE Asiento=@p0", id).Single();
            if (existe > 0) throw new ValidationException("Este asiento tiene origen automatico: use Revertir lote en Contabilidad; no puede editarse ni eliminarse.");
        }
        public static void Bloquear(GestionContext db, DbContextTransaction tx, int empresa)
        {
            using (var cmd = Comando(db, tx, "DECLARE @r int; EXEC @r=sys.sp_getapplock @Resource=@recurso,@LockMode='Exclusive',@LockOwner='Transaction',@LockTimeout=10000; SELECT @r",
                ("recurso", "SIGNET:Contabilidad:" + empresa)))
                if (Convert.ToInt32(cmd.ExecuteScalar()) < 0) throw new ValidationException("Contabilidad esta ocupada. Intente nuevamente.");
        }
        private static void Ejercicio(GestionContext db, int empresa, DateTime fecha)
        {
            ValidarPeriodoAbierto(db, empresa, fecha);
            var ejercicios = db.EjerciciosContables.Where(e => e.Id_Empresa == empresa && e.UserDel == null && e.VigenciaDesde <= fecha && e.VigenciaHasta >= fecha).ToList();
            if (ejercicios.Count != 1 || ejercicios[0].Cerrado) throw new ValidationException("Debe existir un unico ejercicio abierto para la empresa y fecha contable.");
        }
        private static HashSet<int> Cuentas(GestionContext db) =>
            new HashSet<int>(db.CuentasContables.Where(c => c.UserDel == null && c.Subcuenta != "000000").Select(c => c.Id));
        private static GestionContext Abrir()
        {
            var db = new GestionContext();
            db.Database.Connection.Open();
            if (db.Database.SqlQuery<int>("SELECT CASE WHEN OBJECT_ID('dbo.ContabilidadConfiguraciones','U') IS NOT NULL AND OBJECT_ID('dbo.ContabilidadLotes','U') IS NOT NULL AND OBJECT_ID('dbo.ContabilidadAsientos','U') IS NOT NULL AND OBJECT_ID('dbo.ContabilidadDocumentos','U') IS NOT NULL THEN 1 ELSE 0 END").Single() != 1)
            {
                db.Dispose();
                throw new ValidationException("Falta instalar Contabilidad. Ejecute database\\001-Contabilidad.sql y 002-Contabilidad.sql en la base seleccionada, con respaldo previo.");
            }
            return db;
        }
        private static void ValidarReferencias(GestionContext db, ConfiguracionContable config)
        {
            foreach (var grupo in config.Asignaciones.GroupBy(a => a.Dimension))
            {
                var ids = grupo.Select(a => a.Referencia).Distinct().ToList();
                IQueryable<int> habilitadas;
                switch (grupo.Key)
                {
                    case DimensionCuenta.Empresa: continue;
                    case DimensionCuenta.Producto: habilitadas = db.Productos.Where(p => p.UserDel == null).Select(p => p.Id); break;
                    case DimensionCuenta.Categoria: habilitadas = db.ProductosCategorias.Where(p => p.UserDel == null).Select(p => p.Id); break;
                    case DimensionCuenta.Cliente: habilitadas = db.Clientes.Where(p => p.UserDel == null).Select(p => p.Id); break;
                    case DimensionCuenta.Proveedor: habilitadas = db.Proveedores.Where(p => p.UserDel == null).Select(p => p.Id); break;
                    case DimensionCuenta.FormaPago: habilitadas = db.FormasPagos.Where(p => p.UserDel == null).Select(p => p.Id); break;
                    case DimensionCuenta.Impuesto: habilitadas = db.TipoImpuestos.Where(p => p.UserDel == null).Select(p => p.Id); break;
                    case DimensionCuenta.Especie: habilitadas = db.Especies.Where(p => p.UserDel == null).Select(p => p.Id); break;
                    case DimensionCuenta.MedioTesoreria:
                        if (ids.Any(id => !Enum.IsDefined(typeof(MedioTesoreria), id))) throw new ValidationException("Medio de tesoreria no valido.");
                        continue;
                    case DimensionCuenta.Componente:
                        if (ids.Any(id => !Enum.IsDefined(typeof(ComponenteContable), id))) throw new ValidationException("Componente no valido.");
                        continue;
                    case DimensionCuenta.Caja: habilitadas = db.Cajas.Where(p => p.UserDel == null).Select(p => p.Id); break;
                    case DimensionCuenta.Personal: habilitadas = db.Personal.Where(p => p.UserDel == null).Select(p => p.Id); break;
                    case DimensionCuenta.Concepto: continue;
                    case DimensionCuenta.CuentaOrigen: throw new ValidationException("CuentaOrigen resuelve el saldo directamente; no admite asignaciones.");
                    default: throw new ValidationException("Dimension no valida.");
                }
                // SQL Server admite un maximo de 2100 parametros por comando.
                for (int i = 0; i < ids.Count; i += 1000)
                {
                    var bloque = ids.Skip(i).Take(1000).ToList();
                    if (habilitadas.Count(id => bloque.Contains(id)) != bloque.Count)
                        throw new ValidationException("Una referencia de " + grupo.Key + " no existe o esta dada de baja.");
                }
            }
        }
        private static ConfiguracionContable LeerConfiguracion(GestionContext db, DbContextTransaction tx, int empresa)
        {
            using (var cmd = Comando(db, tx, "SELECT TOP(1) Datos FROM dbo.ContabilidadConfiguraciones WHERE Empresa=@empresa ORDER BY Version DESC", ("empresa", empresa)))
            {
                var json = cmd.ExecuteScalar() as string;
                return json == null ? null : JsonConvert.DeserializeObject<ConfiguracionContable>(json);
            }
        }
        private static RegistroContable LeerRegistro(GestionContext db, DbContextTransaction tx, int empresa, OperatoriaContable op, int documento)
        {
            using (var cmd = Comando(db, tx, "SELECT Datos FROM dbo.ContabilidadLotes WHERE Empresa=@empresa AND Operatoria=@op AND Documento=@doc AND ReversionDe IS NULL",
                ("empresa", empresa), ("op", (int)op), ("doc", documento)))
            {
                var json = cmd.ExecuteScalar() as string;
                return json == null ? null : JsonConvert.DeserializeObject<RegistroContable>(json);
            }
        }
        private static RegistroContable ObtenerRegistro(GestionContext db, DbContextTransaction tx, int empresa, int id)
        {
            using (var cmd = Comando(db, tx, "SELECT Datos FROM dbo.ContabilidadLotes WHERE Empresa=@empresa AND Id=@id", ("empresa", empresa), ("id", id)))
            {
                var json = cmd.ExecuteScalar() as string ?? throw new ValidationException("No se encontro el lote en la empresa.");
                return JsonConvert.DeserializeObject<RegistroContable>(json);
            }
        }
        private static void BloquearOrigen(GestionContext db, DbContextTransaction tx, OperatoriaContable op, int id)
        {
            string tabla, detalle, fk;
            switch (op)
            {
                case OperatoriaContable.Venta: tabla = "ComprobantesVentas"; detalle = "ComprobantesVentasDetalle"; fk = "Id_ComprobanteVenta"; break;
                case OperatoriaContable.Compra: tabla = "ComprobantesCompras"; detalle = "ComprobantesComprasDetalle"; fk = "Id_ComprobanteCompra"; break;
                case OperatoriaContable.Cobranza: tabla = "Recibos"; detalle = "Recibos_Detalle"; fk = "Id_Recibo"; break;
                case OperatoriaContable.Pago: tabla = "OrdenesPago"; detalle = "OrdenesPagoDetalle"; fk = "Id_OrdenPago"; break;
                case OperatoriaContable.TransferenciaFondos: tabla = "Transferencias"; detalle = "EspeciesCtaCte"; fk = "Id_Comprobante"; break;
                default: throw new ValidationException("Operatoria sin adaptador.");
            }
            Ejecutar(db, tx, "SELECT Id FROM dbo.[" + tabla + "] WITH(HOLDLOCK) WHERE Id=@id; SELECT Id FROM dbo.[" + detalle + "] WITH(HOLDLOCK) WHERE [" + fk + "]=@id", ("id", id));
            if (op == OperatoriaContable.Venta || op == OperatoriaContable.Pago)
            {
                var impuestos = op == OperatoriaContable.Venta ? "ComprobantesVentasImpuestos" : "OrdenesPagoImpuestos";
                Ejecutar(db, tx, "SELECT Id FROM dbo.[" + impuestos + "] WITH(HOLDLOCK) WHERE [" + fk + "]=@id", ("id", id));
            }
        }
        private static DbCommand Comando(GestionContext db, DbContextTransaction tx, string sql, params (string Nombre, object Valor)[] parametros)
        {
            var cmd = db.Database.Connection.CreateCommand();
            cmd.CommandText = sql; cmd.Transaction = tx?.UnderlyingTransaction;
            foreach (var p in parametros)
            {
                var parametro = cmd.CreateParameter(); parametro.ParameterName = "@" + p.Nombre; parametro.Value = p.Valor ?? DBNull.Value;
                cmd.Parameters.Add(parametro);
            }
            return cmd;
        }
        private static void Ejecutar(GestionContext db, DbContextTransaction tx, string sql, params (string Nombre, object Valor)[] parametros)
        {
            using (var cmd = Comando(db, tx, sql, parametros)) cmd.ExecuteNonQuery();
        }
    }
}
