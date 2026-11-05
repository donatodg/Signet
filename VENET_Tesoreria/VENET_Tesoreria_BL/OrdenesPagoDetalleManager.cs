namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class OrdenesPagoDetalleManager : IDisposable
    {
        private TesoreriaContext db = new TesoreriaContext();
        public OrdenesPagoDetalle OPDetalle { get; set; }
        private int IdSucursal;

        public OrdenesPagoDetalleManager(OrdenesPagoDetalle o, int Id_Sucursal)
        {
            OPDetalle = o;
            IdSucursal = Id_Sucursal;

            if (OPDetalle.Id_Especie == 0)
            {
                if (Sistema.Especies.Count > 0)
                    IdEspecie = OPDetalle.Id_Especie = Sistema.Especies.First().Key;

                OPDetalle.Detalle = "-";
            }
        }

        public int? IdEspecie
        {
            get
            {
                return OPDetalle.Id_Especie == 0 ? null : (int?)OPDetalle.Id_Especie;
            }
            set
            {
                if (value == null || value == 0)
                {
                    OPDetalle.Id_Especie = 0;
                    OPDetalle.Cotizacion = 0;
                }
                else
                {
                    OPDetalle.Id_Especie = (int)value;
                    OPDetalle.Cotizacion = db.Especies.Where(t => t.Id == OPDetalle.Id_Especie).Select(t => t.Cotizacion).FirstOrDefault();
                }
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<KeyNamePair> EspeciesPF
        {
            get
            {
                using (var db = new TesoreriaContext())
                    return db.Especies.Where(t => t.UserDel == null && t.Id == (db.ProvFinancierosCuentas.Where(tt => tt.Id == OPDetalle.Id_Entidad).Select(tt => tt.Id_Especie).FirstOrDefault())).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList();
            }
        }
 
        public List<KeyNamePair> Entidades
        {
            get
            {
                using (var db = new TesoreriaContext())
                    return Sistema.ObtenerEntidades(OPDetalle.Id_TipoEntidad);
            }
        }

        public static void Eliminar(OrdenesPagoDetalle o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.OrdenesPagoDetalle.Remove(o);

                db.SaveChanges();
            }
        }

    }
}
