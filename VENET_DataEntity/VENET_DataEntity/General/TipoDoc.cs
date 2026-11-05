namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoDoc")]
    public class TipoDoc
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
