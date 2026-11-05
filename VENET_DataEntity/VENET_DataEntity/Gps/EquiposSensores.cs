namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EquiposSensores")]
    public class EquiposSensores : ClaseBase
    {
        [Required(ErrorMessage = "El campo equipo es obligatorio.")]
        [StringLength(10)]
        public string Equipo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo observaciones es obligatorio.")]
        [StringLength(50)]
        public string Observaciones { get; set; }
    }
}
