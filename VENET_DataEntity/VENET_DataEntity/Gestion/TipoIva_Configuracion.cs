namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoIva_Configuracion")]
    public class TipoIva_Configuracion : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo iva de origen es obligatorio.")]
        public int Id_TipoIvaOrigen { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo iva de destino es obligatorio.")]
        public int Id_TipoIvaDestino { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de comprobante es obligatorio.")]
        public int Id_TipoComprobante { get; set; }
        [Required(ErrorMessage = "El campo letra es obligatorio.")]
        [StringLength(1)]
        public string Letra { get; set; }
    }
}
