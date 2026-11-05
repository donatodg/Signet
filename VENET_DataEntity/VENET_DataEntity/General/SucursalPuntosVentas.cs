namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SucursalPuntosVentas")]
    public class SucursalPuntosVentas
    {
        [Key]
        [Column(Order = 1)]
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Key]
        [Column(Order = 2)]
        [Range(1, 2147483647, ErrorMessage = "El valor para punto de venta es obligatorio.")]
        public int Id_PuntoVenta { get; set; }
    }
} 
   
