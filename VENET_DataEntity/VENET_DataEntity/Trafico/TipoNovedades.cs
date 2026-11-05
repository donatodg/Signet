namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoNovedades")]
    public class TipoNovedades : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripcion es obligatorio.")]
        [StringLength(5)]
        public String Descripcion { get; set; }
        [Required(ErrorMessage = "El campo descripcion larga es obligatorio.")]
        [StringLength(100)]
        public String DescripcionLarga { get; set; }
        public Boolean Visible { get; set; }

    }
}
