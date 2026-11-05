namespace VENET_Contabilidad_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class TipoCategoriasContablesManager : IDisposable
    {
        private GestionContext db;
        public TipoCategoriasContables catContable { get; set; }

        public TipoCategoriasContablesManager(TipoCategoriasContables o)
        {
            db = new GestionContext();
            catContable = o;

            db.Set<TipoCategoriasContables>().Attach(o);

            if (catContable.Id > 0) db.Entry(catContable).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (catContable.Id == 0)
            {
                db.Entry(catContable).State = EntityState.Added;

                catContable.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                catContable.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(catContable).State = EntityState.Modified;
                catContable.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                catContable.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(TipoCategoriasContables o)
        {
            using (var db = new GestionContext())
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
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from t in db.Set<TipoCategoriasContables>()
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (t.UserDel == null)
                     select new SearchResult
                     {
                         Id = t.Id,
                         Descripcion = t.Descripcion,
                         FechaAdd = t.FechaAdd,
                         FechaMod = t.FechaMod,
                         UserAdd = t.UserAdd,
                         UserMod = t.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : TipoCategoriasContables
        {

        }
    }
}
