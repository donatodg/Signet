namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServiciosEventuales")]
    public class CodigosServiciosEventuales : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de servicio es obligatorio.")]
        public int Id_TipoServicio { get; set; }
        [Required(ErrorMessage = "El campo código es obligatorio.")]
        [StringLength(5)]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de citación es obligatoria.")]
        public DateTime HoraCitacion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de finalización es obligatoria.")]
        public DateTime HoraFinalizacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cantidad de choferes es obligatorio.")]
        public int CantidadChoferes { get; set; }
        public bool Auxiliar { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para jurisdicción es obligatorio.")]
        public int Id_Jurisdiccion { get; set; }
    }
}