using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_Gestion_BL;

namespace VENET_IA_BL
{
    public class AsistenteIAVentaSolicitud
    {
        public string Cliente { get; set; }
        public string Sucursal { get; set; }
        public string TipoComprobante { get; set; }
        public string FormaPago { get; set; }
        public List<AsistenteIAVentaItem> Productos { get; set; } = new List<AsistenteIAVentaItem>();
    }

    public class AsistenteIAVentaItem
    {
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
    }

    public class AsistenteIAVentaBorrador
    {
        public AsistenteIAVentaSolicitud Solicitud { get; set; }
        public string Cliente { get; set; }
        public string Sucursal { get; set; }
        public string TipoComprobante { get; set; }
        public string FormaPago { get; set; }
        public List<AsistenteIAVentaLinea> Lineas { get; set; } = new List<AsistenteIAVentaLinea>();
        public decimal Total { get; set; }
        public List<string> Advertencias { get; set; } = new List<string>();
        [JsonIgnore] public ComprobantesVentas Comprobante { get; set; }
    }

    public class AsistenteIAVentaLinea
    {
        public string Producto { get; set; }
        public string Moneda { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
    }

    /// <summary>Solo prepara entidades nuevas en memoria. Nunca guarda, liquida, cobra ni emite.</summary>
    public class AsistenteIAVentas
    {
        public static void ExigirPermiso()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ComprobantesVentas", Enums.Accion.Ingresar)
                || !Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ComprobantesVentas", Enums.Accion.Agregar))
                throw new AsistenteIAException(403, "Su usuario no tiene permiso para ingresar y agregar comprobantes de ventas.");
        }

        public object Buscar(string cliente, string producto)
        {
            ExigirPermiso();
            var clientes = Sistema.ObtenerEntidades(Enums.TipoEntidad.Cliente);
            object productos = null;
            if (!string.IsNullOrWhiteSpace(producto))
            {
                using (var detalle = new ComprobantesVentasDetalleManager(new ComprobantesVentasDetalle(), 0, 0, false))
                {
                    var encontrados = detalle.Productos.Where(p => Contiene(p.Descripcion, producto) || Contiene(p.Codigo, producto)
                        || Contiene(p.CodigoBarras, producto)).Take(11).ToList();
                    productos = new
                    {
                        coincidencias = encontrados.Take(10).Select(p => new { nombre = p.Descripcion, codigo = p.Codigo,
                            referencia = p.Descripcion + " [#" + p.Id + "]" }),
                        hayMas = encontrados.Count > 10
                    };
                }
            }
            var coincidencias = clientes.Where(c => Contiene(c.Name, cliente)).Take(11).ToList();
            return new
            {
                clientes = string.IsNullOrWhiteSpace(cliente) ? null : new
                {
                    coincidencias = coincidencias.Take(10).Select(c => new { nombre = c.Name, referencia = Referencia(c) }),
                    hayMas = coincidencias.Count > 10
                },
                productos,
                sucursales = Sistema.Sucursales.Select(s => s.Sucursal + " [#" + s.Id_Sucursal + "]"),
                comprobantes = Sistema.TipoComprobanteVentas.Select(Referencia),
                formasPago = Sistema.FormasPagos.Select(Referencia),
                nota = "Elegir nombres o codigos exactos; pedir aclaracion si hay ambiguedad. No se guarda ninguna operacion."
            };
        }

        public static void ValidarSolicitud(AsistenteIAVentaSolicitud solicitud)
        {
            if (solicitud == null || string.IsNullOrWhiteSpace(solicitud.Cliente))
                throw new AsistenteIAException(400, "Indique el cliente de la venta.");
            if (solicitud.Productos == null || solicitud.Productos.Count == 0 || solicitud.Productos.Count > 100)
                throw new AsistenteIAException(400, "Indique entre 1 y 100 renglones.");
            if (solicitud.Productos.Any(p => p == null || string.IsNullOrWhiteSpace(p.Producto) || p.Cantidad <= 0 || p.Cantidad > 1000000))
                throw new AsistenteIAException(400, "Cada renglon debe tener un producto y una cantidad mayor a cero y hasta 1.000.000.");
            if (new[] { solicitud.Cliente, solicitud.Sucursal, solicitud.TipoComprobante, solicitud.FormaPago }
                .Concat(solicitud.Productos.Select(p => p.Producto)).Any(s => s != null && s.Length > 500))
                throw new AsistenteIAException(400, "Los nombres de busqueda no pueden superar 500 caracteres.");
        }

