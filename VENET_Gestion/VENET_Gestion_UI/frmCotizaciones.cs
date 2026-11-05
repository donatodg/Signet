namespace VENET_Gestion_UI
{
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraSplashScreen;
    using VENET_General_UI;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;
    using VENET_Gestion_Reports;
    using VENET_Tesoreria_BL;

    public partial class frmCotizaciones : MultiForm
    {
        private CotizacionesManager.ParametrosBusquedas par = new CotizacionesManager.ParametrosBusquedas();

        public frmCotizaciones()
        {
            InitializeComponent();
        }

        private void frmCotizaciones_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Cotizaciones_GeneraPedido)))
                    btnGeneraVenta.Caption = "Genera Pedido";

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaImagenes_Cotizaciones)))
                    btnImagenes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                   
                id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
                id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
                id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

                cotizacionesManager_ParametrosBusquedasBindingSource.DataSource = par;

                Validate();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Imprimir)) return;
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

        private void btnImprimeComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cotizacionesManager_SearchResultBindingSource.Current == null) return;
            Imprime(((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id, false, false);
        }

        public void Imprime(int Id_Cotizacion, bool GeneraPDF, bool EnviarMail)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Imprimir, "Imprimir Cotizaciones")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                string TC = "";
                string Archivo = "";

                Cotizaciones o = new Cotizaciones() { Id = Id_Cotizacion };

                XtraReport report = new XtraReport();

                TalonariosComprobantes r = CotizacionesManager.Reporte(o);

                if (r.Reporte == "<Ninguno>")
                    report = new xrptCotizacion();
                else
                {
                    if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaReporte_B)) && !CotizacionesManager.EntidadResponsableInscripto(o))
                    {
                        string Reporte = r.Reporte.Split('.')[0] + "B." + r.Reporte.Split('.')[1];
                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + Reporte);
                    }
                    else
                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);
                }

                var ListDatasource = CotizacionesManager.ImprimeComprobante(o);

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeCotizacionesSinLiquidar)))
                    if (ListDatasource[0].Registro.Fecha_Liquidacion == null && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
                        throw new ValidationException("Antes debe confirmar el comprobante.");

                report.DataSource = ListDatasource;

                if (GeneraPDF || EnviarMail)
                {
                    TC = TipoComprobanteManager.ObtenerTipoComprobante(11);
                    Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + TC + "-" + o.Comprobante + "-" + ListDatasource[0].Entidad.Nombre + ".pdf";
                    report.ExportToPdf(Archivo);
                }
                else
                {
                    if (r.Impresora == "" || !(System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<String>()).Contains(r.Impresora))
                    {
                        using (ReportPrintTool printTool = new ReportPrintTool(report))
                        {
                            SplashScreenManager.CloseForm(false);
                            printTool.ShowRibbonPreviewDialog();
                        }
                    }
                    else
                        for (int i = 0; i < Convert.ToInt16(r.Copias); i++)
                            report.Print(r.Impresora);
                }

                report = null;

                if (EnviarMail)
                {
                    string Recipiente = ComprobantesVentasManager.ObtenerMail(o.Id_TipoEntidad, o.Id_Entidad.Value);
                    if (Recipiente == "" || Recipiente == null) throw new ValidationException("La entidad no posee un mail cargado.");

                    Sistema.EnvioMail(Archivo, "Comprobante " + TC + o.Comprobante, "", Recipiente);
                }

                SplashScreenManager.CloseForm(false);

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

        private void cotizacionesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + cotizacionesManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Buscar)) return;
                Validate();
                cotizacionesManager_SearchResultBindingSource.DataSource = CotizacionesManager.Buscar(par);
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
            try
            {
                Validate();
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Agregar)) return;

                if (Convert.ToInt32(par.Id_Sucursal) == 0)
                {
                    Sistema.Mensaje("Debe seleccionar una Sucursal.");
                    return;
                }
                Cotizaciones o = new Cotizaciones() { Id_Sucursal = par.Id_Sucursal };
                var f = new frmCotizaciones_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    cotizacionesManager_SearchResultBindingSource.Add(CotizacionesManager.Buscar(new CotizacionesManager.ParametrosBusquedas() { Id = o.Id, Id_Sucursal = o.Id_Sucursal }).FirstOrDefault());
                }
                f.Dispose();
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

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Modificar)) return;

                if (cotizacionesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current;
                    var f = new frmCotizaciones_AddMod(new Cotizaciones() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        cotizacionesManager_SearchResultBindingSource[cotizacionesManager_SearchResultBindingSource.Position] = CotizacionesManager.Buscar(new CotizacionesManager.ParametrosBusquedas() { Id = curr.Id, Id_Sucursal = curr.Id_Sucursal }).FirstOrDefault();
                        cotizacionesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Eliminar)) return;

                if (cotizacionesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    CotizacionesManager.Eliminar(new Cotizaciones() { Id = ((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id });
                    cotizacionesManager_SearchResultBindingSource.RemoveCurrent();
                    cotizacionesManager_SearchResultBindingSource.ResetBindings(false);
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
            }
        }

        private void btnConfirmar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Cotizaciones", Enums.Accion.Operaciones, "Confirmar Cotizaciones")) return;

                if (cotizacionesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    CotizacionesManager.Confirmar(new Cotizaciones() { Id = ((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id });

                    cotizacionesManager_SearchResultBindingSource[cotizacionesManager_SearchResultBindingSource.Position] = CotizacionesManager.Buscar(new CotizacionesManager.ParametrosBusquedas() { Id = ((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id, Id_Sucursal = ((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id_Sucursal }).FirstOrDefault();
                    cotizacionesManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Cotizaciones", Enums.Accion.Operaciones, "Anular Cotizaciones")) return;

                if (cotizacionesManager_SearchResultBindingSource.Current == null) return;

                if (((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Fecha_Anulacion != null) throw new ValidationException("La cotización ya se encuentra anulada.");

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        CotizacionesManager.Anular(new Cotizaciones() { Id = ((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id }, f.result);

                        cotizacionesManager_SearchResultBindingSource[cotizacionesManager_SearchResultBindingSource.Position] = CotizacionesManager.Buscar(new CotizacionesManager.ParametrosBusquedas() { Id = ((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id, Id_Sucursal = ((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id_Sucursal }).FirstOrDefault();
                        cotizacionesManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnGeneraPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Operaciones, "Generar PDF")) return;

                if (cotizacionesManager_SearchResultBindingSource.Current == null) return;

                foreach (int x in gridView1.GetSelectedRows())
                    Imprime(((CotizacionesManager.SearchResult)gridView1.GetRow(x)).Id, true, false);

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

        private void btnEnviarMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Operaciones, "Enviar por Mail")) return;

                if (cotizacionesManager_SearchResultBindingSource.Current == null) return;

                foreach (int x in gridView1.GetSelectedRows())
                    Imprime(((CotizacionesManager.SearchResult)gridView1.GetRow(x)).Id, false, true);
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

        private void btnGeneraVenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Operaciones, "Genera Comprobante de Venta")) return;

                if (cotizacionesManager_SearchResultBindingSource.Current == null) return;

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Cotizaciones_GeneraPedido)))
                {
                    int Id = CotizacionesManager.GenerarPedido(new Cotizaciones() { Id = ((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id });
                    Sistema.Mensaje("Se creó el comprobante Pedido - Id " + Id, "Nuevo Comprobante");
                }
                else
                {
                    frmCotizacionesComprobante f = new frmCotizacionesComprobante();
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        int Id = CotizacionesManager.GenerarVenta(new Cotizaciones() { Id = ((CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current).Id }, f.Id_Comprobante);
                        Sistema.Mensaje("Se creó el comprobante " + f.Tipo_Comprobante + " - Id " + Id, "Nuevo Comprobante");
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

        private void btnVerCtaCte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Ver, "Cuenta Corriente de la Entidad")) return;

            if (cotizacionesManager_SearchResultBindingSource.Current == null) return;

            var curr = (CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current;

            VENET_Tesoreria_UI.frmEntidadesCtaCte f = new VENET_Tesoreria_UI.frmEntidadesCtaCte(curr.Id_TipoEntidad, Convert.ToInt32(curr.Id_Entidad), true);
            f.ShowDialog(this);
        }

        private void btnDescuento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Operaciones, "Cargar Descuento")) return;

                var curr = (CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current;
                if (curr == null) return;
                if (curr.Fecha_Liquidacion != null) throw new ValidationException("No se puede modificar porque ya se encuentra confirmado.");

                frmPorcentajeDescuento f = new frmPorcentajeDescuento();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Cotizaciones c = new Cotizaciones() { Id = curr.Id };
                    CotizacionesManager manager = new CotizacionesManager(c);
                    manager.ActualizaDescuento(f.Porcentaje);
                    manager.Save();
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

        private void btnImagenes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones", Enums.Accion.Operaciones, "Ver Imagenes")) return;

                var curr = (CotizacionesManager.SearchResult)cotizacionesManager_SearchResultBindingSource.Current;
                if (curr == null) return;

                frmImagenes f = new frmImagenes("Cotizaciones", curr.Id);
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

    }
}
