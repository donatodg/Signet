namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Diagramas")]
    public class Diagramas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de servicio es obligatorio.")]
        public int Id_TipoServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de día es obligatorio.")]
        public int Id_TipoDia { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia desde es obligatoria.")]
        public DateTime VigenciaDesde { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia hasta es obligatoria.")]
        public DateTime VigenciaHasta { get; set; }
    }
}
