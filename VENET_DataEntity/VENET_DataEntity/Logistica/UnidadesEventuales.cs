namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UnidadesEventuales")]
    public class UnidadesEventuales : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para proveedor es obligatorio.")]
        public int Id_Proveedor { get; set; }
       
        [StringLength(10)]
        public string Dominio { get; set; }
        public decimal Tn { get; set; }
           
    }
}
