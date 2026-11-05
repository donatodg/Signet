namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Gestion_BL;

    public partial class frmPedidoEstadoCumplimiento : MultiForm
    {
        public int Avance = 0;

        public frmPedidoEstadoCumplimiento()
        {
            InitializeComponent();
        }

        private void frmPedidoEstadoCumplimiento_Load(object sender, EventArgs e)
        {
            try
            {
                //cumplimientoTextEdit.EditValue = Avance;
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

        private void cumplimientoTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Guardar();
        }

        private void Guardar()
        {
            try
            {
                Validate();
                if (Convert.ToDecimal(cumplimientoTextEdit.EditValue) < 0 || Convert.ToDecimal(cumplimientoTextEdit.EditValue) > 100)
                    throw new ValidationException("El Avance debe estar entre 0 y 100");

                Avance = Convert.ToInt32(cumplimientoTextEdit.EditValue);

                DialogResult = DialogResult.OK;
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
