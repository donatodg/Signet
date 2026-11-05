namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("ComprobantesVentas")]
    public class ComprobantesVentas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para depósito es obligatorio.")]
        public int Id_Deposito { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de comprobante es obligatorio.")]
        public int Id_TipoComprobante { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para talonario es obligatorio.")]
        public int Id_TalonariosComprobantes { get; set; }
        [Required(ErrorMessage = "El campo letra es obligatorio.")]
        [StringLength(2)]
        public string Letra { get; set; }
        [Required(ErrorMessage = "El campo punto de venta es obligatorio.")]
        [StringLength(4)]
        public string PuntoVenta { get; set; }
        [Required(ErrorMessage = "El campo número de comprobante es obligatorio.")]
        [StringLength(8)]
        public string NroComprobante { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de entidad es obligatorio.")]
        public Enums.TipoEntidad Id_TipoEntidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        public int? Id_Entidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para vendedor es obligatorio.")]
        public int Id_Vendedor { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para forma de pago es obligatorio.")]
        public int Id_FormaPago { get; set; }
        public int? Id_EntidadDomicilioEntrega { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de entrega es obligatoria.")]
        public DateTime FechaEntrega { get; set; }
        public DateTime? FechaEntregado { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateTime FechaVto { get; set; }
        public DateTime? FechaImpreso { get; set; }
        [Required(ErrorMessage = "El campo observaciones es obligatorio.")]
        [StringLength(1000)]
        public string Observaciones { get; set; }
        public decimal PercepcionIva { get; set; }
        public decimal OtrosImpuestos { get; set; }
        public decimal Retenciones { get; set; }
        public decimal PercepcionIIBB { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        [StringLength(14)]
        public string AFIPCAE { get; set; }
        [StringLength(50)]
        public string ResultadoCAE { get; set; }
        [StringLength(50)]
        public string FechaVtoCAE { get; set; }
        [StringLength(8000)]
        public string ObservacionesCAE { get; set; }
        [StringLength(8000)]
        public string EventosCAE { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        [StringLength(300)]
        public string MotivoAnulacion { get; set; }
        public int? Id_ComprobanteVenta_Original { get; set; }
        public int? Id_ComprobanteVenta_Procesado { get; set; }
        public int? Id_ComprobanteVenta_Anulado { get; set; }
        public decimal? Importe { get; set; }
        public decimal? ImportePesos { get; set; }
        public int? Id_ComprobanteVenta_Asociado { get; set; }


        public virtual ICollection<ComprobantesVentasDetalle> Detalle { get; set; }
        public virtual ICollection<ComprobantesVentasImpuestos> Impuestos { get; set; }


        [NotMapped]
        public string Comprobante { get { return Letra + "-" + PuntoVenta + "-" + NroComprobante; } }
    }
}
