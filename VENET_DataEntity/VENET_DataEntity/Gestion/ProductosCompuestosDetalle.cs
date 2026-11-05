namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductosCompuestosDetalle")] 
    public class ProductosCompuestosDetalle : ClaseBase
    {
        //[Range(1, 2147483647, ErrorMessage = "El valor para producto compuesto es obligatorio.")]
        public int Id_ProductoCompuesto { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para producto es obligatorio.")]
        public int? Id_Producto { get; set; }
        public decimal Cantidad { get; set; }
        [Required(ErrorMessage = "El campo producto es obligatorio.")]
        [StringLength(500)]
        public string Producto { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe unitario es obligatorio.")]
        public decimal ImporteUnitario { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para alicuota Iva es obligatorio.")]
        public int Id_AlicuotaIva { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para alicuota de Iva es obligatorio.")]
        public decimal AlicuotaIva { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe Iva es obligatorio.")]
        public decimal ImporteIVA { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe es obligatorio.")]
        public decimal Importe { get; set; }
        public decimal ImporteSinIva { get; set; }
        
        [ForeignKey("Id_ProductoCompuesto")]
        public virtual ProductosCompuestos ProductoCompuesto { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

    }
}
