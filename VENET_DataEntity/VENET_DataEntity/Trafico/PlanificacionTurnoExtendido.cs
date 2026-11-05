namespace VENET_DataEntity 
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionTurnoExtendido")]
    public class PlanificacionTurnoExtendido : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public int Id_Planificacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para Servicio es obligatorio.")]
        public int Id_Servicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para coche es obligatorio.")]
        public int Id_Coche { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para diagrama es obligatorio.")]
        public int Id_Diagrama { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. de servicio es obligatorio.")]
        public int NroServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para turno es obligatorio.")]
        public int Turno { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. de vuelta es obligatorio.")]
        public int NroVuelta { get; set; }

    }
}
