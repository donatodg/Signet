namespace VENET_DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Remitos")]
    public class Remitos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal de origen es obligatorio.")]
        public int Id_SucursalOrigen { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de destino es obligatorio.")]
        public Enums.TipoDestinoRemito Id_TipoDestino { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para destino es obligatorio.")]
        public int Id_Destino { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para número es obligatorio.")]
        public int Numero { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        [StringLength(300)]
        public string MotivoAnulacion { get; set; }
        public virtual ICollection<RemitosDetalle> Detalle { get; set; }
    }
}
