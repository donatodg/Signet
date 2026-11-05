namespace VENET_Gestion_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Gestion_BL;

    public partial class frmPedidosEstadosPersonal : MultiForm
    {
        PedidosEstadosManager manager;
        int _Id_Pedido;

        public frmPedidosEstadosPersonal(int Id_Pedido)
        {
            InitializeComponent();
            _Id_Pedido = Id_Pedido;
            manager = new PedidosEstadosManager(Id_Pedido);
        }

        private void frmPedidosEstadosPersonal_Load(object sender, EventArgs e)
        {
            lookUpEditPersonal1.Properties.DataSource = manager.Personal;
            lookUpEditPersonal1.Properties.DisplayMember = "Descripcion";
            lookUpEditPersonal1.Properties.ValueMember = "Id";

            lookUpEditPersonal2.Properties.DataSource = manager.Personal;
            lookUpEditPersonal2.Properties.DisplayMember = "Descripcion";
            lookUpEditPersonal2.Properties.ValueMember = "Id";

            lookUpEditPersonal3.Properties.DataSource = manager.Personal;
            lookUpEditPersonal3.Properties.DisplayMember = "Descripcion";
            lookUpEditPersonal3.Properties.ValueMember = "Id";
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                PedidosEstadosManager.AsignaPersonal(_Id_Pedido, Convert.ToInt32(lookUpEditPersonal1.EditValue), Convert.ToInt32(lookUpEditPersonal2.EditValue), Convert.ToInt32(lookUpEditPersonal3.EditValue));
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

    }
}
