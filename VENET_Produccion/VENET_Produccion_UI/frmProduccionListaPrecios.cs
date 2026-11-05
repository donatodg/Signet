namespace VENET_Produccion_UI
{
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    //using VENET_Produccion_Reports;
    using VENET_Produccion_BL;

    public partial class frmProduccionListaPrecios : MultiForm
    {
        private ProduccionListaPreciosManager.ParametrosBusquedas par = new ProduccionListaPreciosManager.ParametrosBusquedas();

        public frmProduccionListaPrecios()
        {
            InitializeComponent();
        }

        private void frmProduccionListaPrecios_Load(object sender, EventArgs e)
        {
            try
            {
                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                par.Id_Empresa = Sistema.Empresas.ElementAt(0).Key;
                produccionListaPreciosManager_ParametrosBusquedasBindingSource.DataSource = par;
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void produccionListaPreciosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionListaPreciosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Buscar)) return;

                Validate();
                produccionListaPreciosManager_SearchResultBindingSource.DataSource = ProduccionListaPreciosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Agregar)) return;

            Produccion_ListaPrecios o = new Produccion_ListaPrecios();
            var f = new frmProduccionListaPrecios_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                produccionListaPreciosManager_SearchResultBindingSource.Add(ProduccionListaPreciosManager.Buscar(new ProduccionListaPreciosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Modificar)) return;

                if (produccionListaPreciosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProduccionListaPreciosManager.SearchResult)produccionListaPreciosManager_SearchResultBindingSource.Current;
                    var f = new frmProduccionListaPrecios_AddMod(new Produccion_ListaPrecios() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        produccionListaPreciosManager_SearchResultBindingSource[produccionListaPreciosManager_SearchResultBindingSource.Position] = ProduccionListaPreciosManager.Buscar(new ProduccionListaPreciosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        produccionListaPreciosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Eliminar)) return;

                if (produccionListaPreciosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionListaPreciosManager.Eliminar(new Produccion_ListaPrecios() { Id = ((ProduccionListaPreciosManager.SearchResult)produccionListaPreciosManager_SearchResultBindingSource.Current).Id });
                    produccionListaPreciosManager_SearchResultBindingSource.RemoveCurrent();
                    produccionListaPreciosManager_SearchResultBindingSource.ResetBindings(false);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Ver, "Detalle")) return;

                if (produccionListaPreciosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ProduccionListaPreciosManager.SearchResult)produccionListaPreciosManager_SearchResultBindingSource.Current;
                var f = new frmProduccionListaPreciosDetalle(curr.Id);
                f.ShowDialog(this);
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

        private void btnListaPrecios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Imprimir, "Lista de Precios")) return;

            //    if (produccionListaPreciosManager_SearchResultBindingSource.Current == null) return;

            //    var curr = (ProduccionListaPreciosManager.SearchResult)produccionListaPreciosManager_SearchResultBindingSource.Current;

            //    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            //    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
            //    SplashScreenManager.Default.SetWaitFormDescription("Generando Impresión");

            //    //OrdenesPago op = new OrdenesPago() { Id = Id_OrdenPago };

            //    xrptListaPrecio report = new xrptListaPrecio();
            //    //DevExpress.XtraReports reporte = new DevExpress.XtraReports();
            //    //reporte.xrSubreport1.ReportSource = reportOP1;
            //    //reporte.xrSubreport2.ReportSource = reportOP2;



            //    //report.DataSource = ListDatasource;

            //    //if (r.Impresora == "")
            //    //{
            //    //using (ReportPrintTool printTool = new ReportPrintTool(report))
            //    //{
            //    //    SplashScreenManager.CloseForm(false);
            //    //    printTool.ShowRibbonPreviewDialog();
            //    //}
            //    //}
            //    //else
            //    //    for (int i = 0; i < Convert.ToInt16(r.Copias); i++)
            //    //report.Print(r.Impresora);


            //    SplashScreenManager.CloseForm(false);

            //}
            //catch (ValidationException exv)
            //{
            //    SplashScreenManager.CloseForm(false);
            //    Sistema.Mensaje(exv.Message);
            //}
            //catch (Exception ex)
            //{
            //    SplashScreenManager.CloseForm(false);
            //    Sistema.MensajeError(ex);
            //}
        }

        private void btnGenerarExcelPrecios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Operaciones, "Generar Excel de Lista de Precios")) return;

                if (produccionListaPreciosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ProduccionListaPreciosManager.SearchResult)produccionListaPreciosManager_SearchResultBindingSource.Current;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Excel");

                ProduccionListaPreciosManager manager = new ProduccionListaPreciosManager(new Produccion_ListaPrecios() { Id = curr.Id });
                manager.GenerarExcel();
                //manager.GeneraPrueba();

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

        private void btnActualizaUtilidad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Operaciones, "Actualizar Utilidad por Variante")) return;

                if (produccionListaPreciosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ProduccionListaPreciosManager.SearchResult)produccionListaPreciosManager_SearchResultBindingSource.Current;

                var f = new frmProduccionActualizarUtilidad(curr.Id);
                f.ShowDialog(this);
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

        private void btnActualizaProductos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPrecios", Enums.Accion.Operaciones, "Actualizar Precios de Productos")) return;

                if (produccionListaPreciosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ProduccionListaPreciosManager.SearchResult)produccionListaPreciosManager_SearchResultBindingSource.Current;

                var f = new frmProduccionListaPrecios_ActualizaProductos();
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Actualizando Precios");

                    ProduccionListaPreciosManager.ActualizarPreciosProductos(curr.Id, f.Valor);

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
