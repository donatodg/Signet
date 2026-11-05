namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ReciboDetalleManager : IDisposable
    {
        private TesoreriaContext db = new TesoreriaContext();
        public RecibosDetalle ReciboDetalle { get; set; }
        private int IdSucursal;

        public ReciboDetalleManager(RecibosDetalle o, int Id_Sucursal)
        {
            ReciboDetalle = o;
            IdSucursal = Id_Sucursal;

            if (ReciboDetalle.Id_Especie == 0)
            {
                if (Especies.Count > 0)
                    IdEspecie = ReciboDetalle.Id_Especie = Especies.First().Key;

                //  ReciboDetalle.Detalle = "Efectivo";
            }
           
        }

        public int? IdEspecie
        {
            get
            {
                return ReciboDetalle.Id_Especie == 0 ? null : (int?)ReciboDetalle.Id_Especie;
            }
            set
            {
                if (value == null || value == 0)
                {
                    ReciboDetalle.Id_Especie = 0;
                    ReciboDetalle.Cotizacion = 0;
                }
                else
                {
                    ReciboDetalle.Id_Especie = (int)value;
                    ReciboDetalle.Cotizacion = db.Especies.Where(t => t.Id == ReciboDetalle.Id_Especie).Select(t => t.Cotizacion).FirstOrDefault();
                }
            }
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public List<KeyNamePair> Especies
        {
            get
            {
                using (GeneralContext db = new GeneralContext())
                {
                    return db.Especies.Where(t => t.UserDel == null &&
                      (db.Cajas.Where(c => Seguridad.IdCajasAsignadas.Contains(c.Id) && c.Id_Sucursal == IdSucursal).Select(c => c.Id_Especie)).Contains(t.Id))
                        .Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).OrderBy(t => t.Key).ToList();
                }
            }
        }

        public List<KeyNamePair> EspeciesPF
        {
            get
            {
                using (var db = new TesoreriaContext())
                    return db.Especies.Where(t => t.UserDel == null && t.Id == (db.ProvFinancierosCuentas.Where(tt => tt.Id == ReciboDetalle.Id_Entidad).Select(tt => tt.Id_Especie).FirstOrDefault())).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList();
            }
        }

        public List<KeyNamePair> TipoPercepciones
        {
            get
            {
                using (var db = new TesoreriaContext())
                    return db.TipoPercepciones.Where(t => t.UserDel == null).Select(t => new KeyNamePair() { Key = t.Id, Name = t.Descripcion }).ToList();
            }
        }
        public List<KeyNamePair> Entidades
        {
            get
            {
                using (var db = new TesoreriaContext())
                    return Sistema.ObtenerEntidades(ReciboDetalle.Id_TipoEntidad);
            }
        }

        public static void Eliminar(RecibosDetalle o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.RecibosDetalle.Remove(o);

                db.SaveChanges();
            }
        }

    }
}
