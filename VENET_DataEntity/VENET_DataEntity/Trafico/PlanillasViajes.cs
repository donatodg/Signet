namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanillasViajes")]
    public class PlanillasViajes : ClaseBase
    {
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de servicio es obligatorio.")]
        public int Id_TipoServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para sección tome es obligatorio.")]
        public int Id_SeccionTome { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha toma servicio es obligatoria.")]
        public DateTime TomaServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para coche es obligatorio.")]
        public int Id_Coche { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para sección deje es obligatorio.")]
        public int Id_SeccionDeje { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha deja servicio es obligatoria.")]
        public DateTime DejaServicio { get; set; }
        [StringLength(500)]
        public string Observaciones { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Horas { get;  set; }

        public virtual ICollection<PlanillasViajesDetalle> Detalle { get; set; }

     

    }
}