        public AsistenteIAVentaBorrador Preparar(AsistenteIAVentaSolicitud solicitud)
        {
            ValidarSolicitud(solicitud);
            ExigirPermiso();
            var cliente = Resolver(Sistema.ObtenerEntidades(Enums.TipoEntidad.Cliente), solicitud.Cliente, "cliente");
            var sucursal = Resolver(Sistema.Sucursales.Select(s => new KeyNamePair { Key = s.Id_Sucursal, Name = s.Sucursal }).ToList(),
                solicitud.Sucursal, "sucursal");
            var tipo = Resolver(Sistema.TipoComprobanteVentas, solicitud.TipoComprobante, "tipo de comprobante");
            var comprobante = new ComprobantesVentas();
            var borrador = new AsistenteIAVentaBorrador
            {
                Solicitud = solicitud, Cliente = cliente.Name, Sucursal = sucursal.Name,
                TipoComprobante = tipo.Name, Comprobante = comprobante
            };
            using (var manager = new ComprobantesVentasManager(comprobante))
            {
                comprobante.Id_Sucursal = sucursal.Key;
                comprobante.Id_TipoComprobante = tipo.Key;
                comprobante.Id_TipoEntidad = Enums.TipoEntidad.Cliente;
                comprobante.Id_Entidad = cliente.Key;
                var talonarios = Sistema.ObtenerTalonario(sucursal.Key, tipo.Key, Enums.TipoEntidad.Cliente, cliente.Key);
                var talonario = talonarios.First();
                comprobante.Id_TalonariosComprobantes = talonario.Key;
                comprobante.Id_Deposito = talonario.Key2;
                var partes = talonario.Name.Split('-');
                if (partes.Length != 2) throw new AsistenteIAException(400, "El talonario no tiene letra y punto de venta validos.");
                comprobante.Letra = partes[0];
                comprobante.PuntoVenta = partes[1];
                if (talonarios.Count > 1) borrador.Advertencias.Add("Se propone el primer talonario disponible; reviselo antes de guardar.");
                if (!string.IsNullOrWhiteSpace(solicitud.FormaPago))
                    comprobante.Id_FormaPago = Resolver(Sistema.FormasPagos, solicitud.FormaPago, "forma de pago").Key;
                else if (manager.FormaPagocliente > 0) comprobante.Id_FormaPago = manager.FormaPagocliente.Value;
                borrador.FormaPago = Sistema.FormasPagos.FirstOrDefault(f => f.Key == comprobante.Id_FormaPago)?.Name;
                bool descuento = !manager.EsElectronico()
                    || Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVenta_DescuentoPorClienteEnElectronico));
                using (var detalleManager = new ComprobantesVentasDetalleManager(new ComprobantesVentasDetalle(), sucursal.Key, cliente.Key, descuento))
                {
                    var productos = detalleManager.Productos;
                    foreach (var item in solicitud.Productos)
                    {
                        var porCodigo = productos.Where(p => Igual(p.Codigo, item.Producto) || Igual(p.CodigoBarras, item.Producto)).ToList();
                        var candidatos = porCodigo.Count > 0 ? porCodigo : productos.Where(p => Igual(p.Descripcion, item.Producto)
                            || Igual(p.Descripcion + " [#" + p.Id + "]", item.Producto)).ToList();
                        if (candidatos.Count != 1)
                            throw new AsistenteIAException(400, "El producto '" + item.Producto + "' no es unico o no esta disponible. Busquelo y elija un codigo exacto.");
                        var linea = new ComprobantesVentasDetalle { Cantidad = item.Cantidad };
                        using (var m = new ComprobantesVentasDetalleManager(linea, sucursal.Key, cliente.Key, descuento))
                        {
                            linea.Id_Producto = candidatos[0].Id;
                            linea.AlicuotaIva = m.Alicuotas.Single(a => a.Key == linea.Id_AlicuotaIva).Name;
                            linea.Especie = ComprobantesVentasManager.GetEspecie(linea.Id_Especie);
                        }
                        CalcularLinea(linea);
                        comprobante.Detalle.Add(linea);
                        borrador.Lineas.Add(new AsistenteIAVentaLinea
                        {
                            Producto = linea.Descripcion, Moneda = linea.Especie, Cantidad = linea.Cantidad,
                            PrecioUnitario = linea.ImporteUnitario, Descuento = linea.PorcDescuento,
                            Iva = linea.ImporteIVA, Total = linea.Importe
                        });
                        if (linea.Visible_Cantidad_Stock) borrador.Advertencias.Add("Revise Cantidad Stock para " + linea.Descripcion + ".");
                    }
                }
                if (ComprobantesVentasManager.UtilizaImpuesto(tipo.Key))
                {
                    foreach (var impuesto in manager.EntidadesAlicuotas())
                    {
                        impuesto.Id = 0;
                        comprobante.Impuestos.Add(impuesto);
                    }
                }
                CalcularImpuestos(comprobante);
                comprobante.Importe = comprobante.Detalle.Sum(d => d.Importe) + comprobante.Impuestos.Sum(i => i.Importe);
                comprobante.ImportePesos = comprobante.Detalle.Sum(d => d.Importe * d.Cotizacion) + comprobante.Impuestos.Sum(i => i.Importe);
                borrador.Total = comprobante.ImportePesos.Value;
                borrador.Advertencias.Add("Borrador sin guardar. Total en pesos. Revise numeracion, fechas, stock e impuestos en el formulario.");
                return borrador;
            }
        }

        public static void CalcularLinea(ComprobantesVentasDetalle linea)
        {
            var neto = linea.ImporteUnitario * (1 - linea.PorcDescuento / 100) * linea.Cantidad;
            linea.ImporteIVA = Math.Round(neto * linea.AlicuotaIva / 100, 2);
            linea.Importe = Math.Round(neto + neto * linea.AlicuotaIva / 100, 2);
        }

        private static void CalcularImpuestos(ComprobantesVentas comprobante)
        {
            var gravado = comprobante.Detalle.Where(d => d.AlicuotaIva > 0).Sum(d => d.Importe - d.ImporteIVA);
            var noGravado = comprobante.Detalle.Where(d => d.AlicuotaIva <= 0).Sum(d => d.Importe);
            decimal sobreBruto = 0;
            foreach (var i in comprobante.Impuestos.Where(i => i.AplicaSobre == Enums.AplicaSobre.Bruto))
            {
                i.Importe = gravado >= i.BaseImponible ? Math.Round(gravado * i.Alicuota / 100, 2, MidpointRounding.AwayFromZero) : 0;
                i.ImporteBaseImponible = gravado;
                if (gravado > 0 && i.Importe < i.ImporteMinimo) i.Importe = i.ImporteMinimo;
                sobreBruto += i.Importe;
            }
            foreach (var i in comprobante.Impuestos.Where(i => i.AplicaSobre == Enums.AplicaSobre.Neto))
            {
                var baseCalculo = gravado + noGravado + sobreBruto;
                i.Importe = baseCalculo >= i.BaseImponible ? Math.Round(baseCalculo * i.Alicuota / 100, 2, MidpointRounding.AwayFromZero) : 0;
                i.ImporteBaseImponible = gravado + sobreBruto;
                if (gravado > 0 && i.Importe + sobreBruto < i.ImporteMinimo) i.Importe = i.ImporteMinimo;
            }
        }

        public static KeyNamePair Resolver(List<KeyNamePair> opciones, string nombre, string etiqueta)
        {
            var encontrados = string.IsNullOrWhiteSpace(nombre) ? opciones
                : opciones.Where(o => Igual(o.Name, nombre) || Igual(Referencia(o), nombre)).ToList();
            if (encontrados.Count != 1)
                throw new AsistenteIAException(400, "Indique un " + etiqueta + " exacto y sin ambiguedades. Opciones: "
                    + string.Join(", ", opciones.Take(10).Select(Referencia)));
            return encontrados[0];
        }

        private static string Referencia(KeyNamePair opcion) => opcion.Name + " [#" + opcion.Key + "]";

        private static bool Igual(string a, string b) => !string.IsNullOrWhiteSpace(a) && !string.IsNullOrWhiteSpace(b)
            && string.Equals(a.Trim(), b.Trim(), StringComparison.OrdinalIgnoreCase);
        private static bool Contiene(string valor, string buscar) => string.IsNullOrWhiteSpace(buscar)
            || (valor ?? "").IndexOf(buscar.Trim(), StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
