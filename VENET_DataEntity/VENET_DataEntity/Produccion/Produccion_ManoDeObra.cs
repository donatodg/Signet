namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_ManoDeObra")]
    public class Produccion_ManoDeObra : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo descripción corta es obligatorio.")]
        [StringLength(5)]
        public string DescripcionCorta { get; set; }
        public decimal PrecioHora { get; set; }
    }
}
