namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RutasWeb")]
    public class RutasWeb /*: ClaseBase*/
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para recorrido es obligatorio.")]
        [Key]
        [Column(Order = 2)]
        public int IdRecorrido { get; set; }
        [Required(ErrorMessage = "El campo linea es obligatorio.")]
        [StringLength(10)]
        public string Linea { get; set; }
        [Required(ErrorMessage = "El campo ramal es obligatorio.")]
        [StringLength(10)]
        public string idRamal { get; set; }
        [Required(ErrorMessage = "El campo latitud es obligatorio.")]
        [StringLength(40)]
        public string Latitud { get; set; }
        [Required(ErrorMessage = "El campo longitud es obligatorio.")]
        [StringLength(40)]
        public string Longitud { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para orden es obligatorio.")]
        public int? Orden { get; set; }
        [Required(ErrorMessage = "El campo sentido es obligatorio.")]
        [StringLength(50)]
        public string Sentido { get; set; }
    }
}
