namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vales")]
    public class Vales : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para caja es obligatorio.")]
        public int Id_Caja { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para número es obligatorio.")]
        public int Numero { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El importe es obligatorio.")]
        public decimal Importe { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public int Id_Rendicion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        [StringLength(300)]
        public string MotivoAnulacion { get; set; }

        [NotMapped]
        public string Nombre { get; set; }

    }
}
