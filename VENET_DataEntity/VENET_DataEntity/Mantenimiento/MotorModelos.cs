namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MotorModelos")]
    public class MotorModelos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para marca de motor es obligatorio.")]
        public int Id_MotorMarca { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}