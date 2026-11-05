namespace VENET_Produccion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public class ProduccionManoDeObraHistorialManager
    {
        public ProduccionManoDeObraHistorialManager()
        {
        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new ProduccionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from h in db.Produccion_ManoDeObraHistorial
                     join m in db.Produccion_ManoDeObra on h.Id_ManoObra equals m.Id into listMO
                     from mo in listMO
                     where (h.Id_ManoObra == parametros.Id_ManoObra)
                        && (h.FechaAdd >= parametros.Fecha)
                        && (h.UserDel == null)
                     select new SearchResult()
                     {
                         Id = h.Id,
                         PrecioHora = h.PrecioHora,
                         Id_ManoObra = h.Id_ManoObra,
                         ManoObra = mo.Descripcion,
                         FechaAdd = h.FechaAdd,
                         UserAdd = h.UserAdd
                     }).ToList();
                return r;

            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                Fecha = Sistema.ObtenerFecha().AddYears(-1);
            }

            public int Id_ManoObra { get; set; }
            public DateTime Fecha { get; set; }
        }

        public class SearchResult : Produccion_ManoDeObraHistorial
        {
            public string ManoObra { get; set; }
        }

    }
}
