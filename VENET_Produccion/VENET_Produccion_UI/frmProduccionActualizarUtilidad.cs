namespace VENET_Produccion_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Produccion_BL;

    public partial class frmProduccionActualizarUtilidad : MultiForm
    {
        private ProduccionActualizarUtilidadManager manager;

        public frmProduccionActualizarUtilidad(int Id_ListaPrecio)
        {
            InitializeComponent();
            manager = new ProduccionActualizarUtilidadManager(Id_ListaPrecio);
        }

        private void frmProduccionActualizarUtilidad_Load(object sender, EventArgs e)
        {
            try
            {
                produccionActualizarUtilidadManagerBindingSource.DataSource = manager;

                id_LineaLookUpEdit.Properties.DataSource = manager.Lineas;
                id_LineaLookUpEdit.Properties.DisplayMember = "Name";
                id_LineaLookUpEdit.Properties.ValueMember = "Key";

                id_VarianteLookUpEdit.Properties.DisplayMember = "Name";
                id_VarianteLookUpEdit.Properties.ValueMember = "Key";

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

        private void frmProduccionActualizarUtilidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void id_LineaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (manager != null && id_LineaLookUpEdit.ItemIndex != -1)
                {
                    manager.Id_Linea = (int)id_LineaLookUpEdit.EditValue;
                    id_VarianteLookUpEdit.Properties.DataSource = manager.Variantes;
                    id_VarianteLookUpEdit.EditValue = manager.Id_Variante = manager.Variantes.ElementAt(0).Key;
                }
            }
            catch (ValidationException exv)
            {
                id_VarianteLookUpEdit.Properties.DataSource = null;
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
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
