namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;
    using VENET_Tesoreria_Reports;

    public partial class frmListaPagos : MultiForm
    {
        private ListaPagosManager.ParametrosBusquedas par = new ListaPagosManager.ParametrosBusquedas();

        public frmListaPagos()
        {
            InitializeComponent();
        }

        private void frmListaPagos_Load(object sender, EventArgs e)
        {
            listaPagosManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
            id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Imprimir)) return;
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

        private void listaPagosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + listaPagosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Buscar)) return;

                Validate();
                listaPagosManager_SearchResultBindingSource.DataSource = ListaPagosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Agregar)) return;

            ListaPagos o = new ListaPagos();
            var f = new frmListaPagos_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                listaPagosManager_SearchResultBindingSource.Add(ListaPagosManager.Buscar(new ListaPagosManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Modificar)) return;

                if (listaPagosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ListaPagosManager.SearchResult)listaPagosManager_SearchResultBindingSource.Current;
                    var f = new frmListaPagos_AddMod(new ListaPagos() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        listaPagosManager_SearchResultBindingSource[listaPagosManager_SearchResultBindingSource.Position] = ListaPagosManager.Buscar(new ListaPagosManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        listaPagosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Eliminar)) return;

                if (listaPagosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ListaPagosManager.Eliminar(new ListaPagos() { Id = ((ListaPagosManager.SearchResult)listaPagosManager_SearchResultBindingSource.Current).Id });
                    listaPagosManager_SearchResultBindingSource.RemoveCurrent();
                    listaPagosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void btnConfirmar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Confirmar();
        }

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Anular();
        }

        private void Confirmar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Operaciones, "Confirmar Lista de Pagos")) return;

                if (listaPagosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    ListaPagosManager.Confirmar(new ListaPagos() { Id = ((ListaPagosManager.SearchResult)listaPagosManager_SearchResultBindingSource.Current).Id });

                    listaPagosManager_SearchResultBindingSource[listaPagosManager_SearchResultBindingSource.Position] = ListaPagosManager.Buscar(new ListaPagosManager.ParametrosBusquedas() { Id = ((ListaPagosManager.SearchResult)listaPagosManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                    listaPagosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Operaciones, "Anular Lista de Pagos")) return;

                if (listaPagosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        ListaPagosManager.Anular(new ListaPagos() { Id = ((ListaPagosManager.SearchResult)listaPagosManager_SearchResultBindingSource.Current).Id }, f.result);

                        listaPagosManager_SearchResultBindingSource[listaPagosManager_SearchResultBindingSource.Position] = ListaPagosManager.Buscar(new ListaPagosManager.ParametrosBusquedas() { Id = ((ListaPagosManager.SearchResult)listaPagosManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                        listaPagosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnGeneraExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Operaciones, "Generar Plantilla Excel para Importación")) return;

                ListaPagosManager.GenerarModeloExcel();

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

        private void btnGeneraOP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Operaciones, "Generar Ordenes de Pagos")) return;

                if (listaPagosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Generar las Ordenes de Pagos para el Item Seleccionado?", "Atención..."))
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Generando Ordenes de Pagos");

                    ListaPagosManager.GenerarOP(new ListaPagos() { Id = ((ListaPagosManager.SearchResult)listaPagosManager_SearchResultBindingSource.Current).Id });

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

        private void btnImprimeLista_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (listaPagosManager_SearchResultBindingSource.Current == null) return;
            Imprime(((ListaPagosManager.SearchResult)listaPagosManager_SearchResultBindingSource.Current).Id);
        }

        public void Imprime(int Id_ListaPago)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ListaPagos", Enums.Accion.Imprimir, "Imprimir Listado Detallado")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Informe");

                xrptListaPago report = new xrptListaPago();
                report.DataSource = ListaPagosManager.ImprimeListaPago(new ListaPagos() { Id = Id_ListaPago });

                SplashScreenManager.CloseForm(false);

                using (ReportPrintTool printTool = new ReportPrintTool(report))
                    printTool.ShowRibbonPreviewDialog();
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