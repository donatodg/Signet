using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using DevExpress.XtraReports.UI;
using PdfSharp.Pdf.IO;
using SIGNET_Web.Api.Reporting;
using SIGNET_Web.Api.Screens.Acciones;

internal static class Program
{
    private static int Main(string[] args)
    {
        var carpeta = Path.Combine(Path.GetTempPath(), "SIGNET-Repx-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(carpeta);
        try
        {
            var datos = new List<Fila> { new Fila { Nombre = "Cliente prueba" }, new Fila { Nombre = "Otro cliente" } };
            using (var report = Plantilla())
                report.SaveLayoutToXml(Path.Combine(carpeta, "Prueba.repx"));
            var cargar = typeof(RepxRenderer).GetMethod("Cargar", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            using (var report = (XtraReport)cargar.Invoke(null, new object[] { carpeta, "Prueba.repx", datos, new HashSet<string>(), 0 }))
            using (var texto = new MemoryStream())
            {
                report.ExportToText(texto);
                var contenido = System.Text.Encoding.UTF8.GetString(texto.ToArray());
                if (!contenido.Contains("Cliente prueba") || !contenido.Contains("Otro cliente"))
                    throw new Exception("Las expresiones del REPX no recibieron los datos de la BL.");
            }
            var bytes = RepxRenderer.Render(carpeta, "Prueba.repx", datos, new[] { "ORIGINAL", "DUPLICADO" });
            VerificarPdf(bytes, 4, "Datos y copias");
            if (args.Length == 1) File.WriteAllBytes(args[0], bytes);
            if (datos.Any(d => d.LeyendaOriginal != "DUPLICADO")) throw new Exception("No se aplicaron las leyendas a los datos BL.");
            var resultado = new AccionResultado { Pdf = ArchivoResultado.Pdf("Prueba.pdf", bytes) };
            var descargable = Exportador.ComoPdf(resultado, "Descarga.pdf");
            if (descargable.Archivo.Nombre != "Descarga.pdf" || descargable.Pdf != null
                || descargable.Archivo.Base64 != resultado.Pdf.Base64)
                throw new Exception("Exportar debe reutilizar el PDF original, sin convertirlo a HTML.");
            var combinado = Exportador.CombinarDocumentos(new[] { resultado, resultado }, "Lote.pdf");
            VerificarPdf(Convert.FromBase64String(combinado.Pdf.Base64), 8, "Lote de comprobantes");
            Rechaza(() => RepxRenderer.Ruta(carpeta, "..\\fuera.repx"), "dentro");
            Rechaza(() => RepxRenderer.Ruta(carpeta, "http://ejemplo.test/a.repx"), "plantilla");
            Rechaza(() => RepxRenderer.Ruta(carpeta, "Inexistente.repx"), "No se encontro");
            Rechaza(() => RepxRenderer.Ruta("", "Prueba.repx"), "Configure");
            Rechaza(() => RepxRenderer.Render(carpeta, "Prueba.repx", datos, new string[101]), "copias");
            using (var script = Plantilla())
            {
                script.ScriptsSource = "public void Test() {}";
                script.SaveLayoutToXml(Path.Combine(carpeta, "Script.repx"));
            }
            Rechaza(() => RepxRenderer.Render(carpeta, "Script.repx", datos), "scripts");
            using (var heredado = Plantilla())
            {
                var etiqueta = heredado.AllControls<XRLabel>().Single();
                etiqueta.ExpressionBindings.Clear();
                etiqueta.DataBindings.Add("Text", null, "Nombre");
                heredado.SaveLayoutToXml(Path.Combine(carpeta, "Heredado.repx"));
            }
            VerificarPdf(RepxRenderer.Render(carpeta, "Heredado.repx", datos), 2, "Bindings de escritorio");
            Subreportes(carpeta, datos);
            Console.WriteLine("OK: REPX real a PDF, datos BL, tamano de hoja, copias, lotes, descarga sin HTML, subreportes y errores de plantilla.");
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
        finally { Directory.Delete(carpeta, true); }
    }

    private static XtraReport Plantilla()
    {
        var report = new XtraReport { PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom,
            PageWidth = 600, PageHeight = 800, Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10) };
        var detalle = new DetailBand { HeightF = 60, PageBreak = PageBreak.AfterBandExceptLastEntry };
        var etiqueta = new XRLabel { BoundsF = new RectangleF(0, 0, 500, 40) };
        etiqueta.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[Nombre] + ' - ' + [LeyendaOriginal]"));
        detalle.Controls.Add(etiqueta);
        report.Bands.Add(detalle);
        return report;
    }

    private static void Subreportes(string carpeta, List<Fila> datos)
    {
        using (var principal = new XtraReport())
        {
            var banda = new DetailBand { HeightF = 100 };
            banda.Controls.Add(new XRSubreport { ReportSourceUrl = "Prueba.repx", SizeF = new SizeF(500, 100) });
            principal.Bands.Add(banda);
            principal.SaveLayoutToXml(Path.Combine(carpeta, "Padre.repx"));
        }
        var pdf = RepxRenderer.Render(carpeta, "Padre.repx", datos.Take(1).ToList());
        using (var stream = new MemoryStream(pdf))
        using (var document = PdfReader.Open(stream, PdfDocumentOpenMode.Import))
            if (document.PageCount == 0) throw new Exception("El subreporte no genero paginas.");
        using (var circular = new XtraReport())
        {
            var banda = new DetailBand();
            banda.Controls.Add(new XRSubreport { ReportSourceUrl = "Circular.repx" });
            circular.Bands.Add(banda);
            circular.SaveLayoutToXml(Path.Combine(carpeta, "Circular.repx"));
        }
        Rechaza(() => RepxRenderer.Render(carpeta, "Circular.repx", datos), "circular");
    }

    private static void VerificarPdf(byte[] bytes, int paginas, string caso)
    {
        if (System.Text.Encoding.ASCII.GetString(bytes, 0, 5) != "%PDF-") throw new Exception(caso + ": no es PDF.");
        using (var stream = new MemoryStream(bytes))
        using (var pdf = PdfReader.Open(stream, PdfDocumentOpenMode.Import))
        {
            if (pdf.PageCount != paginas) throw new Exception(caso + ": paginas esperadas " + paginas + ", obtenidas " + pdf.PageCount);
            if (Math.Abs(pdf.Pages[0].Width.Point - 432) > 1 || Math.Abs(pdf.Pages[0].Height.Point - 576) > 1)
                throw new Exception(caso + ": no se preservo el tamano de hoja de la plantilla: " + pdf.Pages[0].Width.Point + " x " + pdf.Pages[0].Height.Point);
        }
    }

    private static void Rechaza(Action action, string texto)
    {
        try { action(); }
        catch (ValidationException ex) when (ex.Message.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0) { return; }
        throw new Exception("Falta rechazo: " + texto);
    }

    public class Fila
    {
        public string Nombre { get; set; }
        public string LeyendaOriginal { get; set; }
    }
}
