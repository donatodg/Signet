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

    public class TipoIvaManager : IDisposable
    {
        private GeneralContext db;
        public TipoIva Iva { get; set; }

        public TipoIvaManager(TipoIva o)
        {
            db = new GeneralContext();
            Iva = o;

            db.TipoIva.Attach(o);

            if (Iva.Id > 0) db.Entry(Iva).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Iva.Id == 0)
            {
                db.Entry(Iva).State = EntityState.Added;

                Iva.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Iva.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Iva).State = EntityState.Modified;
                Iva.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Iva.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(TipoIva o)
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

                r = (from t in db.TipoIva
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.Nombre.Contains(parametros.Nombre) || parametros.Nombre == null)
                            && (t.UserDel == null)
                     select new SearchResult
                     {
                         Id = t.Id,
                         Nombre = t.Nombre,
                         Abreviatura = t.Abreviatura,
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
            public string Nombre { get; set; }
        }

        public class SearchResult : TipoIva
        {

        }
    }
}
