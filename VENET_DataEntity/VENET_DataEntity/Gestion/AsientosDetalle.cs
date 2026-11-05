namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AsientosDetalle")]
    public class AsientosDetalle : ClaseBase
    {
        public int Id_Asiento { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para orden es obligatorio.")]
        public int Orden { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cuenta contable es obligatorio.")]
        public int Id_CuentaContable { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para debe es obligatorio.")]
        public decimal Debe { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para haber es obligatorio.")]
        public decimal Haber { get; set; }

        [ForeignKey("Id_Asiento")]
        public virtual Asientos Asiento { get; set; }
        [NotMapped]
        public string Cuenta { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
