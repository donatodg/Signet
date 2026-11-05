namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ClientesDescuentos")]
    public class ClientesDescuentos : ClaseBase
    {
        public int Id_Cliente { get; set; }
        //[Required(ErrorMessage = "El campo categoría es obligatorio.")]
        public int? Id_Categoria2 { get; set; }
        [Required(ErrorMessage = "El campo descuento es obligatorio ó esta fuera de rango.")]
        public decimal Descuento { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Clientes Cliente { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }
        [NotMapped]
        public string Categoria { get; set; }
    }
}
