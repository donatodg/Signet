namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionComentariosDiario")]
    public class PlanificacionComentariosDiario : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public int Id_Planificacion { get; set; }
        [Range(1, 31, ErrorMessage = "La fecha es obligatoria.")]
        public int Fecha { get; set; }
        [Range(1, 31, ErrorMessage = "El item es obligatoria.")]
        public int Item { get; set; }
        [StringLength(500)]
        public string Comentario { get; set; }
    }
}
