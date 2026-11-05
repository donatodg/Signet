namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmChequeDescuento_AddMod : MultiForm, IDisposable, IForm
    {
        private ChequeDescuentoManager manager;
        public List<ChequesDescuentoDetalle> DetalleList = new List<ChequesDescuentoDetalle>();
        private int _IdEspecie;

        public frmChequeDescuento_AddMod(ChequesDescuento o)
        {
            InitializeComponent();
            manager = new ChequeDescuentoManager(o);
        }

        private void frmChequeDescuento_AddMod_Load(object sender, EventArgs e)
        {
            if (Sistema.CentrosCostos.Count == 0)
                throw new ValidationException("El usuario no cuenta con centros de costos asignados.");

            if (manager.CuentasPF.Count == 0)
                throw new ValidationException("El sistema no posee cuentas de proveedor financiero.");

            chequeDescuentoManagerBindingSource.DataSource = manager;

            id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
            id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

            id_ProvFinancieroCuentaLookUpEdit.Properties.DataSource = manager.CuentasPF;
            id_ProvFinancieroCuentaLookUpEdit.Properties.DisplayMember = "Name";
            id_ProvFinancieroCuentaLookUpEdit.Properties.ValueMember = "Key";

            DetalleList.Clear();

            if (manager.Descuento.Detalle != null)
            {
                foreach (ChequesDescuentoDetalle o in manager.Descuento.Detalle)
                {
                    id_ProvFinancieroCuentaLookUpEdit.Enabled = false;

                    ChequesDescuentoDetalle x = new ChequesDescuentoDetalle()
                    {
                        Id = o.Id,
                        Banco = o.Banco,
                        Sucursal = o.Sucursal,
                        NroCheque = o.NroCheque,
                        NroCuenta = o.NroCuenta,
                        ChequeDescuento = o.ChequeDescuento,
                        Id_ChequeDescuento = o.Id_ChequeDescuento,
                        Id_Documento = o.Id_Documento,
                        Importe = o.Importe,
                        FechaAdd = o.FechaAdd,
                        FechaMod = o.FechaMod,
                        UserAdd = o.UserAdd,
                        UserMod = o.UserMod
                    };
                    DetalleList.Add(x);
                }
            }

            detalleBindingSource.DataSource = DetalleList;

            if (manager.Descuento.Id == 0)
            {
                id_CentroCostoLookUpEdit.ItemIndex = 0;
                manager.Descuento.Id_CentroCosto = (int)id_CentroCostoLookUpEdit.EditValue;

                id_ProvFinancieroCuentaLookUpEdit.ItemIndex = 0;
                manager.Descuento.Id_ProvFinancieroCuenta = (int)id_ProvFinancieroCuentaLookUpEdit.EditValue;
                _IdEspecie = manager.Id_Especie;
            }

            if (manager.Descuento.FechaLiquidacion != null || manager.Descuento.FechaAnulacion != null)
            {
                btnAceptar.Enabled = false;
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
            }
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Agregar()
        {
            try
            {
                id_ProvFinancieroCuentaLookUpEdit.Enabled = false;
                frmChequeTerceros f = new frmChequeTerceros(false);
                f.Owner = this;
                f.ShowDialog(this);
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
                    //if (DetalleList[detalleBindingSource.Position].Id != 0)
                    //    manager.EliminarDetalle((ChequesDescuentoDetalle)detalleBindingSource[detalleBindingSource.Position]);

                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    //ChequesDescuentoDetalle o = new ChequesDescuentoDetalle();

                    foreach (ChequesDescuentoDetalle rd in manager.Descuento.Detalle)
                    {
                        if (ii == i)
                        {
                            //o = rd;
                            rd.Borrado = true;
                            break;
                        }
                        i++;
                    }

                    //if (DetalleList[detalleBindingSource.Position].Id == 0)
                    //    o.Borrado = true;

                    DetalleList.Remove(DetalleList[detalleBindingSource.Position]);
                    gridView1.RefreshData();
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
            try
            {
                ChequesTerceros c = ChequeTercerosManager.Reload(new ChequesTerceros() { Id = Id });

                //********************************************************
                // Validaciones
                if (c.Id_Especie != _IdEspecie) throw new ValidationException("El documento es de otra especie del proveedor financiero.");
                if (c.Id_Descuento != null) throw new ValidationException("El documento ya se encuentra en una liquidación de descuento.");
                if (c.FechaRechazado != null) throw new ValidationException("El documento fue rechazado.");
                if (c.FechaDepositado != null) throw new ValidationException("El documento fue depositado.");
                //if (manager.Descuento.Detalle.Count > 0)
                foreach (ChequesDescuentoDetalle d in manager.Descuento.Detalle)
                    if (d.Id_Documento == Id)
                        throw new ValidationException("El documento ya se encuentra en la liquidación de descuento.");
                //********************************************************

                DateTime f = Sistema.ObtenerFecha();
                int u = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CurrentUserId"]);

                ChequesDescuentoDetalle o = new ChequesDescuentoDetalle()
                {
                    Id_Documento = c.Id,
                    Banco = c.Banco,
                    Sucursal = c.Sucursal.Value.ToString(),
                    NroCheque = c.NroCheque.Value.ToString(),
                    NroCuenta = c.NroCta.Value.ToString(),
                    Importe = c.Importe,
                    UserAdd = u,
                    FechaAdd = f
                };

                manager.Descuento.Detalle.Add(o);
                DetalleList.Add(o);

                gridControl1.RefreshDataSource();

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

        private void frmChequeDescuento_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager.Descuento.Detalle.Count == 0 && manager.Descuento.Id > 0)
            {
                ChequeDescuentoManager.Eliminar(new ChequesDescuento() { Id = manager.Descuento.Id });
                DialogResult = DialogResult.Cancel;
            }
            if (manager != null) manager.Dispose();
        }

        public void IdsSeleccionados(List<int> Ids)
        {
            try
            {
                foreach (int Id in Ids)
                {
                    IdSeleccionado(Id);
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

        private void id_ProvFinancieroCuentaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            Validate();
            _IdEspecie = manager.Id_Especie;
        }

    }
}
