namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmImpuestosAlicuotas_AddMod : MultiForm
    {
        private ImpuestosAlicuotasManager manager;

        public frmImpuestosAlicuotas_AddMod(ImpuestosAlicuotas o)
        {
            InitializeComponent();
            manager = new ImpuestosAlicuotasManager(o);
        }

        private void frmImpuestosAlicuotas_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                id_ProvinciaLookUpEdit.Properties.DataSource = Sistema.Provincias;
                id_ProvinciaLookUpEdit.Properties.DisplayMember = "Name";
                id_ProvinciaLookUpEdit.Properties.ValueMember = "Key";

                impuestosAlicuotasManagerBindingSource.DataSource = manager;
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }
    }
}
