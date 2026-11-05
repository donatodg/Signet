namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoViaticosHistorial")]
    public class TipoViaticosHistorial : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de viático es obligatorio.")]
        public Int32 Id_TipoViatico { get; set; }
        [DecimalPrecision(18, 2)]
        public Decimal Importe { get; set; }
    }

   
}
