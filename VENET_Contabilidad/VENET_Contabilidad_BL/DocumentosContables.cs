using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json;
using VENET_Common;
using VENET_DataEntity;

namespace VENET_Contabilidad_BL
{
    public sealed class DocumentoContable
    {
        public int Id { get; set; }
        public Guid Clave { get; set; }
        public HechoContable Hecho { get; set; }
        public int Moneda { get; set; }
        public string Respaldo { get; set; }
        public int Usuario { get; set; }
        public DateTime Creado { get; set; }
        public int? EjercicioOrigen { get; set; }
        public string FirmaSaldos { get; set; }
    }
    public sealed class SaldoCuenta
    {
        public int Cuenta { get; set; }
        public string Nombre { get; set; }
        public decimal Anterior { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal Saldo => Anterior + Debe - Haber;
    }
    public sealed class MovimientoMayor
    {
        public int Asiento { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal Saldo { get; set; }
    }
    public sealed class MayorContable
    {
        public decimal Anterior { get; set; }
        public List<MovimientoMayor> Movimientos { get; set; }
        public decimal Saldo { get; set; }
    }
    public sealed partial class ContabilidadService
    {
        public static bool Complementario(OperatoriaContable op) => op == OperatoriaContable.CostoVenta || op == OperatoriaContable.MovimientoStock
            || op == OperatoriaContable.LiquidacionSueldos || op == OperatoriaContable.Devengamiento || op == OperatoriaContable.Ajuste
            || op == OperatoriaContable.Apertura || op == OperatoriaContable.Cierre;

        public static void ValidarDocumento(DocumentoContable d)
        {
            var h = d?.Hecho;
            if (h == null || d.Clave == Guid.Empty || d.Moneda <= 0 || h.Empresa <= 0 || h.Sucursal <= 0
                || h.Fecha.Year < 1753 || string.IsNullOrWhiteSpace(h.Descripcion) || h.Descripcion.Length > 300
                || string.IsNullOrWhiteSpace(d.Respaldo) || d.Respaldo.Length > 500 || !Complementario(h.Operatoria)
                || h.Operatoria == OperatoriaContable.Apertura || h.Operatoria == OperatoriaContable.Cierre
                || h.Partidas == null || h.Partidas.Count == 0 || h.Partidas.Count > 500)
                throw new ValidationException("Documento complementario incompleto. Indique moneda local, fecha, respaldo y partidas.");
            foreach (var p in h.Partidas)
            {
                if (p == null || string.IsNullOrWhiteSpace(p.Referencia) || p.Referencia.Length > 200 || p.Importe == 0
                    || Math.Abs(p.Importe) > 2147483647 || decimal.Round(p.Importe, 2) != p.Importe
                    || p.Producto <= 0 || p.Personal <= 0 || p.Concepto <= 0 || p.Categoria <= 0
                    || p.CuentaOrigen.HasValue || p.Caja.HasValue || p.Especie.HasValue)
                    throw new ValidationException("Partida complementaria invalida.");
                if (h.Operatoria == OperatoriaContable.CostoVenta || h.Operatoria == OperatoriaContable.MovimientoStock)
                {
                    if (p.Origen != OrigenContable.Productos || !p.Producto.HasValue)
                        throw new ValidationException("Costos y stock requieren productos y valuaciones historicas documentadas.");
                }
                else if (p.Origen != OrigenContable.Conceptos || !p.Concepto.HasValue)
                    throw new ValidationException("Sueldos, devengamientos y ajustes requieren partidas con concepto.");
            }
        }

