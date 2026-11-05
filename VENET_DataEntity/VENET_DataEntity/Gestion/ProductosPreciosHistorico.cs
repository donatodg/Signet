namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductosPreciosHistorico")]
    public class ProductosPreciosHistorico : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para producto es obligatorio.")]
        public int Id_Producto { get; set; }
        public decimal Importe { get; set; }
        public decimal ImporteCosto { get; set; }
    }
}
