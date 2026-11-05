using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SIGNET_Web.Api.Infrastructure;
using SIGNET_Web.Api.Screens;
using VENET_Common;
using VENET_Seguridad_BL;

namespace SIGNET_Web.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private static readonly object ConexionLock = new object();
        private static readonly Regex UsuarioValido = new Regex("^[A-Za-z0-9._@-]{1,100}$");

        private readonly BasesProvider _bases;
        private readonly SessionStore _sessions;
        private readonly LoginThrottle _throttle;
        private readonly ScreenService _screens;
        private readonly SignetOptions _options;
        private readonly bool _loginDesarrollo;
        private readonly IHostingEnvironment _env;

        public AuthController(BasesProvider bases, SessionStore sessions, LoginThrottle throttle, ScreenService screens, IOptions<SignetOptions> options, IHostingEnvironment env)
        {
            _bases = bases;
            _sessions = sessions;
            _throttle = throttle;
            _screens = screens;
            _options = options.Value;
            _env = env;
            _loginDesarrollo = env.IsDevelopment() && _options.LoginDesarrollo;
        }

        [HttpGet("bases")]
        public object Bases()
        {
            var r = _bases.Obtener();
            var l = _options.Login ?? new LoginOptions();
            var color = l.Color != null && Regex.IsMatch(l.Color, "^#[0-9a-fA-F]{6}$") ? l.Color : null;
            return new
            {
                sistema = r.Sistema ?? _options.NombreSistema,
                web = r.Web,
                bases = r.Bases.Select(b => b.Name).ToList(),
                desarrollo = _loginDesarrollo,
                login = new { titulo = l.Titulo, mensaje = l.Mensaje, color, pie = l.Pie, imagen = ArchivoLoginImagen() != null }
            };
        }

        private static readonly Random Azar = new Random();
        private static readonly string[] ExtensionesImagen = { ".svg", ".png", ".jpg", ".jpeg", ".webp", ".gif" };

        // Si Imagen es un archivo se usa siempre ese; si es una carpeta, se elige una imagen al azar en cada pedido.
        private string ArchivoLoginImagen()
        {
            var ruta = _options.Login?.Imagen;
            if (string.IsNullOrWhiteSpace(ruta)) return null;
            var candidatos = new[]
            {
                ruta,
                System.IO.Path.Combine(_env.ContentRootPath, ruta),
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta)
            }.Where(System.IO.Path.IsPathRooted);
            foreach (var c in candidatos)
            {
                if (System.IO.File.Exists(c)) return c;
                if (!System.IO.Directory.Exists(c)) continue;
                var imagenes = System.IO.Directory.GetFiles(c)
                    .Where(f => ExtensionesImagen.Contains(System.IO.Path.GetExtension(f).ToLowerInvariant()))
                    .ToList();
                if (imagenes.Count == 0) continue;
                lock (Azar) return imagenes[Azar.Next(imagenes.Count)];
            }
            return null;
        }

        /// <summary>Imagen configurada del panel de ingreso (pública, solo la ruta definida en appsettings).</summary>
        [HttpGet("login/imagen")]
        public IActionResult LoginImagen()
        {
            var archivo = ArchivoLoginImagen();
            if (archivo == null) return NotFound();
            string tipo;
            switch (System.IO.Path.GetExtension(archivo).ToLowerInvariant())
            {
                case ".svg": tipo = "image/svg+xml"; break;
                case ".png": tipo = "image/png"; break;
                case ".jpg": case ".jpeg": tipo = "image/jpeg"; break;
                case ".webp": tipo = "image/webp"; break;
                case ".gif": tipo = "image/gif"; break;
                default: return NotFound();
            }
            Response.Headers["Cache-Control"] = "no-store";
            return PhysicalFile(archivo, tipo);
        }

        public class LoginRequest
        {
            public string Base { get; set; }
            public string Usuario { get; set; }
            public string Clave { get; set; }
        }

        /// <summary>Réplica de frmLogin.Aceptar (aplicación de escritorio) usando LoginManager original.</summary>
        [HttpPost("login")]
        public object Login([FromBody] LoginRequest req)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.Usuario) || string.IsNullOrEmpty(req.Clave))
                throw new ApiException(400, "Debe ingresar usuario y clave.");
            if (!UsuarioValido.IsMatch(req.Usuario.Trim()))
                throw new ApiException(400, "Los datos ingresados son incorrectos.");

            var claveThrottle = (req.Usuario.Trim().ToUpperInvariant()) + "|" + HttpContext.Connection.RemoteIpAddress;
            if (_throttle.EstaBloqueado(claveThrottle))
                throw new ApiException(429, "Demasiados intentos fallidos. Intente nuevamente en unos minutos.");

            var cfg = _bases.Obtener();
            var b = cfg.Bases.FirstOrDefault(x => string.Equals(x.Name, req.Base, StringComparison.OrdinalIgnoreCase))
                    ?? (cfg.Bases.Count == 1 ? cfg.Bases[0] : null);
            if (b == null) throw new ApiException(400, "Seleccione una base de datos válida.");

            var ctx = SignetRequestContext.Current;
            lock (ConexionLock)
            {
                new DbConexion(b.DataSource, b.DataBase, b.Pass, b.User, string.IsNullOrEmpty(b.Provider) ? "System.Data.SqlClient" : b.Provider, b.Name);
            }

            if (_loginDesarrollo && req.Usuario.Trim() == "1" && req.Clave == "1")
                return LoginDesarrollo(b.Name, ctx);

            using (var manager = new LoginManager(req.Usuario.Trim(), req.Clave))
            {
                if (cfg.Fecha.HasValue && cfg.Fecha.Value < Sistema.ObtenerFecha())
                    throw new ApiException(403, "La licencia del sistema está vencida.");

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.SistemaEnMantenimiento)))
                    throw new ApiException(503, Convert.ToString(Parametro.ObtenerValor(Parametro.Param.MensajeAlIniciarSistema)));

                bool ok;
                try { ok = manager.VerificaUsuario(); }
                catch (System.ComponentModel.DataAnnotations.ValidationException ex)
                {
                    _throttle.RegistrarFallo(claveThrottle);
                    throw new ApiException(401, ex.Message);
                }
                if (!ok)
                {
                    _throttle.RegistrarFallo(claveThrottle);
                    throw new ApiException(401, "Los datos ingresados son incorrectos.");
                }
                _throttle.Limpiar(claveThrottle);

                var s = ConfigurationManager.AppSettings;
                var u = manager.Usuario;
                s["CurrentEmpresa"] = b.Name;
                s["CurrentComputerName"] = "WEB-" + HttpContext.Connection.RemoteIpAddress;
                s["CurrentUserId"] = u.Id.ToString();
                s["CurrentUserName"] = (u.Username ?? "").ToUpper();
                s["CurrentUserEsAdministrador"] = manager.EsAdministrador.ToString();
                s["CurrentUserTema"] = u.Tema;
                s["CurrentUserBackColor"] = u.BackColor;
                s["RibbonMinimizado"] = u.RibbonMinimizado.ToString();
                s["TileConfig"] = u.TileConfig;
                s["GuardarConfiguracion"] = "1";
                s["TileMostrarTitulos"] = u.TituloTile.ToString();
                s["CurrentVersion"] = typeof(AuthController).Assembly.GetName().Version.ToString();

                var session = _sessions.Create(new NameValueCollection(s));
                ctx.Session = session;
                Seguridad.Reload();

                return new { token = session.Token, usuario = Usuario(session) };
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var s = SignetRequestContext.Current?.Session;
            if (s != null) _sessions.Remove(s.Token);
            return NoContent();
        }

        [HttpGet("me")]
        public object Me() => Usuario(SignetRequestContext.RequireSession());

        public class CambiarClaveRequest
        {
            public string ClaveActual { get; set; }
            public string ClaveNueva { get; set; }
            public string ClaveNueva2 { get; set; }
        }

        [HttpPost("cambiar-clave")]
        public IActionResult CambiarClave([FromBody] CambiarClaveRequest req)
        {
            SignetRequestContext.RequireSession();
            using (var m = new SeguridadUsuariosCambioPasswordManager())
            {
                m.CambioClave = new SeguridadUsuariosCambioPasswordManager.CambioPass
                {
                    PassAnterior = req?.ClaveActual,
                    PassNueva = req?.ClaveNueva,
                    PassNueva2 = req?.ClaveNueva2
                };
                m.Save();
            }
            return NoContent();
        }

        [HttpGet("/api/catalog")]
        public object Catalogo() => _screens.Menu();

        /// <summary>Solo Development: sesión de administrador sin validar usuario contra la base.</summary>
        private object LoginDesarrollo(string empresa, SignetRequestContext ctx)
        {
            var s = ConfigurationManager.AppSettings;
            s["CurrentEmpresa"] = empresa;
            s["CurrentComputerName"] = "WEB-DEV";
            s["CurrentUserId"] = "1";
            s["CurrentUserName"] = "DESARROLLO";
            s["CurrentUserEsAdministrador"] = bool.TrueString;
            s["GuardarConfiguracion"] = "0";
            s["CurrentVersion"] = typeof(AuthController).Assembly.GetName().Version.ToString();

            var session = _sessions.Create(new NameValueCollection(s));
            ctx.Session = session;
            Seguridad.IniciarDesarrollo();
            return new { token = session.Token, usuario = Usuario(session) };
        }

        private static object Usuario(SignetSession s) => new
        {
            id = s.UserId,
            nombre = s.UserName,
            empresa = s.Empresa,
            esAdministrador = Seguridad.EsAdministrador
        };
    }
}
