using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SIGNET_Web.Api.Infrastructure;
using VENET_IA_BL;

namespace SIGNET_Web.Api.Chat
{
    /// <summary>
    /// Adaptador web del asistente de datos. Toda la lógica (agente, validación del SQL, esquema, tope mensual)
    /// está en VENET_IA_BL, el mismo proyecto que usa el formulario frmAsistenteIA del sistema de escritorio.
    /// La configuración (clave, modelo, tope...) se lee de los parámetros del sistema IA_* de cada base.
    /// </summary>
    public class ChatService
    {
        private readonly ChatOptions _o;
        private readonly ChatUsoStore _registro;
        private readonly ILogger<ChatService> _log;

        public ChatService(IOptions<SignetOptions> options, ChatUsoStore registro, ILogger<ChatService> log)
        {
            _o = options.Value.Chat ?? new ChatOptions();
            _registro = registro;
            _log = log;
        }

        public ChatOptions Opciones => _o;

        /// <summary>Configuración de la base de la sesión actual (usa CurrentConnection de la sesión).</summary>
        public AsistenteIAConfiguracion Configuracion()
        {
            try
            {
                var c = AsistenteIAConfiguracion.Cargar();
                c.Razonamiento = _o.Razonamiento;
                return c;
            }
            catch (AsistenteIAException ex) { throw new ApiException(ex.Codigo, ex.Message); }
        }

        public async Task<AsistenteIARespuesta> PreguntarAsync(AsistenteIAConfiguracion configuracion, string empresa, string usuario, IList<AsistenteIAMensaje> historial, string pregunta, CancellationToken ct,
            AsistenteIAVentaSolicitud ventaAnterior = null)
        {
            var asistente = new AsistenteIAManager(configuracion)
            {
                Empresa = empresa,
                Log = m => _log.LogWarning("Asistente IA: {Mensaje}", m)
            };
            AsistenteIARespuesta res = null;
            string error = null;
            try
            {
                res = await asistente.PreguntarAsync(historial, pregunta, ct, ventaAnterior);
                return res;
            }
            catch (AsistenteIAException ex)
            {
                error = ex.Message;
                throw new ApiException(ex.Codigo, ex.Message);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                throw;
            }
            finally
            {
                _registro.Registrar(new { fecha = DateTime.Now, empresa, usuario, pregunta, consultas = res?.Consultas, tokens = res?.TokensPregunta, error });
            }
        }
    }
}