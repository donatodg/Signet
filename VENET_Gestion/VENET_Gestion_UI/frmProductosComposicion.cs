namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductosComposicion : MultiForm
    {
        private ProductosComposicionManager manager;
        private int _Id_Producto;

        public frmProductosComposicion(int Id_Producto, string Producto)
        {
            InitializeComponent();
            _Id_Producto = Id_Producto;
            manager = new ProductosComposicionManager(_Id_Producto);
            Text = "Composición del Producto: " + Producto;
        }

        private void frmProductosComposicion_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosComposicion", Enums.Accion.Buscar)) return;

                Validate();
                composicionBindingSource.DataSource = manager.Buscar(0);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosComposicion", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosComposicion", Enums.Accion.Agregar)) return;

            ProductosComposicion o = new ProductosComposicion() { Id_ProductoFinal = _Id_Producto };
            var f = new frmProductosComposicion_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                composicionBindingSource.Add(manager.Buscar(o.Id).SingleOrDefault());

                ActualizaPrecioCostoProducto();
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosComposicion", Enums.Accion.Modificar)) return;

                if (composicionBindingSource.Current == null) return;
                {
                    var curr = (ProductosComposicionManager.SearchResult)composicionBindingSource.Current;
                    var f = new frmProductosComposicion_AddMod(new ProductosComposicion() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        composicionBindingSource[composicionBindingSource.Position] = manager.Buscar(curr.Id).SingleOrDefault();
                        composicionBindingSource.ResetCurrentItem();

                        ActualizaPrecioCostoProducto();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosComposicion", Enums.Accion.Eliminar)) return;

                if (composicionBindingSource.Current == null) return;
                {
                    var curr = (ProductosComposicionManager.SearchResult)composicionBindingSource.Current;

                    if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                    {
                        ProductosComposicion_AddModManager.Eliminar(new ProductosComposicion() { Id = curr.Id });
                        composicionBindingSource.RemoveCurrent();
                        composicionBindingSource.ResetBindings(false);

                        ActualizaPrecioCostoProducto();
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void composicionBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + composicionBindingSource.Count.ToString();
        }

        private void ActualizaPrecioCostoProducto()
        {
            try
            {
                ProductosComposicion_AddModManager.ActualizarCostoProducto(new Productos() { Id = _Id_Producto });
                //DialogResult = DialogResult.OK;
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

        private void frmProductosComposicion_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

    }
}
