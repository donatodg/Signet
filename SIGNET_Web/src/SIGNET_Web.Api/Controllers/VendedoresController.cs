using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SIGNET_Web.Api.Infrastructure;
using SIGNET_Web.Api.Vendedores;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_Gestion_BL;
using VENET_Tesoreria_BL;
using SIGNET_Web.Api.Screens.Acciones;

namespace SIGNET_Web.Api.Controllers
{
    [ApiController]
    [Route("api/vendedores")]
    public class VendedoresController : ControllerBase
    {
        private readonly PortalVentas _ventas;
        private readonly AccionesService _acciones;
        public VendedoresController(PortalVentas ventas, AccionesService acciones) { _ventas = ventas; _acciones = acciones; }

        [HttpGet]
        public object Estado() => new
        {
            ingresar = PortalVentas.Permiso("Productos", Enums.Modulos.Gestion, Enums.Accion.Ingresar)
                || PortalVentas.Permiso("EntidadesCtaCte", Enums.Modulos.Tesoreria, Enums.Accion.Ingresar)
                || (PortalVentas.Permiso("ComprobantesVentas", Enums.Modulos.Gestion, Enums.Accion.Ingresar)
                    && PortalVentas.Permiso("ComprobantesVentas", Enums.Modulos.Tesoreria, Enums.Accion.Ingresar)),
            precios = PortalVentas.Permiso("Productos", Enums.Modulos.Gestion, Enums.Accion.Ingresar, Enums.Accion.Buscar),
            cuenta = PortalVentas.Permiso("EntidadesCtaCte", Enums.Modulos.Tesoreria, Enums.Accion.Ingresar, Enums.Accion.Buscar),
            ventas = PortalVentas.Permiso("ComprobantesVentas", Enums.Modulos.Gestion, Enums.Accion.Ingresar, Enums.Accion.Agregar)
                && PortalVentas.Permiso("ComprobantesVentas", Enums.Modulos.Tesoreria, Enums.Accion.Ingresar, Enums.Accion.Agregar)
        };

        private static void AccesoConsulta(string uso)
        {
            if (uso == "venta") PortalVentas.ExigirVenta();
            else if (uso == "precios") PortalVentas.Exigir("Productos", Enums.Modulos.Gestion, Enums.Accion.Ingresar, Enums.Accion.Buscar);
            else if (uso == "cuenta") PortalVentas.Exigir("EntidadesCtaCte", Enums.Modulos.Tesoreria, Enums.Accion.Ingresar, Enums.Accion.Buscar);
            else throw new ValidationException("Consulta no valida.");
        }

        private static Enums.TipoEntidad Tipo(int tipo)
        {
            if (!new[] { Enums.TipoEntidad.Cliente, Enums.TipoEntidad.Proveedor, Enums.TipoEntidad.Proveedor_Financiero, Enums.TipoEntidad.Personal }
                .Contains((Enums.TipoEntidad)tipo)) throw new ValidationException("Tipo de entidad no valido.");
            return (Enums.TipoEntidad)tipo;
        }

        [HttpGet("entidades")]
        public object Entidades(string uso, string buscar = "", int tipo = (int)Enums.TipoEntidad.Cliente)
        {
            AccesoConsulta(uso);
            var tipoEntidad = uso == "cuenta" ? Tipo(tipo) : Enums.TipoEntidad.Cliente;
            var texto = (buscar ?? "").Trim();
            if (texto.Length > 100) throw new ValidationException("La busqueda admite hasta 100 caracteres.");
            var entidades = Sistema.ObtenerEntidades(tipoEntidad).Where(e => (e.Name ?? "").IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0).Take(31).ToList();
            return new { opciones = entidades.Take(30), hayMas = entidades.Count > 30 };
        }

        [HttpGet("opciones")]
        public object Opciones() => PortalVentas.Opciones();

        [HttpGet("talonarios")]
        public object Talonarios(int cliente, int sucursal, int comprobante)
        {
            PortalVentas.ExigirVenta();
            PortalVentas.Entidad(Enums.TipoEntidad.Cliente, cliente);
            if (!Sistema.Sucursales.Any(s => s.Id_Sucursal == sucursal) || !Sistema.TipoComprobanteVentas.Any(t => t.Key == comprobante))
                throw new ApiException(403, "Sucursal o comprobante no habilitado.");
            return Sistema.ObtenerTalonario(sucursal, comprobante, Enums.TipoEntidad.Cliente, cliente)
                .Select(t => new { key = t.Key, name = t.Name });
        }

