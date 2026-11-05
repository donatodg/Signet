namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RemitosDetalle")]
    public class RemitosDetalle : ClaseBase
    {
        public int Id_Remito { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para productio es obligatorio.")]
        public int Id_Producto { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(200)]
        public string Descripcion { get; set; }

        [ForeignKey("Id_Remito")]
        public virtual Remitos Remito { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
