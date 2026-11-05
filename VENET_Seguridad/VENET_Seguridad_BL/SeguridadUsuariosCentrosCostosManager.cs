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

    public class SeguridadUsuariosCentrosCostosManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadUsuarios Usuario { get; private set; }
        public List<KeyNamePair> CentrosCostosSinAsignar { get; private set; }

        public SeguridadUsuariosCentrosCostosManager(SeguridadUsuarios o)
        {
            db = new SeguridadContext();

            Usuario = db.SeguridadUsuarios.Where(t => t.Id == o.Id).FirstOrDefault();

            if (db.SeguridadGrupos.Where(t => t.Id == Usuario.Id_Grupo).Select(t => t.EsAdministrador).FirstOrDefault())
                throw new ValidationException("El usuario pertenece a un grupo administrador.");

            CentrosCostosSinAsignar = db.CentrosCostos.Where(t => t.UserDel == null && !(db.SeguridadUsuariosCentrosCostos.Where(p => p.Id_Usuario == o.Id && p.UserDel == null).Select(p => p.Id_CentroCosto).ToList()).Contains(t.Id)).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(SeguridadUsuariosCentrosCostos o)
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

                r = (from u in db.SeguridadUsuariosCentrosCostos
                     join c in db.CentrosCostos on u.Id_CentroCosto equals c.Id into listCC
                     from cc in listCC
                     join sucd in db.SeguridadUsuarioCentrosCostoDefault on new { u.Id_CentroCosto, u.Id_Usuario } equals new { sucd.Id_CentroCosto, sucd.Id_Usuario } into listDef
                     from def in listDef.DefaultIfEmpty()
                     where (u.Id_Usuario == Usuario.Id)
                           && (u.UserDel == null)
                           && (cc.UserDel == null)
                     select new SearchResult
                     {
                         Id = u.Id,
                         CentroCosto = cc.Descripcion,
                         Id_CentroCosto = u.Id_CentroCosto,
                         Id_Usuario = u.Id_Usuario,
                         UserAdd = u.UserAdd,
                         UserMod = u.UserMod,
                         FechaAdd = u.FechaAdd,
                         FechaMod = u.FechaMod,
                         Default = def.Id_CentroCosto
                     }).ToList();
                return r;

            }
        }

        public void Save(int IdCentroCosto)
        {
            if (IdCentroCosto == 0) throw new ValidationException("Debe ingresar un centro de costo.");
            if (db.SeguridadUsuariosCentrosCostos.Where(t => t.Id_CentroCosto == IdCentroCosto && t.Id_Usuario == Usuario.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("El centro de costo ya está asignado");

            SeguridadUsuariosCentrosCostos o = new SeguridadUsuariosCentrosCostos()
            {
                Id_CentroCosto = IdCentroCosto,
                Id_Usuario = Usuario.Id,
                UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),
                FechaAdd = Sistema.ObtenerFechaHora()
            };

            db.Entry(o).State = EntityState.Added;
            db.SaveChanges();
        }

        public static void SetDefault(int Id_CentroCosto, int Id_Usuario)
        {
            using (var db = new SeguridadContext())
            {
                //Elimina los asociacion anterior
                var query = from d in db.SeguridadUsuarioCentrosCostoDefault
                            where d.Id_Usuario == Id_Usuario
                            select d;

                foreach (SeguridadUsuarioCentrosCostoDefault def in query)
                {
                    db.SeguridadUsuarioCentrosCostoDefault.Attach(def);
                    db.Entry(def).State = EntityState.Deleted;
                }

                SeguridadUsuarioCentrosCostoDefault o = new SeguridadUsuarioCentrosCostoDefault()
                {
                    Id_CentroCosto = Id_CentroCosto,
                    Id_Usuario = Id_Usuario,
                };

                db.Entry(o).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public class SearchResult : SeguridadUsuariosCentrosCostos
        {
            public string CentroCosto { get; set; }
            public int? Default { get; set; }
        }
    }
}
