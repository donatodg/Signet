namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Common;

    [Table("Planificacion_Fechas_Diagrama")]
    public class PlanificacionFechasDiagrama : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El Valor para Planificación es obligatorio.")]
        public Int32 Id_Planificacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El Valor para Diagrama es obligatorio.")]
        public Int32 Id_Diagrama { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La Fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
  
    }
}
