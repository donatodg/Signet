namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_LineasMedidas")]
    public class Produccion_LineasMedidas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para línea es obligatorio.")]
        public int Id_Linea { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para medida es obligatorio.")]
        public int Id_Medida { get; set; }
    }
}
