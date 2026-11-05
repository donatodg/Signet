using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SIGNET_Web.Api.Screens;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using VENET_Common;

namespace SIGNET_Web.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Debe ejecutarse antes de cualquier uso de EF / ConfigurationManager:
            // hace que ConfigurationManager.AppSettings sea por usuario/petición.
            SignetConfigSystem.Install();

            int dump = Array.IndexOf(args, "--dump-schemas");
            string dumpFile = null;
            if (dump >= 0)
            {
                dumpFile = dump + 1 < args.Length ? args[dump + 1] : "schemas.json";
                args = args.Where((_, i) => i != dump && i != dump + 1).ToArray();
            }

            var root = File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                ? Directory.GetCurrentDirectory()
                : AppDomain.CurrentDomain.BaseDirectory;
            var config = new ConfigurationBuilder()
                .SetBasePath(root)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables("ASPNETCORE_")
                .AddCommandLine(args)
                .Build();

            var host = WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(root)
                .UseUrls(config["Urls"] ?? config["urls"] ?? "http://localhost:5080")
                .UseStartup<Startup>()
                .Build();

            if (dumpFile != null)
            {
                // Diagnóstico: vuelca las pantallas descubiertas en el BL sin levantar el servidor
                var catalog = (ScreenCatalog)host.Services.GetService(typeof(ScreenCatalog));
                var json = JsonConvert.SerializeObject(catalog.All.OrderBy(d => d.AreaOrden).ThenBy(d => d.Key), Formatting.Indented,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore });
                File.WriteAllText(dumpFile, json);
                Console.WriteLine("Pantallas: " + catalog.All.Count() + " -> " + Path.GetFullPath(dumpFile));
                return;
            }

            host.Run();
        }
    }
}
