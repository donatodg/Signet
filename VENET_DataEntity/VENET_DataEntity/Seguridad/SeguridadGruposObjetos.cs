namespace VENET_DataEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SeguridadGruposObjetos")]
    public class SeguridadGruposObjetos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para grupo es obligatorio.")]
        public int Id_Grupo { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para objeto es obligatorio.")]
        public int Id_Objeto { get; set; }
    }
}
