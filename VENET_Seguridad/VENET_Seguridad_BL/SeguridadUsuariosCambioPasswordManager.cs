namespace VENET_Seguridad_BL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class SeguridadUsuariosCambioPasswordManager : IDisposable
    {
        private SeguridadContext db;
        private SeguridadUsuarios Usuario { get; set; }
        public CambioPass CambioClave { get; set; }

        public SeguridadUsuariosCambioPasswordManager()
        {
            db = new SeguridadContext();
            Usuario = db.SeguridadUsuarios.Find(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]));
            CambioClave = new CambioPass();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (CambioClave.PassNueva != CambioClave.PassNueva2 || CambioClave.PassAnterior != Encriptor.DecryptCadena(Usuario.Clave))
                throw new ValidationException("Las contraseñas ingresadas no coinciden.");

            if (string.IsNullOrEmpty(CambioClave.PassNueva2))
                throw new ValidationException("Debe ingresar una contraseña.");

            db.Entry(Usuario).State = EntityState.Modified;

            Usuario.Clave = Encriptor.EncryptCadena(CambioClave.PassNueva2);
            Usuario.FechaMod = Sistema.ObtenerFechaHora();
            Usuario.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            //************************************************************************************
            if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_ClaveUnicaParaLosSistemas)))
            {
                string cnnstrRemoto = "Data Source=ersa05.dyndns.org,24643;Initial Catalog=Users;user id=desarrollo;password=Ersa.Grupo7521";
                //string cnnstrRemoto = "Data Source=Ersa01.dyndns.org,2123;Initial Catalog=ErsaGeneral;user id=ersa;password=1234";
                SqlConnection cnnRemoto = new SqlConnection(cnnstrRemoto);
                cnnRemoto.Open();

                string p = Encriptor.CalculateMD5Hash(CambioClave.PassNueva2);

                if (cnnRemoto.State == System.Data.ConnectionState.Closed) cnnRemoto.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnnRemoto;
                cmd.CommandText = string.Format("EXEC updatePassword '{0}','{1}','SIT','{2}'", Usuario.Username, p, DBNull.Value);
                //cmd.CommandText = string.Format("UPDATE USUARIOS SET [PASSWORD] = '{0}' WHERE [USUARIO] = '{1}'", p, Usuario.Username);
                cmd.ExecuteNonQuery();
            }
            //************************************************************************************

            db.SaveChanges();
        }

        public class CambioPass
        {
            public string PassAnterior { get; set; }
            public string PassNueva { get; set; }
            public string PassNueva2 { get; set; }
        }
    }
}
