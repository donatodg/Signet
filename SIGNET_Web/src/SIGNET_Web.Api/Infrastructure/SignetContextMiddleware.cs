using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VENET_Common;

namespace SIGNET_Web.Api.Infrastructure
{
    /// <summary>
    /// Establece el contexto de la petición para el código original:
    ///  - Con sesión válida: ConfigurationManager.AppSettings devuelve una copia de los valores de la sesión.
    ///  - Sin sesión (login): una copia de los AppSettings del proceso.
    /// Las rutas /api/* (excepto /api/auth/bases y /api/auth/login) requieren sesión.
    /// </summary>
    public class SignetContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SessionStore _sessions;

        public SignetContextMiddleware(RequestDelegate next, SessionStore sessions)
        {
            _next = next;
            _sessions = sessions;
        }

        public async Task Invoke(HttpContext http)
        {
            string token = null;
            string auth = http.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(auth) && auth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                token = auth.Substring(7).Trim();

            var session = _sessions.Get(token);
            var path = http.Request.Path;

            if (session == null && path.StartsWithSegments("/api")
                && !path.StartsWithSegments("/api/auth/bases")
                && !path.StartsWithSegments("/api/auth/login"))
            {
                http.Response.StatusCode = StatusCodes.Status401Unauthorized;
                http.Response.ContentType = "application/json; charset=utf-8";
                await http.Response.WriteAsync("{\"mensaje\":\"La sesión expiró o no es válida. Ingrese nuevamente.\"}");
                return;
            }

            var settings = session != null
                ? new NameValueCollection(session.AppSettings)
                : new NameValueCollection(SignetConfigSystem.ProcessAppSettings);

            SignetRequestContext.Current = new SignetRequestContext(session, settings);
            try
            {
                await _next(http);
            }
            finally
            {
                SignetRequestContext.Current = null;
            }
        }
    }
}
