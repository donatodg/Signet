namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_ListaPreciosDetalle")]
    public class Produccion_ListaPreciosDetalle : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para lista de precio es obligatorio.")]
        public int Id_ListaPrecios { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para variante es obligatorio.")]
        public int Id_Variante { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para medida es obligatorio.")]
        public int Id_Medida { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para costo de composición es obligatorio.")]
        public decimal CostoComposicion { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para costo de tarea es obligatorio.")]
        public decimal CostoTareas { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El campo utilidad es obligatorio.")]
        public decimal Utilidad { get; set; }
        [Range(-2147483647, 2147483647, ErrorMessage = "El valor para ajuste es obligatorio.")]
        public decimal Ajuste { get; set; }
        [Range(-2147483647, 2147483647, ErrorMessage = "El campo total es obligatorio.")]
        public decimal Total { get; set; }
    }
}
