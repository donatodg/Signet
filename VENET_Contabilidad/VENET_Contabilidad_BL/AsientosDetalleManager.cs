namespace VENET_Contabilidad_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class AsientosDetalleManager : IDisposable
    {
        private GestionContext db = new GestionContext();
        public AsientosDetalle Detalle { get; set; }

        public AsientosDetalleManager(AsientosDetalle o)
        {
            Detalle = o;
        }

        public List<KeyName2Pair> CuentasContables { get { return (db.CuentasContables.Where(t => t.UserDel == null && t.Subcuenta != "000000").Select(t => new KeyName2Pair() { Key = t.Id, Name = t.Descripcion.Trim(), Name2 = t.Titulo + "." + t.Capitulo + "." + t.Rubro + "." + t.Cuenta + "." + t.Subcuenta }).ToList()); } }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(AsientosDetalle o)
        {
            using (var db = new GestionContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                ContabilidadService.ProtegerAsiento(db, o.Id_Asiento);
                throw new System.ComponentModel.DataAnnotations.ValidationException("Quite el renglon desde el asiento y guarde el asiento completo para validar su balance.");
            }
        }

    }
}
