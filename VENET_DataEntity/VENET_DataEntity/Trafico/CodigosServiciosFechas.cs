namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServiciosFechas")]
    public class CodigosServiciosFechas : ClaseBase
    {
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para planificación vuelta es obligatorio.")]
        public int Id_Planificacion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para código de servicio vuelta es obligatorio.")]
        public int Id_CodigoServicioVuelta { get; set; }
        public int? Id_Coche { get; set; }
        public int? Id_Personal1 { get; set; }
        public int? Id_Personal2 { get; set; }
        public int? Id_Personal3 { get; set; }
        public int? Id_Estado { get; set; }
        [StringLength(500)]
        public string Comentario { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para día es obligatorio.")]
        public int Dia { get; set; }
    }
}
