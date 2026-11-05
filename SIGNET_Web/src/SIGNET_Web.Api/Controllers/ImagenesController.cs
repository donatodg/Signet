using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;
using VENET_DataEntity;
using VENET_General_BL;

namespace SIGNET_Web.Api.Controllers
{
    /// <summary>Galería de imágenes (frmImagenes) sobre ImagenesManager. Tablas habilitadas: las mismas que abren el formulario en el escritorio.</summary>
    [ApiController]
    [Route("api/imagenes/{tabla}/{id:int}")]
    public class ImagenesController : ControllerBase
    {
        private static readonly string[] Tablas = { "Cotizaciones", "ComprobantesVentas", "Productos" };
        private static readonly string[] Extensiones = { ".jpg", ".jpeg", ".png", ".gif", ".tif", ".tiff" };

        public class ArchivoImagen { public string Nombre { get; set; } public string Base64 { get; set; } }
        public class AgregarRequest { public List<ArchivoImagen> Archivos { get; set; } }
        public class ModificarRequest { public string Descripcion { get; set; } public int IdCategoria { get; set; } public int Orden { get; set; } }

        private static string Validar(string tabla)
        {
            var t = Tablas.FirstOrDefault(x => string.Equals(x, tabla, StringComparison.OrdinalIgnoreCase));
            if (t == null) throw new ApiException(404, "Tabla de imágenes desconocida.");
            return t;
        }

        // Permiso con el que el escritorio habilita el botón "Imágenes" de cada pantalla.
        private static void ExigirVer(string tabla)
        {
            var accion = tabla == "Productos" ? Enums.Accion.Ver : Enums.Accion.Operaciones;
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, tabla, accion, "Ver Imagenes"))
                throw new ApiException(403, Seguridad.MensajeSinPermiso(accion, tabla, "Ver Imagenes"));
        }

        private static void Exigir(Enums.Accion accion, string descripcion = "")
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Imagenes", accion, descripcion))
                throw new ApiException(403, Seguridad.MensajeSinPermiso(accion, "Imagenes", descripcion));
        }

        [HttpGet]
        public object Listar(string tabla, int id)
        {
            tabla = Validar(tabla); ExigirVer(tabla);
            var m = new ImagenesManager(tabla, id);
            return new
            {
                categorias = m.Categorias.Select(c => new { key = c.Key, name = c.Name }).ToList(),
                imagenes = m.ListImagen.Where(i => i.Imagen != null && i.UserDel == null).OrderBy(i => i.Orden).Select(i => new
                {
                    id = i.Id, descripcion = i.Descripcion, idCategoria = i.Id_CategoriaImagen, orden = i.Orden, fecha = i.FechaAdd,
                    datos = "data:image/jpeg;base64," + Convert.ToBase64String(i.Imagen)
                }).ToList()
            };
        }

        [HttpPost]
        public object Agregar(string tabla, int id, [FromBody] AgregarRequest req)
        {
            tabla = Validar(tabla); ExigirVer(tabla); Exigir(Enums.Accion.Agregar);
            if (req?.Archivos == null || req.Archivos.Count == 0) throw new ValidationException("Seleccione al menos una imagen.");
            foreach (var a in req.Archivos)
            {
                if (!Extensiones.Contains(Path.GetExtension(a.Nombre ?? "").ToLowerInvariant())) throw new ValidationException("Formato no permitido: " + a.Nombre);
                byte[] bytes;
                try
                {
                    using (var ms = new MemoryStream(Convert.FromBase64String(a.Base64 ?? "")))
                    using (var bmp = Image.FromStream(ms))
                    using (var salida = new MemoryStream())
                    {
                        bmp.Save(salida, ImageFormat.Jpeg);
                        bytes = salida.ToArray();
                    }
                }
                catch (Exception) { throw new ValidationException("El archivo no es una imagen válida: " + a.Nombre); }
                var o = new Imagenes { Id = 0, Descripcion = "-", Id_CategoriaImagen = 1, Tabla = tabla, Imagen = bytes, Orden = 1, Id_Tabla = id };
                if (!ImagenesManager.Agregar(o)) throw new ValidationException("No se pudo guardar la imagen " + a.Nombre);
            }
            return new { mensaje = req.Archivos.Count + " imagen(es) importada(s)." };
        }

        [HttpPut("{imagenId:int}")]
        public object Modificar(string tabla, int id, int imagenId, [FromBody] ModificarRequest req)
        {
            tabla = Validar(tabla); ExigirVer(tabla); Exigir(Enums.Accion.Modificar);
            PerteneceA(tabla, id, imagenId);
            if (string.IsNullOrWhiteSpace(req?.Descripcion)) throw new ValidationException("El campo descripción es obligatorio.");
            if (!ImagenesManager.Modificar(new Imagenes { Id = imagenId }, req.Descripcion.Trim(), req.IdCategoria, req.Orden)) throw new ValidationException("No se pudo modificar la imagen.");
            return new { mensaje = "Imagen modificada." };
        }

        [HttpDelete("{imagenId:int}")]
        public object Eliminar(string tabla, int id, int imagenId)
        {
            tabla = Validar(tabla); ExigirVer(tabla); Exigir(Enums.Accion.Eliminar);
            PerteneceA(tabla, id, imagenId);
            if (!ImagenesManager.Eliminar(new Imagenes { Id = imagenId })) throw new ValidationException("No se pudo eliminar la imagen.");
            return new { mensaje = "Imagen eliminada." };
        }

        // Evita modificar imágenes de otro registro cambiando la URL.
        private static void PerteneceA(string tabla, int id, int imagenId)
        {
            if (!new ImagenesManager(tabla, id).ListImagen.Any(i => i.Id == imagenId)) throw new ApiException(404, "La imagen no existe.");
        }
    }
}
