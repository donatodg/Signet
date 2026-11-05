namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PersonalNovedades")]
    public class PersonalNovedades : ClaseBase
    {
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para Personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de novedad es obligatorio.")]
        public int Id_TipoNovedad { get; set; }
      //  [Required(ErrorMessage = "El campo Observaciones es obligatorio.")]
        [StringLength(50)]
        public string Observaciones { get; set; }
    }
}
