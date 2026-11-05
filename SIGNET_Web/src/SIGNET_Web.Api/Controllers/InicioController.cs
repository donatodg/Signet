using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SIGNET_Web.Api.Infrastructure;
using SIGNET_Web.Api.Screens;
using VENET_Common;
using VENET_DataEntity;

namespace SIGNET_Web.Api.Controllers
{
    /// <summary>
    /// Pantalla principal con azulejos (TileControlPrincipal de frmMain).
    /// La configuración por usuario se lee/graba con el BL original TilePrincipal (tabla SeguridadUsuariosConfiguracion).
    /// </summary>
    [ApiController]
    [Route("api/inicio")]
    public class InicioController : ControllerBase
    {
        private class TileDef
        {
            public int Id; public int Grupo; public string Titulo; public string Subtitulo; public string Pantalla;
            public string Tamano; public string Color; public string ParametroMenu;
        }

        private static readonly (int Id, string Titulo)[] Grupos =
        {
            (2, "Cuentas Corrientes"), (3, "Movimientos"), (4, "Cheques"), (5, "Gestión"), (6, "Producción"), (7, "Productos")
        };

        // Réplica de frmMain.Designer (Id, textos, tamaño y color por defecto) y de los handlers tileItem*_ItemClick
        private static readonly TileDef[] Tiles =
        {
            T(1, 2, "Cta. Cte. de Especies", "Búsqueda de Cta. Cte. de Especies", "EspeciesCtaCte", "Wide", "#4169E1", "Menu_Tesoreria_CuentaCorrienteEspecies"),
            T(2, 2, "Cta. Cte. de Entidades", "Búsqueda de Cta. Cte. de Entidades", "EntidadesCtaCte", "Wide", "#4169E1", "Menu_Tesoreria_CuentaCorrienteEntidades"),
            T(11, 3, "Recibos", "Búsqueda de Recibos", "Recibos", "Wide", "#FF7F50", "Menu_Tesoreria_Recibos"),
            T(14, 3, "Ordenes de Pagos", "Búsqueda de Ordenes de Pagos", "OrdenesPago", "Wide", "#FF7F50", "Menu_Tesoreria_OrdenesDePago"),
            T(12, 3, "Vales", "Búsqueda de Vales", "Vales", "Medium", "#FF7F50", "Menu_Tesoreria_Vales"),
            T(13, 3, "Rendiciones", "Búsqueda de Rendiciones de Vales", "Rendiciones", "Medium", "#FF7F50", "Menu_Tesoreria_Rendiciones"),
            T(15, 3, "Listas Pagos", "Búsqueda de Listas de Pagos", "ListaPagos", "Medium", "#FF7F50", "Menu_Tesoreria_ListaDePagos"),
            T(16, 3, "Cotizaciones", "Búsqueda de Cotizaciones", "Cotizaciones", "Wide", "#FF7F50", "Menu_Tesoreria_Cotizaciones"),
            T(21, 4, "Cheques de Terceros", "Búsqueda de Cheques de Terceros", "ChequeTerceros", "Wide", "#6B8E23", "Menu_Tesoreria_ChequesDeTerceros"),
            T(22, 4, "Depósitos", "Búsqueda de Boletas de Depósitos", "BoletasDepositos", "Medium", "#6B8E23", "Menu_Tesoreria_BoletasDeDepositos"),
            T(23, 4, "Descuentos", "Búsqueda de Descuentos de Cheques", "ChequeDescuento", "Medium", "#6B8E23", "Menu_Tesoreria_DescuentoDeCheques"),
            T(24, 4, "Cheques Propios", "Búsqueda de Cheques Propios", "ChequePropios", "Wide", "#6B8E23", "Menu_Tesoreria_ChequesPropios"),
            T(34, 5, "Pedidos", "Búsqueda de Pedidos", "Pedidos", "Wide", "#A52A2A", "Menu_Tesoreria_Pedidos"),
            T(31, 5, "Comp. de Ventas", "Búsqueda de Comprobantes de Ventas", "ComprobantesVentas", "Wide", "#A52A2A", "Menu_Tesoreria_ComprobantesDeVentas"),
            T(32, 5, "Comp. de Compras", "Búsqueda de Comprobantes de Compras", "ComprobantesCompras", "Wide", "#A52A2A", "Menu_Tesoreria_ComprobantesDeCompras"),
            T(33, 5, "Productos", "Búsqueda de Productos", "Productos", "Wide", "#A52A2A", "Menu_Configuracion_Productos"),
            T(35, 5, "Listas de Precios", "Búsqueda de Listas de Precios", "ProductosListasPrecios", "Wide", "#A52A2A", "Menu_Configuracion_ProductosListasPrecios"),
            T(41, 6, "Producción", "Búsqueda de Producciones", "Produccion", "Wide", "#008080", "Menu_Produccion_Produccion"),
            T(42, 6, "Líneas", "Búsqueda de Líneas", "ProduccionLineas", "Medium", "#008080", "Menu_Produccion_Lineas"),
            T(43, 6, "Variantes", "Búsqueda de Variantes", "ProduccionVariantes", "Medium", "#008080", "Menu_Produccion_Variantes"),
            T(44, 6, "Tareas", "Búsqueda de Tareas", "ProduccionTareas", "Medium", "#008080", "Menu_Produccion_Tareas"),
            T(45, 6, "Medidas", "Búsqueda de Medidas", "ProduccionMedidas", "Medium", "#008080", "Menu_Produccion_Medidas"),
            T(46, 6, "Lista Precios", "Búsqueda de Lista de Precios para Producción", "ProduccionListaPrecios", "Wide", "#008080", "Menu_Produccion_ListaPrecios"),
            T(51, 7, "Productos", "Búsqueda de Productos", "Productos", "Wide", "#A52A2A", "Menu_Produccion_PProductos"),
            T(52, 7, "Prod. Derivados", "Búsqueda de Productos Derivados", "ProductosDerivados", "Wide", "#A52A2A", "Menu_Produccion_PProdDerivado"),
        };

