namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmEntidadesCtaCte_AddMod : MultiForm, IDisposable
    {
        private EntidadesCtaCteManager manager;

        public frmEntidadesCtaCte_AddMod(EntidadesCtaCte o)
        {
            InitializeComponent();
            manager = new EntidadesCtaCteManager(o);
        }

        private void frmEntidadesCtaCte_AddMod_Load(object sender, EventArgs e)
        {
            entidadesCtaCteManagerBindingSource.DataSource = manager;

            id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
            id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";
            id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";

            id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobanteLibres;
            id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";
            id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";

            if (manager.CtaCte.Id == 0)
            {
                fechaDateEdit.EditValue = manager.CtaCte.Fecha = Sistema.ObtenerFechaHora();
                if (Sistema.CentrosCostos.Count > 0)
                {
                    id_CentroCostoLookUpEdit.ItemIndex = 0;
                    manager.CtaCte.Id_CentroCosto = (int)id_CentroCostoLookUpEdit.EditValue;
                }
                else
                {
                    Sistema.Mensaje("El usuario no posee centro de costos asignados.");
                    Close();
                }
            }
            else
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["CurrentUserEsAdministrador"]))
                    if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.MovimientosInternosPermiteModificarAdministrador)))
                    {
                        DateTime f = Sistema.ObtenerFechaHora();
                        //if (manager.CtaCte.Fecha.DayOfYear < f.DayOfYear || manager.CtaCte.Fecha.Year != f.Year)
                        if (manager.CtaCte.Fecha != new DateTime(f.Year, f.Month, f.Day))
                            btnAceptar.Enabled = false;
                    }
            }
            Validate();
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

        private void creditoTextEdit_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(creditoTextEdit.EditValue) > 0)
            {
                Validate();
                debitoTextEdit.EditValue = manager.CtaCte.Debito = 0;
            }
        }

        private void debitoTextEdit_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(debitoTextEdit.EditValue) > 0)
            {
                Validate();
                creditoTextEdit.EditValue = manager.CtaCte.Credito = 0;
            }
        }

        private void frmEntidadesCtaCte_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void entidadesCtaCteManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError(e.Exception);
        }

    }
}
