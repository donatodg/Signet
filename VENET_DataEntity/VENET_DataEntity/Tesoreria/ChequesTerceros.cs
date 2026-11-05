namespace VENET_DataEntity
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VENET_Comun;

    [Table("ChequesTerceros")]
    public class ChequesTerceros : ClaseBase, INotifyPropertyChanged
    {
        [Range(1, 2147483647, ErrorMessage = "El valor para sucursal es obligatorio.")]
        public int Id_Sucursal { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para banco es obligatorio.")]
        private int _Id_EntidadBancaria;
        public int Id_EntidadBancaria
        {
            get
            { return _Id_EntidadBancaria; }
            set
            {
                if (value != _Id_EntidadBancaria)
                {
                    _Id_EntidadBancaria = value;
                    RaisePropertyChanged("Id_EntidadBancaria");
                }
            }
        }

        [Range(1, 999, ErrorMessage = "El valor para sucursal es obligatorio.")]
        private int? _Sucursal;
        public int? Sucursal
        {
            get { return _Sucursal; }
            set
            {
                if (value != _Sucursal)
                {
                    _Sucursal = value;
                    RaisePropertyChanged("Sucursal");
                }
            }
        }
        [Range(1, 9999, ErrorMessage = "El valor para cod. postal es obligatorio.")]
        private int? _CodPostal;
        public int? CodPostal
        {
            get { return _CodPostal; }
            set
            {
                if (value != _CodPostal)
                {
                    _CodPostal = value;
                    RaisePropertyChanged("CodPostal");
                }
            }
        }
        [Range(1, 99999999, ErrorMessage = "El valor para nro. de cheque es obligatorio.")]
        private int? _NroCheque;
        public int? NroCheque
        {
            get
            { return _NroCheque; }
            set
            {
                if (value != _NroCheque)
                {
                    _NroCheque = value;
                    RaisePropertyChanged("NroCheque");
                }
            }
        }
        [Range(1, 99999999999, ErrorMessage = "El valor para nro. de cuenta es obligatorio.")]
        public long? _NroCta;
        public long? NroCta
        {
            get
            { return _NroCta; }
            set
            {
                if (value != _NroCta)
                {
                    _NroCta = value;
                    RaisePropertyChanged("NroCta");
                }
            }
        }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de emisión es obligatoria.")]
        public DateTime FechaEmision { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de pago es obligatoria.")]
        private DateTime _FechaPago;
        public DateTime FechaPago
        {
            get { return _FechaPago; }
            set
            {
                if (value != _FechaPago)
                {
                    _FechaPago = value;
                    RaisePropertyChanged("FechaPago");
                }
            }
        }
        [Range(1, 2147483647, ErrorMessage = "El valor para especie es obligatorio.")]
        public int Id_Especie { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para importe es obligatorio.")]
        public decimal Importe { get; set; }
        [Range(1, 2147483647, ErrorMessage = "El valor para firmante es obligatorio.")]
        public int Id_Firmante { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para tipo entidad es obligatorio.")]
        //public Enums.TipoEntidad? TipoEntidad { get; set; }
        //[Range(1, 2147483647, ErrorMessage = "El valor para entidad es obligatorio.")]
        //public int? Id_Entidad { get; set; }
        public int? Id_Recibo { get; set; }
        public int? Id_OrdenPago { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de depósito es obligatoria.")]
        public DateTime FechaDeposito { get; set; }
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "La fecha de acreditación es obligatoria.")]
        public DateTime FechaAcreditacion { get; set; }
        public bool ALaOrden { get; set; }
        public DateTime? FechaDepositado { get; set; }
        public DateTime? FechaAcreditado { get; set; }
        public DateTime? FechaRechazado { get; set; }
        [StringLength(50)]
        public string MotivoRechazo { get; set; }
        public decimal? ImporteRechazo { get; set; }
        public DateTime? FechaDescuento { get; set; }
        public int? Id_Descuento { get; set; }
        public int? Id_BoletaDeposito { get; set; }

        [NotMapped]
        public string CodigoBarra { get { return string.Format("{0:000}{1:000}{2:0000}{3:00000000}{4:00000000000}", Id_EntidadBancaria, Sucursal, _CodPostal, NroCheque, _NroCta); } }
        [NotMapped]
        public string CodigoBarraSinCuenta { get { return string.Format("{0:000}{1:000}{2:0000}{3:00000000}{4:00000000000}", Id_EntidadBancaria, Sucursal, _CodPostal, NroCheque, 0); } }
        [NotMapped]
        public string Banco { get; set; }


        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }
}
