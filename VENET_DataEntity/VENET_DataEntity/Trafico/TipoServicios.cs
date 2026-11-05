namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoServicios")]
    public class TipoServicios : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para ramal es obligatorio.")]
        public int Id_Ramal { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [StringLength(100)]
        public string Impresion { get; set; }
        [Required(ErrorMessage = "El campo asientos numerados es obligatorio.")]
        public bool AsientosNumerados { get; set; }
        public bool BoletoEnPlanilla { get; set; }
        public bool? PlanillaCNRT { get; set; }
        public bool? PlanillaCNRTVertical { get; set; }
        public int CantidadRotacion { get; set; }
        //[DecimalPrecision(18, 2)]
        //public Decimal KmsIda { get; set; }
        //[DecimalPrecision(18, 2)]
        //public Decimal KmsRegreso { get; set; }

    }
}
