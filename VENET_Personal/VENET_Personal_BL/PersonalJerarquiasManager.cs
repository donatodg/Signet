namespace VENET_Personal_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class PersonalJerarquiasManager : IDisposable
    {
        private PersonalContext db;
        public PersonalJerarquias PersonalJerarquia { get; set; }

        public PersonalJerarquiasManager(PersonalJerarquias o)
        {
            db = new PersonalContext();
            PersonalJerarquia = o;

            db.PersonalJerarquias.Attach(PersonalJerarquia);

            if (PersonalJerarquia.Id > 0) db.Entry(PersonalJerarquia).Reload();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {

            if (PersonalJerarquia.Id == 0)
            {
                db.Entry(PersonalJerarquia).State = EntityState.Added;
                PersonalJerarquia.FechaAdd = Sistema.ObtenerFechaHora();
                PersonalJerarquia.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(PersonalJerarquia).State = EntityState.Modified;
                PersonalJerarquia.FechaMod = Sistema.ObtenerFechaHora();
                PersonalJerarquia.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(PersonalJerarquias o)
        {
            using (var db = new PersonalContext())
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
            using (var db = new PersonalContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from e in db.PersonalJerarquias
                     where (e.Id == parametros.Id || parametros.Id == null)
                     && (e.Descripcion .Contains( parametros.Descripcion) || parametros.Descripcion == null)
                     && (e.UserDel == null)
                     select new SearchResult
                     {
                         Id = e.Id,
                         Descripcion = e.Descripcion,
                     }).ToList();
                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : PersonalJerarquias
        {

        }
    }
}