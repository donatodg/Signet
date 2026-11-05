namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeguridadUsuarioCentrosCostoDefault")]
    public class SeguridadUsuarioCentrosCostoDefault
    {
        [Key]
        [Column(Order = 1)]
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario es obligatorio.")]
        public int Id_Usuario { get; set; }
        [Key]
        [Column(Order = 2)]
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
    }
}
