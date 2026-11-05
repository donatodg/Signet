namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rutas")]
    public class Rutas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de negocio es obligatorio.")]
        public int Id_UnidadNegocio { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        public int? Id_TipoServicio { get; set; }
        [Required(ErrorMessage = "El campo puntos es obligatorio.")]
        //[StringLength(8000)]
        public string Puntos { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(20)]
        public string Descripcion { get; set; }
        public double Metros { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para ancho de línea es obligatorio.")]
        public int Ancho { get; set; }
        public bool Activa { get; set; }
    }

}