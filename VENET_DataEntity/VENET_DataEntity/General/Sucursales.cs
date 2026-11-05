namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Sucursales")]
    public class Sucursales : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para Empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        public int? Numero { get; set; }
        public DateTime? Fecha_Apertura { get; set; }
        public DateTime? Fecha_Cierre { get; set; }
        public string DomicilioCalle { get; set; }
        public string DomicilioNro { get; set; }
        public string DomicilioPiso { get; set; }
        public string DomicilioDpto { get; set; }
        public int? CodPos { get; set; }
       
    }
}
