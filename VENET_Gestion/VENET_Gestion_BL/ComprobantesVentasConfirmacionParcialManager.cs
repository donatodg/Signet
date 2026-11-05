namespace VENET_Gestion_BL
{
    using System.Collections.Generic;
    using System.Linq;
    using VENET_DataEntity;

    public class ComprobantesVentasConfirmacionParcialManager
    {
        public ComprobantesVentasConfirmacionParcialManager()
        {

        }

        public static List<SearchResult> Buscar(int Id_ComprobanteVenta)
        {
            List<SearchResult> r = new List<SearchResult>();

            using (var db = new GestionContext())
            {
                r = (from v in db.ComprobantesVentas
                     join det in db.ComprobantesVentasDetalle on v.Id equals det.Id_ComprobanteVenta into listCVD
                     from cvd in listCVD
                     where v.Id == Id_ComprobanteVenta
                        && v.FechaAnulacion == null
                        && v.FechaLiquidacion == null
                        && v.UserDel == null
                        && cvd.UserDel == null
                     select new SearchResult()
                     {
                         Id = v.Id,
                         Producto = cvd.Descripcion,
                         Cantidad = cvd.Cantidad,
                         CantidadProcesada = (from dfs in db.ComprobantesVentasDetalleProcesados
                                              join vent in db.ComprobantesVentas on dfs.Id_ComprobanteVentaOriginal equals vent.Id into listCV
                                              from cv in listCV
                                              where dfs.Id_ComprobanteVentaOriginal == Id_ComprobanteVenta
                                                 && dfs.Id_ComprobanteVentaDetalle == cvd.Id  
                                                 && cv.FechaAnulacion == null
                                                 && dfs.FechaDel == null
                                                 && cv.FechaDel == null
                                              select dfs.Cantidad ).DefaultIfEmpty(0).Sum(),
                         CantidadAProcesar = 0,
                         Id_ComprobanteVentaDetalle = cvd.Id,
                         Id_ComprobanteVentaOriginal = v.Id,
                         Id_ComprobanteVentaProcesado = 0,
                         FechaAdd = v.FechaAdd,
                         FechaMod = v.FechaMod,
                         UserAdd = v.UserAdd,
                         UserMod = v.UserMod
                     }).ToList();
            }
            return r;
        }

        public class SearchResult : ComprobantesVentasDetalleProcesados
        {
            public string Producto { get; set; }
            public decimal CantidadProcesada { get; set; }
            public decimal CantidadAProcesar { get; set; }
        }

    }
}
