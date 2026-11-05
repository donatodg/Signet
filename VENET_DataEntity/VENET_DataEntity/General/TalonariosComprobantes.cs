namespace VENET_DataEntity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TalonariosComprobantes")]
    public class TalonariosComprobantes : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para comprobante es obligatorio.")]
        public int Id_Comprobante { get; set; }
        [Required(ErrorMessage = "El campo letra es obligatorio.")]
        [StringLength(1)]
        public string Letra { get; set; }
        [StringLength(3)]
        public string NroCodigo { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para punto de venta es obligatorio.")]
        public int Id_PuntoVenta { get; set; }
        [StringLength(100)]
        public string Impresora { get; set; }
        public int? Copias { get; set; }
        public string Reporte { get; set; }
        public bool Electronico { get; set; }
        public int? Id_AFIP_Comprobante { get; set; }
        public int? Id_Deposito { get; set; }

        public virtual ICollection<TalonariosComprobantesDetalle> Detalle { get; set; }
    }
}

