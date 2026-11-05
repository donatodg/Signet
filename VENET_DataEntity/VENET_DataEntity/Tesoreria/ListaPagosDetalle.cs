namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ListaPagosDetalle")]
    public class ListaPagosDetalle : ClaseBase
    {
        public int Id_ListaPago { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        public int Id_Entidad { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para importe es obligatorio.")]
        public decimal Importe { get; set; }
        // [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        public int? Id_OP { get; set; }


        [ForeignKey("Id_ListaPago")]
        public virtual ListaPagos ListaPago { get; set; }
        [NotMapped]
        public string Entidad { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
