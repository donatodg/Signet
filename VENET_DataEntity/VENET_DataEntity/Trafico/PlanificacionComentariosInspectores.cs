namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanificacionComentariosInspectores")]
    public class PlanificacionComentariosInspectores : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación es obligatorio.")]
        public int Id_PlanificacionDetalleInspectores { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de comentario es obligatorio.")]
        public int Id_TipoComentario { get; set; }
        public string Comentario { get; set; }
    }
}
