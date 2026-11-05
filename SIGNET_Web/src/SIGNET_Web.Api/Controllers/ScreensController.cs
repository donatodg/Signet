using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SIGNET_Web.Api.Screens;
using SIGNET_Web.Api.Screens.Acciones;

namespace SIGNET_Web.Api.Controllers
{
    [ApiController]
    [Route("api/screens/{key}")]
    public class ScreensController : ControllerBase
    {
        private readonly ScreenService _svc;
        private readonly AccionesService _acciones;
        public ScreensController(ScreenService svc, AccionesService acciones) { _svc = svc; _acciones = acciones; }

        [HttpGet("schema")]
        public object Schema(string key) => _svc.Esquema(key, d => _acciones.Listar(d));

        public class AccionRequest
        {
            public List<int> Ids { get; set; }
            public JObject Valores { get; set; }
        }

        [HttpPost("acciones/{accion}/campos")]
        public object CamposAccion(string key, string accion, [FromBody] AccionRequest req) => _acciones.Campos(key, accion, req?.Ids);

        [HttpPost("acciones/{accion}")]
        public object EjecutarAccion(string key, string accion, [FromBody] AccionRequest req) => _acciones.Ejecutar(key, accion, req?.Ids, req?.Valores);

        [HttpGet("lookups")]
        public object Lookups(string key, [FromQuery] string[] nombres) => _svc.Lookups(key, nombres);

        [HttpPost("buscar")]
        public object Buscar(string key, [FromBody] JObject parametros) => _svc.Buscar(key, parametros);

        [HttpGet("registros/nuevo")]
        public object Nuevo(string key) => _svc.Obtener(key, 0);

        [HttpGet("registros/{id:int}")]
        public object Obtener(string key, int id) => _svc.Obtener(key, id);

        public class GuardarRequest
        {
            public int Id { get; set; }
            public JObject Values { get; set; }
            public JObject Opciones { get; set; }
            public JObject Detalles { get; set; }
        }

        [HttpPost("registros")]
        public object Guardar(string key, [FromBody] GuardarRequest req) => _svc.Guardar(key, req?.Id ?? 0, req?.Values, req?.Opciones, req?.Detalles);

        public class LookupsRequest
        {
            public int Id { get; set; }
            public JObject Values { get; set; }
        }

        [HttpPost("hijos")]
        public object AgregarHijo(string key, [FromBody] GuardarRequest req) => _svc.AgregarHijo(key, req?.Values, req?.Opciones);

        public class EdicionRequest
        {
            public JObject Values { get; set; }
            public JArray Filas { get; set; }
        }

        [HttpPost("edicion")]
        public object GuardarEdicion(string key, [FromBody] EdicionRequest req) => _svc.GuardarEdicion(key, req?.Values ?? new JObject(), req?.Filas);

        [HttpPost("procesar")]
        public object Procesar(string key, [FromBody] GuardarRequest req) => _svc.Procesar(key, req?.Values);
        [HttpPost("lookups-dependientes")]
        public object LookupsDependientes(string key, [FromBody] LookupsRequest req) => _svc.LookupsDependientes(key, req?.Id ?? 0, req?.Values);

        public class AutocompletarRequest
        {
            public string Coleccion { get; set; }
            public string Campo { get; set; }
            public JObject Fila { get; set; }
            public JObject Cabecera { get; set; }
        }

        [HttpPost("autocompletar-renglon")]
        public object AutocompletarRenglon(string key, [FromBody] AutocompletarRequest req) =>
            _svc.AutocompletarRenglon(key, req?.Coleccion, req?.Fila, req?.Campo, req?.Cabecera);

        [HttpDelete("registros/{id:int}")]
        public IActionResult Eliminar(string key, int id)
        {
            _svc.Eliminar(key, id);
            return NoContent();
        }
    }
}
