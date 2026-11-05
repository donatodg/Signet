namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Alarmas")]
    public class Alarmas: ClaseBase
    {
        [Required(ErrorMessage = "El campo equipo gps es obligatorio.")]
        [StringLength(20)]
        public string EquipoGps { get; set; }
        [Required(ErrorMessage = "El campo tipo alarma es obligatorio.")]
        [StringLength(50)]
        public string TipoAlarma { get; set; }
        [Required(ErrorMessage = "El campo evento es obligatorio.")]
        [StringLength(200)]
        public string Evento { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para usario que atendió es obligatorio.")]
        public int? AtendioId_User { get; set; }
        public DateTime? AtendioFecha { get; set; }
        [StringLength(800)]
        public string AtendioDescripcion { get; set; }

    }
}
