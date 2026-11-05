using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SIGNET_Web.Api.Infrastructure;
using VENET_Common;
using VENET_Comun;

namespace SIGNET_Web.Api.Screens.Acciones
{
    /// <summary>Acciones (menús Imprimir / Operaciones) registradas por pantalla.</summary>
    public class AccionesRegistro
    {
        public const string ResultadoBusqueda = "resultado-busqueda";

        private readonly Dictionary<string, List<AccionDef>> _acciones = new Dictionary<string, List<AccionDef>>(StringComparer.OrdinalIgnoreCase);

        public AccionesRegistro(ILogger<AccionesRegistro> logger)
        {
            var modulos = typeof(AccionesRegistro).Assembly.GetTypes()
                .Where(t => typeof(IAccionesModulo).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
            foreach (var t in modulos)
            {
                try { ((IAccionesModulo)Activator.CreateInstance(t)).Registrar(this); }
                catch (Exception ex) { logger.LogError(ex, "No se pudieron registrar las acciones de {Modulo}", t.Name); }
            }
            logger.LogInformation("Acciones registradas: {Count} en {Pantallas} pantallas", _acciones.Values.Sum(l => l.Count), _acciones.Count);
        }

        public AccionesRegistro Agregar(string pantalla, AccionDef a)
        {
            if (string.IsNullOrEmpty(a.Key) || string.IsNullOrEmpty(a.Titulo)) throw new ArgumentException("Acción sin Key/Titulo en " + pantalla);
            if (a.Ejecutar == null && a.SoloEscritorio == null) throw new ArgumentException("Acción sin Ejecutar: " + pantalla + "/" + a.Key);
            a.Pantalla = pantalla;
            if (!_acciones.TryGetValue(pantalla, out var l)) _acciones[pantalla] = l = new List<AccionDef>();
            if (l.Any(x => x.Key == a.Key)) throw new ArgumentException("Acción duplicada: " + pantalla + "/" + a.Key);
            l.Add(a);
            return this;
        }

        /// <summary>Opción que en la web no está disponible (requiere diálogos complejos del escritorio).</summary>
        public AccionesRegistro SoloEscritorio(string pantalla, string menu, string key, string titulo, string motivo = "Disponible sólo en la aplicación de escritorio.") =>
            Agregar(pantalla, new AccionDef { Key = key, Menu = menu, Titulo = titulo, SoloEscritorio = motivo, Seleccion = Seleccion.Ninguna });

        /// <summary>Opción que abre otra pantalla web equivalente al diálogo del escritorio.</summary>
        public AccionesRegistro Navegar(string pantalla, string menu, string key, string titulo, string destino) =>
            Agregar(pantalla, new AccionDef
            {
                Key = key, Menu = menu, Titulo = titulo, Seleccion = Seleccion.Ninguna, SinPermiso = true,
                Ejecutar = c => new AccionResultado { Navegar = destino }
            });

        public IReadOnlyList<AccionDef> De(string pantalla) =>
            _acciones.TryGetValue(pantalla, out var l) ? l : (IReadOnlyList<AccionDef>)Array.Empty<AccionDef>();

        public bool TieneResultadoBusquedaPropio(string pantalla) => De(pantalla).Any(a => a.Key == ResultadoBusqueda);
    }

    public class AccionesService
    {
        private readonly AccionesRegistro _registro;
        private readonly ScreenCatalog _catalog;
        private readonly ScreenService _screens;

        public AccionesService(AccionesRegistro registro, ScreenCatalog catalog, ScreenService screens)
        {
            _registro = registro;
            _catalog = catalog;
            _screens = screens;
        }

        /// <summary>Acciones visibles de la pantalla (las que el usuario tiene permiso de ejecutar), incluida "Resultado de la Búsqueda".</summary>
        public List<AccionDef> Listar(ScreenDescriptor d)
        {
            var r = new List<AccionDef>();
            if (d.PuedeBuscar && !_registro.TieneResultadoBusquedaPropio(d.Key))
                r.Add(ResultadoBusquedaGenerico(d));
            r.AddRange(_registro.De(d.Key));
            return r.Where(a => a.SoloEscritorio != null || TienePermiso(d, a)).ToList();
        }

