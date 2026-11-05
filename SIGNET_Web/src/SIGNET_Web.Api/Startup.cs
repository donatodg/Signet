using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using SIGNET_Web.Api.Infrastructure;
using SIGNET_Web.Api.Screens;

namespace SIGNET_Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SignetOptions>(Configuration.GetSection("Signet"));
            services.AddSingleton<BasesProvider>();
            services.AddSingleton<SessionStore>();
            services.AddSingleton<LoginThrottle>();
            services.AddSingleton<ScreenCatalog>();
            services.AddSingleton<ScreenService>();
            services.AddSingleton<InicioLayoutStore>();
            services.AddSingleton<Chat.ChatUsoStore>();
            services.AddSingleton<Chat.ChatService>();
            services.AddSingleton<Screens.Acciones.AccionesRegistro>();
            services.AddSingleton<Screens.Acciones.AccionesService>();
            services.AddMemoryCache();
            services.AddSingleton<Vendedores.PortalVentas>();
            services.AddHostedService<ContabilidadWorker>();

            services.AddMvc(o => o.Filters.Add<ApiExceptionFilter>())
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = false }
                    };
                    o.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss";
                    o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            // Descubrir pantallas al arrancar (y no en el primer request)
            app.ApplicationServices.GetService<ScreenCatalog>();
            app.ApplicationServices.GetService<Screens.Acciones.AccionesRegistro>();

            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                // index.html sin caché para que el navegador tome siempre la última versión del cliente
                OnPrepareResponse = c =>
                {
                    if (c.File.Name.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
                        c.Context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                }
            });
            app.UseMiddleware<SignetContextMiddleware>();
            app.UseMvc();

            // SPA: cualquier ruta que no sea /api ni archivo devuelve index.html
            app.Run(async ctx =>
            {
                var index = Path.Combine(env.WebRootPath ?? Path.Combine(env.ContentRootPath, "wwwroot"), "index.html");
                if (!ctx.Request.Path.StartsWithSegments("/api") && File.Exists(index))
                {
                    ctx.Response.ContentType = "text/html; charset=utf-8";
                    ctx.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                    await ctx.Response.SendFileAsync(index);
                }
                else
                {
                    ctx.Response.StatusCode = 404;
                }
            });
        }
    }
}
