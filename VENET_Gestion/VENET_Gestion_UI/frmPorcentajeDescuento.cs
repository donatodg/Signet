namespace VENET_Gestion_UI
{
    using System;
    using System.Windows.Forms;
    using VENET_Common;

    public partial class frmPorcentajeDescuento : MultiForm
    {
        public decimal Porcentaje = 0;

        public frmPorcentajeDescuento()
        {
            InitializeComponent();
        }

        private void frmPorcentajeDescuento_Load(object sender, EventArgs e)
        {
            try
            {
                porcDescuentoTextEdit.EditValue = Porcentaje;
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
                Porcentaje = Convert.ToDecimal(porcDescuentoTextEdit.EditValue);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void porcDescuentoTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Guardar();
        }

    }
}
