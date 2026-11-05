namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_ManoDeObraHistorial")]
    public class Produccion_ManoDeObraHistorial : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para mano de obra es obligatorio.")]
        public int Id_ManoObra { get; set; }
        public decimal PrecioHora { get; set; }
    }
}
