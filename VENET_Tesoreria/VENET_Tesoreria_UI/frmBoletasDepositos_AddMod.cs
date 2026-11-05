namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmBoletasDepositos_AddMod : MultiForm, IDisposable, IForm
    {
        private BoletasDepositosManager manager;
        public List<BoletasDepositosDetalle> DetalleList = new List<BoletasDepositosDetalle>();

        public frmBoletasDepositos_AddMod(BoletasDepositos o)
        {
            InitializeComponent();
            manager = new BoletasDepositosManager(o);
        }

        private void frmBoletasDepositos_AddMod_Load(object sender, EventArgs e)
        {
            boletasDepositosManagerBindingSource.DataSource = manager;

            id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
            id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

            id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
            id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

            id_ProvFinancieroCuentaLookUpEdit.Properties.DataSource = manager.CuentasPF;
            id_ProvFinancieroCuentaLookUpEdit.Properties.ValueMember = "Key";
            id_ProvFinancieroCuentaLookUpEdit.Properties.DisplayMember = "Name";

            if (manager.CuentasPF.Count > 0)
            {
                id_ProvFinancieroCuentaLookUpEdit.ItemIndex = 0;
                manager.Boleta.Id_ProvFinancieroCuenta = (int)id_ProvFinancieroCuentaLookUpEdit.EditValue;
            }
            else
            {
                Sistema.Mensaje("El sistema no tiene cuentas de proveedor financiero configuradas.");
                Close();
            }

            if (manager.Boleta.Detalle != null)
            {
                foreach (BoletasDepositosDetalle o in manager.Boleta.Detalle)
                {
                    BoletasDepositosDetalle x = new BoletasDepositosDetalle()
                    {
                        Id = o.Id,
                        Id_BoletaDeposito = o.Id_BoletaDeposito,
                        Banco = o.Banco,
                        Sucursal = o.Sucursal,
                        NroCheque = o.NroCheque,
                        NroCuenta = o.NroCuenta,
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

            if (manager.Boleta.FechaConfirmacion != null || manager.Boleta.FechaAnulacion != null)
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

        private void frmBoletasDepositos_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager.Boleta.Detalle.Count == 0 && manager.Boleta.Id > 0)
            {
                BoletasDepositosManager.Eliminar(new BoletasDepositos() { Id = manager.Boleta.Id });
                DialogResult = DialogResult.Cancel;
            }
            if (manager != null) manager.Dispose();
        }

        public void IdSeleccionado(int Id)
        {
            ChequesTerceros c = ChequeTercerosManager.Reload(new ChequesTerceros() { Id = Id });

            //********************************************************
            // Validaciones
            if (c.Id_Especie != manager.Id_Especie) throw new ValidationException("El documento es de una especie distinta al de la cuenta del prov. financiero.");
            if (c.Id_Descuento != null) throw new ValidationException("El documento se encuentra en una boleta de depósito.");
            if (c.Id_BoletaDeposito != null) throw new ValidationException("El documento se encuentra en una boleta de depósito.");
            if (c.FechaRechazado != null) throw new ValidationException("El documento fue rechazado.");
            if (c.FechaDepositado != null) throw new ValidationException("El documento fue depositado.");
            //if (manager.Boleta.Detalle.Count >  0)
            foreach (BoletasDepositosDetalle d in manager.Boleta.Detalle)
                if (d.Id_Documento == Id)
                    throw new ValidationException("El documento ya se encuentra en la boleta.");
            //********************************************************

            DateTime f = Sistema.ObtenerFecha();
            int u = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CurrentUserId"]);

            BoletasDepositosDetalle o = new BoletasDepositosDetalle()
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

            manager.Boleta.Detalle.Add(o);
            DetalleList.Add(o);

            gridControl1.RefreshDataSource();

            Validate();
        }

        public void IdsSeleccionados(List<int> Ids)
        {
            foreach (int i in Ids)
                IdSeleccionado(i);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar(true);
        }

        private void btnEfectivo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(false);
        }

        private void btnCheque_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Agregar(bool Cheques)
        {
            try
            {
                if (Cheques)
                {
                    frmChequeTerceros f = new frmChequeTerceros(false);
                    f.Owner = this;
                    f.ShowDialog(this);
                }
                else
                {
                    frmImporte f = new frmImporte(0);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        BoletasDepositosDetalle o = new BoletasDepositosDetalle()
                        {
                            Id_Documento = 0,
                            Banco = "Efectivo",
                            Sucursal = "-",
                            NroCheque = "-",
                            NroCuenta = "-",
                            Importe = f.result,
                            UserAdd = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CurrentUserId"]),
                            FechaAdd = Sistema.ObtenerFecha()
                        };

                        manager.Boleta.Detalle.Add(o);
                        DetalleList.Add(o);

                        gridControl1.RefreshDataSource();

                        Validate();
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

        private void Eliminar()
        {
            try
            {
                if (detalleBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    //if (DetalleList[detalleBindingSource.Position].Id != 0)
                    //    manager.EliminarDetalle((BoletasDepositosDetalle)detalleBindingSource[detalleBindingSource.Position]);

                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    //BoletasDepositosDetalle o = new BoletasDepositosDetalle();

                    foreach (BoletasDepositosDetalle rd in manager.Boleta.Detalle)
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

    }
}
