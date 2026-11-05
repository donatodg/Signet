namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionLargaDetalles")]
    public class PlanificacionLargaDetalles : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public int Id_Planificacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        public int? Id_TipoServicio { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [StringLength(15)]
        public string Novedad { get; set; }
        public long? Id_CodigoServicioTodos { get; set; }
        public int? Id_Novedad { get; set; }

    }
}