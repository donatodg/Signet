namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class TalonariosComprobantesDetalleManager : IDisposable
    {
        private GeneralContext db = new GeneralContext();
        public TalonariosComprobantesDetalle TalonarioDetalle { get; set; }

        public TalonariosComprobantesDetalleManager(TalonariosComprobantesDetalle o)
        {
            TalonarioDetalle = o;

            if (TalonarioDetalle.FechaVencimiento == DateTime.MinValue)
                TalonarioDetalle.FechaVencimiento = Sistema.ObtenerFechaHora().AddYears(1);
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(TalonariosComprobantesDetalle o)
        {
            using (var db = new GeneralContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.TalonariosComprobantesDetalle.Remove(o);

                db.SaveChanges();
            }
        }

    }
}
