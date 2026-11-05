namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PuntosdePaso")]
    public class PuntosdePaso : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para sección es obligatorio.")]
        public int Id_Seccion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para número es obligatorio.")]
        public int Numero { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public bool Parada { get; set; }
        public int? VelocidadMaxima { get; set; }
    }
}
