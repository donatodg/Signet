namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ViajesEspecialesComentarios")]
    public class ViajesEspecialesComentarios
    {
        [Key]
        public int Id_UnidadNegocio { get; set; }
        [StringLength(8000)]
        public string Observaciones { get; set; }
    }
}
