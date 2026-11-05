using System;
using System.Collections.Generic;

namespace VENET_IA_BL
{
    public class AsistenteIAMensaje
    {
        public const string RolUsuario = "usuario";
        public const string RolAsistente = "asistente";

        /// <summary>"usuario" o "asistente".</summary>
        public string Rol { get; set; }
        public string Texto { get; set; }
    }

    public class AsistenteIAResultado
    {
        public string Sql { get; set; }
        public List<string> Columnas { get; set; } = new List<string>();
        public List<object[]> Filas { get; set; } = new List<object[]>();
        public bool Truncado { get; set; }
    }

    public class AsistenteIARespuesta
    {
        public string Respuesta { get; set; }
        public AsistenteIAResultado Resultado { get; set; }
        public List<string> Consultas { get; set; } = new List<string>();
        public long TokensPregunta { get; set; }
        public long TokensMes { get; set; }
        public long LimiteMes { get; set; }
        public AsistenteIAVentaBorrador Venta { get; set; }
    }

    /// <summary>
    /// Error del asistente para mostrar al usuario. Codigo sigue la convención HTTP
    /// (400 pregunta inválida, 429 límite, 502/504 servicio de IA, 503 configuración o base).
    /// </summary>
    public class AsistenteIAException : Exception
    {
        public int Codigo { get; private set; }

        public AsistenteIAException(int codigo, string mensaje) : base(mensaje)
        {
            Codigo = codigo;
        }
    }
}
