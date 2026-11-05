using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using VENET_Common;

namespace VENET_IA_BL
{
    /// <summary>
    /// Configuración del asistente IA. Se guarda en la tabla Parametros (módulo Sistema) de cada base,
    /// así la comparten el sistema de escritorio y la web. Los valores se leen siempre de la base (sin caché).
    /// </summary>
    public class AsistenteIAConfiguracion
    {
        public const int MaxPasos = 8;
        public const long MaxTokensPorPregunta = 60000;
        public const int MaxFilas = 500;
        public const int FilasParaIA = 50;
        public const int TimeoutSegundos = 30;

        private static readonly string[] ExcluidasSiempre = { "Seguridad*", "__*", "sysdiagrams", "*Password*", "Parametros" };

        private static readonly Parametro.Param[] Todos =
        {
            Parametro.Param.IA_ApiKey, Parametro.Param.IA_Url, Parametro.Param.IA_Modelo, Parametro.Param.IA_LimiteTokensMes,
            Parametro.Param.IA_ConsumoTokensMes, Parametro.Param.IA_TablasExcluidas, Parametro.Param.IA_Contexto, Parametro.Param.IA_ConexionSoloLectura
        };

        /// <summary>Conexión del sistema (donde están los Parametros).</summary>
        public string ConexionSistema { get; private set; }
        /// <summary>Conexión para las consultas de la IA (la de solo lectura si está configurada).</summary>
        public string ConexionConsultas { get; private set; }
        public string ApiKey { get; private set; }
        public string Url { get; private set; }
        public string Modelo { get; private set; }
        public long LimiteTokensMes { get; private set; }
        public string Contexto { get; private set; }
        public List<string> TablasExcluidas { get; private set; }
        /// <summary>Opcional (no está en Parametros): "low", "medium", "high" para modelos con razonamiento.</summary>
        public string Razonamiento { get; set; }

        public bool Configurado
        {
            get { return !string.IsNullOrEmpty(ApiKey) && !string.IsNullOrWhiteSpace(Url) && !string.IsNullOrWhiteSpace(Modelo); }
        }

        public Func<string, bool> Excluida { get; private set; }
        internal string ClaveExclusiones { get; private set; }

        /// <summary>Lee los parámetros IA_* de la base (los crea con sus valores por defecto si no existen).</summary>
        public static AsistenteIAConfiguracion Cargar(string conexion = null)
        {
            conexion = string.IsNullOrWhiteSpace(conexion) ? ConfigurationManager.AppSettings["CurrentConnection"] : conexion;
            if (string.IsNullOrWhiteSpace(conexion))
                throw new AsistenteIAException(503, "No hay una conexión a la base de datos.");

            var valores = Leer(conexion);
            if (Todos.Any(p => !valores.ContainsKey(p.ToString())))
            {
                foreach (var p in Todos.Where(p => !valores.ContainsKey(p.ToString())))
                {
                    // Parametro.ObtenerValor crea el parámetro con su valor por defecto (visible en Parámetros del sistema).
                    try { Parametro.ObtenerValor(p); } catch (Exception) { }
                }
                valores = Leer(conexion);
            }

            Func<Parametro.Param, string> valor = p =>
            {
                string v;
                return valores.TryGetValue(p.ToString(), out v) ? Limpiar(v) : null;
            };

            long limite;
            var c = new AsistenteIAConfiguracion
            {
                ConexionSistema = conexion,
                ApiKey = valor(Parametro.Param.IA_ApiKey),
                Url = valor(Parametro.Param.IA_Url) ?? "https://generativelanguage.googleapis.com/v1beta/openai/",
                Modelo = valor(Parametro.Param.IA_Modelo) ?? "gemini-2.5-flash",
                LimiteTokensMes = long.TryParse(valor(Parametro.Param.IA_LimiteTokensMes), NumberStyles.Integer, CultureInfo.InvariantCulture, out limite) ? Math.Max(0, limite) : 1000000,
                Contexto = valor(Parametro.Param.IA_Contexto)
            };
            var soloLectura = valor(Parametro.Param.IA_ConexionSoloLectura);
            c.ConexionConsultas = string.IsNullOrEmpty(soloLectura) ? conexion : soloLectura;
            c.TablasExcluidas = (valor(Parametro.Param.IA_TablasExcluidas) ?? "")
                .Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).Where(t => t.Length > 0).ToList();
            c.ClaveExclusiones = string.Join(";", c.TablasExcluidas);
            c.Excluida = AsistenteIASqlGuard.Excluidas(ExcluidasSiempre.Concat(c.TablasExcluidas));
            return c;
        }

