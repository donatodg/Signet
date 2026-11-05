namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductosMovimientos : MultiForm
    {
        private ProductosMovimientosManager.ParametrosBusquedas par = new ProductosMovimientosManager.ParametrosBusquedas();

        public frmProductosMovimientos()
        {
            InitializeComponent();
        }

        private void frmProductosMovimientos_Load(object sender, EventArgs e)
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

            productosMovimientosManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosMovimientos", Enums.Accion.Buscar)) return;
                Validate();
                productosMovimientosManager_SearchResultBindingSource.DataSource = new ProductosMovimientosManager().Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosMovimientos", Enums.Accion.Imprimir)) return;
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

        private void productosMovimientosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosMovimientosManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosMovimientos", Enums.Accion.Ver, "Comprobante")) return;

                if (productosMovimientosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProductosMovimientosManager.SearchResult)productosMovimientosManager_SearchResultBindingSource.Current;

                    if (curr.Tipo == "Venta")
                    {
                        ComprobantesVentas o = new ComprobantesVentas() { Id = curr.Id_Comprobante };
                        frmComprobantesVentas_AddMod f = new frmComprobantesVentas_AddMod(o, curr.Comprobante);
                        f.ShowDialog(this);
                    }

                    if (curr.Tipo == "Compra")
                    {
                        ComprobantesCompras o = new ComprobantesCompras() { Id = curr.Id_Comprobante };
                        frmComprobantesCompras_AddMod f = new frmComprobantesCompras_AddMod(o, curr.Comprobante);
                        f.ShowDialog(this);
                    }

                }
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
