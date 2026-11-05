namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BoletasDepositosDetalle")]
    public class BoletasDepositosDetalle : ClaseBase
    {
        public int Id_BoletaDeposito { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para documento es obligatorio.")]
        public int Id_Documento { get; set; }
        [DecimalPrecisionAttribute(18, 2)]
        [Range(0, 2147483647, ErrorMessage = "El valor para efectivo es obligatorio.")]
        public decimal Importe { get; set; }

        [ForeignKey("Id_BoletaDeposito")]
        public virtual BoletasDepositos Boleta { get; set; }

        [NotMapped]
        public string Banco { get; set; }
        [NotMapped]
        public string Sucursal { get; set; }
        [NotMapped]
        public string NroCheque { get; set; }
        [NotMapped]
        public string NroCuenta { get; set; }
        //[NotMapped]
        //public Decimal Importe { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
