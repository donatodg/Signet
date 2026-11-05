namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("OrdenesPagoDetalle")]
    public class OrdenesPagoDetalle : ClaseBase
    {
        public int Id_OrdenPago { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para cotización es obligatorio.")]
        public decimal Cotizacion { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para importe es obligatorio.")]
        public decimal Importe { get; set; }
        [StringLength(100)]
        public string Detalle { get; set; }
        public int? Id_Documento { get; set; }
        public int? Id_DocumentoPropio { get; set; }
        public Enums.TipoEntidad? Id_TipoEntidad { get; set; }
        public int? Id_Entidad { get; set; }

        [ForeignKey("Id_OrdenPago")]
        public virtual OrdenesPago OrdenPago { get; set; }
        [NotMapped]
        public string Especie { get; set; }
        [NotMapped]
        public string TipoMovimiento
        {
            get
            {
                if (Id_Documento > 0) return "Cheque";
                else if (Id_TipoEntidad > 0) return "Cta.Cte.";
                else if (Id_DocumentoPropio > 0) return "Ch. Propio";
                else if (Id_Documento == null && Id_TipoEntidad == null && Id_DocumentoPropio == null) return "Efectivo";
                else return "";
            }
        }
        [NotMapped]
        public string NombreEntidad { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
