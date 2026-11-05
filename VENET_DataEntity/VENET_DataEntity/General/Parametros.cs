namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Parametros")]
    public class Parametros
    {
        [Key]
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo valor es obligatorio.")]
        [StringLength(500)]
        public string Valor { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(500)]
        public string Descripcion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de dato es obligatorio.")]
        public Enums.TipoDato TipoDato { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para módulo es obligatorio.")]
        public Enums.Modulos Modulo { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? UserMod { get; set; }

    }
}
