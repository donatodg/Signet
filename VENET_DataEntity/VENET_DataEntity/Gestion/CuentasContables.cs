namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CuentasContables")]
    public class CuentasContables : ClaseBase
    {
        [Required(ErrorMessage = "El campo título es obligatorio.")]
        [StringLength(2)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo capítulo es obligatorio.")]
        [StringLength(2)]
        public string Capitulo { get; set; }
        [Required(ErrorMessage = "El campo rubro es obligatorio.")]
        [StringLength(2)]
        public string Rubro { get; set; }
        [Required(ErrorMessage = "El campo cuenta es obligatorio.")]
        [StringLength(2)]
        public string Cuenta { get; set; }
        [Required(ErrorMessage = "El campo subcuenta es obligatorio.")]
        [StringLength(6)]
        public string Subcuenta { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(500)]
        public string Descripcion { get; set; }
        [NotMapped]
        public string NroCuenta { get { return Titulo + "." + Capitulo + "." + Rubro + "." + Cuenta + "." + Subcuenta; } }
    }
}
