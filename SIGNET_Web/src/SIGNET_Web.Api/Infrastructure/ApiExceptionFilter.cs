using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using VENET_Common;

namespace SIGNET_Web.Api.Infrastructure
{
    public class ApiException : Exception
    {
        public ApiException(int status, string mensaje) : base(mensaje) { Status = status; }
        public int Status { get; }
    }

    /// <summary>Traduce las excepciones del BL original en respuestas JSON { titulo, mensaje }.</summary>
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger) { _logger = logger; }

        private static readonly int[] ErroresConexionSql = { -2, -1, 2, 53, 64, 4060, 18456, 10053, 10054, 10060, 10061, 11001 };

        private static bool EsErrorConexion(Exception ex)
        {
            for (var e = ex; e != null; e = e.InnerException)
                if (e is System.Data.SqlClient.SqlException || e is System.ComponentModel.Win32Exception) return true;
            return false;
        }

        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            while (ex is TargetInvocationException && ex.InnerException != null) ex = ex.InnerException;

            int status;
            string titulo = "Atención";
            string mensaje;

            switch (ex)
            {
                case ApiException a:
                    status = a.Status; mensaje = a.Message; break;
                case SistemaMensajeException sm:
                    status = StatusCodes.Status400BadRequest; mensaje = sm.Message; titulo = string.IsNullOrEmpty(sm.Titulo) ? titulo : sm.Titulo; break;
                case ValidationException v:
                    status = StatusCodes.Status400BadRequest; mensaje = v.Message; break;
                case DbEntityValidationException dv:
                    status = StatusCodes.Status400BadRequest;
                    mensaje = string.Join(Environment.NewLine, dv.EntityValidationErrors.SelectMany(e => e.ValidationErrors).Select(e => e.ErrorMessage).Distinct());
                    break;
                case DbUpdateException du:
                    status = StatusCodes.Status400BadRequest;
                    Exception inner = du;
                    while (inner.InnerException != null) inner = inner.InnerException;
                    mensaje = "No se pudieron guardar los cambios: " + inner.Message;
                    _logger.LogWarning(du, "DbUpdateException");
                    break;
                case System.Data.Entity.Core.EntityException ee when EsErrorConexion(ee):
                    status = StatusCodes.Status503ServiceUnavailable;
                    mensaje = "No se pudo conectar con la base de datos. Verifique la conexión e intente nuevamente.";
                    _logger.LogError(ex, "Error de conexión a la base en {Path}", context.HttpContext.Request.Path);
                    break;
                case System.Data.SqlClient.SqlException se when ErroresConexionSql.Contains(se.Number) || se.InnerException is System.ComponentModel.Win32Exception:
                    // BL que usa ADO directo (DataSet) en lugar de Entity Framework
                    status = StatusCodes.Status503ServiceUnavailable;
                    mensaje = "No se pudo conectar con la base de datos. Verifique la conexión e intente nuevamente.";
                    _logger.LogError(ex, "Error de conexión a la base en {Path}", context.HttpContext.Request.Path);
                    break;
                default:
                    status = StatusCodes.Status500InternalServerError;
                    mensaje = "Se ha producido un error en la aplicación. Avisar a Sistemas...";
                    _logger.LogError(ex, "Error no controlado en {Path}", context.HttpContext.Request.Path);
                    break;
            }

            context.Result = new ObjectResult(new { titulo, mensaje }) { StatusCode = status };
            context.ExceptionHandled = true;
        }
    }
}
