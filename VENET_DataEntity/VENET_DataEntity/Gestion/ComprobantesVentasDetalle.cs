namespace VENET_DataEntity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ComprobantesVentasDetalle")]
    public class ComprobantesVentasDetalle : ClaseBase
    {
        public int Id_ComprobanteVenta { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        private int _Id_Especie;
        public int Id_Especie
        {
            get
            { return _Id_Especie; }
            set
            {
                if (value != _Id_Especie)
                {
                    _Id_Especie = value;
                    RaisePropertyChanged("Id_Especie");
                }
            }
        }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para cotización es obligatorio.")]
        public decimal Cotizacion { get; set; }

        private int? _Id_Producto;
        public int? Id_Producto
        {
            get
            { return _Id_Producto; }
            set
            {
                if (value != _Id_Producto)
                {
                    _Id_Producto = value;
                    RaisePropertyChanged("Id_Producto");
                }
            }
        }
        public int? Id_ProductoCompuesto { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(4000)]
        public string Descripcion { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para cantidad es obligatorio.")]
        public decimal Cantidad { get; set; }
        public decimal? CantidadStock { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe costo es obligatorio.")]
        public decimal ImporteCosto { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe unitario es obligatorio.")]
        public decimal ImporteUnitario { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para porcentaje descuento es obligatorio.")]
        public decimal PorcDescuento { get; set; }
        public decimal ImporteUnitarioDescuento { get { return ImporteUnitario - (ImporteUnitario * PorcDescuento / 100); } }
        public decimal ImporteUnitarioConIva { get { return ImporteUnitario - (ImporteUnitario * PorcDescuento / 100) + ((ImporteUnitario - (ImporteUnitario * PorcDescuento / 100)) * AlicuotaIva / 100); } }
        public decimal ImporteConDescuento { get { return (Cantidad * ImporteUnitario) - ((Cantidad * ImporteUnitario) * PorcDescuento / 100); } }
        //*********************************************
        public decimal ImporteSINDescuentoCONIva_MAL { get { return (ImporteUnitario + (ImporteUnitario * AlicuotaIva / 100)) * Cantidad; } }
        public decimal ImporteDescuentoCONIva_MAL { get { return ((ImporteUnitario + (ImporteUnitario * AlicuotaIva / 100)) * Cantidad) * PorcDescuento / 100; } }
        //*********************************************

        [Range(0, 2147483647, ErrorMessage = "El valor para alicuota Iva es obligatorio.")]
        public int Id_AlicuotaIva { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para alicuota de Iva es obligatorio.")]
        public decimal AlicuotaIva { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe Iva es obligatorio.")]
        public decimal ImporteIVA { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe es obligatorio.")]
        public decimal Importe { get; set; }


        [ForeignKey("Id_ComprobanteVenta")]
        public virtual ComprobantesVentas ComprobanteVenta { get; set; }
        [NotMapped]
        public string Especie { get; set; }
        [NotMapped]
        public decimal ImporteSinIVa { get { return Cantidad * ImporteUnitario; } }
        [NotMapped]
        public bool Borrado { get; set; }
        [NotMapped]
        public bool Visible_Cantidad_Stock { get; set; }
        [NotMapped]
        public string Unidad_Venta { get; set; }
        [NotMapped]
        public string Unidad_Stock { get; set; }


        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
