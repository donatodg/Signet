namespace VENET_Common
{
    using System;
    using System.Windows.Forms;

    public partial class frmMensaje : Form
    {
        private string Error;

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == 256)
                if ((Keys)m.WParam == Keys.Escape) { Close(); }
            return base.ProcessKeyPreview(ref m);
        }
        public frmMensaje(string Titulo, string Mensaje, string strError = "")
        {
            InitializeComponent();
            lblTitulo.Text = Titulo;
            lblMensaje.Text = Mensaje;
            Error = strError;
            if (strError != "") lnkDetalleError.Visible = true;
            Width = SystemInformation.PrimaryMonitorSize.Width;
        }

        //public frmMensaje(string Titulo, string Mensaje, string pForeColor, string pBackColor, string strError = "")
        //{
        //    InitializeComponent();
        //    SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        //    BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(pBackColor));
        //    lblTitulo.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(pForeColor));
        //    lblTitulo.Text = Titulo;

        //    lblMensaje.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(pForeColor));
        //    lblMensaje.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(pBackColor));
        //    //lblMensaje.BackColor = BackColor;
        //    //lblMensaje.ForeColor = lblTitulo.ForeColor;
        //    lblMensaje.Text = Mensaje;

        //    btnAceptar.BackColor = BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(pBackColor));
        //    btnAceptar.ForeColor = ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(pForeColor));
        //    //btnAceptar = ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(pForeColor));
        //    //btnAceptar.BackColor = BackColor;
        //    //btnAceptar.ForeColor = lblTitulo.ForeColor;

        //    Error = strError;
        //    if (strError != "") lnkDetalleError.Visible = true;
        //    Width = SystemInformation.PrimaryMonitorSize.Width;
        //}

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lnkDetalleError_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmError f = new frmError(Error);
            f.ShowDialog(this);
        }
    }
}
