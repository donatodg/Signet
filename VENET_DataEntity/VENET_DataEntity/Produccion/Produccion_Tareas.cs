namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_Tareas")]
    public class Produccion_Tareas : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo descripción corta es obligatorio.")]
        [StringLength(5)]
        public string DescripcionCorta { get; set; }
        public decimal Unidades { get; set; }
        public DateTime Horas { get; set; }
    }
}
