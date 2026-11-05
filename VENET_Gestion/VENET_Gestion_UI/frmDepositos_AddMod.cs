namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmDepositos_AddMod : MultiForm
    {
        private DepositosManager manager;

        public frmDepositos_AddMod(Depositos o)
        {
            InitializeComponent();
            manager = new DepositosManager(o);
        }

        private void frmDepositos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                depositosManagerBindingSource.DataSource = manager;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
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
                manager.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }
    }
}