        public DocumentoContable CrearDocumento(DocumentoContable solicitud, int usuario)
        {
            ValidarDocumento(solicitud);
            if (usuario <= 0) throw new ValidationException("Usuario no valido.");
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                Bloquear(db, tx, solicitud.Hecho.Empresa);
                var previo = DocumentoPorClave(db, tx, solicitud.Hecho.Empresa, solicitud.Clave);
                if (previo != null)
                {
                    if (FirmaDocumento(previo) != FirmaDocumento(solicitud))
                        throw new ValidationException("La clave de reintento ya pertenece a otro contenido. Cree un nuevo documento.");
                    return previo;
                }
                var config = LeerConfiguracion(db, tx, solicitud.Hecho.Empresa) ?? throw new ValidationException("Falta configuracion contable.");
                if (config.MonedaBase != solicitud.Moneda) throw new ValidationException("Los importes deben estar en la moneda local configurada.");
                Ejercicio(db, solicitud.Hecho.Empresa, solicitud.Hecho.Fecha.Date);
                if (!db.Sucursales.Any(s => s.Id == solicitud.Hecho.Sucursal && s.Id_Empresa == solicitud.Hecho.Empresa && s.UserDel == null))
                    throw new ValidationException("Sucursal ajena a la empresa.");
                var doc = JsonConvert.DeserializeObject<DocumentoContable>(JsonConvert.SerializeObject(solicitud));
                doc.Id = 0; doc.Usuario = usuario; doc.Creado = Sistema.ObtenerFechaHora();
                doc.EjercicioOrigen = null; doc.FirmaSaldos = null;
                doc.Hecho.Documento = 0; doc.Hecho.Fecha = doc.Hecho.Fecha.Date;
                doc.Hecho.Cliente = doc.Hecho.Proveedor = doc.Hecho.FormaPago = null;
                doc.Hecho.TipoComprobante = 0;
                foreach (var p in doc.Hecho.Partidas)
                {
                    if (p.Producto.HasValue)
                    {
                        var producto = db.Productos.SingleOrDefault(x => x.Id == p.Producto && x.UserDel == null)
                            ?? throw new ValidationException("Producto inexistente o dado de baja.");
                        p.Categoria = producto.Id_Categoria;
                    }
                    if (p.Personal.HasValue && !db.Personal.Any(x => x.Id == p.Personal && x.UserDel == null))
                        throw new ValidationException("Personal inexistente o dado de baja.");
                    p.Total = p.Neto = p.Importe; p.Iva = 0;
                    p.Costo = p.Origen == OrigenContable.Productos ? (decimal?)p.Importe : null;
                    p.SaldoDeudor = p.SaldoAcreedor = 0; p.Impuesto = null; p.Medio = null; p.Componente = null; p.FormaPago = null;
                }
                doc.Hecho.Total = doc.Hecho.Neto = doc.Hecho.Partidas.Sum(p => p.Importe);
                doc.Hecho.Iva = 0;
                InsertarDocumento(db, tx, doc);
                tx.Commit(); return doc;
            }
        }

        private static string FirmaDocumento(DocumentoContable d) => MotorContable.Firma(new
        {
            d.Moneda,
            d.Respaldo,
            d.Hecho.Empresa,
            d.Hecho.Operatoria,
            d.Hecho.Sucursal,
            Fecha = d.Hecho.Fecha.Date,
            d.Hecho.Descripcion,
            Partidas = d.Hecho.Partidas.Select(p => new { p.Origen, p.Referencia, p.Importe, p.Producto, p.Personal, p.Concepto }).ToList()
        });

