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

    public class ProductosCategoriasManager : IDisposable
    {
        private GeneralContext db;
        public ProductosCategorias Categoria { get; set; }

        public ProductosCategoriasManager(ProductosCategorias o)
        {
            db = new GeneralContext();
            Categoria = o;

            db.ProductosCategorias.Attach(o);

            if (Categoria.Id > 0) db.Entry(Categoria).Reload();
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Categoria.Id == 0)
            {
                db.Entry(Categoria).State = EntityState.Added;

                Categoria.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Categoria.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Categoria).State = EntityState.Modified;
                Categoria.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Categoria.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(ProductosCategorias o)
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

                r = (from c in db.ProductosCategorias
                     where (c.Id == parametros.Id || parametros.Id == null)
                            && (c.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (c.UserDel == null)
                     select new SearchResult
                     {
                         Id = c.Id,
                         Descripcion = c.Descripcion,
                         FechaAdd = c.FechaAdd,
                         FechaMod = c.FechaMod,
                         UserAdd = c.UserAdd,
                         UserMod = c.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : ProductosCategorias
        {

        }
    }
}
