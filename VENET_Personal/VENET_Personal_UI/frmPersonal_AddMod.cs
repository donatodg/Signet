namespace VENET_Personal_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Personal_BL;

    public partial class frmPersonal_AddMod : MultiForm, IDisposable
    {
        private PersonalManager manager;

        public frmPersonal_AddMod()
        {
            InitializeComponent();
            manager = new PersonalManager(new Personal() { Id = Convert.ToInt32(ConfigurationManager.AppSettings["ParametroId"]) });
        }

        public frmPersonal_AddMod(Personal o)
        {
            InitializeComponent();
            manager = new PersonalManager(o);
        }

        private void frmPersonal_AddMod_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Personal_VerSolapaDetalleLaboral)))
                xtraTabControl1.TabPages.RemoveAt(4);

            personalManagerBindingSource.DataSource = manager;

            //laboralDiaRotacionComboBoxEdit.SelectedIndex = manager.Personal.LaboralDiaRotacion - 1;

            id_EstadoCivilSpinEdit.Properties.DataSource = manager.Estados_Civiles;
            id_EstadoCivilSpinEdit.Properties.ValueMember = "Key";
            id_EstadoCivilSpinEdit.Properties.DisplayMember = "Name";

            tipoDocTextEdit.Properties.DataSource = manager.TipoDoc;
            tipoDocTextEdit.Properties.ValueMember = "Key";
            tipoDocTextEdit.Properties.DisplayMember = "Name";

            id_TipoSpinEdit.Properties.DataSource = manager.Tipos_Personal;
            id_TipoSpinEdit.Properties.ValueMember = "Key";
            id_TipoSpinEdit.Properties.DisplayMember = "Name";

            id_JerarquiaSpinEdit.Properties.DataSource = manager.Jerarquias;
            id_JerarquiaSpinEdit.Properties.ValueMember = "Key";
            id_JerarquiaSpinEdit.Properties.DisplayMember = "Name";

            laboralId_ProvinciaTextEdit.Properties.DataSource = manager.Provincias;
            laboralId_ProvinciaTextEdit.Properties.ValueMember = "Key";
            laboralId_ProvinciaTextEdit.Properties.DisplayMember = "Name";

            id_ProvinciaSpinEdit.Properties.DataSource = manager.Provincias;
            id_ProvinciaSpinEdit.Properties.ValueMember = "Key";
            id_ProvinciaSpinEdit.Properties.DisplayMember = "Name";

            laboralId_UnidadNegocioLookUpEdit.Properties.DataSource = manager.UnidadNegocio;
            laboralId_UnidadNegocioLookUpEdit.Properties.ValueMember = "Key";
            laboralId_UnidadNegocioLookUpEdit.Properties.DisplayMember = "Name";

            laboralDiaRotacionComboBoxEdit.Properties.DataSource = Enums.ToList(typeof(Enums.DiasSemana));
            laboralDiaRotacionComboBoxEdit.Properties.DisplayMember = "Value";
            laboralDiaRotacionComboBoxEdit.Properties.ValueMember = "Key";

            laboralTurnoFijoLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.Turno));
            laboralTurnoFijoLookUpEdit.Properties.DisplayMember = "Value";
            laboralTurnoFijoLookUpEdit.Properties.ValueMember = "Key";

            laboralId_TipoServicioLookUpEdit.Properties.DataSource = manager.Servicios;
            laboralId_TipoServicioLookUpEdit.Properties.DisplayMember = "Name";
            laboralId_TipoServicioLookUpEdit.Properties.ValueMember = "Key";

            laboralId_CabeceraLookUpEdit.Properties.DataSource = manager.Cabeceras;
            laboralId_CabeceraLookUpEdit.Properties.DisplayMember = "Name";
            laboralId_CabeceraLookUpEdit.Properties.ValueMember = "Key";

            laboralId_GrupoLineaLookUpEdit.Properties.DataSource = manager.GrupoLineas;
            laboralId_GrupoLineaLookUpEdit.Properties.DisplayMember = "Name";
            laboralId_GrupoLineaLookUpEdit.Properties.ValueMember = "Key";

            id_TipoIvaLookUpEdit.Properties.DataSource = Sistema.TiposIva;
            id_TipoIvaLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoIvaLookUpEdit.Properties.ValueMember = "Key";

            laboralId_PuntaLineaLookUpEdit.Properties.DataSource = manager.PuntasDeLineas;
            laboralId_PuntaLineaLookUpEdit.Properties.DisplayMember = "Name";
            laboralId_PuntaLineaLookUpEdit.Properties.ValueMember = "Key";

            laboralId_ServicioInspectoresLookUpEdit.Properties.DataSource = manager.ServiciosInspectores;
            laboralId_ServicioInspectoresLookUpEdit.Properties.DisplayMember = "Name";
            laboralId_ServicioInspectoresLookUpEdit.Properties.ValueMember = "Key";
        }

        private void frmPersonal_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
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
                //manager.Personal.LaboralDiaRotacion = laboralDiaRotacionComboBoxEdit.SelectedIndex + 1;
                manager.Save();
                ConfigurationManager.AppSettings["RetornoId"] = manager.Personal.Id.ToString();
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

        private void personalManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError(e.Exception);
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void laboralTurnoFijoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(laboralTurnoFijoLookUpEdit.EditValue) > 3)
                    laboralDiaRotacionComboBoxEdit.Enabled = laboralDiasRotacionTextEdit.Enabled = true;
                else
                    laboralDiaRotacionComboBoxEdit.Enabled = laboralDiasRotacionTextEdit.Enabled = false;
            }
            catch (Exception)
            {
            }
        }

        private void laboralId_UnidadNegocioLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (laboralId_UnidadNegocioLookUpEdit.ItemIndex == -1) return;
                this.Validate();
                manager.Personal.LaboralId_UnidadNegocio = (Int32)laboralId_UnidadNegocioLookUpEdit.EditValue;
                laboralId_TipoServicioLookUpEdit.Properties.DataSource = manager.Servicios;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void laboralId_TipoServicioLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (laboralId_TipoServicioLookUpEdit.ItemIndex == -1) return;
                this.Validate();
                manager.Personal.LaboralId_TipoServicio = (Int32)laboralId_TipoServicioLookUpEdit.EditValue;
                laboralId_CabeceraLookUpEdit.Properties.DataSource = manager.Cabeceras;
                laboralId_GrupoLineaLookUpEdit.Properties.DataSource = manager.GrupoLineas;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void laboralId_PuntaLineaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (laboralId_PuntaLineaLookUpEdit.ItemIndex == -1) return;
                this.Validate();
                manager.Personal.LaboralId_PuntaDeLinea = (Int32)laboralId_PuntaLineaLookUpEdit.EditValue;
                laboralId_ServicioInspectoresLookUpEdit.Properties.DataSource = manager.ServiciosInspectores;

            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void laboralInspectoresFranco4x1CheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (laboralInspectoresFranco4x1CheckEdit.Checked)
            {
                manager.Personal.LaboralInspectoresFranco4x1 = true;
                manager.Personal.LaboralInspectoresFrancoSD = false;
                laboralInspectoresFrancoSDCheckEdit.Checked = false;
                Validate();
            }
        }

        private void laboralInspectoresFrancoSDCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (laboralInspectoresFrancoSDCheckEdit.Checked)
            {
                manager.Personal.LaboralInspectoresFrancoSD = true;
                manager.Personal.LaboralInspectoresFranco4x1 = false;
                laboralInspectoresFranco4x1CheckEdit.Checked = false;
                Validate();
            }
        }
    }
}