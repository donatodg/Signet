namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CircuitosAutorizadosDetalle")]
    public class CircuitosAutorizadosDetalle : ClaseBase
    {
        public int Id_CircuitoAutorizado { get; set; }

        public decimal Importe { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para cantidad es obligatorio.")]
        public int Cantidad { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para descripción es obligatorio.")]
        [StringLength(200)]
        public string Descripcion { get; set; }


        [ForeignKey("Id_CircuitoAutorizado")]
        public virtual CircuitosAutorizados CircuitoAutorizado { get; set; }
        [NotMapped]
        public decimal Total { get { return Importe * Cantidad; } }
        [NotMapped]
        public bool Borrado { get; set; }
    }
}
