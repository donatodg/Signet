namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ViajesEspecialesDetalle")]
    public class ViajesEspecialesDetalle : ClaseBase
    {
        public int Id_ViajeEspecial { get; set; }
        public int? Id_Coche { get; set; }
        public int? Id_Personal1 { get; set; }
        public int? Id_Personal2 { get; set; }
        public bool? FueraLinea { get; set; }
        public bool CobraViaticoPersonal1 { get; set; }
        public bool CobraViaticoPersonal2 { get; set; }
        [StringLength(8000)]
        public string Observaciones { get; set; }
        public int? Id_Vale { get; set; }
        public DateTime? FechaPagoPersonal1 { get; set; }
        public DateTime? FechaPagoPersonal2 { get; set; }

        [ForeignKey("Id_ViajeEspecial")]
        public virtual ViajesEspeciales Viaje { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
        [NotMapped]
        public string Personal1 { get; set; }
        [NotMapped]
        public string Personal2 { get; set; }
        [NotMapped]
        public string Interno { get; set; }


    }
}
