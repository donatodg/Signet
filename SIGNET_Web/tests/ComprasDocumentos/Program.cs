using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VENET_Gestion_BL;
using VENET_Common;
#if !NATIVE
using SIGNET_Web.Api.Controllers;
using SIGNET_Web.Api.Infrastructure;
#endif

internal static class Program
{
    [STAThread]
    private static int Main(string[] args)
    {
        try
        {
            if (args.Length > 0 && args[0] == "--sql") return IntegracionSql.Ejecutar(args);
            Calculos(); Archivos(); Firmas(); Lecturas().GetAwaiter().GetResult();
#if !NATIVE
            SinSesion();
#endif
#if NATIVE
            Console.WriteLine("PASS nativo: formulario compilado, BL, incertidumbre, CUIT, firmas, archivos, PDF real y lector local simulado.");
#else
            Console.WriteLine("PASS compras documentales: calculos, incertidumbre, CUIT, firmas, archivos, PDF real, lector local y permisos.");
#endif
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
    }
    private static void Afirmar(bool b, string texto) { if (!b) throw new Exception(texto); }
    private static void Rechaza(Action a, string texto)
    { try { a(); } catch (ValidationException e) { Afirmar(e.Message.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0, e.Message); return; } throw new Exception("No rechazo: " + texto); }
    private static RevisionCompraDocumento Ejemplo() => new RevisionCompraDocumento
    {
        Id = Guid.NewGuid(),
        Version = 1,
        Sucursal = 1,
        Proveedor = 2,
        TipoComprobante = 3,
        Deposito = 1,
        CentroCosto = 1,
        FormaPago = 1,
        Moneda = 1,
        Cotizacion = 1,
        Recepcion = new DateTime(2026, 5, 2),
        Vencimiento = new DateTime(2026, 5, 10),
        Revisado = true,
        Documento = new DocumentoCompraLeido
        {
            Proveedor = "Proveedor ficticio",
            Cuit = "20-12345678-6",
            Tipo = "Factura",
            Letra = "A",
            PuntoVenta = "1",
            Numero = "123",
            Fecha = new DateTime(2026, 5, 1),
            Moneda = "ARS",
            Total = 217.8m,
            Neto = 180,
            Iva = 37.8m,
            NoGravado = 0,
            OtrosImpuestos = 0,
            PercepcionIva = 0,
            PercepcionIibb = 0,
            PercepcionGanancias = 0,
            Itc = 0,
            PercepcionIibbCapital = 0,
            Descuento = 0,
            Items = new List<ItemCompraLeido> { new ItemCompraLeido { Codigo = "ABC", Descripcion = "Articulo de prueba", Producto = 4,
                Cantidad = 2, PrecioNeto = 100, Descuento = 10, Iva = 21, Total = 217.8m, TipoTotal = "ConIva", CantidadStock = 2 } }
        }
    };
    private static void Calculos()
    {
        var r = Ejemplo(); var ok = CalculoCompraDocumento.Validar(r);
        Afirmar(ok.Errores.Count == 0 && ok.Total == 217.8m && ok.Neto == 180 && ok.Iva == 37.8m, string.Join("; ", ok.Errores));
        r.Documento.Items[0].TipoTotal = "Neto"; r.Documento.Items[0].Total = 180m;
        var netoImpreso = CalculoCompraDocumento.Validar(r);
        Afirmar(netoImpreso.Errores.Count == 0 && netoImpreso.Total == 217.8m, "Factura A con renglon neto impreso, no bruto inventado.");
        r = Ejemplo(); r.Documento.Items[0].TipoTotal = null;
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Any(s => s.Contains("total impreso")), "No inferir semantica de total dudoso.");
        r = Ejemplo();
        r.Documento.PuntoVenta = "00001";
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Count == 0, "Aceptar punto impreso de 5 digitos con cero inicial compatible.");
        r.Documento.PuntoVenta = "10000";
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Count > 0, "No truncar punto mayor al admitido por el BL.");
        Afirmar(CalculoCompraDocumento.Redondear(1.005m) == 1m && CalculoCompraDocumento.Redondear(1.015m) == 1.02m, "Redondeo distinto del BL.");
        r = Ejemplo(); r.Revisado = false; Afirmar(CalculoCompraDocumento.Validar(r).Errores.Any(s => s.Contains("revisar")), "Falta revision humana");
        r = Ejemplo(); r.Documento.OtrosImpuestos = null;
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Any(s => s.Contains("adicionales")), "Desconocido no es cero");
        r = Ejemplo(); r.Documento.Items[0].Producto = null;
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Count > 0, "No inventar producto");
        r = Ejemplo(); r.Documento.Items[0].Total = 200;
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Any(s => s.Contains("recalculo")), "Mismatch de linea");
        r = Ejemplo(); r.Documento.Total = 220;
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Any(s => s.Contains("factura")), "Mismatch de factura");
        r = Ejemplo(); r.Documento.PercepcionIva = 1; r.Cotizacion = 1000;
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Any(s => s.Contains("extranjera")), "No inferir FX de percepciones");
        r = Ejemplo(); r.Documento.Cuit = "20123456780";
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Any(s => s.Contains("CUIT")), "Verificador CUIT");
        r = Ejemplo(); r.Documento.Letra = "XYZ"; r.Documento.PuntoVenta = "00001";
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Any(s => s.Contains("numeracion")), "Limite numero");
        r = Ejemplo(); r.Documento.Items[0].CantidadStock = -1;
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Count > 0, "Stock negativo");
        r = Ejemplo(); r.Documento.Items[0].PrecioNeto = 100.001m;
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Any(s => s.Contains("dos decimales")), "No truncar el precio al persistir con EF.");
        r = Ejemplo(); r.Documento.NoGravado = r.Documento.OtrosImpuestos = decimal.MaxValue; r.Documento.Neto = r.Documento.Iva = decimal.MinValue;
        r.Documento.Items[0].Total = decimal.MinValue;
        Afirmar(CalculoCompraDocumento.Validar(r).Errores.Count > 0, "Numeros hostiles deben dar validacion sin overflow.");
    }
    private static byte[] Png()
    {
        using (var b = new Bitmap(100, 80)) using (var g = Graphics.FromImage(b)) using (var s = new MemoryStream())
        { g.Clear(Color.White); g.DrawString("TEST", SystemFonts.DefaultFont, Brushes.Black, 5, 5); b.Save(s, ImageFormat.Png); return s.ToArray(); }
    }
    private static List<ArchivoCompra> Archivo(string nombre, byte[] bytes) => new List<ArchivoCompra> { new ArchivoCompra { Nombre = nombre, Base64 = Convert.ToBase64String(bytes) } };
    private static void Archivos()
    {
        var imagen = Png(); var a = ComprasDocumentosLector.ValidarArchivos(Archivo("prueba.png", imagen));
        var paginas = ComprasDocumentosLector.Paginas(a);
        using (var b = Image.FromStream(new MemoryStream(paginas.Single()))) Afirmar(b.Width == 100 && b.Height == 80, "Vista JPG real");
        var jpg = paginas.Single();
        Afirmar(ComprasDocumentosLector.Paginas(ComprasDocumentosLector.ValidarArchivos(Archivo("foto.jpg", jpg))).Count == 1, "JPEG de celular");
        Rechaza(() => ComprasDocumentosLector.ValidarArchivos(Archivo("prueba.pdf", imagen)), "firma");
        Rechaza(() => ComprasDocumentosLector.ValidarArchivos(Archivo("..\\prueba.png", imagen)), "Nombre");
        Rechaza(() => ComprasDocumentosLector.ValidarArchivos(new List<ArchivoCompra>()), "Suba");
        Rechaza(() => ComprasDocumentosLector.ValidarArchivos(Enumerable.Range(0, 7).Select(i => Archivo("a.png", imagen)[0]).ToList()), "Suba");
        Rechaza(() => ComprasDocumentosLector.ValidarArchivos(new List<ArchivoCompra> { new ArchivoCompra { Nombre = "a.png", Base64 = "****" } }), "base64");
        var pdf = Pdf();
        var raster = ComprasDocumentosLector.Paginas(ComprasDocumentosLector.ValidarArchivos(Archivo("prueba.pdf", pdf)));
        using (var bitmap = new Bitmap(new MemoryStream(raster.Single())))
            Afirmar(bitmap.Width > 100 && bitmap.GetPixel(bitmap.Width - 2, bitmap.Height - 2).R > 230, "PDF rasterizado con fondo blanco.");
        Rechaza(() => ComprasDocumentosLector.Paginas(ComprasDocumentosLector.ValidarArchivos(Archivo("corrupto.pdf", Encoding.ASCII.GetBytes("%PDF-1.4\ngarbage")))), "PDF corrupto");
        Console.WriteLine("PASS raster: PNG y PDF generados localmente a JPEG, sin subir documentos reales.");
    }
    private static byte[] Pdf()
    {
        var contenido = "BT /F1 14 Tf 20 100 Td (FACTURA TEST 121.00) Tj ET";
        var objetos = new[] { "<< /Type /Catalog /Pages 2 0 R >>", "<< /Type /Pages /Kids [3 0 R] /Count 1 >>",
            "<< /Type /Page /Parent 2 0 R /MediaBox [0 0 300 200] /Contents 4 0 R /Resources << /Font << /F1 5 0 R >> >> >>",
            "<< /Length " + contenido.Length + " >>\nstream\n" + contenido + "\nendstream", "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>" };
        var s = new StringBuilder("%PDF-1.4\n"); var offsets = new List<int>();
        for (int i = 0; i < objetos.Length; i++) { offsets.Add(s.Length); s.Append((i + 1) + " 0 obj\n" + objetos[i] + "\nendobj\n"); }
        int xref = s.Length; s.Append("xref\n0 6\n0000000000 65535 f \n");
        foreach (var o in offsets) s.Append(o.ToString("D10") + " 00000 n \n");
        s.Append("trailer\n<< /Size 6 /Root 1 0 R >>\nstartxref\n" + xref + "\n%%EOF");
        return Encoding.ASCII.GetBytes(s.ToString());
    }
    private static void Firmas()
    {
        var r = Ejemplo(); var firma = ComprasDocumentosService.Firmar(r);
        r.Documento.Items[0].PrecioNeto = 100.00000m; r.Documento.Total = 217.8000m;
        Afirmar(ComprasDocumentosService.Firmar(r) == firma, "Firma estable en decimal");
        r.Documento.Items[0].Producto++;
        Afirmar(ComprasDocumentosService.Firmar(r) != firma, "Cambiar producto invalida revision");
        var json = JsonConvert.SerializeObject(Ejemplo().Documento);
        var d = ComprasDocumentosLector.Parsear(json);
        Afirmar(d.Items[0].Producto == null && d.Items[0].CantidadStock == null && !d.Items[0].RecordarEquivalencia, "No confiar IDs del lector");
        Rechaza(() => ComprasDocumentosLector.Parsear("{\"items\":[],\"comando\":\"guardar\"}"), "esquema");
        Rechaza(() => ComprasDocumentosLector.Parsear("{\"items\":[null]}"), "estructurada");
        Rechaza(() => ComprasDocumentosLector.Parsear("{\"items\":[],\"total\":1,\"total\":2}"), "esquema");
        Rechaza(() => ComprasDocumentosLector.Parsear("```json {} ```"), "esquema");
    }
    private static async Task Lecturas()
    {
        var previoModelo = Environment.GetEnvironmentVariable("SIGNET_COMPRAS_VISION_MODELO");
        var previoUrl = Environment.GetEnvironmentVariable("SIGNET_COMPRAS_VISION_URL");
        try
        {
            Environment.SetEnvironmentVariable("SIGNET_COMPRAS_VISION_URL", "https://example.com/v1/chat/completions");
            Rechaza(() => ComprasDocumentosLector.Endpoint(), "local");
            Environment.SetEnvironmentVariable("SIGNET_COMPRAS_VISION_MODELO", "prueba-local");
            var lector = new ComprasDocumentosLector();
            var respuesta = JsonConvert.SerializeObject(new { choices = new[] { new { finish_reason = "stop", message = new { content = JsonConvert.SerializeObject(Ejemplo().Documento) } } } });
            await Servidor(respuesta, 200, async () =>
            {
                var r = await lector.LeerAsync(new List<byte[]> { Png() }, CancellationToken.None);
                Afirmar(r.Total == 217.8m && r.Items.Count == 1 && r.Items[0].Producto == null, "Transcripcion simulada de servidor local.");
            });
            await Servidor(respuesta.Replace("\"stop\"", "\"length\""), 200, async () =>
            {
                try { await lector.LeerAsync(new List<byte[]> { Png() }, CancellationToken.None); } catch (ValidationException e) { Afirmar(e.Message.Contains("truncada"), e.Message); return; }
                throw new Exception("No rechazo respuesta truncada.");
            });
            await Servidor("{}", 302, async () =>
            {
                try { await lector.LeerAsync(new List<byte[]> { Png() }, CancellationToken.None); } catch (ValidationException e) { Afirmar(e.Message.Contains("302"), e.Message); return; }
                throw new Exception("No rechazo redireccion.");
            });
        }
        finally { Environment.SetEnvironmentVariable("SIGNET_COMPRAS_VISION_MODELO", previoModelo); Environment.SetEnvironmentVariable("SIGNET_COMPRAS_VISION_URL", previoUrl); }
    }
    private static async Task Servidor(string respuesta, int estado, Func<Task> probar)
    {
        var listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        Environment.SetEnvironmentVariable("SIGNET_COMPRAS_VISION_URL", "http://127.0.0.1:" + ((IPEndPoint)listener.LocalEndpoint).Port + "/v1/chat/completions");
        var servir = Task.Run(async () =>
        {
            using (var cliente = await listener.AcceptTcpClientAsync())
            using (var stream = cliente.GetStream())
            {
                var datos = new List<byte>(); var b = new byte[8192]; int n, largo = -1, cabecera = -1;
                while ((n = await stream.ReadAsync(b, 0, b.Length)) > 0)
                {
                    datos.AddRange(b.Take(n));
                    var texto = Encoding.UTF8.GetString(datos.ToArray());
                    if (cabecera < 0 && texto.Contains("\r\n\r\n"))
                    {
                        cabecera = texto.IndexOf("\r\n\r\n", StringComparison.Ordinal) + 4;
                        var h = texto.Substring(0, cabecera).Split(new[] { "\r\n" }, StringSplitOptions.None);
                        largo = int.Parse(h.First(x => x.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase)).Split(':')[1]);
                    }
                    if (cabecera >= 0 && datos.Count >= cabecera + largo) break;
                }
                var request = Encoding.UTF8.GetString(datos.ToArray());
                Afirmar(request.Contains("prueba-local") && request.Contains("image_url") && request.Contains("json_object"), "Payload multimodal local.");
                var cuerpo = Encoding.UTF8.GetBytes(respuesta);
                var headers = Encoding.ASCII.GetBytes("HTTP/1.1 " + estado + " Test\r\nContent-Type: application/json\r\nContent-Length: " + cuerpo.Length + "\r\nConnection: close\r\n\r\n");
                await stream.WriteAsync(headers, 0, headers.Length); await stream.WriteAsync(cuerpo, 0, cuerpo.Length);
            }
        });
        try { await probar(); await servir; } finally { listener.Stop(); }
    }
