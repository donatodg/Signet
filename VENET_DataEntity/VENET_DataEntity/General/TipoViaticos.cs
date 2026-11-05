namespace VENET_DataEntity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoViaticos")]
    public class TipoViaticos : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        public virtual ICollection<TipoViaticosPrecios> Detalle { get; set; }
    }
}
