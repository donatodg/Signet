namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FacturasTangoDatos")]
    public class FacturasTangoDatos 
    {
        [Key]
        [Column(Order = 1)]
        [Range(1, 2147483647, ErrorMessage = "El valor para factura tango es obligatorio.")]
        public int Id_FacturaTango { get; set; }
        [Key]
        [Column(Order = 2)]
        [Range(1, 2147483647, ErrorMessage = "El valor para dato es obligatorio.")]
        public int Id_Dato { get; set; }
    }
}
