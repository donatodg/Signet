namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Archivos")]
    public class Archivos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para número es obligatorio.")]
        public int Numero { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para precinto es obligatorio.")]
        public int? Precinto { get; set; }
        public int? Precinto1 { get; set; }

        [Range(1, 2147483647, ErrorMessage = "El valor para ublicación es obligatorio.")]
        public int Id_Ubicacion { get; set; }
        public int? UserPrecinta { get; set; }
        public DateTime? FechaPrecinta { get; set; }

        public virtual ICollection<ArchivosDetalle> Detalle { get; set; }
    }
}
