using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;

namespace VENET_Gestion_BL
{
    public sealed class ComprasDocumentosService
    {
        private static int Usuario => Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
        public static void ExigirPermiso()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Ingresar)
                || !Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Agregar))
                throw new ValidationException("Requiere permiso Ingresar y Agregar en ComprobantesCompras.");
        }
        private static void Sucursal(int id)
        {
            ExigirPermiso();
            if (Usuario <= 0 || !Sistema.Sucursales.Any(s => s.Id_Sucursal == id))
                throw new ValidationException("Sucursal no habilitada para su usuario.");
        }
        private static GestionContext Abrir()
        {
            var db = new GestionContext();
            try
            {
                db.Database.Connection.Open();
                if (db.Database.SqlQuery<int>("SELECT CASE WHEN OBJECT_ID('dbo.ComprasDocumentos','U') IS NULL THEN 0 ELSE 1 END").Single() == 0)
                    throw new ValidationException("Instale database\\004-ComprasDocumentos.sql con respaldo y prueba en copia.");
                return db;
            }
            catch { db.Dispose(); throw; }
        }
        private static DbCommand Cmd(GestionContext db, DbContextTransaction tx, string sql, params object[] valores)
        {
            var cmd = db.Database.Connection.CreateCommand();
            cmd.Transaction = tx?.UnderlyingTransaction; cmd.CommandText = sql;
            for (int i = 0; i < valores.Length; i += 2)
            {
                var p = cmd.CreateParameter(); p.ParameterName = "@" + valores[i]; p.Value = valores[i + 1] ?? DBNull.Value;
                if (p.Value is byte[]) { p.DbType = DbType.Binary; p.Size = -1; }
                else if (p.Value is string) { p.DbType = DbType.String; p.Size = -1; }
                cmd.Parameters.Add(p);
            }
            return cmd;
        }
        private static void Ejecutar(GestionContext db, DbContextTransaction tx, string sql, params object[] valores)
        { using (var c = Cmd(db, tx, sql, valores)) c.ExecuteNonQuery(); }
        private static void Auditar(GestionContext db, DbContextTransaction tx, Guid id, string accion, object datos)
        {
            Ejecutar(db, tx, "INSERT dbo.ComprasDocumentosAuditoria(Documento,Usuario,Accion,Datos) VALUES(@id,@u,@a,@d)",
                "id", id, "u", Usuario, "a", accion, "d", datos == null ? null : JsonConvert.SerializeObject(datos));
        }
        public OpcionesComprasDocumento Opciones()
        {
            ExigirPermiso();
            using (var db = new GestionContext())
                return new OpcionesComprasDocumento
                {
                    Configurado = ComprasDocumentosLector.Configurado,
                    Modelo = ComprasDocumentosLector.Modelo,
                    Sucursales = Sistema.Sucursales.Select(s => new KeyNamePair { Key = s.Id_Sucursal, Name = s.Sucursal }).ToList(),
                    Proveedores = Sistema.ObtenerEntidades(Enums.TipoEntidad.Proveedor),
                    Tipos = Sistema.TipoComprobanteCompras,
                    Depositos = Sistema.Depositos.Select(p => new KeyNamePair { Key = p.Key, Name = p.Name }).ToList(),
                    Centros = Sistema.CentrosCostos.Select(p => new KeyNamePair { Key = p.Key, Name = p.Name }).ToList(),
                    Formas = Sistema.FormasPagos,
                    Monedas = Sistema.Especies.Select(e => new KeyNamePair { Key = e.Key, Name = e.Name }).ToList(),
                    Alicuotas = db.IvaAlicuotas.Where(a => a.UserDel == null).Select(a => a.Alicuota).ToList()
                };
        }
        public List<KeyNamePair> Productos(string buscar, int? id = null)
        {
            ExigirPermiso();
            if (id.HasValue)
                using (var db = new GestionContext())
                    return db.Productos.Where(p => p.UserDel == null && p.Id == id)
                        .Select(p => new KeyNamePair { Key = p.Id, Name = p.Codigo + " - " + p.Descripcion }).ToList();
            if (string.IsNullOrWhiteSpace(buscar) || buscar.Length > 100) throw new ValidationException("Busque producto por codigo, barras o descripcion (1 a 100 caracteres).");
            using (var db = new GestionContext())
                return db.Productos.Where(p => p.UserDel == null && (p.Codigo.Contains(buscar) || p.CodigoBarras.Contains(buscar) || p.Descripcion.Contains(buscar)))
                    .OrderBy(p => p.Descripcion).Take(50).Select(p => new KeyNamePair { Key = p.Id, Name = p.Codigo + " - " + p.Descripcion }).ToList();
        }
        public List<KeyNamePair> ProductosPorId(List<int> ids)
        {
            ExigirPermiso();
            if (ids == null || ids.Count > 200) throw new ValidationException("Seleccione hasta 200 productos.");
            using (var db = new GestionContext())
                return db.Productos.Where(p => p.UserDel == null && ids.Contains(p.Id))
                    .Select(p => new KeyNamePair { Key = p.Id, Name = p.Codigo + " - " + p.Descripcion }).ToList();
        }
        public ImportacionCompra Cargar(Guid id, int sucursal, List<ArchivoCompra> archivos)
        {
            Sucursal(sucursal);
            if (id == Guid.Empty) throw new ValidationException("Falta clave de carga.");
            var validos = ComprasDocumentosLector.ValidarArchivos(archivos);
            // Valida tambien contenido y limite de paginas antes de persistir, sin enviar nada al lector.
            ComprasDocumentosLector.Paginas(validos);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                Bloquear(db, tx, "carga:" + id);
                using (var c = Cmd(db, tx, "SELECT COUNT(*) FROM dbo.ComprasDocumentos WHERE Id=@id", "id", id))
                    if (Convert.ToInt32(c.ExecuteScalar()) > 0)
                    {
                        var previo = Leer(db, tx, id);
                        var existentes = Archivos(db, tx, id);
                        if (previo.Sucursal != sucursal || existentes.Count != validos.Count || existentes.Where((a, n) =>
                            a.Nombre != validos[n].Nombre || Hash(a.Datos) != Hash(validos[n].Datos)).Any())
                            throw new ValidationException("La clave ya corresponde a otra carga. Recargue la lista.");
                        return previo;
                    }
                Ejecutar(db, tx, "INSERT dbo.ComprasDocumentos(Id,Usuario,Sucursal,Estado) VALUES(@id,@u,@s,'Cargado')",
                    "id", id, "u", Usuario, "s", sucursal);
                for (int i = 0; i < validos.Count; i++)
                {
                    var a = validos[i];
                    Ejecutar(db, tx, "INSERT dbo.ComprasDocumentosArchivos VALUES(@id,@orden,@nombre,@mime,@hash,@datos)",
                        "id", id, "orden", i, "nombre", a.Nombre, "mime", a.Mime, "hash", Hash(a.Datos), "datos", a.Datos);
                }
                Auditar(db, tx, id, "Cargar originales", validos.Select(a => new { a.Nombre, hash = Hash(a.Datos) }));
                tx.Commit();
            }
            return Obtener(id);
        }
        private static void Bloquear(GestionContext db, DbContextTransaction tx, string clave)
        {
            using (var c = Cmd(db, tx, "DECLARE @r int; EXEC @r=sys.sp_getapplock @Resource=@recurso,@LockMode='Exclusive',@LockOwner='Transaction',@LockTimeout=10000; SELECT @r",
                "recurso", "SIGNET:CompraDocumento:" + clave))
                if (Convert.ToInt32(c.ExecuteScalar()) < 0) throw new ValidationException("Otra operacion esta trabajando sobre la compra. Reintente.");
        }
        public List<ImportacionCompra> Listar()
        {
            ExigirPermiso();
            using (var db = Abrir())
            {
                var sucursales = Sistema.Sucursales.Select(s => s.Id_Sucursal).ToList();
                var ids = new List<Guid>();
                using (var c = Cmd(db, null, "SELECT TOP(100) Id,Sucursal FROM dbo.ComprasDocumentos WHERE Usuario=@u ORDER BY Fecha DESC", "u", Usuario))
                using (var reader = c.ExecuteReader()) while (reader.Read()) if (sucursales.Contains(reader.GetInt32(1))) ids.Add(reader.GetGuid(0));
                return ids.Select(id => Leer(db, null, id)).ToList();
            }
        }
        public ImportacionCompra Obtener(Guid id)
        { ExigirPermiso(); using (var db = Abrir()) return Leer(db, null, id); }
        private static ImportacionCompra Leer(GestionContext db, DbContextTransaction tx, Guid id)
        {
            ImportacionCompra result;
            using (var c = Cmd(db, tx, "SELECT Usuario,Sucursal,Version,Estado,Error,Fecha,Compra,Lectura,Revision FROM dbo.ComprasDocumentos WHERE Id=@id", "id", id))
            using (var r = c.ExecuteReader())
            {
                if (!r.Read() || r.GetInt32(0) != Usuario) throw new ValidationException("Importacion no disponible para su usuario.");
                Sucursal(r.GetInt32(1));
                result = new ImportacionCompra
                {
                    Id = id,
                    Sucursal = r.GetInt32(1),
                    Version = r.GetInt32(2),
                    Estado = r.GetString(3),
                    Error = r.IsDBNull(4) ? null : r.GetString(4),
                    Fecha = r.GetDateTime(5),
                    Compra = r.IsDBNull(6) ? (int?)null : r.GetInt32(6),
                    Lectura = r.IsDBNull(7) ? null : JsonConvert.DeserializeObject<DocumentoCompraLeido>(r.GetString(7)),
                    Revision = r.IsDBNull(8) ? null : JsonConvert.DeserializeObject<RevisionCompraDocumento>(r.GetString(8))
                };
            }
            using (var c = Cmd(db, tx, "SELECT Nombre FROM dbo.ComprasDocumentosArchivos WHERE Documento=@id ORDER BY Orden", "id", id))
            using (var r = c.ExecuteReader()) while (r.Read()) result.Archivos.Add(r.GetString(0));
            return result;
        }
        private static List<ArchivoCompraValidado> Archivos(GestionContext db, DbContextTransaction tx, Guid id)
        {
            var result = new List<ArchivoCompraValidado>();
            using (var c = Cmd(db, tx, "SELECT Nombre,Mime,Datos FROM dbo.ComprasDocumentosArchivos WHERE Documento=@id ORDER BY Orden", "id", id))
            using (var r = c.ExecuteReader()) while (r.Read()) result.Add(new ArchivoCompraValidado { Nombre = r.GetString(0), Mime = r.GetString(1), Datos = (byte[])r[2] });
            return result;
        }
        public ArchivoCompraValidado Original(Guid id, int orden)
        {
            ExigirPermiso();
            using (var db = Abrir())
            {
                Leer(db, null, id); var archivos = Archivos(db, null, id);
                if (orden < 0 || orden >= archivos.Count) throw new ValidationException("Original no disponible.");
                return archivos[orden];
            }
        }
        public List<byte[]> Vista(Guid id)
        {
            ExigirPermiso();
            using (var db = Abrir())
            {
                Leer(db, null, id);
                return ComprasDocumentosLector.Paginas(Archivos(db, null, id));
            }
        }
        public async Task<ImportacionCompra> AnalizarAsync(Guid id, int version, CancellationToken ct)
        {
            ExigirPermiso();
            List<ArchivoCompraValidado> archivos;
            using (var db = Abrir())
            {
                var carga = Leer(db, null, id);
                if (carga.Compra.HasValue || carga.Version != version) throw new ValidationException("La carga cambio o ya fue guardada; recargue.");
                archivos = Archivos(db, null, id);
            }
            DocumentoCompraLeido lectura = null; string error = null;
            try { lectura = await new ComprasDocumentosLector().LeerAsync(ComprasDocumentosLector.Paginas(archivos), ct).ConfigureAwait(false); }
            catch (ValidationException e) { error = e.Message; }
            catch (HttpRequestException) { error = "No se pudo completar la comunicacion con el lector local (conexion o respuesta mayor a 1 MB). Revise el servidor y su modelo; sus originales permanecen guardados."; }
            catch (OperationCanceledException) { error = "Lectura cancelada o vencida. Puede reintentar desde la lista; no se genero una compra."; }
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                Bloquear(db, tx, "carga:" + id);
                var actual = Leer(db, tx, id);
                if (actual.Version != version || actual.Compra.HasValue) throw new ValidationException("Otro proceso modifico la carga. Recargue para conservar su revision.");
                Ejecutar(db, tx, "UPDATE dbo.ComprasDocumentos SET Version=Version+1,Estado=@estado,Lectura=@datos,Revision=NULL,Error=@error WHERE Id=@id",
                    "estado", error == null ? "Leido" : "Error", "datos", lectura == null ? null : JsonConvert.SerializeObject(lectura), "error", error, "id", id);
                Auditar(db, tx, id, error == null ? "Leer documento" : "Error de lectura",
                    new { modelo = ComprasDocumentosLector.Modelo, error, lectura, lecturaAnterior = actual.Lectura, revisionAnterior = actual.Revision });
                tx.Commit();
            }
            return Obtener(id);
        }
        public RevisionCompraDocumento Proponer(Guid id)
        {
            var carga = Obtener(id);
            if (carga.Revision != null) { carga.Revision.Version = carga.Version; return carga.Revision; }
            if (carga.Lectura == null) throw new ValidationException("Lea el documento primero.");
            var r = new RevisionCompraDocumento
            {
                Id = id,
                Version = carga.Version,
                Sucursal = carga.Sucursal,
                Documento = carga.Lectura,
                Recepcion = DateTime.Today,
                Vencimiento = carga.Lectura.Fecha ?? DateTime.Today
            };
            using (var db = Abrir())
            {
                var permitidos = Sistema.ObtenerEntidades(Enums.TipoEntidad.Proveedor).Select(p => p.Key).ToList();
                var cuit = CalculoCompraDocumento.NormalizarCuit(r.Documento.Cuit);
                var proveedores = db.Proveedores.Where(p => p.UserDel == null && permitidos.Contains(p.Id)).ToList()
                    .Where(p => cuit.Length == 11 && CalculoCompraDocumento.NormalizarCuit(p.Cuit) == cuit).ToList();
                if (proveedores.Count == 1) r.Proveedor = proveedores[0].Id;
                SugerirProductos(db, r);
            }
            return r;
        }
        private static void SugerirProductos(GestionContext db, RevisionCompraDocumento r)
        {
            foreach (var item in r.Documento.Items)
            {
                if (item.Producto.HasValue) continue;
                if (!string.IsNullOrWhiteSpace(item.Codigo) && item.Codigo.Length <= 150 && r.Proveedor > 0)
                    using (var c = Cmd(db, null, "SELECT e.Producto FROM dbo.ComprasDocumentosEquivalencias e JOIN dbo.Productos p ON p.Id=e.Producto AND p.UserDel IS NULL WHERE Proveedor=@p AND Codigo=@c",
                        "p", r.Proveedor, "c", item.Codigo.Trim().ToUpperInvariant()))
                    {
                        var valor = c.ExecuteScalar();
                        if (valor != null) item.Producto = Convert.ToInt32(valor);
                    }
                if (!item.Producto.HasValue)
                {
                    var codigo = item.Codigo;
                    var ids = db.Productos.Where(p => p.UserDel == null && (codigo != null && codigo != "" && (p.Codigo == codigo || p.CodigoBarras == codigo)
                        || p.Descripcion == item.Descripcion)).Select(p => p.Id).Take(2).ToList();
                    if (ids.Count == 1) item.Producto = ids[0];
                }
            }
        }
        public ResultadoRevisionCompra Revisar(RevisionCompraDocumento r)
        {
            ExigirPermiso(); Sucursal(r?.Sucursal ?? 0);
            using (var db = Abrir())
            {
                var actual = Leer(db, null, r.Id);
                if (actual.Sucursal != r.Sucursal || actual.Version != r.Version || actual.Compra.HasValue)
                    throw new ValidationException("Importacion modificada o guardada. Recargue.");
                return ValidarReferencias(db, r);
            }
        }
        private static ResultadoRevisionCompra ValidarReferencias(GestionContext db, RevisionCompraDocumento r)
        {
            var result = CalculoCompraDocumento.Validar(r);
            if (result.Errores.Count != 0) return result;
            if (!Sistema.ObtenerEntidades(Enums.TipoEntidad.Proveedor).Any(p => p.Key == r.Proveedor)
                || !Sistema.TipoComprobanteCompras.Any(p => p.Key == r.TipoComprobante)
                || !Sistema.Depositos.Any(p => p.Key == r.Deposito) || !Sistema.CentrosCostos.Any(p => p.Key == r.CentroCosto)
                || !Sistema.FormasPagos.Any(p => p.Key == r.FormaPago) || !Sistema.Especies.Any(p => p.Key == r.Moneda))
                result.Errores.Add("Hay referencias fuera de sus permisos o dadas de baja.");
            var proveedor = db.Proveedores.SingleOrDefault(p => p.Id == r.Proveedor && p.UserDel == null);
            if (proveedor == null || CalculoCompraDocumento.NormalizarCuit(proveedor.Cuit) != CalculoCompraDocumento.NormalizarCuit(r.Documento.Cuit))
                result.Errores.Add("El CUIT del documento no coincide con el proveedor seleccionado.");
            foreach (var item in r.Documento.Items)
            {
                var producto = db.Productos.SingleOrDefault(p => p.Id == item.Producto && p.UserDel == null);
                if (producto == null) result.Errores.Add("Producto inexistente o inactivo: " + item.Descripcion);
                else if (producto.Id_UnidadStock > 0 && (!item.CantidadStock.HasValue || item.CantidadStock <= 0))
                    result.Errores.Add("Indique cantidad de stock/conversion de unidad para " + item.Descripcion + ".");
                if (!db.IvaAlicuotas.Any(a => a.UserDel == null && a.Alicuota == item.Iva))
                    result.Errores.Add("Alicuota no configurada: " + item.Iva + ".");
                if (item.RecordarEquivalencia && (string.IsNullOrWhiteSpace(item.Codigo) || item.Codigo.Length > 150))
                    result.Errores.Add("Para recordar equivalencia se requiere codigo del proveedor de hasta 150 caracteres.");
            }
            if (r.Documento.Items.Where(i => i.RecordarEquivalencia).GroupBy(i => (i.Codigo ?? "").Trim().ToUpperInvariant())
                .Any(g => g.Select(i => i.Producto).Distinct().Count() > 1))
                result.Errores.Add("Un mismo codigo de proveedor no puede recordarse para productos distintos.");
            using (var c = Cmd(db, db.Database.CurrentTransaction,
                @"SELECT COUNT(*) FROM dbo.ComprobantesCompras WHERE UserDel IS NULL AND FechaAnulacion IS NULL
                    AND Id_TipoEntidad=@entidad AND Id_Entidad=@proveedor AND Id_TipoComprobante=@tipo AND Letra=@letra
                    AND TRY_CONVERT(int,PuntoVenta)=@punto AND TRY_CONVERT(int,NroComprobante)=@numero",
                "entidad", (int)Enums.TipoEntidad.Proveedor, "proveedor", r.Proveedor, "tipo", r.TipoComprobante,
                "letra", r.Documento.Letra, "punto", int.Parse(r.Documento.PuntoVenta), "numero", int.Parse(r.Documento.Numero)))
            {
                if (Convert.ToInt32(c.ExecuteScalar()) > 0) result.Errores.Add("Ya existe ese comprobante del proveedor (tambien se comparan ceros iniciales).");
            }
            if (result.Errores.Count == 0) result.Firma = Firmar(r);
            return result;
        }
        public ImportacionCompra GuardarRevision(RevisionCompraDocumento r)
        {
            Sucursal(r?.Sucursal ?? 0);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                Bloquear(db, tx, "carga:" + r.Id);
                var actual = Leer(db, tx, r.Id);
                if (actual.Version != r.Version || actual.Sucursal != r.Sucursal || actual.Compra.HasValue) throw new ValidationException("La carga cambio; recargue.");
                if (r.Documento == null || r.Documento.Items == null || r.Documento.Items.Count > 200
                    || JsonConvert.SerializeObject(r).Length > 500000) throw new ValidationException("Borrador invalido o excesivo.");
                Ejecutar(db, tx, "UPDATE dbo.ComprasDocumentos SET Revision=@datos,Version=Version+1 WHERE Id=@id", "datos", JsonConvert.SerializeObject(r), "id", r.Id);
                Auditar(db, tx, r.Id, "Guardar revision sin compra", new { anterior = actual.Revision, revision = r }); tx.Commit();
            }
            return Obtener(r.Id);
        }
        public ResultadoRevisionCompra GuardarCompra(RevisionCompraDocumento r, string firma)
        {
            Sucursal(r?.Sucursal ?? 0);
            using (var db = Abrir())
            using (var tx = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                Bloquear(db, tx, "carga:" + r.Id);
                var actual = Leer(db, tx, r.Id);
                if (actual.Sucursal != r.Sucursal) throw new ValidationException("Sucursal de importacion distinta.");
                if (actual.Compra.HasValue)
                {
                    using (var c = Cmd(db, tx, "SELECT Firma FROM dbo.ComprasDocumentos WHERE Id=@id", "id", r.Id))
                        if ((string)c.ExecuteScalar() != firma || Firmar(r) != firma) throw new ValidationException("La carga ya genero otra revision de compra.");
                    return new ResultadoRevisionCompra { Compra = actual.Compra };
                }
                if (actual.Version != r.Version) throw new ValidationException("La revision cambio. Recargue.");
                // Todos los importadores se serializan por proveedor, incluso entre web y WinForms.
                Bloquear(db, tx, "proveedor:" + r.Proveedor);
                var validado = ValidarReferencias(db, r);
                if (validado.Errores.Count > 0 || string.IsNullOrWhiteSpace(firma) || validado.Firma != firma)
                    throw new ValidationException(validado.Errores.Count > 0 ? string.Join(Environment.NewLine, validado.Errores) : "Cambiaron los datos revisados. Valide de nuevo.");
                var cuit = CalculoCompraDocumento.NormalizarCuit(r.Documento.Cuit);
                var d = r.Documento;
                var compra = new ComprobantesCompras();
                using (var manager = new ComprobantesComprasManager(compra, db.Database.Connection, tx.UnderlyingTransaction))
                {
                    compra.Id_Sucursal = r.Sucursal; compra.Id_Deposito = r.Deposito; compra.Id_CentroCosto = r.CentroCosto;
                    compra.Id_Entidad = r.Proveedor; compra.Id_TipoEntidad = Enums.TipoEntidad.Proveedor;
                    compra.Id_TipoComprobante = r.TipoComprobante; compra.Id_FormaPago = r.FormaPago;
                    compra.Fecha = d.Fecha.Value.Date; compra.FechaRecepcion = r.Recepcion.Date; compra.FechaVto = r.Vencimiento.Date;
                    compra.Letra = d.Letra; compra.PuntoVenta = int.Parse(d.PuntoVenta).ToString("D4"); compra.NroComprobante = d.Numero.PadLeft(8, '0');
                    compra.Observaciones = "Origen documental " + r.Id + ". Revisado por usuario " + Usuario + ". CUIT " + cuit + ".";
                    compra.ImpuestoNoGravado = d.NoGravado.Value; compra.OtrosImpuestos = d.OtrosImpuestos.Value;
                    compra.PercepcionIva = d.PercepcionIva.Value; compra.PercepcionIIBB = d.PercepcionIibb.Value;
                    compra.PercepcionGanancias = d.PercepcionGanancias.Value; compra.ITC = d.Itc.Value;
                    compra.PercepcionIIBBCapital = d.PercepcionIibbCapital.Value; compra.Descuento = d.Descuento.Value;
                    foreach (var item in d.Items)
                    {
                        var neto = item.PrecioNeto.Value * (1 - item.Descuento.Value / 100) * item.Cantidad.Value;
                        var linea = new ComprobantesComprasDetalle
                        {
                            Id_Producto = item.Producto,
                            Descripcion = item.Descripcion,
                            Cantidad = item.Cantidad.Value,
                            CantidadStock = item.CantidadStock,
                            ImporteUnitario = item.PrecioNeto.Value,
                            PorcDescuento = item.Descuento.Value,
                            Id_Especie = r.Moneda,
                            Cotizacion = r.Cotizacion,
                            AlicuotaIva = item.Iva.Value,
                            Id_AlicuotaIva = db.IvaAlicuotas.Where(a => a.UserDel == null && a.Alicuota == item.Iva).Select(a => a.Id).OrderBy(a => a).First(),
                            ImporteIVA = CalculoCompraDocumento.Redondear(neto * item.Iva.Value / 100),
                            Importe = CalculoCompraDocumento.Redondear(neto * (1 + item.Iva.Value / 100))
                        };
                        compra.Detalle.Add(linea);
                    }
                    manager.Save();
                }
                if (compra.FechaLiquidacion.HasValue) throw new ValidationException("Una importacion no puede confirmar compras.");
                Ejecutar(db, tx, "UPDATE dbo.ComprasDocumentos SET Compra=@compra,Firma=@firma,Revision=@revision,Estado='Guardado',Version=Version+1,Error=NULL WHERE Id=@id",
                    "compra", compra.Id, "firma", firma, "revision", JsonConvert.SerializeObject(r), "id", r.Id);
                foreach (var item in d.Items.Where(i => i.RecordarEquivalencia))
                {
                    using (var c = Cmd(db, tx, "SELECT Producto FROM dbo.ComprasDocumentosEquivalencias WHERE Proveedor=@p AND Codigo=@c",
                        "p", r.Proveedor, "c", item.Codigo.Trim().ToUpperInvariant()))
                        Auditar(db, tx, r.Id, "Guardar equivalencia revisada",
                            new { proveedor = r.Proveedor, codigo = item.Codigo, anterior = c.ExecuteScalar(), producto = item.Producto });
                    Ejecutar(db, tx, @"IF EXISTS(SELECT 1 FROM dbo.ComprasDocumentosEquivalencias WHERE Proveedor=@p AND Codigo=@c)
                        UPDATE dbo.ComprasDocumentosEquivalencias SET Producto=@prod,Usuario=@u,Fecha=SYSUTCDATETIME() WHERE Proveedor=@p AND Codigo=@c
                        ELSE INSERT dbo.ComprasDocumentosEquivalencias VALUES(@p,@c,@prod,@u,SYSUTCDATETIME())",
                        "p", r.Proveedor, "c", item.Codigo.Trim().ToUpperInvariant(), "prod", item.Producto, "u", Usuario);
                }
                Auditar(db, tx, r.Id, "Crear compra PENDIENTE", new { compra = compra.Id, firma, revision = r });
                tx.Commit(); validado.Compra = compra.Id; return validado;
            }
        }
        public static string Hash(byte[] datos)
        { using (var hash = SHA256.Create()) return BitConverter.ToString(hash.ComputeHash(datos)).Replace("-", "").ToLowerInvariant(); }
        private sealed class DecimalEstable : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(decimal) || t == typeof(decimal?);
            public override void WriteJson(JsonWriter w, object v, Newtonsoft.Json.JsonSerializer s)
            { if (v == null) w.WriteNull(); else w.WriteRawValue(((decimal)v).ToString("G29", CultureInfo.InvariantCulture)); }
            public override object ReadJson(JsonReader r, Type t, object v, Newtonsoft.Json.JsonSerializer s) => throw new NotSupportedException();
        }
        public static string Firmar(RevisionCompraDocumento r) => Hash(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(r, new DecimalEstable())));
    }
}
