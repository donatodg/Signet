namespace VENET_DataEntity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("TipoAsientos")]
    public class TipoAsientos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de asiento es obligatorio.")]
        public Enums.TiposDeAsientos Id_AsientoPredefinido { get; set; }

        [Required(ErrorMessage = "El campo concepto es obligatorio.")]
        [StringLength(300)]
        public string Concepto { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para Empresa es obligatorio.")]
        public int Id_Empresa { get; set; }

        public virtual ICollection<TipoAsientosDetalle> Detalle { get; set; }
    }
}
