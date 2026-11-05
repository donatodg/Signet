namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class Config
    {
        public string Sistema { get; set; }
        public string Web { get; set; }
        public string LinkData { get; set; }
        public DateTime Fecha { get; set; }
        public List<ConfigBases> Bases { get; set; }

        public static Config ObtenerConfiguracion(string ruta, string xml)
        {
            try
            {
                XElement xDoc;
                try
                {
                    xDoc = XElement.Parse(Encriptor.DecryptFile(ruta + "/" + xml, ((char)78).ToString() + ((char)100).ToString() + ((char)74).ToString() + ((char)100).ToString() + ((char)73).ToString() + ((char)97).ToString() + ((char)85).ToString() + ((char)100).ToString()));
                }
                catch (Exception)
                {
                    xDoc = XElement.Parse(ruta + "/" + xml);
                }

                List<ConfigBases> r = (from x in xDoc.Descendants("configuracion")
                                       select new ConfigBases
                                       {
                                           Name = x.Element("Empresa").Value,
                                           DataSource = x.Element("DataSource").Value,
                                           DataBase = x.Element("BasedeDatos").Value,
                                           User = x.Element("User").Value,
                                           Pass = x.Element("Pass").Value,
                                           Provider = x.Element("Provider").Value
                                       }).ToList();

                Config result = new Config();
                try
                {
                    result.Sistema = (from x in xDoc.Descendants("Config") select x.Element("NombreSistema").Value).FirstOrDefault();
                    result.Web = (from x in xDoc.Descendants("Config") select x.Element("WEB").Value).FirstOrDefault();
                    result.LinkData = (from x in xDoc.Descendants("Config") select x.Element("LinkData").Value).FirstOrDefault();
                    result.Fecha = Convert.ToDateTime((from x in xDoc.Descendants("Config") select x.Element("Fecha").Value).FirstOrDefault());
                }
                catch (Exception) { }

                result.Bases = r;

                return result;

            }
            catch (Exception)
            {
                return new Config { };
            }
        }

        public static void GrabarConfiguracion(string ruta, string xml, Config c)
        {
            //Declaramos el documento y su definición
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", null));

            XElement nodoRaiz = new XElement("Bases");
            xDoc.Add(nodoRaiz);

            foreach (ConfigBases o in c.Bases.ToList())
            {
                //Creamos el nodo empleado y el contenido con sus nodos hijos
                XElement nodo = new XElement("configuracion");
                nodo.Add(new XElement("Empresa", o.Name));
                nodo.Add(new XElement("DataSource", o.DataSource));
                nodo.Add(new XElement("BasedeDatos", o.DataBase));
                nodo.Add(new XElement("User", o.User));
                nodo.Add(new XElement("Pass", o.Pass));
                nodo.Add(new XElement("Provider", o.Provider));

                //Añadirmos el nodo y escribimos en el documento
                nodoRaiz.Add(nodo);
            }

            XElement nodo1 = new XElement("Config");
            nodo1.Add(new XElement("NombreSistema", c.Sistema));
            nodo1.Add(new XElement("WEB", c.Web));
            nodo1.Add(new XElement("LinkData", c.LinkData));
            nodo1.Add(new XElement("Fecha", c.Fecha));
            nodoRaiz.Add(nodo1);

            Encriptor.EncryptString(xDoc.ToString(), ruta + "/" + xml, ((char)78).ToString() + ((char)100).ToString() + ((char)74).ToString() + ((char)100).ToString() + ((char)73).ToString() + ((char)97).ToString() + ((char)85).ToString() + ((char)100).ToString());
        }
    }

    public class ConfigBases
    {
        public string Name { get; set; }
        public string DataSource { get; set; }
        public string DataBase { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Provider { get; set; }

    }
}
