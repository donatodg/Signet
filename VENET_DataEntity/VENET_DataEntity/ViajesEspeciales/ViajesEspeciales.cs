namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ViajesEspeciales")]
    public class ViajesEspeciales : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de negocio es obligatorio.")]
        public int Id_UnidadNegocio { get; set; }
        public int Numero { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha solicitada es obligatoria.")]
        public DateTime FechaSolicitado { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cliente es obligatorio.")]
        public int Id_Cliente { get; set; }

        [Required(ErrorMessage = "El campo origen es obligatorio.")]
        [StringLength(300)]
        public string Origen { get; set; }
        [Required(ErrorMessage = "El campo destino es obligatorio.")]
        [StringLength(300)]
        public string Destino { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha fin es obligatoria.")]
        public DateTime FechaFin { get; set; }
        public int CantPasajeros { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para cantidad de coches es obligatorio.")]
        public int CantCoches { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal KmsEstimados { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal KmsVacios { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal KmsReales { get; set; }
        public bool EsperaRegreso { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal ImporteViaje { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal ImporteViaticoPorChofer { get; set; }
        [DecimalPrecision(18, 2)]
        public decimal ImporteViaticoARendir { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para personal autoriza es obligatorio.")]
        public int Id_PersonalAutoriza { get; set; }
        [StringLength(8000)]
        public string Observaciones { get; set; }
        public string Contacto { get; set; }
        public DateTime? FechaPago { get; set; }
        public DateTime? FechaCerrado { get; set; }
        public virtual ICollection<ViajesEspecialesDetalle> Detalle { get; set; }

    }
}
