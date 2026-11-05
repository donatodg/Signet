namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionLargaTurnoExtendido")]
    public class PlanificacionLargaTurnoExtendido : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public int Id_Planificacion { get; set; }
        public long Id_CodigoServicioTodos { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para coche es obligatorio.")]
        public int Id_Coche { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para código de servicio es obligatorio.")]
        public int Id_CodigoServicio { get; set; }
        [StringLength(50)]
        public string Codigo { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. de vuelta es obligatorio.")]
        public int NroVuelta { get; set; }
    }
}
