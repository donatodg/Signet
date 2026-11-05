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

    public class SeguridadUsuariosUnidadNegociosManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuarios Usuario { get; private set; }
        public List<KeyNamePair> UNSinAsignar { get; private set; }


        public SeguridadUsuariosUnidadNegociosManager(SeguridadUsuarios o)
        {
            db = new SeguridadContext();

            Usuario = db.SeguridadUsuarios.Where(t => t.Id == o.Id).FirstOrDefault();

            if (db.SeguridadGrupos.Where(t => t.Id == Usuario.Id_Grupo).Select(t => t.EsAdministrador).FirstOrDefault())
                throw new ValidationException("El usuario pertenece a un grupo administrador.");

            UNSinAsignar = db.UnidadNegocios.Where(t => t.UserDel == null && !(db.SeguridadUsuariosUnidadNegocios.Where(p => p.Id_Usuario == o.Id && p.UserDel == null).Select(p => p.Id_UnidadNegocio).ToList()).Contains(t.Id)).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(SeguridadUsuariosUnidadNegocios o)
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

        public List<SearchResult> Buscar()
        {
            using (var db = new SeguridadContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from u in db.SeguridadUsuariosUnidadNegocios
                     join c in db.UnidadNegocios on u.Id_UnidadNegocio equals c.Id into listCC
                     from cc in listCC
                     where (u.Id_Usuario == Usuario.Id)
                           && (u.UserDel == null)
                           && (cc.UserDel == null)
                     select new SearchResult
                     {
                         Id = u.Id,
                         UnidadNegocio = cc.Descripcion,
                         Id_UnidadNegocio = u.Id_UnidadNegocio,
                         Id_Usuario = u.Id_Usuario,
                         UserAdd = u.UserAdd,
                         UserMod = u.UserMod,
                         FechaAdd = u.FechaAdd,
                         FechaMod = u.FechaMod
                     }).ToList();
                return r;

            }
        }

        public void Save(int IdUN)
        {
            if (IdUN == 0) throw new ValidationException("Debe ingresar una unidad de negocio.");
            if (db.SeguridadUsuariosUnidadNegocios.Where(t => t.Id_UnidadNegocio == IdUN && t.Id_Usuario == Usuario.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("La unidad de negocio ya está asignado");

            SeguridadUsuariosUnidadNegocios o = new SeguridadUsuariosUnidadNegocios()
            {
                Id_UnidadNegocio = IdUN,
                Id_Usuario = Usuario.Id,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;
            db.SaveChanges();
        }

        public class SearchResult : SeguridadUsuariosUnidadNegocios
        {
            public string UnidadNegocio { get; set; }
        }
    }
}
