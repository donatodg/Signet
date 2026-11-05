namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Recibos_Detalle")]
    public class RecibosDetalle : ClaseBase
    {
        public int Id_Recibo { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para cotización es obligatorio.")]
        public decimal Cotizacion { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para importe es obligatorio.")]
        public decimal Importe { get; set; }
        [Required(ErrorMessage = "El campo detalle es obligatorio.")]
        [StringLength(100)]
        public string Detalle { get; set; }
        public int? Id_Documento { get; set; }
        public Enums.TipoEntidad? Id_TipoEntidad { get; set; }
        public int? Id_Entidad { get; set; }
        public int? Id_TipoPercepcion { get; set; }
        public bool? TarjetaDebito { get; set; }
        public bool? TarjetaCredito { get; set; }

        [ForeignKey("Id_Recibo")]
        public virtual Recibos Recibo { get; set; }
        [NotMapped]
        public string Especie { get; set; }
        [NotMapped]
        public string TipoMovimiento
        {
            get
            {
                if (Id_Documento > 0) return "Cheque";
                else if (Id_TipoEntidad > 0) return "Cta.Cte.";
                else if (TarjetaDebito == true) return "T.Débito";
                else if (TarjetaCredito == true) return "T.Crédito";
                else if (Id_TipoPercepcion > 0) return "Percepción";
                else if (Id_Documento == null &&
                         Id_TipoEntidad == null &&
                         Id_TipoPercepcion == null &&
                         TarjetaDebito == null &&
                         TarjetaCredito == null
                         ) return "Efectivo";
                else return "";
            }
        }
        [NotMapped]
        public string NombreEntidad { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
