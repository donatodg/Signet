namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cajas")]
    public class Cajas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
