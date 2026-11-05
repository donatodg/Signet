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
    using VENET_Gestion_BL;

    public partial class frmOrdenesPago : MultiForm
    {
        private OrdenesPagoManager.ParametrosBusquedas par = new OrdenesPagoManager.ParametrosBusquedas();

        public frmOrdenesPago()
        {
            InitializeComponent();
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
        }

        private void frmOrdenesPago_Load(object sender, EventArgs e)
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

            estadoLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.OPEstados));
            estadoLookUpEdit.Properties.DisplayMember = "Value";
            estadoLookUpEdit.Properties.ValueMember = "Key";

            ordenesPagoManager_ParametrosBusquedasBindingSource.DataSource = par;

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

        private void btnReporteOP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;
            Imprime(((OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current).Id);
        }

        public void Imprime(int Id_OrdenPago, bool EnviarMail = false, bool GeneraPDF = false)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Imprimir, "Imprimir Ordenes de Pago")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                OrdenesPago op = new OrdenesPago() { Id = Id_OrdenPago };

                XtraReport report = new XtraReport();

                TalonariosComprobantes r = OrdenesPagoManager.Reporte(op);

                var ListDatasource = OrdenesPagoManager.ImprimeOP(op);

                if (r.Reporte == "<Ninguno>")
                    if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.OrdenesDePago_UtilizaRetenciones)))
                        report = new xrptOrdenPagoRetenciones();
                    else
                    {
                        if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesDuplicadosPorHoja)))
                        {
                            xrptOrdenPago reportOP1 = new xrptOrdenPago();
                            reportOP1.DataSource = ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; }).ToList();

                            xrptOrdenPago reportOP2 = new xrptOrdenPago();
                            reportOP2.DataSource = OrdenesPagoManager.ImprimeOP(op).Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; }).ToList(); ;

                            xrptDoblePorHoja reporte = new xrptDoblePorHoja();
                            reporte.xrSubreport1.ReportSource = reportOP1;
                            reporte.xrSubreport2.ReportSource = reportOP2;

                            report = reporte;
                        }
                        else
                            report = new xrptOrdenPago();
                    }
                else
                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                if (ListDatasource[0].Registro.Fecha_Liquidacion == null && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
                    throw new ValidationException("Antes de imprimir el comprobante debe liquidarlo.");

                report.DataSource = ListDatasource;

                if (EnviarMail || GeneraPDF)
                {
                    string Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + "OP-" + op.NroComprobante + "-" + ListDatasource[0].Entidad.Nombre + ".pdf";
                    if (!System.IO.File.Exists(Archivo))
                        report.ExportToPdf(Archivo);

                    if (EnviarMail)
                    {
                        string Recipiente = ComprobantesVentasManager.ObtenerMail(op.TipoEntidad, op.Id_Entidad.Value);
                        if (Recipiente == "" || Recipiente == null) throw new ValidationException("La entidad no posee un mail cargado.");

                        Sistema.EnvioMail(Archivo, "Comprobante OP-" + op.NroComprobante, "", Recipiente);
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

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnConfirmar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Confirmar();
        }

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Anular();
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

        private void ordenesPagoManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + ordenesPagoManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Buscar)) return;
                Validate();
                ordenesPagoManager_SearchResultBindingSource.DataSource = OrdenesPagoManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Agregar)) return;
            if (Convert.ToInt32(par.Id_Sucursal) == 0)
            {
                Sistema.Mensaje("Debe seleccionar una Sucursal.");
                return;
            }
            OrdenesPago o = new OrdenesPago() { Id_Sucursal = (int)par.Id_Sucursal };
            var f = new frmOrdenesPago_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                ordenesPagoManager_SearchResultBindingSource.Add(OrdenesPagoManager.Buscar(new OrdenesPagoManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Modificar)) return;
                if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current;
                    var f = new frmOrdenesPago_AddMod(new OrdenesPago() { Id = curr.Id, Id_Entidad = curr.Id_Entidad });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        ordenesPagoManager_SearchResultBindingSource[ordenesPagoManager_SearchResultBindingSource.Position] = OrdenesPagoManager.Buscar(new OrdenesPagoManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        ordenesPagoManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Eliminar)) return;
                if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    OrdenesPagoManager.Eliminar(new OrdenesPago() { Id = ((OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current).Id });
                    ordenesPagoManager_SearchResultBindingSource.RemoveCurrent();
                    ordenesPagoManager_SearchResultBindingSource.ResetBindings(false);
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

        private void Confirmar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Operaciones, "Confirmar Ordenes de Pago")) return;

                if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    OrdenesPagoManager.Confirmar(new OrdenesPago() { Id = ((OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current).Id });

                    ordenesPagoManager_SearchResultBindingSource[ordenesPagoManager_SearchResultBindingSource.Position] = OrdenesPagoManager.Buscar(new OrdenesPagoManager.ParametrosBusquedas() { Id = ((OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                    ordenesPagoManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void gcBusquedaAvanzada_Paint(object sender, PaintEventArgs e)
        {
            if (tipoEntidadLookUpEdit.Text == "") return;

            switch ((Enums.TipoEntidad)tipoEntidadLookUpEdit.EditValue)
            {
                case Enums.TipoEntidad.Cliente:
                    Sistema.AbrirForm(this, "frmClientes", "VENET_Clientes_UI", "VENET_Clientes_UI", true);
                    break;

                case Enums.TipoEntidad.Personal:
                    Sistema.AbrirForm(this, "frmPersonal", "VENET_Personal_UI", "VENET_Personal_UI", true);
                    break;

                case Enums.TipoEntidad.Proveedor:
                    Sistema.AbrirForm(this, "frmProveedores", "VENET_Proveedores_UI", "VENET_Proveedores_UI", true);
                    break;

                default: break;
            }
        }

        //public void IdSeleccionado(int Id)
        //{
        //   id_EntidadTextEdit.Text = Id.ToString();
        //    par.Id_Entidad = Id;

        //    Validate();
        //}

        private void Anular()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Operaciones, "Anular Ordenes de Pago")) return;

                if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;

                if (((OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current).Fecha_Anulacion != null) throw new ValidationException("La orden de pago ya se encuentra anulada.");

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        OrdenesPagoManager.Anular(new OrdenesPago() { Id = ((OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current).Id }, f.result);

                        ordenesPagoManager_SearchResultBindingSource[ordenesPagoManager_SearchResultBindingSource.Position] = OrdenesPagoManager.Buscar(new OrdenesPagoManager.ParametrosBusquedas() { Id = ((OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                        ordenesPagoManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Operaciones, "Asignar Comprobantes a la orden de pago.")) return;
                if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;

                var curr = (OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current;
                if (curr.Fecha_Anulacion != null) throw new ValidationException("La orden de pago se encuentra anulada.");
                if (curr.Fecha_Liquidacion == null) throw new ValidationException("La orden de pago se puede modificar porque no esta confirmada.");
                if (curr.ImporteSinAplicar <= 0) throw new ValidationException("La orden de pago no posee importe sin aplicar.");

                var f = new frmOrdenesPagoComprobantes_AddMod(curr.TipoEntidad, curr.Id_Entidad.Value, curr.Id);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    ordenesPagoManager_SearchResultBindingSource[ordenesPagoManager_SearchResultBindingSource.Position] = OrdenesPagoManager.Buscar(new OrdenesPagoManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                    ordenesPagoManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnDesasignarCmp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Operaciones, "Desasignar Comprobantes a la orden de pago.")) return;
                if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;

                var curr = (OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current;

                if (curr.Fecha_Anulacion != null) throw new ValidationException("La orden de pago se encuentra anulada.");
                if (curr.Fecha_Liquidacion == null) throw new ValidationException("La orden de pago se puede modificar porque no esta confirmada.");

                var f = new frmOrdenesPago_AddMod(new OrdenesPago() { Id = curr.Id, Id_Entidad = curr.Id_Entidad }, true);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    ordenesPagoManager_SearchResultBindingSource[ordenesPagoManager_SearchResultBindingSource.Position] = OrdenesPagoManager.Buscar(new OrdenesPagoManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                    ordenesPagoManager_SearchResultBindingSource.ResetCurrentItem();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Ver, "Cuenta Corriente de la Entidad")) return;

            if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;

            var curr = (OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current;

            frmEntidadesCtaCte f = new frmEntidadesCtaCte(curr.TipoEntidad, Convert.ToInt32(curr.Id_Entidad), true);
            f.ShowDialog(this);
        }

        private void btnReporteCompleto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Ver, "Reporte Completo")) return;

                new frmOrdenesPago_ReporteCompleto().ShowDialog(this);
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

        private void btnReporteCompleto_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Ver, "Reporte Completo")) return;

                new frmOrdenesPago_ReporteCompleto().ShowDialog(this);
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

        private void btnEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Operaciones, "Enviar por Mail")) return;

                if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;
                Imprime(((OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current).Id, true);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Operaciones, "Generar PDF")) return;

                if (ordenesPagoManager_SearchResultBindingSource.Current == null) return;
                Imprime(((OrdenesPagoManager.SearchResult)ordenesPagoManager_SearchResultBindingSource.Current).Id, false, true);
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