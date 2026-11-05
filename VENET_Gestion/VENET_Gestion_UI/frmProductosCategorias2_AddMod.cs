namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductosCategorias2_AddMod : MultiForm, IDisposable
    {
        private ProductosCategorias2Manager manager;

        public frmProductosCategorias2_AddMod(ProductosCategorias2 o)
        {
            InitializeComponent();
            manager = new ProductosCategorias2Manager(o);
        }

        private void frmProductosCategorias_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                productosCategorias2ManagerBindingSource.DataSource = manager;
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
    }
}
