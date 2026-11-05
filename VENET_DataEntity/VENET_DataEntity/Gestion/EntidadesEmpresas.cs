namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("EntidadesEmpresas")]
    public class EntidadesEmpresas : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de entidad es obligatorio.")]
        public Enums.TipoEntidad TipoEntidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        public int Id_Entidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa{ get; set; }
    }
}
