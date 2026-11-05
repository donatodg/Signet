namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class JurisdiccionesManager : IDisposable
    {
        private GeneralContext db;
        public Jurisdicciones Jurisdiccion { get; set; }

        public JurisdiccionesManager(Jurisdicciones o)
        {
            db = new GeneralContext();
            Jurisdiccion = o;

            db.Jurisdicciones.Attach(o);

            if (Jurisdiccion.Id > 0) db.Entry(Jurisdiccion).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Jurisdiccion.Id == 0)
            {
                db.Entry(Jurisdiccion).State = EntityState.Added;

                Jurisdiccion.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Jurisdiccion.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Jurisdiccion).State = EntityState.Modified;
                Jurisdiccion.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Jurisdiccion.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Jurisdicciones o)
        {
            using (var db = new GeneralContext())
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
            using (var db = new GeneralContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from j in db.Jurisdicciones
                     where (j.Id == parametros.Id || parametros.Id == null)
                            && (j.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (j.UserDel == null)
                     select new SearchResult
                     {
                         Id = j.Id,
                         Descripcion = j.Descripcion,
                         FechaAdd = j.FechaAdd,
                         FechaMod = j.FechaMod,
                         UserAdd = j.UserAdd,
                         UserMod = j.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : Jurisdicciones
        {

        }
    }
}
