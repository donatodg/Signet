namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ViajeEspecialesVales")]
    public class ViajeEspecialesVales : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public Int32 Id_Personal { get; set; }
        [DecimalPrecision(18, 2)]
        public Decimal Importe { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public String Descripcion { get; set; }
        [StringLength(8000)]
        public String Observaciones { get; set; }
        public Nullable<DateTime> FechaAnulacion { get; set; }
        [StringLength(300)]
        public String MotivoAnulacion { get; set; }
        public Nullable<DateTime> FechaRendicion { get; set; }
        [DecimalPrecision(18, 2)]
        public Nullable<Decimal> ImporteComprobantes { get; set; }
        [DecimalPrecision(18, 2)]
        public Nullable<Decimal> ImporteDevuelto { get; set; }
        [StringLength(8000)]
        public String ObservacionesRendicion { get; set; }
    }
}
