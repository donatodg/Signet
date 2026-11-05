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

    public class RecibosComprobantesManager
    {
        public List<SearchResult> ComprobantesSinAsignar { get; private set; }

        public RecibosComprobantesManager()
        {

        }

        public List<SearchResult> Buscar(Enums.TipoEntidad TipoEntidad, int Id_Entidad, List<RecibosComprobantes> ListaAsignados)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from cc in db.ComprobantesVentas
                     where cc.UserDel == null
                     && cc.FechaLiquidacion != null
                     && cc.FechaAnulacion == null
                     && (db.TipoComprobante.Where(t => t.UserDel == null && t.GeneraDeuda == true && t.Id_Area == Enums.ComprobanteArea.Ventas).Select(t => t.Id)).Contains(cc.Id_TipoComprobante)
                     && cc.Id_TipoEntidad == TipoEntidad
                     && cc.Id_Entidad == Id_Entidad
                     && cc.Importe > (db.RecibosComprobantes.Where(t => t.Id_ComprobantesVentas == cc.Id && t.UserDel == null && t.ImportePago > 0).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum())
                     select new SearchResult
                     {
                         Seleccionado = false,
                         Id = cc.Id,
                         Fecha = cc.Fecha,
                         Comprobante = cc.Letra + "-" + cc.PuntoVenta + "-" + cc.NroComprobante,
                         Id_ComprobantesVentas = cc.Id,
                         Importe = cc.Importe.Value,
                         ImporteAdeudado = (cc.Importe - (db.RecibosComprobantes.Where(t => t.Id_ComprobantesVentas == cc.Id && t.UserDel == null && t.ImportePago > 0).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum())).Value,
                         ImportePago = (cc.Importe - (db.RecibosComprobantes.Where(t => t.Id_ComprobantesVentas == cc.Id && t.UserDel == null && t.ImportePago > 0).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum())).Value,
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

                    foreach (SearchResult s in result.Where(t => ListaAsignados.Select(a => a.Id_ComprobantesVentas).Contains(t.Id)))
                    {
                        r.Remove(s);
                    }
                }

                return r;
            }
        }

        public static void Eliminar(RecibosComprobantes o)
        {
            using (var db = new TesoreriaContext())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.Entry(o).Reload();
                db.RecibosComprobantes.Remove(o);

                db.SaveChanges();
            }
        }

        public static void AsociarComprobantes(int IdRecibo, List<RecibosComprobantes> ListaComprobantesSeleccionados)
        {
            RecibosManager rm = new RecibosManager(new Recibos() { Id = IdRecibo });

            if (ListaComprobantesSeleccionados.Where(t => t.Borrado == false).Select(t => t.ImportePago).DefaultIfEmpty(0).Sum() > rm.Recibo.ImporteSinAplicar)
                throw new ValidationException("El importe seleccionado supera al disponible.");


            foreach (RecibosComprobantes c in ListaComprobantesSeleccionados)
            {
                rm.Recibo.Comprobantes.Add(new RecibosComprobantes()
                {
                    Borrado = false,
                    Fecha = c.Fecha,
                    Id_ComprobantesVentas = c.Id_ComprobantesVentas,
                    ImporteAdeudado = c.ImporteAdeudado,
                    Importe = c.Importe,
                    ImportePago = c.ImportePago,
                    Comprobante = c.Comprobante,
                    FechaAdd = Sistema.ObtenerFechaHora(),
                    UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                });
            }

            rm.Save();
        }

        public class SearchResult : RecibosComprobantes
        {
            public bool Seleccionado { get; set; }
        }
    }
}
