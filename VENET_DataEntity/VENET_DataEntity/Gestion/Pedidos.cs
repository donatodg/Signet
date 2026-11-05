namespace VENET_DataEntity
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("Pedidos")]
    public class Pedidos : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para talonario es obligatorio.")]
        public int Id_TalonariosComprobantes { get; set; }
        [Required(ErrorMessage = "El campo letra es obligatorio.")]
        [StringLength(2)]
        public string Letra { get; set; }
        [Required(ErrorMessage = "El campo punto de venta es obligatorio.")]
        [StringLength(4)]
        public string PuntoVenta { get; set; }
        [Required(ErrorMessage = "El campo número de comprobante es obligatorio.")]
        [StringLength(8)]
        public string NroComprobante { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de entidad es obligatorio.")]
        public Enums.TipoEntidad Id_TipoEntidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        public int? Id_Entidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para vendedor es obligatorio.")]
        public int Id_Vendedor { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de entrega es obligatoria.")]
        public DateTime FechaEntrega { get; set; }
        [Required(ErrorMessage = "El campo observaciones es obligatorio.")]
        [StringLength(1000)]
        public string Observaciones { get; set; }
        public DateTime? FechaEntregado { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        [StringLength(300)]
        public string MotivoAnulacion { get; set; }
        public int? Id_ComprobanteGenerado { get; set; }

        public virtual ICollection<PedidosDetalle> Detalle { get; set; }


        [NotMapped]
        public string Comprobante { get { return Letra + "-" + PuntoVenta + "-" + NroComprobante; } }
        [NotMapped]
        public int Avance
        {
            get
            {
                if (Detalle == null)
                    return 0;
                else return Convert.ToInt32( Detalle.Where(t => t.UserDel == null).Select(t => t.Avance).DefaultIfEmpty().Average());
            }
        }
        [NotMapped]
        public string Entregado
        {
            get
            {
                if (Detalle == null) return "";

                int Cantidad = Detalle.Where(t => t.UserDel == null).Count();
                int Entregado = Detalle.Where(t => t.UserDel == null && FechaEntrega != null).Count();

                if (Entregado > 0 && Cantidad == Entregado)
                    return "Entregado";
                else if (Entregado > 0 && Cantidad != Entregado)
                    return "Parcial";
                else
                    return "Pendiente";
            }
        }

    }
}
