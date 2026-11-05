namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProvFinancierosCuentas")]
    public class ProvFinancierosCuentas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para proveedor financiero es obligatorio.")]
        public int Id_ProvFinanciero { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad bancaria es obligatorio.")]
        public int Id_EntidadBancaria { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }

        [Range(1, 99999, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int NroSucursal { get; set; }
        [Range(1, 99999, ErrorMessage = "El valor para cod. postal es obligatorio.")]

        public int CodPostal { get; set; }
        [Range(1, 9999999999999, ErrorMessage = "El valor para cuenta es obligatorio.")]
        public long NroCuenta { get; set; }
        [StringLength(22)]
        public string CBU { get; set; }
    }
}
