namespace VENET_Gestion_BL
{
    using System.Collections.Generic;
    using System.Linq;
    using VENET_Comun;
    using VENET_DataEntity;

    public class ComprobantesVentasPresentacionManager
    {
        public ComprobantesVentasPresentacionManager()
        {
        }

        public static List<SearchResult> Buscar(int Id_Empresa)
        {
            List<SearchResult> r = new List<SearchResult>();

            using (var db = new GestionContext())
            {
                r = (from v in db.ComprobantesVentas
                     join t in db.TalonariosComprobantes on v.Id_TalonariosComprobantes equals t.Id into listComp
                     from tc in listComp
                     join c in db.CentrosCostos on v.Id_CentroCosto equals c.Id into listCC
                     from cen in listCC.DefaultIfEmpty()
                     join s in db.Sucursales on v.Id_Sucursal equals s.Id into listSuc
                     from suc in listSuc
                     where suc.Id_Empresa == Id_Empresa
                        && tc.Electronico == true
                        && (v.AFIPCAE == null || v.AFIPCAE == "")
                        && v.FechaAnulacion == null
                        && v.FechaLiquidacion != null
                        && v.UserDel == null
                     select new SearchResult()
                     {
                         Id = v.Id,
                         AFIPCAE = v.AFIPCAE,
                         Centro_Costo = cen.Descripcion,
                         Fecha = v.Fecha,
                         FechaAdd = v.FechaAdd,
                         FechaAnulacion = v.FechaAnulacion,
                         FechaEntrega = v.FechaEntrega,
                         FechaEntregado = v.FechaEntregado,
                         FechaImpreso = v.FechaImpreso,
                         FechaLiquidacion = v.FechaLiquidacion,
                         FechaMod = v.FechaMod,
                         FechaVto = v.FechaVto,
                         FechaVtoCAE = v.FechaVtoCAE,
                         Id_CentroCosto = v.Id_CentroCosto,
                         Id_ComprobanteVenta_Anulado = v.Id_ComprobanteVenta_Anulado,
                         Id_ComprobanteVenta_Procesado = v.Id_ComprobanteVenta_Procesado,
                         Id_Entidad = v.Id_Entidad,
                         Id_EntidadDomicilioEntrega = v.Id_EntidadDomicilioEntrega,
                         Id_FormaPago = v.Id_FormaPago,
                         Id_Sucursal = v.Id_Sucursal,
                         Id_TalonariosComprobantes = v.Id_TalonariosComprobantes,
                         Id_TipoComprobante = v.Id_TipoComprobante,
                         Id_TipoEntidad = v.Id_TipoEntidad,
                         Id_Vendedor = v.Id_Vendedor,
                         Importe = v.Importe,
                         ImportePesos = v.ImportePesos,
                         Letra = v.Letra,
                         MotivoAnulacion = v.MotivoAnulacion,
                         Nombre_Entidad = v.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == v.Id_Entidad).Select(c => c.Empresa == null ? c.Nombre : c.Empresa).FirstOrDefault()
                                        : v.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == v.Id_Entidad).Select(c => c.Empresa == null ? c.Nombre : c.Empresa).FirstOrDefault()
                                        : v.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                        join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                        from prov in listPF
                                                                                                        where pfc.Id == v.Id_Entidad
                                                                                                        select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                                        : v.Id_TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == v.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",
                         NroComprobante = v.NroComprobante,
                         Observaciones = v.Observaciones,
                         ObservacionesCAE = v.ObservacionesCAE,
                         OtrosImpuestos = v.OtrosImpuestos,
                         PercepcionIIBB = v.PercepcionIIBB,
                         PercepcionIva = v.PercepcionIva,
                         PuntoVenta = v.PuntoVenta,
                         Retenciones = v.Retenciones,
                         Sucursal = suc.Descripcion,
                         UserAdd = v.UserAdd,
                         UserMod = v.UserMod
                     }).OrderBy(t => new { t.Fecha, t.Id_TipoComprobante, t.Letra, t.PuntoVenta, t.NroComprobante }).ToList();
            }
            return r;
        }


        public class SearchResult : ComprobantesVentas
        {
            public string Sucursal { get; set; }
            public string Nombre_Entidad { get; set; }
            public string Centro_Costo { get; set; }
        }

    }
}
