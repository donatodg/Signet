namespace VENET_General_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing.Printing;
    using System.IO;
    using System.Windows.Forms;
    using DevExpress.XtraReports.UI;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmTalonariosComprobantes_AddMod : MultiForm, IDisposable
    {
        private TalonariosComprobantesManager manager;

        public List<TalonariosComprobantesDetalle> DetalleList = new List<TalonariosComprobantesDetalle>();

        public frmTalonariosComprobantes_AddMod(TalonariosComprobantes o, Int32 Id_Empresa)
        {
            InitializeComponent();
            manager = new TalonariosComprobantesManager(o, Id_Empresa);
        }

        private void frmTalonariosComprobantes_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                    ImpresorascomboBoxEdit.Properties.Items.Add(strPrinter);

                CargarComboReportes();

                talonariosComprobantesManagerBindingSource.DataSource = manager;

                ImpresorascomboBoxEdit.Text = manager.Talonario.Impresora;

                id_PuntoVentaLookUpEdit.Properties.DataSource = manager.PuntosVentas;
                id_PuntoVentaLookUpEdit.Properties.DisplayMember = "PuntoVenta";
                id_PuntoVentaLookUpEdit.Properties.ValueMember = "Id";

                id_ComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobanteConTalonarios;
                id_ComprobanteLookUpEdit.Properties.DisplayMember = "Name";
                id_ComprobanteLookUpEdit.Properties.ValueMember = "Key";

                id_DepositoLookUpEdit.Properties.DataSource = Sistema.Depositos;
                id_DepositoLookUpEdit.Properties.DisplayMember = "Name";
                id_DepositoLookUpEdit.Properties.ValueMember = "Key";

                DetalleList.Clear();

                if (manager.Talonario.Detalle != null)
                {
                    foreach (TalonariosComprobantesDetalle o in manager.Talonario.Detalle)
                    {
                        TalonariosComprobantesDetalle x = new TalonariosComprobantesDetalle()
                        {
                            Id = o.Id,
                            FechaVencimiento = o.FechaVencimiento,
                            Id_TalonarioComprobante = o.Id_TalonarioComprobante,
                            NroActual = o.NroActual,
                            NroDesde = o.NroDesde,
                            NroHasta = o.NroHasta,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        DetalleList.Add(x);
                    }
                }
                detalleBindingSource.DataSource = DetalleList;

                id_AFIP_ComprobanteLookUpEdit.Properties.DataSource = manager.TiposComprobantesAFIP;
                id_AFIP_ComprobanteLookUpEdit.Properties.DisplayMember = "Name";
                id_AFIP_ComprobanteLookUpEdit.Properties.ValueMember = "Key";

                electronicoCheckEdit_CheckStateChanged(null, null);

            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void CargarComboReportes()
        {
            List<string> ListaReportes = new List<string>();
            ListaReportes.Add("<Ninguno>");

            string path = Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas);
            //string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Reportes\";

            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                DirectoryInfo di = new DirectoryInfo(path);

                foreach (FileInfo fi in di.GetFiles("*.repx"))
                {
                    ListaReportes.Add(fi.Name);
                }
            }
            catch (Exception) { }

            reporteLookUpEdit.Properties.DataSource = ListaReportes;
        }

        private void frmTalonariosComprobantes_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                Validate();
                manager.Talonario.Impresora = ImpresorascomboBoxEdit.Text;
                manager.Save();
                DialogResult = DialogResult.OK;
                Close();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Agregar()
        {
            try
            {
                TalonariosComprobantesDetalle o = new TalonariosComprobantesDetalle();
                var f = new frmTalonariosComprobantesDetalle_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (var t in manager.Talonario.Detalle)
                    {
                        if (o.NroDesde >= t.NroDesde && o.NroDesde <= t.NroHasta && t.UserDel == null)
                            throw new ValidationException("Los números ingresados ya existen.");
                        if (o.NroHasta >= t.NroHasta && o.NroHasta <= t.NroDesde && t.UserDel == null)
                            throw new ValidationException("Los números ingresados ya existen.");
                    }
                    manager.Talonario.Detalle.Add(o);
                    DetalleList.Add(o);

                    gridControl1.RefreshDataSource();
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
                if (detalleBindingSource.Current == null) return;
                {

                    TalonariosComprobantesDetalle o = new TalonariosComprobantesDetalle()
                    {
                        Id = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).Id,
                        Id_TalonarioComprobante = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).Id_TalonarioComprobante,
                        NroActual = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).NroActual,
                        NroDesde = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).NroDesde,
                        NroHasta = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).NroHasta,
                        TalonarioComprobante = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).TalonarioComprobante,
                        FechaVencimiento = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).FechaVencimiento,
                        FechaAdd = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).FechaAdd,
                        FechaMod = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).FechaMod,
                        FechaDel = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).FechaDel,
                        UserAdd = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).UserAdd,
                        UserMod = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).UserMod,
                        UserDel = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).UserDel
                    };

                    var f = new frmTalonariosComprobantesDetalle_AddMod(o);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        detalleBindingSource[detalleBindingSource.Position] = o;

                        foreach (var t in manager.Talonario.Detalle)
                        {
                            if (t.Id == o.Id)
                            {
                                t.NroDesde = o.NroDesde;
                                t.NroHasta = o.NroHasta;
                                t.NroActual = o.NroActual;
                                t.FechaVencimiento = o.FechaVencimiento;
                            }

                            if (o.Id != t.Id && o.NroDesde >= t.NroDesde && o.NroDesde <= t.NroHasta && t.UserDel == null)
                                throw new ValidationException("Los números ingresados ya existen.");
                            if (o.Id != t.Id && o.NroHasta <= t.NroHasta && o.NroHasta >= t.NroDesde && t.UserDel == null)
                                throw new ValidationException("Los números ingresados ya existen.");
                        }

                        gridView1.RefreshData();
                        gridControl1.RefreshDataSource();

                        detalleBindingSource.EndEdit();
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
                if (detalleBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    if (DetalleList[detalleBindingSource.Position].Id == 0)
                    {
                        int i = 0;
                        int ii = detalleBindingSource.Position;

                        TalonariosComprobantesDetalle o = new TalonariosComprobantesDetalle();

                        foreach (TalonariosComprobantesDetalle rd in manager.Talonario.Detalle)
                        {
                            if (ii == i)
                            {
                                o = rd;
                                break;
                            }
                            i++;
                        }

                        DetalleList.Remove(DetalleList[detalleBindingSource.Position]);
                        manager.Talonario.Detalle.Remove(o);
                        gridView1.RefreshData();
                    }
                    else
                    {
                        TalonariosComprobantesDetalle o = (TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position];
                        TalonariosComprobantesDetalleManager.Eliminar(new TalonariosComprobantesDetalle() { Id = ((TalonariosComprobantesDetalle)detalleBindingSource[detalleBindingSource.Position]).Id });

                        DetalleList.Remove(DetalleList[detalleBindingSource.Position]);
                        gridView1.RefreshData();
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(VENET_Comun.Enums.Modulos.General, "Diseñador de Reportes", VENET_Comun.Enums.Accion.Ingresar)) return;

                XtraReport report = new XtraReport();

                if (reporteLookUpEdit.EditValue.ToString() != "<Ninguno>")
                    report = XtraReport.FromFile(Parametro.ObtenerValor(Parametro.Param.RutaOriginalesComprobantesVentas) + reporteLookUpEdit.EditValue, true);
                //report = XtraReport.FromFile(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Reportes\" + reporteLookUpEdit.EditValue, true);

               

                ReportDesignTool dt = new ReportDesignTool(report);
                dt.ShowRibbonDesignerDialog();

                CargarComboReportes();
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

        private void electronicoCheckEdit_CheckStateChanged(object sender, EventArgs e)
        {
            id_AFIP_ComprobanteLookUpEdit.Enabled = electronicoCheckEdit.Checked;
            //if (id_AFIP_ComprobanteLookUpEdit.Enabled && id_AFIP_ComprobanteLookUpEdit.Text == "") id_AFIP_ComprobanteLookUpEdit.ItemIndex = 0;
        }

    }
}
