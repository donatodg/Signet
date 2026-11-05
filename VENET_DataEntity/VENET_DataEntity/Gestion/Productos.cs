namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Productos")]
    public class Productos : ClaseBase
    {
        [Required(ErrorMessage = "El campo código es obligatorio.")]
        [StringLength(100)]
        public string Codigo { get; set; }
        //[Required(ErrorMessage = "El campo código de fábrica es obligatorio.")]
        [StringLength(500)]
        public string CodigoFabrica { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(500)]
        public string Descripcion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para alicuota Iva es obligatorio.")]
        public int Id_IvaAlicuota { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para catogoría es obligatorio.")]
        public int Id_Categoria { get; set; }
        public int? Id_Categoria2 { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de compra es obligatorio.")]
        public int Id_UnidadCompra { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de venta es obligatorio.")]
        public int Id_UnidadVenta { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para equivalencia es obligatorio.")]
        public float Equivalencia { get; set; }
        public int? Id_UnidadStock { get; set; }
        //[Required(ErrorMessage = "El campo código de barra es obligatorio.")]
        [StringLength(100)]
        public string CodigoBarras { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para la especie es obligatorio.")]
        public int Id_Especie { get; set; }
        public decimal Importe { get; set; }
        public int? Id_EspecieOriginal { get; set; }
        public decimal? ImporteOriginal { get; set; }
        public int? Id_EspecieCosto { get; set; }
        public decimal ImporteCosto { get; set; }
        public DateTime? FechaActualizacionCosto { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para stock mínimo es obligatorio.")]
        public int StockMinimo { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para stock máximo es obligatorio.")]
        public int StockMaximo { get; set; }
        //[Required(ErrorMessage = "El campo observaciones es obligatorio.")]
        [StringLength(8000)]
        public string Observaciones { get; set; }


        //public virtual ICollection<ProductosComposicion> Detalle { get; set; }
    }
}
