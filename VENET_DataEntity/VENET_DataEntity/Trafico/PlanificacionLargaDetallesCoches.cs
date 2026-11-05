namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionLargaDetallesCoches")]
    public class PlanificacionLargaDetallesCoches : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public int Id_Planificacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para coche es obligatorio.")]
        public int Id_Coche { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        public int Id_TipoServicio { get; set; }
        public int Id_CodigoServicio { get; set; }
        public int Id_NovedadCoche { get; set; }
    }
}
