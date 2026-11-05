namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmRendicionesDetalle_AddMod : MultiForm, IDisposable
    {
        private RendicionesDetalleManager manager;
        public RendicionesDetalle RendicionDetalle;

        public frmRendicionesDetalle_AddMod(RendicionesDetalle o)
        {
            InitializeComponent();
            RendicionDetalle = o;
            manager = new RendicionesDetalleManager(o);
        }

        private void frmRendicionesDetalle_AddMod_Load(object sender, EventArgs e)
        {
            rendicionesDetalleManagerBindingSource.DataSource = manager;
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

                manager.RendicionDetalle.Cuenta = id_CuentaLookUpEdit.Text;

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

        private void frmRendicionesDetalle_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void importeTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }
    }
}
