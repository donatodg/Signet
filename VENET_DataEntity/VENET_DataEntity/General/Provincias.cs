namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Provincia")]
    public class Provincias
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo Abreviatura es obligatorio.")]
        [StringLength(3)]
        public string Abreviatura { get; set; }
    }
}
