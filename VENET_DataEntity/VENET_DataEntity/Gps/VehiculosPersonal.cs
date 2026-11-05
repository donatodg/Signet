namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("VehiculosPersonal")]
    public class VehiculosPersonal : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para vehiculo es obligatorio.")]
        public int Id_Vehiculo { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para titularidad es obligatorio.")]
        public Enums.TipoTitularidad Id_Titularidad { get; set; }
    }
}
