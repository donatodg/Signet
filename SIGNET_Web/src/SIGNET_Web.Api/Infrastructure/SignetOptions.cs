using System.Collections.Generic;

namespace SIGNET_Web.Api.Infrastructure
{
    public class SignetOptions
    {
        public string NombreSistema { get; set; } = "SIGNET";
        public string SetupXmlPath { get; set; }
        public List<BaseOptions> Bases { get; set; } = new List<BaseOptions>();
        public int SessionMinutes { get; set; } = 480;

        /// <summary>Permite ingresar con usuario "1" y clave "1" sin validar contra la base. Solo tiene efecto en entorno Development.</summary>
        public bool LoginDesarrollo { get; set; }
        public int MaxFilasBusqueda { get; set; } = 5000;
        public List<string> CamposOcultos { get; set; } = new List<string>();
        public Dictionary<string, string> Formularios { get; set; } = new Dictionary<string, string>();
        public LoginOptions Login { get; set; } = new LoginOptions();
        public ChatOptions Chat { get; set; } = new ChatOptions();
        public ContabilidadWorkerOptions ContabilidadWorker { get; set; } = new ContabilidadWorkerOptions();
    }
    public sealed class ContabilidadWorkerOptions
    {
        public bool Habilitado { get; set; }
        public int IntervaloSegundos { get; set; } = 30;
        public List<string> ConexionesVariables { get; set; } = new List<string>();
    }

    /// <summary>Asistente de datos con IA (proveedor compatible con la API de OpenAI: Gemini, OpenAI, Azure, Groq, Ollama...).</summary>
    /// <summary>
    /// Asistente de datos (IA). La configuración (clave, modelo, tope mensual, tablas excluidas, contexto) está en los
    /// parámetros del sistema IA_* de cada base, compartidos con el sistema de escritorio (VENET_IA).
    /// </summary>
    public class ChatOptions
    {
        /// <summary>Muestra el asistente en la web (además debe estar habilitado Menu_Sistema_AsistenteIA y el usuario tener permiso).</summary>
        public bool Habilitado { get; set; }
        /// <summary>Opcional: low / medium / high (reasoning_effort). Vacío = valor del proveedor.</summary>
        public string Razonamiento { get; set; }
    }

    /// <summary>Aspecto de la pantalla de ingreso (todo es opcional).</summary>
    public class LoginOptions
    {
        /// <summary>Imagen del panel izquierdo (svg, png, jpg, webp) o carpeta con varias: se elige una al azar en cada ingreso. Ruta absoluta o relativa a la carpeta del proyecto/ejecutable.</summary>
        public string Imagen { get; set; } = "Personalizacion\\Login";
        public string Titulo { get; set; }
        public string Mensaje { get; set; } = "Gestión integral de su empresa";
        /// <summary>Color de acento en hexadecimal, ej. #1d5fa8.</summary>
        public string Color { get; set; }
        public string Pie { get; set; }
    }

    public class BaseOptions
    {
        public string Name { get; set; }
        public string DataSource { get; set; }
        public string DataBase { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Provider { get; set; } = "System.Data.SqlClient";
    }
}
