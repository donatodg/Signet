namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeguridadUsuarios")]
    public class SeguridadUsuarios : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para grupo es obligatorio.")]
        public int Id_Grupo { get; set; }
        [Required(ErrorMessage = "El campo usuario es obligatorio.")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo clave es obligatorio.")]
        [StringLength(50)]
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public int? Legajo { get; set; }
        public string Email { get; set; }
        public byte[] Foto { get; set; }
        public string Tema { get; set; }
        public string BackColor { get; set; }
        public byte[] BackImage { get; set; }
        public bool RibbonMinimizado { get; set; }
        public bool TituloTile { get; set; }
        [Column(TypeName = "xml")]
        public string TileConfig { get; set; }
        public bool? Indicadores { get; set; }
    }
}
