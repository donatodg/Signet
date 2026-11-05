namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Tesoreria_BL;
    
    public partial class frmTransferencia : MultiForm
    {
        private TransferenciasManager manager;

        public frmTransferencia(Int32 IdEspecie)
        {
            InitializeComponent();
            manager = new TransferenciasManager(IdEspecie);
        }

        private void frmTransferencia_Load(object sender, EventArgs e)
        {
            transferenciasManagerBindingSource.DataSource = manager;

            id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
            id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

            id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobante;
            id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";

            idEspecieDestinoLookUpEdit.Properties.DataSource = Sistema.Especies;
            idEspecieDestinoLookUpEdit.Properties.DisplayMember = "Name";
            idEspecieDestinoLookUpEdit.Properties.ValueMember = "Key";

            idEspecieOrigenLookUpEdit.Properties.DataSource = Sistema.Especies;
            idEspecieOrigenLookUpEdit.Properties.DisplayMember = "Name";
            idEspecieOrigenLookUpEdit.Properties.ValueMember = "Key";
        }

        private void btnGuradar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                this.Validate();
                manager.Save();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
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
