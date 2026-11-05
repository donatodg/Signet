namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EquiposGpsMovimientos")]
    public class EquiposGpsMovimientos : ClaseBase
    {
        public int? Id_EquipoGps { get; set; }
        public int? Id_Sensor { get; set; }
        public int? Id_Vehiculo { get; set; }
        [Required(ErrorMessage = "El campo comentario es obligatorio.")]
        [StringLength(30)]
        public string Comentario { get; set; }
    }
}