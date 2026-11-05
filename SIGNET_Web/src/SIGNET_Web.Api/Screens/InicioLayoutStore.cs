using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace SIGNET_Web.Api.Screens
{
    /// <summary>
    /// Diseño de la pantalla principal web (grupo, orden y tamaño de cada azulejo, texto y color de títulos de grupos).
    /// El escritorio lo guarda como XML de DevExpress en SeguridadUsuarios.TileConfig; ese formato no se puede generar
    /// sin DevExpress y escribir otro rompería RestoreLayoutFromStream del escritorio, por eso se guarda aparte
    /// (App_Data\inicio\{base}\{usuario}.json).
    /// </summary>
    public class InicioLayoutStore
    {
        public class GrupoLayout
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string ColorTitulo { get; set; }
        }

        public class TileLayout
        {
            public int Id { get; set; }
            public int Grupo { get; set; }
            public string Tamano { get; set; }
        }

        public class Layout
        {
            public List<GrupoLayout> Grupos { get; set; } = new List<GrupoLayout>();
            /// <summary>El orden de la lista es el orden de los azulejos dentro de cada grupo.</summary>
            public List<TileLayout> Tiles { get; set; } = new List<TileLayout>();
        }

        private readonly string _carpeta;
        private readonly object _lock = new object();

        public InicioLayoutStore(IHostingEnvironment env)
        {
            _carpeta = Path.Combine(env.ContentRootPath, "App_Data", "inicio");
        }

        private string Archivo(string empresa, string usuario)
        {
            string Limpio(string s)
            {
                var sb = new StringBuilder();
                foreach (var ch in s ?? "") sb.Append(char.IsLetterOrDigit(ch) || ch == '-' || ch == '_' ? ch : '_');
                return sb.Length == 0 ? "_" : sb.ToString();
            }
            return Path.Combine(_carpeta, Limpio(empresa), Limpio(usuario) + ".json");
        }

        public Layout Leer(string empresa, string usuario)
        {
            var f = Archivo(empresa, usuario);
            lock (_lock)
            {
                try
                {
                    return File.Exists(f) ? JsonConvert.DeserializeObject<Layout>(File.ReadAllText(f, Encoding.UTF8)) ?? new Layout() : new Layout();
                }
                catch (Exception) { return new Layout(); }
            }
        }

        public void Guardar(string empresa, string usuario, Layout layout)
        {
            var f = Archivo(empresa, usuario);
            lock (_lock)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(f));
                var tmp = f + ".tmp";
                File.WriteAllText(tmp, JsonConvert.SerializeObject(layout, Formatting.Indented), Encoding.UTF8);
                if (File.Exists(f)) File.Replace(tmp, f, null);
                else File.Move(tmp, f);
            }
        }
    }
}
