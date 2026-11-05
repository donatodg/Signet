namespace VENET_Common
{
    using System;
    using System.Windows.Forms;

    public partial class frmMensajeSiNo : Form
    {
        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == 256)
                if ((Keys)m.WParam == Keys.Escape) { btnNo_Click(null, null); }
                if ((Keys)m.WParam == Keys.Enter) { btnSi_Click(null, null); }
            return base.ProcessKeyPreview(ref m);
        }

        public frmMensajeSiNo(string Titulo, string Mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = Mensaje;
            lblTitulo.Text = Titulo;
            Width = SystemInformation.PrimaryMonitorSize.Width;
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
