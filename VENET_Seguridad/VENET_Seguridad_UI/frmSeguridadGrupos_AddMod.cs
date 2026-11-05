namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadGrupos_AddMod : MultiForm, IDisposable
    {
        private SeguridadGruposManager manager;

        public frmSeguridadGrupos_AddMod(SeguridadGrupos o)
        {
            InitializeComponent();
            manager = new SeguridadGruposManager(o);
        }

        private void frmSeguridadGrupos_AddMod_Load(object sender, EventArgs e)
        {
            seguridadGruposManagerBindingSource.DataSource = manager;
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

        private void frmSeguridadGrupos_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
    }
}
