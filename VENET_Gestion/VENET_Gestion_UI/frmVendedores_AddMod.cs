namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmVendedores_AddMod : MultiForm, IDisposable
    {
        private VendedoresManager manager;

        public frmVendedores_AddMod(Vendedores o)
        {
            InitializeComponent();
            manager = new VendedoresManager(o);
        }

        private void frmVendedores_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                id_TipoIVALookUpEdit.Properties.DataSource = Sistema.TiposIva;
                id_TipoIVALookUpEdit.Properties.DisplayMember = "Name";
                id_TipoIVALookUpEdit.Properties.ValueMember = "Key";

                //codPosLookUpEdit.Properties.DataSource = manager.CP;
                //codPosLookUpEdit.Properties.DisplayMember = "Name3";
                //codPosLookUpEdit.Properties.ValueMember = "Key";

                codPosLookUpEdit.Properties.DataSource = Sistema.CodPostal;
                codPosLookUpEdit.Properties.DisplayMember = "Descripcion";
                codPosLookUpEdit.Properties.ValueMember = "Id";

                vendedoresManagerBindingSource.DataSource = manager;
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void frmVendedores_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
    }
}
