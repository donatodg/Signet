namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Personal")]
    public class Personal : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; }
        public string ApellidoCasada { get; set; }
        [StringLength(50)]
        public string DomicilioCalle { get; set; }
        [StringLength(10)]
        public string DomicilioNro { get; set; }
        [StringLength(5)]
        public string DomicilioPiso { get; set; }
        [StringLength(5)]
        public string DomicilioDpto { get; set; }
        public int? CodPos { get; set; }
        public int? Id_Provincia { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        [StringLength(50)]
        public string Celular { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de alta es obligatoria.")]
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [StringLength(5000)]
        public string Observaciones { get; set; }
        public int? Id_EstadoCivil { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de documento es obligatorio.")]
        public int Id_TipoDoc { get; set; }
        public int? NroDoc { get; set; }
        public int Id_Tipo { get; set; }
        public int Id_Jerarquia { get; set; }
        [StringLength(13)]
        public string Cuit { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para iva es obligatorio.")]
        public int Id_TipoIva { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para legajo es obligatorio.")]
        public int? LaboralLegajo { get; set; }
        [StringLength(50)]
        public string LaboralSucursal { get; set; }
        [StringLength(50)]
        public string LaboralDomicilio { get; set; }
        public int? LaboralCodPos { get; set; }
        [StringLength(50)]
        public string LaboralTelefono { get; set; }
        public int? LaboralId_Provincia { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de negocio es obligatorio.")]
        public int LaboralId_UnidadNegocio { get; set; }
        public int? LaboralId_TipoServicio { get; set; }
        public int? LaboralId_Cabecera { get; set; }
        public int? LaboralId_GrupoLinea { get; set; }
        public int? LaboralDiasRotacion { get; set; }
        public Enums.DiasSemana? LaboralDiaRotacion { get; set; }
        public Enums.Turno? LaboralTurnoFijo { get; set; }
        public int LaboralFrancoDias { get; set; }
        public DateTime? LaboralVencimientoCarnet { get; set; }
        [StringLength(20)]
        public string LaboralCarnetNumero { get; set; }
        public DateTime? LaboralEmisionCarnet { get; set; }
        public DateTime? LaboralVencimientoCarnetCNRT { get; set; }
        [StringLength(20)]
        public string LaboralCarnetNumeroCNRT { get; set; }
        public DateTime? LaboralEmisionCarnetCNRT { get; set; }
        public DateTime? LaboralVencimientoCarnetAdicional { get; set; }
        [StringLength(20)]
        public string LaboralCarnetNumeroAdicional { get; set; }
        public DateTime? LaboralEmisionCarnetAdicional { get; set; }
        public DateTime? LaboralVencimientoCarnetAdicional2 { get; set; }
        [StringLength(20)]
        public string LaboralCarnetNumeroAdicional2 { get; set; }
        public DateTime? LaboralEmisionCarnetAdicional2 { get; set; }
        public int? LaboralId_PuntaDeLinea { get; set; }
        public int? LaboralId_ServicioInspectores { get; set; }
        public bool? LaboralInspectoresFranco4x1 { get; set; }
        public bool? LaboralInspectoresFrancoSD { get; set; }
    }
}
