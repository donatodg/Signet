namespace VENET_Contabilidad_UI
{
    using VENET_Contabilidad_BL;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;

    public partial class frmAsientosDetalle_AddMod : MultiForm
    {
        private AsientosDetalleManager manager;
        public AsientosDetalle AsientoDetalle;

        public frmAsientosDetalle_AddMod(AsientosDetalle o)
        {
            InitializeComponent();
            AsientoDetalle = o;
            manager = new AsientosDetalleManager(o);
        }

        private void frmAsientosDetalle_AddMod_Load(object sender, EventArgs e)
        {
            id_CuentaContableLookUpEdit.Properties.DataSource = manager.CuentasContables;
            id_CuentaContableLookUpEdit.Properties.DisplayMember = "Name";
            id_CuentaContableLookUpEdit.Properties.ValueMember = "Key";

            asientosDetalleManagerBindingSource.DataSource = manager;
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

                if (AsientoDetalle.Debe < 0 || AsientoDetalle.Haber < 0 || (AsientoDetalle.Debe == 0 && AsientoDetalle.Haber == 0))
                {
                    Sistema.Mensaje("Debe ingresar un importe válido.");
                    return;
                }
                if (AsientoDetalle.Debe > 0 && AsientoDetalle.Haber > 0)
                {
                    Sistema.Mensaje("Solamente debe ingresar un importe.");
                    return;
                }
                if (AsientoDetalle.Id_CuentaContable == 0)
                {
                    Sistema.Mensaje("Debe ingresar una cuenta contable.");
                    return;
                }

                AsientoDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                AsientoDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                AsientoDetalle.Id_CuentaContable = Convert.ToInt32(id_CuentaContableLookUpEdit.EditValue);
                AsientoDetalle.Haber = Convert.ToDecimal(haberTextEdit.Text);
                AsientoDetalle.Debe = Convert.ToDecimal(debeTextEdit.Text);
                AsientoDetalle.Orden = Convert.ToInt32(ordenTextEdit.Text);
                AsientoDetalle.Cuenta = id_CuentaContableLookUpEdit.Text;

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

        private void debeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(debeTextEdit.EditValue) > 0)
            {
                manager.Detalle.Haber = 0;
                haberTextEdit.EditValue = 0;
            }
        }

        private void haberTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(haberTextEdit.EditValue) > 0)
            {
                manager.Detalle.Debe = 0;
                debeTextEdit.EditValue = 0;
            }
        }

        private void haberTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Guardar();
        }
    }
}
