namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmProductosSinMovimientos : MultiForm
    {
        ProductosSinMovimientosManager.ParametrosBusquedas par = new ProductosSinMovimientosManager.ParametrosBusquedas();

        public frmProductosSinMovimientos()
        {
            InitializeComponent();
        }

        private void frmProductosMovimientos_Load(object sender, EventArgs e)
        {
            try
            {
                par.FechaDesde = Sistema.ObtenerFecha().AddYears(-1);
                productosSinMovimientosManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosSinMovimientos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void productosMovimientosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosSinMovimientosManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();
                productosSinMovimientosManager_SearchResultBindingSource.DataSource = new ProductosSinMovimientosManager().Buscar(par);
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
