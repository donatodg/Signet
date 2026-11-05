namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmBoletaDepositoEfectivo : MultiForm, IDisposable
    {
        private BoletaDepositoEfectivoManager manager;

        public frmBoletaDepositoEfectivo(int Id_Caja)
        {
            InitializeComponent();
            manager = new BoletaDepositoEfectivoManager(Id_Caja);
        }

        private void frmBoletaDepositoEfectivo_Load(object sender, EventArgs e)
        {
            boletaDepositoEfectivoManagerBindingSource.DataSource = manager;

            id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
            id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

            id_CuentaPFLookUpEdit.Properties.DataSource = manager.CuentasPF;
            id_CuentaPFLookUpEdit.Properties.ValueMember = "Key";
            id_CuentaPFLookUpEdit.Properties.DisplayMember = "Name";
        }

        private void frmBoletaDepositoEfectivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
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
    }
}