#if !NATIVE
    private static void SinSesion()
    {
        var settings = new System.Collections.Specialized.NameValueCollection { ["CurrentUserId"] = "2" };
        var session = new SignetSession("documentos-test", settings)
        {
            Seguridad = new SeguridadState
            {
                GrupoUsuario = new VENET_DataEntity.SeguridadGrupos { EsAdministrador = false },
                Objetos = new List<VENET_DataEntity.SeguridadObjetos>()
            }
        };
        SignetRequestContext.Current = new SignetRequestContext(session, settings); var c = new ComprasDocumentosController();
        var consultas = new Action[] { () => c.Opciones(), () => c.Listar(), () => c.Obtener(Guid.NewGuid()), () => c.Vista(Guid.NewGuid()),
            () => c.Cargar(null), () => c.Revisar(null), () => c.GuardarRevision(null), () => c.Guardar(null), () => c.Productos("a"),
            () => c.Propuesta(Guid.NewGuid()), () => c.Original(Guid.NewGuid(), 0), () => c.Leer(Guid.NewGuid(), null, CancellationToken.None).GetAwaiter().GetResult() };
        foreach (var a in consultas)
        {
            try { a(); } catch (ApiException ex) { Afirmar(ex.Status == 403, "HTTP sin permisos"); continue; }
            throw new Exception("Endpoint documental sin exigir sesion");
        }
        session.Seguridad.Objetos.Add(new VENET_DataEntity.SeguridadObjetos { Id = 1, Modulo = VENET_Comun.Enums.Modulos.Gestion, Formulario = "ComprobantesCompras", Permiso = "Ingresar" });
        try { c.Listar(); throw new Exception("Ingresar sin Agregar no debe permitir leer los documentos."); }
        catch (ApiException ex) { Afirmar(ex.Status == 403, "Agregar obligatorio."); }
        SignetRequestContext.Current = null;
    }
#endif
}
