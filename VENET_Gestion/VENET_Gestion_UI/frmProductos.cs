namespace VENET_Gestion_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_UI;
    using VENET_Gestion_BL;

    public partial class frmProductos : MultiForm
    {
        ProductosManager.ParametrosBusquedas par = new ProductosManager.ParametrosBusquedas();

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaImagenes_Productos)))
                    btnImagenes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                productosManager_ParametrosBusquedasBindingSource.DataSource = par;
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

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Imprimir)) return;
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
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Buscar)) return;

                Validate();
                productosManager_SearchResultBindingSource.DataSource = ProductosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Agregar)) return;

            Productos o = new Productos();
            var f = new frmProductos_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                productosManager_SearchResultBindingSource.Add(ProductosManager.Buscar(new ProductosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Modificar)) return;

                if (productosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProductosManager.SearchResult)productosManager_SearchResultBindingSource.Current;
                    var f = new frmProductos_AddMod(new Productos() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        productosManager_SearchResultBindingSource[productosManager_SearchResultBindingSource.Position] = ProductosManager.Buscar(new ProductosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        productosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Eliminar)) return;

                if (productosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProductosManager.Eliminar(new Productos() { Id = ((ProductosManager.SearchResult)productosManager_SearchResultBindingSource.Current).Id });
                    productosManager_SearchResultBindingSource.RemoveCurrent();
                    productosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnHistorialPrecios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Ver Historial de Precios")) return;

                frmProductosHistorialPrecios f = new frmProductosHistorialPrecios();
                f.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Ver Stock de Productos")) return;

                frmProductosStock f = new frmProductosStock();
                f.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnMovimientos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Ver Movimientos de Productos")) return;

                frmProductosMovimientos f = new frmProductosMovimientos();
                f.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnListaPrecios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Ver Lista de Precios")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Reporte.");

                gridControl2.DataSource = ProductosManager.Buscar(new ProductosManager.ParametrosBusquedas() { OrdenadoPorIdCategoria = true });

                SplashScreenManager.CloseForm(false);

                gridControl2.ShowRibbonPrintPreview();
            }
            catch (Exception)
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnProductosSinVentas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Ver Productos sin ventas")) return;

                frmProductosSinMovimientos f = new frmProductosSinMovimientos();
                f.ShowDialog(this);

            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnctualizaPrecios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Actualización Masiva de Precios")) return;

                frmProductosActualizaPrecios f = new frmProductosActualizaPrecios();
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnComposicion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Composición del Producto")) return;

                if (productosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ProductosManager.SearchResult)productosManager_SearchResultBindingSource.Current;
                var f = new frmProductosComposicion(curr.Id, curr.Descripcion);
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    productosManager_SearchResultBindingSource[productosManager_SearchResultBindingSource.Position] = ProductosManager.Buscar(new ProductosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    productosManager_SearchResultBindingSource.ResetCurrentItem();
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnActualizacionCostos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Operaciones, "Actualización Masiva de Costos")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Actualizando Costos.");

                ProductosManager.ActualizacionCostos();

                Buscar();

                SplashScreenManager.CloseForm(false);

            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }

        private void btnComposicionTodos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Composición de todos los Productos")) return;

                new frmProductosComposicionTodos().ShowDialog();

            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnActualizaCostoCompra_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Actualización Masiva de Precios de Costo")) return;

                frmProductosActualizaPreciosCostos f = new frmProductosActualizaPreciosCostos();
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnImagenes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Ver, "Ver Imagenes")) return;

                var curr = (ProductosManager.SearchResult)productosManager_SearchResultBindingSource.Current;
                if (curr == null) return;

                frmImagenes f = new frmImagenes("Productos", curr.Id);
                f.ShowDialog();
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

        private void btnActualizaExcelVenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Operaciones, "Actualizar Precios Ventas con Excel")) return;

                OpenFileDialog ofd = new OpenFileDialog()
                {
                    FileName = "",
                    Filter = "Archivos Excel|*.xls;*.xlsx",
                    Title = "Abrir Excel Importe de Venta"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName;

                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Actualizando Importe Venta.");
                    
                    ProductosManager.ActualizardesdeExcel(path, true);

                    Buscar();

                    SplashScreenManager.CloseForm(false);
                }

            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false); 
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false); 
                Sistema.MensajeError(ex);
            }
        }

        private void btnActualizaExcelCosto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Operaciones, "Actualizar Precios Costos con Excel")) return;
                OpenFileDialog ofd = new OpenFileDialog()
                {
                    FileName = "",
                    Filter = "Archivos Excel|*.xls;*.xlsx",
                    Title = "Abrir Excel Importe de Costo"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName;

                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Actualizando Importe Costo.");

                    ProductosManager.ActualizardesdeExcel(path, false);

                    Buscar();

                    SplashScreenManager.CloseForm(false);
                }

            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }

        private void btnGenerarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Productos", Enums.Accion.Operaciones, "Generar Excel Modelo Precios")) return;

                SaveFileDialog ofd = new SaveFileDialog()
                {
                    FileName = "Precios_Actualizar.xlsx",
                    Filter = "Archivos Excel|*.xls;*.xlsx",
                    Title = "Guardar Excel Modelo Precios"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filename = ofd.FileName;

                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Generando Excel Modelo Precios.");

                    ProductosManager.GeneraExcelModelo(filename);

                    SplashScreenManager.CloseForm(false);
                }

            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }
    }
}
