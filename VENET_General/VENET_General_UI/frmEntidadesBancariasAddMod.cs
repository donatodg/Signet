namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmEntidadesBancariasAddMod : MultiForm, IDisposable
    {
        private EntidadesBancariasManager manager;

        public frmEntidadesBancariasAddMod(EntidadesBancarias o)
        {
            InitializeComponent();
            manager = new EntidadesBancariasManager(o);
        }

        private void frmEntidadesBancariasAddMod_Load(object sender, EventArgs e)
        {
            entidadesBancariasManagerBindingSource.DataSource = manager;
            if (manager.Entidad.Codigo > 0) codigoTextEdit.Enabled = false;
        }

        private void frmEntidadesBancariasAddMod_FormClosing(object sender, FormClosingEventArgs e)
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
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                    Sistema.Mensaje("El código ingresado ya existe.");
                else
                    Sistema.MensajeError(e);
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

    }
}
