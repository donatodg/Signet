namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_Lineas")]
    public class Produccion_Lineas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(150)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo descripción corta es obligatorio.")]
        [StringLength(10)]
        public string DescripcionCorta { get; set; }
        [Required(ErrorMessage = "El campo código es obligatorio.")]
        [StringLength(15)]
        public string Codigo { get; set; }
        [StringLength(15)]
        public string ImprimirConCodigo { get; set; }
        [StringLength(500)]
        public string ObservacionesImpresion { get; set; }
        public bool ImprimirVertical { get; set; }
    }
}
