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

    public class ProductosActualizaPreciosCostoManager
    {
        public List<SearchResult> ListaProductos { get; set; }

        public void Buscar()
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from p in db.Productos
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
                     where (p.UserDel == null)
                     select new SearchResult()
                     {
                         Id = p.Id,
                         Descripcion = p.Descripcion,
                         Codigo = p.Codigo,
                         CodigoBarras = p.CodigoBarras,
                         CodigoFabrica = p.CodigoFabrica,
                         Id_Categoria = p.Id_Categoria,
                         Id_Categoria2 = p.Id_Categoria2,
                         Id_Especie = p.Id_Especie,
                         Id_IvaAlicuota = p.Id_IvaAlicuota,
                         Id_UnidadVenta = p.Id_UnidadVenta,
                         Importe = p.Importe,
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
                         FechaAdd = p.FechaAdd,
                         FechaMod = p.FechaMod,
                         UserAdd = p.UserAdd,
                         UserMod = p.UserMod,
                         NuevoPrecio = 0,
                         Seleccionado = false
                     }).ToList();

                List<KeyNamePair> ListaProveedores = (from c in db.ComprobantesCompras
                                                      join ccd in db.ComprobantesComprasDetalle on c.Id equals ccd.Id_ComprobanteCompra into listDet
                                                      from d in listDet
                                                      join pr in db.Proveedores on c.Id_Entidad equals pr.Id into listProv
                                                      from p in listProv
                                                      where c.UserDel == null
                                                         && d.Id_Producto > 0
                                                      orderby c.Id descending, d.Id_Producto
                                                      select new KeyNamePair()
                                                      {
                                                          Key = d.Id_Producto.Value,
                                                          Name = p.Nombre
                                                      }).ToList();



                foreach (SearchResult o in r)
                    //o.Proveedor = (from c in db.ComprobantesCompras
                    //               join ccd in db.ComprobantesComprasDetalle on c.Id equals ccd.Id_ComprobanteCompra into listDet
                    //               from d in listDet
                    //               join pr in db.Proveedores on c.Id_Entidad equals pr.Id into listProv
                    //               from p in listProv
                    //               where d.Id_Producto == o.Id
                    //               && c.UserDel == null
                    //               orderby c.Id descending
                    //               select p.Nombre
                    //               ).FirstOrDefault();
                    o.Proveedor = ListaProveedores.Where(t => t.Key == o.Id).Select(t => t.Name).FirstOrDefault();

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
                    Productos p = db.Productos.Find(o.Id);
                    db.Entry(p).State = EntityState.Modified;

                    p.ImporteCosto = o.NuevoPrecio;
                    p.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    p.FechaMod = Sistema.ObtenerFechaHora();
                    p.FechaActualizacionCosto = p.FechaMod;
                    //p.Id_EspecieCosto = o.Id_EspecieCosto;
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

        public class SearchResult : Productos
        {
            public decimal Alicuota { get; set; }
            public string Categoria { get; set; }
            public string Categoria2 { get; set; }
            public string UnidadVenta { get; set; }
            public string Especie { get; set; }
            public string Proveedor { get; set; }
            public bool Seleccionado { get; set; }
            public decimal NuevoPrecio { get; set; }
        }
    }
}
