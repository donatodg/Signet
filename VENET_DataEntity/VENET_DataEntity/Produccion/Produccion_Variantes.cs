namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_Variantes")]
    public class Produccion_Variantes : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para línea es obligatorio.")]
        public int Id_Linea { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo descripción corta es obligatorio.")]
        [StringLength(10)]
        public string DescripcionCorta { get; set; }
        [Required(ErrorMessage = "El campo código es obligatorio.")]
        [StringLength(10)]
        public string Codigo { get; set; }
        public decimal Utilidad { get; set; }
    }
}
