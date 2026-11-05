namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;
    
    public partial class frmEspecies_AddMod : MultiForm, IDisposable
    {
        private EspeciesManager manager;
    
        public frmEspecies_AddMod(Especies o)
        {
            InitializeComponent();
            manager = new EspeciesManager(o);
        }

        private void frmEspecies_AddMod_Load(object sender, EventArgs e)
        {
            especiesManagerBindingSource.DataSource = manager;
            //if (manager.Especie.Id != 0)
            //    cotizacionSpinEdit.Enabled = false;
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

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void especiesManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError( e.Exception);
        }

        private void frmEspecies_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
    }
}
