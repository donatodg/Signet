namespace VENET_Gestion_UI
{
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraSplashScreen;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;
    using VENET_Gestion_Reports;

    public partial class frmProductosListasPrecios : MultiForm
    {
        ProductosListasPreciosManager.ParametrosBusquedas par = new ProductosListasPreciosManager.ParametrosBusquedas();

        public frmProductosListasPrecios()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                productosListasPreciosManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosListasPrecios", Enums.Accion.Imprimir)) return;
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

        private void productosListasPreciosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + productosListasPreciosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosListasPrecios", Enums.Accion.Buscar)) return;

                Validate();
                productosListasPreciosManager_SearchResultBindingSource.DataSource = ProductosListasPreciosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosListasPrecios", Enums.Accion.Agregar)) return;

            ProductosListasPrecios o = new ProductosListasPrecios();
            var f = new frmProductosListasPrecios_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                productosListasPreciosManager_SearchResultBindingSource.Add(ProductosListasPreciosManager.Buscar(new ProductosListasPreciosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosListasPrecios", Enums.Accion.Modificar)) return;

                if (productosListasPreciosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProductosListasPreciosManager.SearchResult)productosListasPreciosManager_SearchResultBindingSource.Current;
                    var f = new frmProductosListasPrecios_AddMod(new ProductosListasPrecios() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        productosListasPreciosManager_SearchResultBindingSource[productosListasPreciosManager_SearchResultBindingSource.Position] = ProductosListasPreciosManager.Buscar(new ProductosListasPreciosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        productosListasPreciosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosListasPrecios", Enums.Accion.Eliminar)) return;

                if (productosListasPreciosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProductosListasPreciosManager.Eliminar(new ProductosListasPrecios() { Id = ((ProductosListasPreciosManager.SearchResult)productosListasPreciosManager_SearchResultBindingSource.Current).Id });
                    productosListasPreciosManager_SearchResultBindingSource.RemoveCurrent();
                    productosListasPreciosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnDetalle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosListasPrecios", Enums.Accion.Modificar)) return;

                if (productosListasPreciosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProductosListasPreciosManager.SearchResult)productosListasPreciosManager_SearchResultBindingSource.Current;
                    var f = new frmProductosListasPreciosDetalle(curr.Id);
                    f.ShowDialog(this);
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

        private void btnActualizaPrecioProducto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProductosListasPrecios", Enums.Accion.Operaciones, "Actualizar Precios Productos desde Lista de Precio")) return;

                if (productosListasPreciosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Actualizar los Precios de los Productos con los de la Lista de Precio seleccionada?", "Atención..."))
                {
                    var curr = (ProductosListasPreciosManager.SearchResult)productosListasPreciosManager_SearchResultBindingSource.Current;

                    ProductosListasPreciosManager.ActualizarImporteProductosSegunLista(curr.Id);
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

        private void btnReporteListaPrecio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProductosListasPrecios", Enums.Accion.Imprimir, "Reporte de Lista de Precio")) return;

                if (productosListasPreciosManager_SearchResultBindingSource.Current == null) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                var curr = (ProductosListasPreciosManager.SearchResult)productosListasPreciosManager_SearchResultBindingSource.Current;


                XtraReport report = new XtraReport();

                try
                {
                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + "ListaPrecios.repx");
                }
                catch
                {
                    report = new xrptListaPrecios();
                }

                report.DataSource = ProductosListasPreciosManager.ImprimeComprobante(curr.Id);

                report.ShowPreview();

                SplashScreenManager.CloseForm(false);
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

        private void btnListaPorCategoria_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProductosListasPrecios", Enums.Accion.Imprimir, "Reporte de Lista de Precio por Categoría")) return;

                if (productosListasPreciosManager_SearchResultBindingSource.Current == null) return;

                frmProductosListasPreciosImprimir f = new frmProductosListasPreciosImprimir();
                if (f.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                var curr = (ProductosListasPreciosManager.SearchResult)productosListasPreciosManager_SearchResultBindingSource.Current;

                XtraReport report = new XtraReport();
                try
                {
                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + "ListaPrecios.repx");
                }
                catch
                {
                    report = new xrptListaPrecios();
                }

                report.DataSource = ProductosListasPreciosManager.ImprimeComprobante(curr.Id, f.Categorias);

                report.ShowPreview();

                SplashScreenManager.CloseForm(false);

                if (f.Mails.Count() > 0)
                {
                    string Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + "Lista_Precios" + "-" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".pdf";
                    if (!System.IO.File.Exists(Archivo))
                        report.ExportToPdf(Archivo);

                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Enviando Emails");

                    foreach (string Recipiente in f.Mails)
                        Sistema.EnvioMail(Archivo, "Lista de Precios", "", Recipiente);

                    SplashScreenManager.CloseForm(false);
                }
                f.Dispose();
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
