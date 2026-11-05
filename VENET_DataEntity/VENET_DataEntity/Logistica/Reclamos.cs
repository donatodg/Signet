namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Reclamos")]
    public class Reclamos : ClaseBase
    {
        public DateTime Fecha { get; set; }
        //[StringLength(50)]
        public Enums.Regiones Region { get; set; }
        //[StringLength(50)]
        public Enums.Grupos Grupo { get; set; }
        [StringLength(50)]
        public string Circuito { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para factura es obligatorio.")]
        public int? Id_Factura { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad es obligatorio.")]
        public int Id_Unidad { get; set; }
        public string Tn { get; set; }
        [StringLength(10)]
        public string Dominio { get; set; }
        public Enums.HsKmUnd HsKmUnd { get; set; }
        public decimal Cantidad { get; set; }
        public decimal TarifaTrans { get; set; }
        public decimal ValorDia { get { return Cantidad * TarifaTrans; } }
        public decimal TarifaRecupero { get; set; }
        public decimal ImporteRecupero { get { return Cantidad * TarifaRecupero; } }
        [StringLength(50)]
        public string Inicio { get; set; }
        [StringLength(50)]
        public string Fin { get; set; }
        [StringLength(800)]
        public string Observaciones { get; set; }
        public DateTime? FechaLiquidado { get; set; }
        public Enums.SiNo? EstadoLiquidado { get; set; }
        [StringLength(800)]
        public string ObservacionesLiquidado { get; set; }

        [NotMapped]
        public int Id_Proveedor { get; set; }
        [NotMapped]
        public decimal Total { get { return (Cantidad * TarifaTrans) + (Cantidad * TarifaRecupero); } }
    }
}
