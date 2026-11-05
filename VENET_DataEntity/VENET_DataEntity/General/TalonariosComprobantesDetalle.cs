namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TalonariosComprobantesDetalle")]
    public class TalonariosComprobantesDetalle : ClaseBase
    {
        public int Id_TalonarioComprobante { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. desde es obligatorio.")]
        public int NroDesde { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. hasta es obligatorio.")]
        public int NroHasta { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para nro. hasta es obligatorio.")]
        public int NroActual { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateTime FechaVencimiento { get; set; }

        [ForeignKey("Id_TalonarioComprobante")]
        public virtual TalonariosComprobantes TalonarioComprobante { get; set; }
    }
}