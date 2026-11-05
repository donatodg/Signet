namespace VENET_Gestion_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductosDerivados : MultiForm
    {
        ProductosDerivadosManager.ParametrosBusquedas par = new ProductosDerivadosManager.ParametrosBusquedas();

        public frmProductosDerivados()
        {
            InitializeComponent();
        }

        private void frmProductosDerivados_Load(object sender, EventArgs e)
        {
            productosDerivadosManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosDerivados", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void productosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosDerivadosManager_SearchResultBindingSource.Count.ToString();
        }
        
        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosDerivados", Enums.Accion.Buscar)) return;

                Validate();
                productosDerivadosManager_SearchResultBindingSource.DataSource = ProductosDerivadosManager.Buscar(par);
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

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosDerivados", Enums.Accion.Agregar)) return;

            ProductosDerivados o = new ProductosDerivados();
            var f = new frmProductosDerivados_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                productosDerivadosManager_SearchResultBindingSource.Add(ProductosDerivadosManager.Buscar(new ProductosDerivadosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosDerivados", Enums.Accion.Modificar)) return;

                if (productosDerivadosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProductosDerivadosManager.SearchResult)productosDerivadosManager_SearchResultBindingSource.Current;
                    var f = new frmProductosDerivados_AddMod(new ProductosDerivados() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        productosDerivadosManager_SearchResultBindingSource[productosDerivadosManager_SearchResultBindingSource.Position] = ProductosDerivadosManager.Buscar(new ProductosDerivadosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        productosDerivadosManager_SearchResultBindingSource.ResetCurrentItem();
                    }
                    f.Dispose();
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

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosDerivados", Enums.Accion.Eliminar)) return;

                if (productosDerivadosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProductosDerivadosManager.Eliminar(new ProductosDerivados() { Id = ((ProductosDerivadosManager.SearchResult)productosDerivadosManager_SearchResultBindingSource.Current).Id });
                    productosDerivadosManager_SearchResultBindingSource.RemoveCurrent();
                    productosDerivadosManager_SearchResultBindingSource.ResetBindings(false);
                }
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
