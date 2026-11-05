namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanillasViajesDetalle")]
    public class PlanillasViajesDetalle : ClaseBase
    {
        public int Id_PlanillaViaje { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para número de vuelta es obligatorio.")]
        public int NroVuelta { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para sección origen es obligatorio.")]
        public int Id_SeccionOrigen { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de salida es obligatoria.")]
        public DateTime HoraSalida { get; set; }
        public int? LegajoControl { get; set; }
        public int? NroPlanilla { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para sección destino es obligatorio.")]
        public int Id_SeccionDestino { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora de llegada es obligatoria.")]
        public DateTime HoraLlegada { get; set; }
        public decimal? Kms { get; set; }

        [ForeignKey("Id_PlanillaViaje")]
        public virtual PlanillasViajes Planilla { get; set; }
        [NotMapped]
        public string SeccionOrigen { get; set; }
        [NotMapped]
        public string SeccionDestino { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
