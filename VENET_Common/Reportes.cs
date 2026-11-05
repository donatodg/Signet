namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using VENET_DataEntity;
  
    public class Reportes
    {
        public class ComprobantesVentasReporte
        {
            public class DatosReporte
            {
                public string Sucursal { get; set; }
                public string Comprobante { get; set; }
                public string Letra { get; set; }
                public string NroCodigo { get; set; }
                public string PuntoVenta { get; set; }
                public string NroComprobante { get; set; }
                public EntidadReporte Entidad { get; set; }
                public string Vendedor { get; set; }
                public string FormaPago { get; set; }
                public DateTime Fecha { get; set; }
                public DateTime FechaVto { get; set; }
                public DateTime FechaEntrega { get; set; }
                public DateTime? FechaLiquidacion { get; set; }
                public string Observaciones { get; set; }
                public decimal PercepcionIva { get; set; }
                public decimal OtrosImpuestos { get; set; }
                public decimal Percepciones { get; set; }
                public decimal PercepcionIIBB { get; set; }
                public decimal ImpuestosTotal { get; set; }
                public decimal SubTotal { get; set; }
                public decimal SubTotal2 { get; set; }
                public decimal TotalIva { get; set; }
                public decimal ImporteTotal { get; set; }
                public string TotalEnLetras { get; set; }
                public string CodigoBarraCAE { get; set; }
                public string CodigoQrAfip { get; set; }
                public string AFIPCAE { get; set; }
                public string FechaVtoCAE { get; set; }
                public string ObservacionesCAE { get; set; }
                public virtual ICollection<ComprobantesVentasDetalle> Detalle { get; set; }
                public virtual ICollection<ComprobantesVentasImpuestos> Impuestos { get; set; }
                public string Impuestos1_Nombre { get; set; }
                public decimal? Impuestos1_Importe { get; set; }
                public string Impuestos2_Nombre { get; set; }
                public decimal? Impuestos2_Importe { get; set; }
                public string Impuestos3_Nombre { get; set; }
                public decimal? Impuestos3_Importe { get; set; }
                public string Impuestos4_Nombre { get; set; }
                public decimal? Impuestos4_Importe { get; set; }
                public string Impuestos5_Nombre { get; set; }
                public decimal? Impuestos5_Importe { get; set; }
                public EmpresasReporte Empresa { get; set; }
                public ComprobantesVentas Registro { get; set; }
                public string LeyendaOriginal { get; set; }
                public decimal? ImporteTotalSinDescuento_MAL { get; set; }
                public decimal? ImporteTotalDescuento_MAL { get; set; }
                public string Pedido { get; set; }

            }
        }

        public class OrdenesPagoReporte
        {
            public class DatosReporte
            {
                public EmpresasReporte Empresa { get; set; }
                public EntidadReporte Entidad { get; set; }
                public OrdenesPago Registro { get; set; }
                public string Letra { get; set; }
                public string PuntoVenta { get; set; }
                public string NroComprobante { get; set; }
                public DateTime Fecha { get; set; }
                public string Concepto { get; set; }
                public string Observaciones { get; set; }
                public decimal ImporteTotal { get; set; }
                public string TotalEnLetras { get; set; }
                public virtual ICollection<OrdenesPagoDetalle> Detalle { get; set; }
                public virtual ICollection<OrdenesPagoImpuestos> Impuestos { get; set; }
                public string LeyendaOriginal { get; set; }
            }
        }

        public class RecibosReporte
        {
            public class DatosReporte
            {
                public EmpresasReporte Empresa { get; set; }
                public EntidadReporte Entidad { get; set; }
                public Recibos Registro { get; set; }
                public string Letra { get; set; }
                public string PuntoVenta { get; set; }
                public string NroComprobante { get; set; }
                public DateTime Fecha { get; set; }
                public string Concepto { get; set; }
                public string Observaciones { get; set; }
                public decimal ImporteTotal { get; set; }
                public string TotalEnLetras { get; set; }
                public virtual ICollection<RecibosDetalle> Detalle { get; set; }
                public string LeyendaOriginal { get; set; }
            }
        }

        public class EmpresasReporte : Empresas
        {
            public string TipoIva { get; set; }
            public string Localidad { get; set; }
        }

        public class EntidadReporte
        {
            public string Nombre { get; set; }
            public string Domicilio { get; set; }
            public string Localidad { get; set; }
            public string Cuit { get; set; }
            public string TipoIva { get; set; }
            public decimal SaldoCtaCte { get; set; }
            public string Telefono { get; set; }
            public string DomicilioEntrega { get; set; }

        }

        public class CotizacionesReporte
        {
            public class DatosReporte
            {
                public string Sucursal { get; set; }
                public string Comprobante { get; set; }
                public string Letra { get; set; }
                public string PuntoVenta { get; set; }
                public string NroComprobante { get; set; }
                public EntidadReporte Entidad { get; set; }
                public string FormaPago { get; set; }
                public DateTime Fecha { get; set; }
                public DateTime? FechaLiquidacion { get; set; }
                public string Observaciones { get; set; }
                public decimal ImporteTotal { get; set; }
                public decimal ImporteSubTotal { get; set; }
                public string TotalEnLetras { get; set; }
                public string SubTotalEnLetras { get; set; }
                public virtual ICollection<CotizacionesDetalle> Detalle { get; set; }
                public EmpresasReporte Empresa { get; set; }
                public Cotizaciones Registro { get; set; }
            }
        }

        public class PedidosReporte
        {
            public class DatosReporte
            {
                public string Sucursal { get; set; }
                public string Comprobante { get; set; }
                public string Letra { get; set; }
                public string PuntoVenta { get; set; }
                public string NroComprobante { get; set; }
                public EntidadReporte Entidad { get; set; }
                public string FormaPago { get; set; }
                public DateTime Fecha { get; set; }
                public DateTime? FechaLiquidacion { get; set; }
                public DateTime? FechaEntrega { get; set; }
                public string Observaciones { get; set; }
                public decimal ImporteTotal { get; set; }
                public string TotalEnLetras { get; set; }
                public virtual ICollection<PedidosDetalle> Detalle { get; set; }
                public EmpresasReporte Empresa { get; set; }
                public Pedidos Registro { get; set; }
            }
        }

    }
}
