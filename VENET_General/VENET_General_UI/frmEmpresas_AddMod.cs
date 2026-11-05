namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmEmpresas_AddMod : MultiForm, IDisposable
    {
        private EmpresasManager manager;

        public frmEmpresas_AddMod(Empresas o)
        {
            InitializeComponent();
            manager = new EmpresasManager(o);
        }

        private void frmEmpresas_AddMod_Load(object sender, EventArgs e)
        {
            codPostalLookUpEdit.Properties.DataSource = Sistema.CodPostal;
            codPostalLookUpEdit.Properties.ValueMember = "Id";
            codPostalLookUpEdit.Properties.DisplayMember = "Descripcion";

            id_TipoIvaLookUpEdit.Properties.DataSource = Sistema.TiposIva;
            id_TipoIvaLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoIvaLookUpEdit.Properties.ValueMember = "Key";

            empresasManagerBindingSource.DataSource = manager;
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
                Sistema.MensajeError( ex);
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

        private void frmEmpresas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void codPostalLookUpEdit_Enter(object sender, EventArgs e)
        {
            codPostalLookUpEdit.SelectAll();
        }
    }
}
