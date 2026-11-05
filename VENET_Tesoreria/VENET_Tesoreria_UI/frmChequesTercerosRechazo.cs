namespace VENET_Tesoreria_UI
{
    using System;
    using System.Windows.Forms;
    using VENET_Common;

    public partial class frmChequesTercerosRechazo : MultiForm
    {
        public string Motivo;
        public decimal Importe;

        public frmChequesTercerosRechazo()
        {
            InitializeComponent();
        }

        private void frmChequesTercerosRechazo_Load(object sender, EventArgs e)
        {
            textoTextEdit.Text = "SIN FONDOS";
            importeTextEdit.EditValue = 0;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Motivo = textoTextEdit.Text;
            Importe = Convert.ToDecimal(importeTextEdit.EditValue);
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
