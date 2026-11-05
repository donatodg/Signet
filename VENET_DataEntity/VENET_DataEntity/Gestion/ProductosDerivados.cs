namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductosDerivados")]
    public class ProductosDerivados : ClaseBase
    {
        [Required(ErrorMessage = "El campo código es obligatorio.")]
        [StringLength(100)]
        public string Codigo { get; set; }
        //[Required(ErrorMessage = "El campo código de fábrica es obligatorio.")]
        [StringLength(100)]
        public string CodigoFabrica { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(500)]
        public string Descripcion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para producto es obligatorio.")]
        public int Id_Producto { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para catogoría es obligatorio.")]
        public int Id_Categoria { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de venta es obligatorio.")]
        public int Id_UnidadVenta { get; set; }
        [Range(0.00001, 2147483647, ErrorMessage = "El valor para cantidad es obligatorio.")]
        public float Cantidad{ get; set; }
        //[Required(ErrorMessage = "El campo código de barra es obligatorio.")]
        [StringLength(100)]
        public string CodigoBarras { get; set; }
    }
}
