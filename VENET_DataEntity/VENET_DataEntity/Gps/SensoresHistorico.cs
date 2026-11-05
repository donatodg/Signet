namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SensoresHistorico")]
    public class SensoresHistorico
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo equipo es obligatorio.")]
        [StringLength(10)]
        public string Equipo { get; set; }
        public string Estado { get; set; }
        [Required(ErrorMessage = "El campo campo es obligatorio.")]
        [StringLength(50)]
        public string Campo { get; set; }
        public DateTime? Fecha { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de alta es obligatoria.")]
        public DateTime FechaAdd { get; set; }
    }
}
