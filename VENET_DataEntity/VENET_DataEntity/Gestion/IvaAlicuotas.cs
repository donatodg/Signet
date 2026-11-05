namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IvaAlicuotas")]
    public class IvaAlicuotas : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para alicuota es obligatorio.")]
        public decimal Alicuota { get; set; }
    }
}
