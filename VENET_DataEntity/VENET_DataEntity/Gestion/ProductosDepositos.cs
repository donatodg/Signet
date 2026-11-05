namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductosDepositos")]
    public class ProductosDepositos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para producto es obligatorio.")]
        public int Id_Producto { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para depósito es obligatorio.")]
        public int Id_Deposito { get; set; }
        //[Range(–2147483648, 2147483647, ErrorMessage = "El valor para stock inicial es obligatorio.")]
        public decimal StockInicial { get; set; }
    }
}
