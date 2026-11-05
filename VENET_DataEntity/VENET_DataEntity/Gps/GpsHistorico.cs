namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GpsHistorico")]
    public class GpsHistorico
    {
        [Key]
        [Required(ErrorMessage = "El campo id es obligatorio.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(10)]
        public string Equipo { get; set; }
        [Required(ErrorMessage = "El campo Campo es obligatorio.")]
        [StringLength(200)]
        public string Campo { get; set; }
        [Required(ErrorMessage = "El campo latitud es obligatorio.")]
        [StringLength(20)]
        public string Latitud { get; set; }
        [Required(ErrorMessage = "El campo longitud es obligatorio.")]
        [StringLength(20)]
        public string Longitud { get; set; }
        public decimal? Angulo { get; set; }
        public decimal? Velocidad { get; set; }
        public decimal? Metros { get; set; }
        public DateTime FechaGps { get; set; }
        public DateTime FechaAdd { get; set; }
    }
}
