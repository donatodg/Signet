namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionLineas_AddMod : MultiForm
    {
        private ProduccionLineasManager manager;

        public frmProduccionLineas_AddMod(Produccion_Lineas o)
        {
            InitializeComponent();
            manager = new ProduccionLineasManager(o);
        }

        private void frmProduccionLineas_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                produccionLineasManagerBindingSource.DataSource = manager;

                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                if (id_EmpresaLookUpEdit.ItemIndex < 0)
                {
                    id_EmpresaLookUpEdit.ItemIndex = 0;
                    manager.Linea.Id_Empresa = Convert.ToInt32(id_EmpresaLookUpEdit.EditValue);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void frmProduccionLineas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void codigoTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
