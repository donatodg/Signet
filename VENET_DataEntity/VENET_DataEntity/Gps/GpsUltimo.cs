namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GpsUltimo")]
    public class GpsUltimo
    {
        [Key]
        [Required(ErrorMessage = "El campo equipo es obligatorio.")]
        [StringLength(10)]
        public string Equipo { get; set; }
        [Required(ErrorMessage = "El campo Campo es obligatorio.")]
        [StringLength(200)]
        public string Campo { get; set; }
        [Required(ErrorMessage = "El campo IP es obligatorio.")]
        [StringLength(20)]
        public string IP { get; set; }
        [Required(ErrorMessage = "El campo puerto es obligatorio.")]
        [StringLength(10)]
        public string Puerto { get; set; }
        [Required(ErrorMessage = "El campo latitud es obligatorio.")]
        [StringLength(20)]
        public string Latitud { get; set; }
        [Required(ErrorMessage = "El campo longitud es obligatorio.")]
        [StringLength(20)]
        public string Longitud { get; set; }
        public decimal? Angulo { get; set; }
        public decimal? Velocidad { get; set; }
        public bool? GpsStatus { get; set; }
        public DateTime FechaGps { get; set; }
        public DateTime FechaAdd { get; set; }
    }
}
