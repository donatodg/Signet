namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoViaticosPrecios")]
    public class TipoViaticosPrecios : ClaseBase
    {
        public int Id_TipoViatico { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal Importe { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha desde es obligatoria.")]
        public DateTime VigenciaDesde { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha hasta es obligatoria.")]
        public DateTime VigenciaHasta { get; set; }

        [ForeignKey("Id_TipoViatico")]
        public virtual TipoViaticos Viatico { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }


}
