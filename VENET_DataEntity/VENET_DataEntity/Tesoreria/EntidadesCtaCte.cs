namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("EntidadesCtaCte")]
    public class EntidadesCtaCte : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de entidad es obligatorio.")]
        public Enums.TipoEntidad Id_TipoEntidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        public int Id_Entidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de comprobante es obligatorio.")]
        public int Id_TipoComprobante { get; set; }
        public int Id_Comprobante { get; set; }
        [Required(ErrorMessage = "El campo concepto es obligatorio.")]
        [StringLength(200)]
        public string Concepto { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public int? Id_Comentario { get; set; }
    }
}
