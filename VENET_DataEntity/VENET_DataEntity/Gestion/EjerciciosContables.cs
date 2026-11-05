namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EjerciciosContables")]
    public class EjerciciosContables : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia desde es obligatoria.")]
        public DateTime VigenciaDesde { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia hasta es obligatoria.")]
        public DateTime VigenciaHasta { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(200)]
        public string Descripcion { get; set; }
        public bool Cerrado { get; set; }
    }
}
