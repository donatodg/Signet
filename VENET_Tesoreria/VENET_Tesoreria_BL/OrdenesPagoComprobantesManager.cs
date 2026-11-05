namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class OrdenesPagoComprobantesManager
    {
        public List<SearchResult> ComprobantesSinAsignar { get; private set; }

        public OrdenesPagoComprobantesManager()
        {

        }

        public List<SearchResult> Buscar(Enums.TipoEntidad TipoEntidad, int Id_Entidad, List<OrdenesPagoComprobantes> ListaAsignados)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from cc in db.ComprobantesCompras
                     where cc.UserDel == null
                     && cc.FechaLiquidacion != null
                     && cc.FechaAnulacion == null
                     && (db.TipoComprobante.Where(t => t.UserDel == null && t.GeneraDeuda == true && t.Id_Area == Enums.ComprobanteArea.Compras).Select(t => t.Id)).Contains(cc.Id_TipoComprobante)
                     && cc.Id_TipoEntidad == TipoEntidad
                     && cc.Id_Entidad == Id_Entidad
                     && cc.Importe > (db.OrdenesPagoComprobantes.Where(t => t.Id_ComprobantesCompras == cc.Id && t.UserDel == null && t.ImportePago > 0).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum())
                     select new SearchResult
                     {
                         Seleccionado = false,
                         Id = cc.Id,
                         Fecha = cc.Fecha,
                         Comprobante = cc.Letra + "-" + cc.PuntoVenta + "-" + cc.NroComprobante,
                         Id_ComprobantesCompras = cc.Id,
                         Importe = cc.Importe.Value,
                         ImporteAdeudado = (cc.Importe - (db.OrdenesPagoComprobantes.Where(t => t.Id_ComprobantesCompras == cc.Id && t.UserDel == null && t.ImportePago > 0).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum())).Value,
                         ImportePago = (cc.Importe - (db.OrdenesPagoComprobantes.Where(t => t.Id_ComprobantesCompras == cc.Id && t.UserDel == null && t.ImportePago > 0).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum())).Value,
                         UserAdd = cc.UserAdd,
                         UserMod = cc.UserMod,
                         FechaAdd = cc.FechaAdd,
                         FechaMod = cc.FechaMod,
                     }).ToList();

                if (ListaAsignados.Count() > 0)
                {
                    List<SearchResult> result = new List<SearchResult>();
                    foreach (SearchResult x in r)
                    {
                        result.Add(x);
                    }

                    foreach (SearchResult s in result.Where(t => ListaAsignados.Select(a => a.Id_ComprobantesCompras).Contains(t.Id)))
                    {
                        r.Remove(s);
                    }
                }

                return r;
            }
        }

        public static void Eliminar(OrdenesPagoComprobantes o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.OrdenesPagoComprobantes.Remove(o);

                db.SaveChanges();
            }
        }

        public static void AsociarComprobantes(int IdOrdenPago, List<OrdenesPagoComprobantes> ListaComprobantesSeleccionados)
        {
            OrdenesPagoManager opm = new OrdenesPagoManager(new OrdenesPago() { Id = IdOrdenPago });

            if (ListaComprobantesSeleccionados.Where(t => t.Borrado == false).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum() > opm.OP.ImporteSinAplicar)
                throw new ValidationException("El importe seleccionado supera al disponible.");


            foreach (OrdenesPagoComprobantes c in ListaComprobantesSeleccionados)
            {
                opm.OP.Comprobantes.Add(new OrdenesPagoComprobantes()
                {
                    Borrado = false,
                    Fecha = c.Fecha,
                    Id_ComprobantesCompras = c.Id_ComprobantesCompras,
                    ImporteAdeudado = c.ImporteAdeudado,
                    Importe = c.Importe,
                    ImportePago = c.ImportePago,
                    Comprobante = c.Comprobante,
                    FechaAdd = Sistema.ObtenerFechaHora(),
                    UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                });
            }

            opm.Save();
        }

        public class SearchResult : OrdenesPagoComprobantes
        {
            public bool Seleccionado { get; set; }
        }
    }
}
