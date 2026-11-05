namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeguridadUsuariosEmpresas")]
    public class SeguridadUsuariosEmpresas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario es obligatorio.")]
        public int Id_Usuario { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }

    }
}
