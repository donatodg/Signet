namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProductosHistorialPreciosManager
    {
        public ProductosHistorialPreciosManager()
        {

        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> result = new List<SearchResult>();

                result = (from ph in db.ProductosPreciosHistorico
                          join prod in db.Productos on ph.Id_Producto equals prod.Id into listHist
                          from p in listHist
                          join esp in db.Especies on p.Id_Especie equals esp.Id into listEsp
                          from e in listEsp
                          where (ph.Id_Producto == parametros.Id_Producto || parametros.Id_Producto == null)
                          && (ph.FechaAdd >= parametros.FechaDesde && ph.FechaAdd <= parametros.FechaHasta)
                          && (ph.UserDel == null)
                          orderby ph.Id
                          select new SearchResult
                          {
                              Id = ph.Id,
                              Codigo = p.Codigo,
                              CodigoBarras = p.CodigoBarras,
                              CodigoFabrica = p.CodigoFabrica,
                              Descripcion = p.Descripcion,
                              Especie = e.Descripcion,
                              Id_Producto = ph.Id_Producto,
                              ImporteCosto = ph.ImporteCosto,
                              Importe = ph.Importe,
                              Fecha = ph.FechaAdd,
                              FechaAdd = ph.FechaAdd,
                              FechaMod = ph.FechaMod,
                              UserAdd = ph.UserAdd,
                              UserMod = ph.UserMod
                          }).ToList();
                return result;
            }
        }


        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaDesde = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                FechaHasta = FechaDesde.AddMonths(1).AddDays(-1);
            }
            public List<ProductosBusqueda> Productos { get { using (GestionContext db = new GestionContext()) { return db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList(); } } }

            public int? Id_Producto { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
        }


        public class ProductosBusqueda
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string CodigoFabrica { get; set; }
            public string CodigoBarras { get; set; }
            public string Descripcion { get; set; }
        }

        public class SearchResult : ProductosPreciosHistorico
        {
            public DateTime Fecha { get; set; }
            public string Codigo { get; set; }
            public string CodigoFabrica { get; set; }
            public string CodigoBarras { get; set; }
            public string Especie { get; set; }
            public string Descripcion { get; set; }
        }

    }
}