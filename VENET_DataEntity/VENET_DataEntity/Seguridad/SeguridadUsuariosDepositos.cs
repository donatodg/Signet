namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeguridadUsuariosDepositos")]
    public class SeguridadUsuariosDepositos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario es obligatorio.")]
        public int Id_Usuario { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para depósito es obligatorio.")]
        public int Id_Deposito { get; set; }

    }
}
