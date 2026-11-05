namespace VENET_Gestion_BL
{
    using System.Collections.Generic;
    using System.Linq;
    using VENET_DataEntity;

    public class ProductosComposicionManager
    {
        private GestionContext db;
        private int _Id_Producto;
        //  public Productos Producto { get; private set; }
        //public List<ProductosComposicion> Composicion { get; private set; }


        public ProductosComposicionManager(int Id_Producto)
        {
            db = new GestionContext();
            _Id_Producto = Id_Producto;

            //db.Productos.Attach(Producto);

            //if (Producto.Id > 0)
            //    db.Entry(Producto).Reload();

            //CargarComposicion();
        }

        //public void CargarComposicion()
        //{
        //    Composicion = (from pc in db.ProductosComposicion
        //                   join pr in db.Productos on pc.Id_ProductoFinal equals pr.Id into listPr
        //                   from p in listPr
        //                   join puv in db.ProductosUnidadVenta on p.Id_UnidadVenta equals puv.Id into listUV
        //                   from uv in listUV
        //                   where pc.Id_ProductoFinal == Producto.Id
        //                      && pc.UserDel == null
        //                   select new ProductosComposicion()
        //                   {
        //                       Cantidad = pc.Cantidad,
        //                       Descripcion = pc.Descripcion,
        //                       FechaAdd = pc.FechaAdd,
        //                       FechaMod = pc.FechaMod,
        //                       Id = pc.Id,
        //                       Id_ProductoComposicion = pc.Id_ProductoComposicion,
        //                       Id_ProductoFinal = pc.Id_ProductoFinal,
        //                       UserAdd = pc.UserAdd,
        //                       UserMod = pc.UserMod,
        //                       Medida = uv.Descripcion,
        //                       Producto = p.Descripcion
        //                   }).ToList();
        //}

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<SearchResult> Buscar(int Id_ProductosComposicion)
        {
            using (var db = new GestionContext())
            {
                return (from pc in db.ProductosComposicion
                        join pr in db.Productos on pc.Id_ProductoComposicion equals pr.Id into listPr
                        from p in listPr
                        join puv in db.ProductosUnidadVenta on p.Id_UnidadVenta equals puv.Id into listUV
                        from uv in listUV
                        where pc.Id_ProductoFinal == _Id_Producto
                           && pc.UserDel == null
                           && (pc.Id == Id_ProductosComposicion || Id_ProductosComposicion == 0)
                        select new SearchResult()
                        {
                            Cantidad = pc.Cantidad,
                            Observaciones = pc.Observaciones,
                            FechaAdd = pc.FechaAdd,
                            FechaMod = pc.FechaMod,
                            Id = pc.Id,
                            Id_ProductoComposicion = pc.Id_ProductoComposicion,
                            Id_ProductoFinal = pc.Id_ProductoFinal,
                            ImporteCosto = p.ImporteCosto,
                            FechaActualizacionCosto = p.FechaActualizacionCosto,
                            UserAdd = pc.UserAdd,
                            UserMod = pc.UserMod,
                            Medida = uv.Descripcion,
                            Producto = p.Descripcion
                        }).ToList();
            }
        }

        public class SearchResult : ProductosComposicion
        {
        }

    }
}
