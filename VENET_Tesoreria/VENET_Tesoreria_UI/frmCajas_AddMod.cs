namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmCajas_AddMod : MultiForm, IDisposable
    {
        private CajasManager manager;

        public frmCajas_AddMod(Cajas o)
        {
            InitializeComponent();
            manager = new CajasManager(o);
        }

        private void frmCajas_AddMod_Load(object sender, EventArgs e)
        {
            id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
            id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
            id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

            id_EspecieLookUpEdit.Properties.DataSource = Sistema.EspeciesTodas;
            id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
            id_EspecieLookUpEdit.Properties.ValueMember = "Key";

            cajasManagerBindingSource.DataSource = manager;
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

        private void frmCajas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
    }
}
