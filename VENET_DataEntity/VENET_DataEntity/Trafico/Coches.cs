namespace VENET_DataEntity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Coches")]
    public class Coches : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        public int Id_UnidadNegocio { get; set; }
        public int? Id_TipoServicio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para interno es obligatorio.")]
        public int Interno { get; set; }
        [Required(ErrorMessage = "El campo dominio es obligatorio.")]
        [StringLength(100)]
        public string Dominio { get; set; }
        public int? HabilServicioFijo { get; set; }
        public int? SabadoServicioFijo { get; set; }
        public int? DomingoServicioFijo { get; set; }
        public int? FeriadoServicioFijo { get; set; }
        public string Id_Externo { get; set; }
        public bool PisoBajo { get; set; }
        public bool ConRampa { get; set; }
        public bool ConAscensor { get; set; }
        public bool Articulado { get; set; }
        public Enums.TipoUnidades Id_TipoVehiculo { get; set; }
        public virtual ICollection<CochesPublicidad> Publicidades { get; set; }
    }
}
