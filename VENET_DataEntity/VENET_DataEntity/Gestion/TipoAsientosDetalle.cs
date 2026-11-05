namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoAsientosDetalle")]
    public class TipoAsientosDetalle : ClaseBase
    {
        public int Id_TipoAsiento { get; set; }
        public bool CuentaContable { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cuenta contable es obligatorio.")]
        public int Id_CuentaContable { get; set; }
        public bool Debe { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cuenta importe es obligatorio.")]
        public int Id_CuentaImporte { get; set; }

        [ForeignKey("Id_TipoAsiento")]
        public virtual TipoAsientos TipoAsientos { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
