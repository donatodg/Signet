namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class EspeciesCotizacionesManager : IDisposable
    {
        private TesoreriaContext db;
        public List<EspeciesCotizaciones> Cotizaciones { get; set; }

        public EspeciesCotizacionesManager(ParametrosBusquedas o)
        {
            db = new TesoreriaContext();
            Cotizaciones = CargarCotizaciones(o);
        }

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        private List<EspeciesCotizaciones> CargarCotizaciones(ParametrosBusquedas par)
        {
            return (db.EspeciesCotizaciones.Where(t => t.Id_Especie == par.Id_Especie && t.FechaAdd >= par.FechaDesde)).ToList();
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaDesde = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
            }
            public DateTime FechaDesde { get; set; }
            public int Id_Especie { get; set; }
        }

    }
}
