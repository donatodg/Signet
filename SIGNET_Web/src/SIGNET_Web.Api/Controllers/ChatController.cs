using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIGNET_Web.Api.Chat;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_IA_BL;
using System.Linq;
using SIGNET_Web.Api.Screens;

namespace SIGNET_Web.Api.Controllers
{
    /// <summary>
    /// Asistente de datos (IA). Configuración en los parámetros del sistema IA_* (clave, modelo, tope mensual...).
    /// Acceso: menú Menu_Sistema_AsistenteIA habilitado + permiso Sistema / AsistenteIA / Ingresar del grupo del usuario
    /// (los administradores siempre tienen acceso), igual que en el sistema de escritorio.
    /// </summary>
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chat;

        public ChatController(ChatService chat) { _chat = chat; }

        // El login de desarrollo (1/1) ve siempre el asistente, aunque no haya conexión con la base.
        private static bool Permitido() =>
            Seguridad.EsDesarrollo || (AsistenteIASeguridad.MenuHabilitado() && AsistenteIASeguridad.TienePermiso());

        [HttpGet]
        public object Estado()
        {
            SignetRequestContext.RequireSession();
            var habilitado = _chat.Opciones.Habilitado;
            if (!habilitado || !Permitido())
                return new { habilitado, permitido = false, configurado = false, modelo = (string)null, tokensMes = 0L, limiteMes = 0L };

            AsistenteIAConfiguracion c;
            long tokensMes;
            try
            {
                c = _chat.Configuracion();
                tokensMes = c.TokensDelMes();
            }
            catch when (Seguridad.EsDesarrollo)
            {
                return new { habilitado, permitido = true, configurado = false, modelo = (string)null, tokensMes = 0L, limiteMes = 0L };
            }
            return new
            {
                habilitado,
                permitido = true,
                configurado = c.Configurado,
                modelo = c.Modelo,
                tokensMes = tokensMes,
                limiteMes = c.LimiteTokensMes
            };
        }

        public class PreguntaRequest
        {
            public string Pregunta { get; set; }
            public List<AsistenteIAMensaje> Historial { get; set; }
            public AsistenteIAVentaSolicitud VentaAnterior { get; set; }
        }

        [HttpPost]
        public async Task<AsistenteIARespuesta> Preguntar([FromBody] PreguntaRequest req)
        {
            var s = SignetRequestContext.RequireSession();
            if (!_chat.Opciones.Habilitado) throw new ApiException(404, "El asistente de datos no está habilitado.");
            if (!Permitido()) throw new ApiException(403, "Su usuario no tiene acceso al asistente de datos (permiso AsistenteIA / Ingresar).");

            var pregunta = req?.Pregunta?.Trim();
            if (string.IsNullOrEmpty(pregunta)) throw new ApiException(400, "Escriba una pregunta.");
            if (pregunta.Length > 2000) throw new ApiException(400, "La pregunta es demasiado larga (máximo 2000 caracteres).");

            var c = _chat.Configuracion();
            if (!c.Configurado) throw new ApiException(503, "Falta configurar la clave del asistente: cargue el parámetro del sistema IA_ApiKey.");

            return await _chat.PreguntarAsync(c, s.Empresa, s.UserName, req.Historial, pregunta, HttpContext.RequestAborted, req.VentaAnterior);
        }

        [HttpPost("venta/formulario")]
        public object AbrirVenta([FromBody] AsistenteIAVentaSolicitud solicitud)
        {
            SignetRequestContext.RequireSession();
            if (!_chat.Opciones.Habilitado || !Permitido())
                throw new ApiException(403, "Su usuario no tiene acceso al asistente.");
            try
            {
                var borrador = new AsistenteIAVentas().Preparar(solicitud);
                var venta = borrador.Comprobante;
                var campos = ScreenCatalog.PropiedadesEscalares(venta.GetType()).Where(p => p.CanWrite && p.Name != "Id"
                    && p.Name != "FechaAdd" && p.Name != "UserAdd" && p.Name != "FechaMod" && p.Name != "UserMod"
                    && p.Name != "FechaDel" && p.Name != "UserDel").ToList();
                return new
                {
                    pantalla = "ComprobantesVentas",
                    valores = ValueConverter.ToDictionary(venta, campos),
                    detalles = new
                    {
                        Detalle = venta.Detalle.Select(d => ValueConverter.ToDictionary(d, ScreenCatalog.PropiedadesEscalares(d.GetType())
                            .Where(p => p.Name != "FechaAdd" && p.Name != "UserAdd" && p.Name != "FechaMod" && p.Name != "UserMod"
                                && p.Name != "FechaDel" && p.Name != "UserDel"))).ToList(),
                        Impuestos = venta.Impuestos.Select(i => ValueConverter.ToDictionary(i, ScreenCatalog.PropiedadesEscalares(i.GetType())
                            .Where(p => p.Name != "FechaAdd" && p.Name != "UserAdd" && p.Name != "FechaMod" && p.Name != "UserMod"
                                && p.Name != "FechaDel" && p.Name != "UserDel"))).ToList()
                    }
                };
            }
            catch (AsistenteIAException ex) { throw new ApiException(ex.Codigo, ex.Message); }
        }
    }
}