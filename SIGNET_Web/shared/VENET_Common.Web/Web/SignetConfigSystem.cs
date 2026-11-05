namespace VENET_Common
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Configuration.Internal;
    using System.Reflection;

    /// <summary>
    /// El código original (BL, DataEntity, Common) lee y escribe el estado del usuario en
    /// ConfigurationManager.AppSettings (CurrentUserId, CurrentConnection, ...), que es global al proceso.
    /// Este proxy hace que ConfigurationManager.AppSettings devuelva la colección de la petición actual,
    /// de modo que varios usuarios / bases puedan usar la web en simultáneo sin modificar el código original.
    /// </summary>
    public sealed class SignetConfigSystem : IInternalConfigSystem
    {
        private static readonly object _sync = new object();
        private readonly IInternalConfigSystem _inner;

        private SignetConfigSystem(IInternalConfigSystem inner)
        {
            _inner = inner;
        }

        private static FieldInfo ConfigSystemField
        {
            get { return typeof(ConfigurationManager).GetField("s_configSystem", BindingFlags.Static | BindingFlags.NonPublic); }
        }

        public static void Install()
        {
            lock (_sync)
            {
                // Fuerza la inicialización del sistema de configuración original.
                var _ = ConfigurationManager.AppSettings;

                FieldInfo field = ConfigSystemField;
                if (field == null) throw new InvalidOperationException("No se pudo instalar SignetConfigSystem (campo s_configSystem no encontrado).");

                var current = (IInternalConfigSystem)field.GetValue(null);
                if (current is SignetConfigSystem) return;

                field.SetValue(null, new SignetConfigSystem(current));
            }
        }

        /// <summary>AppSettings del archivo .config del proceso (sin el proxy).</summary>
        public static NameValueCollection ProcessAppSettings
        {
            get
            {
                FieldInfo field = ConfigSystemField;
                var cs = field != null ? field.GetValue(null) as SignetConfigSystem : null;
                if (cs != null) return (NameValueCollection)cs._inner.GetSection("appSettings");
                return ConfigurationManager.AppSettings;
            }
        }

        public object GetSection(string configKey)
        {
            if (configKey == "appSettings")
            {
                var ctx = SignetRequestContext.Current;
                if (ctx != null) return ctx.AppSettings;
            }
            return _inner.GetSection(configKey);
        }

        public void RefreshConfig(string sectionName)
        {
            _inner.RefreshConfig(sectionName);
        }

        public bool SupportsUserConfig
        {
            get { return _inner.SupportsUserConfig; }
        }
    }
}
