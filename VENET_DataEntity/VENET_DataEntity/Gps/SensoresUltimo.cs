namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SensoresUltimo")]
    public class SensoresUltimo
    {
        [Key]
        [Required(ErrorMessage = "El campo equipo es obligatorio.")]
        [StringLength(10)]
        public string Equipo { get; set; }
        [Required(ErrorMessage = "El registro Campo es obligatorio.")]
        [StringLength(200)]
        public string Campo { get; set; }
        [Required(ErrorMessage = "El campo ip es obligatorio.")]
        [StringLength(20)]
        public string IP { get; set; }
        [Required(ErrorMessage = "El campo puerto es obligatorio.")]
        [StringLength(20)]
        public string Puerto { get; set; }
        [Required(ErrorMessage = "El campo cambio actuadores es obligatorio.")]
        [StringLength(50)]
        public string CambioActuadores { get; set; }
        public DateTime? Fecha { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de alta es obligatoria.")]
        public DateTime FechaAdd { get; set; }
    }
}
