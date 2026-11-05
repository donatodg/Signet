namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Diagramas_Detalle")]
    public class DiagramasDetalle : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para diagrama es obligatorio.")]
        public int Id_Diagrama { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. de servicio es obligatorio.")]
        public int NroServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro de turno es obligatorio.")]
        public int Turno { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para sección es obligatorio.")]
        public int Id_Seccion { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para nro. de vuelta es obligatorio.")]
        public int NroVuelta { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora es obligatoria.")]
        public DateTime Hora { get; set; }
        public bool Marcada { get; set; }
        [StringLength(50)]
        public string Comentario { get; set; }
        public decimal Kms { get; set; }
    }
}
