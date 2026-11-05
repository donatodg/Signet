namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChequesPropios")]
    public class ChequesPropios : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para cuenta es obligatorio.")]
        public int Id_ProvFinancierosCuenta { get; set; }
        [Range(1, 99999999, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Range(1, 99999999, ErrorMessage = "El valor para nro. de cheque es obligatorio.")]
        public int NroCheque { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de emisión es obligatoria.")]
        public DateTime FechaEmision { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de pago es obligatoria.")]
        public DateTime FechaPago { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para importe es obligatorio.")]
        public decimal Importe { get; set; }
        public int? Id_OrdenPago { get; set; }
        public bool ALaOrden { get; set; }
        public DateTime? FechaDepositado { get; set; }
        public DateTime? FechaRechazado { get; set; }
        [StringLength(50)]
        public string MotivoRechazo { get; set; }
        public decimal? ImporteRechazo { get; set; }
        [NotMapped]
        public string Banco { get; set; }

    }
}
