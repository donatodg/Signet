namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmChequeTerceros_AddMod : MultiForm, IDisposable
    {
        private ChequeTercerosManager manager;

        public frmChequeTerceros_AddMod(ChequesTerceros o)
        {
            InitializeComponent();
            manager = new ChequeTercerosManager(o);

            if (o.FechaPago == DateTime.MinValue) o.FechaEmision = o.FechaPago = Sistema.ObtenerFecha();
            if (o.FechaAcreditado != null || o.FechaDepositado != null || o.FechaDescuento != null || o.FechaRechazado != null) btnAceptar.Enabled = false;
        }

        private void frmChequeTerceros_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                chequeTercerosManagerBindingSource.DataSource = manager;

                id_EntidadBancariaLookUpEdit.Properties.DataSource = manager.Bancos;
                id_EntidadBancariaLookUpEdit.Properties.DisplayMember = "Name";
                id_EntidadBancariaLookUpEdit.Properties.ValueMember = "Key";

                id_FirmanteLookUpEdit.Properties.DataSource = manager.Firmantes;
                id_FirmanteLookUpEdit.Properties.DisplayMember = "Cuit";
                id_FirmanteLookUpEdit.Properties.ValueMember = "Id";

                id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
                id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
                id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

                id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
                id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
                id_EspecieLookUpEdit.Properties.ValueMember = "Key";

                if (manager.Cheque.Id_Sucursal == 0)
                {
                    id_SucursalLookUpEdit.ItemIndex = 0;
                    id_EspecieLookUpEdit.ItemIndex = 0;
                }

                if (manager.Cheque.Id_Recibo > 0)
                {
                    id_SucursalLookUpEdit.Enabled = false;
                    id_EntidadBancariaLookUpEdit.Enabled = false;
                    sucursalTextEdit.Enabled = false;
                    codPostalTextEdit.Enabled = false;
                    nroChequeTextEdit.Enabled = false;
                    nroCtaTextEdit.Enabled = false;
                    importeTextEdit.Enabled = false;
                    id_FirmanteLookUpEdit.Enabled = false;
                    id_EspecieLookUpEdit.Enabled = false;
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

        private void frmChequeTerceros_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void lnkFirmante_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Firmantes o = new Firmantes();
                frmFirmantes_AddMod f = new frmFirmantes_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    id_FirmanteLookUpEdit.Properties.DataSource = manager.Firmantes;
                    id_FirmanteLookUpEdit.Refresh();
                    manager.Cheque.Id_Firmante = o.Id;
                    id_FirmanteLookUpEdit.EditValue = o.Id;
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

        private void id_FirmanteLookUpEdit_Enter(object sender, EventArgs e)
        {
            Validate();
        }
    }
}
