namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rendiciones")]
    public class Rendiciones : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para caja es obligatorio.")]
        public int Id_Caja { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        public string Ids_Vales { get; set; }
        public decimal ImporteVale { get; set; }
        [Required]
        public decimal Devolucion { get; set; }
        [Required]
        public decimal Diferencia { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        [StringLength(300)]
        public string MotivoAnulacion { get; set; }

        public virtual ICollection<RendicionesDetalle> Detalle { get; set; }
    }
}
