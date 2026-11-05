namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class FirmantesManager : IDisposable
    {
        private TesoreriaContext db;
        public Firmantes Firmante { get; set; }

        public FirmantesManager(Firmantes o)
        {
            db = new TesoreriaContext();
            Firmante = o;

            db.Firmantes.Attach(Firmante);
            if (Firmante.Id > 0)
                db.Entry(Firmante).Reload();

        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (db.Firmantes.Where(t => t.Cuit == Firmante.Cuit && t.Id != Firmante.Id && t.UserDel == null).Count() > 0)
                throw new ValidationException("Ya existe un firmante con dicho cuit.");

            if (Firmante.Id == 0)
            {
                db.Entry(Firmante).State = EntityState.Added;
                Firmante.FechaAdd = Sistema.ObtenerFechaHora();
                Firmante.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }
            else
            {
                db.Entry(Firmante).State = EntityState.Modified;
                Firmante.FechaMod = Sistema.ObtenerFechaHora();
                Firmante.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(Firmantes o)
        {
            using (var db = new TesoreriaContext())
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
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from f in db.Firmantes
                     where (f.Id == parametros.Id || parametros.Id == null)
                     && (f.Nombre.Contains(parametros.Nombre) || parametros.Nombre == null)
                     && (f.Cuit.Contains(parametros.Cuit) || parametros.Cuit == null)
                     && (f.UserDel == null)
                     select new SearchResult
                     {
                         Id = f.Id,
                         Nombre = f.Nombre,
                         Cuit = f.Cuit,
                         FechaAdd = f.FechaAdd,
                         FechaMod = f.FechaMod,
                         UserAdd = f.UserAdd,
                         UserMod = f.UserMod
                     }).ToList();
                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Nombre { get; set; }
            public string Cuit { get; set; }
        }

        public class SearchResult : Firmantes
        {
          
        }
    }
}
