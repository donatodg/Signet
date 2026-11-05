namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeguridadGrupos")]
    public class SeguridadGrupos : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripcion es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public bool EsAdministrador { get; set; }
    }
}
