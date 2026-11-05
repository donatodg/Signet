namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductosDerivados_AddMod : MultiForm, IDisposable
    {
        private ProductosDerivadosManager manager;

        public frmProductosDerivados_AddMod(ProductosDerivados o)
        {
            InitializeComponent();
            manager = new ProductosDerivadosManager(o);
        }

        private void frmProductosDerivados_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                FiltroBusquedaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ProductosFiltroBusquedas));
                FiltroBusquedaLookUpEdit.Properties.DisplayMember = "Value";
                FiltroBusquedaLookUpEdit.Properties.ValueMember = "Key";

                id_ProductoLookUpEdit.Properties.DataSource = manager.Productos;
                id_ProductoLookUpEdit.Properties.ValueMember = "Id";

                id_CategoriaLookUpEdit.Properties.DataSource = manager.Categorias;
                id_CategoriaLookUpEdit.Properties.DisplayMember = "Name";
                id_CategoriaLookUpEdit.Properties.ValueMember = "Key";

                id_UnidadVentaLookUpEdit.Properties.DataSource = manager.UnidadesVenta;
                id_UnidadVentaLookUpEdit.Properties.DisplayMember = "Name";
                id_UnidadVentaLookUpEdit.Properties.ValueMember = "Key";

                productosDerivadosManagerBindingSource.DataSource = manager;

                FiltroBusquedaLookUpEdit.ItemIndex = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.GestionBusquedaProductosDefecto)) - 1;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void FiltroBusquedaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            id_ProductoLookUpEdit.Properties.DisplayMember = FiltroBusquedaLookUpEdit.EditValue.ToString();

            switch (FiltroBusquedaLookUpEdit.ItemIndex)
            {
                case 0:
                    id_ProductoLookUpEdit.Properties.Columns[1].Visible = true;
                    id_ProductoLookUpEdit.Properties.Columns[2].Visible = false;
                    id_ProductoLookUpEdit.Properties.Columns[3].Visible = false;
                    break;

                case 1:
                    id_ProductoLookUpEdit.Properties.Columns[1].Visible = false;
                    id_ProductoLookUpEdit.Properties.Columns[2].Visible = true;
                    id_ProductoLookUpEdit.Properties.Columns[3].Visible = false;
                    break;

                case 2:
                    id_ProductoLookUpEdit.Properties.Columns[1].Visible = false;
                    id_ProductoLookUpEdit.Properties.Columns[2].Visible = false;
                    id_ProductoLookUpEdit.Properties.Columns[3].Visible = true;
                    break;
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void equivalenciaTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }

    }
}
