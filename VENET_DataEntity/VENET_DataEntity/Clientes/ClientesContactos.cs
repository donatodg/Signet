namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ClientesContactos")]
    public class ClientesContactos : ClaseBase
    {
        public int Id_Cliente { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(200)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Telefono1 { get; set; }
        [StringLength(50)]
        public string Telefono2 { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Clientes Cliente { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }
    }
}