        public List<DocumentoContable> Documentos(int empresa, OperatoriaContable op, string buscar)
        {
            if (!Complementario(op) || (buscar ?? "").Length > 100) throw new ValidationException("Consulta de documentos no valida.");
            using (var db = Abrir())
            using (var cmd = Comando(db, null, "SELECT TOP(30) Datos FROM dbo.ContabilidadDocumentos WHERE Empresa=@empresa AND Operatoria=@op AND Descripcion LIKE @buscar ORDER BY Id DESC",
                ("empresa", empresa), ("op", (int)op), ("buscar", "%" + (buscar ?? "").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") + "%")))
            using (var r = cmd.ExecuteReader())
            {
                var result = new List<DocumentoContable>();
                while (r.Read()) result.Add(JsonConvert.DeserializeObject<DocumentoContable>(r.GetString(0)));
                return result;
            }
        }
        public HechoContable CabeceraDocumento(int empresa, OperatoriaContable op, int id)
        {
            using (var db = Abrir())
            using (var cmd = Comando(db, null, "SELECT Datos FROM dbo.ContabilidadDocumentos WHERE Empresa=@empresa AND Operatoria=@op AND Id=@id",
                ("empresa", empresa), ("op", (int)op), ("id", id)))
                return JsonConvert.DeserializeObject<DocumentoContable>(cmd.ExecuteScalar() as string
                    ?? throw new ValidationException("Documento contable no encontrado.")).Hecho;
        }
        private static HechoContable ObtenerHecho(GestionContext db, DbContextTransaction tx, int empresa, OperatoriaContable op, int id, int moneda)
        {
            if (op == OperatoriaContable.CostoVentaAutomatico) return ObtenerCosto(db, tx, empresa, id, moneda);
            if (!Complementario(op)) return OrigenGestion.Obtener(op, id, db.Database.Connection, tx?.UnderlyingTransaction);
            DocumentoContable doc;
            using (var cmd = Comando(db, tx, "SELECT Datos FROM dbo.ContabilidadDocumentos WHERE Empresa=@empresa AND Operatoria=@op AND Id=@id",
                ("empresa", empresa), ("op", (int)op), ("id", id)))
                doc = JsonConvert.DeserializeObject<DocumentoContable>(cmd.ExecuteScalar() as string ?? throw new ValidationException("Documento contable no encontrado."));
            if (doc.Moneda != moneda) throw new ValidationException("La moneda configurada cambio desde la aprobacion del documento.");
            if (doc.EjercicioOrigen.HasValue)
            {
                var ejercicio = db.EjerciciosContables.SingleOrDefault(e => e.Id == doc.EjercicioOrigen && e.Id_Empresa == empresa && e.UserDel == null)
                    ?? throw new ValidationException("El ejercicio de origen ya no esta disponible.");
                using (var cmd = Comando(db, tx, @"SELECT COUNT(*) FROM dbo.ContabilidadLotes l
                    INNER JOIN dbo.ContabilidadDocumentos d ON d.Id=l.Documento AND d.Operatoria=l.Operatoria AND d.Empresa=l.Empresa
                    WHERE l.Empresa=@empresa AND l.Operatoria=@op AND d.EjercicioOrigen=@ejercicio AND l.ReversionDe IS NULL",
                    ("empresa", empresa), ("op", (int)op), ("ejercicio", ejercicio.Id)))
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        throw new ValidationException("El ejercicio ya tiene un lote de esta operatoria. No se permite duplicar apertura/cierre.");
                var hecho = HechoSaldos(db, empresa, moneda, ejercicio, op, doc.Hecho.Fecha, doc.Hecho.Sucursal);
                if (MotorContable.Firma(hecho.Partidas) != doc.FirmaSaldos)
                    throw new ValidationException("Cambiaron los saldos de origen. Prepare un nuevo documento de apertura/cierre.");
                hecho.Documento = id;
                return hecho;
            }
            return doc.Hecho;
        }
        private static DocumentoContable DocumentoPorClave(GestionContext db, DbContextTransaction tx, int empresa, Guid clave)
        {
            using (var cmd = Comando(db, tx, "SELECT Datos FROM dbo.ContabilidadDocumentos WHERE Empresa=@empresa AND Clave=@clave", ("empresa", empresa), ("clave", clave)))
            {
                var json = cmd.ExecuteScalar() as string;
                return json == null ? null : JsonConvert.DeserializeObject<DocumentoContable>(json);
            }
        }
        private static void InsertarDocumento(GestionContext db, DbContextTransaction tx, DocumentoContable doc)
        {
            using (var cmd = Comando(db, tx, "INSERT dbo.ContabilidadDocumentos(Empresa,Operatoria,Clave,Descripcion,EjercicioOrigen,Datos) OUTPUT INSERTED.Id VALUES(@empresa,@op,@clave,@descripcion,@ejercicio,N'')",
                ("empresa", doc.Hecho.Empresa), ("op", (int)doc.Hecho.Operatoria), ("clave", doc.Clave), ("descripcion", doc.Hecho.Descripcion), ("ejercicio", doc.EjercicioOrigen)))
                doc.Id = Convert.ToInt32(cmd.ExecuteScalar());
            doc.Hecho.Documento = doc.Id;
            Ejecutar(db, tx, "UPDATE dbo.ContabilidadDocumentos SET Datos=@datos WHERE Id=@id", ("datos", JsonConvert.SerializeObject(doc)), ("id", doc.Id));
            if (db.Database.SqlQuery<int>("SELECT CASE WHEN OBJECT_ID('dbo.ContabilidadCola','U') IS NULL THEN 0 ELSE 1 END").Single() == 1)
                Ejecutar(db, tx, @"INSERT dbo.ContabilidadCola(Empresa,Operatoria,Documento,Sucursal,UsuarioOrigen,FechaOrigen)
                    VALUES(@empresa,@op,@doc,@sucursal,@usuario,@fecha)",
                    ("empresa", doc.Hecho.Empresa), ("op", (int)doc.Hecho.Operatoria), ("doc", doc.Id),
                    ("sucursal", doc.Hecho.Sucursal), ("usuario", doc.Usuario), ("fecha", doc.Hecho.Fecha));
        }
    }
}
