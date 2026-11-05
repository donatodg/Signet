namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServiciosEventualesViaticos")]
    public class CodigosServiciosEventualesViaticos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para codigo de servicio es obligatorio.")]
        public Int32 Id_CodigoServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de viatico es obligatorio.")]
        public Int32 Id_TipoViatico { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cantidad es obligatorio.")]
        public Int32 Cantidad { get; set; }
    }
}
