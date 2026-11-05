using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_Gestion_BL;
using VENET_IA_BL;

namespace SIGNET_Web.Api.Vendedores
{
    public class VentaMovil
    {
        public int Cliente { get; set; }
        public int Sucursal { get; set; }
        public int TipoComprobante { get; set; }
        public int Talonario { get; set; }
        public int CentroCosto { get; set; }
        public int Vendedor { get; set; }
        public int FormaPago { get; set; }
        public string Observaciones { get; set; }
        public List<LineaMovil> Productos { get; set; }
    }

    public class LineaMovil
    {
        public int Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? CantidadStock { get; set; }
    }

    public sealed class PortalVentas
    {
        private readonly IMemoryCache _cache;
        public PortalVentas(IMemoryCache cache) { _cache = cache; }

        public static bool Permiso(string pantalla, Enums.Modulos modulo, params Enums.Accion[] acciones)
        {
            SignetRequestContext.RequireSession();
            return acciones.All(a => Seguridad.TienePermiso(modulo, pantalla, a));
        }

        public static void Exigir(string pantalla, Enums.Modulos modulo, params Enums.Accion[] acciones)
        {
            if (!Permiso(pantalla, modulo, acciones))
                throw new ApiException(403, "Su usuario no tiene permiso para " + pantalla + ".");
        }

        public static void ExigirVenta()
        {
            Exigir("ComprobantesVentas", Enums.Modulos.Gestion, Enums.Accion.Ingresar, Enums.Accion.Agregar);
            try { AsistenteIAVentas.ExigirPermiso(); }
            catch (AsistenteIAException ex) { throw new ApiException(ex.Codigo, ex.Message); }
        }

        public static KeyNamePair Elegir(List<KeyNamePair> opciones, int id, string campo)
        {
            var opcion = id == 0 && opciones.Count == 1 ? opciones[0] : opciones.SingleOrDefault(x => x.Key == id);
            return opcion ?? throw new ValidationException("Seleccione un " + campo + " habilitado.");
        }

        public static KeyNamePair Entidad(Enums.TipoEntidad tipo, int id)
        {
            if (id <= 0) throw new ValidationException("Seleccione un cliente o entidad.");
            return Elegir(Sistema.ObtenerEntidades(tipo), id, "cliente o entidad");
        }

        public static void Validar(VentaMovil venta)
        {
            if (venta == null || venta.Cliente <= 0) throw new ValidationException("Seleccione un cliente.");
            if (venta.Productos == null || venta.Productos.Count < 1 || venta.Productos.Count > 100)
                throw new ValidationException("Agregue entre 1 y 100 productos.");
            if (venta.Productos.Any(p => p == null || p.Producto <= 0 || p.Cantidad < 0.01m || p.Cantidad > 1000000
                || p.CantidadStock.HasValue && (p.CantidadStock <= 0 || p.CantidadStock > 1000000)))
                throw new ValidationException("Ingrese productos y cantidades validas (0,01 a 1.000.000).");
            if ((venta.Observaciones ?? "").Length > 900) throw new ValidationException("Las observaciones admiten hasta 900 caracteres.");
        }

        public static List<KeyNamePair> Vendedores()
        {
            using (var db = new GestionContext())
                return db.Vendedores.Where(v => v.UserDel == null).OrderBy(v => v.Nombre)
                    .Select(v => new KeyNamePair { Key = v.Id, Name = v.Nombre }).ToList();
        }

        public static object Opciones()
        {
            ExigirVenta();
            return new
            {
                sucursales = Sistema.Sucursales.Select(s => new { key = s.Id_Sucursal, name = s.Sucursal }),
                comprobantes = Sistema.TipoComprobanteVentas,
                centros = Sistema.CentrosCostos.Select(c => new { key = c.Key, name = c.Name }),
                vendedores = Vendedores(),
                formasPago = Sistema.FormasPagos
            };
        }

