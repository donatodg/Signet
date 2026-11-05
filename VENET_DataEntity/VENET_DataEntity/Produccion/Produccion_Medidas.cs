namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_Medidas")]
    public class Produccion_Medidas : ClaseBase
    {
        [Required(ErrorMessage = "El valor para ancho es obligatorio.")]
        public decimal Ancho { get; set; }
        [Required(ErrorMessage = "El campo largo es obligatorio.")]
        public decimal Alto { get; set; }
        public string Codigo { get; set; }
        public string Medida { get; set; }


    }
}
