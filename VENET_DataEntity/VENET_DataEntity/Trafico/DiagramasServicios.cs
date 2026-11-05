namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Diagramas_Servicios")]
    public class DiagramasServicios : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para nro de servicio es obligatorio.")]
        public int NroServicio { get; set; }
        [Range(1, 3, ErrorMessage = "El valor para nro de turno es obligatorio y debe ser menor a 4.")]
        public int Turno { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para diagrama es obligatorio.")]
        public int Id_Diagrama { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de citación es obligatoria")]
        public DateTime HoraCitacion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de finalización es obligatoria")]
        public DateTime HoraFinalizacion { get; set; }
        public decimal Tome { get; set; }
        public decimal Deje { get; set; }
        public decimal? Kms { get; set; }
        [Required(ErrorMessage = "El campo código es obligatorio.")]
        [StringLength(10)]
        public string Codigo { get; set; }
        [StringLength(50)]
        public string Comentario { get; set; }
        public bool? Marcado { get; set; }
    }
}
