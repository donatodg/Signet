namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Eventos")]
    public class Eventos
    {
        [Key]
        public int Id { get; set; }
        public string EquipoGps { get; set; }
        public string EquipoSensor { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entrada es obligatorio.")]
        public int Id_Entrada { get; set; }
        [Required(ErrorMessage = "El campo evento es obligatorio.")]
        [StringLength(200)]
        public string Evento { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
    }
}
