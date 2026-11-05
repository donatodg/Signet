namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoIva")]
    public class TipoIva : ClaseBase
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo abreviatura es obligatorio.")]
        [StringLength(5)]
        public string Abreviatura { get; set; }
    }
}
