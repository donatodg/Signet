namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Autorizaciones")]
    public class Autorizaciones : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para dato es obligatorio.")]
        public int Id_Dato { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. de orden es obligatorio.")]
        public int NroOrden { get; set; }
        [StringLength(100)]
        public string Region { get; set; }
        [StringLength(100)]
        public string Grupo { get; set; }
        [StringLength(100)]
        public string OfConcentradora { get; set; }
        [StringLength(50)]
        public string Tipo { get; set; }
        [StringLength(100)]
        public string Servicio { get; set; }
        public Enums.HsKmUnd HsKmUnd { get; set; }
        public DateTime Fecha { get; set; }
        [StringLength(50)]
        public string Circuito { get; set; }
        [StringLength(50)]
        public string Patente { get; set; }
        public string Tn { get; set; }
        public decimal Cantidad { get; set; }
        public decimal TarifaProveedor { get; set; }
        public decimal ImporteProveedor { get; set; }
        public decimal TarifaRecupero { get; set; }
        public decimal ImporteRecupero { get; set; }
        public decimal TarifaNueva { get; set; }
        public decimal ImporteNuevo { get; set; }
        [StringLength(800)]
        public string Observaciones { get; set; }
        public int? Id_FacturaTango { get; set; }
        public bool? Autorizado { get; set; }
        public int? UserAutoriza { get; set; }
        public DateTime? FechaAutoriza { get; set; }
        [StringLength(800)]
        public string MotivoAutoriza { get; set; }
        public int? Id_Proveedor { get; set; }


    }
}
