namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmTipoImpuestos_AddMod : MultiForm, IDisposable
    {
        private TipoImpuestosManager manager;

        public frmTipoImpuestos_AddMod(TipoImpuestos o)
        {
            InitializeComponent();
            manager = new TipoImpuestosManager(o);
        }

        private void frmTipoImpuestos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                id_TipoImpuestoLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoImpuesto));
                id_TipoImpuestoLookUpEdit.Properties.DisplayMember = "Value";
                id_TipoImpuestoLookUpEdit.Properties.ValueMember = "Key";

                aplicaSobreLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.AplicaSobre));
                aplicaSobreLookUpEdit.Properties.DisplayMember = "Value";
                aplicaSobreLookUpEdit.Properties.ValueMember = "Key";

                id_AFIP_TributosLookUpEdit.Properties.DataSource = manager.AfipTributo;
                id_AFIP_TributosLookUpEdit.Properties.DisplayMember = "Name";
                id_AFIP_TributosLookUpEdit.Properties.ValueMember = "Key";

                tipoImpuestosManagerBindingSource.DataSource = manager;
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

        private void frmTipoImpuestos_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
      

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
            }
        }

    }
}
