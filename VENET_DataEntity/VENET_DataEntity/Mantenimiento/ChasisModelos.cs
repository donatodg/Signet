namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChasisModelos")]
    public class ChasisModelos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para marca de chasis es obligatorio.")]
        public int Id_ChasisMarca { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}