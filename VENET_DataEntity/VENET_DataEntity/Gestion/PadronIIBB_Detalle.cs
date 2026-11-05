namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PadronIIBB_Detalle")]
    public class PadronIIBB_Detalle : ClaseBase
    {
        public int Id_PadronIIBB { get; set; }
        [Required(ErrorMessage = "El campo régimen es obligatorio.")]
        [StringLength(1)]
        public string Regimen { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de publicación es obligatoria.")]
        public DateTime FechaPublicacion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia desde es obligatoria.")]
        public DateTime VigenciaDesde { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia hasta es obligatoria.")]
        public DateTime VigenciaHasta { get; set; }
        [Required(ErrorMessage = "El campo Cuit es obligatorio.")]
        [StringLength(11)]
        public string Cuit { get; set; }
        [Required(ErrorMessage = "El campo tipo de contribuyente es obligatorio.")]
        [StringLength(1)]
        public string TipoContribuyente { get; set; }
        [Required(ErrorMessage = "El campo Alta/Baja es obligatorio.")]
        [StringLength(1)]
        public string AltaBaja { get; set; }
        [Required(ErrorMessage = "El campo cambio de alícuota es obligatorio.")]
        [StringLength(1)]
        public string CambioAlicuota { get; set; }
        public decimal Alicuota { get; set; }
        [StringLength(2)]
        public string NroGrupo { get; set; }
    }
}
