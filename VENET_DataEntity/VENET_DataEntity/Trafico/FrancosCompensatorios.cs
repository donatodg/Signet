namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("FrancosCompensatorios")]
    public class FrancosCompensatorios : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        public Enums.TipoFrancoCompensatorio Id_Tipo { get; set; }
        public DateTime? FechaCompensatoria { get; set; }
        [Required(ErrorMessage = "El campo servicio es obligatorio.")]
        [StringLength(50)]
        public string Servicio { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
