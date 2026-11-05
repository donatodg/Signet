using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VENET_Common;

namespace VENET_Gestion_BL
{
    public sealed class ArchivoCompra
    {
        public string Nombre { get; set; }
        public string Base64 { get; set; }
    }
    public sealed class OpcionesComprasDocumento
    {
        public bool Configurado { get; set; }
        public string Modelo { get; set; }
        public List<KeyNamePair> Sucursales { get; set; }
        public List<KeyNamePair> Proveedores { get; set; }
        public List<KeyNamePair> Tipos { get; set; }
        public List<KeyNamePair> Depositos { get; set; }
        public List<KeyNamePair> Centros { get; set; }
        public List<KeyNamePair> Formas { get; set; }
        public List<KeyNamePair> Monedas { get; set; }
        public List<decimal> Alicuotas { get; set; }
    }
    public sealed class DocumentoCompraLeido
    {
        public string Proveedor { get; set; }
        public string Cuit { get; set; }
        public string Tipo { get; set; }
        public string Letra { get; set; }
        public string PuntoVenta { get; set; }
        public string Numero { get; set; }
        public DateTime? Fecha { get; set; }
        public string Moneda { get; set; }
        public decimal? Total { get; set; }
        public decimal? Neto { get; set; }
        public decimal? Iva { get; set; }
        public decimal? NoGravado { get; set; }
        public decimal? OtrosImpuestos { get; set; }
        public decimal? PercepcionIva { get; set; }
        public decimal? PercepcionIibb { get; set; }
        public decimal? PercepcionGanancias { get; set; }
        public decimal? Itc { get; set; }
        public decimal? PercepcionIibbCapital { get; set; }
        public decimal? Descuento { get; set; }
        public List<ItemCompraLeido> Items { get; set; } = new List<ItemCompraLeido>();
        public List<string> Advertencias { get; set; } = new List<string>();
    }
    public sealed class ItemCompraLeido
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioNeto { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Total { get; set; }
        public string TipoTotal { get; set; }
        public int? Producto { get; set; }
        public decimal? CantidadStock { get; set; }
        public bool RecordarEquivalencia { get; set; }
    }
    public sealed class RevisionCompraDocumento
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public int Sucursal { get; set; }
        public int Proveedor { get; set; }
        public int TipoComprobante { get; set; }
        public int Deposito { get; set; }
        public int CentroCosto { get; set; }
        public int FormaPago { get; set; }
        public int Moneda { get; set; }
        public decimal Cotizacion { get; set; }
        public DateTime Recepcion { get; set; }
        public DateTime Vencimiento { get; set; }
        public bool Revisado { get; set; }
        public DocumentoCompraLeido Documento { get; set; }
    }
    public sealed class ImportacionCompra
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public int Sucursal { get; set; }
        public string Estado { get; set; }
        public string Error { get; set; }
        public DateTime Fecha { get; set; }
        public int? Compra { get; set; }
        public DocumentoCompraLeido Lectura { get; set; }
        public RevisionCompraDocumento Revision { get; set; }
        public List<string> Archivos { get; set; } = new List<string>();
    }
    public sealed class ResultadoRevisionCompra
    {
        public decimal Total { get; set; }
        public decimal Neto { get; set; }
        public decimal Iva { get; set; }
        public string Firma { get; set; }
        public List<string> Errores { get; set; } = new List<string>();
        public List<string> Advertencias { get; set; } = new List<string>();
        public int? Compra { get; set; }
    }
    public static class CalculoCompraDocumento
    {
        public static decimal Redondear(decimal n) => decimal.Round(n, 2, MidpointRounding.ToEven);
        public static ResultadoRevisionCompra Validar(RevisionCompraDocumento r)
        {
            var result = new ResultadoRevisionCompra();
            if (r?.Documento == null) throw new ValidationException("Falta el documento revisado.");
            var d = r.Documento;
            if (r.Id == Guid.Empty || r.Sucursal <= 0 || r.Proveedor <= 0 || r.TipoComprobante <= 0 || r.Deposito <= 0
                || r.CentroCosto <= 0 || r.FormaPago <= 0 || r.Moneda <= 0 || r.Cotizacion <= 0 || r.Cotizacion > 1000000000)
                result.Errores.Add("Seleccione sucursal, proveedor, tipo, deposito, centro de costo, pago, moneda y cotizacion positiva.");
            if (!d.Fecha.HasValue || d.Fecha.Value.Year < 1753 || d.Fecha.Value.Year >= 9999
                || r.Recepcion.Year < 1753 || r.Recepcion.Year >= 9999 || r.Vencimiento.Year < 1753 || r.Vencimiento.Year >= 9999 || d.Fecha.Value.Date > r.Recepcion.Date)
                result.Errores.Add("Revise fecha del comprobante, recepcion y vencimiento.");
            if (!new[] { "A", "B", "C", "M", "E" }.Contains(d.Letra)
                || !Digitos(d.PuntoVenta, 5) || (Digitos(d.PuntoVenta, 5) && int.Parse(d.PuntoVenta) > 9999) || !Digitos(d.Numero, 8))
                result.Errores.Add("Letra o numeracion invalidas. El BL admite punto de venta hasta 9999 (se aceptan ceros iniciales) y numero hasta 8 digitos.");
            if (Digitos(d.Numero, 8) && long.Parse(d.Numero) == 0) result.Errores.Add("El numero del comprobante no puede ser cero.");
            if (!CuitValido(d.Cuit)) result.Errores.Add("Revise el CUIT del proveedor y su digito verificador.");
            var adicionales = new[] { d.NoGravado, d.OtrosImpuestos, d.PercepcionIva, d.PercepcionIibb,
                d.PercepcionGanancias, d.Itc, d.PercepcionIibbCapital, d.Descuento };
            if (adicionales.Any(v => !v.HasValue || v < 0 || v > 1000000000000m))
                result.Errores.Add("Complete impuestos adicionales y descuento: indique cero solo despues de verificar su ausencia.");
            if (r.Cotizacion != Redondear(r.Cotizacion) || adicionales.Any(v => v.HasValue && v != Redondear(v.Value)))
                result.Errores.Add("El modelo EF heredado conserva dos decimales. Revise cotizacion e impuestos sin truncarlos automaticamente.");
            if (r.Cotizacion != 1 && adicionales.Any(v => v.GetValueOrDefault() != 0))
                result.Errores.Add("Moneda extranjera con impuestos/descuento de cabecera: completar por el circuito habitual; no se infiere su conversion.");
            if (d.Items == null || d.Items.Count == 0 || d.Items.Count > 200)
                result.Errores.Add("El documento debe contener entre 1 y 200 items.");
            else for (int i = 0; i < d.Items.Count; i++)
                {
                    var p = d.Items[i];
                    if (p == null || string.IsNullOrWhiteSpace(p.Descripcion) || p.Descripcion.Length > 4000
                        || p.Producto.GetValueOrDefault() <= 0 || !p.Cantidad.HasValue || p.Cantidad <= 0 || p.Cantidad > 1000000
                        || !p.PrecioNeto.HasValue || p.PrecioNeto < 0 || p.PrecioNeto > 1000000000 || !p.Descuento.HasValue || p.Descuento < 0 || p.Descuento > 100
                        || !p.Iva.HasValue || p.Iva < 0 || p.Iva > 100 || p.CantidadStock < 0 || p.CantidadStock > 1000000000)
                    { result.Errores.Add("Item " + (i + 1) + ": completar producto, descripcion, cantidad, precio NETO, descuento e IVA validos."); continue; }
                    if (new[] { p.Cantidad, p.CantidadStock, p.PrecioNeto, p.Descuento, p.Iva }.Any(v => v.HasValue && v != Redondear(v.Value)))
                        result.Errores.Add("Item " + (i + 1) + ": el modelo EF heredado conserva dos decimales; revise precio, cantidades y porcentajes sin truncarlos.");
                    var neto = p.PrecioNeto.Value * (1 - p.Descuento.Value / 100) * p.Cantidad.Value;
                    var iva = Redondear(neto * p.Iva.Value / 100);
                    var total = Redondear(neto * (1 + p.Iva.Value / 100));
                    if (total > int.MaxValue || iva > int.MaxValue)
                        result.Errores.Add("Item " + (i + 1) + ": importe fuera del rango admitido por el BL.");
                    result.Neto += total - iva; result.Iva += iva; result.Total += total;
                    if (p.TipoTotal != "Neto" && p.TipoTotal != "ConIva")
                        result.Errores.Add("Item " + (i + 1) + ": indique si el total impreso es neto o incluye IVA.");
                    var totalImpreso = p.TipoTotal == "Neto" ? Redondear(neto) : total;
                    if (!p.Total.HasValue || p.Total < 0 || p.Total > 1000000000000m || Math.Abs(p.Total.Value - totalImpreso) > .02m)
                        result.Errores.Add("Item " + (i + 1) + ": el total leido no coincide con el recalculo.");
                }
            if (adicionales.All(v => v.HasValue && v >= 0 && v <= 1000000000000m))
                result.Total += adicionales.Take(7).Sum(v => v.Value) - d.Descuento.Value;
            if (!d.Total.HasValue || d.Total <= 0 || d.Total > 1000000000000m || Math.Abs(d.Total.Value - result.Total) > .02m)
                result.Errores.Add("El total de la factura no coincide con items, impuestos y descuento.");
            if (r.Cotizacion > 0 && r.Cotizacion <= 1000000000 && Math.Abs(result.Total) * r.Cotizacion > 9999999999999999.99m)
                result.Errores.Add("El importe convertido excede el rango decimal del modelo EF heredado.");
            if (d.Iva.HasValue && (d.Iva < 0 || d.Iva > 1000000000000m || Math.Abs(d.Iva.Value - result.Iva) > .02m)) result.Errores.Add("El IVA de cabecera no coincide con los items.");
            if (d.Neto.HasValue && (d.Neto < 0 || d.Neto > 1000000000000m || Math.Abs(d.Neto.Value - result.Neto) > .02m)) result.Errores.Add("El neto de cabecera no coincide con los items.");
            if (!r.Revisado) result.Errores.Add("Debe revisar el original y confirmar proveedor, productos, unidades, impuestos y totales.");
            result.Advertencias.Add("La lectura es una propuesta: no verifica autenticidad fiscal ni validez de CAE/QR.");
            if (d.Advertencias != null) result.Advertencias.AddRange(d.Advertencias.Take(30).Select(s => (s ?? "").Substring(0, Math.Min((s ?? "").Length, 500))));
            return result;
        }
        public static bool Digitos(string s, int max) => !string.IsNullOrEmpty(s) && s.Length <= max && s.All(c => c >= '0' && c <= '9');
        public static string NormalizarCuit(string s) => (s ?? "").Replace("-", "").Replace(" ", "").Trim();
        public static bool CuitValido(string texto)
        {
            var c = NormalizarCuit(texto);
            if (!Digitos(c, 11) || c.Length != 11 || c.All(n => n == c[0])) return false;
            var pesos = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int digito = 11 - Enumerable.Range(0, 10).Sum(i => (c[i] - '0') * pesos[i]) % 11;
            if (digito == 11) digito = 0;
            if (digito == 10) digito = 9;
            return digito == c[10] - '0';
        }
    }
}
