using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIGNET_Web.Api.Infrastructure;
using VENET_Comun;

namespace SIGNET_Web.Api.Screens.Acciones
{
    public enum Seleccion { Ninguna, Una, Varias }

    /// <summary>
    /// Opción de los menús "Imprimir" / "Operaciones" de una pantalla, replicando el handler del formulario original.
    /// </summary>
    public class AccionDef
    {
        /// <summary>Clave de la pantalla (nombre del Manager sin "Manager"). Se completa al registrar.</summary>
        [JsonIgnore] public string Pantalla { get; set; }
        public string Key { get; set; }
        /// <summary>"Imprimir" u "Operaciones".</summary>
        public string Menu { get; set; } = "Operaciones";
        public string Titulo { get; set; }
        /// <summary>Permiso exigido: si es null se usan Módulo/Formulario de la pantalla.</summary>
        [JsonIgnore] public Enums.Modulos? Modulo { get; set; }
        [JsonIgnore] public string Formulario { get; set; }
        /// <summary>Si es null: Imprimir para el menú Imprimir, Operaciones para el resto.</summary>
        [JsonIgnore] public Enums.Accion? Accion { get; set; }
        /// <summary>TipoNuevoAccion de Seguridad.ObtenerPermiso (ej. "Imprimir Recibo").</summary>
        [JsonIgnore] public string Descripcion { get; set; } = "";
        /// <summary>Si es true no se valida permiso (el handler original no lo validaba).</summary>
        [JsonIgnore] public bool SinPermiso { get; set; }
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Seleccion Seleccion { get; set; } = Seleccion.Una;
        /// <summary>Pregunta Sí/No previa (frmMensajeSiNo del original).</summary>
        public string Confirmacion { get; set; }
        /// <summary>Datos que el usuario ingresa antes de ejecutar (ej. "Motivo Anulación").</summary>
        public List<FieldSchema> Campos { get; set; } = new List<FieldSchema>();
        /// <summary>Campos que dependen de la selección o de la base (opciones de combos). Se piden al abrir el diálogo.</summary>
        [JsonIgnore] public Func<AccionContexto, List<FieldSchema>> CamposDinamicos { get; set; }
        public bool TieneCamposDinamicos => CamposDinamicos != null;
        /// <summary>Si no es null, la opción se muestra deshabilitada con este motivo (sólo disponible en el escritorio).</summary>
        public string SoloEscritorio { get; set; }
        /// <summary>Separador antes de la opción en el menú.</summary>
        public bool Separador { get; set; }
        [JsonIgnore] public Func<AccionContexto, AccionResultado> Ejecutar { get; set; }
    }

    public class AccionContexto
    {
        public ScreenDescriptor Pantalla { get; set; }
        public List<int> Ids { get; set; } = new List<int>();
        public JObject Valores { get; set; } = new JObject();
        internal ScreenService Service { get; set; }

        /// <summary>Id seleccionado (selección única). Lanza 400 si no hay.</summary>
        public int Id => Ids.Count > 0 ? Ids[0] : throw new ApiException(400, "Debe seleccionar un registro.");

        public T Valor<T>(string nombre, T porDefecto = default(T))
        {
            var t = Valores?[nombre];
            if (t == null || t.Type == JTokenType.Null || (t.Type == JTokenType.String && (string)t == "")) return porDefecto;
            return (T)ValueConverter.FromJson(t, typeof(T));
        }

        public string Texto(string nombre) => Valor<string>(nombre)?.Trim();

        /// <summary>Valores de un campo "multi" (lista de ids).</summary>
        public List<int> Enteros(string nombre)
        {
            var t = Valores?[nombre];
            if (t is JArray a) return a.Where(x => x.Type == JTokenType.Integer || x.Type == JTokenType.String).Select(x => Convert.ToInt32((object)((JValue)x).Value, CultureInfo.InvariantCulture)).ToList();
            var s = t?.Type == JTokenType.String ? (string)t : null;
            return string.IsNullOrWhiteSpace(s) ? new List<int>() : s.Split(',').Select(x => int.Parse(x.Trim(), CultureInfo.InvariantCulture)).ToList();
        }

