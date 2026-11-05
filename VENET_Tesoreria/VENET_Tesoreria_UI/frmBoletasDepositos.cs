namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmBoletasDepositos : MultiForm
    {
        private BoletasDepositosManager.ParametrosBusquedas par = new BoletasDepositosManager.ParametrosBusquedas();

        public frmBoletasDepositos()
        {
            InitializeComponent();
        }

        private void frmBoletasDepositos_Load(object sender, EventArgs e)
        {
            id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
            id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

            id_ProvFinancieroCuentaLookUpEdit.Properties.DataSource = par.CuentasPF;
            id_ProvFinancieroCuentaLookUpEdit.Properties.ValueMember = "Key";
            id_ProvFinancieroCuentaLookUpEdit.Properties.DisplayMember = "Name";

            boletasDepositosManager_ParametrosBusquedasBindingSource.DataSource = par;

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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "BoletasDepositos", Enums.Accion.Imprimir)) return;
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

        private void boletasDepositosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + boletasDepositosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "BoletasDepositos", Enums.Accion.Buscar)) return;

                Validate();
                boletasDepositosManager_SearchResultBindingSource.DataSource = BoletasDepositosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "BoletasDepositos", Enums.Accion.Agregar)) return;

            BoletasDepositos o = new BoletasDepositos() { Id_Sucursal = Convert.ToInt32(par.Id_Sucursal) };
            var f = new frmBoletasDepositos_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                boletasDepositosManager_SearchResultBindingSource.Add(BoletasDepositosManager.Buscar(new BoletasDepositosManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "BoletasDepositos", Enums.Accion.Modificar)) return;

                if (boletasDepositosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (BoletasDepositosManager.SearchResult)boletasDepositosManager_SearchResultBindingSource.Current;
                    var f = new frmBoletasDepositos_AddMod(new BoletasDepositos() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        boletasDepositosManager_SearchResultBindingSource[boletasDepositosManager_SearchResultBindingSource.Position] = BoletasDepositosManager.Buscar(new BoletasDepositosManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        boletasDepositosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "BoletasDepositos", Enums.Accion.Eliminar)) return;

                if (boletasDepositosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    BoletasDepositosManager.Eliminar(new BoletasDepositos() { Id = ((BoletasDepositosManager.SearchResult)boletasDepositosManager_SearchResultBindingSource.Current).Id });
                    boletasDepositosManager_SearchResultBindingSource.RemoveCurrent();
                    boletasDepositosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnConfirmar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "BoletasDepositos", Enums.Accion.Operaciones, "Confirmar Boleta de Depósito")) return;

                if (boletasDepositosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    BoletasDepositosManager.Confirmar(new BoletasDepositos() { Id = ((BoletasDepositosManager.SearchResult)boletasDepositosManager_SearchResultBindingSource.Current).Id });

                    boletasDepositosManager_SearchResultBindingSource[boletasDepositosManager_SearchResultBindingSource.Position] = BoletasDepositosManager.Buscar(new BoletasDepositosManager.ParametrosBusquedas() { Id = ((BoletasDepositosManager.SearchResult)boletasDepositosManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                    boletasDepositosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "BoletasDepositos", Enums.Accion.Operaciones, "Anular Boleta de Depósito")) return;

                if (boletasDepositosManager_SearchResultBindingSource.Current == null) return;

                if (((BoletasDepositosManager.SearchResult)boletasDepositosManager_SearchResultBindingSource.Current).FechaAnulacion != null) throw new ValidationException("La boleta ya se encuentra anulada.");

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        BoletasDepositosManager.Anular(new BoletasDepositos() { Id = ((BoletasDepositosManager.SearchResult)boletasDepositosManager_SearchResultBindingSource.Current).Id }, f.result);

                        boletasDepositosManager_SearchResultBindingSource[boletasDepositosManager_SearchResultBindingSource.Position] = BoletasDepositosManager.Buscar(new BoletasDepositosManager.ParametrosBusquedas() { Id = ((BoletasDepositosManager.SearchResult)boletasDepositosManager_SearchResultBindingSource.Current).Id }).FirstOrDefault();
                        boletasDepositosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modificar();
        }

    }
}
