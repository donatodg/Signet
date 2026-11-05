namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Asientos")]
    public class Asientos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para número es obligatorio.")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(500)]
        public string Descripcion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        [StringLength(300)]
        public string MotivoAnulacion { get; set; }

        public virtual ICollection<AsientosDetalle> Detalle { get; set; }
    }
}
