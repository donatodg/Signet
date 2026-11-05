namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionServiciosCoches")]
    public class PlanificacionServiciosCoches
    {
        [Key]
        public Int32 Id { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public Int32 Id_Planificacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de servicio es obligatorio.")]
        public Int32 Id_Diagrama { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para número de servicio es obligatorio.")]
        public Int32 NroServicio { get; set; }
        public Nullable<Int32> Id_Coche { get; set; }
    }
}
