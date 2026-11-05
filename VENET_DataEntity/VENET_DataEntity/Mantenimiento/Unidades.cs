namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Unidades")]
    public class Unidades : ClaseBase
    {
        [Required(ErrorMessage = "El campo dominio es obligatorio.")]
        [StringLength(10)]
        public string Dominio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para estado de unidad es obligatorio.")]
        public int Id_EstadoUnidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para modelo de año es obligatorio.")]
        public int AñoModelo { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa titular es obligatorio.")]
        public int Id_EmpresaTitular { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de unidad es obligatorio.")]
        public int Id_TipoUnidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para condicion de uso es obligatorio.")]
        public int Id_CondicionUso { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para interno es obligatorio.")]
        public int Interno { get; set; }
        public DateTime? FechaVtoCedula { get; set; }
        [StringLength(31)]
        public string ChasisNumero { get; set; }
        public int? ChasisAño { get; set; }
        public int? Id_ProveedorChasis { get; set; }
        public int? Id_ChasisMarca { get; set; }
        public int? Id_ChasisModelo { get; set; }
        public int? Id_ChasisTipo { get; set; }
        public decimal? ChasisMonto { get; set; }
        [StringLength(20)]
        public string ChasisFactura { get; set; }
        [StringLength(31)]
        public string MotorNumero { get; set; }
        public int? MotorAño { get; set; }
        public int? Id_ProveedorMotor { get; set; }
        public int? Id_MotorMarca { get; set; }
        public int? Id_MotorModelo { get; set; }
        [StringLength(20)]
        public string MotorFactura { get; set; }
        public decimal? MotorMonto { get; set; }
        public int? Id_ProveedorCarroceria { get; set; }
        public int? CarroceriaAño { get; set; }
        public int? Id_CarroceriaModelo { get; set; }
        [StringLength(20)]
        public string CarroceriaFactura { get; set; }
        public int? CarroceriaCupo { get; set; }
        public int? Id_CarroceriaCaracteristica { get; set; }
        public decimal? CarroceriaMonto { get; set; }
        public int? Id_Deudor { get; set; }
        public int? Id_Acreedor { get; set; }
        public DateTime? DeudaFechaInicio { get; set; }
        public decimal? DeudaMonto { get; set; }
        public DateTime? DeudaFechaVenc { get; set; }
        public int? Id_EstadoDeuda { get; set; }
        [StringLength(20)]
        public string DeudaCodigo { get; set; }
        public bool? PoseeAire { get; set; }
        public bool? PoseeRampa { get; set; }
        public bool? PoseeTacografo { get; set; }
        public bool? PoseeCartel { get; set; }
        public bool? PoseeExpendedora { get; set; }
        public bool? PoseeGps { get; set; }
        public bool? PoseeBaño { get; set; }
        public int? Id_TipoCombustible { get; set; }
        public decimal? CapacidadTanque { get; set; }
        [StringLength(50)]
        public string NroTacografo { get; set; }
        public bool VenceCedula{ get; set; }
        public string Observaciones { get; set; }
        public int? Id_Tag { get; set; }
    }
}