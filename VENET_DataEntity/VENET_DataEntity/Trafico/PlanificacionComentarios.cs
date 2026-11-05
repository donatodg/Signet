namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionComentarios")]
    public class PlanificacionComentarios : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public int Id_PlanificacionDetalle { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de comentario es obligatorio.")]
        public int Id_TipoComentario { get; set; }
        public string Comentario { get; set; }
    }
}
