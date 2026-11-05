namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rendiciones_Detalle")]
    public class RendicionesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int Id_Rendicion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cuenta es obligatorio.")]
        public int Id_Cuenta { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El importe es obligatorio.")]
        public decimal Importe { get; set; }


        [ForeignKey("Id_Rendicion")]
        public virtual Rendiciones Rendicion { get; set; }
        [NotMapped]
        public string Cuenta { get; set; }
    }
}
