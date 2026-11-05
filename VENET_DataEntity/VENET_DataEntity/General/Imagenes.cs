namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Imagenes")]
    public class Imagenes : ClaseBase
    {
        [Required(ErrorMessage = "El campo tabla es obligatorio.")]
        [StringLength(100)]
        public string Tabla { get; set; }
        [Required(ErrorMessage = "El campo id tabla es obligatorio.")]
        public int Id_Tabla { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        public int Id_CategoriaImagen { get; set; }
        public byte[] Imagen { get; set; }
        public int Orden { get; set; }

    }
}
