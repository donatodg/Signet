namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ViajesEspecialesVales")]
    public class ViajesEspecialesVales : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal Importe { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [StringLength(8000)]
        public string Observaciones { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        [StringLength(300)]
        public string MotivoAnulacion { get; set; }
        public DateTime? FechaRendicion { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal? ImporteComprobantes { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal? ImporteDevuelto { get; set; }
        [StringLength(8000)]
        public string ObservacionesRendicion { get; set; }
    }
}
