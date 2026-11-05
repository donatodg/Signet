using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;
using VENET_Contabilidad_BL;
using VENET_Contabilidad_UI;

namespace SIGNET_Web.Api.Controllers
{
    public sealed partial class ContabilidadController
    {
        private int UsuarioActual => SignetRequestContext.RequireSession().UserId;
        private List<int> SucursalesActuales => Sistema.Sucursales.Select(s => s.Id_Sucursal).Distinct().ToList();
        private static void ExigirRevision()
        {
            SignetRequestContext.RequireSession();
            if (!Puede("ContabilidadBandeja", Enums.Accion.Ingresar, Enums.Accion.Buscar)
                && !Puede("ContabilidadAprobacion", Enums.Accion.Ingresar, Enums.Accion.Modificar))
                throw new ApiException(403, "Sin permiso para consultar y revisar la bandeja.");
        }
        [HttpGet("bandeja")]
        public object Bandeja(int empresa, DateTime desde, DateTime hasta)
        {
            ExigirRevision(); Empresa(empresa);
            return _service.Bandeja(empresa, desde, hasta, SucursalesActuales);
        }
        public sealed class PeriodoSolicitud
        {
            public int Empresa { get; set; }
            public DateTime Desde { get; set; }
            public DateTime Hasta { get; set; }
        }
        [HttpPost("bandeja/sincronizar")]
        public object Sincronizar([FromBody] PeriodoSolicitud s)
        {
            Exigir("ContabilidadBandeja", Enums.Accion.Agregar);
            if (s == null) throw new ValidationException("Falta el periodo.");
            Empresa(s.Empresa);
            return new { cantidad = _service.SincronizarBandeja(s.Empresa, s.Desde, s.Hasta, UsuarioActual, SucursalesActuales) };
        }
        public sealed class LoteSolicitud
        {
            public int Empresa { get; set; }
            public List<RevisionLote> Documentos { get; set; }
        }
        private void ValidarLote(LoteSolicitud s)
        {
            if (s == null) throw new ValidationException("Falta la seleccion.");
            Empresa(s.Empresa); ContabilidadService.ValidarSeleccion(s.Documentos);
            foreach (var d in s.Documentos) Validar(new SolicitudContable { Empresa = s.Empresa, Operatoria = d.Operatoria, Documento = d.Documento });
        }
        [HttpPost("bandeja/revisar")]
        public object RevisarBandeja([FromBody] LoteSolicitud s)
        {
            ExigirRevision(); ValidarLote(s);
            return _service.RevisarLote(s.Empresa, s.Documentos);
        }
        [HttpPost("bandeja/registrar")]
        public object RegistrarBandeja([FromBody] LoteSolicitud s)
        {
            Exigir("ContabilidadBandeja", Enums.Accion.Agregar); ValidarLote(s);
            return _service.RegistrarLote(s.Empresa, s.Documentos, UsuarioActual);
        }
        public sealed class AprobacionSolicitud : SolicitudBase
        {
            public OperatoriaContable Operatoria { get; set; }
            public int Documento { get; set; }
            public string Firma { get; set; }
        }
        public class SolicitudBase
        {
            public int Empresa { get; set; }
            public string Motivo { get; set; }
        }
        [HttpPost("aprobar")]
        public object Aprobar([FromBody] AprobacionSolicitud s)
        {
            Exigir("ContabilidadAprobacion", Enums.Accion.Modificar);
            if (s == null) throw new ValidationException("Falta la revision.");
            Validar(new SolicitudContable { Empresa = s.Empresa, Operatoria = s.Operatoria, Documento = s.Documento });
            _service.Aprobar(s.Empresa, s.Operatoria, s.Documento, s.Firma, s.Motivo, UsuarioActual);
            return new { aprobado = true };
        }
        [HttpPost("bandeja/{id:int}/reintentar")]
        public object Reintentar(int id, [FromBody] SolicitudBase s)
        {
            Exigir("ContabilidadBandeja", Enums.Accion.Agregar);
            if (s == null) throw new ValidationException("Falta empresa.");
            Empresa(s.Empresa); _service.Reintentar(s.Empresa, id, UsuarioActual, SucursalesActuales); return new { solicitado = true };
        }
        [HttpGet("operativa")]
        public object Operativa(int empresa)
        {
            Exigir("ContabilidadAutomatizacion", Enums.Accion.Buscar); Empresa(empresa); return _service.Operativa(empresa);
        }
        [HttpGet("usuarios-automaticos")]
        public object UsuariosAutomaticos()
        {
            Exigir("ContabilidadAutomatizacion", Enums.Accion.Buscar);
            return _service.UsuariosAutomaticos(UsuarioActual);
        }
        public sealed class OperativaSolicitud : SolicitudBase
        {
            public OperativaContable Configuracion { get; set; }
        }
        [HttpPost("operativa")]
        public object GuardarOperativa([FromBody] OperativaSolicitud s)
        {
            Exigir("ContabilidadAutomatizacion", Enums.Accion.Modificar);
            if (s?.Configuracion == null || s.Empresa != s.Configuracion.Empresa) throw new ValidationException("Falta la configuracion.");
            Empresa(s.Empresa); return _service.GuardarOperativa(s.Configuracion, UsuarioActual, s.Motivo);
        }
        [HttpPost("procesar")]
        public object Procesar([FromBody] SolicitudBase s)
        {
            Exigir("ContabilidadAutomatizacion", Enums.Accion.Modificar);
            if (s == null) throw new ValidationException("Falta empresa.");
            Empresa(s.Empresa); return new { procesados = _service.ProcesarCola(s.Empresa) };
        }
        [HttpGet("costos")]
        public object Costos(int empresa, int venta)
        {
            ExigirRevision();
            Validar(new SolicitudContable { Empresa = empresa, Operatoria = OperatoriaContable.Venta, Documento = venta });
            return _service.Costos(empresa, venta);
        }
        [HttpGet("periodos")]
        public object Periodos(int empresa)
        {
            Exigir("ContabilidadPeriodos", Enums.Accion.Buscar); Empresa(empresa); return _service.Periodos(empresa);
        }
        public sealed class BloqueoSolicitud : SolicitudBase
        {
            public DateTime Mes { get; set; }
            public bool Cerrar { get; set; }
        }
        [HttpPost("periodos")]
        public object BloquearPeriodo([FromBody] BloqueoSolicitud s)
        {
            SignetRequestContext.RequireSession();
            if (s == null) throw new ValidationException("Falta el periodo.");
            if (s.Cerrar) Exigir("ContabilidadPeriodos", Enums.Accion.Modificar);
            else if (!Puede("ContabilidadPeriodos", Enums.Accion.Ingresar)
                || !Seguridad.TienePermiso(Enums.Modulos.Gestion, "ContabilidadPeriodos", Enums.Accion.Operaciones, "Reabrir"))
                throw new ApiException(403, "Sin permiso de reapertura excepcional.");
            Empresa(s.Empresa); _service.CambiarPeriodo(s.Empresa, s.Mes, s.Cerrar, s.Motivo, UsuarioActual); return new { actualizado = true };
        }
        [HttpGet("clasificacion")]
        public object Clasificacion(int empresa)
        {
            Exigir("ContabilidadConfiguracion", Enums.Accion.Buscar); Empresa(empresa);
            return new { cuentas = _service.Clasificaciones(empresa), cajas = _service.CajasContables(empresa) };
        }
        public sealed class ClasificacionSolicitud : SolicitudBase
        {
            public List<ClasificacionCuenta> Cuentas { get; set; }
            public List<VinculoCaja> Cajas { get; set; }
        }
        [HttpPost("clasificacion")]
        public object GuardarClasificacion([FromBody] ClasificacionSolicitud s)
        {
            Exigir("ContabilidadConfiguracion", Enums.Accion.Modificar);
            if (s == null) throw new ValidationException("Falta clasificacion.");
            Empresa(s.Empresa); _service.GuardarClasificaciones(s.Empresa, s.Cuentas, s.Cajas, s.Motivo, UsuarioActual); return new { guardado = true };
        }
        [HttpGet("conciliacion")]
        public object Conciliacion(int empresa, int moneda, DateTime desde, DateTime hasta, string tipo)
        {
            Exigir("ContabilidadConciliacion", Enums.Accion.Buscar); Empresa(empresa);
            return DatosInforme(empresa, moneda, desde, hasta, tipo);
        }
        private IEnumerable DatosInforme(int empresa, int moneda, DateTime desde, DateTime hasta, string tipo)
        {
            switch (tipo)
            {
                case "documentos": return _service.ConciliarDocumentos(empresa, desde, hasta, SucursalesActuales);
                case "cajas": return _service.ConciliarCajas(empresa, moneda, desde, hasta, SucursalesActuales);
                case "balance": return _service.InformeBalance(empresa, moneda, desde, hasta);
                case "saldos": return _service.Saldos(empresa, moneda, desde, hasta);
                default: throw new ValidationException("Informe desconocido.");
            }
        }
        [HttpGet("exportar")]
        public object Exportar(int empresa, int moneda, DateTime desde, DateTime hasta, string tipo, string formato)
        {
            Exigir("ContabilidadConciliacion", Enums.Accion.Imprimir);
            Exigir("ContabilidadConciliacion", Enums.Accion.Buscar); Empresa(empresa);
            var bytes = InformeContable.Exportar("SIGNET - " + tipo + " - Empresa " + empresa + " - " + desde.ToString("yyyy-MM-dd") + " / " + hasta.ToString("yyyy-MM-dd"),
                DatosInforme(empresa, moneda, desde, hasta, tipo), formato);
            return new
            {
                nombre = "contabilidad-" + tipo + "." + formato,
                contentType = formato == "pdf" ? "application/pdf" : "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                base64 = Convert.ToBase64String(bytes)
            };
        }
        [HttpGet("auditoria")]
        public object Auditoria(int empresa)
        {
            Exigir("ContabilidadPeriodos", Enums.Accion.Buscar); Empresa(empresa); return _service.Auditoria(empresa);
        }
    }
}
