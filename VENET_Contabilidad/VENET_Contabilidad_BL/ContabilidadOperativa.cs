using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json;
using VENET_Common;
using VENET_DataEntity;

namespace VENET_Contabilidad_BL
{
    public enum ModoContable { Manual = 1, Propuesto = 2, Automatico = 3 }
    public enum EstadoCola { Pendiente = 1, Propuesto = 2, Registrado = 3, Error = 4, Anulado = 5 }
    public enum ClaseCuenta { Activo = 1, Pasivo = 2, Patrimonio = 3, Ingreso = 4, Gasto = 5 }
    public sealed class PoliticaContable
    {
        public OperatoriaContable Operatoria { get; set; }
        public ModoContable Modo { get; set; } = ModoContable.Manual;
        public int? UsuarioAutomatico { get; set; }
        [System.ComponentModel.ReadOnly(true)]
        public DateTime Desde { get; set; }
    }
    public sealed class OperativaContable
    {
        [System.ComponentModel.ReadOnly(true)]
        public int Empresa { get; set; }
        public bool Activa { get; set; }
        public int Moneda { get; set; }
        public bool CapturarCosto { get; set; }
        public bool DobleControl { get; set; } = true;
        [System.ComponentModel.ReadOnly(true)]
        public int Version { get; set; }
        public List<PoliticaContable> Politicas { get; set; } = new List<PoliticaContable>();
    }
    public sealed class PendienteContable
    {
        public int Id { get; set; }
        public int Empresa { get; set; }
        public OperatoriaContable Operatoria { get; set; }
        public int Documento { get; set; }
        public int Sucursal { get; set; }
        public int? UsuarioOrigen { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoCola Estado { get; set; }
        public int Intentos { get; set; }
        public string Error { get; set; }
        public string Firma { get; set; }
        public int? Lote { get; set; }
        public bool Anulado { get; set; }
        public string Descripcion { get; set; }
        public bool Aprobado { get; set; }
    }
    public sealed class RevisionLote
    {
        public int Documento { get; set; }
        public OperatoriaContable Operatoria { get; set; }
        public SimulacionContable Simulacion { get; set; }
        public string Error { get; set; }
    }
    public sealed class ClasificacionCuenta
    {
        public int Cuenta { get; set; }
        public ClaseCuenta Clase { get; set; }
        public string Rubro { get; set; }
    }
    public sealed class VinculoCaja
    {
        public int Caja { get; set; }
        public int Cuenta { get; set; }
    }
    public sealed class PeriodoContable
    {
        public DateTime Mes { get; set; }
        public bool Cerrado { get; set; }
        public int Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
    }
    public sealed class CostoHistorico
    {
        public int Detalle { get; set; }
        public int? Producto { get; set; }
        public int? Categoria { get; set; }
        public int MonedaBase { get; set; }
        public int? MonedaCosto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? CantidadStock { get; set; }
        public decimal? CostoUnitario { get; set; }
        public decimal? Cotizacion { get; set; }
        public decimal? CostoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public string Error { get; set; }
    }
    public sealed partial class ContabilidadService
    {
        internal static void ExigirInstalacionProductiva(GestionContext db)
        {
            if (db.Database.SqlQuery<int>("SELECT CASE WHEN OBJECT_ID('dbo.ContabilidadOperativa','U') IS NOT NULL THEN 1 ELSE 0 END").Single() == 0)
                throw new ValidationException("Instale database\\003-ContabilidadProductiva.sql con respaldo y prueba en copia.");
        }
        private static bool PermisoUsuario(GestionContext db, DbContextTransaction tx, int usuario, string formulario, string permiso)
        {
            using (var cmd = Comando(db, tx, @"SELECT COUNT(*) FROM dbo.SeguridadUsuarios u JOIN dbo.SeguridadGrupos g ON g.Id=u.Id_Grupo
                WHERE u.Id=@usuario AND u.UserDel IS NULL AND g.UserDel IS NULL AND (g.EsAdministrador=1 OR EXISTS(
                SELECT 1 FROM dbo.SeguridadGruposObjetos a JOIN dbo.SeguridadObjetos o ON o.Id=a.Id_Objeto
                WHERE a.Id_Grupo=g.Id AND a.UserDel IS NULL AND o.Modulo=9 AND o.Formulario=@formulario AND o.Permiso=@permiso))",
                ("usuario", usuario), ("formulario", formulario), ("permiso", permiso)))
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
        private static void ExigirUsuario(GestionContext db, DbContextTransaction tx, int usuario, string formulario, string permiso)
        {
            if (!PermisoUsuario(db, tx, usuario, formulario, "Ingresar") || !PermisoUsuario(db, tx, usuario, formulario, permiso))
                throw new ValidationException("Usuario sin permiso " + formulario + "/" + permiso + ".");
        }
        public OperativaContable Operativa(int empresa)
        {
            using (var db = Abrir()) { ExigirInstalacionProductiva(db); return LeerOperativa(db, null, empresa); }
        }
        private static OperativaContable LeerOperativa(GestionContext db, DbContextTransaction tx, int empresa)
        {
            var result = new OperativaContable { Empresa = empresa };
            using (var cmd = Comando(db, tx, "SELECT Activa,Moneda,CapturarCosto,DobleControl,Version FROM dbo.ContabilidadOperativa WHERE Empresa=@empresa", ("empresa", empresa)))
            using (var r = cmd.ExecuteReader())
                if (r.Read()) { result.Activa = r.GetBoolean(0); result.Moneda = r.GetInt32(1); result.CapturarCosto = r.GetBoolean(2); result.DobleControl = r.GetBoolean(3); result.Version = r.GetInt32(4); }
            using (var cmd = Comando(db, tx, "SELECT Operatoria,Modo,UsuarioAutomatico,Desde FROM dbo.ContabilidadPoliticas WHERE Empresa=@empresa ORDER BY Operatoria", ("empresa", empresa)))
            using (var r = cmd.ExecuteReader())
                while (r.Read()) result.Politicas.Add(new PoliticaContable
                {
                    Operatoria = (OperatoriaContable)r.GetInt32(0),
                    Modo = (ModoContable)r.GetInt32(1),
                    UsuarioAutomatico = r.IsDBNull(2) ? (int?)null : r.GetInt32(2),
                    Desde = r.GetDateTime(3)
                });
            return result;
        }
        public static void ValidarOperativa(OperativaContable o)
        {
            if (o == null || o.Empresa <= 0 || o.Moneda <= 0 || o.Politicas == null || o.Politicas.Count > 6
                || o.Politicas.Any(p => p == null || !new[] { 1, 2, 3, 4, 7, 13 }.Contains((int)p.Operatoria)
                    || !Enum.IsDefined(typeof(ModoContable), p.Modo)
                    || p.Modo == ModoContable.Automatico && p.UsuarioAutomatico.GetValueOrDefault() <= 0)
                || o.Politicas.GroupBy(p => p.Operatoria).Any(g => g.Count() > 1))
                throw new ValidationException("Politicas de automatizacion invalidas.");
            if (o.Politicas.Any(p => p.Operatoria == OperatoriaContable.CostoVentaAutomatico && p.Modo != ModoContable.Manual) && !o.CapturarCosto)
                throw new ValidationException("Active captura historica para proponer o automatizar costos.");
        }
        public OperativaContable GuardarOperativa(OperativaContable o, int usuario, string motivo)
        {
            ValidarOperativa(o); ValidarMotivo(motivo);
            o = JsonConvert.DeserializeObject<OperativaContable>(JsonConvert.SerializeObject(o));
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db); Bloquear(db, tx, o.Empresa);
                ExigirUsuario(db, tx, usuario, "ContabilidadAutomatizacion", "Modificar");
                var anterior = LeerOperativa(db, tx, o.Empresa);
                if (anterior.Version != o.Version) throw new ValidationException("Politicas modificadas por otro usuario; recargue.");
                var config = LeerConfiguracion(db, tx, o.Empresa) ?? throw new ValidationException("Configure primero el motor contable.");
                if (o.Moneda != config.MonedaBase) throw new ValidationException("La moneda operativa debe coincidir con la moneda base del motor.");
                foreach (var p in o.Politicas.Where(p => p.Modo == ModoContable.Automatico))
                    ExigirUsuario(db, tx, p.UsuarioAutomatico.Value, "ContabilidadAutomatizacion", "Modificar");
                o.Version++;
                Ejecutar(db, tx, @"DELETE dbo.ContabilidadPoliticas WHERE Empresa=@empresa;
                    IF EXISTS(SELECT 1 FROM dbo.ContabilidadOperativa WHERE Empresa=@empresa)
                    UPDATE dbo.ContabilidadOperativa SET Activa=@activa,Moneda=@moneda,CapturarCosto=@costo,DobleControl=@doble,Version=@version,Usuario=@usuario,Fecha=SYSUTCDATETIME() WHERE Empresa=@empresa
                    ELSE INSERT dbo.ContabilidadOperativa VALUES(@empresa,@activa,@moneda,@costo,@doble,@version,@usuario,SYSUTCDATETIME())",
                    ("empresa", o.Empresa), ("activa", o.Activa), ("moneda", o.Moneda), ("costo", o.CapturarCosto),
                    ("doble", o.DobleControl), ("version", o.Version), ("usuario", usuario));
                foreach (var p in o.Politicas)
                {
                    // La activacion automatica nunca alcanza documentos anteriores a su autorizacion.
                    var vieja = anterior.Politicas.SingleOrDefault(x => x.Operatoria == p.Operatoria);
                    p.Desde = vieja != null && vieja.Modo == p.Modo && vieja.UsuarioAutomatico == p.UsuarioAutomatico
                        && anterior.Activa && o.Activa ? vieja.Desde : Sistema.ObtenerFechaHora();
                    Ejecutar(db, tx, "INSERT dbo.ContabilidadPoliticas VALUES(@empresa,@op,@modo,@usuario,@desde)",
                        ("empresa", o.Empresa), ("op", (int)p.Operatoria), ("modo", (int)p.Modo), ("usuario", p.UsuarioAutomatico), ("desde", p.Desde));
                }
                Auditar(db, tx, o.Empresa, usuario, "Politicas", o.Version.ToString(), motivo, o);
                tx.Commit(); return o;
            }
        }
        private static void ValidarMotivo(string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo) || motivo.Trim().Length < 5 || motivo.Length > 500)
                throw new ValidationException("Indique un motivo significativo (5 a 500 caracteres).");
        }
        private static void Auditar(GestionContext db, DbContextTransaction tx, int empresa, int usuario, string accion, string referencia, string motivo, object datos)
        {
            Ejecutar(db, tx, "INSERT dbo.ContabilidadAuditoria(Empresa,Usuario,Accion,Referencia,Motivo,Datos) VALUES(@empresa,@usuario,@accion,@ref,@motivo,@datos)",
                ("empresa", empresa), ("usuario", usuario), ("accion", accion), ("ref", referencia), ("motivo", motivo),
                ("datos", datos == null ? null : JsonConvert.SerializeObject(datos)));
        }
        public List<CostoHistorico> Costos(int empresa, int venta)
        {
            using (var db = Abrir()) { ExigirInstalacionProductiva(db); return LeerCostos(db, null, empresa, venta); }
        }
        private static List<CostoHistorico> LeerCostos(GestionContext db, DbContextTransaction tx, int empresa, int venta)
        {
            using (var cmd = Comando(db, tx, @"SELECT Detalle,Producto,Categoria,MonedaBase,MonedaCosto,Cantidad,CantidadStock,CostoUnitario,Cotizacion,CostoTotal,Fecha,Error
                FROM dbo.ContabilidadCostos WHERE Empresa=@empresa AND Venta=@venta ORDER BY Detalle", ("empresa", empresa), ("venta", venta)))
            using (var r = cmd.ExecuteReader())
            {
                var result = new List<CostoHistorico>();
                while (r.Read()) result.Add(new CostoHistorico
                {
                    Detalle = r.GetInt32(0),
                    Producto = r.IsDBNull(1) ? (int?)null : r.GetInt32(1),
                    Categoria = r.IsDBNull(2) ? (int?)null : r.GetInt32(2),
                    MonedaBase = r.GetInt32(3),
                    MonedaCosto = r.IsDBNull(4) ? (int?)null : r.GetInt32(4),
                    Cantidad = r.GetDecimal(5),
                    CantidadStock = r.IsDBNull(6) ? (decimal?)null : r.GetDecimal(6),
                    CostoUnitario = r.IsDBNull(7) ? (decimal?)null : r.GetDecimal(7),
                    Cotizacion = r.IsDBNull(8) ? (decimal?)null : r.GetDecimal(8),
                    CostoTotal = r.IsDBNull(9) ? (decimal?)null : r.GetDecimal(9),
                    Fecha = r.GetDateTime(10),
                    Error = r.IsDBNull(11) ? null : r.GetString(11)
                });
                return result;
            }
        }
        public static List<PartidaOrigen> PartidasCostos(IEnumerable<CostoHistorico> costos, int moneda)
        {
            var rows = costos.ToList();
            if (rows.Count == 0 || rows.Any(c => c == null || c.MonedaBase != moneda || c.Error != null || !c.Producto.HasValue
                || !c.MonedaCosto.HasValue || c.Cotizacion.GetValueOrDefault() <= 0 || !c.CostoUnitario.HasValue || c.CostoUnitario < 0
                || !c.CostoTotal.HasValue || c.CostoTotal < 0 || c.Cantidad <= 0))
                throw new ValidationException("Costo historico incompleto o moneda distinta; cargue una valuacion complementaria documentada.");
            return rows.Select(c => new PartidaOrigen
            {
                Origen = OrigenContable.Productos,
                Referencia = "Costo historico detalle #" + c.Detalle,
                Producto = c.Producto,
                Categoria = c.Categoria,
                Especie = c.MonedaCosto,
                Costo = c.CostoTotal,
                Importe = c.CostoTotal.Value,
                Total = c.CostoTotal.Value,
                Neto = c.CostoTotal.Value
            }).ToList();
        }
        private static HechoContable ObtenerCosto(GestionContext db, DbContextTransaction tx, int empresa, int venta, int moneda)
        {
            ExigirInstalacionProductiva(db);
            var h = OrigenGestion.Obtener(OperatoriaContable.Venta, venta, db.Database.Connection, tx?.UnderlyingTransaction);
            if (h.Empresa != empresa) throw new ValidationException("Venta ajena a la empresa.");
            var costos = LeerCostos(db, tx, empresa, venta);
            var detalle = db.ComprobantesVentasDetalle.Where(d => d.Id_ComprobanteVenta == venta && d.UserDel == null).ToList();
            if (detalle.Count != costos.Count || detalle.Any(d => !costos.Any(c => c.Detalle == d.Id && c.Producto == d.Id_Producto
                && c.Cantidad == d.Cantidad && c.CantidadStock == d.CantidadStock)))
                throw new ValidationException("El detalle cambio desde la captura historica.");
            h.Operatoria = OperatoriaContable.CostoVentaAutomatico; h.Partidas = PartidasCostos(costos, moneda);
            h.Total = h.Neto = h.Partidas.Sum(p => p.Importe); h.Iva = 0; return h;
        }
        public static void ValidarPeriodoAbierto(GestionContext db, int empresa, DateTime fecha)
        {
            var mes = new DateTime(fecha.Year, fecha.Month, 1);
            if (db.Database.SqlQuery<int>(@"IF OBJECT_ID('dbo.ContabilidadPeriodos','U') IS NULL SELECT 0
                ELSE SELECT COUNT(*) FROM dbo.ContabilidadPeriodos WHERE Empresa=@p0 AND Mes=@p1 AND Cerrado=1", empresa, mes).Single() > 0)
                throw new ValidationException("El periodo contable esta bloqueado. Requiere reapertura autorizada y auditada.");
        }
        public static void ValidarEdicionManual(GestionContext db, int empresa)
        {
            if (db.Database.SqlQuery<int>(@"IF OBJECT_ID('dbo.ContabilidadOperativa','U') IS NULL SELECT 0
                ELSE SELECT COUNT(*) FROM dbo.ContabilidadOperativa WHERE Empresa=@p0 AND DobleControl=1", empresa).Single() > 0)
                throw new ValidationException("Con doble control no se editan asientos directamente. Prepare un documento Ajuste con respaldo y aprobacion independiente; revierta los errores conservando el original.");
        }
        public List<KeyNamePair> UsuariosAutomaticos(int usuario)
        {
            using (var db = Abrir())
            {
                ExigirUsuario(db, null, usuario, "ContabilidadAutomatizacion", "Buscar");
                return db.SeguridadUsuarios.Where(u => u.UserDel == null).ToList()
                    .Where(u => PermisoUsuario(db, null, u.Id, "ContabilidadAutomatizacion", "Ingresar")
                        && PermisoUsuario(db, null, u.Id, "ContabilidadAutomatizacion", "Modificar"))
                    .Select(u => new KeyNamePair { Key = u.Id, Name = u.Apellido + ", " + u.Nombre + " (" + u.Username + ")" }).ToList();
            }
        }
        public List<PeriodoContable> Periodos(int empresa)
        {
            using (var db = Abrir())
            {
                ExigirInstalacionProductiva(db);
                using (var cmd = Comando(db, null, "SELECT Mes,Cerrado,Usuario,Fecha,Motivo FROM dbo.ContabilidadPeriodos WHERE Empresa=@empresa ORDER BY Mes DESC", ("empresa", empresa)))
                using (var r = cmd.ExecuteReader())
                {
                    var result = new List<PeriodoContable>();
                    while (r.Read()) result.Add(new PeriodoContable { Mes = r.GetDateTime(0), Cerrado = r.GetBoolean(1), Usuario = r.GetInt32(2), Fecha = r.GetDateTime(3), Motivo = r.GetString(4) });
                    return result;
                }
            }
        }
        public void CambiarPeriodo(int empresa, DateTime mes, bool cerrar, string motivo, int usuario)
        {
            ValidarMotivo(motivo);
            if (mes.Year < 1753 || mes.Year >= 9999 || mes.Day != 1) throw new ValidationException("Seleccione el primer dia del mes.");
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                ExigirInstalacionProductiva(db); Bloquear(db, tx, empresa);
                ExigirUsuario(db, tx, usuario, "ContabilidadPeriodos", cerrar ? "Modificar" : "Reabrir");
                if (!cerrar && db.EjerciciosContables.Any(e => e.Id_Empresa == empresa && e.UserDel == null && e.Cerrado
                    && e.VigenciaDesde < mes.AddMonths(1) && e.VigenciaHasta >= mes))
                    throw new ValidationException("No se puede reabrir un mes de un ejercicio cerrado; requiere correcciones en un ejercicio abierto.");
                Ejecutar(db, tx, @"IF EXISTS(SELECT 1 FROM dbo.ContabilidadPeriodos WHERE Empresa=@empresa AND Mes=@mes)
                    UPDATE dbo.ContabilidadPeriodos SET Cerrado=@cerrado,Usuario=@usuario,Fecha=SYSUTCDATETIME(),Motivo=@motivo WHERE Empresa=@empresa AND Mes=@mes
                    ELSE INSERT dbo.ContabilidadPeriodos VALUES(@empresa,@mes,@cerrado,@usuario,SYSUTCDATETIME(),@motivo)",
                    ("empresa", empresa), ("mes", mes), ("cerrado", cerrar), ("usuario", usuario), ("motivo", motivo));
                Auditar(db, tx, empresa, usuario, cerrar ? "Bloquear mes" : "Reabrir mes", mes.ToString("yyyy-MM"), motivo, null);
                tx.Commit();
            }
        }
    }
}
