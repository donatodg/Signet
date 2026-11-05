namespace VENET_General_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using VENET_DataEntity;

    public class TipoViaticosPreciosManager : IDisposable
    {
        private GeneralContext db;
        public TipoViaticosPrecios Precio { get; set; }

        public TipoViaticosPreciosManager(TipoViaticosPrecios o)
        {
            db = new GeneralContext();
            Precio = o;
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        public static void Eliminar(TipoViaticosPrecios o)
        {
            using (var db = new GeneralContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.TipoViaticosPrecios.Remove(o);

                db.SaveChanges();
            }
        }

        public Boolean ValidaVigencia(List<TipoViaticosPrecios> ListDetalles)
        {
            //if (db.TipoViaticosPrecios.Where(t => (Precio.VigenciaDesde >= t.VigenciaDesde && Precio.VigenciaDesde <= t.VigenciaHasta)
            //                               && t.Id != Precio.Id
            //                               && t.UserDel == null
            //                               && t.Id_TipoViatico == Precio.Id_TipoViatico).Count() > 0) return false;
            //else return true;

            foreach (TipoViaticosPrecios r in ListDetalles)
            {
                if ((Precio.Id != r.Id || Precio.Id == 0) &&
                    ((Precio.VigenciaDesde >= r.VigenciaDesde && Precio.VigenciaDesde <= r.VigenciaHasta) ||
                    (Precio.VigenciaHasta >= r.VigenciaDesde && Precio.VigenciaHasta <= r.VigenciaHasta) ||
                    (Precio.VigenciaDesde <= r.VigenciaDesde && Precio.VigenciaHasta >= r.VigenciaHasta)) &&
                    r.Borrado == false)
                    return false;
            }
            return true;
        }

    }
}
