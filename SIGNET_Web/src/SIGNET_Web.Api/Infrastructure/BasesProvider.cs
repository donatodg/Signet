using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VENET_Common;

namespace SIGNET_Web.Api.Infrastructure
{
    /// <summary>
    /// Bases de datos disponibles para el login. Reutiliza VENET_Common.Config (lectura del Setup.xml
    /// encriptado del escritorio) y agrega las bases configuradas en appsettings.json.
    /// </summary>
    public class BasesProvider
    {
        private readonly SignetOptions _options;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<BasesProvider> _logger;

        public BasesProvider(IOptions<SignetOptions> options, IHostingEnvironment env, ILogger<BasesProvider> logger)
        {
            _options = options.Value;
            _env = env;
            _logger = logger;
        }

        public class Resultado
        {
            public string Sistema { get; set; }
            public string Web { get; set; }
            public DateTime? Fecha { get; set; }
            public List<ConfigBases> Bases { get; set; } = new List<ConfigBases>();
        }

        public Resultado Obtener()
        {
            var r = new Resultado { Sistema = _options.NombreSistema };

            string setup = ResolverSetupXml();
            if (setup != null)
            {
                Config cfg = Config.ObtenerConfiguracion(Path.GetDirectoryName(setup), Path.GetFileName(setup));
                if (cfg.Bases != null) r.Bases.AddRange(cfg.Bases);
                if (!string.IsNullOrEmpty(cfg.Sistema)) r.Sistema = cfg.Sistema;
                r.Web = cfg.Web;
                r.Fecha = cfg.Fecha;
            }

            foreach (var b in _options.Bases ?? new List<BaseOptions>())
            {
                if (string.IsNullOrWhiteSpace(b.Name) || r.Bases.Any(x => x.Name == b.Name)) continue;
                r.Bases.Add(new ConfigBases { Name = b.Name, DataSource = b.DataSource, DataBase = b.DataBase, User = b.User, Pass = b.Pass, Provider = b.Provider ?? "System.Data.SqlClient" });
            }
            return r;
        }

        private string ResolverSetupXml()
        {
            if (string.IsNullOrWhiteSpace(_options.SetupXmlPath)) return null;
            var candidatos = new[]
            {
                _options.SetupXmlPath,
                Path.Combine(_env.ContentRootPath, _options.SetupXmlPath),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _options.SetupXmlPath),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Setup.xml")
            };
            foreach (var c in candidatos)
            {
                try
                {
                    var full = Path.GetFullPath(c);
                    if (File.Exists(full)) return full;
                }
                catch (Exception) { }
            }
            _logger.LogWarning("No se encontró Setup.xml en {Ruta}", _options.SetupXmlPath);
            return null;
        }
    }
}
