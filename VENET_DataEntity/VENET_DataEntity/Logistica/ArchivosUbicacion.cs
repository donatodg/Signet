namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ArchivosUbicacion")]
    public class ArchivosUbicacion : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
