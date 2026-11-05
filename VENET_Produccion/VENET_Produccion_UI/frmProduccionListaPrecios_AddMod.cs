namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Produccion_BL;
    using DevExpress.XtraSplashScreen;

    public partial class frmProduccionListaPrecios_AddMod : MultiForm
    {
        private ProduccionListaPreciosManager manager;
        private decimal Utilidad;

        public frmProduccionListaPrecios_AddMod(Produccion_ListaPrecios o)
        {
            InitializeComponent();
            manager = new ProduccionListaPreciosManager(o);
        }

        private void frmProduccionListaPrecios_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                produccionListaPreciosManagerBindingSource.DataSource = manager;

                if (manager.Lista.Id > 0)
                {
                    id_EmpresaLookUpEdit.Enabled = false;
                    Utilidad = manager.Lista.Utilidad;
                }
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
                SplashScreenManager.Default.SetWaitFormDescription("Generando Lista de Precios");

                Validate();

                bool ActualizaUtilidad = false;

                if (manager.Lista.Id > 0 && (Utilidad != manager.Lista.Utilidad))
                    ActualizaUtilidad = true;

                manager.Save(ActualizaUtilidad);
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void frmProduccionListaPrecios_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void vigenteHastaDateEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }

    }
}
