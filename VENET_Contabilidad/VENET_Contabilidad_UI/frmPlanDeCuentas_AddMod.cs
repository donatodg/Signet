namespace VENET_Contabilidad_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Contabilidad_BL;

    public partial class frmPlanDeCuentas_AddMod : MultiForm, IDisposable
    {
        private PlanDeCuentasManager manager;

        public frmPlanDeCuentas_AddMod(CuentasContables o)
        {
            InitializeComponent();
            manager = new PlanDeCuentasManager(o);
        }

        private void frmPlanDeCuentas_AddMod_Load(object sender, EventArgs e)
        {
            try
            {

                planDeCuentasManagerBindingSource.DataSource = manager;

                if (manager.CuentaContable.Id > 0)
                {
                    tituloTextEdit_EditValueChanged(null, null);
                    capituloTextEdit_EditValueChanged(null, null);
                    rubroTextEdit_EditValueChanged(null, null);
                    cuentaTextEdit_EditValueChanged(null, null);

                    manager.CuentaContable.Descripcion = manager.CuentaContable.Descripcion.Trim();
                    descripcionTextEdit.EditValue = manager.CuentaContable.Descripcion;
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

        private void tituloTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = manager.BuscaTitulo(tituloTextEdit.EditValue.ToString());
            }
            catch (Exception) { }
        }

        private void capituloTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblCapitulo.Text = manager.BuscaCapitulo(tituloTextEdit.EditValue.ToString(), capituloTextEdit.EditValue.ToString());
            }
            catch (Exception) { }
        }

        private void rubroTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblRubro.Text = manager.BuscaRubro(tituloTextEdit.EditValue.ToString(), capituloTextEdit.EditValue.ToString(), rubroTextEdit.EditValue.ToString());
            }
            catch (Exception) { }
        }

        private void cuentaTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblCuenta.Text = manager.BuscaCuenta(tituloTextEdit.EditValue.ToString(), capituloTextEdit.EditValue.ToString(), rubroTextEdit.EditValue.ToString(), cuentaTextEdit.EditValue.ToString());
            }
            catch (Exception) { }
        }

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void frmPlanDeCuentas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void tituloTextEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tituloTextEdit.EditValue == DBNull.Value)
                    tituloTextEdit.EditValue = 0;

                tituloTextEdit.EditValue = Convert.ToInt32(tituloTextEdit.EditValue).ToString("D2");
                if (tituloTextEdit.EditValue.ToString() != "00")
                    lblTitulo.Text = manager.BuscaTitulo(tituloTextEdit.EditValue.ToString());
            }
            catch (Exception) { }
        }

        private void capituloTextEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                if (capituloTextEdit.EditValue == DBNull.Value)
                    capituloTextEdit.EditValue = 0;

                capituloTextEdit.EditValue = Convert.ToInt32(capituloTextEdit.EditValue).ToString("D2");
                if (capituloTextEdit.EditValue.ToString() != "00")
                    lblCapitulo.Text = manager.BuscaCapitulo(tituloTextEdit.EditValue.ToString(), capituloTextEdit.EditValue.ToString());
            }
            catch (Exception) { }
        }

        private void rubroTextEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                if (rubroTextEdit.EditValue == DBNull.Value)
                    rubroTextEdit.EditValue = 0;

                rubroTextEdit.EditValue = Convert.ToInt32(rubroTextEdit.EditValue).ToString("D2");
                if (rubroTextEdit.EditValue.ToString() != "00")
                    lblRubro.Text = manager.BuscaRubro(tituloTextEdit.EditValue.ToString(), capituloTextEdit.EditValue.ToString(), rubroTextEdit.EditValue.ToString());
            }
            catch (Exception) { }
        }

        private void cuentaTextEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cuentaTextEdit.EditValue == DBNull.Value)
                    cuentaTextEdit.EditValue = 0;

                cuentaTextEdit.EditValue = Convert.ToInt32(cuentaTextEdit.EditValue).ToString("D2");
                if (cuentaTextEdit.EditValue.ToString() != "00")
                    lblCuenta.Text = manager.BuscaCuenta(tituloTextEdit.EditValue.ToString(), capituloTextEdit.EditValue.ToString(), rubroTextEdit.EditValue.ToString(), cuentaTextEdit.EditValue.ToString());
            }
            catch (Exception) { }
        }

        private void subcuentaTextEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                if (subcuentaTextEdit.EditValue == DBNull.Value)
                    subcuentaTextEdit.EditValue = 0;

                subcuentaTextEdit.EditValue = Convert.ToInt32(subcuentaTextEdit.EditValue).ToString("D6");
            }
            catch (Exception) { }
        }

        private void descripcionTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Guardar();
        }


    }
}
