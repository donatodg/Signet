namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ramales")]
    public class Ramales : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para linea es obligatorio.")]
        public int Id_Linea { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
     
    }
}
