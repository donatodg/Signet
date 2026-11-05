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

    public class TipoCodigoServicioManager : IDisposable
    {
        private GeneralContext db;
        public TipoCodigoServicio Tipo { get; set; }

        public TipoCodigoServicioManager(TipoCodigoServicio o)
        {
            db = new GeneralContext();
            Tipo = o;

            db.TipoCodigoServicio.Attach(Tipo);

            if (Tipo.Id > 0) db.Entry(Tipo).Reload();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (db.TipoCodigoServicio.Where(t => t.UserDel == null && t.Id != Tipo.Id && t.Descripcion == Tipo.Descripcion).Count() > 0)
                throw new ValidationException("El tipo de Servicio ya se encuentra cargado.");

            if (Tipo.Id == 0)
            {
                db.Entry(Tipo).State = EntityState.Added;

                Tipo.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Tipo.FechaAdd = Sistema.ObtenerFechaHora();

            }
            else
            {
                db.Entry(Tipo).State = EntityState.Modified;
                Tipo.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Tipo.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(TipoCodigoServicio o)
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

                r = (from t in db.TipoCodigoServicio
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

        public class SearchResult : TipoCodigoServicio
        {

        }
    }
}
