namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Servicios")]
    public class Servicios : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de negocio es obligatorio.")]
        public int Id_UnidadNegocio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
        public int? Id_Proveedor { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }
        public decimal Importe { get; set; }
        public Enums.Periodicidad Periodicidad { get; set; }
        [Range(1, 31, ErrorMessage = "El valor para día de vencimiento es obligatorio.")]
        public int DiaVencimiento { get; set; }
        [StringLength(100)]
        public string Domicilio { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de vigencia desde es obligatoria.")]
        public DateTime VigenciaDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }
        public string Observaciones { get; set; }
    }
}
