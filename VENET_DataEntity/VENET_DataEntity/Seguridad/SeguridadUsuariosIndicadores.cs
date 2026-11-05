namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeguridadUsuariosIndicadores")]
    public class SeguridadUsuariosIndicadores :ClaseBase
    {
        public int Id_SeguridadUsuario { get; set; }
        [StringLength(50)]
        public string Indicador1 { get; set; }
        [StringLength(50)]
        public string Indicador2 { get; set; }
        [StringLength(50)]
        public string Indicador3 { get; set; }
        [StringLength(50)]
        public string Indicador4 { get; set; }
        [Column(TypeName = "xml")]
        public string Config { get; set; }
        public int Splitter1X { get; set; }
        public int Splitter2X { get; set; }
        public int Splitter3X { get; set; }
    }
}
