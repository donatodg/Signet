namespace VENET_Common
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using VENET_DataEntity;

    public class FuncionesLog
    {
        int Usuario;
        int Accion;

        /// <summary>
        /// Accion: 1 = Ingreso, Accion: 0 = Egreso
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="accion"></param>
        public FuncionesLog(int usuario, int accion)
        {
            Usuario = usuario;
            Accion = accion;
        }
        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return (from u in host.AddressList where (u.AddressFamily.ToString() == "InterNetwork") select (u)).FirstOrDefault().ToString();
        }

        public static string GetPublicIpAddress()
        {
            try
            {
                string url = "http://checkip.dyndns.org";
                WebRequest req = WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
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
                    IPLocal = GetLocalIpAddress(),
                    BaseDatos = ConfigurationManager.AppSettings["CurrentEmpresa"],
                    VersionSistema = ConfigurationManager.AppSettings["CurrentVersion"]
                };
                if (Accion == 1)
                    o.IPPublica = GetPublicIpAddress();
                else
                    o.IPPublica = "";

                SeguridadContext db = new SeguridadContext();
                db.SistemaLog.Attach(o);
                db.Entry(o).State = EntityState.Added;

                db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
    }
}
