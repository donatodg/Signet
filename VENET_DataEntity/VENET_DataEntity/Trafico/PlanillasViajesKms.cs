namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanillasViajesKms")]
    public class PlanillasViajesKms
    {
        [Key]
        [Column(Order = 1)]
        [Range(1, 2147483647, ErrorMessage = "El valor para origen es obligatorio.")]
        public int Id_SeccionOrigen { get; set; }
        [Key]
        [Column(Order = 2)]
        [Range(1, 2147483647, ErrorMessage = "El valor para destino es obligatorio.")]
        public int Id_SeccionDestino { get; set; }
        public decimal Kms { get; set; }
    }
}
