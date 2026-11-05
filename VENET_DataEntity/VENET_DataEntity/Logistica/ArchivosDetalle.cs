namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ArchivosDetalle")]
    public class ArchivosDetalle : ClaseBase
    {
        public int Id_Archivo { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. de control es obligatorio.")]
        public int NroControl { get; set; }
       
        [Required(ErrorMessage = "El campo tipo de documento es obligatorio.")]
        [StringLength(50)]
        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(200)]
        public string Descripcion { get; set; }
        public int? Id_FacturaTango { get; set; }


        [ForeignKey("Id_Archivo")]
        public virtual Archivos Archivo { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
