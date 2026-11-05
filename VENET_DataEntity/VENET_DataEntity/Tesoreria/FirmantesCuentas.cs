namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FirmantesCuentas")]
    public class FirmantesCuentas
    {
        [Key]
        [Required(ErrorMessage = "El campo codigo de barra es obligatorio.")]
        [StringLength(29)]
        public string CodigoBarra { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para firmante es obligatorio.")]
        public int Id_Firmante { get; set; }
    }
}
