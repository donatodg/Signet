namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProvFinancieros")]
    public class ProvFinancieros : ClaseBase
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Domicilio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para código postal es obligatorio.")]
        public int Id_CodPostal { get; set; }
        [StringLength(13)]
        public string Cuit { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para iva es obligatorio.")]
        public int Id_TipoIva { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
    }
}
