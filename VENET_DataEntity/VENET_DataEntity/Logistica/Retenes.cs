namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Retenes")]
    public class Retenes : ClaseBase
    {
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para proveedor es obligatorio.")]
        public int Id_Proveedor { get; set; }
        [StringLength(500)]
        public string Motivo { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad es obligatorio.")]
        public int? Id_Unidad { get; set; }
        public decimal Tn { get; set; }
        [StringLength(10)]
        public string Dominio { get; set; }
        public Enums.HsKmUnd HsKmUnd { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoSTD { get; set; }
        public decimal CostoAdicional { get; set; }
        public int? Id_FacturaTango { get; set; }
        public decimal? Total { get { return Cantidad * (CostoSTD + CostoAdicional); } }
    }
}
