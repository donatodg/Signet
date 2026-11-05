namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vendedores")]
    public class Vendedores : ClaseBase
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(13)]
        public string Cuit { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de iva es obligatorio.")]
        public int Id_TipoIVA { get; set; }
        [StringLength(50)]
        public string DomicilioCalle { get; set; }
        [StringLength(10)]
        public string DomicilioNro { get; set; }
        [StringLength(5)]
        public string DomicilioPiso { get; set; }
        [StringLength(5)]
        public string DomicilioDpto { get; set; }
        public int? Id_Localidad { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        [StringLength(50)]
        public string Celular { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(1000)]
        public string Observaciones { get; set; }
        public decimal? Comision { get; set; }
    }
}
