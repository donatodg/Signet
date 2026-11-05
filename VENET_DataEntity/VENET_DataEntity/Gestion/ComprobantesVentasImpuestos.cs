namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("ComprobantesVentasImpuestos")]
    public class ComprobantesVentasImpuestos: ClaseBase
    {
        public int Id_ComprobanteVenta { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para impuesto es obligatorio.")]
        public int Id_Impuesto { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para alícuota es obligatorio.")]
        public decimal Alicuota { get; set; }
        //[Range(0.01, 2147483647, ErrorMessage = "El valor para base imponible es obligatorio.")]
        public decimal BaseImponible { get; set; }
        //public bool AcumuladoMes { get; set; }
        public int? Id_Provincia { get; set; }
        public Enums.AplicaSobre AplicaSobre { get; set; }
        public decimal ImporteBaseImponible { get; set; }
        public decimal ImporteMinimo { get; set; }
        public decimal Importe { get; set; }

        [ForeignKey("Id_ComprobanteVenta")]
        public virtual ComprobantesVentas ComprobanteVenta { get; set; }
        [NotMapped]
        public string Impuesto { get; set; }
        [NotMapped]
        public string Provincia { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
       
    }
}
