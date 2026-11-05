namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionDetalle")]
    public class PlanificacionDetalle : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public Int32 Id_Planificacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public Int32 Id_Personal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para coche es obligatorio.")]
        public Int32 Id_Coche { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para linea es obligatorio.")]
        public Int32 Id_Linea { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para turno es obligatorio.")]
        //public Int32 Turno { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para titularidad es obligatorio.")]
        //public Int32 Id_Titularidad { get; set; }
        
        
    }
}
