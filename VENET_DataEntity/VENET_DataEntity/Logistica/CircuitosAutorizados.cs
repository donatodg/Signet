namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CircuitosAutorizados")]
    public class CircuitosAutorizados : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para nombre es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string OfConcentradora { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha desde es obligatoria.")]
        public DateTime VigenciaDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }

        public virtual ICollection<CircuitosAutorizadosDetalle> Detalle { get; set; }
    }
}
