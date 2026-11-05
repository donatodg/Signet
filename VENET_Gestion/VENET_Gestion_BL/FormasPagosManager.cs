namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class FormasPagosManager : IDisposable
    {
        private GestionContext db;
        public FormasPagos FormaPago { get; set; }

        public FormasPagosManager(FormasPagos  o)
        {
            db = new GestionContext();
            FormaPago = o;

            db.FormasPagos.Attach(o);

            if (FormaPago.Id > 0) db.Entry(FormaPago).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (FormaPago.Id == 0)
            {
                db.Entry(FormaPago).State = EntityState.Added;

                FormaPago.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                FormaPago.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(FormaPago).State = EntityState.Modified;
                FormaPago.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                FormaPago.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(FormasPagos o)
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

                r = (from f in db.FormasPagos
                     where (f.Id == parametros.Id || parametros.Id == null)
                            && (f.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (f.UserDel == null)
                     select new SearchResult
                     {
                         Id = f.Id,
                         Descripcion =f.Descripcion,
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
            public string Descripcion { get; set; }
        }

        public class SearchResult : FormasPagos
        {

        }
    }
}
