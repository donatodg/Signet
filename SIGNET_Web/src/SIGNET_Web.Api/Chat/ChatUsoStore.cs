using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace SIGNET_Web.Api.Chat
{
    /// <summary>
    /// Registro de preguntas/consultas del asistente (App_Data\chat\registro-AAAA-MM.jsonl).
    /// El consumo de tokens se guarda en la base (parámetro IA_ConsumoTokensMes), compartido con el escritorio.
    /// </summary>
    public class ChatUsoStore
    {
        private readonly string _carpeta;
        private readonly object _lock = new object();

        public ChatUsoStore(IHostingEnvironment env)
        {
            _carpeta = Path.Combine(env.ContentRootPath, "App_Data", "chat");
        }

        public void Registrar(object entrada)
        {
            try
            {
                lock (_lock)
                {
                    Directory.CreateDirectory(_carpeta);
                    File.AppendAllText(Path.Combine(_carpeta, $"registro-{DateTime.Now:yyyy-MM}.jsonl"), JsonConvert.SerializeObject(entrada) + Environment.NewLine);
                }
            }
            catch (Exception) { }
        }
    }
}