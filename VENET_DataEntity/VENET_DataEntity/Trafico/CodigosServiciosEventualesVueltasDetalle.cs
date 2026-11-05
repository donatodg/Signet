namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServiciosEventualesVueltasDetalle")]
    public class CodigosServiciosEventualesVueltasDetalle : ClaseBase
    {
        public Int32 Id_CodigoServicioVuelta { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para nro. de vuelta es obligatorio.")]
        //public Int32 NroVuelta { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para sección es obligatorio.")]
        public Int32 Id_Seccion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora es obligatoria.")]
        public DateTime Hora { get; set; }
        [Range(1, 9, ErrorMessage = "El valor para día es obligatorio y debe estar comprendido entre 1 y 9.")]
        public Int32 Dia { get; set; }

        [ForeignKey("Id_CodigoServicioVuelta")]
        public virtual CodigosServiciosEventualesVueltas Vuelta { get; set; }

        [NotMapped]
        public Boolean Borrado { get; set; }
        [NotMapped]
        public String Seccion { get; set; }
        [NotMapped]
        public Int32 NroSecccion { get; set; }
    }
}