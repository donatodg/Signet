namespace VENET_Gestion_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public class ComprobantesVentas_ReporteCompletoManager
    {
        public ComprobantesVentas_ReporteCompletoManager()
        {

        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new GestionContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from cv in db.ComprobantesVentas
                     join d in db.ComprobantesVentasDetalle on cv.Id equals d.Id_ComprobanteVenta into listCVD
                     from cvd in listCVD
                     join suc in db.Sucursales on cv.Id_Sucursal equals suc.Id into listSuc
                     from s in listSuc
                     join emp in db.Empresas on s.Id_Empresa equals emp.Id into listEmp
                     from e in listEmp
                     join dep in db.Depositos on cv.Id_Deposito equals dep.Id into listDep
                     from d in listDep
                     join centro in db.CentrosCostos on cv.Id_CentroCosto equals centro.Id into listCC
                     from cc in listCC
                     join tipoC in db.TipoComprobante on cv.Id_TipoComprobante equals tipoC.Id into listTC
                     from tc in listTC
                     join ven in db.Vendedores on cv.Id_Vendedor equals ven.Id into listVen
                     from v in listVen
                     join fpago in db.FormasPagos on cv.Id_FormaPago equals fpago.Id into listFP
                     from fp in listFP
                     join espec in db.Especies on cvd.Id_Especie equals espec.Id into listEsp
                     from esp in listEsp
                     join prod in db.Productos on cvd.Id_Producto equals prod.Id into listProd
                     from p in listProd.DefaultIfEmpty()
                     join cat in db.ProductosCategorias on p.Id_Categoria equals cat.Id into listCat
                     from c in listCat.DefaultIfEmpty()
                     where (e.Id  == parametros.Id_Empresa || parametros.Id_Empresa == null)
                        && (cv.Id_TipoComprobante == parametros.Id_TipoComprobante || parametros.Id_TipoComprobante == null)
                        && (cv.Fecha >= parametros.FechaDesde && cv.Fecha <= parametros.FechaHasta)
                        && (cv.FechaAnulacion == null)
                        && (cv.FechaLiquidacion != null)
                        && (tc.GeneraDeuda == true && parametros.SoloGeneraDeuda == true || parametros.SoloGeneraDeuda == false)
                        && (cvd.UserDel == null)
                        && (cv.UserDel == null)
                        && Seguridad.IdEmpresasAsignadas.Contains(e.Id)
                     select new SearchResult
                     {
                         Empresa = e.Nombre,
                         Id = cv.Id,
                         Id_Deposito = cv.Id_Deposito,
                         Deposito = d.Descripcion,
                         Id_Sucursal = cv.Id_Sucursal,
                         Sucursal = s.Descripcion,
                         Id_CentroCosto = cv.Id_CentroCosto,
                         CentroCosto = cc.Descripcion,
                         Id_TipoComprobante = cv.Id_TipoComprobante,
                         TipoComprobante = tc.Descripcion,
                         Id_TalonariosComprobantes = cv.Id_TalonariosComprobantes,
                         Letra = cv.Letra,
                         PuntoVenta = cv.PuntoVenta,
                         NroComprobante = cv.NroComprobante,
                         Id_TipoEntidad = cv.Id_TipoEntidad,
                         Id_Entidad = cv.Id_Entidad,
                         NombreEntidad = cv.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == cv.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : cv.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == cv.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : cv.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                         join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                         from prov in listPF
                                                                                                         where pfc.Id == cv.Id_Entidad
                                                                                                         select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                                        : cv.Id_TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == cv.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",
                         CuitEntidad = cv.Id_TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == cv.Id_Entidad).Select(c => c.Cuit).FirstOrDefault()
                                        : cv.Id_TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == cv.Id_Entidad).Select(c => c.Cuit).FirstOrDefault()
                                        : cv.Id_TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                         join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                         from prov in listPF
                                                                                                         where pfc.Id == cv.Id_Entidad
                                                                                                         select prov.Cuit).FirstOrDefault()
                                        : cv.Id_TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == cv.Id_Entidad).Select(c => c.Cuit).FirstOrDefault() : "",
                         Id_Vendedor = cv.Id_Vendedor,
                         Vendedor = v.Nombre,
                         Id_FormaPago = cv.Id_FormaPago,
                         FormaPago = fp.Descripcion,
                         Id_EntidadDomicilioEntrega = cv.Id_EntidadDomicilioEntrega,
                         Fecha = cv.Fecha,
                         FechaEntrega = cv.FechaEntrega,
                         FechaEntregado = cv.FechaEntregado,
                         FechaVto = cv.FechaVto,
                         FechaImpreso = cv.FechaImpreso,
                         Observaciones = cv.Observaciones,
                         PercepcionIva = cv.PercepcionIva,
                         OtrosImpuestos = cv.OtrosImpuestos,
                         Retenciones = cv.Retenciones,
                         PercepcionIIBB = cv.PercepcionIIBB,
                         FechaLiquidacion = cv.FechaLiquidacion,
                         AFIPCAE = cv.AFIPCAE,
                         ResultadoCAE = cv.ResultadoCAE,
                         FechaVtoCAE = cv.FechaVtoCAE,
                         ObservacionesCAE = cv.ObservacionesCAE,
                         EventosCAE = cv.EventosCAE,
                         Importe = cv.Importe,
                         ImportePesos = cv.ImportePesos,
                         Especie = esp.Descripcion,
                         Cotizacion = cvd.Cotizacion,
                         Id_Producto = cvd.Id_Producto,
                         Producto = cvd.Descripcion,
                         Cantidad = cvd.Cantidad,
                         CantidadStock = cvd.CantidadStock,
                         ImporteCosto = cvd.ImporteCosto,
                         PorcDescuento = cvd.PorcDescuento,
                         ImporteUnitario = cvd.ImporteUnitario,
                         Id_AlicuotaIva = cvd.Id_AlicuotaIva,
                         AlicuotaIva = cvd.AlicuotaIva,
                         ImporteIva = cvd.ImporteIVA,
                         ImporteProducto = cvd.Importe,
                         Categoria = c.Descripcion,
                         Codigo = p.Codigo,
                         CodigoBarras = p.CodigoBarras,
                         CodigoFabrica = p.CodigoFabrica,
                         FechaAdd = cv.FechaAdd,
                         FechaMod = cv.FechaMod,
                         UserAdd = cv.UserAdd,
                         UserMod = cv.UserMod
                     }).ToList();
                return r;
            }
        }

        public class ParametrosBusquedas
        {
            public ParametrosBusquedas()
            {
                FechaDesde = new DateTime(Sistema.ObtenerFechaHora().Year, Sistema.ObtenerFechaHora().Month, 1);
                FechaHasta = FechaDesde.AddMonths(1).AddDays(-1);
                Id_Empresa = Sistema.Empresas.First().Key;
                SoloGeneraDeuda = false;
            }

            public int? Id_Empresa { get; set; }
            public int? Id_TipoComprobante { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
            public bool SoloGeneraDeuda { get; set; }
        }

        public class SearchResult : ComprobantesVentas
        {
            public string Empresa { get; set; }    
            public string Deposito { get; set; }
            public string Sucursal { get; set; }
            public string CentroCosto { get; set; }
            public string TipoComprobante { get; set; }
            public string NombreEntidad { get; set; }
            public string CuitEntidad { get; set; }
            public string Vendedor { get; set; }
            public string FormaPago { get; set; }
            public string Especie { get; set; }
            public decimal Cotizacion { get; set; }
            public int? Id_Producto { get; set; }
            public string Producto { get; set; }
            public string Categoria { get; set; }
            public decimal Cantidad { get; set; }
            public decimal? CantidadStock { get; set; }
            public decimal ImporteCosto { get; set; }
            public decimal PorcDescuento { get; set; }
            public decimal ImporteUnitario { get; set; }
            public int Id_AlicuotaIva { get; set; }
            public decimal AlicuotaIva { get; set; }
            public decimal ImporteIva { get; set; }
            public decimal ImporteProducto { get; set; }
            public string Codigo { get; set; }
            public string CodigoBarras { get; set; }
            public string CodigoFabrica { get; set; }
        }
    }
}
