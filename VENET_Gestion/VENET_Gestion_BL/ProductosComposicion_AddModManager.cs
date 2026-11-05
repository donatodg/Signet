namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;
    using static ComprobantesVentasDetalleManager;

    public class ProductosComposicion_AddModManager
    {
        private GestionContext db;
        public ProductosComposicion ProductoComposicion { get; private set; }


        public ProductosComposicion_AddModManager(ProductosComposicion o)
        {
            db = new GestionContext();
            ProductoComposicion = o;
            ProductoComposicion.PropertyChanged += new PropertyChangedEventHandler(PropertyChanged);

            db.ProductosComposicion.Attach(ProductoComposicion);

            if (ProductoComposicion.Id > 0)
                db.Entry(ProductoComposicion).Reload();
            else
            {
                ProductoComposicion.Cantidad = 1;
                ProductoComposicion.Observaciones = "";
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<ProductosBusqueda> Productos
        {
            get
            {
                //if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVenta_ProductosConPrecio)))
                //    return db.Productos.Where(t => t.UserDel == null && t.Importe > 0).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList();
                //else
                return db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList();
            }
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Id_Producto")
            {
                Productos p = new Productos();
                if (ProductoComposicion.Id_ProductoComposicion > 0)
                {
                    using (GestionContext db = new GestionContext())
                    {
                        p.Id = ProductoComposicion.Id_ProductoComposicion.Value;
                        db.Productos.Attach(p);
                        db.Entry(p).Reload();
                    }

                    //ProductoComposicion.Id_AlicuotaIva = p.Id_IvaAlicuota;
                    //ProductoComposicion.Id_Especie = p.Id_Especie;
                    //ProductoComposicion.ImporteUnitario = p.Importe;
                    ProductoComposicion.Producto = p.Descripcion;
                    ProductoComposicion.Medida = (db.ProductosUnidadVenta.Where(t => t.Id == p.Id_UnidadVenta).Select(t => t.Descripcion).FirstOrDefault());
                    ProductoComposicion.ImporteCosto = p.ImporteCosto;
                    ProductoComposicion.FechaActualizacionCosto = p.FechaActualizacionCosto;

                }
            }
            //if (e.PropertyName == "Id_Especie")
            //{
            //    using (GestionContext db = new GestionContext())
            //    {
            //        Detalle.Cotizacion = db.Especies.Where(t => t.Id == Detalle.Id_Especie).Select(t => t.Cotizacion).FirstOrDefault();
            //    }
            //}
        }

        public void Save()
        {
            if (ProductoComposicion.Id_ProductoComposicion == null) throw new ValidationException("Debe ingresar un producto válido.");
            if (ProductoComposicion.Cantidad <= 0) throw new ValidationException("Debe ingresar un cantidad válido.");
            if (ProductoComposicion.Observaciones == null) ProductoComposicion.Observaciones = "";

            if (ProductoComposicion.Id == 0)
            {
                db.Entry(ProductoComposicion).State = EntityState.Added;

                ProductoComposicion.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                ProductoComposicion.FechaAdd = Sistema.ObtenerFechaHora();
            }
            else
            {
                db.Entry(ProductoComposicion).State = EntityState.Modified;
                ProductoComposicion.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                ProductoComposicion.FechaMod = Sistema.ObtenerFechaHora();
            }

            var err = db.GetValidationErrors();
            if (err.Count() > 0)
                throw new ValidationException(
                    (from e in err
                     from er in e.ValidationErrors
                     select er.ErrorMessage).Distinct().Aggregate((s, e) => s + Environment.NewLine + e));

            db.SaveChanges();
        }

        public static void Eliminar(ProductosComposicion o)
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

        public static void ActualizarCostoProducto(Productos o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Modified;
                db.Entry(o).Reload();

                //if ((db.ProductosComposicion.Where(t => t.UserDel == null && t.Id_ProductoFinal == o.Id).Count()) > 0)
                //{
                decimal Costo = (from pc in db.ProductosComposicion
                                 join pr in db.Productos on pc.Id_ProductoComposicion equals pr.Id into listPr
                                 from p in listPr
                                 where pc.Id_ProductoFinal == o.Id
                                    && pc.UserDel == null
                                 select p.ImporteCosto * pc.Cantidad).DefaultIfEmpty().Sum();

                o.ImporteCosto = Costo;
                o.FechaActualizacionCosto = Sistema.ObtenerFechaHora();

                o.UserMod = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                o.FechaMod = Sistema.ObtenerFechaHora();

                db.SaveChanges();
                //}
            }
        }

    }
}
