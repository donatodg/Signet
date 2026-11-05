namespace VENET_Produccion_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Produccion_BL;

    public partial class frmProduccionVariantesActualizarUtilidad : MultiForm
    {
        private ProduccionVariantesActualizarUtilidadManager manager;

        public frmProduccionVariantesActualizarUtilidad()
        {
            InitializeComponent();
            manager = new ProduccionVariantesActualizarUtilidadManager(); 
        }

        private void frmProduccionVariantesActualizarUtilidad_Load(object sender, EventArgs e)
        {
            try
            {
                produccionVariantesActualizarUtilidadManagerBindingSource.DataSource = manager;

                //id_LineaLookUpEdit.Properties.DataSource = manager.Lineas;
                //id_LineaLookUpEdit.Properties.DisplayMember = "Name";
                //id_LineaLookUpEdit.Properties.ValueMember = "Key";

                id_LineaLookUpEdit.EditValue = manager.Id_Linea = manager.Lineas.ElementAt(0).Key;
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
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Actualizando Utilidad");

                Validate();

                manager.ActualizarUtilidadMasivo();

                SplashScreenManager.CloseForm(false);

                DialogResult = DialogResult.OK;
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

        private void utilidadTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }

        private void frmProduccionVariantesActualizarUtilidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

    }
}
