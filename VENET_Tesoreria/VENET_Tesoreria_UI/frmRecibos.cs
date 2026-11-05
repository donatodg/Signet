namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using DevExpress.XtraReports.UI;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;
    using VENET_Tesoreria_Reports;
    using DevExpress.XtraSplashScreen;
    using System.Collections.Generic;
    using VENET_Gestion_BL;

    public partial class frmRecibos : MultiForm
    {
        private RecibosManager.ParametrosBusquedas par = new RecibosManager.ParametrosBusquedas();

        public frmRecibos()
        {
            InitializeComponent();
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
        }

        private void frmRecibos_Load(object sender, EventArgs e)
        {
            tipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
            tipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
            tipoEntidadLookUpEdit.Properties.ValueMember = "Key";

            id_EntidadLookUpEdit.Properties.DataSource = par.Entidades;
            id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
            id_EntidadLookUpEdit.Properties.ValueMember = "Key";

            id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
            id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

            recibosManager_ParametrosBusquedasBindingSource.DataSource = par;

            if (Sistema.Sucursales.Count() > 0)
            {
                id_SucursalLookUpEdit.ItemIndex = 0;
                par.Id_Sucursal = (int)id_SucursalLookUpEdit.EditValue;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void recibosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + recibosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Buscar)) return;
                Validate();
                recibosManager_SearchResultBindingSource.DataSource = RecibosManager.Buscar(par);
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
            Validate();
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Agregar)) return;
            Recibos o = new Recibos() { Id_Sucursal = Convert.ToInt32(par.Id_Sucursal) };
            var f = new frmRecibos_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                recibosManager_SearchResultBindingSource.Add(RecibosManager.Buscar(new RecibosManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Modificar)) return;
                if (recibosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current;
                    var f = new frmRecibos_AddMod(new Recibos() { Id = curr.Id, Id_Entidad = curr.Id_Entidad });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        recibosManager_SearchResultBindingSource[recibosManager_SearchResultBindingSource.Position] = RecibosManager.Buscar(new RecibosManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        recibosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Eliminar)) return;
                if (recibosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    RecibosManager.Eliminar(new Recibos() { Id = ((RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current).Id });
                    recibosManager_SearchResultBindingSource.RemoveCurrent();
                    recibosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnConfirmar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Confirmar();
        }

        private void Confirmar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Operaciones, "Confirmar Recibo")) return;

                if (recibosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    RecibosManager.Confirmar(new Recibos() { Id = ((RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current).Id });

                    recibosManager_SearchResultBindingSource[recibosManager_SearchResultBindingSource.Position] = RecibosManager.Buscar(new RecibosManager.ParametrosBusquedas() { Id = ((RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                    recibosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
                id_EntidadLookUpEdit.EditValue = par.Id_Entidad = null;
            }
        }

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Anular();
        }

        private void Anular()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Operaciones, "Anular Recibo")) return;

                if (recibosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        RecibosManager.Anular(new Recibos() { Id = ((RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current).Id }, f.result);

                        recibosManager_SearchResultBindingSource[recibosManager_SearchResultBindingSource.Position] = RecibosManager.Buscar(new RecibosManager.ParametrosBusquedas() { Id = ((RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                        recibosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnImprimeRecibo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (recibosManager_SearchResultBindingSource.Current == null) return;
            Imprime(((RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current).Id);
        }

        public void Imprime(int Id_Recibo, bool EnviarMail = false, bool GeneraPDF = false)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Imprimir, "Imprimir Recibo")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                Recibos rec = new Recibos() { Id = Id_Recibo };

                XtraReport report = new XtraReport();

                TalonariosComprobantes r = RecibosManager.Reporte(rec);

                List<Reportes.RecibosReporte.DatosReporte> ListDatasource = RecibosManager.ImprimeRecibo(rec);

                if (r.Reporte == "<Ninguno>")
                    if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesDuplicadosPorHoja)))
                    {
                        xrptRecibo reportRec1 = new xrptRecibo();
                        reportRec1.DataSource = ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; }).ToList();
                        xrptRecibo reportRec2 = new xrptRecibo();
                        reportRec2.DataSource = RecibosManager.ImprimeRecibo(rec).Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; }).ToList(); ;

                        xrptDoblePorHoja reporte = new xrptDoblePorHoja();
                        reporte.xrSubreport1.ReportSource = reportRec1;
                        reporte.xrSubreport2.ReportSource = reportRec2;

                        report = reporte;
                    }
                    else
                        report = new xrptRecibo();
                else
                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                report.DataSource = ListDatasource;

                if (ListDatasource[0].Registro.Fecha_Liquidacion == null && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
                    throw new ValidationException("Antes de imprimir el comprobante debe liquidarlo.");

                if (EnviarMail || GeneraPDF)
                {
                    string Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + "REC-" + rec.NroComprobante + "-" + ListDatasource[0].Entidad.Nombre + ".pdf";
                    if (!System.IO.File.Exists(Archivo))
                        report.ExportToPdf(Archivo);

                    if (EnviarMail)
                    {
                        string Recipiente = ComprobantesVentasManager.ObtenerMail(rec.TipoEntidad, rec.Id_Entidad.Value);
                        if (Recipiente == "" || Recipiente == null) throw new ValidationException("La entidad no posee un mail cargado.");

                        Sistema.EnvioMail(Archivo, "Comprobante REC-" + rec.NroComprobante, "", Recipiente);
                    }
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

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modificar();
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

        private void btnAsignaCmp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Operaciones, "Asignar Comprobantes al recibo.")) return;
                if (recibosManager_SearchResultBindingSource.Current == null) return;

                var curr = (RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current;

                if (curr.Fecha_Anulacion != null) throw new ValidationException("El recibo se encuentra anulado.");
                if (curr.Fecha_Liquidacion == null) throw new ValidationException("El recibo se puede modificar porque no esta confirmado.");
                if (curr.ImporteSinAplicar <= 0) throw new ValidationException("El recibo no posee importe sin aplicar.");

                var f = new frmRecibosComprobantes_AddMod(curr.TipoEntidad, curr.Id_Entidad.Value, curr.Id);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    recibosManager_SearchResultBindingSource[recibosManager_SearchResultBindingSource.Position] = RecibosManager.Buscar(new RecibosManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                    recibosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnDesasignaCmp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Operaciones, "Desasignar Comprobantes al recibo.")) return;
                if (recibosManager_SearchResultBindingSource.Current == null) return;

                var curr = (RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current;
                if (curr.Fecha_Anulacion != null) throw new ValidationException("El recibo se encuentra anulado.");
                if (curr.Fecha_Liquidacion == null) throw new ValidationException("El recibo se puede modificar porque no esta confirmado.");

                var f = new frmRecibos_AddMod(new Recibos() { Id = curr.Id, Id_Entidad = curr.Id_Entidad }, true);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    recibosManager_SearchResultBindingSource[recibosManager_SearchResultBindingSource.Position] = RecibosManager.Buscar(new RecibosManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                    recibosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnVerCtaCte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Ver, "Cuenta Corriente de la Entidad")) return;

            if (recibosManager_SearchResultBindingSource.Current == null) return;

            var curr = (RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current;

            frmEntidadesCtaCte f = new frmEntidadesCtaCte(curr.TipoEntidad, Convert.ToInt32(curr.Id_Entidad), true);
            f.ShowDialog(this);
        }

        private void btnReporteCompleto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Ver, "Reporte Completo")) return;

                new frmRecibos_ReporteCompleto().ShowDialog(this);
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

        private void btnMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Operaciones, "Enviar por Mail")) return;

                if (recibosManager_SearchResultBindingSource.Current == null) return;
                Imprime(((RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current).Id, true);
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

        private void btnPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Operaciones, "Generar PDF")) return;

                if (recibosManager_SearchResultBindingSource.Current == null) return;
                Imprime(((RecibosManager.SearchResult)recibosManager_SearchResultBindingSource.Current).Id, false, true);
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

        private void btnPercepciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Ver, "Percepciones")) return;

                new frmRecibos_ReporteCompleto(true).ShowDialog(this);
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
