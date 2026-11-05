namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("ComprobantesCompras")]
    public class ComprobantesCompras : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para depósito es obligatorio.")]
        public int Id_Deposito { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de comprobante es obligatorio.")]
        public int Id_TipoComprobante { get; set; }
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
        [Range(1, 2147483647, ErrorMessage = "El valor para forma de pago es obligatorio.")]
        public int Id_FormaPago { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        public DateTime FechaRecepcion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateTime FechaVto { get; set; }
        [Required(ErrorMessage = "El campo observaciones es obligatorio.")]
        [StringLength(1000)]
        public string Observaciones { get; set; }
        public decimal PercepcionIva { get; set; }
        public decimal OtrosImpuestos { get; set; }
        public decimal PercepcionGanancias { get; set; }
        public decimal PercepcionIIBB { get; set; }
        public decimal ImpuestoNoGravado { get; set; }
        public decimal ITC { get; set; }
        public decimal PercepcionIIBBCapital { get; set; }
        public decimal Descuento { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        [StringLength(300)]
        public string MotivoAnulacion { get; set; }
        public decimal? Importe { get; set; }
        public decimal? ImportePesos { get; set; }



        public virtual ICollection<ComprobantesComprasDetalle> Detalle { get; set; }

        [NotMapped]
        public string Comprobante { get { return Letra + "-" + PuntoVenta + "-" + NroComprobante; } }
    }
}
