namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("ComprobantesVentasAProcesar")]
    public class ComprobantesVentasAProcesar : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para tipo de entidad es obligatorio.")]
        public Enums.TipoEntidad Id_TipoEntidad { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        public int? Id_Entidad { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

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
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(4000)]
        public string Descripcion { get; set; }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para cantidad es obligatorio.")]
        public decimal Cantidad { get; set; }
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
        [Range(0, 2147483647, ErrorMessage = "El valor para importe costo es obligatorio.")]
        public decimal ImporteCosto { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe unitario es obligatorio.")]
        public decimal ImporteUnitario { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para porcentaje descuento es obligatorio.")]
        public decimal PorcDescuento { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para alicuota Iva es obligatorio.")]
        public int Id_AlicuotaIva { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para alicuota de Iva es obligatorio.")]
        public decimal AlicuotaIva { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe Iva es obligatorio.")]
        public decimal ImporteIVA { get; set; }
        [Range(0, 2147483647, ErrorMessage = "El valor para importe es obligatorio.")]
        public decimal Importe { get; set; }
        public int? Id_ComprobanteVenta { get; set; }

        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
