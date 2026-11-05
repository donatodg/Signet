namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ServiciosInspectores")]
    public class ServiciosInspectores : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de negocio es obligatorio.")]
        public int Id_UnidadNegocio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para punta de línea es obligatorio.")]
        public int Id_PuntaLinea { get; set; }
        [Required(ErrorMessage = "El campo código es obligatorio.")]
        [StringLength(7)]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de citación es obligatoria.")]
        public DateTime HoraCitacion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de finalización es obligatoria.")]
        public DateTime HoraFinalizacion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia desde es obligatoria.")]
        public DateTime VigenciaDesde { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia hasta es obligatoria.")]
        public DateTime VigenciaHasta { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public bool Feriado { get; set; }
    }
}
