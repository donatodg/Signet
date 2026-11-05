namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductosListaPrecioActual")]
    public class ProductosListaPrecioActual : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para lista de precios es obligatorio.")]
        public int Id_Produccion_ListaPrecios { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
