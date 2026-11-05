namespace VENET_Personal_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Personal_BL;

    public partial class frmPersonalTipos_AddMod : MultiForm, IDisposable
    {
        private PersonalTiposManager manager;

        protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 256)
            {
                if ((Keys)m.WParam == Keys.Escape) { Close(); }
                if ((Keys)m.WParam == Keys.Enter) { Guardar(); }
            }
            return base.ProcessKeyPreview(ref m);
        }

        public frmPersonalTipos_AddMod(PersonalTipos o)
        {
            InitializeComponent();
            manager = new PersonalTiposManager(o);
        }

        private void frmPersonalTipos_AddMod_Load(object sender, EventArgs e)
        {
            personalTiposManagerBindingSource.DataSource = manager;
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

        private void frmPersonalTipos_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

    }
}
