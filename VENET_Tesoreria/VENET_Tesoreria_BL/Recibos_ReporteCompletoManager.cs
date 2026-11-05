namespace VENET_Tesoreria_BL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using static VENET_Common.Parametro;

    public class Recibos_ReporteCompletoManager
    {
        public Recibos_ReporteCompletoManager()
        {

        }

        public static List<SearchResult> Buscar(ParametrosBusquedas parametros)
        {
            using (var db = new TesoreriaContext())
            {
                List<SearchResult> r = new List<SearchResult>();

                r = (from o in db.Recibos
                     join d in db.RecibosDetalle on o.Id equals d.Id_Recibo into listCVD
                     from od in listCVD
                     join suc in db.Sucursales on o.Id_Sucursal equals suc.Id into listSuc
                     from s in listSuc
                     join emp in db.Empresas on s.Id_Empresa equals emp.Id into listEmp
                     from e in listEmp
                     join centro in db.CentrosCostos on o.Id_CentroCosto equals centro.Id into listCC
                     from cc in listCC
                     join espec in db.Especies on od.Id_Especie equals espec.Id into listEsp
                     from esp in listEsp
                     join tipoPer in db.TipoPercepciones on od.Id_TipoPercepcion equals tipoPer.Id into listPer
                     from p in listPer.DefaultIfEmpty()
                     where (s.Id == parametros.Id_Sucursal)
                        && (o.Fecha >= parametros.FechaDesde && o.Fecha <= parametros.FechaHasta)
                        && ((od.Id_TipoPercepcion > 0 && parametros.SoloPercepciones == true) || parametros.SoloPercepciones == false)
                        && (o.Fecha_Anulacion == null)
                        && (o.Fecha_Liquidacion != null)
                        && (od.UserDel == null)
                        && (o.UserDel == null)
                     select new SearchResult
                     {
                         Id = o.Id,
                         Id_Sucursal = o.Id_Sucursal,
                         Sucursal = s.Descripcion,
                         Id_CentroCosto = o.Id_CentroCosto,
                         CentroCosto = cc.Descripcion,
                         Id_TalonariosComprobantes = o.Id_TalonariosComprobantes,
                         Letra = o.Letra,
                         PuntoVenta = o.PuntoVenta,
                         NroComprobante = o.NroComprobante,
                         TipoEntidad = o.TipoEntidad,
                         Id_Entidad = o.Id_Entidad,
                         NombreEntidad = o.TipoEntidad == Enums.TipoEntidad.Cliente ? db.Clientes.Where(c => c.Id == o.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : o.TipoEntidad == Enums.TipoEntidad.Proveedor ? db.Proveedores.Where(c => c.Id == o.Id_Entidad).Select(c => c.Nombre).FirstOrDefault()
                                        : o.TipoEntidad == Enums.TipoEntidad.Proveedor_Financiero ? (from pfc in db.ProvFinancierosCuentas
                                                                                                     join pf in db.ProvFinancieros on pfc.Id_ProvFinanciero equals pf.Id into listPF
                                                                                                     from prov in listPF
                                                                                                     where pfc.Id == o.Id_Entidad
                                                                                                     select prov.Nombre + "-" + pfc.CBU).FirstOrDefault()
                                        : o.TipoEntidad == Enums.TipoEntidad.Personal ? db.Personal.Where(c => c.Id == o.Id_Entidad).Select(c => c.Apellido + ", " + c.Nombre).FirstOrDefault() : "",
                         Fecha = o.Fecha,
                         Observaciones = o.Observaciones,
                         Importe = o.Importe,
                         ImporteSinAplicar = o.ImporteSinAplicar,
                         Especie = esp.Descripcion,
                         Concepto = o.Concepto,
                         Cotizacion = od.Cotizacion,
                         Detalle = o.Detalle,
                         DetalleItem = od.Detalle,
                         Fecha_Liquidacion = o.Fecha_Liquidacion,
                         Id_Documento = od.Id_Documento,
                         Id_Especie = od.Id_Especie,
                         ImporteItem = od.Importe,
                         //TipoMovimiento  = od.TipoMovimiento,
                         Id_TipoEntidad = od.Id_TipoEntidad,
                         TarjetaDebito = od.TarjetaDebito,
                         TarjetaCredito = od.TarjetaCredito,
                         Id_TipoPercepcion = od.Id_TipoPercepcion,
                         Percepcion = p.Descripcion,
                         FechaAdd = o.FechaAdd,
                         FechaMod = o.FechaMod,
                         UserAdd = o.UserAdd,
                         UserMod = o.UserMod
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
                Id_Sucursal = Sistema.Sucursales.First().Id_Sucursal;
            }

            public int Id_Sucursal { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }
            public bool SoloPercepciones { get; set; }
        }

        public class SearchResult : Recibos
        {
            public string Sucursal { get; set; }
            public string CentroCosto { get; set; }
            public string NombreEntidad { get; set; }
            public string Especie { get; set; }
            public int Id_Especie { get; set; }
            public decimal Cotizacion { get; set; }
            public decimal ImporteItem { get; set; }
            public string DetalleItem { get; set; }
            public int? Id_Documento { get; set; }
            public Enums.TipoEntidad? Id_TipoEntidad { get; set; }
            public bool? TarjetaDebito { get; set; }
            public bool? TarjetaCredito { get; set; }
            public string TipoMovimiento
            {
                get
                {
                    if (Id_Documento > 0) return "Cheque";
                    else if (Id_TipoEntidad > 0) return "Cta.Cte.";
                    else if (TarjetaDebito == true) return "T.Débito";
                    else if (TarjetaCredito == true) return "T.Crédito";
                    else if (Id_TipoPercepcion > 0) return "Percepción";
                    else if (Id_Documento == null &&
                             Id_TipoEntidad == null &&
                             Id_TipoPercepcion == null &&
                             TarjetaDebito == null &&
                             TarjetaCredito == null
                             ) return "Efectivo";
                    else return "";
                }
            }
            public int? Id_TipoPercepcion { get; set; }
            public string Percepcion { get; set; }

        }
    }
}
