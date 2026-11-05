using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using DevExpress.XtraReports.Security;
using DevExpress.XtraReports.UI;

namespace SIGNET_Web.Api.Reporting
{
    public static class RepxRenderer
    {
        static RepxRenderer()
        {
            ScriptPermissionManager.GlobalInstance = new ScriptPermissionManager(ExecutionMode.Deny);
        }

        public static bool Configurado(string plantilla) =>
            !string.IsNullOrWhiteSpace(plantilla) && plantilla != "<Ninguno>";

        public static string Ruta(string carpeta, string plantilla)
        {
            if (string.IsNullOrWhiteSpace(carpeta))
                throw new ValidationException("Configure RutaOriginalesComprobantesVentas con la carpeta de plantillas del servidor.");
            if (!Configurado(plantilla) || Path.IsPathRooted(plantilla)
                || plantilla.IndexOfAny(Path.GetInvalidPathChars()) >= 0 || plantilla.Contains(":")
                || !string.Equals(Path.GetExtension(plantilla), ".repx", StringComparison.OrdinalIgnoreCase))
                throw new ValidationException("La plantilla debe ser un archivo .repx relativo a la carpeta de reportes.");
            var raiz = Path.GetFullPath(carpeta).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            var ruta = Path.GetFullPath(Path.Combine(raiz, plantilla));
            if (!ruta.StartsWith(raiz, StringComparison.OrdinalIgnoreCase))
                throw new ValidationException("La plantilla debe estar dentro de la carpeta de reportes.");
            if (!File.Exists(ruta))
                throw new ValidationException("No se encontro la plantilla '" + plantilla + "' en la carpeta de reportes del servidor.");
            return ruta;
        }

        public static byte[] Render(string carpeta, string plantilla, IEnumerable datos, IEnumerable<string> leyendas = null)
        {
            var copias = (leyendas ?? new string[] { null }).ToList();
            if (copias.Count == 0 || copias.Count > 100)
                throw new ValidationException("La cantidad de copias debe estar entre 1 y 100.");
            var reportes = new List<XtraReport>();
            try
            {
                foreach (var leyenda in copias)
                {
                    if (leyenda != null)
                        foreach (var dato in datos)
                        {
                            var propiedad = dato.GetType().GetProperty("LeyendaOriginal");
                            if (propiedad?.CanWrite == true) propiedad.SetValue(dato, leyenda);
                        }
                    var report = Cargar(carpeta, plantilla, datos, new HashSet<string>(StringComparer.OrdinalIgnoreCase));
                    reportes.Add(report);
                    report.CreateDocument();
                }
                var principal = reportes[0];
                foreach (var report in reportes.Skip(1)) principal.Pages.AddRange(report.Pages);
                using (var stream = new MemoryStream())
                {
                    principal.ExportToPdf(stream);
                    return stream.ToArray();
                }
            }
            finally { foreach (var report in reportes) report.Dispose(); }
        }

        private static XtraReport Cargar(string carpeta, string plantilla, IEnumerable datos, HashSet<string> cargando, int profundidad = 0)
        {
            var ruta = Ruta(carpeta, plantilla);
            if (!cargando.Add(ruta))
                throw new ValidationException("La plantilla contiene una referencia circular de subreportes.");
            XtraReport report = null;
            try
            {
                // Solo XML: no compilar plantillas heredadas que contienen codigo ejecutable.
                report = new XtraReport();
                using (var stream = File.OpenRead(ruta)) report.LoadLayoutFromXml(stream, true);
                Vincular(report, carpeta, datos, cargando, profundidad);
                return report;
            }
            catch { report?.Dispose(); throw; }
            finally { cargando.Remove(ruta); }
        }

        private static void Vincular(XtraReport report, string carpeta, IEnumerable datos, HashSet<string> cargando, int profundidad)
        {
            if (profundidad > 20) throw new ValidationException("La plantilla contiene demasiados niveles de subreportes.");
            if (!string.IsNullOrWhiteSpace(report.ScriptsSource))
                throw new ValidationException("La plantilla contiene scripts. Migre sus reglas a la BL o a expresiones antes de usarla en la web.");
            report.DataSource = datos;
            report.RequestParameters = false;
            foreach (var subreport in report.AllControls<XRSubreport>())
            {
                if (!string.IsNullOrWhiteSpace(subreport.ReportSourceUrl))
                {
                    var nombre = subreport.ReportSourceUrl;
                    subreport.ReportSourceUrl = null;
                    subreport.ReportSource = Cargar(carpeta, nombre, datos, cargando, profundidad + 1);
                }
                else if (subreport.ReportSource != null)
                    Vincular(subreport.ReportSource, carpeta, datos, cargando, profundidad + 1);
            }
        }
    }
}
