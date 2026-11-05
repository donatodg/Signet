namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("EntidadesImpuestoAlicuotas")]
    public class EntidadesImpuestoAlicuotas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de entidad es obligatorio.")]
        public Enums.TipoEntidad Id_TipoEntidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        public int Id_Entidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de impuesto es obligatorio.")]
        public int Id_ImpuestoAlicuota { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

        //[NotMapped]
        //public ImpuestosAlicuotas ImpAlicuota { get; set; }
    }
}
