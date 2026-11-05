namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using DevExpress.XtraReports.UI;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;
    using VENET_Tesoreria_Reports;
    using DevExpress.XtraSplashScreen;
    using VENET_Gestion_BL;

    public partial class frmRendiciones : MultiForm
    {
        private RendicionesManager.ParametrosBusquedas par = new RendicionesManager.ParametrosBusquedas();

        public frmRendiciones()
        {
            InitializeComponent();
        }

        private void frmRendicion_Load(object sender, EventArgs e)
        {
            id_CajaLookUpEdit.Properties.DataSource = Sistema.Cajas;
            id_CajaLookUpEdit.Properties.ValueMember = "Id_Caja";
            id_CajaLookUpEdit.Properties.DisplayMember = "Caja";

            if (Sistema.Cajas.Count > 0)
            {
                id_CajaLookUpEdit.ItemIndex = 0;
                par.Id_Caja = (int)id_CajaLookUpEdit.EditValue;
            }
            else
            {
                Sistema.Mensaje("El usuario no posee cajas asignadas.");
                Close();
            }

            rendicionesManager_ParametrosBusquedasBindingSource.DataSource = par;
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
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void rendicionesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + rendicionesManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Buscar)) return;
                Validate();
                rendicionesManager_SearchResultBindingSource.DataSource = RendicionesManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Agregar)) return;
            Rendiciones o = new Rendiciones();
            var f = new frmRendiciones_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                rendicionesManager_SearchResultBindingSource.Add(RendicionesManager.Buscar(new RendicionesManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Modificar)) return;
                if (rendicionesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (RendicionesManager.SearchResult)rendicionesManager_SearchResultBindingSource.Current;
                    var f = new frmRendiciones_AddMod(new Rendiciones() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        rendicionesManager_SearchResultBindingSource[rendicionesManager_SearchResultBindingSource.Position] = RendicionesManager.Buscar(new RendicionesManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        rendicionesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Eliminar)) return;
                if (rendicionesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    RendicionesManager.Eliminar(new Rendiciones() { Id = ((RendicionesManager.SearchResult)rendicionesManager_SearchResultBindingSource.Current).Id });
                    rendicionesManager_SearchResultBindingSource.RemoveCurrent();
                    rendicionesManager_SearchResultBindingSource.ResetBindings(false);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Operaciones, "Confirmar Rendición")) return;

                if (rendicionesManager_SearchResultBindingSource.Current == null) return;

                var curr = (RendicionesManager.SearchResult)rendicionesManager_SearchResultBindingSource.Current;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    RendicionesManager.Confirmar(new Rendiciones() { Id = curr.Id });

                    rendicionesManager_SearchResultBindingSource[rendicionesManager_SearchResultBindingSource.Position] = RendicionesManager.Buscar(new RendicionesManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                    rendicionesManager_SearchResultBindingSource.ResetCurrentItem();
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
            {
                try
                {
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Operaciones, "Anular Rendición")) return;

                    if (rendicionesManager_SearchResultBindingSource.Current == null) return;

                    var curr = (RendicionesManager.SearchResult)rendicionesManager_SearchResultBindingSource.Current;

                    if (curr.FechaAnulacion != null) throw new ValidationException("La rendición ya se encuentra anulado.");

                    if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                    {
                        frmTexto f = new frmTexto("Motivo Anulación", "", "");
                        if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            RendicionesManager.Anular(new Rendiciones() { Id = curr.Id }, f.result);

                            rendicionesManager_SearchResultBindingSource[rendicionesManager_SearchResultBindingSource.Position] = RendicionesManager.Buscar(new RendicionesManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                            rendicionesManager_SearchResultBindingSource.ResetCurrentItem();
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
        }

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modificar();
        }

        private void btnReporteConceptos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Ver, "Ver Rendición de Vale Por Concepto")) return;

                frmRendicionesPorConcepto f = new frmRendicionesPorConcepto();
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

        private void btnImprimeRendicion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rendicionesManager_SearchResultBindingSource.Current == null) return;
            Imprime(((RendicionesManager.SearchResult)rendicionesManager_SearchResultBindingSource.Current).Id);
        }

        public void Imprime(int Id_Rendicion)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Rendiciones", Enums.Accion.Imprimir, "Imprime Rendiciones")) return;

                xrptRendicion report = new xrptRendicion();
                report.DataSource = RendicionesManager.ImprimeRendicion(new Rendiciones() { Id = Id_Rendicion });

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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void btnEMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Rendiciones", Enums.Accion.Operaciones, "Enviar por Mail")) return;

                if (rendicionesManager_SearchResultBindingSource.Current == null) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                foreach (int x in gridView1.GetSelectedRows())
                {
                    //  new frmEntidadesCtaCte().ImprimeComprobanteVentas(((ValesManager.SearchResult)gridView1.GetRow(x)).Id, false, true);
                    if (((RendicionesManager.SearchResult)gridView1.GetRow(x)).FechaConfirmacion == null)
                        Sistema.Mensaje("No se puede enviar por mail una rendiciòn sin confirmar.");
                    else
                    {
                        string TC = "";
                        string Archivo = "";

                        TC = "Rendicion";
                        //TC = TipoComprobanteManager.ObtenerTipoComprobante(cv.Id_TipoComprobante);
                        Archivo = Parametro.ObtenerValor(Parametro.Param.RutaGeneracionComprobantesVentas) + TC + "-" + ((RendicionesManager.SearchResult)gridView1.GetRow(x)).Id + "-" + ((RendicionesManager.SearchResult)gridView1.GetRow(x)).Legajo + ".pdf";

                        xrptRendicion report = new xrptRendicion();
                        report.DataSource = RendicionesManager.ImprimeRendicion(new Rendiciones() { Id = ((RendicionesManager.SearchResult)gridView1.GetRow(x)).Id });

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

