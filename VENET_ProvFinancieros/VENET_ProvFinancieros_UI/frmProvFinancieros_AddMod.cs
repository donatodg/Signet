namespace VENET_ProvFinancieros_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_ProvFinancieros_BL;

    public partial class frmProvFinancieros_AddMod : MultiForm, IDisposable
    {
        private ProvFinancierosManager manager;

        public frmProvFinancieros_AddMod()
        {
            InitializeComponent();
            manager = new ProvFinancierosManager(new ProvFinancieros() { Id = Convert.ToInt32(ConfigurationManager.AppSettings["ParametroId"]) });
        }

        public frmProvFinancieros_AddMod(ProvFinancieros o)
        {
            InitializeComponent();
            manager = new ProvFinancierosManager(o);
        }

        private void frmProvFinancieros_AddMod_Load(object sender, EventArgs e)
        {
            id_CodPostalLookUpEdit.Properties.DataSource = Sistema.CodPostal;
            id_CodPostalLookUpEdit.Properties.ValueMember = "Id";
            id_CodPostalLookUpEdit.Properties.DisplayMember = "Descripcion";

            id_TipoIvaLookUpEdit.Properties.DataSource = Sistema.TiposIva;
            id_TipoIvaLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoIvaLookUpEdit.Properties.ValueMember = "Key";

            ProvFinancierosManagerBindingSource.DataSource = manager;
        }

        private void frmProvFinancieros_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
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
                ConfigurationManager.AppSettings["RetornoId"] = manager.ProvFinancieros.Id.ToString();
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

        private void ProvFinancierosManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError(e.Exception);
        }

    }
}