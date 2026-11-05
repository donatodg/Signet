namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmProductosStock : MultiForm
    {
        private ProductosStockManager.ParametrosBusquedas par = new ProductosStockManager.ParametrosBusquedas();
        private int? _Id_Deposito;

        public frmProductosStock()
        {
            InitializeComponent();
        }

        private void frmProductosStock_Load(object sender, EventArgs e)
        {
            FiltroBusquedaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ProductosFiltroBusquedas));
            FiltroBusquedaLookUpEdit.Properties.DisplayMember = "Value";
            FiltroBusquedaLookUpEdit.Properties.ValueMember = "Key";

            id_ProductoLookUpEdit.Properties.DataSource = par.Productos;
            id_ProductoLookUpEdit.Properties.ValueMember = "Id";

            id_DepositoLookUpEdit.Properties.DataSource = Sistema.Depositos;
            id_DepositoLookUpEdit.Properties.DisplayMember = "Name";
            id_DepositoLookUpEdit.Properties.ValueMember = "Key";

            FiltroBusquedaLookUpEdit.ItemIndex = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.GestionBusquedaProductosDefecto)) - 1;

            productosStock_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosStock", Enums.Accion.Buscar)) return;
                Validate();
                productosStock_SearchResultBindingSource.DataSource = new ProductosStockManager().Buscar(par);
                _Id_Deposito = par.Id_Deposito;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosStock", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void productosStock_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosStock_SearchResultBindingSource.Count.ToString();
        }

        private void FiltroBusquedaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            id_ProductoLookUpEdit.Properties.DisplayMember = FiltroBusquedaLookUpEdit.EditValue.ToString();
        }

        private void btnActualizaStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_Id_Deposito == null)
                {
                    Sistema.Mensaje("Debe seleccionar un depósito.");
                    return;
                }
                List<int> ListaProductos = gridView1.GetSelectedRows().ToList().Select(x => ((ProductosStockManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList();
                frmProductosActualizaStock f = new frmProductosActualizaStock(ListaProductos, _Id_Deposito.Value);

                int row = 0;
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    foreach (int i in gridView1.GetSelectedRows())
                    {
                        ((ProductosStockManager.SearchResult)gridView1.GetRow(i)).StockInicial = f._ListaStockInicialNuevo[row];
                        row += 1;
                    }

                gridView1.RefreshData();
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
