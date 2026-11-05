namespace VENET_Tesoreria_UI
{
    using System;
    using VENET_Common;

    public partial class frmMotivoRechazo : MultiForm
    {
        public string Motivo;

        public frmMotivoRechazo()
        {
            InitializeComponent();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMotivo.Text == "")
                Motivo = "-";
            else
                Motivo = txtMotivo.Text;

            return;
        }
    }
}
