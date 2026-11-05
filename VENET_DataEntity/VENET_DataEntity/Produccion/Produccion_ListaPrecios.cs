namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produccion_ListaPrecios")]
    public class Produccion_ListaPrecios : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para empresa es obligatorio.")]
        public int Id_Empresa { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El campo utilidad es obligatorio.")]
        public decimal Utilidad { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha desde es obligatoria.")]
        public DateTime VigenteDesde { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha desde es obligatoria.")]
        public DateTime VigenteHasta { get; set; }
    }
}
