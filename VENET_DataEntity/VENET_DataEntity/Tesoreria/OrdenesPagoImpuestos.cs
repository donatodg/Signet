namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("OrdenesPagoImpuestos")]
    public class OrdenesPagoImpuestos : ClaseBase
    {
        public int Id_OrdenPago { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para impuesto es obligatorio.")]
        public int Id_Impuesto { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para alícuota es obligatorio.")]
        public decimal Alicuota { get; set; }
        //[Range(0.01, 2147483647, ErrorMessage = "El valor para base imponible es obligatorio.")]
        public decimal BaseImponible { get; set; }
        //public bool AcumuladoMes { get; set; }
        public Enums.AplicaSobre AplicaSobre { get; set; }
        public decimal ImporteBaseImponible { get; set; }
        public decimal ImporteMinimo { get; set; }
        public decimal Importe { get; set; }
        public int? Id_Provincia { get; set; }

        [ForeignKey("Id_OrdenPago")]
        public virtual OrdenesPago OrdenPago { get; set; }
        [NotMapped]
        public string Impuesto { get; set; }
        [NotMapped]
        public string Provincia { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
