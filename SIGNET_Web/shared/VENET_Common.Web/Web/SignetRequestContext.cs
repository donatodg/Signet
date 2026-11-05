namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Threading;
    using VENET_DataEntity;

    /// <summary>
    /// Estado de un usuario logueado en la web. Reemplaza el estado global (estático / AppSettings)
    /// que la aplicación de escritorio mantenía por proceso.
    /// </summary>
    public sealed class SignetSession
    {
        public SignetSession(string token, NameValueCollection appSettings)
        {
            Token = token;
            AppSettings = appSettings;
            LastAccessUtc = DateTime.UtcNow;
        }

        public string Token { get; private set; }

        /// <summary>Valores que el escritorio guardaba en ConfigurationManager.AppSettings (CurrentUserId, CurrentConnection, ...).</summary>
        public NameValueCollection AppSettings { get; private set; }

        public DateTime LastAccessUtc { get; set; }

        /// <summary>Datos de seguridad (permisos y asignaciones) del usuario. Lo carga <see cref="Seguridad.Reload"/>.</summary>
        public SeguridadState Seguridad { get; set; }

        public int UserId { get { int r; int.TryParse(AppSettings["CurrentUserId"], out r); return r; } }
        public string UserName { get { return AppSettings["CurrentUserName"]; } }
        public string Empresa { get { return AppSettings["CurrentEmpresa"]; } }
    }

    public sealed class SeguridadState
    {
        /// <summary>Sesión de desarrollo (login 1/1): administrador sin consultar permisos en la base.</summary>
        public bool Desarrollo { get; set; }

        public List<SeguridadObjetos> Objetos { get; set; }
        public SeguridadGrupos GrupoUsuario { get; set; }
        public List<int> IdEmpresasAsignadas { get; set; }
        public List<int> IdSucursalesAsignadas { get; set; }
        public List<int> IdCentrosCostosAsignados { get; set; }
        public List<int> IdPuntosVentasAsignados { get; set; }
        public List<int> IdCajasAsignadas { get; set; }
        public List<int> IdUnidadesNegociosAsignadas { get; set; }
        public List<int> IdDepositosAsignados { get; set; }
    }

    /// <summary>
    /// Contexto de la petición HTTP actual (fluye por async/await mediante AsyncLocal).
    /// </summary>
    public sealed class SignetRequestContext
    {
        private static readonly AsyncLocal<SignetRequestContext> _current = new AsyncLocal<SignetRequestContext>();

        public SignetRequestContext(SignetSession session, NameValueCollection appSettings)
        {
            Session = session;
            AppSettings = appSettings;
        }

        public static SignetRequestContext Current
        {
            get { return _current.Value; }
            set { _current.Value = value; }
        }

        /// <summary>Sesión autenticada (null durante el login).</summary>
        public SignetSession Session { get; set; }

        /// <summary>Copia por petición de los AppSettings, devuelta por ConfigurationManager.AppSettings.</summary>
        public NameValueCollection AppSettings { get; private set; }

        public static SignetSession RequireSession()
        {
            var c = Current;
            if (c == null || c.Session == null)
                throw new InvalidOperationException("No hay una sesión de usuario activa.");
            return c.Session;
        }
    }
}
