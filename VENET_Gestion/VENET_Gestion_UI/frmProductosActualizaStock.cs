namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using DevExpress.XtraSplashScreen;
    using VENET_Gestion_BL;

    public partial class frmProductosActualizaStock : MultiForm
    {
        private List<int> _ListProductos = new List<int>();
        private int _Id_Deposito;
        public decimal _CantidadActual;
        public List<decimal> _ListaStockInicialNuevo = new List<decimal>();

        public frmProductosActualizaStock(List<int> ListProductos, int Id_Deposito)
        {
            InitializeComponent();
            _ListProductos = ListProductos;
            _Id_Deposito = Id_Deposito;
        }

        private void frmProductosActualizaStock_Load(object sender, EventArgs e)
        {
            txtCantidadActual.EditValue = 0;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                Validate();
                _CantidadActual = Convert.ToDecimal(txtCantidadActual.EditValue);

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Actualizando Stock");

                foreach (int i in _ListProductos)
                    _ListaStockInicialNuevo.Add(ProductosActualizaStockManager.ActualizarStock(i, _Id_Deposito, _CantidadActual));

                SplashScreenManager.CloseForm(false);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }

        private void txtCantidadActual_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Guardar();
        }

    }
}
