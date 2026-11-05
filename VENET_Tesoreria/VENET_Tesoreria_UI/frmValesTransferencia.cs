namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Tesoreria_BL;

    public partial class frmValesTransferencia : MultiForm
    {
        private ValesTransferenciaManager manager = new ValesTransferenciaManager();

        public frmValesTransferencia()
        {
            InitializeComponent();
        }

        private void frmValesTransferencia_Load(object sender, EventArgs e)
        {
            valesTransferenciaManagerBindingSource.DataSource = manager;
            valesBindingSource.DataSource = manager.ValeTrans.Vales;

            id_CajaOrigenLookUpEdit.Properties.DataSource = Sistema.Cajas;
            id_CajaOrigenLookUpEdit.Properties.ValueMember = "Id_Caja";
            id_CajaOrigenLookUpEdit.Properties.DisplayMember = "Caja";

            id_CajaDestinoLookUpEdit.Properties.DataSource = manager.CajasDestino;
            id_CajaDestinoLookUpEdit.Properties.ValueMember = "Id_Caja";
            id_CajaDestinoLookUpEdit.Properties.DisplayMember = "Caja";
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Validate();
                manager.Save();
                Sistema.Mensaje("Se han transferido correctamente los vales.");
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

        private void id_CajaOrigenLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            Validate();
            manager.ValeTrans.Id_CajaOrigen = (int)id_CajaOrigenLookUpEdit.EditValue;
            manager.ValeTrans.RaisePropertyChanged("id_CajaOrigen");
            id_CajaDestinoLookUpEdit.Properties.DataSource = manager.CajasDestino;
            if (manager.CajasDestino.Count > 0)
            {
                id_CajaDestinoLookUpEdit.ItemIndex = 0;
                manager.ValeTrans.Id_CajaDestino = (int)id_CajaDestinoLookUpEdit.EditValue;
            }
            valesBindingSource.DataSource = manager.ValeTrans.Vales;
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            manager.ValeTrans.Vales[valesBindingSource.Position].Seleccionado = ((DevExpress.XtraEditors.CheckEdit)(sender)).Checked;
        }
    }
}
