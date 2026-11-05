namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
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

    public partial class frmVales : MultiForm, IForm
    {
        private ValesManager.ParametrosBusquedas par = new ValesManager.ParametrosBusquedas();

        public frmVales()
        {
            InitializeComponent();
            par.Estado = Enums.ValesEstados.Todos;
        }

        public frmVales(ValesManager.ParametrosBusquedas parametros)
        {
            InitializeComponent();
            par = parametros;
            id_CajaLookUpEdit.Enabled = false;
            id_PersonalLookUpEdit.Enabled = false;
            lnkPersonal.Enabled = false;
            estadoLookUpEdit.Enabled = false;
            Buscar();

            gridView1.OptionsSelection.MultiSelect = true;
        }

        private void frmVales_Load(object sender, EventArgs e)
        {
            valesManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_CajaLookUpEdit.Properties.DataSource = Sistema.Cajas;
            id_CajaLookUpEdit.Properties.ValueMember = "Id_Caja";
            id_CajaLookUpEdit.Properties.DisplayMember = "Caja";

            id_PersonalLookUpEdit.Properties.DataSource = par.ListaPersonal;
            id_PersonalLookUpEdit.Properties.DisplayMember = "Nombre";
            id_PersonalLookUpEdit.Properties.ValueMember = "Id";

            estadoLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ValesEstados));
            estadoLookUpEdit.Properties.DisplayMember = "Value";
            estadoLookUpEdit.Properties.ValueMember = "Key";

            if (Sistema.Cajas.Count > 0)
            {
                if (par.Id_Caja == null)
                {
                    id_CajaLookUpEdit.ItemIndex = 0;
                    par.Id_Caja = (int)id_CajaLookUpEdit.EditValue;
                }
            }
            else
            {
                Sistema.Mensaje("El usuario no posee cajas asignadas.");
                Close();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void valesManager_SearchResultBindingSource_ListChanged_1(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + valesManager_SearchResultBindingSource.Count.ToString();
        }

        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {
            Modalidad();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Buscar)) return;
                Validate();
                valesManager_SearchResultBindingSource.DataSource = ValesManager.Buscar(par);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Agregar)) return;
                if (Convert.ToInt32(par.Id_Caja) == 0)
                {
                    Sistema.Mensaje("Debe seleccionar una Empresa.");
                    return;
                }
                Vales o = new Vales() { Id_Caja = (int)par.Id_Caja };
                var f = new frmVales_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    valesManager_SearchResultBindingSource.Add(ValesManager.Buscar(new ValesManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
                }
                f.Dispose();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void Modalidad()
        {
            if (valesManager_SearchResultBindingSource.Current == null) return;

            IForm formInterface = Owner as IForm;

            if (formInterface != null)
            {
                if (gridView1.GetSelectedRows().Count() > 1)
                    formInterface.IdsSeleccionados(gridView1.GetSelectedRows().ToList().Select(x => ((ValesManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList());
                else
                    formInterface.IdSeleccionado(((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).Id);

                Close();

            }
            else Modificar();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Modificar)) return;
                if (valesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current;
                    var f = new frmVales_AddMod(new Vales() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        valesManager_SearchResultBindingSource[valesManager_SearchResultBindingSource.Position] = ValesManager.Buscar(new ValesManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        valesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Eliminar)) return;
                if (valesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ValesManager.Eliminar(new Vales() { Id = ((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).Id });
                    valesManager_SearchResultBindingSource.RemoveCurrent();
                    valesManager_SearchResultBindingSource.ResetBindings(false);
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
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Operaciones, "Confirmar Vale")) return;

                if (valesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    ValesManager.Confirmar(new Vales() { Id = ((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).Id });
                    valesManager_SearchResultBindingSource[valesManager_SearchResultBindingSource.Position] = ValesManager.Buscar(new ValesManager.ParametrosBusquedas() { Id = ((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                    valesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Operaciones, "Anular Vale")) return;

                if (valesManager_SearchResultBindingSource.Current == null) return;

                if (((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).FechaAnulacion != null) throw new ValidationException("El vale ya se encuentra anulado.");

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        ValesManager.Anular(new Vales() { Id = ((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).Id }, f.result);
                        valesManager_SearchResultBindingSource[valesManager_SearchResultBindingSource.Position] = ValesManager.Buscar(new ValesManager.ParametrosBusquedas() { Id = ((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                        valesManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnRendir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Operaciones, "Rendir Vale")) return;

                if (valesManager_SearchResultBindingSource.Current == null) return;

                var curr = (ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current;

                if (curr.Id_Rendicion > 0) throw new ValidationException("No se puede rendir un vale ya rendido.");
                if (curr.FechaConfirmacion == null) throw new ValidationException("No se puede rendir un vale sin confirmar.");
                if (curr.FechaAnulacion != null) throw new ValidationException("No se puede rendir un vale anulado.");

                Rendiciones o = new Rendiciones() { Id_Personal = curr.Id_Personal, Ids_Vales = curr.Numero.ToString(), ImporteVale = curr.Importe, Id_Caja = curr.Id_Caja };
                frmRendiciones_AddMod f = new frmRendiciones_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    if (Sistema.MensajeSiNo("¿Desea confirmar la rendición ingresada?", "Atención..."))
                        RendicionesManager.Confirmar(o);

                    Buscar();
                    //valesManager_SearchResultBindingSource[valesManager_SearchResultBindingSource.Position] = ValesManager.Buscar(new ValesManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                    //valesManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void lnkPersonal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPersonal", "VENET_Personal_UI", "VENET_Personal_UI", true);
        }

        public void IdSeleccionado(int Id)
        {
            id_PersonalLookUpEdit.EditValue = par.Id_Personal = Id;
            Validate();
        }

        private void btnImprimeVale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (valesManager_SearchResultBindingSource.Current == null) return;
            Imprime(((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).Id);
        }

        public void Imprime(int Id_Vale)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Imprimir, "Imprime Vale")) return;

                XtraReport report = new XtraReport();

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesDuplicadosPorHoja)))
                {
                    xrptVale reportVale = new xrptVale();
                    reportVale.DataSource = ValesManager.ImprimeVale(new Vales() { Id = Id_Vale });

                    xrptDoblePorHoja reporte = new xrptDoblePorHoja();
                    reporte.xrSubreport1.ReportSource = reportVale;
                    reporte.xrSubreport2.ReportSource = reportVale;

                    report = reporte;
                }
                else
                {
                    report = new xrptVale();
                    report.DataSource = ValesManager.ImprimeVale(new Vales() { Id = Id_Vale });
                }

                using (ReportPrintTool printTool = new ReportPrintTool(report))
                    printTool.ShowRibbonPreviewDialog();
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

        private void btnRendicion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Ver, "Ver Rendición de Vale")) return;
                if (valesManager_SearchResultBindingSource.Current == null) return;

                if (((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).FechaRendicion == null)
                {
                    Sistema.Mensaje("El Vale no se encuentra rendido.");
                    return;
                }

                frmRendiciones_AddMod f = new frmRendiciones_AddMod(new Rendiciones() { Id = ((ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current).Id_Rendicion });
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

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modalidad();
        }

        public void IdsSeleccionados(List<int> Ids)
        {
            throw new NotImplementedException();
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void btnTransferir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Operaciones, "Transferencia de Vales")) return;
                frmValesTransferencia f = new frmValesTransferencia();
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

        private void btnModeloExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Operaciones, "Generar Plantilla Excel para Importación")) return;

                ValesManager.GenerarModeloExcel();

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

        private void btnImportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Operaciones, "Importar Excel con Vales")) return;

                Validate();
                if (Convert.ToInt32(par.Id_Caja) == 0)
                {
                    Sistema.Mensaje("Debe seleccionar una Empresa.");
                    return;
                }
                frmValesMasivo_AddMod f = new frmValesMasivo_AddMod((int)par.Id_Caja);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    par.Estado = Enums.ValesEstados.Pendientes;
                    estadoLookUpEdit.EditValue = par.Estado;
                    Validate();
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

        private void btnCtaCte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Ver, "Cuenta Corriente de la Entidad")) return;

            if (valesManager_SearchResultBindingSource.Current == null) return;

            var curr = (ValesManager.SearchResult)valesManager_SearchResultBindingSource.Current;

            frmEntidadesCtaCte f = new frmEntidadesCtaCte(Enums.TipoEntidad.Personal, Convert.ToInt32(curr.Id_Personal), true);
            f.ShowDialog(this);
        }

        private void btnEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Vales", Enums.Accion.Operaciones, "Enviar por Mail")) return;

                if (valesManager_SearchResultBindingSource.Current == null) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                foreach (int x in gridView1.GetSelectedRows())
                {
                    //  new frmEntidadesCtaCte().ImprimeComprobanteVentas(((ValesManager.SearchResult)gridView1.GetRow(x)).Id, false, true);
                    if (((ValesManager.SearchResult)gridView1.GetRow(x)).FechaConfirmacion == null)
                        Sistema.Mensaje("No se puede enviar por mail un vale sin confirmar.");
                    else
                    {
                        string TC = "";
                        string Archivo = "";

                        XtraReport report = new XtraReport();

                        TC = "Vale";
                        //TC = TipoComprobanteManager.ObtenerTipoComprobante(cv.Id_TipoComprobante);
                        Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + TC + "-" + ((ValesManager.SearchResult)gridView1.GetRow(x)).Numero + "-" + ((ValesManager.SearchResult)gridView1.GetRow(x)).Legajo + ".pdf";

                        report = new xrptVale();
                        report.DataSource = ValesManager.ImprimeVale(new Vales() { Id = ((ValesManager.SearchResult)gridView1.GetRow(x)).Id });

                        if (!System.IO.File.Exists(Archivo))
                            report.ExportToPdf(Archivo);

                        string Recipiente = ComprobantesVentasManager.ObtenerMail(Enums.TipoEntidad.Personal, ((ValesManager.SearchResult)gridView1.GetRow(x)).Id_Personal);
                        if (Recipiente == "" || Recipiente == null) throw new ValidationException("La entidad no posee un mail cargado.");

                        Sistema.EnvioMail(Archivo, "Comprobante " + TC + " " + ((ValesManager.SearchResult)gridView1.GetRow(x)).Numero, "", Recipiente);
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
    }
}
