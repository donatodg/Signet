namespace VENET_Common
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using VENET_DataEntity;

    public class Funciones
    {
        Int32 Usuario;
        Int32 Accion;

       /// <summary>
        /// Accion: 1 = Ingreso, Accion: 0 = Egreso
       /// </summary>
       /// <param name="usuario"></param>
       /// <param name="accion"></param>
        public Funciones(Int32 usuario, Int32 accion)
        {
            Usuario = usuario;
            Accion = accion;
        }
        public static String GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return (from u in host.AddressList where (u.AddressFamily.ToString() == "InterNetwork") select (u)).FirstOrDefault().ToString();
        }

        public static String GetPublicIpAddress()
        {
            try
            {
                string url = "http://checkip.dyndns.org";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim().Split(':')[1].Split('<')[0].Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void GrabarLog()
        {
            try
            {
                SistemaLog o = new SistemaLog()
                {
                    Id_Usuario = Usuario,
                    Accion = Accion,
                    Fecha = Sistema.ObtenerFechaHora(),
                    Host = Environment.MachineName,
                    UserLocal = Environment.UserName,
                    IPLocal = Funciones.GetLocalIpAddress(),
                    BaseDatos = ConfigurationManager.AppSettings["CurrentEmpresa"]
                };
                if (Accion == 1)
                    o.IPPublica = Funciones.GetPublicIpAddress();
                else
                    o.IPPublica = "";

                SeguridadContext db = new SeguridadContext();
                db.SistemaLog.Attach(o);
                db.Entry(o).State = EntityState.Added;

                db.SaveChanges();
            }
            catch (Exception )
            {
            }
        }
    }
}
