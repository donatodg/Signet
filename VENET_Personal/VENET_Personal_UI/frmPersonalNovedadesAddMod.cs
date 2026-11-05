namespace VENET_Personal_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Personal_BL;

    public partial class frmPersonalNovedadesAddMod : MultiForm, IDisposable
    {
        private PersonalNovedadesManager manager;

        public frmPersonalNovedadesAddMod(PersonalNovedades o)
        {
            InitializeComponent();
            manager = new PersonalNovedadesManager(o);
        }

        private void frmPersonalNovedadesAddMod_Load(object sender, EventArgs e)
        {
            personalNovedadesManagerBindingSource.DataSource = manager;
            fechaHastaDateEdit.EditValue = manager.Novedad.Fecha;

            id_TipoNovedadLookUpEdit.Properties.DataSource = manager.TipoNovedad;
            id_TipoNovedadLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoNovedadLookUpEdit.Properties.ValueMember = "Key";

            idPersonalLookUpEdit.Properties.DataSource = manager.Personal;
            idPersonalLookUpEdit.Properties.DisplayMember = "LegajoNombre";
            idPersonalLookUpEdit.Properties.ValueMember = "Id";

            if (manager.Novedad.Id_Personal > 0)
            {
                fechaDateEdit.Enabled = fechaHastaDateEdit.Enabled = false;
                idPersonalLookUpEdit.EditValue = manager.Novedad.Id_Personal;
            }
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void frmPersonalNovedadesAddMod_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void Guardar()
        {
            try
            {
                Validate();
                manager.Save((DateTime)fechaHastaDateEdit.EditValue);
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

    }
}
