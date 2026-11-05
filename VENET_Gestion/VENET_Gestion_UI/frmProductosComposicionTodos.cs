namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmProductosComposicionTodos : MultiForm
    {
        ProductosComposicionTodosManager.ParametrosBusquedas par = new ProductosComposicionTodosManager.ParametrosBusquedas();

        public frmProductosComposicionTodos()
        {
            InitializeComponent();
        }

        private void frmProductosComposicionTodos_Load(object sender, EventArgs e)
        {
            try
            {
                FiltroBusquedaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ProductosFiltroBusquedas));
                FiltroBusquedaLookUpEdit.Properties.DisplayMember = "Value";
                FiltroBusquedaLookUpEdit.Properties.ValueMember = "Key";

                id_ProductoLookUpEdit.Properties.DataSource = par.Productos;
                id_ProductoLookUpEdit.Properties.ValueMember = "Id";

                FiltroBusquedaLookUpEdit.ItemIndex = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.GestionBusquedaProductosDefecto)) - 1;

                productosComposicionTodosManager_ParametrosBusquedasBindingSource.DataSource = par;
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

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosComposicionTodos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void FiltroBusquedaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            id_ProductoLookUpEdit.Properties.DisplayMember = FiltroBusquedaLookUpEdit.EditValue.ToString();
        }

        private void productosComposicionTodosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosComposicionTodosManager_SearchResultBindingSource.Count.ToString();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosComposicionTodos", Enums.Accion.Buscar)) return;
                Validate();
                productosComposicionTodosManager_SearchResultBindingSource.DataSource = ProductosComposicionTodosManager.Buscar(par);
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


    }
}
