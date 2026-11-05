namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class RendicionesDetalleManager : IDisposable
    {
        private TesoreriaContext db = new TesoreriaContext();
        public RendicionesDetalle RendicionDetalle { get; set; }

        public RendicionesDetalleManager(RendicionesDetalle o)
        {
            RendicionDetalle = o;
            if (RendicionDetalle.Id_Cuenta == 0)
            {
                RendicionDetalle.Id_Cuenta = 1;
                RendicionDetalle.Cuenta = db.Cuentas.Where(t => t.Id == 1).Select(t => t.Descripcion).SingleOrDefault();
            }
        }

        public List<KeyNamePair> Cuentas { get { return db.Cuentas.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Name).ToList(); } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(RendicionesDetalle o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.RendicionesDetalle.Remove(o);

                db.SaveChanges();
            }
        }
    }
}
