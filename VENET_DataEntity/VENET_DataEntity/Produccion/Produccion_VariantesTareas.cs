namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_VariantesTareas")]
    public class Produccion_VariantesTareas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para variante es obligatorio.")]
        public int Id_Variante { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para medida es obligatorio.")]
        public int Id_Medida { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tarea es obligatorio.")]
        public int Id_Tarea { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para mano de obra es obligatorio.")]
        public int Id_ManoObra { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El campo cantidad es obligatorio.")]
        public decimal Cantidad { get; set; }
        public decimal Unidades { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El campo horas es obligatorio.")]
        public DateTime Horas { get; set; }
    }
}
