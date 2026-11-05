namespace VENET_DataEntity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Clientes")]
    public class Clientes : ClaseBase
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Empresa { get; set; }
        [StringLength(100)]
        public string Domicilio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para código postal es obligatorio.")]
        public int Id_CodPostal { get; set; }
        [StringLength(13)]
        public string Cuit { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para iva es obligatorio.")]
        public int Id_TipoIva { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public int? Id_ListaPrecio { get; set; }
        public int? Id_FormaPago { get; set; }
        public virtual ICollection<ClientesContactos> Contactos { get; set; }
        public virtual ICollection<ClientesDescuentos> Descuentos { get; set; }
        public virtual ICollection<ClientesEntregas> Entregas { get; set; }
    }
}
