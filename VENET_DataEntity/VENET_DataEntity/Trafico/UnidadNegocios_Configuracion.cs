namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UnidadNegocios_Configuracion")]
    public class UnidadNegocios_Configuracion
    {
        [Key]
        public int Id_UnidadNegocio { get; set; }
        public int RotaHabil { get; set; }
        public int RotaSabado { get; set; }
        public int RotaFeriado { get; set; }
    }
}
