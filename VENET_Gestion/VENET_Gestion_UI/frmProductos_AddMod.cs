namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductos_AddMod : MultiForm, IDisposable
    {
        private ProductosManager manager;

        public frmProductos_AddMod(Productos o)
        {
            InitializeComponent();
            manager = new ProductosManager(o);
        }

        private void frmProductos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                id_EspecieLookUpEdit.Properties.DataSource = Sistema.EspeciesTodas;
                id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
                id_EspecieLookUpEdit.Properties.ValueMember = "Key";

                id_EspecieOrigLookUpEdit.Properties.DataSource = Sistema.EspeciesTodas;
                id_EspecieOrigLookUpEdit.Properties.DisplayMember = "Name";
                id_EspecieOrigLookUpEdit.Properties.ValueMember = "Key";

                id_CategoriaLookUpEdit.Properties.DataSource = manager.Categorias;
                id_CategoriaLookUpEdit.Properties.DisplayMember = "Name";
                id_CategoriaLookUpEdit.Properties.ValueMember = "Key";

                id_Categoria2LookUpEdit.Properties.DataSource = manager.Categorias2;
                id_Categoria2LookUpEdit.Properties.DisplayMember = "Name";
                id_Categoria2LookUpEdit.Properties.ValueMember = "Key";

                id_IvaAlicuotaLookUpEdit.Properties.DataSource = manager.Alicuotas;
                id_IvaAlicuotaLookUpEdit.Properties.DisplayMember = "Name";
                id_IvaAlicuotaLookUpEdit.Properties.ValueMember = "Key";

                id_UnidadVentaLookUpEdit.Properties.DataSource = manager.UnidadesVenta;
                id_UnidadVentaLookUpEdit.Properties.DisplayMember = "Name";
                id_UnidadVentaLookUpEdit.Properties.ValueMember = "Key";

                id_UnidadCompraLookUpEdit.Properties.DataSource = manager.UnidadesVenta;
                id_UnidadCompraLookUpEdit.Properties.DisplayMember = "Name";
                id_UnidadCompraLookUpEdit.Properties.ValueMember = "Key";

                id_UnidadStockLookUpEdit.Properties.DataSource = manager.UnidadesVenta;
                id_UnidadStockLookUpEdit.Properties.DisplayMember = "Name";
                id_UnidadStockLookUpEdit.Properties.ValueMember = "Key";

                productosManagerBindingSource.DataSource = manager;

                if (manager.Producto.Id > 0)
                    importeCostoTextEdit.Text = manager.EspecieSigla + " " + manager.Producto.ImporteCosto.ToString();

                //if (Sistema.Especies.Count > 0)
                //{
                //    id_EspecieLookUpEdit.ItemIndex = 0;
                //    manager.Producto.Id_Especie = (int)id_EspecieLookUpEdit.EditValue;
                //}
                //else
                //{
                //    Sistema.Mensaje("El usuario no posee especies asignadas.");
                //    Close();
                //}

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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }


    }
}
