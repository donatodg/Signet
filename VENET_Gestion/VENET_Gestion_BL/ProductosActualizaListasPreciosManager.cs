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

    public class ProductosActualizaListasPreciosManager
    {
        public List<SearchResult> ListaProductos { get; set; }

        public void Buscar(int Id_ListasPrecios)
        {
            using (var db = new GestionContext())
            {
                //actualiza detalle de lista de precios con la lista de productos nuevos y borra los que no estan 
                System.Data.SqlClient.SqlConnection sqlConn = (System.Data.SqlClient.SqlConnection)db.Database.Connection;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("Productos_ListasdePrecios", sqlConn);

                using (cmd)
                {
                    System.Data.SqlClient.SqlParameter Parameter1 = new System.Data.SqlClient.SqlParameter("IdListaPrecio", Id_ListasPrecios);

                    cmd.CommandTimeout = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(Parameter1);
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed) cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }


                List<SearchResult> r = new List<SearchResult>();

                r = (from lp in db.ProductosListasPreciosDetalle
                     join prod in db.Productos on lp.Id_Producto equals prod.Id into listProd
                     from p in listProd
                     join a in db.IvaAlicuotas on p.Id_IvaAlicuota equals a.Id into listAlic
                     from alic in listAlic
                     join c in db.ProductosCategorias on p.Id_Categoria equals c.Id into listCat
                     from cat in listCat
                     join c2 in db.ProductosCategorias2 on p.Id_Categoria2 equals c2.Id into listCat2
                     from cat2 in listCat2.DefaultIfEmpty()
                     join u in db.ProductosUnidadVenta on p.Id_UnidadVenta equals u.Id into listUV
                     from uv in listUV
                     join esp in db.Especies on p.Id_Especie equals esp.Id into listEsp
                     from e in listEsp
                     join espOrig in db.Especies on p.Id_EspecieOriginal equals espOrig.Id into listEspOrig
                     from eo in listEspOrig.DefaultIfEmpty()
                     where (p.UserDel == null &&
                            lp.Id_Productos_ListasPrecios == Id_ListasPrecios)
                     select new SearchResult()
                     {
                         Id = lp.Id,
                         Id_Especie = lp.Id_Especie,
                         Importe = lp.Importe,
                         Id_EspecieOriginal = lp.Id_EspecieOriginal,
                         ImporteOriginal = lp.ImporteOriginal,
                         Id_Producto = lp.Id_Producto,
                         Id_Productos_ListasPrecios = lp.Id_Productos_ListasPrecios,
                         EspecieOriginal = eo.Descripcion,

                         Descripcion = p.Descripcion,
                         Codigo = p.Codigo,
                         CodigoBarras = p.CodigoBarras,
                         CodigoFabrica = p.CodigoFabrica,
                         Id_Categoria = p.Id_Categoria,
                         Id_Categoria2 = p.Id_Categoria2,
                         Id_IvaAlicuota = p.Id_IvaAlicuota,
                         Id_UnidadVenta = p.Id_UnidadVenta,
                         ImporteCosto = p.ImporteCosto,
                         FechaActualizacionCosto = p.FechaActualizacionCosto,
                         Id_EspecieCosto = p.Id_EspecieCosto,
                         Observaciones = p.Observaciones,
                         StockMaximo = p.StockMaximo,
                         StockMinimo = p.StockMinimo,
                         Alicuota = alic.Alicuota,
                         Categoria = cat.Descripcion,
                         Categoria2 = cat2.Descripcion,
                         UnidadVenta = uv.Descripcion,
                         Especie = e.Descripcion,
                         FechaAdd = lp.FechaAdd,
                         FechaMod = lp.FechaMod,
                         UserAdd = lp.UserAdd,
                         UserMod = lp.UserMod,
                         NuevoPrecio = 0,
                         NuevoPrecio_Original = 0,
                         Seleccionado = false,
                         ImporteOriginalProducto = p.ImporteOriginal,
                         ImporteProducto = p.Importe
                     }).ToList();

                //List<KeyNamePair> ListaProveedores = (from c in db.ComprobantesCompras
                //                                      join ccd in db.ComprobantesComprasDetalle on c.Id equals ccd.Id_ComprobanteCompra into listDet
                //                                      from d in listDet
                //                                      join pr in db.Proveedores on c.Id_Entidad equals pr.Id into listProv
                //                                      from p in listProv
                //                                      where c.UserDel == null
                //                                          && d.Id_Producto > 0
                //                                      orderby c.Id descending, d.Id_Producto
                //                                      select new KeyNamePair()
                //                                      {
                //                                          Key = d.Id_Producto.Value,
                //                                          Name = p.Nombre
                //                                      }).ToList();


                //foreach (SearchResult o in r)
                //    o.Proveedor = ListaProveedores.Where(t => t.Key == o.Id).Select(t => t.Name).FirstOrDefault();

                ListaProductos = r;
            }
        }

        public int Save()
        {
            int Cant = 0;

            using (var db = new GestionContext())
            {
                foreach (SearchResult o in ListaProductos.Where(t => t.Seleccionado == true))
                {
                    ProductosListasPreciosDetalle p = db.ProductosListasPreciosDetalle.Find(o.Id);
                    db.Entry(p).State = EntityState.Modified;

                    p.Importe = o.NuevoPrecio;
                    p.ImporteOriginal = o.NuevoPrecio_Original;
                    p.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    p.FechaMod = Sistema.ObtenerFechaHora();

                    Cant += 1;

                    var err = db.GetValidationErrors();
                    if (err.Count() > 0)
                        throw new ValidationException(
                            (from e in err
                             from er in e.ValidationErrors
                             select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

                    db.SaveChanges();
                }
            }

            return Cant;
        }

        public void DeseleccionarTodo()
        {
            foreach (SearchResult s in ListaProductos)
            {
                s.Seleccionado = false;
            }
        }

        public class SearchResult : ProductosListasPreciosDetalle
        {
            public decimal Alicuota { get; set; }
            public string Categoria { get; set; }
            public string Categoria2 { get; set; }
            public string UnidadVenta { get; set; }
            public string Especie { get; set; }
            public string EspecieOriginal { get; set; }
            //public string Proveedor { get; set; }
            public bool Seleccionado { get; set; }
            public decimal NuevoPrecio { get; set; }
            public decimal NuevoPrecio_Original { get; set; }
            public string Descripcion { get; set; }
            public string Codigo { get; set; }
            public string CodigoBarras { get; set; }
            public string CodigoFabrica { get; set; }
            public int Id_Categoria { get; set; }
            public int? Id_Categoria2 { get; set; }
            public int Id_IvaAlicuota { get; set; }
            public int Id_UnidadVenta { get; set; }
            public decimal ImporteCosto { get; set; }
            public DateTime? FechaActualizacionCosto { get; set; }
            public int? Id_EspecieCosto { get; set; }
            public string Observaciones { get; set; }
            public int StockMaximo { get; set; }
            public int StockMinimo { get; set; }
            public decimal ImporteProducto { get; set; }
            public decimal? ImporteOriginalProducto { get; set; }
        }
    }
}
