namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ArchivosCajasUsuarios")]
    public class ArchivosCajasUsuarios: ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario es obligatorio.")]
        public int Id_Usuario { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. de caja es obligatorio.")]
        public int NroCaja { get; set; }
    }
}
