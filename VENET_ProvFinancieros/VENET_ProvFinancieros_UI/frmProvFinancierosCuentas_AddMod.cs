namespace VENET_ProvFinancieros_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_ProvFinancieros_BL;
    
    public partial class frmProvFinancierosCuentas_AddMod : MultiForm, IDisposable
    {
        private ProvFinancierosCuentasManager manager;

        public frmProvFinancierosCuentas_AddMod(ProvFinancierosCuentas o)
        {
            InitializeComponent();
            manager = new ProvFinancierosCuentasManager(o);
        }

        private void frmProvFinancierosCuentas_AddMod_Load(object sender, EventArgs e)
        {
            id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
            id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
            id_EspecieLookUpEdit.Properties.ValueMember = "Key";

            id_EntidadBancariaLookUpEdit.Properties.DataSource = manager.Entidades;
            id_EntidadBancariaLookUpEdit.Properties.DisplayMember = "Name";
            id_EntidadBancariaLookUpEdit.Properties.ValueMember = "Key";

            provFinancierosCuentasManagerBindingSource.DataSource = manager;
       
            if (Sistema.Especies.Count > 0)
            {
                id_EspecieLookUpEdit.ItemIndex = 0;
            }
            else
            {
                Sistema.Mensaje("El usuario no posee especies asignadas.");
                Close();
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void frmProvFinancierosCuentas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

    }
}
