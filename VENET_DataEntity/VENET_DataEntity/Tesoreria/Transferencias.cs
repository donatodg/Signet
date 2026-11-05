namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Transferencias")]
    public class Transferencias : ClaseBase
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para caja de origen es obligatorio.")]
        public int _Id_Caja_Origen;
        public int Id_Caja_Origen
        {
            get
            { return _Id_Caja_Origen; }
            set
            {
                _Id_Caja_Origen = value;
                RaisePropertyChanged("Id_Caja_Origen");
            }
        }
        [Range(1, 2147483647, ErrorMessage = "El valor para caja de destino es obligatorio.")]
        public int _Id_Caja_Destino;
        public int Id_Caja_Destino
        {
            get { return _Id_Caja_Destino; }
            set
            {
                _Id_Caja_Destino = value;
                RaisePropertyChanged("Id_Caja_Destino");
            }
        }
        [Range(1, 2147483647, ErrorMessage = "El valor para centro de costo es obligatorio.")]
        public int Id_CentroCosto { get; set; }
        public decimal Cotizacion_Origen { get; set; }
        public decimal Cotizacion_Destino { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio.")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }

        [NotMapped]
        public decimal Debito
        {
            get
            {
                try
                {
                    return Importe * Cotizacion_Origen / Cotizacion_Destino;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
