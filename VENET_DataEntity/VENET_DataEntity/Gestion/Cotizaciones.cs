namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Cotizaciones")]
    public class Cotizaciones : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para talonario es obligatorio.")]
        public int Id_TalonariosComprobantes { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de entidad es obligatorio.")]
        public Enums.TipoEntidad Id_TipoEntidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        public int? Id_Entidad { get; set; }
        [Required(ErrorMessage = "El campo letra es obligatorio.")]
        [StringLength(2)]
        public string Letra { get; set; }
        [Required(ErrorMessage = "El campo punto de venta es obligatorio.")]
        [StringLength(4)]
        public string PuntoVenta { get; set; }
        [Required(ErrorMessage = "El campo número de comprobante es obligatorio.")]
        [StringLength(8)]
        public string NroComprobante { get; set; }
      
        [Range(1, 2147483647, ErrorMessage = "El valor para forma de pago es obligatorio.")]
        public int Id_FormaPago { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo observaciones es obligatorio.")]
        [StringLength(1000)]
        public string Observaciones { get; set; }
        public DateTime? Fecha_Liquidacion { get; set; }
        public DateTime? Fecha_Anulacion { get; set; }
        [StringLength(300)]
        public string Motivo_Anulacion { get; set; }
        public int? Id_ComprobanteGenerado { get; set; }

        public virtual ICollection<CotizacionesDetalle> Detalle { get; set; }


        [NotMapped]
        public string Comprobante { get { return Letra + "-" + PuntoVenta + "-" + NroComprobante; } }
        [NotMapped]
        public byte[] Imagen { get; set; }
    }
}
