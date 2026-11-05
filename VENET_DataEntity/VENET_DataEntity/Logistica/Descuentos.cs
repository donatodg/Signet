namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Descuentos")]
    public class Descuentos : ClaseBase
    {
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para factura es obligatorio.")]
        public int? Id_Factura { get; set; }
        public decimal Importe { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para alícuota es obligatorio.")]
        //public int Id_AlicuotaIva { get; set; }
        [StringLength(50)]
        public string Zona { get; set; }
        [StringLength(800)]
        public string Observaciones { get; set; }
        public Enums.Meses? MesDescuento { get; set; }
        public bool Descontar { get; set; }
        public bool? Descontado { get; set; }
    }
}
