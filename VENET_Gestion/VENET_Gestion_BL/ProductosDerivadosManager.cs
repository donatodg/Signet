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

    public class ProductosDerivadosManager : IDisposable
    {
        private GestionContext db;
        public ProductosDerivados Producto { get; set; }

        public ProductosDerivadosManager(ProductosDerivados o)
        {
            db = new GestionContext();
            Producto = o;

            db.ProductosDerivados.Attach(o);

            if (Producto.Id > 0) db.Entry(Producto).Reload();
            else
            {
                Producto.Id_Categoria = Categorias.First().Key;
                Producto.Id_UnidadVenta = UnidadesVenta.First().Key;
                Producto.Cantidad = 1;
            }
        }

        public List<KeyNamePair> Categorias { get { return (db.ProductosCategorias.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList()); } }

        public List<KeyNamePair> UnidadesVenta { get { return (db.ProductosUnidadVenta.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList()); } }

        public List<ProductosBusqueda> Productos
        {
            get
            {
                //if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVenta_ProductosConPrecio)))
                    //return db.Productos.Where(t => t.UserDel == null && t.Importe > 0).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList();
                //else
                    return db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList();
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public void Save()
        {
            if (Producto.Id == 0)
            {
                db.Entry(Producto).State = EntityState.Added;

                Producto.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Producto.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(Producto).State = EntityState.Modified;
                Producto.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                Producto.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(ProductosDerivados o)
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

                r = (from pd in db.ProductosDerivados
                     join prod in db.Productos on pd.Id_Producto equals prod.Id into listProd
                     from p in listProd
                     join c in db.ProductosCategorias on pd.Id_Categoria equals c.Id into listCat
                     from cat in listCat
                     join u in db.ProductosUnidadVenta on pd.Id_UnidadVenta equals u.Id into listUV
                     from uv in listUV
                     where (pd.Id == parametros.Id || parametros.Id == null)
                            && (pd.Codigo.Contains(parametros.Codigo) || parametros.Codigo == null)
                            && (pd.CodigoFabrica.Contains(parametros.CodigoFabrica) || parametros.CodigoFabrica == null)
                            && (pd.CodigoBarras.Contains(parametros.CodigoBarras) || parametros.CodigoBarras == null)
                            && (pd.Descripcion.Contains(parametros.Descripcion) || parametros.Descripcion == null)
                            && (pd.UserDel == null)
                     select new SearchResult
                     {
                         Id = pd.Id,
                         Codigo = pd.Codigo,
                         CodigoFabrica = pd.CodigoFabrica,
                         Descripcion = pd.Descripcion,
                         Id_Categoria = pd.Id_Categoria,
                         Id_UnidadVenta = pd.Id_UnidadVenta,
                         CodigoBarras = pd.CodigoBarras,
                         Categoria = cat.Descripcion,
                         UnidadVenta = uv.Descripcion,
                         Id_Producto = pd.Id_Producto,
                         Cantidad = pd.Cantidad,
                         Producto = p.Descripcion,
                         FechaAdd = pd.FechaAdd,
                         FechaMod = pd.FechaMod,
                         UserAdd = pd.UserAdd,
                         UserMod = pd.UserMod
                     }).ToList();

                if (parametros.OrdenadoPorIdCategoria)
                {
                    List<SearchResult> re = new List<SearchResult>();
                    foreach (SearchResult x in r)
                    {
                        //x.Categoria =  (100 + x.Id_Categoria) + " - " + x.Categoria;
                        x.Categoria = x.Id_Categoria.ToString("000") + " - " + x.Categoria;
                        re.Add(x);
                    }

                    return re;
                }
                else
                    return r;
            }

        }

        public class ParametrosBusquedas
        {
            public int? Id { get; set; }
            public string Codigo { get; set; }
            public string CodigoFabrica { get; set; }
            public string CodigoBarras { get; set; }
            public string Descripcion { get; set; }
            public bool OrdenadoPorIdCategoria { get; set; }
        }

        public class SearchResult : ProductosDerivados
        {
            public string Categoria { get; set; }
            public string UnidadVenta { get; set; }
            public string Producto { get; set; }
        }

        public class ProductosBusqueda
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string CodigoFabrica { get; set; }
            public string CodigoBarras { get; set; }
            public string Descripcion { get; set; }
            //public decimal Descuento { get; set; }
        }

    }
}
