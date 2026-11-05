namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductosComposicion")]
    public class ProductosComposicion : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para producto final es obligatorio.")]
        public int Id_ProductoFinal { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para producto es obligatorio.")]

        private int?  _Id_ProductoComposicion;
        public int? Id_ProductoComposicion
        {
            get
            { return _Id_ProductoComposicion; }
            set
            {
                if (value != _Id_ProductoComposicion)
                {
                    _Id_ProductoComposicion = value;
                    RaisePropertyChanged("Id_Producto");
                }
            }
        }
        [Range(0.01, 2147483647, ErrorMessage = "El valor para cantidad es obligatorio.")]
        public decimal Cantidad { get; set; }
        //[Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(200)]
        public string Observaciones { get; set; }

        [NotMapped]
        public string Producto{ get; set; }
        [NotMapped]
        public string Medida { get; set; }
        [NotMapped]
        public DateTime? FechaActualizacionCosto { get; set; }
        [NotMapped]
        public decimal ImporteCosto { get; set; }
        [NotMapped]
        public decimal TotalCosto { get { return ImporteCosto * Cantidad; } }

        //[ForeignKey("Id_ProductoFinal")]
        //public virtual Productos Producto { get; set; }

        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
