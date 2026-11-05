namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("TipoComprobante")]
    public class TipoComprobante : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo descripción corta es obligatorio.")]
        [StringLength(4)]
        public string DescripcionCorta { get; set; }
        public Enums.ComprobanteArea Id_Area { get; set; }
        public bool InternoSistema { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para orden es obligatorio.")]
        public int Orden { get; set; }
        public int? Id_TipoCompProcesa { get; set; }
        public int? Id_TipoCompAnula { get; set; }
        public bool MueveStock { get; set; }
        public bool RestaStock { get; set; }
        public Enums.TipoMovimiento? Id_MovimientoCaja { get; set; }
        public Enums.TipoMovimientoDebitoCredito? Id_MovimientoEntidad { get; set; }
        public bool GeneraDeuda { get; set; }
        public bool UtilizaImpuestos { get; set; }
    }
}
