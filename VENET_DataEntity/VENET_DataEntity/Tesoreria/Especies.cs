namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Especies")]
    public class Especies : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo sigla es obligatorio.")]
        [StringLength(3)]
        public string Sigla { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para cotizacion es obligatorio.")]
        public decimal Cotizacion { get; set; }
        [StringLength(3)]
        public string Id_EspecieAFIP { get; set; }

    }
}
