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

    public partial class frmChequesPropios : MultiForm
    {
        private ChequePropiosManager.ParametrosBusquedas par = new ChequePropiosManager.ParametrosBusquedas();

        public frmChequesPropios()
        {
            InitializeComponent();
        }

        public frmChequesPropios(ChequePropiosManager.ParametrosBusquedas parametros, bool Busqueda)
        {
            InitializeComponent();
            par = parametros;
            if (Busqueda) Buscar();
        }

        private void frmChequePropios_Load(object sender, EventArgs e)
        {
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;

            estadoLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ChequesEstados));
            estadoLookUpEdit.Properties.DisplayMember = "Value";
            estadoLookUpEdit.Properties.ValueMember = "Key";

            id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
            id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

            id_ProvFinancierosCuentaLookUpEdit.Properties.DataSource = ChequePropiosManager.ProveedorFinancieroCuentas;
            id_ProvFinancierosCuentaLookUpEdit.Properties.DisplayMember = "Name";
            id_ProvFinancierosCuentaLookUpEdit.Properties.ValueMember = "Key";

            chequePropiosManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_SucursalLookUpEdit.ItemIndex = 0;
            if (id_SucursalLookUpEdit.EditValue != DBNull.Value)
                par.Id_Sucursal = (int)id_SucursalLookUpEdit.EditValue;

            id_ProvFinancierosCuentaLookUpEdit.ItemIndex = 0;
            if (id_ProvFinancierosCuentaLookUpEdit.EditValue != DBNull.Value)
                par.Id_ProvFinancierosCuenta = (int)id_ProvFinancierosCuentaLookUpEdit.EditValue;
            
            //if (par.EnDescuento == 0) Buscar();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Imprimir)) return;
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
            if (chequePropiosManager_SearchResultBindingSource.Current == null) return;

            IForm formInterface = Owner as IForm;

            if (formInterface != null)
            {
                if (gridView1.GetSelectedRows().Count() > 1)
                    formInterface.IdsSeleccionados(gridView1.GetSelectedRows().ToList().Select(x => ((ChequePropiosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList());
                else
                    formInterface.IdSeleccionado(((ChequePropiosManager.SearchResult)chequePropiosManager_SearchResultBindingSource.Current).Id);

                Close();

            }
            else Modificar();
        }

        private void chequePropiosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + chequePropiosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Buscar)) return;
                Validate();
                chequePropiosManager_SearchResultBindingSource.DataSource = ChequePropiosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Agregar)) return;
            ChequesPropios o = new ChequesPropios();
            frmChequesPropios_AddMod f = new frmChequesPropios_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                chequePropiosManager_SearchResultBindingSource.Add(ChequePropiosManager.Buscar(new ChequePropiosManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Modificar)) return;
                if (chequePropiosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ChequePropiosManager.SearchResult)chequePropiosManager_SearchResultBindingSource.Current;

                frmChequesPropios_AddMod f = new frmChequesPropios_AddMod(new ChequesPropios() { Id = curr.Id });
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    chequePropiosManager_SearchResultBindingSource[chequePropiosManager_SearchResultBindingSource.Position] = ChequePropiosManager.Buscar(new ChequePropiosManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                    chequePropiosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Eliminar)) return;
                if (chequePropiosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ChequePropiosManager.Eliminar(new ChequesPropios() { Id = ((ChequePropiosManager.SearchResult)chequePropiosManager_SearchResultBindingSource.Current).Id });
                    chequePropiosManager_SearchResultBindingSource.RemoveCurrent();
                    chequePropiosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnDepositar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Operaciones, "Depositar Cheques")) return;
                if (chequePropiosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea depositar el/los item/s seleccionado/s?", "Atención..."))
                {
                    string r = ChequePropiosManager.Depositar(gridView1.GetSelectedRows().ToList().Select(x => ((ChequePropiosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList());

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

        private void btnRechazar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Operaciones, "Rechazar Cheques")) return;
                if (chequePropiosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea rechazar el/los item/s seleccionado/s?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    //frmChequesPropiosRechazo f = new frmChequesPropiosRechazo();
                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string r = ChequePropiosManager.Rechazar(gridView1.GetSelectedRows().ToList().Select(x => ((ChequePropiosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList(), f.result);
                        //string r = ChequePropiosManager.Rechazar(gridView1.GetSelectedRows().ToList().Select(x => ((ChequePropiosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList(), f.Motivo, f.Importe);

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

        //private void btnDescuento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Operaciones, "Descontar Cheques")) return;
        //        if (chequePropiosManager_SearchResultBindingSource.Current == null) return;

        //        if (Sistema.MensajeSiNo("¿Desea descontar el/los item/s seleccionado/s?", "Atención..."))
        //        {
        //            int IdSucursal;
        //            if (par.Id_Sucursal == null) IdSucursal = Sistema.Sucursales.First().Id_Sucursal; else IdSucursal = (int)par.Id_Sucursal;
        //            ChequesDescuento o = new ChequesDescuento() { Id_Sucursal = IdSucursal };
        //            frmChequeDescuento_AddMod f = new frmChequeDescuento_AddMod(o);

        //            foreach (int x in gridView1.GetSelectedRows())
        //                f.IdSeleccionado(((ChequePropiosManager.SearchResult)gridView1.GetRow(x)).Id);

        //            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //                if (Sistema.MensajeSiNo("¿Desea Confirmar el descuento ingresado?", "Confirmar") == true)
        //                    ChequeDescuentoManager.Confirmar(o);

        //            Buscar();
        //        }
        //    }
        //    catch (ValidationException exv)
        //    {
        //        Sistema.Mensaje(exv.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Sistema.MensajeError(ex);
        //    }
        //}

        private void btnAnularDeposito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Operaciones, "Anular Depósito Cheques")) return;
                if (chequePropiosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea anular depósito de el/los item/s seleccionado/s?", "Atención..."))
                {
                    string r = ChequePropiosManager.AnularDeposito(gridView1.GetSelectedRows().ToList().Select(x => ((ChequePropiosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList());

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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Operaciones, "Anular Rechazo Cheques")) return;
                if (chequePropiosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea anular rechazo de el/los item/s seleccionado/s?", "Atención..."))
                {
                    string r = ChequePropiosManager.AnularRechazo(gridView1.GetSelectedRows().ToList().Select(x => ((ChequePropiosManager.SearchResult)gridView1.GetRow(x)).Id).Distinct().ToList());

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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequesPropios", Enums.Accion.Ver, "Ver Orden de Pago")) return;
                if (chequePropiosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ChequePropiosManager.SearchResult)chequePropiosManager_SearchResultBindingSource.Current;

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
