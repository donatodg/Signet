namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Coches_Publicidad")]
    public class CochesPublicidad : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para coche es obligatorio.")]
        public int Id_Coche { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de comienzo es obligatoria.")]
        public DateTime Empezo { get; set; }
        public DateTime? Finalizo { get; set; }

        [ForeignKey("Id_Coche")]
        public virtual Coches Coche { get; set; }
    }
}
