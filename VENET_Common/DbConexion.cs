namespace VENET_Common
{
    using System.Configuration;

    public class DbConexion
    {
        public static string ConnectionString { get; private set; }
        public static string Provider { get; private set; }
        public DbConexion(string datasource, string inicialcatalog, string pass, string user, string provider, string name)
        {
            Provider = provider;
            ConnectionString = string.Format("Data Source={0};Initial Catalog={1};user id={2}; password={3};Persist Security Info=True;Language=Spanish", datasource, inicialcatalog, user, pass);
            ConfigurationManager.AppSettings["CurrentConnection"] = new ConnectionStringSettings(name, DbConexion.ConnectionString, provider).ToString();

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.ConnectionStrings.ConnectionStrings.Remove(name);
            //config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(name, DbConexion.ConnectionString, provider));
            //config.ConnectionStrings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            //config.ConnectionStrings.SectionInformation.ForceSave = true;
            //config.Save();

            //ConfigurationManager.RefreshSection("connectionStrings");
            //ConfigurationManager.AppSettings["CurrentConnection"] = name;

        }

    }
}

