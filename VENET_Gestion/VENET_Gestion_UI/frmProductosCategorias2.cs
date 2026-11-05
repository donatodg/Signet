namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductosCategorias2 : MultiForm
    {
        ProductosCategorias2Manager.ParametrosBusquedas par = new ProductosCategorias2Manager.ParametrosBusquedas();

        public frmProductosCategorias2()
        {
            InitializeComponent();
        }

        private void frmProductosCategorias_Load(object sender, EventArgs e)
        {
            productosCategorias2Manager_ParametrosBusquedasBindingSource.DataSource = par;

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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias2", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void productosCategorias2Manager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosCategorias2Manager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias2", Enums.Accion.Buscar)) return;

                Validate();
                productosCategorias2Manager_SearchResultBindingSource.DataSource = ProductosCategorias2Manager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias2", Enums.Accion.Agregar)) return;

            ProductosCategorias2 o = new ProductosCategorias2();
            var f = new frmProductosCategorias2_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                productosCategorias2Manager_SearchResultBindingSource.Add(ProductosCategorias2Manager.Buscar(new ProductosCategorias2Manager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias2", Enums.Accion.Modificar)) return;

                if (productosCategorias2Manager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProductosCategorias2Manager.SearchResult)productosCategorias2Manager_SearchResultBindingSource.Current;
                    var f = new frmProductosCategorias2_AddMod(new ProductosCategorias2() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        productosCategorias2Manager_SearchResultBindingSource[productosCategorias2Manager_SearchResultBindingSource.Position] = ProductosCategorias2Manager.Buscar(new ProductosCategorias2Manager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        productosCategorias2Manager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCategorias2", Enums.Accion.Eliminar)) return;

                if (productosCategorias2Manager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProductosCategorias2Manager.Eliminar(new ProductosCategorias2() { Id = ((ProductosCategorias2Manager.SearchResult)productosCategorias2Manager_SearchResultBindingSource.Current).Id });
                    productosCategorias2Manager_SearchResultBindingSource.RemoveCurrent();
                    productosCategorias2Manager_SearchResultBindingSource.ResetBindings(false);
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
