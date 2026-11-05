namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    public class clsConfig
    {
        public String Name { get; set; }
        public String DataSource { get; set; }
        public String DataBase { get; set; }
        public String User { get; set; }
        public String Pass { get; set; }
        public String Provider { get; set; }

        public static List<clsConfig> ObtenerConfiguracion(String ruta, String xml)
        {
            try
            {
                XElement xDoc;
                try
                {
                    xDoc = XElement.Parse(clsEncriptor.DecryptFile(ruta + "/" + xml, "NdJdIaUd"));
                }
                catch (Exception)
                {
                    xDoc = XElement.Parse(ruta + "/" + xml);
                }

                return (from x in xDoc.Descendants("configuracion")
                        select new clsConfig
                        {
                            Name = x.Element("Empresa").Value,
                            DataSource = x.Element("DataSource").Value,
                            DataBase = x.Element("BasedeDatos").Value,
                            User = x.Element("User").Value,
                            Pass = x.Element("Pass").Value,
                            Provider = x.Element("Provider").Value
                        }).ToList();

            }
            catch (Exception)
            {
                return new List<clsConfig> { };
            }
        }

        public static void GrabarConfiguracion(String ruta, String xml, List<clsConfig> olist)
        {
            //Declaramos el documento y su definición
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", null));

            XElement nodoRaiz = new XElement("Bases");
            xDoc.Add(nodoRaiz);

            foreach (clsConfig o in olist.ToList())
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
            clsEncriptor.EncryptString(xDoc.ToString(), ruta + "/" + xml, "NdJdIaUd");
        }

    }
}