        private static AccionDef ResultadoBusquedaGenerico(ScreenDescriptor d) => new AccionDef
        {
            Pantalla = d.Key,
            Key = AccionesRegistro.ResultadoBusqueda,
            Menu = "Imprimir",
            Titulo = "Resultado de la Búsqueda",
            Seleccion = Seleccion.Ninguna,
            Ejecutar = ctx => new AccionResultado { ImprimirGrilla = true }
        };

        private AccionDef Obtener(ScreenDescriptor d, string accion)
        {
            var a = (accion == AccionesRegistro.ResultadoBusqueda && !_registro.TieneResultadoBusquedaPropio(d.Key))
                ? ResultadoBusquedaGenerico(d)
                : _registro.De(d.Key).FirstOrDefault(x => string.Equals(x.Key, accion, StringComparison.OrdinalIgnoreCase));
            if (a == null) throw new ApiException(404, "Operación inexistente: " + accion);
            if (a.SoloEscritorio != null) throw new ApiException(400, a.SoloEscritorio);
            return a;
        }

        private static Enums.Accion AccionPermiso(AccionDef a) => a.Accion ?? (a.Menu == "Imprimir" ? Enums.Accion.Imprimir : Enums.Accion.Operaciones);

        private static bool TienePermiso(ScreenDescriptor d, AccionDef a) =>
            a.SinPermiso || Seguridad.TienePermiso(a.Modulo ?? d.Modulo, a.Formulario ?? d.Formulario, AccionPermiso(a), a.Descripcion ?? "");

        private static void ExigirPermiso(ScreenDescriptor d, AccionDef a)
        {
            if (a.SinPermiso) return;
            var form = a.Formulario ?? d.Formulario;
            if (!Seguridad.ObtenerPermiso(a.Modulo ?? d.Modulo, form, AccionPermiso(a), a.Descripcion ?? ""))
                throw new ApiException(403, Seguridad.MensajeSinPermiso(AccionPermiso(a), form, a.Descripcion ?? ""));
        }

        private AccionContexto Contexto(ScreenDescriptor d, AccionDef a, List<int> ids, JObject valores)
        {
            ids = (ids ?? new List<int>()).Where(i => i > 0).Distinct().ToList();
            if (a.Seleccion == Seleccion.Una && ids.Count != 1)
                throw new ApiException(400, ids.Count == 0 ? "Debe seleccionar un registro." : "Debe seleccionar un único registro.");
            if (a.Seleccion == Seleccion.Varias && ids.Count == 0)
                throw new ApiException(400, "Debe seleccionar al menos un registro.");
            return new AccionContexto { Pantalla = d, Ids = ids, Valores = valores ?? new JObject(), Service = _screens };
        }

        public List<FieldSchema> Campos(string key, string accion, List<int> ids)
        {
            var d = _catalog.Get(key);
            _screens.ExigirPermiso(d, Enums.Accion.Ingresar);
            var a = Obtener(d, accion);
            ExigirPermiso(d, a);
            var campos = new List<FieldSchema>(a.Campos);
            if (a.CamposDinamicos != null) campos = a.CamposDinamicos(Contexto(d, a, ids, null)) ?? campos;
            return campos;
        }

        public AccionResultado Ejecutar(string key, string accion, List<int> ids, JObject valores)
        {
            var d = _catalog.Get(key);
            _screens.ExigirPermiso(d, Enums.Accion.Ingresar);
            var a = Obtener(d, accion);
            ExigirPermiso(d, a);
            var ctx = Contexto(d, a, ids, valores);

            var campos = a.CamposDinamicos != null ? (a.CamposDinamicos(ctx) ?? a.Campos) : a.Campos;
            foreach (var c in campos.Where(c => c.Required))
            {
                var t = ctx.Valores[c.Name];
                if (t == null || t.Type == JTokenType.Null || (t.Type == JTokenType.String && string.IsNullOrWhiteSpace((string)t))
                    || (t is JArray arr && arr.Count == 0))
                    throw new ApiException(400, "Debe ingresar '" + c.Label + "'.");
            }
            return a.Ejecutar(ctx) ?? new AccionResultado();
        }
    }
}
