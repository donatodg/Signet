namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ComprobantesComprasDetalleManager : IDisposable
    {
        private GestionContext db = new GestionContext();
        public ComprobantesComprasDetalle Detalle { get; set; }
        private int IdSucursal;

        public ComprobantesComprasDetalleManager(ComprobantesComprasDetalle o, int Id_Sucursal)
        {
            Detalle = o;
            Detalle.PropertyChanged += new PropertyChangedEventHandler(PropertyChanged);
            IdSucursal = Id_Sucursal;

            if (Detalle.Id == 0)
            {
                if (Detalle.Cantidad == 0) Detalle.Cantidad = 1;
                if (Detalle.Id_Especie == 0) Detalle.Id_Especie = Sistema.Especies.First().Key;
                if (Detalle.Id_AlicuotaIva == 0) Detalle.Id_AlicuotaIva = Alicuotas.First().Key;
            }
            else
            {
                if (Detalle.CantidadStock > 0 && Detalle.Visible_Cantidad_Stock == false)
                    Detalle.Visible_Cantidad_Stock = true;
            }
        }

        // public List<KeyNamePair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Alicuota.ToString()}).ToList()); } }
        //  public List<KeyNamePair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Alicuota.ToString().Replace(".", ",") }).ToList()); } }
        public List<KeyNameDecimalPair> Alicuotas { get { return (db.IvaAlicuotas.Where(t => t.UserDel == null).Select(t => new KeyNameDecimalPair() { Key = t.Id, Name = t.Alicuota }).ToList()); } }

        public List<ProductosBusqueda> Productos { get { return db.Productos.Where(t => t.UserDel == null).Select(t => new ProductosBusqueda() { Id = t.Id, Codigo = t.Codigo, CodigoBarras = t.CodigoBarras, CodigoFabrica = t.CodigoFabrica, Descripcion = t.Descripcion }).OrderBy(t => t.Descripcion).ToList(); } }

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
                    Detalle.ImporteUnitario = p.ImporteCosto;
                    Detalle.Descripcion = p.Descripcion;

                    if (p.Id_UnidadStock > 0)
                        Detalle.Visible_Cantidad_Stock = true;
                    else
                        Detalle.Visible_Cantidad_Stock = false;

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
            if (db != null) db.Dispose();
        }

        public static void Eliminar(ComprobantesComprasDetalle o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.ComprobantesComprasDetalle.Remove(o);

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
        }
    }
}
