namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChequesDescuentoDetalle")]
    public class ChequesDescuentoDetalle : ClaseBase
    {
        public int Id_ChequeDescuento { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cheque es obligatorio.")]
        public int Id_Documento { get; set; }

        [ForeignKey("Id_ChequeDescuento")]
        public virtual ChequesDescuento ChequeDescuento { get; set; }

        [NotMapped]
        public string Banco { get; set; }
        [NotMapped]
        public string Sucursal { get; set; }
        [NotMapped]
        public string NroCheque { get; set; }
        [NotMapped]
        public string NroCuenta { get; set; }
        [NotMapped]
        public decimal Importe { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
