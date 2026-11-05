using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace VENET_IA_BL
{
    /// <summary>
    /// Valida el SQL generado por la IA: una sola sentencia SELECT/WITH, sin comentarios, sin escritura,
    /// sin ejecución de procedimientos, sin acceso a otras bases y sin tablas excluidas.
    /// Además la consulta se ejecuta dentro de una transacción que siempre se revierte.
    /// </summary>
    public static class AsistenteIASqlGuard
    {
        private static readonly Regex Prohibidas = new Regex(
            @"\b(INSERT|UPDATE|DELETE|MERGE|DROP|ALTER|CREATE|TRUNCATE|EXEC|EXECUTE|GRANT|REVOKE|DENY|INTO|OPENROWSET|OPENDATASOURCE|OPENQUERY|OPENXML|BULK|BACKUP|RESTORE|DBCC|SHUTDOWN|KILL|WAITFOR|DECLARE|SET|USE|RECONFIGURE|CHECKPOINT|READTEXT|WRITETEXT|UPDATETEXT|GO|SP_\w*|XP_\w*)\b",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        private static readonly Regex Sistema = new Regex(@"\b(SYS|INFORMATION_SCHEMA|MASTER|MSDB|TEMPDB|MODEL)\s*\.", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        private static readonly Regex TresPartes = new Regex(@"[\w\]]\s*\.\s*[\w\[]*\]?\s*\.\s*[\w\[]", RegexOptions.CultureInvariant);
        private static readonly Regex Identificador = new Regex(@"\[([^\]]+)\]|""([^""]+)""|([A-Za-z_][\w]*)", RegexOptions.CultureInvariant);

        /// <summary>Devuelve el SQL listo para ejecutar (sin comentarios) o lanza ArgumentException con el motivo.</summary>
        public static string Validar(string sql, Func<string, bool> tablaExcluida)
        {
            if (string.IsNullOrWhiteSpace(sql)) throw new ArgumentException("La consulta está vacía.");
            if (sql.Length > 8000) throw new ArgumentException("La consulta es demasiado larga.");

            Separar(sql, out var ejecutable, out var analisis);
            ejecutable = ejecutable.Trim();
            analisis = analisis.Trim();
            while (analisis.EndsWith(";"))
            {
                analisis = analisis.Substring(0, analisis.Length - 1).TrimEnd();
                ejecutable = ejecutable.Substring(0, ejecutable.LastIndexOf(';')).TrimEnd();
            }

            if (!Regex.IsMatch(analisis, @"^(SELECT|WITH)\b", RegexOptions.IgnoreCase))
                throw new ArgumentException("Solo se permiten consultas SELECT (o WITH ... SELECT).");
            if (analisis.Contains(";")) throw new ArgumentException("Solo se permite una sentencia por consulta.");
            var m = Prohibidas.Match(analisis);
            if (m.Success) throw new ArgumentException($"Palabra no permitida en la consulta: {m.Value.ToUpperInvariant()}.");
            if (Sistema.IsMatch(analisis)) throw new ArgumentException("No se permite consultar objetos del sistema ni otras bases.");
            if (TresPartes.IsMatch(analisis)) throw new ArgumentException("No se permiten nombres de 3 o más partes (base.esquema.tabla). Use alias de tabla.");

            foreach (Match id in Identificador.Matches(analisis))
            {
                var nombre = id.Groups[1].Success ? id.Groups[1].Value : id.Groups[2].Success ? id.Groups[2].Value : id.Groups[3].Value;
                if (tablaExcluida(nombre.Trim())) throw new ArgumentException($"La tabla o columna {nombre} no está disponible para el asistente.");
            }
            return ejecutable;
        }

        /// <summary>
        /// ejecutable: SQL sin comentarios (los literales se conservan).
        /// analisis: igual pero con el contenido de los literales vaciado, para buscar palabras clave sin falsos positivos.
        /// </summary>
        private static void Separar(string sql, out string ejecutable, out string analisis)
        {
            var e = new StringBuilder(sql.Length);
            var a = new StringBuilder(sql.Length);
            int i = 0;
            while (i < sql.Length)
            {
                char c = sql[i];
                char n = i + 1 < sql.Length ? sql[i + 1] : '\0';
                if (c == '-' && n == '-')
                {
                    while (i < sql.Length && sql[i] != '\n') i++;
                    e.Append(' '); a.Append(' ');
                }
                else if (c == '/' && n == '*')
                {
                    int fin = sql.IndexOf("*/", i + 2, StringComparison.Ordinal);
                    if (fin < 0) throw new ArgumentException("Comentario sin cerrar.");
                    i = fin + 2;
                    e.Append(' '); a.Append(' ');
                }
                else if (c == '\'')
                {
                    int j = i + 1;
                    while (true)
                    {
                        if (j >= sql.Length) throw new ArgumentException("Texto entre comillas sin cerrar.");
                        if (sql[j] == '\'')
                        {
                            if (j + 1 < sql.Length && sql[j + 1] == '\'') { j += 2; continue; }
                            break;
                        }
                        j++;
                    }
                    e.Append(sql, i, j - i + 1);
                    a.Append("''");
                    i = j + 1;
                }
                else if (c == '[' || c == '"')
                {
                    char cierre = c == '[' ? ']' : '"';
                    int fin = sql.IndexOf(cierre, i + 1);
                    if (fin < 0) throw new ArgumentException("Identificador sin cerrar.");
                    e.Append(sql, i, fin - i + 1);
                    a.Append(sql, i, fin - i + 1);
                    i = fin + 1;
                }
                else
                {
                    e.Append(c); a.Append(c);
                    i++;
                }
            }
            ejecutable = e.ToString();
            analisis = a.ToString();
        }

        /// <summary>Patrones simples con * como comodín.</summary>
        public static Func<string, bool> Excluidas(IEnumerable<string> patrones)
        {
            var regex = new List<Regex>();
            foreach (var p in patrones)
            {
                if (string.IsNullOrWhiteSpace(p)) continue;
                regex.Add(new Regex("^" + Regex.Escape(p.Trim()).Replace(@"\*", ".*") + "$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant));
            }
            return nombre => regex.Exists(r => r.IsMatch(nombre));
        }
    }
}
