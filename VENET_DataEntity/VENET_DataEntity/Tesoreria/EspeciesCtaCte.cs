namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EspeciesCtaCte")]
    public class EspeciesCtaCte : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para caja es obligatorio.")]
        public int Id_Caja { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }

        //[Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        //public Int32 Id_Sucursal { get; set; }

        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        //[Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        //public Int32 Id_Especie { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de comprobante es obligatorio.")]
        public int Id_TipoComprobante { get; set; }
        public int Id_Comprobante { get; set; }
        [Required(ErrorMessage = "El campo concepto es obligatorio.")]
        [StringLength(300)]
        public string Concepto { get; set; }
        public Boolean? Tarjeta { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
    }
}
