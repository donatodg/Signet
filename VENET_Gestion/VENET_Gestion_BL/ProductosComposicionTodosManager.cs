namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_DataEntity;

    public class ProductosComposicionTodosManager
    {
        public ProductosComposicionTodosManager()
        {

        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from pc in db.ProductosComposicion
                     join prodf in db.Productos on pc.Id_ProductoFinal equals prodf.Id into listPF
                     from pf in listPF
                     join prodComp in db.Productos on pc.Id_ProductoComposicion equals prodComp.Id into listPC
                     from pci in listPC
                     where (pc.Id_ProductoFinal == parametros.Id_ProductoFinal || parametros.Id_ProductoFinal == null)
                     && pc.UserDel == null
                     select new SearchResult()
                     {
                         Id = pc.Id,
                         Id_ProductoFinal = pc.Id_ProductoFinal,
                         Id_ProductoComposicion = pc.Id_ProductoComposicion,
                         Cantidad = pc.Cantidad,
                         FechaAdd = pc.FechaAdd,
                         FechaMod = pc.FechaMod,
                         Observaciones = pc.Observaciones,
                         CodigoProductoFinal = pf.Codigo,
                         ProductoFinal = pf.Descripcion,
                         CodigoProducto = pci.Codigo,
                         ProductoComposicion = pci.Descripcion,
                         Costo = pci.ImporteCosto,
                         ActualizacionCosto = pci.FechaActualizacionCosto,
                         Total_Costo = pci.ImporteCosto * pc.Cantidad, 
                         //
                         //Producto = pc.Producto,
                         //FechaActualizacionCosto = pc.FechaActualizacionCosto,
                         //ImporteCosto = pc.ImporteCosto,
                         //Medida = pc.Medida,
                         //
                         UserAdd = pc.UserAdd,
                         UserMod = pc.UserMod
                     }
                     ).ToList();

                return r;
            }
        }



        public class ParametrosBusquedas
        {
            public List<ProductosBusqueda> Productos { get { using (GestionContext db = new GestionContext()) { return db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList(); } } }

            public int? Id_ProductoFinal { get; set; }
        }


        public class ProductosBusqueda
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string CodigoFabrica { get; set; }
            public string CodigoBarras { get; set; }
            public string Descripcion { get; set; }
        }
 

        public class SearchResult : ProductosComposicion
        {
            public string ProductoFinal { get; set; }
            public string CodigoProductoFinal { get; set; }
            public string ProductoComposicion  { get; set; }
            public string CodigoProducto  { get; set; }
            public decimal Costo  { get; set; }
            public decimal Total_Costo  { get; set; }
            public DateTime? ActualizacionCosto  { get; set; }
        }

    }
}
