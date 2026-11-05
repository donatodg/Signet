namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmEspeciesCtaCte_AddMod : MultiForm, IDisposable
    {
        private EspeciesCtaCteManager manager;

        public frmEspeciesCtaCte_AddMod(EspeciesCtaCte o)
        {
            InitializeComponent();
            manager = new EspeciesCtaCteManager(o);
        }

        private void frmEspeciesCtaCte_AddMod_Load(object sender, EventArgs e)
        {
            especiesCtaCteManagerBindingSource.DataSource = manager;

            id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
            id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";
            id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";

            Id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobanteLibres;
            Id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";
            Id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";

            if (manager.EspecieCtaCte.Id == 0)
            {
                fechaDateEdit.EditValue = manager.EspecieCtaCte.Fecha = Sistema.ObtenerFechaHora();
                if (Sistema.CentrosCostos.Count > 0)
                {
                    id_CentroCostoLookUpEdit.ItemIndex = 0;
                    manager.EspecieCtaCte.Id_CentroCosto = (int)id_CentroCostoLookUpEdit.EditValue;
                }
                else
                {
                    Sistema.Mensaje("El usuario no posee centro de costos asignados.");
                    Close();
                }
            }
            else
            {
                DateTime f = Sistema.ObtenerFechaHora();
                if (manager.EspecieCtaCte.Fecha.DayOfYear < f.DayOfYear || manager.EspecieCtaCte.Fecha.Year != f.Year)
                    btnAgregar.Enabled = false;
            }
            Validate();
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

        private void creditoTextEdit_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(creditoTextEdit.EditValue) > 0)
            {
                Validate();
                debitoTextEdit.EditValue = manager.EspecieCtaCte.Debito = 0;
            }
            //this.Validate();
        }

        private void debitoTextEdit_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(debitoTextEdit.EditValue) > 0)
            {
                Validate();
                creditoTextEdit.EditValue = manager.EspecieCtaCte.Credito = 0;
            }
            //this.Validate();
        }
        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void especiesCtaCteManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError(e.Exception);
        }

        private void frmEspeciesCtaCte_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }
    }
}
