namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Linq;
    using System.Windows.Forms;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;
    using VENET_Tesoreria_BL;
    using VENET_Tesoreria_UI;
    using DevExpress.XtraReports.UI;
    using VENET_General_UI;

    public partial class frmComprobantesVentas : MultiForm
    {
        private ComprobantesVentasManager.ParametrosBusquedas par = new ComprobantesVentasManager.ParametrosBusquedas();
        //private short CantCopias = 1;

        public frmComprobantesVentas()
        {
            InitializeComponent();
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
        }

        private void frmComprobantesVentas_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVentas_ImprimirRemito)))
                    btnRemito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVentas_ConfirmaParcial)))
                    btnConfirmarParcial.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaImagenes_ComprobanteVentas)))
                    btnImagenes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobanteVentas;
                id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";
                id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";

                tipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
                tipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
                tipoEntidadLookUpEdit.Properties.ValueMember = "Key";

                id_EntidadLookUpEdit.Properties.DataSource = par.Entidades;
                id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
                id_EntidadLookUpEdit.Properties.ValueMember = "Key";

                id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
                id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
                id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

                comprobantesVentasManager_ParametrosBusquedasBindingSource.DataSource = par;

                //if (Sistema.Sucursales.Count() > 0)
                //{
                //    id_SucursalLookUpEdit.ItemIndex = 0;
                //    par.Id_Sucursal = (int)id_SucursalLookUpEdit.EditValue;
                //}

                if (Sistema.TipoComprobanteVentas.Count() > 0)
                {
                    id_TipoComprobanteLookUpEdit.ItemIndex = 0;
                    par.Id_TipoComprobante = (int)id_TipoComprobanteLookUpEdit.EditValue;
                }
                else
                {
                    Sistema.Mensaje("No hay declarados comprobantes de Ventas.");
                    return;
                }

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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void comprobantesVentasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + comprobantesVentasManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Buscar)) return;
                Validate();
                comprobantesVentasManager_SearchResultBindingSource.DataSource = ComprobantesVentasManager.Buscar(par);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Agregar)) return;

                if (Convert.ToInt32(par.Id_Sucursal) == 0)
                {
                    Sistema.Mensaje("Debe seleccionar una Sucursal.");
                    return;
                }
                ComprobantesVentas o = new ComprobantesVentas() { Id_Sucursal = par.Id_Sucursal, Id_TipoComprobante = par.Id_TipoComprobante };
                var f = new frmComprobantesVentas_AddMod(o, id_TipoComprobanteLookUpEdit.Text);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    //if (1 == 1)
                    //    Confirmar(o.Id);

                    comprobantesVentasManager_SearchResultBindingSource.Add(ComprobantesVentasManager.Buscar(new ComprobantesVentasManager.ParametrosBusquedas() { Id = o.Id, Id_Sucursal = o.Id_Sucursal, Id_TipoComprobante = o.Id_TipoComprobante }).FirstOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Modificar)) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current;
                    var f = new frmComprobantesVentas_AddMod(new ComprobantesVentas() { Id = curr.Id }, id_TipoComprobanteLookUpEdit.Text);
                    //var f = new frmComprobantesVentas_AddMod(new ComprobantesVentas() { Id = curr.Id, Id_Entidad = curr.Id_Entidad });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        comprobantesVentasManager_SearchResultBindingSource[comprobantesVentasManager_SearchResultBindingSource.Position] = ComprobantesVentasManager.Buscar(new ComprobantesVentasManager.ParametrosBusquedas() { Id = curr.Id, Id_Sucursal = curr.Id_Sucursal, Id_TipoComprobante = curr.Id_TipoComprobante }).FirstOrDefault();
                        comprobantesVentasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Eliminar)) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ComprobantesVentasManager.Eliminar(new ComprobantesVentas() { Id = ((ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current).Id });
                    comprobantesVentasManager_SearchResultBindingSource.RemoveCurrent();
                    comprobantesVentasManager_SearchResultBindingSource.ResetBindings(false);
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
                id_EntidadLookUpEdit.EditValue = par.Id_Entidad = null;
            }
        }

        private void Confirmar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Confirmar Comprobante de Venta")) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {

                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Confirmando Comprobante");

                    var curr = (ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current;
                    //string r = new ComprobantesVentasManager().Confirmar(new ComprobantesVentas() { Id = curr.Id });
                    string r = ComprobantesVentasManager.Confirmar(new ComprobantesVentas() { Id = curr.Id });

                    SplashScreenManager.CloseForm(false);

                    if (r != "" && r!= null) Sistema.Mensaje(r);

                    comprobantesVentasManager_SearchResultBindingSource[comprobantesVentasManager_SearchResultBindingSource.Position] = ComprobantesVentasManager.Buscar(new ComprobantesVentasManager.ParametrosBusquedas() { Id = curr.Id, Id_Sucursal = curr.Id_Sucursal, Id_TipoComprobante = curr.Id_TipoComprobante }).FirstOrDefault();
                    comprobantesVentasManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void Confirmar(int Id)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Confirmar Comprobante de Venta")) return;
                string r = ComprobantesVentasManager.Confirmar(new ComprobantesVentas() { Id = Id });
                if (r != "") Sistema.Mensaje(r);
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

        private void ConfirmarParcial()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Confirmar parcialmente Comprobante de Venta")) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    var curr = (ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current;
                    frmComprobantesVentasConfirmacionParcial f = new frmComprobantesVentasConfirmacionParcial(curr.Id);
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        string r = ComprobantesVentasManager.ConfirmarParcialmente(new ComprobantesVentas() { Id = curr.Id }, f.ListaAProcesar, f.TodoProcesado);

                        if (r != "") Sistema.Mensaje(r);

                        comprobantesVentasManager_SearchResultBindingSource[comprobantesVentasManager_SearchResultBindingSource.Position] = ComprobantesVentasManager.Buscar(new ComprobantesVentasManager.ParametrosBusquedas() { Id = curr.Id, Id_Sucursal = curr.Id_Sucursal, Id_TipoComprobante = curr.Id_TipoComprobante }).FirstOrDefault();
                        comprobantesVentasManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void Anular()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Anular Comprobante de Venta")) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

                if (((ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current).FechaAnulacion != null) throw new ValidationException("El comprobante ya se encuentra anulada.");

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        var curr = (ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current;
                        string r = ComprobantesVentasManager.Anular(new ComprobantesVentas() { Id = curr.Id }, f.result);

                        if (r != "") Sistema.Mensaje(r);

                        comprobantesVentasManager_SearchResultBindingSource[comprobantesVentasManager_SearchResultBindingSource.Position] = ComprobantesVentasManager.Buscar(new ComprobantesVentasManager.ParametrosBusquedas() { Id = curr.Id, Id_Sucursal = curr.Id_Sucursal, Id_TipoComprobante = curr.Id_TipoComprobante }).FirstOrDefault();
                        comprobantesVentasManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void tipoEntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (tipoEntidadLookUpEdit.ItemIndex != -1)
            {
                par.TipoEntidad = (Enums.TipoEntidad)tipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = par.Entidades;
                id_EntidadLookUpEdit.EditValue = par.Id_Entidad = null;
            }
            if (par.TipoEntidad == null)
                id_EntidadLookUpEdit.EditValue = par.Id_Entidad = null;
        }

        private void btnComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Imprimir, "Imprimir Comprobante")) return;

            if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

            foreach (int x in gridView1.GetSelectedRows())
                //Imprime(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, false, false);
                new frmEntidadesCtaCte().ImprimeComprobanteVentas(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, false, false);
        }

        private void btnConfirmar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           Confirmar();
        }

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Anular();
        }

        //public void Imprime(int Id_Comprobante, bool GeneraPDF, bool EnviarMail, int Copias = 0)
        //{
        //    try
        //    {
        //        if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ComprobantesVentas", Enums.Accion.Imprimir, "Imprimir Comprobantes de Ventas")) return;

        //        string TC = "";
        //        string Archivo = "";

        //        SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
        //        SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
        //        SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

        //        ComprobantesVentas cv = new ComprobantesVentas() { Id = Id_Comprobante };

        //        XtraReport report = new XtraReport();

        //        TalonariosComprobantes r = ComprobantesVentasManager.Reporte(cv);

        //        if (r.Reporte == "<Ninguno>")
        //            report = new xrptComprobanteVenta();
        //        else
        //            report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //        var ListDatasource = ComprobantesVentasManager.ImprimeComprobante(cv);

        //        if (ListDatasource[0].FechaLiquidacion == null && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
        //            throw new ValidationException("Antes de imprimir el comprobante debe liquidarlo.");

        //        report.DataSource = ListDatasource;

        //        if (GeneraPDF || EnviarMail)
        //        {
        //            TC = TipoComprobanteManager.ObtenerTipoComprobante(cv.Id_TipoComprobante);
        //            Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + TC + "-" + cv.Comprobante + ".pdf";
        //            report.ExportToPdf(Archivo);
        //        }
        //        else
        //        {
        //            if (r.Impresora == "")
        //            {
        //                using (ReportPrintTool printTool = new ReportPrintTool(report))
        //                {
        //                    SplashScreenManager.CloseForm(false);
        //                    printTool.ShowRibbonPreviewDialog();
        //                }
        //            }
        //            else
        //            {
        //                if (Copias > 0) r.Copias = Copias;

        //                switch (Convert.ToInt16(r.Copias))
        //                {
        //                    case 0:
        //                    case 1:
        //                        {
        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
        //                            //report.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
        //                            report.Print(r.Impresora);
        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);
        //                            break;
        //                        }
        //                    case 3:
        //                        {
        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "TRIPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            break;
        //                        }
        //                    case 4:
        //                        {
        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "TRIPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "CUADRUPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            break;
        //                        }
        //                    case 5:
        //                        {
        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "TRIPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "CUADRUPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            report = new XtraReport();
        //                            if (r.Reporte == "<Ninguno>")
        //                                report = new xrptComprobanteVenta();
        //                            else
        //                                report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

        //                            report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "QUINTUPLICADO"; return t; })).ToList();
        //                            report.Print(r.Impresora);

        //                            break;
        //                        }
        //                }
        //            }
        //        }

        //        report = null;

        //        if (EnviarMail)
        //        {
        //            string Recipiente = ComprobantesVentasManager.ObtenerMail(cv.Id_TipoEntidad, cv.Id_Entidad.Value);
        //            if (Recipiente == "" || Recipiente == null) throw new ValidationException("La entidad no posee un mail cargado.");

        //            Sistema.EnvioMail(Archivo, "Comprobante " + TC + cv.Comprobante, "Este es un mail automático enviado por la aplicación.", Recipiente);
        //        }

        //        SplashScreenManager.CloseForm(false);
        //    }
        //    catch (ValidationException exv)
        //    {
        //        SplashScreenManager.CloseForm(false);
        //        Sistema.Mensaje(exv.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        SplashScreenManager.CloseForm(false);
        //        Sistema.MensajeError(ex);
        //    }
        //}

        //private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        //{
        //    if (CantCopias == 0)
        //        CantCopias = 1;

        //    e.PrintDocument.PrinterSettings.Copies = CantCopias;
        //}

        private void btnGeneraRecibo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Generar Recibo")) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

                var curr = (ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current;

                if (!TipoComprobanteManager.GeneraDeuda(curr.Id_TipoComprobante)) throw new ValidationException("El comprobante no genera deuda y no se puede asignar un recibo.");

                if (curr.FechaAnulacion != null) throw new ValidationException("El comprobante se encuentra anulado.");
                if (curr.FechaLiquidacion == null) throw new ValidationException("El comprobante se encuentra pendiente.");

                decimal ImportePago = ComprobantesVentasManager.GetImportePagoComprobante(curr.Id);

                if (ImportePago >= curr.Importe) throw new ValidationException("El comprobante ya se ha abonado.");

                if (Sistema.MensajeSiNo("¿Desea Generar el Recibo del Item Seleccionado?", "Atención..."))
                {
                    Recibos o = new Recibos()
                    {
                        Id = 0,
                        Concepto = ComprobantesComprasManager.GetNombreComprobante(curr.Id_TipoComprobante) + " " + curr.Comprobante,
                        Fecha = Sistema.ObtenerFecha(),
                        Id_Entidad = curr.Id_Entidad,
                        Id_CentroCosto = curr.Id_CentroCosto,
                        Id_Sucursal = curr.Id_Sucursal,
                        TipoEntidad = curr.Id_TipoEntidad,
                        //Observaciones = "Importe: " + curr.Importe_Pesos.ToString("n")
                        Observaciones = "-",
                        Comprobantes = new List<RecibosComprobantes>(),
                        Detalle = new List<RecibosDetalle>(),
                        Importe = curr.Importe.Value - ImportePago
                    };

                    RecibosManager rm = new RecibosManager(o);

                    RecibosComprobantes x = new RecibosComprobantes()
                    {
                        Borrado = false,
                        Fecha = curr.Fecha,
                        FechaAdd = Sistema.ObtenerFechaHora(),
                        UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),

                        Id_ComprobantesVentas = curr.Id,
                        ImporteAdeudado = curr.Importe.Value - ImportePago,
                        ImportePago = curr.Importe.Value - ImportePago,
                        Comprobante = curr.Comprobante,
                    };
                    rm.Recibo.Comprobantes.Add(x);

                    frmRecibos_AddMod f = new frmRecibos_AddMod(rm);
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Operaciones, "Confirmar Recibo")) return;

                        if (Sistema.MensajeSiNo("¿Desea confirmar el recibo ingresado?", "Confirmar") == true)
                        {
                            RecibosManager.Confirmar(o);
                        }
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

        private void btnPresentar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Presentar Comprobantes")) return;

                new frmComprobantesVentasPresentacion().ShowDialog(this);
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

        private void btnGeneraPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Generar PDF")) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

                foreach (int x in gridView1.GetSelectedRows())
                    //Imprime(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, true, false);
                    new frmEntidadesCtaCte().ImprimeComprobanteVentas(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, true, false);

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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Enviar por Mail")) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

                foreach (int x in gridView1.GetSelectedRows())
                    //Imprime(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, false, true);
                    new frmEntidadesCtaCte().ImprimeComprobanteVentas(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, false, true);
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

        private void btnReporteCompleto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Ver, "Reporte Completo")) return;

                new frmComprobantesVentas_ReporteCompleto().ShowDialog(this);
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

        private void btnConfirmarParcial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConfirmarParcial();
        }

        private void btnPorTriplicado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Imprimir, "Imprimir Comprobante")) return;

            if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

            foreach (int x in gridView1.GetSelectedRows())
                //Imprime(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, false, false, 3);
                new frmEntidadesCtaCte().ImprimeComprobanteVentas(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, false, false, 3);
        }

        private void btnCtaCteEntidad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Ver, "Cuenta Corriente de la Entidad")) return;

            if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

            var curr = (ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current;

            frmEntidadesCtaCte f = new frmEntidadesCtaCte(curr.Id_TipoEntidad, Convert.ToInt32(curr.Id_Entidad), true);
            f.ShowDialog(this);
        }

        private void btnRemito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ComprobantesVentas", Enums.Accion.Imprimir, "Imprimir Comprobantes de Ventas")) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                foreach (int x in gridView1.GetSelectedRows())
                {
                    ComprobantesVentas cv = new ComprobantesVentas() { Id = ((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id };

                    XtraReport report = new XtraReport();

                    TalonariosComprobantes r = ComprobantesVentasManager.Reporte(cv);

  
                    var ListDatasource = ComprobantesVentasManager.ImprimeComprobante(cv);
                   
                    if (ListDatasource[0].FechaLiquidacion == null && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
                        throw new ValidationException("Antes de imprimir el comprobante debe liquidarlo.");

                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + Parametro.ObtenerValor(Parametro.Param.Ventas_NombreRemito));
                    report.DataSource = ListDatasource;

                    if (r.Impresora == "" || !(System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<String>()).Contains(r.Impresora))
                    {
                        using (ReportPrintTool printTool = new ReportPrintTool(report))
                        {
                            SplashScreenManager.CloseForm(false);
                            printTool.ShowRibbonPreviewDialog();
                        }
                    }
                    else
                    {
                        switch (Convert.ToInt16(Parametro.ObtenerValor(Parametro.Param.ComprobantesVentasRemito_ImprimirCopias)))
                        {
                            case 0:
                            case 1:
                                {
                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
                                    report.Print(r.Impresora);
                                    break;
                                }
                            case 2:
                                {
                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + "Remito.repx");

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);
                                    break;
                                }
                            case 3:
                                {
                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + "Remito.repx");

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + "Remito.repx");

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "TRIPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    break;
                                }
                        }
                    }
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

        private void btnComprobanteDuplicado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Imprimir, "Imprimir Comprobante")) return;

            if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

            foreach (int x in gridView1.GetSelectedRows())
                //Imprime(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, false, false, 3);
                new frmEntidadesCtaCte().ImprimeComprobanteVentas(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, false, false, 1, "DUPLICADO");
        }

        private void btnDescuento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Cargar Descuento")) return;

                var curr = (ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current;
                if (curr == null) return;
                if (curr.FechaLiquidacion != null) throw new ValidationException("No se puede modificar porque ya se encuentra confirmado.");

                frmPorcentajeDescuento f = new frmPorcentajeDescuento();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ComprobantesVentas c = new ComprobantesVentas() { Id = curr.Id };
                    ComprobantesVentasManager manager = new ComprobantesVentasManager(c);
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

        private void btnComprobantePantalla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Imprimir, "Imprimir Comprobante")) return;

            if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

            foreach (int x in gridView1.GetSelectedRows())
                new frmEntidadesCtaCte().ImprimeComprobanteVentas(((ComprobantesVentasManager.SearchResult)gridView1.GetRow(x)).Id, false, false, 0, "", true);

        }

        private void btnImagenes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Ver Imagenes")) return;

                var curr = (ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current;
                if (curr == null) return;

                frmImagenes f = new frmImagenes("ComprobantesVentas", curr.Id);
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

        private void btnDuplicar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Duplica Comprobante de Venta")) return;

                if (comprobantesVentasManager_SearchResultBindingSource.Current == null) return;

                frmDuplicaComprobante f = new frmDuplicaComprobante();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    int Id = ComprobantesVentasManager.DuplicarVenta(new ComprobantesVentas() { Id = ((ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current).Id }, f.Id_Comprobante, f.Id_TipoEntidad, f.Id_Entidad);
                    Sistema.Mensaje("Se creó el comprobante " + f.Tipo_Comprobante + " - Id " + Id, "Nuevo Comprobante");
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

        private void btnAsociarComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Operaciones, "Asociar Comprobante de Venta")) return;

                var curr = (ComprobantesVentasManager.SearchResult)comprobantesVentasManager_SearchResultBindingSource.Current;
                if (curr == null) return;

                frmComprobanteVentaAsociado f = new frmComprobanteVentaAsociado(curr.Id);
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

        private void btnIvaVentas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas", Enums.Accion.Ver, "Iva Ventas")) return;

                new frmComprobantesVentas_IvaVentas().ShowDialog(this);
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
