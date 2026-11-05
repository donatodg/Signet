namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionManoDeObra_AddMod : MultiForm
    {
        private ProduccionManoDeObraManager manager;
        decimal ValorHora;

        public frmProduccionManoDeObra_AddMod(Produccion_ManoDeObra o)
        {
            InitializeComponent();
            manager = new ProduccionManoDeObraManager(o);
        }

        private void frmManoDeObra_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                produccionManoDeObraManagerBindingSource.DataSource = manager;
                ValorHora = manager.ManoDeObra.PrecioHora;
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
                bool RegistraHistorial = false;

                if (ValorHora != manager.ManoDeObra.PrecioHora)
                    RegistraHistorial = true;

                manager.Save(RegistraHistorial);
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void precioHoraTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }

        private void frmProduccionManoDeObra_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

    }
}
