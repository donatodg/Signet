namespace VENET_Tesoreria_UI
{
    using VENET_Gestion_BL;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    //using VENET_Gestion_UI;
    using VENET_Tesoreria_BL;
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraSplashScreen;
    using VENET_Gestion_Reports;
    using VENET_General_UI;

    public partial class frmEntidadesCtaCte : MultiForm
    {
        private EntidadesCtaCteManager.ParametrosBusquedas par = new EntidadesCtaCteManager.ParametrosBusquedas();
        private Enums.TipoEntidad _TipoEntidad;
        private int _IdEntidad;
        private bool _Busqueda = false;

        public frmEntidadesCtaCte()
        {
            InitializeComponent();
        }

        public frmEntidadesCtaCte(Enums.TipoEntidad TipoEntidad, int IdEntidad, bool Busqueda = false)
        {
            InitializeComponent();
            _TipoEntidad = TipoEntidad;
            _IdEntidad = IdEntidad;
            _Busqueda = Busqueda;
        }

        private void frmEntidadesCtaCte_Load(object sender, EventArgs e)
        {
            try
            {
                entidadesCtaCteManager_ParametrosBusquedasBindingSource.DataSource = par;

                id_TipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
                id_TipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
                id_TipoEntidadLookUpEdit.Properties.ValueMember = "Key";

                id_EntidadLookUpEdit.Properties.DataSource = par.Entidades;
                id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
                id_EntidadLookUpEdit.Properties.ValueMember = "Key";

                id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
                id_EspecieLookUpEdit.Properties.ValueMember = "Key";
                id_EspecieLookUpEdit.Properties.DisplayMember = "Name";

                //id_EntidadLookUpEdit.Properties.DataSource = par.Entidades;
                //id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
                //id_EntidadLookUpEdit.Properties.ValueMember = "Key";

                id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobante;
                id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";
                id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";

                if (Sistema.Especies.Count > 0)
                {
                    id_EspecieLookUpEdit.ItemIndex = 0;
                    par.Id_Especie = (int)id_EspecieLookUpEdit.EditValue;
                }
                else
                {
                    Sistema.Mensaje("El usuario no posee especies asignadas.");
                    Close();
                }

                par.Id_TipoEntidad = _TipoEntidad;

                if (par.Id_TipoEntidad == 0)
                    id_TipoEntidadLookUpEdit.EditValue = par.Id_TipoEntidad = Enums.TipoEntidad.Cliente;
                else
                    id_TipoEntidadLookUpEdit.EditValue = _TipoEntidad;

                if (_IdEntidad > 0)
                {
                    par.Id_Entidad = _IdEntidad;
                    id_EntidadLookUpEdit.EditValue = _IdEntidad;
                }

                Validate();

                if (_Busqueda) Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnMovimiento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void barSubItemAgregar_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void entidadesCtaCteManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + entidadesCtaCteManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Buscar)) return;
                Validate();

                if (id_EntidadLookUpEdit.EditValue != DBNull.Value)
                    par.Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;

                entidadesCtaCteManager_SearchResultBindingSource.DataSource = EntidadesCtaCteManager.Buscar(par);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Agregar)) return;

                Validate();
                if (par.Id_Entidad == null) throw new ValidationException("Debe seleccionar una entidad.");
                if (par.Id_Especie == null) throw new ValidationException("Debe seleccionar una especie.");

                EntidadesCtaCte o = new EntidadesCtaCte() { Id_TipoEntidad = (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue, Id_Entidad = (int)id_EntidadLookUpEdit.EditValue, Id_Especie = (int)id_EspecieLookUpEdit.EditValue };
                var f = new frmEntidadesCtaCte_AddMod(o);
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Buscar();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Modificar)) return;

                if (entidadesCtaCteManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EntidadesCtaCteManager.SearchResult)entidadesCtaCteManager_SearchResultBindingSource.Current;

                    if (curr.InternoSistema == true || curr.Id_Comprobante > 0)
                        Sistema.Mensaje("No se puede modificar el registro debido a que el tipo de movimiento está bloqueado.");
                    else
                    {
                        var f = new frmEntidadesCtaCte_AddMod(new EntidadesCtaCte() { Id = curr.Id });
                        if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            Buscar();
                        }
                        f.Dispose();
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

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Eliminar)) return;

                if (entidadesCtaCteManager_SearchResultBindingSource.Current == null) return;

                var curr = (EntidadesCtaCteManager.SearchResult)entidadesCtaCteManager_SearchResultBindingSource.Current;

                if (curr.InternoSistema == true || curr.Id_Comprobante > 0)
                    //if (((EntidadesCtaCteManager.SearchResult)entidadesCtaCteManager_SearchResultBindingSource.Current).InternoSistema == true)
                    Sistema.Mensaje("No se puede eliminar el registro debido a que el tipo de movimiento está bloqueado.");
                else
                {
                    if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                    {
                        EntidadesCtaCteManager.Eliminar(new EntidadesCtaCte() { Id = ((EntidadesCtaCteManager.SearchResult)entidadesCtaCteManager_SearchResultBindingSource.Current).Id });
                        entidadesCtaCteManager_SearchResultBindingSource.RemoveCurrent();
                        entidadesCtaCteManager_SearchResultBindingSource.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Ver, "Ver Comprobante")) return;

                if (entidadesCtaCteManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EntidadesCtaCteManager.SearchResult)entidadesCtaCteManager_SearchResultBindingSource.Current;

                    if (curr.InternoSistema == true)
                        switch (curr.Id_TipoComprobante)
                        {
                            //case (int)Enums.TipoComprobante.Remitos:
                            //    break;

                            case (int)Enums.TipoComprobante.Recibos:
                                Recibos o2 = new Recibos() { Id = curr.Id_Comprobante };
                                frmRecibos_AddMod f2 = new frmRecibos_AddMod(o2);
                                f2.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.Vales:
                                Vales o3 = new Vales() { Id = curr.Id_Comprobante };
                                frmVales_AddMod f3 = new frmVales_AddMod(o3);
                                f3.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.Rendiciones:
                                Rendiciones o4 = new Rendiciones() { Id = curr.Id_Comprobante };
                                frmRendiciones_AddMod f4 = new frmRendiciones_AddMod(o4);
                                f4.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.BoletasDeposito:
                                BoletasDepositos o5 = new BoletasDepositos() { Id = curr.Id_Comprobante };
                                frmBoletasDepositos_AddMod f5 = new frmBoletasDepositos_AddMod(o5);
                                f5.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.Transferencia:
                                Transferencias o6 = new Transferencias() { Id = curr.Id_Comprobante };
                                frmTransferencias f6 = new frmTransferencias(o6);
                                f6.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.OrdenesPago:
                                OrdenesPago o7 = new OrdenesPago() { Id = curr.Id_Comprobante };
                                frmOrdenesPago_AddMod f7 = new frmOrdenesPago_AddMod(o7);
                                f7.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.ListaPago:
                                ListaPagos o8 = new ListaPagos() { Id = curr.Id_Comprobante };
                                frmListaPagos_AddMod f8 = new frmListaPagos_AddMod(o8);
                                f8.ShowDialog();
                                break;
                        }

                    if (curr.InternoSistema == false && curr.Id_Area == Enums.ComprobanteArea.Compras && curr.Id_Comprobante > 0)
                    {
                        ConfigurationManager.AppSettings["ParametroId"] = curr.Id_Comprobante.ToString();
                        ConfigurationManager.AppSettings["RetornoId"] = "0";

                        Sistema.AbrirForm(this, "frmComprobantesCompras_AddMod", "VENET_Gestion_UI", "VENET_Gestion_UI", true, false, false);
                        //frmComprobantesCompras_AddMod f = new frmComprobantesCompras_AddMod(new ComprobantesCompras() { Id = curr.Id_Comprobante });
                        //f.ShowDialog();
                    }

                    if (curr.InternoSistema == false && curr.Id_Area == Enums.ComprobanteArea.Ventas && curr.Id_Comprobante > 0)
                    {
                        ConfigurationManager.AppSettings["ParametroId"] = curr.Id_Comprobante.ToString();
                        ConfigurationManager.AppSettings["RetornoId"] = "0";

                        Sistema.AbrirForm(this, "frmComprobantesVentas_AddMod", "VENET_Gestion_UI", "VENET_Gestion_UI", true, false, false);
                        //frmComprobantesVentas_AddMod f = new frmComprobantesVentas_AddMod(new ComprobantesVentas() { Id = curr.Id_Comprobante });
                        //f.ShowDialog();
                    }

                    if (curr.InternoSistema == false && curr.Id_Comprobante == 0)
                        Modificar();
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
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void id_TipoEntidadLookUpEdit_EditValueChanged_1(object sender, EventArgs e)
        {
            if (par != null && id_TipoEntidadLookUpEdit.ItemIndex != -1)
            {
                par.Id_TipoEntidad = (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = par.Entidades;
                id_EntidadLookUpEdit.EditValue = par.Id_Entidad = null;
                if (par.Id_TipoEntidad != Enums.TipoEntidad.Proveedor_Financiero)
                {
                    id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
                    id_EspecieLookUpEdit.ItemIndex = 0;
                    par.Id_Especie = (int)id_EspecieLookUpEdit.EditValue;
                }
                else
                {
                    id_EspecieLookUpEdit.Properties.DataSource = null;
                    par.Id_Especie = null;
                    id_EspecieLookUpEdit.ItemIndex = -1;
                }
            }
        }

        private void id_EntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (par != null && id_TipoEntidadLookUpEdit.ItemIndex != -1 && (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue == Enums.TipoEntidad.Proveedor_Financiero && id_EntidadLookUpEdit.ItemIndex != -1)
            {
                Validate();
                par.Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;
                id_EspecieLookUpEdit.Properties.DataSource = par.EspeciesPF;
                if (par.EspeciesPF.Count > 0)
                    id_EspecieLookUpEdit.EditValue = par.Id_Especie = par.EspeciesPF.ElementAt(0).Key;
                else
                    id_EspecieLookUpEdit.EditValue = par.Id_Especie = null;
            }
        }

        private void btnOP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Agregar)) return;

                Validate();
                if (par.Id_Entidad == null) throw new ValidationException("Debe seleccionar una entidad.");
                if (par.Id_Especie == null) throw new ValidationException("Debe seleccionar una especie.");

                OrdenesPago o = new OrdenesPago() { TipoEntidad = par.Id_TipoEntidad, Id_Entidad = (int)par.Id_Entidad };
                frmOrdenesPago_AddMod f = new frmOrdenesPago_AddMod(o);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Operaciones, "Confirmar Ordenes de Pago")) return;

                    if (Sistema.MensajeSiNo("¿Desea confirmar la orden de pago ingresada?", "Confirmar") == true)
                    {
                        OrdenesPagoManager.Confirmar(o);
                        Buscar();
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

        private void btnRecibo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Agregar)) return;

                Validate();
                if (par.Id_Entidad == null) throw new ValidationException("Debe seleccionar una entidad.");
                if (par.Id_Especie == null) throw new ValidationException("Debe seleccionar una especie.");

                Recibos o = new Recibos() { TipoEntidad = par.Id_TipoEntidad, Id_Entidad = (int)par.Id_Entidad };
                frmRecibos_AddMod f = new frmRecibos_AddMod(o);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Operaciones, "Confirmar Recibo")) return;

                    if (Sistema.MensajeSiNo("¿Desea confirmar el recibo ingresado?", "Confirmar") == true)
                    {
                        RecibosManager.Confirmar(o);
                        Buscar();
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

        private void btnImprimeComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Ver, "Imprimir Comprobante")) return;

                if (entidadesCtaCteManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EntidadesCtaCteManager.SearchResult)entidadesCtaCteManager_SearchResultBindingSource.Current;

                    if (curr.InternoSistema == true)
                        switch (curr.Id_TipoComprobante)
                        {
                            //case (int)Enums.TipoComprobante.Remitos:
                            //    break;

                            case (int)Enums.TipoComprobante.Recibos:
                                new frmRecibos().Imprime(curr.Id_Comprobante);
                                break;

                            case (int)Enums.TipoComprobante.Vales:
                                new frmVales().Imprime(curr.Id_Comprobante);
                                break;

                            case (int)Enums.TipoComprobante.Rendiciones:
                                new frmRendiciones().Imprime(curr.Id_Comprobante);
                                break;

                            case (int)Enums.TipoComprobante.BoletasDeposito:
                                break;

                            case (int)Enums.TipoComprobante.Transferencia:
                                break;

                            case (int)Enums.TipoComprobante.OrdenesPago:
                                new frmOrdenesPago().Imprime(curr.Id_Comprobante);
                                break;

                            case (int)Enums.TipoComprobante.ListaPago:
                                new frmListaPagos().Imprime(curr.Id_Comprobante);
                                break;
                        }

                    if (curr.InternoSistema == false && curr.Id_Area == Enums.ComprobanteArea.Ventas && curr.Id_Comprobante > 0)
                    {
                        //new frmComprobantesVentas().Imprime(curr.Id_Comprobante, false, false);
                        ImprimeComprobanteVentas(curr.Id_Comprobante, false, false);
                    }

                    //else
                    //{
                    //hacer impresion genérica;
                    //}
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

        public void ImprimeComprobanteVentas(int Id_Comprobante, bool GeneraPDF, bool EnviarMail, int Copias = 0, string LeyendaOriginal = "ORIGINAL", bool SoloPantalla = false)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ComprobantesVentas", Enums.Accion.Imprimir, "Imprimir Comprobantes de Ventas")) return;

                string TC = "";
                string Archivo = "";

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                ComprobantesVentas cv = new ComprobantesVentas() { Id = Id_Comprobante };

                XtraReport report = new XtraReport();

                TalonariosComprobantes r = ComprobantesVentasManager.Reporte(cv);

                if (r.Reporte == "<Ninguno>")
                    report = new xrptComprobanteVenta();
                else
                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                var ListDatasource = ComprobantesVentasManager.ImprimeComprobante(cv);

                bool SoloLiquidados = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados));

                if (ListDatasource[0].FechaLiquidacion == null && SoloLiquidados)
                    throw new ValidationException("Antes de imprimir el comprobante debe liquidarlo.");

                if (SoloLiquidados && r.Electronico && ListDatasource[0].AFIPCAE == null)
                    throw new ValidationException("Antes de imprimir el comprobante debe presentarlo en AFIP.");

                report.DataSource = ListDatasource;

                if (GeneraPDF || EnviarMail)
                {
                    TC = TipoComprobanteManager.ObtenerTipoComprobante(cv.Id_TipoComprobante);
                    Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + TC + "-" + cv.Comprobante + "-" + ListDatasource[0].Entidad.Nombre + ".pdf";
                    if (!System.IO.File.Exists(Archivo))
                        report.ExportToPdf(Archivo);
                }
                else
                {


                    if (r.Impresora == "" || SoloPantalla || !(System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<String>()).Contains(r.Impresora))
                    {
                        using (ReportPrintTool printTool = new ReportPrintTool(report))
                        {
                            SplashScreenManager.CloseForm(false);
                            printTool.ShowRibbonPreviewDialog();
                        }
                    }
                    else
                    {
                        if (Copias > 0) r.Copias = Copias;

                        switch (Convert.ToInt16(r.Copias))
                        {
                            case 0:
                            case 1:
                                {
                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = LeyendaOriginal; return t; })).ToList();
                                    //report.PrintingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(PrintingSystem_StartPrint);
                                    report.Print(r.Impresora);
                                    break;
                                }
                            case 2:
                                {
                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);
                                    break;
                                }
                            case 3:
                                {
                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "TRIPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    break;
                                }
                            case 4:
                                {
                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "TRIPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "CUADRUPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    break;
                                }
                            case 5:
                                {
                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "ORIGINAL"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "DUPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "TRIPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "CUADRUPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    report = new XtraReport();
                                    if (r.Reporte == "<Ninguno>")
                                        report = new xrptComprobanteVenta();
                                    else
                                        report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                                    report.DataSource = (ListDatasource.Select(t => { t.LeyendaOriginal = "QUINTUPLICADO"; return t; })).ToList();
                                    report.Print(r.Impresora);

                                    break;
                                }
                        }
                    }
                }

                report = null;

                if (EnviarMail)
                {
                    string Recipiente = ComprobantesVentasManager.ObtenerMail(cv.Id_TipoEntidad, cv.Id_Entidad.Value);
                    if (Recipiente == "" || Recipiente == null) throw new ValidationException("La entidad no posee un mail cargado.");

                    Sistema.EnvioMail(Archivo, "Comprobante " + TC + cv.Comprobante, "", Recipiente);
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

        private void btnCtasCtesConSaldo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Ver, "Ver Cuentas Corrientes con Saldo")) return;

                frmEntidadesCtaCteSaldos f = new frmEntidadesCtaCteSaldos();
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


        private void btnEnviarCtaCteMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCte", Enums.Accion.Operaciones, "Enviar datos por Email")) return;
                Validate();

                if (id_EntidadLookUpEdit.EditValue == DBNull.Value)
                    throw new ValidationException("Debe seleccionar una entidad para enviar el Email.");

                if (!Sistema.MensajeSiNo("¿Desea enviar por Email la cuenta corriente a " + id_EntidadLookUpEdit.Text + "?")) return;

                if (entidadesCtaCteManager_SearchResultBindingSource.Count == 0)
                    throw new ValidationException("La búsqueda no arrojo datos para enviar.");

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Enviando Email.");

                string Archivo;

                //PDF
                Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + "CtaCte-" + id_EntidadLookUpEdit.Text + "-" + Convert.ToDateTime(Sistema.ObtenerFechaHora()).ToString("ddMMyyyyhhMMss") + ".pdf";
                gridControl1.ExportToPdf(Archivo);

                ////Excel              
                //Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + "CtaCte-" + id_EntidadLookUpEdit.Text + "-" + Convert.ToDateTime(fechaDesdeDateEdit.EditValue).ToString("ddMMyyyy") + ".xls";
                //gridControl1.ExportToXls(Archivo);

                string Recipiente = ComprobantesVentasManager.ObtenerMail((Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue, (int)id_EntidadLookUpEdit.EditValue);
                if (Recipiente == "" || Recipiente == null) throw new ValidationException("La entidad no posee un Email cargado.");

                Sistema.EnvioMail(Archivo, "Cta Cte " + id_EntidadLookUpEdit.Text + " - desde " + Convert.ToDateTime(fechaDesdeDateEdit.EditValue).ToString("dd/MM/yyyy"), "", Recipiente);

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

        private void btnComentario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "EntidadesCtaCte", Enums.Accion.Operaciones, "Ver Comentarios")) return;

                var curr = (EntidadesCtaCteManager.SearchResult)entidadesCtaCteManager_SearchResultBindingSource.Current;
                if (curr == null || curr.Concepto == "Saldo Anterior") return;

                frmComentarios f = new frmComentarios("EntidadesCtaCte", curr.Id);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (curr.Id_Comentario == null)
                        EntidadesCtaCteManager.ActualizaComentario(curr.Id, f.Id);

                    Buscar();
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
    }
}
