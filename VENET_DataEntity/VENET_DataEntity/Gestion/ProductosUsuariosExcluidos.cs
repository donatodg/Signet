namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductosUsuariosExcluidos")]
    public class ProductosUsuariosExcluidos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario Iva es obligatorio.")]
        public int Id_Usuario { get; set; }
        [Required(ErrorMessage = "El campo código de producto es obligatorio.")]
        [StringLength(50)]
        public string CodigoProducto { get; set; }
         
    }
}
