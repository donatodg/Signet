namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Firmantes")]
    public class Firmantes : ClaseBase
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo cuit es obligatorio.")]
        [StringLength(13)]
        public string Cuit { get; set; }
    }
}
