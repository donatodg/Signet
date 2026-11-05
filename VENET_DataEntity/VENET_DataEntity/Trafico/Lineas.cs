namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Lineas")]
    public class Lineas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de negocio es obligatorio.")]
        public int Id_UnidadNegocio { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo descripcion corta es obligatorio.")]
        [StringLength(5)]
        public string DescripcionCorta { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string TipoServicio { get; set; }
        public bool? MediaLargaDistancia { get; set; }
    }
}
