namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Secciones")]
    public class Secciones : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de servicio es obligatoria.")]
        public int Id_TipoServicio { get; set; }
        [Required(ErrorMessage = "El campo ida/vuelta es obligatorio.")]
        [StringLength(1)]
        public string IdaVuelta { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para número es obligatorio.")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo descripcion corta es obligatorio.")]
        [StringLength(20)]
        public string DescripcionCorta { get; set; }
        //[DataType("decimal(18,13)")]
        public double? Latitud { get; set; }
        //[DataType("decimal(18,13)")]
        public double? Longitud { get; set; }
        public int? VelocidadMaxima {get;set;}
        public decimal? Kms { get; set; }
    }
}
