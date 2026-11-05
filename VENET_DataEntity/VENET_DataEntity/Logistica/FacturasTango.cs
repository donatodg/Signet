namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("FacturasTango")]
    public class FacturasTango : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para Id_CPA04 es obligatorio.")]
        public int Id_CPA04 { get; set; }
        [StringLength(10)]
        public string Id_Proveedor { get; set; }
        [StringLength(100)]
        public string Proveedor { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de emisión es obligatoria.")]
        public DateTime FechaEmision { get; set; }
        public decimal Cotizacion { get; set; }
        public decimal ImporteNeto { get; set; }
        public decimal ImporteTotal { get; set; }
        [StringLength(500)]
        public string Leyenda { get; set; }
        [StringLength(10)]
        public string TipoComprobante { get; set; }
        [StringLength(20)]
        public string NroComprobante { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateTime FechaIngreso { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para hora ingreso es obligatorio.")]
        public int HoraIngreso { get; set; }
        public DateTime? FechaAsociacion { get; set; }
        public int? UserAsociacion { get; set; }
        [StringLength(800)]
        public string ObservacionesAsociacion { get; set; }
        [StringLength(800)]
        public string Observaciones { get; set; }
        public decimal? Diferencia { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool? Cerrada { get; set; }
        public int? Id_EstadoFactura { get; set; }
        public string Caja { get; set; }
        public int? Orden { get; set; }
        public bool SinRecupero { get; set; }
        public bool? EsPeaje { get; set; }

    }
}
