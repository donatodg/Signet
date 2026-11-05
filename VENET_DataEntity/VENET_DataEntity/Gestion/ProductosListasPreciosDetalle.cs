namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Productos_ListasPreciosDetalle")]
    public class ProductosListasPreciosDetalle : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para lista de precios es obligatorio.")]
        public int Id_Productos_ListasPrecios { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para producto es obligatorio.")]
        public int Id_Producto { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para la especie es obligatorio.")]
        public int Id_Especie { get; set; }
        public decimal Importe { get; set; }
        public int? Id_EspecieOriginal { get; set; }
        public decimal? ImporteOriginal { get; set; }
 
    }
}