        [HttpGet("productos")]
        public object Productos(string uso, int cliente, string buscar = "")
        {
            if (uso != "precios" && uso != "venta") throw new ValidationException("Consulta de productos no valida.");
            AccesoConsulta(uso);
            PortalVentas.Entidad(Enums.TipoEntidad.Cliente, cliente);
            var texto = (buscar ?? "").Trim();
            if (texto.Length < 2 || texto.Length > 100) throw new ValidationException("Escriba entre 2 y 100 caracteres.");
            using (var m = new ComprobantesVentasDetalleManager(new ComprobantesVentasDetalle(), 0, cliente, true))
            {
                var productos = m.Productos.Where(p => (p.Descripcion ?? "").IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0
                    || (p.Codigo ?? "").IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0).Take(21).ToList();
                return new
                {
                    hayMas = productos.Count > 20,
                    productos = productos.Take(20).Select(p =>
                    {
                        var d = new ComprobantesVentasDetalle();
                        using (var detalle = new ComprobantesVentasDetalleManager(d, 0, cliente, true))
                        {
                            d.Id_Producto = p.Id;
                            d.AlicuotaIva = detalle.Alicuotas.Single(a => a.Key == d.Id_AlicuotaIva).Name;
                            return new { id = p.Id, codigo = p.Codigo, nombre = p.Descripcion, precio = d.ImporteUnitario,
                                descuento = d.PorcDescuento, iva = d.AlicuotaIva, moneda = ComprobantesVentasManager.GetEspecie(d.Id_Especie),
                                cantidadStock = d.Visible_Cantidad_Stock && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaDistintaUnidadStock)) };
                        }
                    }).ToList()
                };
            }
        }

        [HttpGet("monedas")]
        public object Monedas()
        {
            AccesoConsulta("cuenta");
            return Sistema.Especies.Select(e => new { key = e.Key, name = e.Name });
        }

        [HttpGet("cuenta")]
        public object Cuenta(int entidad, int moneda, DateTime desde, DateTime hasta, int tipo = (int)Enums.TipoEntidad.Cliente)
        {
            AccesoConsulta("cuenta");
            var tipoEntidad = Tipo(tipo);
            PortalVentas.Entidad(tipoEntidad, entidad);
            if (!Sistema.Especies.Any(e => e.Key == moneda)) throw new ApiException(403, "Moneda no habilitada.");
            if (desde.Year < 1753 || hasta.Year >= 9999 || desde > hasta || hasta.Subtract(desde).TotalDays > 366)
                throw new ValidationException("Consulte un periodo de hasta un año con fechas validas.");
            var filas = EntidadesCtaCteManager.Buscar(new EntidadesCtaCteManager.ParametrosBusquedas
            {
                Id_TipoEntidad = tipoEntidad, Id_Entidad = entidad, Id_Especie = moneda,
                FechaDesde = desde.Date, FechaHasta = hasta.Date.AddDays(1).AddTicks(-1)
            });
            return new { saldo = filas.LastOrDefault()?.Saldo ?? 0, saldoAnterior = filas.FirstOrDefault()?.Saldo ?? 0,
                movimientos = filas.Where(f => f.Id > 0).Select(f => new { id = f.Id, fecha = f.Fecha, concepto = f.Concepto,
                    movimiento = f.Movimiento, debito = f.Debito, credito = f.Credito, saldo = f.Saldo }).ToList() };
        }

        [HttpGet("comprobante")]
        public object Comprobante(int movimiento, int entidad, int moneda, int tipo = (int)Enums.TipoEntidad.Cliente)
        {
            AccesoConsulta("cuenta");
            var tipoEntidad = Tipo(tipo);
            PortalVentas.Entidad(tipoEntidad, entidad);
            if (!Sistema.Especies.Any(e => e.Key == moneda)) throw new ApiException(403, "Moneda no habilitada.");
            using (var db = new TesoreriaContext())
                if (!db.EntidadesCtaCte.Any(m => m.Id == movimiento && m.Id_Entidad == entidad
                    && m.Id_TipoEntidad == tipoEntidad && m.Id_Especie == moneda && m.UserDel == null))
                    throw new ApiException(404, "El movimiento no pertenece a la entidad y moneda seleccionadas.");
            return _acciones.Ejecutar("EntidadesCtaCte", "comprobante", new System.Collections.Generic.List<int> { movimiento }, null);
        }

        [HttpPost("revisar")]
        public object Revisar([FromBody] VentaMovil venta) => _ventas.Revisar(venta);

        public class Confirmacion { public string Token { get; set; } }
        [HttpPost("guardar")]
        public object Guardar([FromBody] Confirmacion confirmacion) => _ventas.Guardar(confirmacion?.Token);
    }
}
