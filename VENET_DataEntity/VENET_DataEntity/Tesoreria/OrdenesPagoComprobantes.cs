namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrdenesPagoComprobantes")]
    public class OrdenesPagoComprobantes : ClaseBase
    {
        public int Id_OrdenPago { get; set; }
        public int Id_ComprobantesCompras { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para importe adeudado es obligatorio.")]
        public decimal ImporteAdeudado { get; set; }
        public decimal ImportePago { get; set; }


        [ForeignKey("Id_OrdenPago")]
        public virtual OrdenesPago OrdenPago { get; set; }
        [NotMapped]
        public string Comprobante { get; set; }
        [NotMapped]
        public decimal Importe { get; set; }
        [NotMapped]
        public DateTime Fecha { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