        private static AsistenteIAVentaBorrador Preparar(VentaMovil venta)
        {
            ExigirVenta();
            Validar(venta);
            var cliente = Entidad(Enums.TipoEntidad.Cliente, venta.Cliente);
            var sucursal = Elegir(Sistema.Sucursales.Select(s => new KeyNamePair { Key = s.Id_Sucursal, Name = s.Sucursal }).ToList(),
                venta.Sucursal, "sucursal");
            var tipo = Elegir(Sistema.TipoComprobanteVentas, venta.TipoComprobante, "tipo de comprobante");
            var centro = Elegir(Sistema.CentrosCostos.Select(c => new KeyNamePair { Key = c.Key, Name = c.Name }).ToList(),
                venta.CentroCosto, "centro de costo");
            var vendedor = Elegir(Vendedores(), venta.Vendedor, "vendedor");
            var talonarios = Sistema.ObtenerTalonario(sucursal.Key, tipo.Key, Enums.TipoEntidad.Cliente, cliente.Key);
            var talonarioId = Elegir(talonarios.Select(t => new KeyNamePair { Key = t.Key, Name = t.Name }).ToList(),
                venta.Talonario, "talonario").Key;
            var talonario = talonarios.Single(t => t.Key == talonarioId);
            if (!Sistema.Depositos.Any(d => d.Key == talonario.Key2))
                throw new ValidationException("El deposito del talonario no esta habilitado para su usuario.");
            List<ComprobantesVentasDetalleManager.ProductosBusqueda> productos;
            using (var m = new ComprobantesVentasDetalleManager(new ComprobantesVentasDetalle(), sucursal.Key, cliente.Key, false))
                productos = m.Productos;
            var solicitud = new AsistenteIAVentaSolicitud
            {
                Cliente = Referencia(cliente), Sucursal = Referencia(sucursal), TipoComprobante = Referencia(tipo),
                FormaPago = venta.FormaPago > 0 ? Referencia(Elegir(Sistema.FormasPagos, venta.FormaPago, "forma de pago")) : null,
                Productos = venta.Productos.Select(p =>
                {
                    var producto = productos.SingleOrDefault(x => x.Id == p.Producto)
                        ?? throw new ValidationException("Un producto ya no esta habilitado. Vuelva a buscarlo.");
                    return new AsistenteIAVentaItem { Producto = producto.Descripcion + " [#" + producto.Id + "]", Cantidad = p.Cantidad };
                }).ToList()
            };
            AsistenteIAVentaBorrador borrador;
            try { borrador = new AsistenteIAVentas().Preparar(solicitud); }
            catch (AsistenteIAException ex) { throw new ApiException(ex.Codigo, ex.Message); }
            var comprobante = borrador.Comprobante;
            comprobante.Id_CentroCosto = centro.Key;
            comprobante.Id_Vendedor = vendedor.Key;
            comprobante.Id_TalonariosComprobantes = talonario.Key;
            comprobante.Id_Deposito = talonario.Key2;
            comprobante.Observaciones = string.IsNullOrWhiteSpace(venta.Observaciones) ? "Venta desde portal vendedores" : venta.Observaciones.Trim();
            var lineas = comprobante.Detalle.ToList();
            for (var i = 0; i < lineas.Count; i++)
            {
                lineas[i].CantidadStock = venta.Productos[i].CantidadStock;
                if (lineas[i].Visible_Cantidad_Stock
                    && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaDistintaUnidadStock))
                    && !lineas[i].CantidadStock.HasValue)
                    throw new ValidationException("Indique Cantidad Stock para " + lineas[i].Descripcion + ".");
            }
            comprobante.FechaLiquidacion = null;
            borrador.Advertencias = new List<string> { "Se guardara sin confirmar. Administracion debe revisar y confirmar la venta. No se emite en AFIP ni se cobra." };
            return borrador;
        }

        private static string Referencia(KeyNamePair opcion) => opcion.Name + " [#" + opcion.Key + "]";
        private static string Firma(AsistenteIAVentaBorrador b) => JsonConvert.SerializeObject(new
        {
            b.Total, b.Lineas, b.Comprobante.Id_FormaPago, b.Comprobante.Id_Deposito,
            Impuestos = b.Comprobante.Impuestos.Select(i => new { i.Id_Impuesto, i.Alicuota, i.Importe }),
            Cotizaciones = b.Comprobante.Detalle.Select(d => d.Cotizacion)
        });

        public object Revisar(VentaMovil venta)
        {
            var borrador = Preparar(venta);
            var ticket = new Ticket { Id = Guid.NewGuid().ToString("N"), Venta = venta, Firma = Firma(borrador) };
            _cache.Set(Clave(), ticket, TimeSpan.FromMinutes(20));
            return new { token = ticket.Id, resumen = borrador,
                impuestos = borrador.Comprobante.Impuestos.Select(i => new { nombre = i.Impuesto, alicuota = i.Alicuota, importe = i.Importe }).ToList() };
        }

        public object Guardar(string token)
        {
            ExigirVenta();
            if (!_cache.TryGetValue<Ticket>(Clave(), out var ticket) || ticket.Id != token)
                throw new ApiException(409, "La revision vencio. Revise la venta nuevamente antes de guardar.");
            lock (ticket)
            {
                if (ticket.Resultado != null) return ticket.Resultado;
                if (ticket.Intentado)
                    throw new ApiException(409, "No se puede repetir este guardado. Verifique en Comprobantes de Ventas si se registro antes de volver a cargar.");
                var borrador = Preparar(ticket.Venta);
                if (Firma(borrador) != ticket.Firma)
                    throw new ApiException(409, "Cambiaron precios, cotizaciones o impuestos. Revise la venta nuevamente.");
                using (var manager = new ComprobantesVentasManager(new ComprobantesVentas()))
                {
                    var c = manager.Comprobante;
                    var b = borrador.Comprobante;
                    c.Id_Entidad = b.Id_Entidad; c.Id_TipoEntidad = Enums.TipoEntidad.Cliente;
                    c.Id_Sucursal = b.Id_Sucursal; c.Id_TipoComprobante = b.Id_TipoComprobante;
                    c.Id_TalonariosComprobantes = b.Id_TalonariosComprobantes;
                    c.Id_Deposito = b.Id_Deposito; c.Id_CentroCosto = b.Id_CentroCosto;
                    c.Id_Vendedor = b.Id_Vendedor; c.Id_FormaPago = b.Id_FormaPago;
                    c.Fecha = b.Fecha; c.FechaEntrega = b.FechaEntrega; c.FechaVto = b.FechaVto;
                    c.Observaciones = b.Observaciones; c.Detalle = b.Detalle; c.Impuestos = b.Impuestos;
                    var ahora = Sistema.ObtenerFechaHora();
                    foreach (var linea in c.Detalle.Cast<ClaseBase>().Concat(c.Impuestos))
                    {
                        linea.Id = 0; linea.FechaAdd = ahora; linea.UserAdd = SignetRequestContext.RequireSession().UserId;
                        linea.FechaMod = linea.FechaDel = null; linea.UserMod = linea.UserDel = null;
                    }
                    // Nunca reintentar automaticamente despues de entrar al Save: podria haberse confirmado en SQL.
                    ticket.Intentado = true;
                    manager.Save();
                    ticket.Resultado = new { id = c.Id, comprobante = c.Comprobante, mensaje = "Venta guardada, pendiente de confirmacion por administracion." };
                    return ticket.Resultado;
                }
            }
        }

        private static string Clave() => "vendedores:" + SignetRequestContext.RequireSession().Token;
        private sealed class Ticket
        {
            public string Id;
            public VentaMovil Venta;
            public string Firma;
            public bool Intentado;
            public object Resultado;
        }
    }
}
