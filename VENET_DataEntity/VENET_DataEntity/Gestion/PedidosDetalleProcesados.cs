namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PedidosDetalleProcesados")]
    public class PedidosDetalleProcesados : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para comprobante original es obligatorio.")]
        public int Id_PedidoOriginal { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para comprobante procesado es obligatorio.")]
        public int Id_ComprobanteVentaProcesado { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para detalle comprobante es obligatorio.")]
        public int Id_PedidoDetalle { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para cantidad es obligatorio.")]
        public decimal Cantidad { get; set; }
    }
}
