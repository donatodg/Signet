namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PadronIIBB")]
    public class PadronIIBB : ClaseBase
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(50)]
        public string Archivo { get; set; }
    }
}
