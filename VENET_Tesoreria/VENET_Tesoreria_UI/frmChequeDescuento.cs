namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmChequeDescuento : MultiForm, IForm
    {
        private ChequeDescuentoManager.ParametrosBusquedas par = new ChequeDescuentoManager.ParametrosBusquedas();

        public frmChequeDescuento()
        {
            InitializeComponent();
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
        }

        private void frmChequeDescuento_Load(object sender, EventArgs e)
        {
            id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
            id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

            chequeDescuentoManager_ParametrosBusquedasBindingSource.DataSource = par;

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

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequeDescuento", Enums.Accion.Imprimir)) return;
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

        private void btnAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void chequeDescuentoManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + chequeDescuentoManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequeDescuento", Enums.Accion.Buscar)) return;
                Validate();
                chequeDescuentoManager_SearchResultBindingSource.DataSource = ChequeDescuentoManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequeDescuento", Enums.Accion.Agregar)) return;
            ChequesDescuento o = new ChequesDescuento() { Id_Sucursal = Convert.ToInt32(par.Id_Sucursal) };
            var f = new frmChequeDescuento_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                chequeDescuentoManager_SearchResultBindingSource.Add(ChequeDescuentoManager.Buscar(new ChequeDescuentoManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequeDescuento", Enums.Accion.Modificar)) return;
                if (chequeDescuentoManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ChequeDescuentoManager.SearchResult)chequeDescuentoManager_SearchResultBindingSource.Current;


                    var f = new frmChequeDescuento_AddMod(new ChequesDescuento() { Id = curr.Id });
                    DialogResult r = f.ShowDialog(this);
                    if (r == DialogResult.OK)
                    {
                        chequeDescuentoManager_SearchResultBindingSource[chequeDescuentoManager_SearchResultBindingSource.Position] = ChequeDescuentoManager.Buscar(new ChequeDescuentoManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        chequeDescuentoManager_SearchResultBindingSource.ResetCurrentItem();
                    }
                    if (r == DialogResult.Cancel)
                    {
                        Buscar();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequeDescuento", Enums.Accion.Eliminar)) return;
                if (chequeDescuentoManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ChequeDescuentoManager.Eliminar(new ChequesDescuento() { Id = ((ChequeDescuentoManager.SearchResult)chequeDescuentoManager_SearchResultBindingSource.Current).Id });
                    chequeDescuentoManager_SearchResultBindingSource.RemoveCurrent();
                    chequeDescuentoManager_SearchResultBindingSource.ResetBindings(false);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequeDescuento", Enums.Accion.Operaciones, "Confirmar Descuento")) return;

                if (chequeDescuentoManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    ChequeDescuentoManager.Confirmar(new ChequesDescuento() { Id = ((ChequeDescuentoManager.SearchResult)chequeDescuentoManager_SearchResultBindingSource.Current).Id });

                    chequeDescuentoManager_SearchResultBindingSource[chequeDescuentoManager_SearchResultBindingSource.Position] = ChequeDescuentoManager.Buscar(new ChequeDescuentoManager.ParametrosBusquedas() { Id = ((ChequeDescuentoManager.SearchResult)chequeDescuentoManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                    chequeDescuentoManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ChequeDescuento", Enums.Accion.Operaciones, "Anular Descuento")) return;

                if (chequeDescuentoManager_SearchResultBindingSource.Current == null) return;

                if (((ChequeDescuentoManager.SearchResult)chequeDescuentoManager_SearchResultBindingSource.Current).FechaAnulacion != null) throw new ValidationException("El descuento ya se encuentra anulado.");

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        ChequeDescuentoManager.Anular(new ChequesDescuento() { Id = ((ChequeDescuentoManager.SearchResult)chequeDescuentoManager_SearchResultBindingSource.Current).Id }, f.result);

                        chequeDescuentoManager_SearchResultBindingSource[chequeDescuentoManager_SearchResultBindingSource.Position] = ChequeDescuentoManager.Buscar(new ChequeDescuentoManager.ParametrosBusquedas() { Id = ((ChequeDescuentoManager.SearchResult)chequeDescuentoManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                        chequeDescuentoManager_SearchResultBindingSource.ResetCurrentItem();
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

        public void IdSeleccionado(int Id)
        {
            //id_EntidadTextEdit.Text = Id.ToString();
            //par.Id_Entidad = Id;

            Validate();
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modificar();
        }

        public void IdsSeleccionados(List<int> Ids)
        {
            throw new NotImplementedException();
        }
    }
}
