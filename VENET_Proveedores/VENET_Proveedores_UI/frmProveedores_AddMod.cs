namespace VENET_Proveedores_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Proveedores_BL;

    public partial class frmProveedores_AddMod : MultiForm, IDisposable
    {
        private ProveedoresManager manager;

        public frmProveedores_AddMod()
        {
            InitializeComponent();
            manager = new ProveedoresManager(new Proveedores() { Id = Convert.ToInt32(ConfigurationManager.AppSettings["ParametroId"]) });
        }

        public frmProveedores_AddMod(Proveedores o)
        {
            InitializeComponent();
            manager = new ProveedoresManager(o);
        }

        private void frmProveedores_AddMod_Load(object sender, EventArgs e)
        {
            id_CodPostalLookUpEdit.Properties.DataSource = Sistema.CodPostal;
            id_CodPostalLookUpEdit.Properties.ValueMember = "Id";
            id_CodPostalLookUpEdit.Properties.DisplayMember = "Descripcion";

            id_TipoIvaLookUpEdit.Properties.DataSource = Sistema.TiposIva;
            id_TipoIvaLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoIvaLookUpEdit.Properties.ValueMember = "Key";

            id_ListaPrecioLookUpEdit.Properties.DataSource = manager.ListasPrecios;
            id_ListaPrecioLookUpEdit.Properties.DisplayMember = "Name";
            id_ListaPrecioLookUpEdit.Properties.ValueMember = "Key";

            ProveedoresManagerBindingSource.DataSource = manager;
        }

        private void frmProveedores_AddMod_FormClosing(object sender, FormClosingEventArgs e)
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
                ConfigurationManager.AppSettings["RetornoId"] = manager.Proveedores.Id.ToString();
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

        private void ProveedoresManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError(e.Exception);
        }

        private void btnGeneraCUIT_Click(object sender, EventArgs e)
        {
            try
            {
                frmGeneraCuit f = new frmGeneraCuit();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    manager.Proveedores.Cuit = f.Cuit;
                    cuitTextEdit.EditValue = manager.Proveedores.Cuit;
                }
                f.Dispose();
                Validate();
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

        private void id_ListaPrecioLookUpEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }
    }
}