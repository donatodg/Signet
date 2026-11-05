namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ActivosFijos")]
    public class ActivosFijos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de negocio es obligatorio.")]
        public int Id_UnidadNegocio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para clase es obligatorio.")]
        public int Id_Clase { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para familia es obligatorio.")]
        public int Id_Familia { get; set; }
        public int? Id_Proveedor { get; set; }
        //[Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de compra es obligatoria.")]
        public DateTime? FechaCompra { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }
        public decimal? CostoOriginal { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        [StringLength(20)]
        public string CodTango { get; set; }
        [StringLength(50)]
        public string CodBarras { get; set; }
        [StringLength(50)]
        public string CodInterno { get; set; }
        [StringLength(50)]
        public string NroSerie { get; set; }
        [StringLength(50)]
        public string Marca { get; set; }
        public int? UbicacionId_Sucursal { get; set; }
        [StringLength(50)]
        public string UbicacionSector { get; set; }
        public int? UbicacionId_Deposito { get; set; }
        public int? UbicacionId_Personal { get; set; }
        public int? UbicacionId_Coche { get; set; }
        public DateTime? UbicacionFechaAsignacion { get; set; }
        [StringLength(8000)]
        public string Observaciones { get; set; }
        public byte[] Foto { get; set; }
        public DateTime? ReparacionFecha { get; set; }
        public int? Id_Remito { get; set; }
        public DateTime? FechaBaja { get; set; }
        [StringLength(500)]
        public string MotivoBaja { get; set; }
        [StringLength(100)]
        public string DatoAdicional1 { get; set; }
        [StringLength(100)]
        public string DatoAdicional2 { get; set; }
        [StringLength(100)]
        public string DatoAdicional3 { get; set; }
        [StringLength(100)]
        public string DatoAdicional4 { get; set; }
        [StringLength(100)]
        public string DatoAdicional5 { get; set; }
        [StringLength(100)]
        public string DatoAdicional6 { get; set; }
        [StringLength(100)]
        public string DatoAdicional7 { get; set; }
        [StringLength(100)]
        public string DatoAdicional8 { get; set; }
        [StringLength(100)]
        public string DatoAdicional9 { get; set; }
        [StringLength(100)]
        public string DatoAdicional10 { get; set; }
    }
}
