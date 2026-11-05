namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServicios")]
    public class CodigosServicios : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de servicio es obligatorio.")]
        public int Id_TipoServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de código de servicio es obligatorio.")]
        public int Id_TipoCodigoServicio { get; set; }
        [Required(ErrorMessage = "El campo código es obligatorio.")]
        [StringLength(7)]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [StringLength(50)]
        public string Descripcion2 { get; set; }
        [StringLength(50)]
        public string Comentario { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia desde es obligatoria.")]
        public DateTime VigenciaDesde { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia hasta es obligatoria.")]
        public DateTime VigenciaHasta { get; set; }
        public bool HsPorVuelta { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de citación es obligatoria.")]
        public DateTime HoraCitacion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de finalización es obligatoria.")]
        public DateTime HoraFinalizacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cantidad de choferes es obligatorio.")]
        public int CantidadChoferes { get; set; }
        public bool Auxiliar { get; set; }
        public bool Auxiliar2 { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para jurisdicción es obligatorio.")]
        public int Id_Jurisdiccion { get; set; }
        public int? Id_Cabecera { get; set; }
        public int? Id_GrupoLinea { get; set; }
        public int? Id_Zona { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public bool Feriado { get; set; }
        public DateTime HsTomeDeje { get; set; }
        public DateTime HsSimple { get; set; }
        public DateTime Hs50 { get; set; }
        public DateTime Hs100 { get; set; }
        public DateTime HsPlus { get; set; }
        public DateTime HsTomeDeje1 { get; set; }
        public DateTime HsSimple1 { get; set; }
        public DateTime Hs501 { get; set; }
        public DateTime Hs1001 { get; set; }
        public DateTime HsPlus1 { get; set; }
        public decimal? ImporteVueltaChoferAntiguo { get; set; }
        public decimal? ImporteVueltaChoferIntermedio { get; set; }
        public decimal? ImporteVueltaChoferNuevo { get; set; }
        public decimal? ImporteVueltaAuxiliarAntiguo { get; set; }
        public decimal? ImporteVueltaAuxiliarIntermedio { get; set; }
        public decimal? ImporteVueltaAuxiliarNuevo { get; set; }
    }
}
