namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CentrosCostos")]
    public class CentrosCostos : ClaseBase
    {
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
  
    }
}
