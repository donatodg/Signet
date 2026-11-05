namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PersonalJerarquias")]
    public class PersonalJerarquias : ClaseBase
    {
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
