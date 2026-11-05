namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;
    using System.Text.RegularExpressions;

    public class ComprobantesVentasDetalleManager : IDisposable
    {
        private GestionContext db = new GestionContext();
        public ComprobantesVentasDetalle Detalle { get; set; }
        private int IdSucursal;
        private int IdCliente;
        private bool UtilizaPorcDescuento;
        private int? IdListasPrecios;

        public ComprobantesVentasDetalleManager(ComprobantesVentasDetalle o, int Id_Sucursal, int Id_Cliente, bool Utiliza_PorcDescuento)
        {
            Detalle = o;
            Detalle.PropertyChanged += new PropertyChangedEventHandler(PropertyChanged);
            IdSucursal = Id_Sucursal;
            IdCliente = Id_Cliente;
            UtilizaPorcDescuento = Utiliza_PorcDescuento;
            IdListasPrecios = db.Clientes.Where(t => t.Id == IdCliente).Select(t => t.Id_ListaPrecio).DefaultIfEmpty().FirstOrDefault();

            if (Detalle.Id == 0)
            {
                if (Detalle.Cantidad == 0) Detalle.Cantidad = 1;
                if (Detalle.Id_Especie == 0) Detalle.Id_Especie = Sistema.Especies.First().Key;
                if (Detalle.Id_AlicuotaIva == 0) Detalle.Id_AlicuotaIva = Alicuotas.Where(t => t.Key == Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.ComprobantesVenta_IdIvaAlicuotas))).First().Key;
                if (Detalle.Descripcion == null) Detalle.Descripcion = "";

                if (UtilizaPorcDescuento && Detalle.PorcDescuento == 0)
                    Detalle.PorcDescuento = db.ClientesDescuentos.Where(t => t.Id_Cliente == IdCliente && t.UserDel == null && t.Id_Categoria2 == null).Select(t => t.Descuento).FirstOrDefault();
            }
            else
            {
                if (Detalle.CantidadStock > 0 && Detalle.Visible_Cantidad_Stock == false)
                    Detalle.Visible_Cantidad_Stock = true;
            }
        }

        //public List<KeyNamePair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Alicuota.ToString() }).ToList()); } }
        //public List<KeyNamePair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Alicuota.ToString().Replace(".", ",") }).ToList()); } }
        public List<KeyNameDecimalPair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNameDecimalPair() { Key = t.Id, Name = t.Alicuota }).ToList()); } }

        public List<ProductosBusqueda> Productos
        {
            get
            {
                List<ProductosBusqueda> result = new List<ProductosBusqueda>();

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVenta_ProductosConPrecio)))
                    result = db.Productos.Where(t => t.UserDel == null && t.Importe > 0).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList();
                else
                    result = db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList();

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVenta_ProductosExcluidos)))
                {
                    int User = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    List<string> Excluidos = db.ProductosUsuariosExcluidos.Where(t => t.Id_Usuario == User && t.UserDel == null).Select(t => t.CodigoProducto).ToList();

                    return result.Where(t => !Excluidos.Contains(t.Codigo)).ToList();
                }
                else
                    return result;
            }
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Id_Producto")
            {
                Productos p = new Productos();
                if (Detalle.Id_Producto > 0)
                {
                    using (GestionContext db = new GestionContext())
                    {
                        p.Id = Detalle.Id_Producto.Value;
                        db.Productos.Attach(p);
                        db.Entry(p).Reload();
                    }

                    Detalle.Id_AlicuotaIva = p.Id_IvaAlicuota;
                    Detalle.Id_Especie = p.Id_Especie;

                    //Utiliza Listas de Precios
                    if (IdListasPrecios > 0)
                        Detalle.ImporteUnitario = (from lp in db.ProductosListasPrecios
                                                   join listDet in db.ProductosListasPreciosDetalle on lp.Id equals listDet.Id_Productos_ListasPrecios into listaDet
                                                   from ld in listaDet
                                                   where lp.UserDel == null &&
                                                         lp.Activo == true &&
                                                         ld.Id_Producto == p.Id &&
                                                         lp.Id == IdListasPrecios
                                                   select ld.Importe).FirstOrDefault();
                    else
                        Detalle.ImporteUnitario = p.Importe;

                    Detalle.Descripcion = p.Descripcion;
                    Detalle.ImporteCosto = p.ImporteCosto;

                    if (p.Id_UnidadStock > 0)
                        Detalle.Visible_Cantidad_Stock = true;
                    else
                        Detalle.Visible_Cantidad_Stock = false;

                    if (UtilizaPorcDescuento)
                        Detalle.PorcDescuento = db.ClientesDescuentos
                                                  .Where(t => t.Id_Cliente == IdCliente &&
                                                              t.UserDel == null &&
                                                              (t.Id_Categoria2 == p.Id_Categoria2 || t.Id_Categoria2 == null))
                                                   .Select(t => t.Descuento).FirstOrDefault();
                }
                else
                    Detalle.Visible_Cantidad_Stock = false;
            }
            if (e.PropertyName == "Id_Especie")
            {
                using (GestionContext db = new GestionContext())
                {
                    Detalle.Cotizacion = db.Especies.Where(t => t.Id == Detalle.Id_Especie).Select(t => t.Cotizacion).FirstOrDefault();
                }
            }
        }

        public void Dispose()
        {
            if (Detalle != null) Detalle.PropertyChanged -= PropertyChanged;
            if (db != null) db.Dispose();
        }

        public static void Eliminar(ComprobantesVentasDetalle o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.ComprobantesVentasDetalle.Remove(o);

                db.SaveChanges();
            }
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
