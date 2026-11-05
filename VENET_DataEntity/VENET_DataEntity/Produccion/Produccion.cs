namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion")]
    public class Produccion : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para variante es obligatorio.")]
        public int Id_Variante { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para medida es obligatorio.")]
        public int Id_Medida { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para producto es obligatorio.")]
        public int Id_Producto { get; set; }
        public int? Id_ProductoDerivado { get; set; }
        //[Required(ErrorMessage = "El campo descripción es obligatorio.")]
        //[StringLength(500)]
        //public string Descripcion { get; set; }
        //[Required(ErrorMessage = "El campo código es obligatorio.")]
        //[StringLength(100)]
        //public string Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Altos { get; set; }
        [StringLength(1)]
        public string OperacionAltos { get; set; }
        public decimal AltosAjuste { get; set; }
        public decimal Anchos { get; set; }
        [StringLength(1)]
        public string OperacionAnchos { get; set; }
        public decimal AnchosAjuste { get; set; }
        [StringLength(1)]
        public string Operacion { get; set; }
        public decimal Incidencia { get; set; }
    }
}
