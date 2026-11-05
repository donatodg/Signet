namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServiciosEventualesVueltas")]
    public class CodigosServiciosEventualesVueltas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para código de servicio es obligatorio.")]
        public Int32 Id_CodigoServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para número de vuelta es obligatorio.")]
        public Int32 NroVuelta { get; set; }
        public Decimal KmsProductivos { get; set; }
        public Decimal KmsImproductivos { get; set; }
        [Required(ErrorMessage = "El campo sentido es obligatorio.")]
        [StringLength(1)]
        public String Sentido { get; set; }
        public Decimal HsTomeDeje { get; set; }
        public Decimal HsSimple { get; set; }
        public Decimal Hs50 { get; set; }
        public Decimal Hs100 { get; set; }
        public Decimal HsPlus { get; set; }

        public virtual ICollection<CodigosServiciosEventualesVueltasDetalle> Detalle { get; set; }
           
    }
}
   