        /// <summary>Guarda el archivo subido en un campo "file" en una carpeta temporal, ejecuta la acción con la ruta y lo borra.</summary>
        public T ConArchivo<T>(string nombre, Func<string, T> accion) => ArchivoSubido.Usar(Valores?[nombre] as JObject, accion);

        /// <summary>Re-ejecuta el Buscar del Manager de la pantalla (con parámetros por defecto + Id) y devuelve la fila con ese Id, o null.</summary>
        public object Fila(int id) => Service.BuscarFila(Pantalla, id);
        public T Fila<T>(int id) where T : class => Fila(id) as T;
    }

    /// <summary>Archivo enviado por el navegador ({nombre, base64}) que el BL necesita leer desde disco.</summary>
    public static class ArchivoSubido
    {
        public static T Usar<T>(JObject archivo, Func<string, T> accion, params string[] extensiones)
        {
            var nombre = (string)archivo?["nombre"];
            var base64 = (string)archivo?["base64"];
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(base64)) throw new ApiException(400, "Debe seleccionar un archivo.");
            var ext = System.IO.Path.GetExtension(nombre).ToLowerInvariant();
            var permitidas = extensiones.Length > 0 ? extensiones : new[] { ".xlsx", ".xls" };
            if (!permitidas.Contains(ext)) throw new ApiException(400, "El archivo debe ser " + string.Join(" o ", permitidas) + ".");
            var dir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SIGNET_Web", Guid.NewGuid().ToString("N"));
            System.IO.Directory.CreateDirectory(dir);
            var ruta = System.IO.Path.Combine(dir, "archivo" + ext);
            try
            {
                System.IO.File.WriteAllBytes(ruta, Convert.FromBase64String(base64.Contains(",") ? base64.Substring(base64.IndexOf(',') + 1) : base64));
                return accion(ruta);
            }
            finally { try { System.IO.Directory.Delete(dir, true); } catch (Exception) { } }
        }
    }

    /// <summary>Tabla de resultados que el cliente muestra en pantalla (reemplazo de grillas de los diálogos del escritorio).</summary>
    public class TablaResultado
    {
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public List<FieldSchema> Columnas { get; set; } = new List<FieldSchema>();
        public List<Dictionary<string, object>> Filas { get; set; } = new List<Dictionary<string, object>>();

        public static TablaResultado Desde(System.Data.DataTable t, string titulo)
        {
            var r = new TablaResultado { Titulo = titulo };
            foreach (System.Data.DataColumn c in t.Columns)
                r.Columnas.Add(new FieldSchema { Name = c.ColumnName, Label = ScreenCatalog.SepararPalabras(c.ColumnName), Type = Tipo(c.DataType), Nullable = true });
            foreach (System.Data.DataRow f in t.Rows)
                r.Filas.Add(t.Columns.Cast<System.Data.DataColumn>().ToDictionary(c => c.ColumnName, c => f.IsNull(c) ? null : f[c]));
            r.Resumen = r.Filas.Count + " registro(s)";
            return r;
        }

        public static TablaResultado Desde<T>(IEnumerable<T> filas, string titulo, params (string Nombre, string Etiqueta, Func<T, object> Valor)[] columnas)
        {
            var r = new TablaResultado { Titulo = titulo };
            foreach (var c in columnas) r.Columnas.Add(new FieldSchema { Name = c.Nombre, Label = c.Etiqueta, Type = "string", Nullable = true });
            foreach (var f in filas ?? Enumerable.Empty<T>())
                r.Filas.Add(columnas.ToDictionary(c => c.Nombre, c => { try { return c.Valor(f); } catch (Exception) { return null; } }));
            for (var i = 0; i < columnas.Length; i++)
            {
                var v = r.Filas.Select(f => f[columnas[i].Nombre]).FirstOrDefault(x => x != null);
                if (v != null) r.Columnas[i].Type = Tipo(Nullable.GetUnderlyingType(v.GetType()) ?? v.GetType());
            }
            r.Resumen = r.Filas.Count + " registro(s)";
            return r;
        }

        private static string Tipo(Type t)
        {
            if (t == typeof(int) || t == typeof(long) || t == typeof(short) || t == typeof(byte)) return "int";
            if (t == typeof(decimal) || t == typeof(double) || t == typeof(float)) return "decimal";
            if (t == typeof(DateTime)) return "datetime";
            if (t == typeof(bool)) return "bool";
            return "string";
        }
    }

    /// <summary>Datos iniciales para abrir el alta de otra pantalla (ej. Generar Recibo desde un comprobante de venta).</summary>
    public class AltaPrecargada
    {
        public string Pantalla { get; set; }
        public Dictionary<string, object> Valores { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, List<Dictionary<string, object>>> Detalles { get; set; } = new Dictionary<string, List<Dictionary<string, object>>>();
    }

    /// <summary>Exportación a PDF (Microsoft Edge headless) y envío por correo (Sistema.EnvioMail del BL).</summary>
    public static class Exportador
    {
        private static readonly string[] RutasEdge =
        {
            @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
            @"C:\Program Files\Microsoft\Edge\Application\msedge.exe",
            @"C:\Program Files\Google\Chrome\Application\chrome.exe",
            @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
        };

        public static byte[] HtmlAPdf(string html)
        {
            var exe = RutasEdge.FirstOrDefault(System.IO.File.Exists);
            if (exe == null) throw new ApiException(501, "No se encontró Microsoft Edge/Chrome en el servidor para generar PDF.");
            var dir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SIGNET_Web", Guid.NewGuid().ToString("N"));
            System.IO.Directory.CreateDirectory(dir);
            try
            {
                var entrada = System.IO.Path.Combine(dir, "doc.html");
                var salida = System.IO.Path.Combine(dir, "doc.pdf");
                System.IO.File.WriteAllText(entrada, HtmlDocumento.SinImpresion(html), Encoding.UTF8);
                var psi = new System.Diagnostics.ProcessStartInfo(exe,
                    "--headless=new --disable-gpu --no-first-run --no-pdf-header-footer --user-data-dir=\"" + System.IO.Path.Combine(dir, "perfil")
                    + "\" --print-to-pdf=\"" + salida + "\" \"" + new Uri(entrada).AbsoluteUri + "\"")
                { UseShellExecute = false, CreateNoWindow = true };
                using (var p = System.Diagnostics.Process.Start(psi))
                {
                    if (!p.WaitForExit(60000)) { try { p.Kill(); } catch (Exception) { } throw new ApiException(504, "Tiempo agotado generando el PDF."); }
                }
                if (!System.IO.File.Exists(salida)) throw new ApiException(500, "No se pudo generar el PDF.");
                return System.IO.File.ReadAllBytes(salida);
            }
            finally { try { System.IO.Directory.Delete(dir, true); } catch (Exception) { } }
        }

        /// <summary>Convierte un resultado HTML en un PDF descargable.</summary>
        public static AccionResultado ComoPdf(AccionResultado r, string nombre)
        {
            if (r?.Pdf != null)
                return new AccionResultado { Archivo = ArchivoResultado.Pdf(nombre, Convert.FromBase64String(r.Pdf.Base64)) };
            if (r?.Html == null) return r;
            return new AccionResultado { Archivo = ArchivoResultado.Pdf(nombre, HtmlAPdf(r.Html)) };
        }

        /// <summary>Genera el PDF del documento y lo envía con Sistema.EnvioMail (configuración SMTP de la base).</summary>
        public static void EnviarMail(AccionResultado documento, string nombreArchivo, string asunto, string destinatario)
        {
            if (string.IsNullOrWhiteSpace(destinatario)) throw new System.ComponentModel.DataAnnotations.ValidationException("La entidad no posee un mail cargado.");
            if (documento?.Html == null && documento?.Pdf == null) throw new ApiException(500, "No se pudo generar el documento.");
            var dir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SIGNET_Web", Guid.NewGuid().ToString("N"));
            System.IO.Directory.CreateDirectory(dir);
            try
            {
                if (!nombreArchivo.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)) nombreArchivo += ".pdf";
                var ruta = System.IO.Path.Combine(dir, ArchivoResultado.NombreSeguro(nombreArchivo));
                System.IO.File.WriteAllBytes(ruta, documento.Pdf != null ? Convert.FromBase64String(documento.Pdf.Base64) : HtmlAPdf(documento.Html));
                VENET_Common.Sistema.EnvioMail(ruta, asunto, "", destinatario.Trim());
            }
            finally { try { System.IO.Directory.Delete(dir, true); } catch (Exception) { } }
        }

        public static AccionResultado CombinarDocumentos(IEnumerable<AccionResultado> documentos, string nombre)
        {
            using (var pdf = new PdfSharp.Pdf.PdfDocument())
            {
                foreach (var documento in documentos)
                {
                    if (documento?.Pdf == null && documento?.Html == null)
                        throw new ApiException(500, "No se pudo generar uno de los documentos.");
                    var bytes = documento.Pdf != null ? Convert.FromBase64String(documento.Pdf.Base64) : HtmlAPdf(documento.Html);
                    using (var entrada = new System.IO.MemoryStream(bytes))
                    using (var origen = PdfSharp.Pdf.IO.PdfReader.Open(entrada, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import))
                        foreach (var pagina in origen.Pages) pdf.AddPage(pagina);
                }
                using (var salida = new System.IO.MemoryStream())
                {
                    pdf.Save(salida, false);
                    return new AccionResultado { Pdf = ArchivoResultado.Pdf(nombre, salida.ToArray()) };
                }
            }
        }

    }

    public class AccionResultado
    {
        public string Mensaje { get; set; }
        public string Titulo { get; set; }
        public bool Refrescar { get; set; }
        /// <summary>Clave de la pantalla web que reemplaza al diálogo del escritorio.</summary>
        public string Navegar { get; set; }
        /// <summary>Valores que el destino de Navegar recibe como parámetros/filtro fijo (equivale a los argumentos del constructor del formulario).</summary>
        public Dictionary<string, object> Parametros { get; set; }
        /// <summary>Abre la galería de imágenes (frmImagenes) del registro indicado.</summary>
        public string ImagenesTabla { get; set; }
        public int ImagenesId { get; set; }
        /// <summary>Documento HTML completo para imprimir en una ventana nueva.</summary>
        public string Html { get; set; }
        /// <summary>PDF de una plantilla REPX, para vista previa e impresion en el navegador.</summary>
        public ArchivoResultado Pdf { get; set; }
        public ArchivoResultado Archivo { get; set; }
        /// <summary>El cliente imprime la grilla de resultados (equivalente a ShowRibbonPrintPreview).</summary>
        public bool ImprimirGrilla { get; set; }
        public bool Horizontal { get; set; }
        /// <summary>Tablas a mostrar en pantalla (resultado de procesos / informes de control).</summary>
        public List<TablaResultado> Tablas { get; set; }
        /// <summary>Abrir el alta de otra pantalla con datos precargados.</summary>
        public AltaPrecargada Alta { get; set; }

        public static AccionResultado Ok(string mensaje, bool refrescar = true) => new AccionResultado { Mensaje = mensaje, Refrescar = refrescar };
        public static AccionResultado Documento(HtmlDocumento doc) => new AccionResultado { Html = doc.ToString() };
    }

    public class ArchivoResultado
    {
        public string Nombre { get; set; }
        public string ContentType { get; set; }
        public string Base64 { get; set; }

        public static ArchivoResultado Csv(string nombre, string contenido) =>
            new ArchivoResultado { Nombre = nombre, ContentType = "text/csv;charset=utf-8", Base64 = Convert.ToBase64String(Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(contenido)).ToArray()) };

        public static ArchivoResultado Pdf(string nombre, byte[] contenido) =>
            new ArchivoResultado { Nombre = NombreSeguro(nombre.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) ? nombre : nombre + ".pdf"),
                ContentType = "application/pdf", Base64 = Convert.ToBase64String(contenido) };

        public static ArchivoResultado Xlsx(string nombre, byte[] contenido) =>
            new ArchivoResultado { Nombre = NombreSeguro(nombre), ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Base64 = Convert.ToBase64String(contenido) };

        public static string NombreSeguro(string nombre)
        {
            foreach (var c in System.IO.Path.GetInvalidFileNameChars()) nombre = nombre.Replace(c, '_');
            return nombre;
        }
    }

    /// <summary>Módulo que registra acciones. Las implementaciones se descubren por reflexión.</summary>
    public interface IAccionesModulo
    {
        void Registrar(AccionesRegistro r);
    }

    public static class Campo
    {
        public static FieldSchema Texto(string name, string label, bool required = true, int? maxLength = null) =>
            new FieldSchema { Name = name, Label = label, Type = "string", Required = required, Nullable = !required, MaxLength = maxLength };
        public static FieldSchema Decimal(string name, string label, bool required = true, decimal? def = null) =>
            new FieldSchema { Name = name, Label = label, Type = "decimal", Required = required, Nullable = !required, Default = def };
        public static FieldSchema Entero(string name, string label, bool required = true, int? def = null) =>
            new FieldSchema { Name = name, Label = label, Type = "int", Required = required, Nullable = !required, Default = def };
        public static FieldSchema Fecha(string name, string label, bool required = true, DateTime? def = null) =>
            new FieldSchema { Name = name, Label = label, Type = "date", Required = required, Nullable = !required, Default = def };
        public static FieldSchema Check(string name, string label, bool def = false) =>
            new FieldSchema { Name = name, Label = label, Type = "bool", Default = def };
        public static FieldSchema Opciones(string name, string label, IEnumerable<LookupItem> opciones, bool required = true, object def = null) =>
            new FieldSchema { Name = name, Label = label, Type = "int", Required = required, Nullable = !required, Options = opciones.ToList(), Default = def };
        /// <summary>Combo a partir de entidades del BL (usa Id/Key + Nombre/Descripcion/RazonSocial).</summary>
        public static FieldSchema Entidades(string name, string label, IEnumerable<object> entidades, bool required = true) =>
            Opciones(name, label, (entidades ?? Enumerable.Empty<object>()).Where(o => o != null).Select(LookupItem.From), required);
        /// <summary>Lista de selección múltiple; el valor es un array de ids.</summary>
        public static FieldSchema Multi(string name, string label, IEnumerable<LookupItem> opciones, bool required = true) =>
            new FieldSchema { Name = name, Label = label, Type = "multi", Required = required, Nullable = !required, Options = opciones.ToList() };
        /// <summary>Archivo Excel a subir; el valor es {nombre, base64}.</summary>
        public static FieldSchema Archivo(string name, string label = "Archivo Excel") =>
            new FieldSchema { Name = name, Label = label, Type = "file", Required = true };
    }

    /// <summary>
    /// Arma un documento HTML imprimible (reemplazo web de los XtraReport originales).
    /// </summary>
    public class HtmlDocumento
    {
        private readonly StringBuilder _b = new StringBuilder();
        private readonly string _titulo;
        private bool _horizontal;
        private static readonly CultureInfo Ar = new CultureInfo("es-AR");

        public HtmlDocumento(string titulo) { _titulo = titulo; }

        public static string E(object v) => WebUtility.HtmlEncode(Formatear(v));

        public static string Formatear(object v)
        {
            switch (v)
            {
                case null: return "";
                case DateTime d: return d.TimeOfDay == TimeSpan.Zero ? d.ToString("dd/MM/yyyy", Ar) : d.ToString("dd/MM/yyyy HH:mm", Ar);
                case decimal m: return m.ToString("N2", Ar);
                case double db: return db.ToString("N2", Ar);
                case float f: return f.ToString("N2", Ar);
                case bool b: return b ? "Sí" : "No";
                case Enum en: return Enums.GetDescription(en);
                default: return Convert.ToString(v, Ar);
            }
        }

        public HtmlDocumento Horizontal() { _horizontal = true; return this; }

        /// <summary>Encabezado con empresa a la izquierda, letra al centro y tipo/número de comprobante a la derecha.</summary>
        public HtmlDocumento Encabezado(string empresa, IEnumerable<string> lineasEmpresa, string comprobante, string letra = null, IEnumerable<(string, object)> datos = null)
        {
            _b.Append("<div class='enc'><div class='emp'><h1>").Append(E(empresa)).Append("</h1>");
            foreach (var l in lineasEmpresa ?? Enumerable.Empty<string>()) if (!string.IsNullOrWhiteSpace(l)) _b.Append("<div>").Append(E(l)).Append("</div>");
            _b.Append("</div>");
            if (!string.IsNullOrEmpty(letra)) _b.Append("<div class='letra'>").Append(E(letra)).Append("</div>");
            _b.Append("<div class='cbte'><h2>").Append(E(comprobante)).Append("</h2>");
            foreach (var (k, v) in datos ?? Enumerable.Empty<(string, object)>()) _b.Append("<div><b>").Append(E(k)).Append(":</b> ").Append(E(v)).Append("</div>");
            _b.Append("</div></div>");
            return this;
        }

        public HtmlDocumento Titulo(string texto) { _b.Append("<h3>").Append(E(texto)).Append("</h3>"); return this; }

        public HtmlDocumento Leyenda(string texto)
        {
            if (!string.IsNullOrWhiteSpace(texto)) _b.Append("<div class='leyenda'>").Append(E(texto)).Append("</div>");
            return this;
        }

        public HtmlDocumento Parrafo(string texto)
        {
            if (!string.IsNullOrWhiteSpace(texto)) _b.Append("<p>").Append(E(texto)).Append("</p>");
            return this;
        }

        /// <summary>Bloque de pares etiqueta/valor (se omiten los vacíos).</summary>
        public HtmlDocumento Datos(params (string Etiqueta, object Valor)[] datos)
        {
            _b.Append("<div class='datos'>");
            foreach (var (k, v) in datos)
            {
                var s = Formatear(v);
                if (string.IsNullOrWhiteSpace(s)) continue;
                _b.Append("<div><b>").Append(E(k)).Append(":</b> ").Append(WebUtility.HtmlEncode(s)).Append("</div>");
            }
            _b.Append("</div>");
            return this;
        }

        /// <summary>Tabla de detalle. Las columnas numéricas se alinean a la derecha.</summary>
        public HtmlDocumento Tabla<T>(IEnumerable<T> filas, params (string Titulo, Func<T, object> Valor)[] columnas)
        {
            var lista = (filas ?? Enumerable.Empty<T>()).ToList();
            _b.Append("<table><thead><tr>");
            foreach (var c in columnas) _b.Append("<th>").Append(E(c.Titulo)).Append("</th>");
            _b.Append("</tr></thead><tbody>");
            foreach (var f in lista)
            {
                _b.Append("<tr>");
                foreach (var c in columnas)
                {
                    object v;
                    try { v = c.Valor(f); } catch (Exception) { v = null; }
                    var num = v is decimal || v is double || v is float || v is int || v is long;
                    _b.Append(num ? "<td class='n'>" : "<td>").Append(E(v)).Append("</td>");
                }
                _b.Append("</tr>");
            }
            if (lista.Count == 0) _b.Append("<tr><td colspan='").Append(columnas.Length).Append("' class='c'>Sin datos</td></tr>");
            _b.Append("</tbody></table>");
            return this;
        }

        /// <summary>Totales alineados a la derecha (se omiten los null).</summary>
        public HtmlDocumento Totales(params (string Etiqueta, object Valor)[] totales)
        {
            _b.Append("<table class='tot'>");
            foreach (var (k, v) in totales)
            {
                if (v == null) continue;
                _b.Append("<tr><td>").Append(E(k)).Append("</td><td class='n'>").Append(E(v)).Append("</td></tr>");
            }
            _b.Append("</table>");
            return this;
        }

        public HtmlDocumento Firma(params string[] etiquetas)
        {
            _b.Append("<div class='firmas'>");
            foreach (var e in etiquetas) _b.Append("<div>").Append(E(e)).Append("</div>");
            _b.Append("</div>");
            return this;
        }

        public HtmlDocumento SaltoPagina() { _b.Append("<div class='salto'></div>"); return this; }

        /// <summary>Línea de corte entre dos copias impresas en la misma hoja (xrptDoblePorHoja).</summary>
        public HtmlDocumento Corte() { _b.Append("<div class='corte'></div>"); return this; }

        /// <summary>Como Tabla, pero omite las columnas sin ningún valor.</summary>
        public HtmlDocumento TablaSinVacias<T>(IEnumerable<T> filas, params (string Titulo, Func<T, object> Valor)[] columnas)
        {
            var lista = (filas ?? Enumerable.Empty<T>()).ToList();
            object Seguro(Func<T, object> f, T x) { try { return f(x); } catch (Exception) { return null; } }
            var usadas = columnas.Where(c => lista.Any(f => Seguro(c.Valor, f) != null)).ToArray();
            return Tabla(lista, usadas.Length == 0 ? columnas : usadas);
        }

        private const string BotonImprimir = "<div class='no-print'><button onclick='window.print()'>Imprimir</button></div>";
        private const string ScriptImprimir = "<script>window.addEventListener('load',function(){setTimeout(function(){window.print()},300)})</script>";

        /// <summary>Quita el botón y el auto-print (para exportar a PDF).</summary>
        public static string SinImpresion(string html) => html.Replace(BotonImprimir, "").Replace(ScriptImprimir, "");

        public override string ToString()
        {
            return "<!DOCTYPE html><html lang='es'><head><meta charset='utf-8'><title>" + E(_titulo) + "</title><style>"
                + "@page{size:A4 " + (_horizontal ? "landscape" : "portrait") + ";margin:12mm}"
                + "body{font-family:Segoe UI,Arial,sans-serif;font-size:11px;color:#000;margin:0;padding:12px}"
                + ".enc{display:flex;justify-content:space-between;align-items:flex-start;border:1px solid #000;padding:8px;gap:12px}"
                + ".enc h1{font-size:18px;margin:0 0 4px}.enc h2{font-size:16px;margin:0 0 4px}"
                + ".letra{border:2px solid #000;font-size:28px;font-weight:bold;padding:2px 14px;align-self:center}"
                + ".cbte{text-align:right}.datos{border:1px solid #000;border-top:0;padding:6px 8px;display:grid;grid-template-columns:1fr 1fr;gap:2px 16px}"
                + "h3{font-size:14px;margin:10px 0 4px}.leyenda{text-align:center;font-weight:bold;letter-spacing:2px;margin:4px 0}"
                + "table{border-collapse:collapse;width:100%;margin-top:8px}th,td{border:1px solid #888;padding:3px 5px;text-align:left}"
                + "th{background:#eee}.n{text-align:right;white-space:nowrap}.c{text-align:center}"
                + "table.tot{width:auto;margin-left:auto}table.tot td{border:0;padding:2px 8px;font-weight:bold}"
                + ".firmas{display:flex;justify-content:space-around;margin-top:60px}.firmas div{border-top:1px solid #000;padding-top:4px;min-width:160px;text-align:center}"
                + ".salto{page-break-after:always}.corte{border-top:1px dashed #000;margin:18px 0}"
                + ".no-print{margin-bottom:10px}@media print{.no-print{display:none}body{padding:0}}"
                + "</style></head><body>" + BotonImprimir
                + _b + ScriptImprimir + "</body></html>";
        }
    }
}
