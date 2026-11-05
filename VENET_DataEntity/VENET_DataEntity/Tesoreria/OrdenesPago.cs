namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("OrdenesPago")]
    public class OrdenesPago : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
        [Required]
        public Enums.TipoEntidad TipoEntidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        public int? Id_Entidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para talonario es obligatorio.")]
        public int Id_TalonariosComprobantes { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo concepto es obligatorio.")]
        [StringLength(100)]
        public string Concepto { get; set; }
        [Required(ErrorMessage = "El campo letra es obligatorio.")]
        [StringLength(1)]
        public string Letra { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para punto de venta es obligatorio.")]
        [StringLength(4)]
        public string PuntoVenta { get; set; }
        [StringLength(8)]
        public string NroComprobante { get; set; }
        public DateTime? Fecha_Liquidacion { get; set; }
        public DateTime? Fecha_Anulacion { get; set; }
        public string Motivo_Anulacion { get; set; }
        public int? Id_Entidad_Mov { get; set; }
        public string Observaciones { get; set; }
        public decimal Importe { get; set; }
        public decimal? ImporteSinAplicar { get; set; }

        public virtual ICollection<OrdenesPagoDetalle> Detalle { get; set; }
        public virtual ICollection<OrdenesPagoImpuestos> Impuestos { get; set; }
        public virtual ICollection<OrdenesPagoComprobantes> Comprobantes { get; set; }
    }
}

