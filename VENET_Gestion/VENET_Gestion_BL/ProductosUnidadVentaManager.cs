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

    public class ProductosUnidadVentaManager : IDisposable
    {
        private GestionContext db;
        public ProductosUnidadVenta Unidad { get; set; }

        public ProductosUnidadVentaManager(ProductosUnidadVenta o)
        {
            db = new GestionContext();
            Unidad = o;

            db.ProductosUnidadVenta.Attach(o);

            if (Unidad.Id > 0) db.Entry(Unidad).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Unidad.Id == 0)
            {
                db.Entry(Unidad).State = EntityState.Added;

                Unidad.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Unidad.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Unidad).State = EntityState.Modified;
                Unidad.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Unidad.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(ProductosUnidadVenta o)
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

                r = (from u in db.ProductosUnidadVenta
                     where (u.Id == parametros.Id || parametros.Id == null)
                            && (u.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (u.UserDel == null)
                     select new SearchResult
                     {
                         Id = u.Id,
                         Descripcion = u.Descripcion,
                         FechaAdd = u.FechaAdd,
                         FechaMod = u.FechaMod,
                         UserAdd = u.UserAdd,
                         UserMod = u.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : ProductosUnidadVenta
        {

        }
    }
}
