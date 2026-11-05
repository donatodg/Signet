namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Especies_Cotizaciones")]
    public class EspeciesCotizaciones : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }
        public decimal Cotizacion { get; set; }

    }
}
