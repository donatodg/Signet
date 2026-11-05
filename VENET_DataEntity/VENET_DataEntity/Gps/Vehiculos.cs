namespace VENET_DataEntity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vehiculos")]
    public class Vehiculos : ClaseBase
    {
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(20)]
        public string Descripcion { get; set; }
        [StringLength(50)]
        public string Observaciones { get; set; }
        [StringLength(10)]
        public string Dominio { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para unidad de negocio es obligatorio.")]
        public int Id_UnidadNegocio { get; set; }
        public int? Id_Zona { get; set; }
        public int? Id_Ruta { get; set; }
        public decimal? VelocidadMaxima { get; set; }

        public virtual ICollection<VehiculosEntradas> Detalle { get; set; }
    }

}
