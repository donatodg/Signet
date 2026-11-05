using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VENET_Common;
using VENET_Contabilidad_BL;
using VENET_DataEntity;

namespace SIGNET_Web.Api.Infrastructure
{
    public sealed class ContabilidadWorker : BackgroundService
    {
        private readonly ContabilidadWorkerOptions options;
        private readonly ILogger<ContabilidadWorker> logger;
        public ContabilidadWorker(IOptions<SignetOptions> options, ILogger<ContabilidadWorker> logger)
        { this.options = options.Value.ContabilidadWorker; this.logger = logger; }
        protected override async Task ExecuteAsync(CancellationToken token)
        {
            if (!options.Habilitado) return;
            if (options.ConexionesVariables == null || options.ConexionesVariables.Count == 0)
                throw new ValidationException("ContabilidadWorker habilitado sin conexiones configuradas.");
            if (options.IntervaloSegundos < 10 || options.IntervaloSegundos > 3600
                || options.ConexionesVariables.Any(v => string.IsNullOrWhiteSpace(v)))
                throw new ValidationException("Worker: intervalo permitido de 10 a 3600 segundos y nombres de variables no vacios.");
            while (!token.IsCancellationRequested)
            {
                foreach (var variable in options.ConexionesVariables)
                {
                    if (token.IsCancellationRequested) break;
                    try
                    {
                        var conexion = Environment.GetEnvironmentVariable(variable);
                        if (string.IsNullOrWhiteSpace(conexion)) throw new ValidationException("Falta variable de conexion del worker: " + variable);
                        var settings = new NameValueCollection(SignetConfigSystem.ProcessAppSettings) { ["CurrentConnection"] = conexion, ["CurrentUserId"] = "0" };
                        var session = new SignetSession("contabilidad-worker", settings);
                        SignetRequestContext.Current = new SignetRequestContext(session, settings);
                        using (var db = new GestionContext())
                        {
                            var empresas = db.Database.SqlQuery<int>("SELECT Empresa FROM dbo.ContabilidadOperativa WHERE Activa=1").ToList();
                            foreach (var empresa in empresas)
                            {
                                if (token.IsCancellationRequested) break;
                                var cantidad = new ContabilidadService().ProcesarCola(empresa, 20);
                                if (cantidad > 0) logger.LogInformation("Contabilidad: {Cantidad} eventos procesados para empresa {Empresa}.", cantidad, empresa);
                            }
                        }
                    }
                    catch (ValidationException e) { logger.LogError("Configuracion del worker contable: {Error}", e.Message); }
                    catch (SqlException e) { logger.LogError("Worker contable: error SQL {Numero} en conexion configurada {Variable}. Cola conservada.", e.Number, variable); }
                    catch (Exception e) when (!(e is OperationCanceledException))
                    {
                        logger.LogError("Worker contable: fallo {Tipo} en conexion {Variable}. Cola conservada; revisar configuracion y eventos del servidor.", e.GetType().Name, variable);
                    }
                    finally { SignetRequestContext.Current = null; }
                }
                await Task.Delay(TimeSpan.FromSeconds(Math.Max(10, options.IntervaloSegundos)), token);
            }
        }
    }
}
