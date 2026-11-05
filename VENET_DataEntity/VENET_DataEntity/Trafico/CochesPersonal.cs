namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Coches_Personal")]
    public class CochesPersonal : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para coche es obligatorio.")]
        public int Id_Coche { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para personal es obligatorio.")]
        public int Id_Personal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para titularidad es obligatorio.")]
        public Enums.TipoTitularidad Id_Titularidad { get; set; }



    }
}
