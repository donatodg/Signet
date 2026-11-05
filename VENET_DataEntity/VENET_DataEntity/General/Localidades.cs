namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Localidad")]
    public class Localidades : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para provincia es obligatorio.")]
        public int Id_Provincia { get; set; }
        [Required(ErrorMessage = "El campo localidad es obligatorio.")]
        [StringLength(100)]
        public string Localidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para código postal es obligatorio.")]
        public int CodPostal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para clearing es obligatorio.")]
        public int Clearing { get; set; }
    }
}
