namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmLocalidades_AddMod : MultiForm, IDisposable
    {
        private LocalidadesManager manager;

        public frmLocalidades_AddMod(Localidades o)
        {
            InitializeComponent();
            manager = new LocalidadesManager(o);
        }
        private void frmLocalidades_AddMod_Load(object sender, EventArgs e)
        {
            localidadesManagerBindingSource.DataSource = manager;

            id_ProvinciaLookUpEdit.Properties.DataSource = Sistema.Provincias;
            id_ProvinciaLookUpEdit.Properties.ValueMember = "Key";
            id_ProvinciaLookUpEdit.Properties.DisplayMember = "Name";
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

        private void frmLocalidades_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
      
    }
}
