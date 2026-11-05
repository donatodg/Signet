namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Diagramas_Fecha")]
    public class DiagramasFecha : ClaseBase
    {
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para diagrama es obligatorio.")]
        public int Id_Diagrama { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. de servicio es obligatorio.")]
        public int NroServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro de turno es obligatorio.")]
        public int Turno { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para Coche es obligatorio.")]
        public int Id_Coche { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para Personal es obligatorio.")]
        public int Id_Personal { get; set; }
    }
}
