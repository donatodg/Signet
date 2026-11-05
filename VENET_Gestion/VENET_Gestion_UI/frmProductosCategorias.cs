namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductosCategorias : MultiForm
    {
        ProductosCategoriasManager.ParametrosBusquedas par = new ProductosCategoriasManager.ParametrosBusquedas();

        public frmProductosCategorias()
        {
            InitializeComponent();
        }

        private void frmProductosCategorias_Load(object sender, EventArgs e)
        {
            productosCategoriasManager_ParametrosBusquedasBindingSource.DataSource = par;

        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void productosCategoriasManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosCategoriasManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias", Enums.Accion.Buscar)) return;

                Validate();
                productosCategoriasManager_SearchResultBindingSource.DataSource = ProductosCategoriasManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias", Enums.Accion.Agregar)) return;

            ProductosCategorias o = new ProductosCategorias();
            var f = new frmProductosCategorias_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                productosCategoriasManager_SearchResultBindingSource.Add(ProductosCategoriasManager.Buscar(new ProductosCategoriasManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias", Enums.Accion.Modificar)) return;

                if (productosCategoriasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProductosCategoriasManager.SearchResult)productosCategoriasManager_SearchResultBindingSource.Current;
                    var f = new frmProductosCategorias_AddMod(new ProductosCategorias() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        productosCategoriasManager_SearchResultBindingSource[productosCategoriasManager_SearchResultBindingSource.Position] = ProductosCategoriasManager.Buscar(new ProductosCategoriasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        productosCategoriasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias", Enums.Accion.Eliminar)) return;

                if (productosCategoriasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProductosCategoriasManager.Eliminar(new ProductosCategorias() { Id = ((ProductosCategoriasManager.SearchResult)productosCategoriasManager_SearchResultBindingSource.Current).Id });
                    productosCategoriasManager_SearchResultBindingSource.RemoveCurrent();
                    productosCategoriasManager_SearchResultBindingSource.ResetBindings(false);
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
