namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Empresas")]
    public class Empresas : ClaseBase
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Fantasia { get; set; }
        [StringLength(100)]
        public string Direccion { get; set; }
        public int? Id_CodPostal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de Iva es obligatorio.")]
        public int Id_TipoIva { get; set; }
        [StringLength(13)]
        public string Cuit { get; set; }
        [StringLength(800)]
        public string Actividad { get; set; }
        [StringLength(50)]
        public string IngresosBrutos { get; set; }
        public DateTime? InicioActividades { get; set; }
        [StringLength(200)]
        public string RutaCertSigner { get; set; }
        [StringLength(50)]
        public string ClaveCertSigner { get; set; }
        public DateTime? FechaVtoCert { get; set; }
    }
}
