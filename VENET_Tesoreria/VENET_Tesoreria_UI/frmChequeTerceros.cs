namespace VENET_Tesoreria_UI
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraPrinting;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing.Printing;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmChequeTerceros : MultiForm
    {
        private ChequeTercerosManager.ParametrosBusquedas par = new ChequeTercerosManager.ParametrosBusquedas();

        public frmChequeTerceros()
        {
            InitializeComponent();
        }

        public frmChequeTerceros(ChequeTercerosManager.ParametrosBusquedas parametros, bool Busqueda)
        {
            InitializeComponent();
            par = parametros;
            if (Busqueda) Buscar();
        }

        public frmChequeTerceros(bool EnDescuento)
        {
            InitializeComponent();
            if (!EnDescuento) par.EnDescuento = 0;
        }

        private void frmChequeTerceros_Load(object sender, EventArgs e)
        {
            try
            {
                gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;

                estadoLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ChequesEstados));
                estadoLookUpEdit.Properties.DisplayMember = "Value";
                estadoLookUpEdit.Properties.ValueMember = "Key";

                id_EntidadBancariaLookUpEdit.Properties.DataSource = par.Bancos;
                id_EntidadBancariaLookUpEdit.Properties.DisplayMember = "Descripcion";
                id_EntidadBancariaLookUpEdit.Properties.ValueMember = "Codigo";

                id_FirmanteLookUpEdit.Properties.DataSource = par.Firmantes;
                id_FirmanteLookUpEdit.Properties.DisplayMember = "Nombre";
                id_FirmanteLookUpEdit.Properties.ValueMember = "Id";

                id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
                id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
                id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

                chequeTercerosManager_ParametrosBusquedasBindingSource.DataSource = par;

                id_SucursalLookUpEdit.ItemIndex = 0;
                if (id_SucursalLookUpEdit.EditValue != DBNull.Value)
                    par.Id_Sucursal = (int)id_SucursalLookUpEdit.EditValue;

                if (par.EnDescuento == 0) Buscar();
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

        private void btnAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Imprimir)) return;
            //gridControl1.ShowRibbonPrintPreview();

            using (PrintableComponentLink pcl = new PrintableComponentLink { PrintingSystem = new PrintingSystem() })
            {
                pcl.Margins.Left = 50;
                pcl.Margins.Right = 50;
                pcl.Margins.Top = 80;
                pcl.Margins.Bottom = 50;
                pcl.Landscape = true;
                pcl.PaperKind = (DevExpress.Drawing.Printing.DXPaperKind)PaperKind.A4;
                pcl.EnablePageDialog = true;
                pcl.Component = gridControl1;

                PageHeaderFooter phf = pcl.PageHeaderFooter as PageHeaderFooter;

                phf.Header.Content.Clear();

                //phf.Header.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
                phf.Header.LineAlignment = BrickAlignment.Center;
                //phf.Header.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);

                pcl.CreateDocument();
                pcl.ShowRibbonPreview(UserLookAndFeel.Default);
                pcl.PrintingSystem.ExecCommand(PrintingSystemCommand.Scale, new object[] { 1 });
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modalidad();
        }

        private void Modalidad()
        {
            if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

            IForm formInterface = Owner as IForm;

            if (formInterface != null)
            {
                if (gridView1.GetSelectedRows().Count() > 1)
                    formInterface.IdsSeleccionados(gridView1.GetSelectedRows().ToList().Select(x => ((ChequeTercerosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList());
                else
                    formInterface.IdSeleccionado(((ChequeTercerosManager.SearchResult)chequeTercerosManager_SearchResultBindingSource.Current).Id);

                Close();

            }
            else Modificar();
        }

        private void chequeTercerosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + chequeTercerosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Buscar)) return;
                Validate();
                chequeTercerosManager_SearchResultBindingSource.DataSource = ChequeTercerosManager.Buscar(par);
                gridView1.ExpandAllGroups();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Agregar)) return;
            ChequesTerceros o = new ChequesTerceros();
            frmChequeTerceros_AddMod f = new frmChequeTerceros_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                chequeTercerosManager_SearchResultBindingSource.Add(ChequeTercerosManager.Buscar(new ChequeTercerosManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Modificar)) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ChequeTercerosManager.SearchResult)chequeTercerosManager_SearchResultBindingSource.Current;

                //if (curr.Id_Recibo > 0)
                //{
                //    Sistema.Mensaje("El Cheque ingreso por un recibo, debe modificarse por el recibo.");
                //    return;
                //}

                frmChequeTerceros_AddMod f = new frmChequeTerceros_AddMod(new ChequesTerceros() { Id = curr.Id });
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    chequeTercerosManager_SearchResultBindingSource[chequeTercerosManager_SearchResultBindingSource.Position] = ChequeTercerosManager.Buscar(new ChequeTercerosManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                    chequeTercerosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Eliminar)) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ChequeTercerosManager.Eliminar(new ChequesTerceros() { Id = ((ChequeTercerosManager.SearchResult)chequeTercerosManager_SearchResultBindingSource.Current).Id });
                    chequeTercerosManager_SearchResultBindingSource.RemoveCurrent();
                    chequeTercerosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnRecibo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Ver, "Ver Recibo")) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ChequeTercerosManager.SearchResult)chequeTercerosManager_SearchResultBindingSource.Current;

                if (curr.Id_Recibo == null) return;

                Recibos o = new Recibos() { Id = Convert.ToInt32(curr.Id_Recibo) };
                frmRecibos_AddMod f = new frmRecibos_AddMod(o);
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

        private void btnDepositar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Operaciones, "Depositar Cheques")) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea depositar el/los item/s seleccionado/s?", "Atención..."))
                {
                    string r = ChequeTercerosManager.Depositar(gridView1.GetSelectedRows().ToList().Select(x => ((ChequeTercerosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList());

                    if (r != "")
                        Sistema.Mensaje(r);
                }

                Buscar();
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

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modalidad();
        }

        private void btnBoletaDeposito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Ver, "Ver Boleta de Depósito")) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ChequeTercerosManager.SearchResult)chequeTercerosManager_SearchResultBindingSource.Current;

                if (curr.Id_BoletaDeposito == null) return;

                BoletasDepositos o = new BoletasDepositos() { Id = Convert.ToInt32(curr.Id_BoletaDeposito) };
                frmBoletasDepositos_AddMod f = new frmBoletasDepositos_AddMod(o);
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

        private void btnBoletaDescuento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Ver, "Ver Boleta de Descuento")) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ChequeTercerosManager.SearchResult)chequeTercerosManager_SearchResultBindingSource.Current;

                if (curr.Id_Descuento == null) return;

                ChequesDescuento o = new ChequesDescuento() { Id = Convert.ToInt32(curr.Id_Descuento) };
                frmChequeDescuento_AddMod f = new frmChequeDescuento_AddMod(o);
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

        private void btnRechazar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Operaciones, "Rechazar Cheques")) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea rechazar el/los item/s seleccionado/s?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    //frmChequesTercerosRechazo f = new frmChequesTercerosRechazo();
                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string r = ChequeTercerosManager.Rechazar(gridView1.GetSelectedRows().ToList().Select(x => ((ChequeTercerosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList(), f.result);
                        //string r = ChequeTercerosManager.Rechazar(gridView1.GetSelectedRows().ToList().Select(x => ((ChequeTercerosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList(), f.Motivo, f.Importe);

                        if (r != "")
                            Sistema.Mensaje(r);
                    }
                }

                Buscar();
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

        private void btnDescuento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Operaciones, "Descontar Cheques")) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea descontar el/los item/s seleccionado/s?", "Atención..."))
                {
                    int IdSucursal;
                    if (par.Id_Sucursal == null) IdSucursal = Sistema.Sucursales.First().Id_Sucursal; else IdSucursal = (int)par.Id_Sucursal;
                    ChequesDescuento o = new ChequesDescuento() { Id_Sucursal = IdSucursal };
                    frmChequeDescuento_AddMod f = new frmChequeDescuento_AddMod(o);

                    foreach (int x in gridView1.GetSelectedRows())
                        f.IdSeleccionado(((ChequeTercerosManager.SearchResult)gridView1.GetRow(x)).Id);

                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        if (Sistema.MensajeSiNo("¿Desea Confirmar el descuento ingresado?", "Confirmar") == true)
                            ChequeDescuentoManager.Confirmar(o);

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

        private void btnAnularDeposito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Operaciones, "Anular Depósito Cheques")) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea anular depósito de el/los item/s seleccionado/s?", "Atención..."))
                {
                    string r = ChequeTercerosManager.AnularDeposito(gridView1.GetSelectedRows().ToList().Select(x => ((ChequeTercerosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList());

                    if (r != "")
                        Sistema.Mensaje(r);
                }
                Buscar();
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

        private void btnAnularRechazo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Operaciones, "Anular Rechazo Cheques")) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea anular rechazo de el/los item/s seleccionado/s?", "Atención..."))
                {
                    string r = ChequeTercerosManager.AnularRechazo(gridView1.GetSelectedRows().ToList().Select(x => ((ChequeTercerosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList());

                    if (r != "")
                        Sistema.Mensaje(r);
                }
                Buscar();
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

        private void btnOP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesTercero", Enums.Accion.Ver, "Ver Orden de Pago")) return;
                if (chequeTercerosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ChequeTercerosManager.SearchResult)chequeTercerosManager_SearchResultBindingSource.Current;

                if (curr.Id_OrdenPago == null) return;

                OrdenesPago o = new OrdenesPago() { Id = Convert.ToInt32(curr.Id_OrdenPago) };
                frmOrdenesPago_AddMod f = new frmOrdenesPago_AddMod(o);
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
    }
}
