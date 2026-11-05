namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ImpuestosAlicuotas")]
    public class ImpuestosAlicuotas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de impuesto es obligatorio.")]
        public int Id_Impuesto { get; set; }
        public decimal Alicuota { get; set; }
        public decimal BaseImponible { get; set; }
        //public bool AcumuladoMes { get; set; }
        public decimal ImporteMinimo { get; set; }
        public int? Id_Provincia { get; set; }

        [NotMapped]
        public string Provincia { get; set; }

    }
}