        private static TileDef T(int id, int grupo, string titulo, string sub, string pantalla, string tamano, string color, string param) =>
            new TileDef { Id = id, Grupo = grupo, Titulo = titulo, Subtitulo = sub, Pantalla = pantalla, Tamano = tamano, Color = color, ParametroMenu = param };

        private readonly ScreenService _screens;
        private readonly InicioLayoutStore _layouts;
        public InicioController(ScreenService screens, InicioLayoutStore layouts) { _screens = screens; _layouts = layouts; }

        private static readonly HashSet<string> Tamanos = new HashSet<string> { "Small", "Medium", "Wide", "Large" };
        private static readonly System.Text.RegularExpressions.Regex ColorHex = new System.Text.RegularExpressions.Regex("^#[0-9A-Fa-f]{6}$");

        // El usuario del login de desarrollo es ficticio (Id 1): se separa para no pisar el diseño de un usuario real.
        private static string ClaveUsuario(SignetSession s) => GuardaEnBase ? s.UserId.ToString() : "desarrollo";

        private static string Hex(string argb)
        {
            if (string.IsNullOrEmpty(argb) || !int.TryParse(argb, out var v)) return null;
            var c = Color.FromArgb(v);
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private static int Argb(string hex)
        {
            if (string.IsNullOrEmpty(hex)) throw new ApiException(400, "Color inválido.");
            try { return ColorTranslator.FromHtml(hex).ToArgb(); }
            catch (Exception) { throw new ApiException(400, "Color inválido."); }
        }

        [HttpGet]
        public object Obtener()
        {
            var sesion = SignetRequestContext.RequireSession();
            var s = ConfigurationManager.AppSettings;

            // Pantallas a las que el usuario puede ingresar (permiso Ingresar)
            var habilitadas = _screens.PantallasHabilitadas();

            // Parámetros del módulo Sistema "Menu_*" = False deshabilitan el acceso (igual que frmMain_Load)
            var deshabilitados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            try { foreach (var p in Parametro.ObtenerParamterosMenuPrincipalDeshabilitados()) deshabilitados.Add(p.Nombre); }
            catch (Exception) { }

            var config = TilePrincipal.ConfiguracionUsuario().GroupBy(c => c.Id_Tile).ToDictionary(g => g.Key, g => g.First());

            var layout = _layouts.Leer(sesion.Empresa, ClaveUsuario(sesion));
            var tileLayout = layout.Tiles.Select((t, i) => new { t, i }).GroupBy(x => x.t.Id).ToDictionary(g => g.Key, g => g.First());

            var tiles = Tiles
                .Select((t, i) => new { t, i })
                .Where(x => habilitadas.Contains(x.t.Pantalla) && !deshabilitados.Contains(x.t.ParametroMenu))
                .Select(x =>
                {
                    var t = x.t;
                    config.TryGetValue(t.Id, out var c);
                    tileLayout.TryGetValue(t.Id, out var l);
                    return new
                    {
                        id = t.Id,
                        grupo = l?.t.Grupo ?? t.Grupo,
                        orden = l != null ? l.i : 1000 + x.i,
                        titulo = t.Titulo,
                        subtitulo = t.Subtitulo,
                        pantalla = t.Pantalla,
                        tamano = l != null && Tamanos.Contains(l.t.Tamano) ? l.t.Tamano : t.Tamano,
                        tamanoDefecto = t.Tamano,
                        colorDefecto = t.Color,
                        color1 = Hex(c?.Color1),
                        color2 = Hex(c?.Color2),
                        colorFuente = Hex(c?.ColorFuente),
                        visible = c?.Visible ?? true
                    };
                })
                .OrderBy(t => t.orden)
                .ToList();

            // Grupos del diseño guardado (en su orden) y luego los originales que falten
            var grupos = layout.Grupos.Select(g => new
            {
                id = g.Id,
                titulo = g.Titulo ?? Grupos.Where(o => o.Id == g.Id).Select(o => o.Titulo).FirstOrDefault() ?? "",
                colorTitulo = g.ColorTitulo
            }).ToList();
            grupos.AddRange(Grupos.Where(o => grupos.All(g => g.id != o.Id)).Select(o => new { id = o.Id, titulo = o.Titulo, colorTitulo = (string)null }));

            bool.TryParse(s["TileMostrarTitulos"], out var titulos);
            return new
            {
                colorFondo = Hex(s["CurrentUserBackColor"]),
                mostrarTitulos = titulos,
                guardaEnBase = GuardaEnBase,
                grupos = grupos.Where(g => tiles.Any(t => t.grupo == g.id)),
                tiles
            };
        }

        public class LayoutRequest
        {
            public List<InicioLayoutStore.GrupoLayout> Grupos { get; set; }
            public List<InicioLayoutStore.TileLayout> Tiles { get; set; }
        }

        /// <summary>Mover azulejos de grupo/orden, tamaño (Pequeño/Mediano/Largo/Grande) y texto/color de los títulos de grupos.</summary>
        [HttpPut("layout")]
        public IActionResult GuardarLayout([FromBody] LayoutRequest req)
        {
            var sesion = SignetRequestContext.RequireSession();
            if (req?.Grupos == null || req.Tiles == null) throw new ApiException(400, "Diseño inválido.");
            if (req.Grupos.Count > 100 || req.Tiles.Count > Tiles.Length) throw new ApiException(400, "Diseño inválido.");

            var idsGrupos = new HashSet<int>();
            foreach (var g in req.Grupos)
            {
                if (g == null || g.Id <= 0 || !idsGrupos.Add(g.Id)) throw new ApiException(400, "Grupo inválido.");
                g.Titulo = g.Titulo?.Trim();
                if (g.Titulo != null && g.Titulo.Length > 60) throw new ApiException(400, "El título del grupo admite hasta 60 caracteres.");
                if (!string.IsNullOrEmpty(g.ColorTitulo) && !ColorHex.IsMatch(g.ColorTitulo)) throw new ApiException(400, "Color inválido.");
                if (string.IsNullOrEmpty(g.ColorTitulo)) g.ColorTitulo = null;
            }
            var idsTiles = new HashSet<int>();
            foreach (var t in req.Tiles)
            {
                if (t == null || Tiles.All(d => d.Id != t.Id) || !idsTiles.Add(t.Id)) throw new ApiException(400, "Acceso inexistente.");
                if (!idsGrupos.Contains(t.Grupo)) throw new ApiException(400, "Grupo inexistente.");
                if (!Tamanos.Contains(t.Tamano)) throw new ApiException(400, "Tamaño inválido.");
            }

            // Se conservan los azulejos y grupos que el usuario no ve hoy (sin permiso) para no perder su diseño.
            var clave = ClaveUsuario(sesion);
            var anterior = _layouts.Leer(sesion.Empresa, clave);
            var tiles = req.Tiles.Concat(anterior.Tiles.Where(t => !idsTiles.Contains(t.Id))).ToList();
            var grupos = req.Grupos
                .Concat(anterior.Grupos.Where(g => !idsGrupos.Contains(g.Id) && tiles.Any(t => t.Grupo == g.Id)))
                .ToList();
            _layouts.Guardar(sesion.Empresa, clave, new InicioLayoutStore.Layout { Grupos = grupos, Tiles = tiles });
            return NoContent();
        }

        /// <summary>
        /// Vuelve al diseño original de frmMain: grupos/orden/tamaños/títulos y, si la sesión graba en la base,
        /// también colores, visibilidad, color de fondo y mostrar títulos (mismas tablas que usa TilePrincipal).
        /// </summary>
        [HttpDelete]
        public IActionResult Restablecer()
        {
            var sesion = SignetRequestContext.RequireSession();
            _layouts.Guardar(sesion.Empresa, ClaveUsuario(sesion), new InicioLayoutStore.Layout());
            if (!GuardaEnBase) return NoContent();

            using (var db = new SeguridadContext())
            {
                var idUsuario = sesion.UserId;
                db.SeguridadUsuariosConfiguracion.RemoveRange(db.SeguridadUsuariosConfiguracion.Where(c => c.Id_Usuario == idUsuario));
                var u = db.SeguridadUsuarios.Find(idUsuario);
                if (u != null)
                {
                    u.BackColor = null;
                    u.BackImage = null;
                    u.TituloTile = false;
                }
                db.SaveChanges();
            }
            var s = ConfigurationManager.AppSettings;
            s["CurrentUserBackColor"] = null;
            s["TileMostrarTitulos"] = bool.FalseString;
            return NoContent();
        }

        public class TileRequest
        {
            public bool? Visible { get; set; }
            public string Color1 { get; set; }
            public string Color2 { get; set; }
            public string ColorFuente { get; set; }
        }

        /// <summary>Equivalente a Eliminar/Agregar azulejo y Color 1 / Color 2 / Color Fuente del menú contextual.</summary>
        [HttpPut("tiles/{id:int}")]
        public IActionResult Tile(int id, [FromBody] TileRequest req)
        {
            SignetRequestContext.RequireSession();
            if (Tiles.All(t => t.Id != id)) throw new ApiException(404, "Acceso inexistente.");
            if (req == null) return NoContent();
            if (!GuardaEnBase) return NoContent();
            if (req.Visible.HasValue) TilePrincipal.ItemOculto(req.Visible.Value, id);
            if (!string.IsNullOrEmpty(req.Color1)) TilePrincipal.TileColor1(Argb(req.Color1), id);
            if (!string.IsNullOrEmpty(req.Color2)) TilePrincipal.TileColor2(Argb(req.Color2), id);
            if (!string.IsNullOrEmpty(req.ColorFuente)) TilePrincipal.ForeColor(Argb(req.ColorFuente), id);
            return NoContent();
        }

        public class PreferenciasRequest
        {
            public string ColorFondo { get; set; }
            public bool? MostrarTitulos { get; set; }
        }

        /// <summary>Equivalente a Color de Fondo y Mostrar/Ocultar Títulos.</summary>
        [HttpPut("preferencias")]
        public IActionResult Preferencias([FromBody] PreferenciasRequest req)
        {
            SignetRequestContext.RequireSession();
            var s = ConfigurationManager.AppSettings;
            if (!string.IsNullOrEmpty(req?.ColorFondo))
            {
                var argb = Argb(req.ColorFondo);
                if (GuardaEnBase) TilePrincipal.BackColor(argb);
                s["CurrentUserBackColor"] = argb.ToString();
            }
            if (req?.MostrarTitulos != null)
            {
                if (GuardaEnBase) TilePrincipal.TileTitulo(req.MostrarTitulos.Value);
                s["TileMostrarTitulos"] = req.MostrarTitulos.Value.ToString();
            }
            return NoContent();
        }

        /// <summary>El login de desarrollo (usuario ficticio) no graba en la base, igual que GuardarConfiguracion=0 del escritorio.</summary>
        private static bool GuardaEnBase => ConfigurationManager.AppSettings["GuardarConfiguracion"] == "1";
    }
}
