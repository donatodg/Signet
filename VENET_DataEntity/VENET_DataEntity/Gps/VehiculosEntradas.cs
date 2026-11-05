namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VehiculosEntradas")]
    public class VehiculosEntradas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para vehiculo es obligatorio.")]
        public int Id_Vehiculo { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entrada es obligatorio.")]
        public int Id_Entrada { get; set; }
        public bool MostrarMensaje { get; set; }
        [StringLength(20)]
        public string ForeColor { get; set; }
        [StringLength(20)]
        public string BackColor { get; set; }
        public bool Sonido { get; set; }

        [ForeignKey("Id_Vehiculo")]
        public virtual Vehiculos Vehiculo { get; set; }

        [NotMapped]
        public string EntradaDescripcion { get; set; }
        [NotMapped]
        public bool Borrado { get; set; }
    }

}
