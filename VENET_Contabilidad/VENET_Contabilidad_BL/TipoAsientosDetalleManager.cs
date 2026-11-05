namespace VENET_Contabilidad_BL
{
    using System;
    using System.Data.Entity;
    using VENET_DataEntity;

    public class TipoAsientosDetalleManager : IDisposable
    {
        private GestionContext db = new GestionContext();
        public TipoAsientosDetalle Detalle { get; set; }
        //private int IdSucursal;

        public TipoAsientosDetalleManager(TipoAsientosDetalle o)
        {
            Detalle = o;

            //if (Detalle.Id == 0)
            //{
            //    if (Detalle.Cantidad == 0) Detalle.Cantidad = 1;
            //    if (Detalle.Id_Especie == 0) Detalle.Id_Especie = Sistema.Especies.First().Key;
            //    if (Detalle.Id_AlicuotaIva == 0) Detalle.Id_AlicuotaIva = Alicuotas.First().Key;
            //}

        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(TipoAsientosDetalle o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.TipoAsientosDetalle.Remove(o);

                db.SaveChanges();
            }
        }

    }
}