        /// <summary>Valores "vacíos" de un parámetro (Valor es obligatorio en la tabla, por eso se usa "-").</summary>
        private static string Limpiar(string v)
        {
            v = v == null ? null : v.Trim();
            if (string.IsNullOrEmpty(v) || v == "-" || v == "********" || v.Equals("SinConfigurar", StringComparison.OrdinalIgnoreCase)) return null;
            return v;
        }

        private static Dictionary<string, string> Leer(string conexion)
        {
            var d = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            try
            {
                using (var cn = new SqlConnection(conexion))
                using (var cmd = new SqlCommand("SELECT Nombre, Valor FROM Parametros WHERE Nombre LIKE 'IA[_]%'", cn))
                {
                    cn.Open();
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            d[r.GetString(0)] = r.IsDBNull(1) ? null : r.GetString(1);
                }
            }
            catch (SqlException)
            {
                throw new AsistenteIAException(503, "No se pudo conectar con la base de datos. Verifique la conexión e intente nuevamente.");
            }
            return d;
        }

        private static string Mes
        {
            get { return DateTime.Now.ToString("yyyy-MM", CultureInfo.InvariantCulture); }
        }

        /// <summary>Tokens consumidos en el mes actual (formato del parámetro: AAAA-MM|tokens).</summary>
        public long TokensDelMes()
        {
            try
            {
                using (var cn = new SqlConnection(ConexionSistema))
                using (var cmd = new SqlCommand("SELECT Valor FROM Parametros WHERE Nombre = @n", cn))
                {
                    cmd.Parameters.AddWithValue("@n", Parametro.Param.IA_ConsumoTokensMes.ToString());
                    cn.Open();
                    return Interpretar(cmd.ExecuteScalar() as string);
                }
            }
            catch (SqlException)
            {
                return 0;
            }
        }

        private static long Interpretar(string valor)
        {
            long t;
            if (string.IsNullOrEmpty(valor) || !valor.StartsWith(Mes + "|", StringComparison.Ordinal)) return 0;
            return long.TryParse(valor.Substring(8), NumberStyles.Integer, CultureInfo.InvariantCulture, out t) ? t : 0;
        }

        /// <summary>Suma tokens al consumo del mes en forma atómica (lo comparten todas las PCs y la web) y devuelve el total.</summary>
        public long SumarTokens(long tokens)
        {
            if (tokens <= 0) return TokensDelMes();
            try
            {
                using (var cn = new SqlConnection(ConexionSistema))
                using (var cmd = new SqlCommand(@"
UPDATE Parametros SET Valor =
    CASE WHEN Valor LIKE @mes + '|%' AND TRY_CAST(SUBSTRING(Valor, 9, 20) AS bigint) IS NOT NULL
         THEN @mes + '|' + CAST(TRY_CAST(SUBSTRING(Valor, 9, 20) AS bigint) + @t AS varchar(20))
         ELSE @mes + '|' + CAST(@t AS varchar(20)) END
OUTPUT inserted.Valor
WHERE Nombre = @n", cn))
                {
                    cmd.Parameters.AddWithValue("@mes", Mes);
                    cmd.Parameters.AddWithValue("@t", tokens);
                    cmd.Parameters.AddWithValue("@n", Parametro.Param.IA_ConsumoTokensMes.ToString());
                    cn.Open();
                    return Interpretar(cmd.ExecuteScalar() as string);
                }
            }
            catch (SqlException)
            {
                return 0;
            }
        }
    }
}
