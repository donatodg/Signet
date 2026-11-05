namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionLargaServicios")]
    public class PlanificacionLargaServicios : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public int Id_Planificacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de servicio es obligatorio.")]
        public int Id_TipoServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para código de servicio es obligatorio.")]
        public int Id_CodigoServicio { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cantidad de servicio es obligatorio.")]
        public int CantidadServicios { get; set; }
        public bool Cancelado { get; set; }
        [StringLength(500)]
        public string Observaciones { get; set; }
    }
}
