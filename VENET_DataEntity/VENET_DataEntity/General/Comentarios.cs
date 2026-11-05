namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Comentarios")]
    public class Comentarios : ClaseBase
    {
        [Required(ErrorMessage = "El campo tabla es obligatorio.")]
        public string Tabla { get; set; }
        [Required(ErrorMessage = "El campo id tabla es obligatorio.")]
        public int Id_Tabla { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo color es obligatorio.")]
        [StringLength(50)]
        public string Color { get;  set; }
    }
}
