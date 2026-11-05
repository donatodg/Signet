namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmProductosHistorialPrecios : MultiForm
    {
        private ProductosHistorialPreciosManager.ParametrosBusquedas par = new ProductosHistorialPreciosManager.ParametrosBusquedas();

        public frmProductosHistorialPrecios()
        {
            InitializeComponent();
        }

        private void frmProductosHistorialPrecios_Load(object sender, EventArgs e)
        {
            FiltroBusquedaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ProductosFiltroBusquedas));
            FiltroBusquedaLookUpEdit.Properties.DisplayMember = "Value";
            FiltroBusquedaLookUpEdit.Properties.ValueMember = "Key";

            id_ProductoLookUpEdit.Properties.DataSource = par.Productos;
            id_ProductoLookUpEdit.Properties.ValueMember = "Id";

            FiltroBusquedaLookUpEdit.ItemIndex = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.GestionBusquedaProductosDefecto)) - 1;

            productosHistorialPreciosManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosHistorialPrecios", Enums.Accion.Buscar)) return;
                Validate();
                productosHistorialPreciosManager_SearchResultBindingSource.DataSource = ProductosHistorialPreciosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosHistorialPrecios", Enums.Accion.Imprimir)) return;
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

        private void productosHistorialPreciosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosHistorialPreciosManager_SearchResultBindingSource.Count.ToString();
        }

    }
}
