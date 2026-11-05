namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CodigosServiciosVueltasDetalle")]
    public class CodigosServiciosVueltasDetalle : ClaseBase
    {
        public int Id_CodigoServicioVuelta { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para nro. de vuelta es obligatorio.")]
        //public Int32 NroVuelta { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para sección es obligatorio.")]
        public int Id_Seccion { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La hora es obligatoria.")]
        public DateTime Hora { get; set; }
        [Range(1, 9, ErrorMessage = "El valor para día es obligatorio y debe estar comprendido entre 1 y 9.")]
        public int Dia { get; set; }
       
        [ForeignKey("Id_CodigoServicioVuelta")]
        public virtual CodigosServiciosVueltas Vuelta { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }
        [NotMapped]
        public string Seccion { get; set; }
        [NotMapped]
        public int NroSecccion { get; set; }
    }
}
