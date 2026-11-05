namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("TipoImpuestos")]
    public class TipoImpuestos : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        public Enums.TipoImpuesto Id_TipoImpuesto { get; set; }
        public Enums.AplicaSobre AplicaSobre { get; set; }
        public int? Id_AFIP_Tributos { get; set; }
    }
}
