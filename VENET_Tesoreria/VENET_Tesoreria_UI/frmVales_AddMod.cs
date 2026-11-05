namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmVales_AddMod : MultiForm, IForm, IDisposable
    {
        private ValesManager manager;
        public Vales Vale;

        public frmVales_AddMod(Vales o)
        {
            InitializeComponent();
            manager = new ValesManager(o);
        }

        private void frmVales_AddMod_Load(object sender, EventArgs e)
        {
            valesManagerBindingSource.DataSource = manager;

            id_PersonalLookUpEdit.Properties.DataSource = manager.ListaPersonal;
            id_PersonalLookUpEdit.Properties.DisplayMember = "Nombre";
            id_PersonalLookUpEdit.Properties.ValueMember = "Id";

            id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
            id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

            if (manager.Vale.FechaConfirmacion != null) btnAceptar.Enabled = false;
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

        private void lnkPersonal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPersonal", "VENET_Personal_UI", "VENET_Personal_UI", true);
        }

        public void IdSeleccionado(int Id)
        {
            id_PersonalLookUpEdit.EditValue = manager.Vale.Id_Personal = Id;
            Validate();
        }

        private void frmVales_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        public void IdsSeleccionados(List<int> Ids)
        {
            throw new NotImplementedException();
        }
    }
}
