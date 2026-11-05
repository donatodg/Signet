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

    public class LocalidadesManager : IDisposable
    {
        private GeneralContext db;
        public Localidades Localidad { get; set; }

        public LocalidadesManager(Localidades o)
        {
            db = new GeneralContext();
            Localidad = o;

            db.Localidades.Attach(Localidad);

            if (Localidad.Id > 0) db.Entry(Localidad).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Localidad.Id == 0)
            {
                db.Entry(Localidad).State = EntityState.Added;

                Localidad.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Localidad.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Localidad).State = EntityState.Modified;
                Localidad.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Localidad.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Localidades o)
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

                r = (from t in db.Localidades
                     join p in db.Provincias on t.Id_Provincia equals p.Id into listProv
                     from prov in listProv.DefaultIfEmpty()
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.CodPostal == parametros.CodPos || parametros.CodPos == null)
                            && (t.Localidad.Contains(parametros.Localidad) || parametros.Localidad == null)
                            && (t.Id_Provincia == parametros.Id_Provincia || parametros.Id_Provincia == null)
                            && (t.UserDel == null)
                     select new SearchResult
                     {
                         Id = t.Id,
                         CodPostal = t.CodPostal,
                         Id_Provincia = t.Id_Provincia,
                         Localidad = t.Localidad,
                         Provincia = prov.Descripcion,
                         Clearing = t.Clearing,
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
            public int? CodPos { get; set; }
            public string Localidad { get; set; }
            public int? Id_Provincia { get; set; }
        }

        public class SearchResult : Localidades
        {
            public string Provincia { get; set; }

        }
    }
}
