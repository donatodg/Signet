namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("SeguridadObjetos")]
    public class SeguridadObjetos
    {
        [Key]
        public int Id { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para modulo es obligatorio.")]
        public Enums.Modulos Modulo { get; set; }
        [Required(ErrorMessage = "El campo formulario es obligatorio.")]
        [StringLength(100)]
        public string Formulario { get; set; }
        [Required(ErrorMessage = "El campo permiso es obligatorio.")]
        [StringLength(100)]
        public string Permiso { get; set; }
    }
}
