namespace VENET_Gestion_UI
{
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraSplashScreen;
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

    public partial class frmPedidos : MultiForm
    {
        private PedidosManager.ParametrosBusquedas par = new PedidosManager.ParametrosBusquedas();

        public frmPedidos()
        {
            InitializeComponent();
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                estadoLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.PedidosEstados));
                estadoLookUpEdit.Properties.DisplayMember = "Value";
                estadoLookUpEdit.Properties.ValueMember = "Key";

                tipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
                tipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
                tipoEntidadLookUpEdit.Properties.ValueMember = "Key";

                id_EntidadLookUpEdit.Properties.DataSource = par.Entidades;
                id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
                id_EntidadLookUpEdit.Properties.ValueMember = "Key";

                id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
                id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
                id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

                pedidosManager_ParametrosBusquedasBindingSource.DataSource = par;

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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void pedidosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + pedidosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Buscar)) return;
                Validate();
                pedidosManager_SearchResultBindingSource.DataSource = PedidosManager.Buscar(par);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Agregar)) return;

                if (Convert.ToInt32(par.Id_Sucursal) == 0)
                {
                    Sistema.Mensaje("Debe seleccionar una Sucursal.");
                    return;
                }
                Pedidos o = new Pedidos() { Id_Sucursal = par.Id_Sucursal };
                var f = new frmPedidos_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    pedidosManager_SearchResultBindingSource.Add(PedidosManager.Buscar(new PedidosManager.ParametrosBusquedas() { Id_Pedido = o.Id, Id_Sucursal = o.Id_Sucursal }).FirstOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Modificar)) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current;
                    var f = new frmPedidos_AddMod(new Pedidos() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        pedidosManager_SearchResultBindingSource[pedidosManager_SearchResultBindingSource.Position] = PedidosManager.Buscar(new PedidosManager.ParametrosBusquedas() { Id_Pedido = curr.Id, Id_Sucursal = curr.Id_Sucursal }).FirstOrDefault();
                        pedidosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Eliminar)) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;

                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaLiquidacion != null) throw new ValidationException("Solamente se pueden eliminar pedidos sin confirmar.");

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    PedidosManager.Eliminar(new Pedidos() { Id = ((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).Id });
                    pedidosManager_SearchResultBindingSource.RemoveCurrent();
                    pedidosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void ButtonPressedFecha(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.DateEdit)sender).EditValue = null;
            }
        }

        private void ButtonPressedEntidad(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
                id_EntidadLookUpEdit.EditValue = par.Id_Entidad = null;
            }
        }

        private void btnConfirmar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Pedidos", Enums.Accion.Operaciones, "Confirmar Pedidos")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    PedidosManager.Confirmar(new Pedidos() { Id = ((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).Id });

                    pedidosManager_SearchResultBindingSource[pedidosManager_SearchResultBindingSource.Position] = PedidosManager.Buscar(new PedidosManager.ParametrosBusquedas() { Id_Pedido = ((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).Id, Id_Sucursal = ((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).Id_Sucursal }).FirstOrDefault();
                    pedidosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Pedidos", Enums.Accion.Operaciones, "Anular Pedidos")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;

                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaAnulacion != null) throw new ValidationException("El pedido ya se encuentra anulado.");
                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaEntregado != null) throw new ValidationException("El pedido se encuentra entregado.");
                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaLiquidacion == null) throw new ValidationException("No se puede anular un pedido sin confirmar.");

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        PedidosManager.Anular(new Pedidos() { Id = ((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).Id }, f.result);

                        pedidosManager_SearchResultBindingSource[pedidosManager_SearchResultBindingSource.Position] = PedidosManager.Buscar(new PedidosManager.ParametrosBusquedas() { Id_Pedido = ((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).Id, Id_Sucursal = ((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).Id_Sucursal }).FirstOrDefault();
                        pedidosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnGeneraCompVenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Operaciones, "Genera Comprobante de Venta")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;
                var curr = (PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current;
                if (curr.Id_ComprobanteGenerado != null) throw new ValidationException("El pedido ya fue generado.");
                if (curr.FechaLiquidacion == null) throw new ValidationException("No se puede generar a partir de un pedido sin confirmar.");

                frmCotizacionesComprobante f = new frmCotizacionesComprobante();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    int Id = PedidosManager.GenerarVenta(new Pedidos() { Id = curr.Id }, f.Id_Comprobante);
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

        private void btnGeneraPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Operaciones, "Generar PDF")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;
                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaLiquidacion != null) throw new ValidationException("Debe confirmar el pedido antes de generar el PDF.");

                foreach (int x in gridView1.GetSelectedRows())
                    Imprime(((PedidosManager.SearchResult)gridView1.GetRow(x)).Id, true, false);

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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Operaciones, "Enviar por Mail")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;
                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaLiquidacion == null) throw new ValidationException("Debe confirmar el pedido antes de enviar el mail.");

                foreach (int x in gridView1.GetSelectedRows())
                    Imprime(((PedidosManager.SearchResult)gridView1.GetRow(x)).Id, false, true);
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

        public void Imprime(int Id_Pedido, bool GeneraPDF, bool EnviarMail)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Imprimir, "Imprimir Pedidos")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Generando Comprobante");

                string TC = "";
                string Archivo = "";

                Pedidos o = new Pedidos() { Id = Id_Pedido };

                XtraReport report = new XtraReport();

                TalonariosComprobantes r = PedidosManager.Reporte(o);

                if (r.Reporte == "<Ninguno>")
                    report = new xrptPedidoHorizontal();
                else
                    report.LoadLayout(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + r.Reporte);

                var ListDatasource = PedidosManager.ImprimeComprobante(o);

                if (ListDatasource[0].Registro.FechaLiquidacion == null && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ImprimeComprobantesLiquidados)))
                    throw new ValidationException("Antes debe confirmar el comprobante.");

                report.DataSource = ListDatasource;

                if (GeneraPDF || EnviarMail)
                {
                    TC = TipoComprobanteManager.ObtenerTipoComprobante(12);
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

        private void btnCtaCteEntidad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Ver, "Cuenta Corriente de la Entidad")) return;

            if (pedidosManager_SearchResultBindingSource.Current == null) return;

            var curr = (PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current;

            VENET_Tesoreria_UI.frmEntidadesCtaCte f = new VENET_Tesoreria_UI.frmEntidadesCtaCte(curr.Id_TipoEntidad, Convert.ToInt32(curr.Id_Entidad), true);
            f.ShowDialog(this);
        }

        private void btnComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Imprimir, "Imprimir Comprobante")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;
                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaLiquidacion == null) throw new ValidationException("Debe confirmar el pedido antes de imprimir el pedido.");

                foreach (int x in gridView1.GetSelectedRows())
                    Imprime(((PedidosManager.SearchResult)gridView1.GetRow(x)).Id, false, false);
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

        private void btnAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked;
        }

        private void btnEstado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Ver, "Estado del Pedido")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;
                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaLiquidacion == null) throw new ValidationException("Debe confirmar el pedido antes para ver su estado.");
                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaAnulacion != null) throw new ValidationException("El pedido se encuentra anulado.");

                var curr = (PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current;

                frmPedidosEstados f = new frmPedidosEstados(curr.Id);
                f.ShowDialog(this);

                pedidosManager_SearchResultBindingSource[pedidosManager_SearchResultBindingSource.Position] = PedidosManager.Buscar(new PedidosManager.ParametrosBusquedas() { Id_Pedido = curr.Id, Id_Sucursal = curr.Id_Sucursal }).FirstOrDefault();
                pedidosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnAnularEntrega_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Ver, "Anular Entrega")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;
                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaEntregado == null) throw new ValidationException("El pedido no está entregado.");
                if (((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).FechaAnulacion != null) throw new ValidationException("El pedido se encuentra anulado.");

                var curr = (PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current;

                PedidosEstadosManager.Entregar(curr.Id, null);
                PedidosEstadosManager manager = new PedidosEstadosManager(curr.Id);

                pedidosManager_SearchResultBindingSource[pedidosManager_SearchResultBindingSource.Position] = PedidosManager.Buscar(new PedidosManager.ParametrosBusquedas() { Id_Pedido = curr.Id, Id_Sucursal = curr.Id_Sucursal }).FirstOrDefault();
                pedidosManager_SearchResultBindingSource.ResetCurrentItem();

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

        private void btnDescuentos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Operaciones, "Cargar Descuento")) return;

                var curr = (PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current;
                if (curr == null) return;
                if (curr.FechaLiquidacion != null) throw new ValidationException("No se puede modificar porque ya se encuentra confirmado.");

                frmPorcentajeDescuento f = new frmPorcentajeDescuento();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Pedidos c = new Pedidos() { Id = curr.Id };
                    PedidosManager manager = new PedidosManager(c);
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

        private void btnEntregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Operaciones, "Entregar Pedido")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;
                var curr = (PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current;

                if (curr.FechaEntregado != null) throw new ValidationException("El pedido ya está entregado.");

                DateTime Fecha = Sistema.ObtenerFecha();
                frmFecha f = new frmFecha(Fecha, null, Fecha);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    PedidosEstadosManager.Entregar(curr.Id, f.Fecha);
                    PedidosEstadosManager manager = new PedidosEstadosManager(curr.Id);

                    pedidosManager_SearchResultBindingSource[pedidosManager_SearchResultBindingSource.Position] = PedidosManager.Buscar(new PedidosManager.ParametrosBusquedas() { Id_Pedido = curr.Id, Id_Sucursal = curr.Id_Sucursal }).FirstOrDefault();
                    pedidosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnConfirmarParcial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GeneraVentaParcial();
        }

        private void GeneraVentaParcial()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Pedidos", Enums.Accion.Operaciones, "Genera Comprobante de Venta Parcial")) return;

                if (pedidosManager_SearchResultBindingSource.Current == null) return;
                var curr = (PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current;

                if (curr.Id_ComprobanteGenerado != null) throw new ValidationException("El pedido ya fue generado.");
                if (curr.FechaLiquidacion == null) throw new ValidationException("No se puede generar a partir de un pedido sin confirmar.");

                frmPedidosConfirmacionParcial fp = new frmPedidosConfirmacionParcial(((PedidosManager.SearchResult)pedidosManager_SearchResultBindingSource.Current).Id);
                if (fp.ShowDialog() == DialogResult.OK)
                {
                    frmCotizacionesComprobante f = new frmCotizacionesComprobante();
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        int Id = PedidosManager.GenerarVentaParcial(new Pedidos() { Id = curr.Id }, f.Id_Comprobante, fp.ListaAProcesar, fp.TodoProcesado);
                        pedidosManager_SearchResultBindingSource[pedidosManager_SearchResultBindingSource.Position] = PedidosManager.Buscar(new PedidosManager.ParametrosBusquedas() { Id_Pedido = curr.Id, Id_Sucursal = curr.Id_Sucursal }).FirstOrDefault();
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

    }
}
