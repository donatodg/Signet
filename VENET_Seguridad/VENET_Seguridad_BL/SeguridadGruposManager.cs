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

    public class SeguridadGruposManager : IDisposable
    {
        private SeguridadContext db;
        public SeguridadGrupos Grupo { get; set; }

        public SeguridadGruposManager(SeguridadGrupos o)
        {
            db = new SeguridadContext();
            Grupo = o;

            db.SeguridadGrupos.Attach(Grupo);

            if (Grupo.Id > 0) db.Entry(Grupo).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Grupo.EsAdministrador && db.SeguridadGrupos.Where(t => t.EsAdministrador && t.Id != Grupo.Id).Count() != 0)
                throw new ValidationException("Ya existe un grupo administrador.");

            if (Grupo.Id == 0)
            {
                db.Entry(Grupo).State = EntityState.Added;

                Grupo.FechaAdd = Sistema.ObtenerFechaHora();
                Grupo.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Grupo).State = EntityState.Modified;
                Grupo.FechaMod = Sistema.ObtenerFechaHora();
                Grupo.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(SeguridadGrupos o)
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

                r = (from g in db.SeguridadGrupos
                     where (g.Id == parametros.Id || parametros.Id == null)
                        && (g.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                        && (g.UserDel == null)
                     select new SearchResult
                     {
                         Id = g.Id,
                         Descripcion = g.Descripcion,
                         EsAdministrador = g.EsAdministrador,
                         UserAdd = g.UserAdd,
                         UserMod = g.UserMod,
                         FechaAdd = g.FechaAdd,
                         FechaMod = g.FechaMod
                     }).ToList();
                return r;

            }
        }

        public static void Duplicar(int Id_GrupoOriginal, int Id_GrupoNuevo)
        {
            using (var db = new SeguridadContext())
            {
                var r = (from g in db.SeguridadGruposObjetos
                         where (g.Id_Grupo == Id_GrupoOriginal)
                            && (g.UserDel == null)
                         select g.Id_Objeto).ToList();

                foreach (int x in r)
                {
                    SeguridadGruposObjetos o = new SeguridadGruposObjetos()
                    {
                        Id_Grupo = Id_GrupoNuevo,
                        Id_Objeto = x,
                        FechaAdd = Sistema.ObtenerFechaHora(),
                        UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                    };

                    db.SeguridadGruposObjetos.Attach(o);
                    db.Entry(o).State = EntityState.Added;
                }
                db.SaveChanges();
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
            public bool EsAdministrador { get; set; }
        }

        public class SearchResult : SeguridadGrupos
        {


        }
    }
}
