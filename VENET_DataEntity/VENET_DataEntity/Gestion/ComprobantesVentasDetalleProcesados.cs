namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ComprobantesVentasDetalleProcesados")]
    public class ComprobantesVentasDetalleProcesados : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para comprobante original es obligatorio.")]
        public int Id_ComprobanteVentaOriginal { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para comprobante procesado es obligatorio.")]
        public int Id_ComprobanteVentaProcesado { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para detalle comprobante es obligatorio.")]
        public int Id_ComprobanteVentaDetalle { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para cantidad es obligatorio.")]
        public decimal Cantidad { get; set; }
    }
}
