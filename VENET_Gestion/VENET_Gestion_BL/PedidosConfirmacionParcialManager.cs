namespace VENET_Gestion_BL
{
    using System.Collections.Generic;
    using System.Linq;
    using VENET_DataEntity;

    public class PedidosConfirmacionParcialManager
    {
        public PedidosConfirmacionParcialManager()
        {

        }

        public static List<SearchResult> Buscar(int Id_Pedido)
        {
            List<SearchResult> r = new List<SearchResult>();

            using (var db = new GestionContext())
            {
                r = (from v in db.Pedidos
                     join det in db.PedidosDetalle on v.Id equals det.Id_Pedido into listCVD
                     from cvd in listCVD
                     where v.Id == Id_Pedido
                        && v.FechaAnulacion == null
                        && v.FechaLiquidacion != null
                        && v.Id_ComprobanteGenerado == null
                        && v.UserDel == null
                        && cvd.UserDel == null
                     select new SearchResult()
                     {
                         Id = v.Id,
                         Producto = cvd.Descripcion,
                         Cantidad = cvd.Cantidad,
                         CantidadProcesada = (from dfs in db.PedidosDetalleProcesados
                                              join vent in db.Pedidos on dfs.Id_PedidoOriginal equals vent.Id into listCV
                                              from cv in listCV
                                              where dfs.Id_PedidoOriginal == Id_Pedido
                                                 && dfs.Id_PedidoDetalle == cvd.Id
                                                 && cv.FechaAnulacion == null
                                                 && dfs.FechaDel == null
                                                 && cv.FechaDel == null
                                              select dfs.Cantidad).DefaultIfEmpty(0).Sum(),
                         CantidadAProcesar = 0,
                         Id_PedidoDetalle = cvd.Id,
                         Id_PedidoOriginal = v.Id,
                         Id_ComprobanteVentaProcesado = 0,
                         FechaAdd = v.FechaAdd,
                         FechaMod = v.FechaMod,
                         UserAdd = v.UserAdd,
                         UserMod = v.UserMod
                     }).ToList();
            }
            return r;
        }

        public class SearchResult : PedidosDetalleProcesados
        {
            public string Producto { get; set; }
            public decimal CantidadProcesada { get; set; }
            public decimal CantidadAProcesar { get; set; }
        }

    }
}
