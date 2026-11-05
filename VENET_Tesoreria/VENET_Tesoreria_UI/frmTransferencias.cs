namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmTransferencias : MultiForm
    {
        private TransferenciasManager manager;

        public frmTransferencias(Transferencias o)
        {
            InitializeComponent();
            manager = new TransferenciasManager(o);
        }

        private void frmTransferencias_Load(object sender, EventArgs e)
        {
            transferenciasManagerBindingSource.DataSource = manager;

            id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
            id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

            id_Caja_OrigenLookUpEdit.Properties.DataSource = Sistema.Cajas;
            id_Caja_OrigenLookUpEdit.Properties.ValueMember = "Id_Caja";
            id_Caja_OrigenLookUpEdit.Properties.DisplayMember = "Caja";

            id_Caja_DestinoLookUpEdit.Properties.DataSource = Sistema.Cajas;
            id_Caja_DestinoLookUpEdit.Properties.ValueMember = "Id_Caja";
            id_Caja_DestinoLookUpEdit.Properties.DisplayMember = "Caja";

            if (manager.Transferencia.Id > 0) btnAceptar.Enabled = false;
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
                DialogResult = System.Windows.Forms.DialogResult.OK;
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


    }
}
