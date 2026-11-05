namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VehiculosPersonalDiario")]
    public class VehiculosPersonalDiario : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para vehiculo es obligatorio.")]
        public int Id_Vehiculo { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
    }
}
