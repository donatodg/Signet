namespace VENET_Common
{
    public class ConfigManager  
    {
        public Config Confi { get; set; }
        public ConfigBases Conf { get; set; }

        public ConfigManager(ConfigBases o)
        {
            Conf = o;
        }

        public ConfigManager(Config o)
        {
            Confi = o;
        }

        public void Dispose()
        {
            Dispose();
        }

        public static void Save(Config o)
        {
            //Grabar en el archivo la lista
            Config.GrabarConfiguracion(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Setup.xml", o);
        }

    }
}
