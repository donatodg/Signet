using System;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using VENET_Common;

namespace SIGNET_Web.Api.Infrastructure
{
    /// <summary>Sesiones en memoria (token opaco -> SignetSession).</summary>
    public class SessionStore
    {
        private readonly ConcurrentDictionary<string, SignetSession> _sessions = new ConcurrentDictionary<string, SignetSession>(StringComparer.Ordinal);
        private readonly TimeSpan _timeout;
        private DateTime _lastCleanup = DateTime.UtcNow;

        public SessionStore(IOptions<SignetOptions> options)
        {
            _timeout = TimeSpan.FromMinutes(Math.Max(5, options.Value.SessionMinutes));
        }

        public SignetSession Create(NameValueCollection appSettings)
        {
            var bytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(bytes);
            string token = Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
            var s = new SignetSession(token, appSettings);
            _sessions[token] = s;
            return s;
        }

        public SignetSession Get(string token)
        {
            Cleanup();
            if (string.IsNullOrEmpty(token)) return null;
            if (!_sessions.TryGetValue(token, out var s)) return null;
            if (DateTime.UtcNow - s.LastAccessUtc > _timeout)
            {
                _sessions.TryRemove(token, out _);
                return null;
            }
            s.LastAccessUtc = DateTime.UtcNow;
            return s;
        }

        public void Remove(string token)
        {
            if (!string.IsNullOrEmpty(token)) _sessions.TryRemove(token, out _);
        }

        private void Cleanup()
        {
            if (DateTime.UtcNow - _lastCleanup < TimeSpan.FromMinutes(5)) return;
            _lastCleanup = DateTime.UtcNow;
            foreach (var kv in _sessions.Where(kv => DateTime.UtcNow - kv.Value.LastAccessUtc > _timeout).ToList())
                _sessions.TryRemove(kv.Key, out _);
        }
    }

    /// <summary>Limita intentos fallidos de login (el escritorio cerraba la app al 3er intento).</summary>
    public class LoginThrottle
    {
        private const int MaxIntentos = 5;
        private static readonly TimeSpan Bloqueo = TimeSpan.FromMinutes(5);
        private readonly ConcurrentDictionary<string, (int Fallos, DateTime Hasta)> _fallos = new ConcurrentDictionary<string, (int, DateTime)>();

        public bool EstaBloqueado(string clave)
        {
            return _fallos.TryGetValue(clave, out var f) && f.Fallos >= MaxIntentos && f.Hasta > DateTime.UtcNow;
        }

        public void RegistrarFallo(string clave)
        {
            _fallos.AddOrUpdate(clave, _ => (1, DateTime.UtcNow.Add(Bloqueo)),
                (_, f) => f.Hasta < DateTime.UtcNow ? (1, DateTime.UtcNow.Add(Bloqueo)) : (f.Fallos + 1, DateTime.UtcNow.Add(Bloqueo)));
        }

        public void Limpiar(string clave) => _fallos.TryRemove(clave, out _);
    }
}
