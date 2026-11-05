using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using VENET_DataEntity;

namespace VENET_Tesoreria_BL
{
    public class TipoMovimientosManager : IDisposable
    {
        private TesoreriaContext db;
        public TipoMovimiento TipoMov { get; set; }

        public TipoMovimientosManager(TipoMovimiento o)
        {
            db = new TesoreriaContext();
            TipoMov = o;

            db.TipoMovimiento.Attach(TipoMov);

            if (TipoMov.Id > 0) db.Entry(TipoMov).Reload();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            //var Usuario = (Usuarios)Thread.CurrentPrincipal.Identity;
            //var x = ConfigurationManager.AppSettings["CurrentUser"];

            if (TipoMov.Id == 0)
            {
                db.Entry(TipoMov).State = EntityState.Added;
                //Linea.FechaAdd = DateTime.Now;
                //Unidad.UserAdd = Usuario.Id;
            }
            else
            {
                db.Entry(TipoMov).State = EntityState.Modified;
                //Unidad.FechaMod = DateTime.Now;
                //  Unidad.UserMod = Usuario.Id;
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0) throw new ValidationException(
                (from e in err
                 from er in e.ValidationErrors
                 select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(TipoMovimiento o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaDel = DateTime.Now;

                db.SaveChanges();
            }
        }
       
        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from t in db.TipoMovimiento
                     where (t.Id == parametros.Id || parametros.Id == null)
                            && (t.Descripcion == parametros.Descripcion || parametros.Descripcion == null)
                            && (t.UserDel == null)
                     select new SearchResult()
                     {
                         Id = t.Id,
                         Descripcion = t.Descripcion
                     }).ToList();

                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public Nullable<Int32> Id { get; set; }
            public String Descripcion { get; set; }
        }

        public class SearchResult : TipoMovimiento
        {

        }
    }
}
