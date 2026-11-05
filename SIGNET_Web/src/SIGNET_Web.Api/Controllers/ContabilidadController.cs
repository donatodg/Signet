using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VENET_Common;
using VENET_Comun;
using VENET_Contabilidad_BL;
using VENET_DataEntity;
using SIGNET_Web.Api.Infrastructure;

namespace SIGNET_Web.Api.Controllers
{
    [ApiController]
    [Route("api/contabilidad")]
    public sealed partial class ContabilidadController : ControllerBase
    {
        private readonly ContabilidadService _service = new ContabilidadService();
        private static bool Puede(string pantalla, params Enums.Accion[] acciones) =>
            acciones.All(a => Seguridad.TienePermiso(Enums.Modulos.Gestion, pantalla, a));
        private static void Exigir(string pantalla, Enums.Accion accion)
        {
            SignetRequestContext.RequireSession();
            if (!Seguridad.TienePermiso(Enums.Modulos.Gestion, pantalla, Enums.Accion.Ingresar)
                || !Seguridad.TienePermiso(Enums.Modulos.Gestion, pantalla, accion))
                throw new ApiException(403, "Sin permiso para " + pantalla + ".");
        }
        private static void Empresa(int empresa)
        {
            if (!Sistema.Empresas.Any(e => e.Key == empresa)) throw new ApiException(403, "Empresa no habilitada para su usuario.");
        }
        private static void Origen(OperatoriaContable op)
        {
            string pantalla;
            Enums.Modulos modulo;
            switch (op)
            {
                case OperatoriaContable.Venta: pantalla = "ComprobantesVentas"; modulo = Enums.Modulos.Gestion; break;
                case OperatoriaContable.CostoVentaAutomatico: pantalla = "ComprobantesVentas"; modulo = Enums.Modulos.Gestion; break;
                case OperatoriaContable.Compra: pantalla = "ComprobantesCompras"; modulo = Enums.Modulos.Gestion; break;
                case OperatoriaContable.Cobranza: pantalla = "Recibos"; modulo = Enums.Modulos.Tesoreria; break;
                case OperatoriaContable.Pago: pantalla = "OrdenesPago"; modulo = Enums.Modulos.Tesoreria; break;
                case OperatoriaContable.TransferenciaFondos: pantalla = "Transferencias"; modulo = Enums.Modulos.Tesoreria; break;
                case OperatoriaContable.CostoVenta:
                case OperatoriaContable.MovimientoStock:
                case OperatoriaContable.LiquidacionSueldos:
                case OperatoriaContable.Devengamiento:
                case OperatoriaContable.Ajuste:
                case OperatoriaContable.Apertura:
                case OperatoriaContable.Cierre: return;
                default: throw new ValidationException("Operatoria sin adaptador de gestion habilitado.");
            }
            if (!Seguridad.TienePermiso(modulo, pantalla, Enums.Accion.Ingresar)
                || !Seguridad.TienePermiso(modulo, pantalla, Enums.Accion.Buscar))
                throw new ApiException(403, "Sin permiso de consulta sobre el documento original.");
        }
        [HttpGet("estado")]
        public object Estado()
        {
            SignetRequestContext.RequireSession();
            return new
            {
                ingresar = Puede("ContabilidadConfiguracion", Enums.Accion.Ingresar)
                    || Puede("ContabilidadRegistracion", Enums.Accion.Ingresar)
                    || Puede("ContabilidadDiario", Enums.Accion.Ingresar)
                    || Puede("ContabilidadBandeja", Enums.Accion.Ingresar)
                    || Puede("ContabilidadAutomatizacion", Enums.Accion.Ingresar)
                    || Puede("ContabilidadPeriodos", Enums.Accion.Ingresar)
                    || Puede("ContabilidadConciliacion", Enums.Accion.Ingresar)
                    || Puede("ContabilidadAprobacion", Enums.Accion.Ingresar),
                configurar = Puede("ContabilidadConfiguracion", Enums.Accion.Ingresar, Enums.Accion.Buscar),
                editar = Puede("ContabilidadConfiguracion", Enums.Accion.Ingresar, Enums.Accion.Modificar),
                simular = Puede("ContabilidadRegistracion", Enums.Accion.Ingresar, Enums.Accion.Buscar),
                registrar = Puede("ContabilidadRegistracion", Enums.Accion.Ingresar, Enums.Accion.Agregar),
                diario = Puede("ContabilidadDiario", Enums.Accion.Ingresar, Enums.Accion.Buscar),
                revertir = Puede("ContabilidadDiario", Enums.Accion.Ingresar, Enums.Accion.Eliminar),
                bandeja = Puede("ContabilidadBandeja", Enums.Accion.Ingresar, Enums.Accion.Buscar)
                    || Puede("ContabilidadAprobacion", Enums.Accion.Ingresar, Enums.Accion.Modificar),
                registrarBandeja = Puede("ContabilidadBandeja", Enums.Accion.Ingresar, Enums.Accion.Agregar),
                aprobar = Puede("ContabilidadAprobacion", Enums.Accion.Ingresar, Enums.Accion.Modificar),
                automatizacion = Puede("ContabilidadAutomatizacion", Enums.Accion.Ingresar, Enums.Accion.Buscar),
                editarAutomatizacion = Puede("ContabilidadAutomatizacion", Enums.Accion.Ingresar, Enums.Accion.Modificar),
                periodos = Puede("ContabilidadPeriodos", Enums.Accion.Ingresar, Enums.Accion.Buscar),
                bloquearPeriodos = Puede("ContabilidadPeriodos", Enums.Accion.Ingresar, Enums.Accion.Modificar),
                reabrirPeriodos = Puede("ContabilidadPeriodos", Enums.Accion.Ingresar) && Seguridad.TienePermiso(Enums.Modulos.Gestion, "ContabilidadPeriodos", Enums.Accion.Operaciones, "Reabrir"),
                conciliar = Puede("ContabilidadConciliacion", Enums.Accion.Ingresar, Enums.Accion.Buscar),
                exportar = Puede("ContabilidadConciliacion", Enums.Accion.Ingresar, Enums.Accion.Imprimir),
                empresas = Sistema.Empresas
            };
        }
        [HttpGet("catalogos")]
        public object Catalogos(int empresa)
        {
            SignetRequestContext.RequireSession();
            if (!Puede("ContabilidadConfiguracion", Enums.Accion.Ingresar, Enums.Accion.Buscar)
                && !Puede("ContabilidadRegistracion", Enums.Accion.Ingresar, Enums.Accion.Buscar)
                && !Puede("ContabilidadDiario", Enums.Accion.Ingresar, Enums.Accion.Buscar)
                && !Puede("ContabilidadBandeja", Enums.Accion.Ingresar, Enums.Accion.Buscar)
                && !Puede("ContabilidadAutomatizacion", Enums.Accion.Ingresar, Enums.Accion.Buscar)
                && !Puede("ContabilidadPeriodos", Enums.Accion.Ingresar, Enums.Accion.Buscar)
                && !Puede("ContabilidadConciliacion", Enums.Accion.Ingresar, Enums.Accion.Buscar)
                && !Puede("ContabilidadAprobacion", Enums.Accion.Ingresar, Enums.Accion.Modificar))
                throw new ApiException(403, "Sin permisos contables.");
            Empresa(empresa);
            using (var db = new GestionContext())
                return new
                {
                    cuentas = db.CuentasContables.Where(c => c.UserDel == null && c.Subcuenta != "000000")
                        .OrderBy(c => c.Titulo).ThenBy(c => c.Capitulo).ThenBy(c => c.Rubro).ThenBy(c => c.Cuenta).ThenBy(c => c.Subcuenta)
                        .Select(c => new { key = c.Id, name = c.Titulo + "." + c.Capitulo + "." + c.Rubro + "." + c.Cuenta + "." + c.Subcuenta + " - " + c.Descripcion }).ToList(),
                    monedas = Sistema.Especies.Select(e => new { key = e.Key, name = e.Name }),
                    cajas = db.Cajas.Where(c => c.UserDel == null && db.Sucursales.Any(s => s.Id == c.Id_Sucursal && s.Id_Empresa == empresa))
                        .Select(c => new { key = c.Id, name = c.Descripcion }).ToList(),
                    sucursales = Sistema.Sucursales.Where(s => db.Sucursales.Any(x => x.Id == s.Id_Sucursal && x.Id_Empresa == empresa))
                        .Select(s => new { key = s.Id_Sucursal, name = s.Sucursal }).ToList(),
                    comprobantes = db.TipoComprobante.Where(t => t.UserDel == null).Select(t => new { key = t.Id, name = t.Descripcion }).ToList(),
                    ejercicios = db.EjerciciosContables.Where(t => t.Id_Empresa == empresa && t.UserDel == null)
                        .OrderByDescending(t => t.VigenciaDesde).Select(t => new { key = t.Id, name = t.Descripcion + (t.Cerrado ? " (cerrado)" : " (abierto)") }).ToList(),
                    operatorias = Opciones<OperatoriaContable>(),
                    origenes = Opciones<OrigenContable>(),
                    magnitudes = Opciones<MagnitudContable>(),
                    lados = Opciones<LadoContable>(),
                    dimensiones = Opciones<DimensionCuenta>(),
                    medios = Opciones<MedioTesoreria>()
                };
        }
        private static object Opciones<T>() => Enum.GetValues(typeof(T)).Cast<object>().Select(v => new { key = Convert.ToInt32(v), name = v.ToString() }).ToList();
        [HttpGet("referencias")]
        public object Referencias(int empresa, DimensionCuenta dimension, string buscar = "", int? id = null)
        {
            Exigir("ContabilidadConfiguracion", Enums.Accion.Buscar); Empresa(empresa);
            if ((buscar ?? "").Length > 100) throw new ValidationException("La busqueda admite hasta 100 caracteres.");
            System.Collections.Generic.IEnumerable<KeyNamePair> opciones;
            using (var db = new GestionContext())
            {
                var texto = (buscar ?? "").Trim();
                switch (dimension)
                {
                    case DimensionCuenta.Empresa: opciones = Sistema.Empresas.Where(e => e.Key == empresa); break;
                    case DimensionCuenta.Cliente: opciones = Sistema.ObtenerEntidades(Enums.TipoEntidad.Cliente); break;
                    case DimensionCuenta.Proveedor: opciones = Sistema.ObtenerEntidades(Enums.TipoEntidad.Proveedor); break;
                    case DimensionCuenta.FormaPago: opciones = Sistema.FormasPagos; break;
                    case DimensionCuenta.Especie: opciones = Sistema.Especies.Select(e => new KeyNamePair { Key = e.Key, Name = e.Name }); break;
                    case DimensionCuenta.MedioTesoreria:
                        opciones = Enum.GetValues(typeof(MedioTesoreria)).Cast<MedioTesoreria>().Select(m => new KeyNamePair { Key = (int)m, Name = m.ToString() }); break;
                    case DimensionCuenta.Componente:
                        opciones = Enum.GetValues(typeof(ComponenteContable)).Cast<ComponenteContable>().Select(m => new KeyNamePair { Key = (int)m, Name = m.ToString() }); break;
                    case DimensionCuenta.Caja:
                        opciones = db.Cajas.Where(p => p.UserDel == null && db.Sucursales.Any(s => s.Id == p.Id_Sucursal && s.Id_Empresa == empresa))
                            .Select(p => new KeyNamePair { Key = p.Id, Name = p.Descripcion }).ToList(); break;
                    case DimensionCuenta.Personal:
                        opciones = db.Personal.Where(p => p.UserDel == null).Select(p => new KeyNamePair { Key = p.Id, Name = p.Apellido + ", " + p.Nombre }).ToList(); break;
                    case DimensionCuenta.Concepto:
                        throw new ValidationException("Los conceptos son codigos contables definidos por la empresa. Ingrese el codigo en la asignacion.");
                    case DimensionCuenta.CuentaOrigen:
                        throw new ValidationException("CuentaOrigen resuelve directamente la cuenta del saldo; no admite asignaciones.");
                    case DimensionCuenta.Producto:
                        opciones = db.Productos.Where(p => p.UserDel == null && (id.HasValue ? p.Id == id : p.Descripcion.Contains(texto) || p.Codigo.Contains(texto)))
                            .OrderBy(p => p.Descripcion).Take(50).Select(p => new KeyNamePair { Key = p.Id, Name = p.Codigo + " - " + p.Descripcion }).ToList(); break;
                    case DimensionCuenta.Categoria:
                        opciones = db.ProductosCategorias.Where(p => p.UserDel == null).Select(p => new KeyNamePair { Key = p.Id, Name = p.Descripcion }).ToList(); break;
                    case DimensionCuenta.Impuesto:
                        opciones = db.TipoImpuestos.Where(p => p.UserDel == null).Select(p => new KeyNamePair { Key = p.Id, Name = p.Descripcion }).ToList(); break;
                    default: throw new ValidationException("Dimension no valida.");
                }
                return opciones.Where(o => id.HasValue ? o.Key == id : (o.Name ?? "").IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0).Take(50).ToList();
            }
        }
        [HttpGet("configuracion")]
        public object Configuracion(int empresa)
        {
            Exigir("ContabilidadConfiguracion", Enums.Accion.Buscar); Empresa(empresa);
            return _service.Configuracion(empresa);
        }
        [HttpPost("configuracion")]
        public object Guardar([FromBody] ConfiguracionContable config)
        {
            Exigir("ContabilidadConfiguracion", Enums.Accion.Modificar);
            if (config == null) throw new ValidationException("Falta la configuracion.");
            Empresa(config.Empresa);
            if (config.Plantillas != null && config.Plantillas.Any(p => p?.Sucursal.HasValue == true && !Sistema.Sucursales.Any(s => s.Id_Sucursal == p.Sucursal)))
                throw new ApiException(403, "Una sucursal de la configuracion no esta habilitada.");
            return _service.GuardarConfiguracion(config, SignetRequestContext.RequireSession().UserId);
        }
        public sealed class SolicitudContable
        {
            public int Empresa { get; set; }
            public OperatoriaContable Operatoria { get; set; }
            public int Documento { get; set; }
            public string Firma { get; set; }
        }
        [HttpGet("documentos")]
        public object Documentos(int empresa, OperatoriaContable operatoria, string buscar = "")
        {
            Exigir("ContabilidadRegistracion", Enums.Accion.Buscar); Empresa(empresa); Origen(operatoria);
            var texto = (buscar ?? "").Trim();
            if (texto.Length > 100) throw new ValidationException("La busqueda admite hasta 100 caracteres.");
            if (ContabilidadService.Complementario(operatoria))
                return _service.Documentos(empresa, operatoria, texto).Where(d => Sistema.Sucursales.Any(s => s.Id_Sucursal == d.Hecho.Sucursal))
                    .Select(d => new { key = d.Id, name = "#" + d.Id + " / " + d.Hecho.Descripcion + " / " + d.Respaldo }).ToList();
            using (var db = new GestionContext())
            {
                var permitidas = Sistema.Sucursales.Select(s => s.Id_Sucursal).ToList();
                var sucursales = db.Sucursales.Where(s => s.Id_Empresa == empresa && s.UserDel == null && permitidas.Contains(s.Id)).Select(s => s.Id).ToList();
                if (operatoria == OperatoriaContable.Venta || operatoria == OperatoriaContable.CostoVentaAutomatico)
                    return db.ComprobantesVentas.Where(c => c.UserDel == null && c.FechaLiquidacion != null && c.FechaAnulacion == null
                        && sucursales.Contains(c.Id_Sucursal) && c.Id_TipoEntidad == Enums.TipoEntidad.Cliente
                        && (c.NroComprobante.Contains(texto) || c.Observaciones.Contains(texto)))
                        .OrderByDescending(c => c.Fecha).ThenByDescending(c => c.Id).Take(30)
                        .Select(c => new { key = c.Id, name = c.Letra + "-" + c.PuntoVenta + "-" + c.NroComprobante + " / " + c.Observaciones }).ToList();
                if (operatoria == OperatoriaContable.Compra)
                    return db.ComprobantesCompras.Where(c => c.UserDel == null && c.FechaLiquidacion != null && c.FechaAnulacion == null
                        && sucursales.Contains(c.Id_Sucursal) && c.Id_TipoEntidad == Enums.TipoEntidad.Proveedor
                        && (c.NroComprobante.Contains(texto) || c.Observaciones.Contains(texto)))
                        .OrderByDescending(c => c.Fecha).ThenByDescending(c => c.Id).Take(30)
                        .Select(c => new { key = c.Id, name = c.Letra + "-" + c.PuntoVenta + "-" + c.NroComprobante + " / " + c.Observaciones }).ToList();
                using (var tesoreria = new TesoreriaContext())
                {
                    if (operatoria == OperatoriaContable.TransferenciaFondos)
                        return tesoreria.Transferencias.Where(t => t.UserDel == null && t.Descripcion.Contains(texto)
                            && tesoreria.Cajas.Any(c => c.Id == t.Id_Caja_Origen && sucursales.Contains(c.Id_Sucursal))
                            && tesoreria.Cajas.Any(c => c.Id == t.Id_Caja_Destino && sucursales.Contains(c.Id_Sucursal)))
                            .OrderByDescending(t => t.Id).Take(30).Select(t => new { key = t.Id, name = "#" + t.Id + " / " + t.Descripcion }).ToList();
                    if (operatoria == OperatoriaContable.Cobranza)
                        return tesoreria.Recibos.Where(c => c.UserDel == null && c.Fecha_Liquidacion != null && c.Fecha_Anulacion == null
                            && sucursales.Contains(c.Id_Sucursal) && c.TipoEntidad == Enums.TipoEntidad.Cliente
                            && (c.NroComprobante.Contains(texto) || c.Concepto.Contains(texto)))
                            .OrderByDescending(c => c.Fecha).ThenByDescending(c => c.Id).Take(30)
                            .Select(c => new { key = c.Id, name = c.Letra + "-" + c.PuntoVenta + "-" + c.NroComprobante + " / " + c.Concepto }).ToList();
                    return tesoreria.OrdenesPago.Where(c => c.UserDel == null && c.Fecha_Liquidacion != null && c.Fecha_Anulacion == null
                        && sucursales.Contains(c.Id_Sucursal) && c.TipoEntidad == Enums.TipoEntidad.Proveedor
                        && (c.NroComprobante.Contains(texto) || c.Concepto.Contains(texto)))
                        .OrderByDescending(c => c.Fecha).ThenByDescending(c => c.Id).Take(30)
                        .Select(c => new { key = c.Id, name = c.Letra + "-" + c.PuntoVenta + "-" + c.NroComprobante + " / " + c.Concepto }).ToList();
                }
            }
        }
        private void Validar(SolicitudContable s)
        {
            if (s == null || s.Documento <= 0) throw new ValidationException("Indique un documento.");
            Empresa(s.Empresa); Origen(s.Operatoria);
            var h = ContabilidadService.Complementario(s.Operatoria)
                ? _service.CabeceraDocumento(s.Empresa, s.Operatoria, s.Documento)
                : OrigenGestion.Obtener(s.Operatoria == OperatoriaContable.CostoVentaAutomatico ? OperatoriaContable.Venta : s.Operatoria, s.Documento);
            if (h.Empresa != s.Empresa || !Sistema.Sucursales.Any(x => x.Id_Sucursal == h.Sucursal))
                throw new ApiException(403, "Documento fuera de las empresas o sucursales habilitadas.");
            if (s.Operatoria == OperatoriaContable.TransferenciaFondos)
                using (var db = new GestionContext())
                {
                    var permitidas = Sistema.Sucursales.Select(x => x.Id_Sucursal).ToList();
                    foreach (var p in h.Partidas)
                        if (!db.Cajas.Any(c => c.Id == p.Caja && permitidas.Contains(c.Id_Sucursal)))
                            throw new ApiException(403, "Una caja de la transferencia pertenece a una sucursal no habilitada.");
                }
        }
        [HttpPost("simular")]
        public object Simular([FromBody] SolicitudContable solicitud)
        {
            Exigir("ContabilidadRegistracion", Enums.Accion.Buscar); Validar(solicitud);
            var sim = _service.Simular(solicitud.Empresa, solicitud.Operatoria, solicitud.Documento);
            if (!Sistema.Sucursales.Any(s => s.Id_Sucursal == sim.Hecho.Sucursal)) throw new ApiException(403, "Sucursal no habilitada.");
            return sim;
        }
        [HttpPost("registrar")]
        public object Registrar([FromBody] SolicitudContable solicitud)
        {
            Exigir("ContabilidadRegistracion", Enums.Accion.Agregar); Validar(solicitud);
            return _service.Registrar(solicitud.Empresa, solicitud.Operatoria, solicitud.Documento, solicitud.Firma, SignetRequestContext.RequireSession().UserId);
        }
        [HttpPost("complementarios")]
        public object CrearDocumento([FromBody] DocumentoContable documento)
        {
            Exigir("ContabilidadRegistracion", Enums.Accion.Agregar);
            if (documento?.Hecho == null) throw new ValidationException("Falta el documento.");
            Empresa(documento.Hecho.Empresa);
            if (!Sistema.Sucursales.Any(s => s.Id_Sucursal == documento.Hecho.Sucursal)) throw new ApiException(403, "Sucursal no habilitada.");
            return _service.CrearDocumento(documento, SignetRequestContext.RequireSession().UserId);
        }
        public sealed class SolicitudEjercicio
        {
            public int Empresa { get; set; }
            public int Ejercicio { get; set; }
            public OperatoriaContable Operatoria { get; set; }
            public int Sucursal { get; set; }
            public DateTime Fecha { get; set; }
            public Guid Clave { get; set; }
        }
        [HttpPost("ejercicio")]
        public object PrepararEjercicio([FromBody] SolicitudEjercicio s)
        {
            Exigir("ContabilidadRegistracion", Enums.Accion.Agregar);
            if (s == null) throw new ValidationException("Falta la solicitud.");
            Empresa(s.Empresa);
            if (!Sistema.Sucursales.Any(x => x.Id_Sucursal == s.Sucursal)) throw new ApiException(403, "Sucursal no habilitada.");
            return _service.PrepararEjercicio(s.Empresa, s.Ejercicio, s.Operatoria, s.Sucursal, s.Fecha, s.Clave, SignetRequestContext.RequireSession().UserId);
        }
        [HttpGet("saldos")]
        public object Saldos(int empresa, int moneda, DateTime desde, DateTime hasta)
        {
            Exigir("ContabilidadDiario", Enums.Accion.Buscar); Empresa(empresa);
            return _service.Saldos(empresa, moneda, desde, hasta);
        }
        [HttpGet("mayor")]
        public object Mayor(int empresa, int moneda, int cuenta, DateTime desde, DateTime hasta)
        {
            Exigir("ContabilidadDiario", Enums.Accion.Buscar); Empresa(empresa);
            return _service.Mayor(empresa, moneda, cuenta, desde, hasta);
        }
        [HttpGet("diario")]
        public object Diario(int empresa, DateTime desde, DateTime hasta)
        {
            Exigir("ContabilidadDiario", Enums.Accion.Buscar); Empresa(empresa);
            return _service.Diario(empresa, desde, hasta);
        }
        public sealed class ReversionContable
        {
            public int Empresa { get; set; }
            public int Lote { get; set; }
            public DateTime Fecha { get; set; }
            public string Motivo { get; set; }
        }
        [HttpPost("revertir")]
        public object Revertir([FromBody] ReversionContable r)
        {
            Exigir("ContabilidadDiario", Enums.Accion.Eliminar);
            if (r == null) throw new ValidationException("Falta la reversion.");
            Empresa(r.Empresa);
            return _service.Revertir(r.Empresa, r.Lote, r.Fecha, r.Motivo, SignetRequestContext.RequireSession().UserId);
        }
    }
}
