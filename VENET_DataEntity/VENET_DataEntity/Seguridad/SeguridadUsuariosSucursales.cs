namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeguridadUsuariosSucursales")]
    public class SeguridadUsuariosSucursales : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario es obligatorio.")]
        public int Id_Usuario { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }

    }
}
