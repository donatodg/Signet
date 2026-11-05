namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Puntos")]
    public class Puntos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de negocio es obligatorio.")]
        public int Id_UnidadNegocio { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        public int? Id_TipoServicio { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para imagen es obligatorio.")]
        public int IndiceImagen { get; set; }

        [Required(ErrorMessage = "El campo latitud es obligatorio.")]
        [StringLength(20)]
        public string Latitud { get; set; }
        [Required(ErrorMessage = "El campo longitud es obligatorio.")]
        [StringLength(20)]
        public string Longitud { get; set; }
    }

}