namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionMedidas_AddMod : MultiForm
    {
        private ProduccionMedidasManager manager;
        //bool UtilizaProfundidad;

        public frmProduccionMedidas_AddMod(Produccion_Medidas o)
        {
            InitializeComponent();
            manager = new ProduccionMedidasManager(o);
        }

        private void frmProduccionMedidas_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                produccionMedidasManagerBindingSource.DataSource = manager;
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

        private void largoTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!UtilizaProfundidad &&
            if (e.KeyChar == 13) Guardar();
        }

        private void profundoTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }

    }
}
