namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServiciosTodos")]
    public class CodigosServiciosTodos
    {

        [Key]
        [Column(Order = 1)]
        public long Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Id_CodigoServicio { get; set; }
        [Key]
        [Column(Order = 3)]
        [StringLength(9)]
        public string Codigo { get; set; }
    }
}
