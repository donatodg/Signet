namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Familias")]
    public class Familias : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para clase es obligatorio.")]
        public int Id_Clase { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [StringLength(20)]
        public string DatoAdicional1 { get; set; }
        [StringLength(20)]
        public string DatoAdicional2 { get; set; }
        [StringLength(20)]
        public string DatoAdicional3 { get; set; }
        [StringLength(20)]
        public string DatoAdicional4 { get; set; }
        [StringLength(20)]
        public string DatoAdicional5 { get; set; }
        [StringLength(20)]
        public string DatoAdicional6 { get; set; }
        [StringLength(20)]
        public string DatoAdicional7 { get; set; }
        [StringLength(20)]
        public string DatoAdicional8 { get; set; }
        [StringLength(20)]
        public string DatoAdicional9 { get; set; }
        [StringLength(20)]
        public string DatoAdicional10 { get; set; }
    }
}
