namespace VENET_Common
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using VENET_DataEntity;

    public class LoginManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuarios Usuario { get; set; }

        public LoginManager()
        { }

        public LoginManager(string UserName, string Pass)
        {
            db = new SeguridadContext();
            Usuario = new SeguridadUsuarios() { Username = UserName, Clave = Pass };
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        private bool _EsAdministrador;
        public bool EsAdministrador { get { return _EsAdministrador; } private set { _EsAdministrador = value; } }

        public bool VerificaUsuario()
        {
            if (string.IsNullOrEmpty(Usuario.Username)) throw new ValidationException("Debe ingresar un nombre de usuario.");
            if (string.IsNullOrEmpty(Usuario.Clave)) throw new ValidationException("Debe ingresar una clave.");

            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_ClaveUnicaParaLosSistemas)))
            {
                string pass = Encriptor.EncryptCadena(Usuario.Clave);

                Usuario.Id = (from u in db.SeguridadUsuarios where u.Username == Usuario.Username && u.Clave == pass && u.Activo == true select u.Id).FirstOrDefault();

                if (Usuario.Id > 0)
                {
                    SeguridadUsuarios u = new SeguridadUsuarios() { Id = Usuario.Id };
                    db.SeguridadUsuarios.Attach(u);
                    db.Entry(u).Reload();
                    EsAdministrador = db.SeguridadGrupos.Where(t => t.Id == u.Id_Grupo).Select(t => t.EsAdministrador).FirstOrDefault();

                    Usuario = u;

                    return true;
                }
                else
                    return false;
            }
            else
            {
                //************************************************************************************
                //ersa03.dyndns.org,15003 -- 186.122.161.36
                string cnnstrRemoto = "Data Source=ersa05.dyndns.org,24643;Initial Catalog=Users;user id=desarrollo;password=Ersa.Grupo7521";
                //string cnnstrRemoto = "Data Source=181.14.247.42,2123;Initial Catalog=ErsaGeneral;user id=ersa;password=1234";
                SqlConnection cnnRemoto = new SqlConnection(cnnstrRemoto);
                cnnRemoto.Open();

                string p = Encriptor.CalculateMD5Hash(Usuario.Clave);

                if (cnnRemoto.State == ConnectionState.Closed) cnnRemoto.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnnRemoto;
                //cmd.CommandText = string.Format("SELECT idUsuario FROM USUARIOS WHERE USUARIO = '{0}' AND [PASSWORD] = '{1}'", Usuario.Username, p);
                cmd.CommandText = string.Format("EXEC VerificaUsuario '{0}','{1}','SIT'", Usuario.Username, p);

                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    //************************************************************************************
                    string pass = Encriptor.EncryptCadena(Usuario.Clave);

                    //Usuario.Id = (from u in db.SeguridadUsuarios where u.Username == Usuario.Username && u.Clave == pass && u.Activo == true select u.Id).FirstOrDefault();
                    Usuario.Id = (from u in db.SeguridadUsuarios where u.Username == Usuario.Username && u.Activo == true select u.Id).FirstOrDefault();

                    if (Usuario.Id > 0)
                    {
                        SeguridadUsuarios u = new SeguridadUsuarios() { Id = Usuario.Id };
                        db.SeguridadUsuarios.Attach(u);
                        db.Entry(u).Reload();
                        EsAdministrador = db.SeguridadGrupos.Where(t => t.Id == u.Id_Grupo).Select(t => t.EsAdministrador).FirstOrDefault();
                        //**************
                        u.Clave = pass;
                        //**************
                        Usuario = u;

                        db.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        public void ObtenerFechaHora()
        {
            try
            {
                db.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
            }
            catch (Exception)
            {
            }
        }

        public void InicializarContextos()
        {
            try
            {
                using (var db = new ErsaContext())
                {
                    db.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
                }
                using (var db = new GeneralContext())
                {
                    db.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
                }
                using (var db = new GestionContext())
                {
                    db.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
                }
                using (var db = new PersonalContext())
                {
                    db.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
                }
                using (var db = new SeguridadContext())
                {
                    db.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
                }
                using (var db = new TesoreriaContext())
                {
                    db.Database.SqlQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
                }
            }
            catch (Exception)
            {
            }
        }

        public void VerificaLogError()
        {
            try
            {
                if (new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).GetFiles("LogError.txt").FirstOrDefault().Length > 10485760)
                    System.IO.File.Move(AppDomain.CurrentDomain.BaseDirectory + "LogError" + ".txt", AppDomain.CurrentDomain.BaseDirectory + "LogError_" + Sistema.ObtenerFechaHora().ToString("ddMMyyyyHHmm") + ".txt");
            }
            catch (Exception) { }
        }

        public void Backup()
        {
            try
            {
                int exitCode;
                ProcessStartInfo processInfo;
                Process process;

                string ruta;
                ruta = Parametro.ObtenerValor(Parametro.Param.Ruta_Backup_Sistema);

                processInfo = new ProcessStartInfo("cmd.exe", "/c \"" + ruta + "\"");
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                // *** Redirect the output ***
                // processInfo.RedirectStandardError = true;
                //processInfo.RedirectStandardOutput = true;

                process = Process.Start(processInfo);
                process.WaitForExit();

                // *** Read the streams ***
                // Warning: This approach can lead to deadlocks, see Edit #2
                //string output = process.StandardOutput.ReadToEnd();
                //string error = process.StandardError.ReadToEnd();

                exitCode = process.ExitCode;

                //Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
                //Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
                //Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
                process.Close();
            }
            catch (Exception e)
            {
                Sistema.Mensaje("Error al realizar backup.", "Atención", e, false);
            }
        }
    }
}
