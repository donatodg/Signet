using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;
using VENET_Gestion_BL;

namespace SIGNET_Web.Api.Controllers
{
    [ApiController]
    [Route("api/compras-documentos")]
    public sealed class ComprasDocumentosController : ControllerBase
    {
        private readonly ComprasDocumentosService servicio = new ComprasDocumentosService();
        private static void Exigir()
        {
            SignetRequestContext.RequireSession();
            if (!Seguridad.TienePermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Ingresar)
                || !Seguridad.TienePermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Agregar))
                throw new ApiException(403, "Sin permiso para cargar documentos de compras.");
        }
        [HttpGet("opciones")]
        public object Opciones() { Exigir(); return servicio.Opciones(); }
        [HttpGet("productos")]
        public object Productos(string buscar, int? id = null) { Exigir(); return servicio.Productos(buscar, id); }
        [HttpGet]
        public object Listar() { Exigir(); return servicio.Listar(); }
        public sealed class Carga
        {
            public Guid Id { get; set; }
            public int Sucursal { get; set; }
            public List<ArchivoCompra> Archivos { get; set; }
        }
        [HttpPost]
        [RequestSizeLimit(18 * 1024 * 1024)]
        public object Cargar([FromBody] Carga s)
        {
            Exigir();
            if (s == null) throw new System.ComponentModel.DataAnnotations.ValidationException("Falta la carga.");
            return servicio.Cargar(s.Id, s.Sucursal, s.Archivos);
        }
        [HttpGet("{id:guid}")]
        public object Obtener(Guid id) { Exigir(); return servicio.Obtener(id); }
        [HttpGet("{id:guid}/propuesta")]
        public object Propuesta(Guid id) { Exigir(); return servicio.Proponer(id); }
        [HttpGet("{id:guid}/original/{orden:int}")]
        public object Original(Guid id, int orden)
        {
            Exigir(); var a = servicio.Original(id, orden);
            return new { nombre = a.Nombre, contentType = a.Mime, base64 = Convert.ToBase64String(a.Datos) };
        }
        [HttpGet("{id:guid}/vista")]
        public object Vista(Guid id)
        {
            Exigir(); return servicio.Vista(id).ConvertAll(Convert.ToBase64String);
        }
        public sealed class Lectura { public int Version { get; set; } }
        [HttpPost("{id:guid}/leer")]
        public async Task<object> Leer(Guid id, [FromBody] Lectura s, CancellationToken ct)
        {
            Exigir();
            if (s == null) throw new System.ComponentModel.DataAnnotations.ValidationException("Falta la version.");
            return await servicio.AnalizarAsync(id, s.Version, ct);
        }
        [HttpPost("revisar")]
        [RequestSizeLimit(1024 * 1024)]
        public object Revisar([FromBody] RevisionCompraDocumento s) { Exigir(); return servicio.Revisar(s); }
        [HttpPost("revision")]
        [RequestSizeLimit(1024 * 1024)]
        public object GuardarRevision([FromBody] RevisionCompraDocumento s) { Exigir(); return servicio.GuardarRevision(s); }
        public sealed class Guardado { public RevisionCompraDocumento Revision { get; set; } public string Firma { get; set; } }
        [HttpPost("guardar")]
        [RequestSizeLimit(1024 * 1024)]
        public object Guardar([FromBody] Guardado s)
        {
            Exigir();
            if (s?.Revision == null) throw new System.ComponentModel.DataAnnotations.ValidationException("Falta la revision.");
            return servicio.GuardarCompra(s.Revision, s.Firma);
        }
    }
}
