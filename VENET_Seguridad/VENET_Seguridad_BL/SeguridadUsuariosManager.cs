namespace VENET_Seguridad_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class SeguridadUsuariosManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuarios Usuario { get; set; }

        public SeguridadUsuariosManager(SeguridadUsuarios o)
        {
            db = new SeguridadContext();
            Usuario = o;

            db.SeguridadUsuarios.Attach(Usuario);

            if (Usuario.Id > 0)
            {
                db.Entry(Usuario).Reload();
                Usuario.Clave = Encriptor.DecryptCadena(Usuario.Clave);
            }
            else Usuario.Activo = true;
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<KeyNamePair> Grupos { get { return db.SeguridadGrupos.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Key).ToList(); } }

        public void Save()
        {
            string p = Encriptor.CalculateMD5Hash(Usuario.Clave);
            Usuario.Clave = Encriptor.EncryptCadena(Usuario.Clave);

            if (db.SeguridadUsuarios.Where(t => t.Username == Usuario.Username && t.Id != Usuario.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("Ya existe un usuario con el mismo nombre.");

            if (Usuario.Id == 0)
            {
                db.Entry(Usuario).State = EntityState.Added;

                Usuario.FechaAdd = Sistema.ObtenerFechaHora();
                Usuario.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                //if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_ClaveUnicaParaLosSistemas)))
                //{
                //    string cnnstrRemoto = "Data Source=186.122.161.36,15003;Initial Catalog=Users;user id=desarrollo;password=Ersa.Grupo7521";
                //    //string cnnstrRemoto = "Data Source=181.14.247.42,2123;Initial Catalog=ErsaGeneral;user id=ersa;password=1234";
                //    System.Data.SqlClient.SqlConnection cnnRemoto = new System.Data.SqlClient.SqlConnection(cnnstrRemoto);
                //    cnnRemoto.Open();

                //    if (cnnRemoto.State == System.Data.ConnectionState.Closed) cnnRemoto.Open();
                //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                //    cmd.Connection = cnnRemoto;

                //    cmd.CommandText = string.Format("EXEC insertUsuario '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','SIT'", Usuario.Username, p, Usuario.Nombre, Usuario.Apellido, 0, null, 0, 0, 0, 0, 1);
                //    //cmd.CommandText = string.Format("INSERT INTO Usuarios (Usuario, [password], Rol, [session], pantallas, regiones, Mensajes, tipoMensaje, versionSoft, DescripcionRol, ultimoLogin, menuActivo, ip) VALUES('{0}', '{1}', 0, 0, '00000000', '00000000', '', '-1', '02.61', Null, Null, Null, Null)", Usuario.Username, p);

                //    cmd.ExecuteNonQuery();
                //}
            }
            else
            {
                db.Entry(Usuario).State = EntityState.Modified;
                Usuario.FechaMod = Sistema.ObtenerFechaHora();
                Usuario.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_ClaveUnicaParaLosSistemas)))
                {
                    string cnnstrRemoto = "Data Source=ersa05.dyndns.org,24643;Initial Catalog=Users;user id=desarrollo;password=Ersa.Grupo7521";
                    //string cnnstrRemoto = "Data Source=181.14.247.42,2123;Initial Catalog=ErsaGeneral;user id=ersa;password=1234";
                    System.Data.SqlClient.SqlConnection cnnRemoto = new System.Data.SqlClient.SqlConnection(cnnstrRemoto);
                    cnnRemoto.Open();

                    if (cnnRemoto.State == System.Data.ConnectionState.Closed) cnnRemoto.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = cnnRemoto;
                    cmd.CommandText = string.Format("EXEC updatePassword '{0}','{1}','SIT','{2}'", Usuario.Username, p, null);
                    //cmd.CommandText = string.Format("UPDATE Usuarios SET [password] = '{0}' where usuario = '{1}'", p, Usuario.Username);

                    cmd.ExecuteNonQuery();
                }
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(SeguridadUsuarios o)
        {
            using (var db = new SeguridadContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = Sistema.ObtenerFechaHora();

                db.SaveChanges();
            }
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new SeguridadContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from u in db.SeguridadUsuarios
                     join g in db.SeguridadGrupos on u.Id_Grupo equals g.Id into listGrupo
                     from grup in listGrupo.DefaultIfEmpty()
                     where (u.Id == parametros.Id || parametros.Id == null)
                   && (u.Username.Contains(parametros.Usuario) || parametros.Usuario == null)
                   && (u.Apellido.Contains(parametros.Apellido) || parametros.Apellido == null)
                   && (u.Nombre.Contains(parametros.Nombre) || parametros.Nombre == null)
                   && (u.Activo == parametros.Activo || parametros.Activo == true)
                   && (u.UserDel == null)
                     select new SearchResult
                     {
                         Id = u.Id,
                         Id_Grupo = u.Id_Grupo,
                         Username = u.Username,
                         Apellido = u.Apellido,
                         Nombre = u.Nombre,
                         Activo = u.Activo,
                         Legajo = u.Legajo,
                         Email = u.Email,
                         UserAdd = u.UserAdd,
                         UserMod = u.UserMod,
                         FechaAdd = u.FechaAdd,
                         FechaMod = u.FechaMod,
                         Grupo = grup.Descripcion,
                         Foto = u.Foto
                     }).ToList();
                return r;

            }
        }

        public static void Restablecer(int Id_Usuario)
        {
            using (var db = new SeguridadContext())
            {
                SeguridadUsuarios u;

                u = db.SeguridadUsuarios.Find(Id_Usuario);

                u.Tema = null;
                u.BackColor = null;
                u.BackImage = null;
                u.RibbonMinimizado = false;
                u.TituloTile = false;
                u.TileConfig = null;

                var query = from c in db.SeguridadUsuariosConfiguracion
                            where c.Id_Usuario == Id_Usuario
                            select c;

                foreach (SeguridadUsuariosConfiguracion suc in query)
                {
                    db.SeguridadUsuariosConfiguracion.Attach(suc);
                    db.Entry(suc).State = EntityState.Deleted;
                }

                var query1 = from i in db.SeguridadUsuariosIndicadores
                             where i.Id_SeguridadUsuario == Id_Usuario
                             select i;

                foreach (SeguridadUsuariosIndicadores i in query1)
                {
                    db.SeguridadUsuariosIndicadores.Attach(i);
                    db.Entry(i).State = EntityState.Deleted;
                }

                db.SaveChanges();

                if (Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]) == Id_Usuario)
                    ConfigurationManager.AppSettings["GuardarConfiguracion"] = "0";
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Activo = true;
            }
            public int? Id { get; set; }
            public string Usuario { get; set; }
            public string Apellido { get; set; }
            public string Nombre { get; set; }
            public bool Activo { get; set; }
        }

        public class SearchResult : SeguridadUsuarios
        {
            public string Grupo { get; set; }
        }
    }
}
