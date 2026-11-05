namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmChequesPropios_AddMod : MultiForm
    {
        private ChequePropiosManager manager;

        public frmChequesPropios_AddMod(ChequesPropios o)
        {
            InitializeComponent();
            manager = new ChequePropiosManager(o);
        }

        public frmChequesPropios_AddMod(ChequesPropios o, int Id_Sucursal)
        {
            InitializeComponent();
            manager = new ChequePropiosManager(o);
            manager.Cheque.Id_Sucursal = Id_Sucursal;
        }

        private void frmChequePropios_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                chequePropiosManagerBindingSource.DataSource = manager;

                if (manager.Cheque.FechaPago == DateTime.MinValue) manager.Cheque.FechaEmision = manager.Cheque.FechaPago = Sistema.ObtenerFecha();
                if (manager.Cheque.Id_OrdenPago != null || manager.Cheque.FechaDepositado != null || manager.Cheque.FechaRechazado != null) btnAceptar.Enabled = false;

                id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
                id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
                id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

                id_ProvFinancierosCuentaLookUpEdit.Properties.DataSource = ChequePropiosManager.ProveedorFinancieroCuentas;
                id_ProvFinancierosCuentaLookUpEdit.Properties.DisplayMember = "Name";
                id_ProvFinancierosCuentaLookUpEdit.Properties.ValueMember = "Key";

                if (Convert.ToInt32(id_SucursalLookUpEdit.EditValue) == 0)
                {
                    id_SucursalLookUpEdit.ItemIndex = 0;
                    manager.Cheque.Id_Sucursal = (int)id_SucursalLookUpEdit.EditValue;
                }

                if (Convert.ToInt32(id_ProvFinancierosCuentaLookUpEdit.EditValue) == 0)
                {
                    id_ProvFinancierosCuentaLookUpEdit.ItemIndex = 0;
                    manager.Cheque.Id_ProvFinancierosCuenta = (int)id_ProvFinancierosCuentaLookUpEdit.EditValue;
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

        private void aLaOrdenCheckEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Guardar();
        }

    }
}
