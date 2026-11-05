namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServiciosVueltas")]
    public class CodigosServiciosVueltas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para código de servicio es obligatorio.")]
        public int Id_CodigoServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para número de vuelta es obligatorio.")]
        public int NroVuelta { get; set; }
        public decimal KmsProductivos { get; set; }
        public decimal KmsImproductivos { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de citación es obligatoria.")]
        public DateTime HoraCitacion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de finalización es obligatoria.")]
        public DateTime HoraFinalizacion { get; set; }
        [Required(ErrorMessage = "El campo sentido es obligatorio.")]
        [StringLength(1)]
        public string Sentido { get; set; }
        [StringLength(50)]
        public string Comentario { get; set; }
        [StringLength(50)]
        public string CodigoExterno { get; set; }
        public int? IdTerminalSube { get; set; }
        public int? IdTerminalBaja { get; set; }
        public bool? ExtensionDiaAnterior { get; set; }
        public virtual ICollection<CodigosServiciosVueltasDetalle> Detalle { get; set; }

        //[NotMapped]
        //public String Origen { get; set; }
        //[NotMapped]
        //public String Destino { get; set; }
        //[NotMapped]
        //public DateTime Salida { get; set; }
        //[NotMapped]
        //public DateTime Llegada { get; set; }
    }
}
