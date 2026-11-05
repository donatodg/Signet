namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServiciosViaticos")]
    public class CodigosServiciosViaticos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para codigo de servicio es obligatorio.")]
        public int Id_CodigoServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de viatico es obligatorio.")]
        public int Id_TipoViatico { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cantidad es obligatorio.")]
        public int Cantidad { get; set; }
    }
}
