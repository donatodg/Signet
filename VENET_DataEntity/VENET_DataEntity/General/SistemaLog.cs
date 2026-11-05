namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SistemaLog")]
    public class SistemaLog
    {
        [Key]
        public int Id { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario es obligatorio.")]
        public int Id_Usuario { get; set; }
        public int Accion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo host es obligatorio.")]
        [StringLength(50)]
        public string Host { get; set; }
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        [StringLength(50)]
        public string UserLocal { get; set; }
        //[Required(ErrorMessage = "El campo IP local es obligatorio.")]
        [StringLength(50)]
        public string IPLocal { get; set; }
        //[Required(ErrorMessage = "El campo IP pública es obligatorio.")]
        [StringLength(50)]
        public string IPPublica { get; set; }
        [Required(ErrorMessage = "El campo base de datos es obligatorio.")]
        [StringLength(50)]
        public string BaseDatos { get; set; }
        public string VersionSistema { get; set; }
    }
}
