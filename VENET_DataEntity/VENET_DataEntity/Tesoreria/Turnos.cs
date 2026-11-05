namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Turnos")]
    public class Turnos 
    {
        [Key]
        public int Id { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario es obligatorio.")]
        public int Id_Usuario { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "El valor para fecha de inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool? Controlado { get; set; }
    }
}
