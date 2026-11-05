namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PuntosVenta")]
    public class PuntosVentas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Required(ErrorMessage = "El campo punto de venta es obligatorio.")]
        [StringLength(4)]
        public string PuntoVenta { get; set; }
    }
}
