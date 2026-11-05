namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeguridadUsuariosConfiguracion")]
    public class SeguridadUsuariosConfiguracion
    {
        [Key]
        public int Id { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para usuario es obligatorio.")]
        public int Id_Usuario { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tile es obligatorio.")]
        public int Id_Tile { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string ColorFuente { get; set; }
        public bool Visible { get; set; }

        //public int? Size { get; set; }

    }
}
