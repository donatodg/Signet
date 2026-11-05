using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VENET_IA_BL
{
    /// <summary>Esquema de la base (tablas, columnas, relaciones y filas aproximadas) con caché por conexión.</summary>
    public class AsistenteIAEsquema
    {
        public class Tabla
        {
            public string Nombre { get; set; }
            public bool EsVista { get; set; }
            public long? Filas { get; set; }
            public List<string> Columnas { get; } = new List<string>();
            public List<string> Relaciones { get; } = new List<string>();
        }

        public DateTime Cargado { get; private set; }
        public Dictionary<string, Tabla> Tablas { get; } = new Dictionary<string, Tabla>(StringComparer.OrdinalIgnoreCase);

        private static readonly ConcurrentDictionary<string, AsistenteIAEsquema> Cache = new ConcurrentDictionary<string, AsistenteIAEsquema>();
        private static readonly TimeSpan Vigencia = TimeSpan.FromMinutes(30);

        /// <param name="claveExclusiones">Identifica el juego de exclusiones (si cambia, se recarga el esquema).</param>
        public static async Task<AsistenteIAEsquema> ObtenerAsync(string conexion, Func<string, bool> excluida, string claveExclusiones, CancellationToken ct)
        {
            var clave = conexion + "|" + claveExclusiones;
            AsistenteIAEsquema e;
            if (Cache.TryGetValue(clave, out e) && DateTime.UtcNow - e.Cargado < Vigencia) return e;
            e = await CargarAsync(conexion, excluida, ct);
            Cache[clave] = e;
            return e;
        }

        public static void LimpiarCache()
        {
            Cache.Clear();
        }

        /// <summary>Abre la conexión; si falla corta la pregunta (no tiene sentido seguir gastando tokens).</summary>
        internal static async Task<SqlConnection> AbrirAsync(string conexion, CancellationToken ct)
        {
            var cn = new SqlConnection(conexion);
            try
            {
                await cn.OpenAsync(ct);
                return cn;
            }
            catch (SqlException)
            {
                cn.Dispose();
                throw new AsistenteIAException(503, "No se pudo conectar con la base de datos. Verifique la conexión e intente nuevamente.");
            }
        }

        private static async Task<AsistenteIAEsquema> CargarAsync(string conexion, Func<string, bool> excluida, CancellationToken ct)
        {
            var e = new AsistenteIAEsquema { Cargado = DateTime.UtcNow };
            using (var cn = await AbrirAsync(conexion, ct))
            {
                using (var cmd = new SqlCommand(@"
SELECT t.TABLE_NAME, t.TABLE_TYPE, c.COLUMN_NAME, c.DATA_TYPE, c.IS_NULLABLE, c.CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.TABLES t
JOIN INFORMATION_SCHEMA.COLUMNS c ON c.TABLE_SCHEMA = t.TABLE_SCHEMA AND c.TABLE_NAME = t.TABLE_NAME
WHERE t.TABLE_SCHEMA = 'dbo'
ORDER BY t.TABLE_NAME, c.ORDINAL_POSITION", cn) { CommandTimeout = 60 })
                using (var r = await cmd.ExecuteReaderAsync(ct))
                {
                    while (await r.ReadAsync(ct))
                    {
                        var nombre = r.GetString(0);
                        if (excluida(nombre)) continue;
                        var columna = r.GetString(2);
                        if (excluida(columna)) continue;
                        if (!e.Tablas.TryGetValue(nombre, out var t))
                            e.Tablas[nombre] = t = new Tabla { Nombre = nombre, EsVista = r.GetString(1) == "VIEW" };
                        var tipo = r.GetString(3);
                        if (!r.IsDBNull(5) && (tipo.Contains("char") || tipo.Contains("binary")))
                            tipo += "(" + (r.GetInt32(5) == -1 ? "max" : r.GetInt32(5).ToString()) + ")";
                        t.Columnas.Add(columna + " " + tipo + (r.GetString(4) == "YES" ? " null" : ""));
                    }
                }

                // Relaciones y filas aproximadas: opcionales (un usuario de solo lectura puede no tener permiso).
                try
                {
                    using (var cmd = new SqlCommand(@"
SELECT OBJECT_NAME(fk.parent_object_id), COL_NAME(fkc.parent_object_id, fkc.parent_column_id),
       OBJECT_NAME(fk.referenced_object_id), COL_NAME(fkc.referenced_object_id, fkc.referenced_column_id)
FROM sys.foreign_keys fk JOIN sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id", cn) { CommandTimeout = 60 })
                    using (var r = await cmd.ExecuteReaderAsync(ct))
                        while (await r.ReadAsync(ct))
                            if (e.Tablas.TryGetValue(r.GetString(0), out var t) && !excluida(r.GetString(2)))
                                t.Relaciones.Add($"{r.GetString(1)} -> {r.GetString(2)}.{r.GetString(3)}");
                }
                catch (SqlException) { }

                try
                {
                    using (var cmd = new SqlCommand(@"
SELECT o.name, SUM(p.rows) FROM sys.partitions p JOIN sys.objects o ON o.object_id = p.object_id
WHERE p.index_id IN (0, 1) AND o.type = 'U' GROUP BY o.name", cn) { CommandTimeout = 60 })
                    using (var r = await cmd.ExecuteReaderAsync(ct))
                        while (await r.ReadAsync(ct))
                            if (e.Tablas.TryGetValue(r.GetString(0), out var t)) t.Filas = Convert.ToInt64(r.GetValue(1));
                }
                catch (SqlException) { }
            }
            return e;
        }

        public string Listar(string buscar)
        {
            var q = Tablas.Values.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(buscar))
            {
                var partes = buscar.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                q = q.Where(t => partes.Any(p => t.Nombre.IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0));
            }
            var lista = q.OrderBy(t => t.Nombre).ToList();
            if (lista.Count == 0) return "No hay tablas que coincidan.";
            return string.Join(", ", lista.Select(t => t.Nombre + (t.EsVista ? " (vista)" : t.Filas.HasValue ? $" ({t.Filas} filas)" : "")));
        }

        public string Describir(IEnumerable<string> nombres)
        {
            var sb = new StringBuilder();
            foreach (var n in nombres.Distinct(StringComparer.OrdinalIgnoreCase).Take(15))
            {
                if (!Tablas.TryGetValue(n.Trim().Trim('[', ']'), out var t)) { sb.AppendLine($"{n}: no existe o no está disponible."); continue; }
                sb.Append(t.Nombre).Append(t.EsVista ? " (vista)" : "").Append(": ").AppendLine(string.Join(", ", t.Columnas));
                if (t.Relaciones.Count > 0) sb.Append("  Relaciones: ").AppendLine(string.Join("; ", t.Relaciones));
            }
            return sb.ToString();
        }
    }


    public static class AsistenteIAConsulta
    {
        /// <summary>Ejecuta un SELECT validado dentro de una transacción que siempre se revierte.</summary>
        public static async Task<AsistenteIAResultado> EjecutarAsync(string conexion, string sql, int maxFilas, int timeoutSegundos, CancellationToken ct)
        {
            var res = new AsistenteIAResultado { Sql = sql };
            using (var cn = await AsistenteIAEsquema.AbrirAsync(conexion, ct))
            {
                using (var tx = cn.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        using (var cmd = new SqlCommand(sql, cn, tx) { CommandTimeout = timeoutSegundos })
                        using (var r = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult, ct))
                        {
                            for (int i = 0; i < r.FieldCount; i++) res.Columnas.Add(string.IsNullOrEmpty(r.GetName(i)) ? $"Columna{i + 1}" : r.GetName(i));
                            while (await r.ReadAsync(ct))
                            {
                                if (res.Filas.Count >= maxFilas) { res.Truncado = true; break; }
                                var fila = new object[r.FieldCount];
                                for (int i = 0; i < r.FieldCount; i++) fila[i] = Valor(r.GetValue(i));
                                res.Filas.Add(fila);
                            }
                        }
                    }
                    finally
                    {
                        tx.Rollback();
                    }
                }
            }
            return res;
        }

        private static object Valor(object v)
        {
            switch (v)
            {
                case DBNull _: return null;
                case byte[] _: return "(binario)";
                case string s when s.Length > 500: return s.Substring(0, 500) + "…";
                case Guid g: return g.ToString();
                case TimeSpan t: return t.ToString();
                case DateTimeOffset d: return d.DateTime;
                default: return v;
            }
        }
    }
}
