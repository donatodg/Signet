namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EntidadesBancarias")]
    public class EntidadesBancarias
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de alta es obligatoria.")]
        public DateTime FechaAdd { get; set; }
        public DateTime? FechaMod { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario de alta es obligatorio.")]
        public int UserAdd { get; set; }
        public int? UserMod { get; set; }
    }
}
