namespace VENET_DataEntity
{ 
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductosCompuestos")]
    public class ProductosCompuestos : ClaseBase
    {
        [StringLength(50)]
        public string Adicional { get; set; }
        public decimal ImporteAdicional { get; set; }
        [Required(ErrorMessage = "El campo producto final es obligatorio.")]
        [StringLength(300)]
        public string ProductoFinal { get; set; }
        public decimal ImporteTotal { get; set; }
        public decimal ImporteSinIvaTotal { get; set; }

        public virtual ICollection<ProductosCompuestosDetalle> Detalle { get; set; }
    }
}
