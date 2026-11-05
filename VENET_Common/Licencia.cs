namespace VENET_Common
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Principal;
    using System.Text;
    using System.Xml.Linq;

    public class Licencia
    {
        private string Pass = "zoe+789632178";
        public string Key { get; private set; }
        public string Lic { get { return StringToGUID(Key + "ViSuAlOzOnO"); } }

        public Licencia() { Key = ObtenerKey(); }

        private string ObtenerKey()
        {

            // Usa el Id del Disco Rigido // 
            //ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            //ManagementObjectCollection mcol = mangnmt.GetInstances();
            //string result = "";
            //foreach (ManagementObject strt in mcol)
            //{
            //    result += Convert.ToString(strt["VolumeSerialNumber"]);
            //}
            //return StringToGUID(result);
            // ------------------------- //

            //Devuelve el Id del usuario
            return StringToGUID(WindowsIdentity.GetCurrent().User.Value + "ViSuAlOzOnO");
        }

        private string StringToGUID(string value)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            return new Guid(data).ToString();
        }

        public bool EstaActivada()
        {
            if (System.IO.File.Exists("Licencias.lic"))
            {
                XDocument xDoc = XDocument.Parse(Encriptor.DecryptFile("Licencias.lic", "", Pass));
                var c = (from x in xDoc.Descendants("Licencia") where (string)x.Element("Key") == Key && (string)x.Element("ActivationCode") == Lic select x).FirstOrDefault();
                if (c == null)
                {
                    throw new ValidationException("El equipo no se encuentra activado.");
                }
                return true;
            }
            else
            {
                throw new ValidationException("No se encuentra el archivo de licencias.");
            }
        }

        public bool Activar(string clave, string licencia)
        {
            if (Lic != licencia) throw new ValidationException("El código de activación no coincide con la clave.");

            if (System.IO.File.Exists("Licencias.lic"))
            {
                XDocument xDoc = XDocument.Parse(Encriptor.DecryptFile("Licencias.lic", "", Pass));

                var c = (from x in xDoc.Descendants("Licencia") where (string)x.Element("Key") == clave.ToString() && (string)x.Element("ActivationCode") == licencia.ToString() select x).FirstOrDefault();
                if (c != null)
                {
                    throw new ValidationException("El equipo ya se encuentra activado.");
                }
                else
                {
                    //no encontro la key
                    xDoc.Descendants("VisualOzonoNET").FirstOrDefault().Add(
                        new XElement("Licencia",
                            new XElement("Key", clave.ToString()),
                            new XElement("ActivationCode", licencia.ToString())));
                    Encriptor.EncryptString(xDoc.ToString(), "Licencias.lic", Pass);
                }
            }
            else
            {
                XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", null),
                    new XElement("VisualOzonoNET",
                     new XElement("Licencia",
                         new XElement("Key", clave.ToString()),
                         new XElement("ActivationCode", licencia.ToString()))));
                xDoc.Save("Licencias.lic", SaveOptions.None);

                Encriptor.EncryptString(xDoc.ToString(), "Licencias.lic", Pass);

            }
            return true;
        }
    }
}
