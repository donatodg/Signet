namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoNovedadesCoches")]
    public class TipoNovedadesCoches : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(4)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo descripción larga es obligatorio.")]
        [StringLength(100)]
        public string DescripcionLarga { get; set; }
    }
}
