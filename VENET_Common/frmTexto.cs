namespace VENET_Common
{
    using System.Windows.Forms;

    public partial class frmTexto : MultiForm
    {
        public string result;
        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == 256)
            {
                if ((Keys)m.WParam == Keys.Escape) { DialogResult = DialogResult.Cancel; Close(); }
                if ((Keys)m.WParam == Keys.Enter) { btnAceptar_ItemClick(null, null); }
            }
            return base.ProcessKeyPreview(ref m);
        }

        public frmTexto(string Form, string Label, string Textbox)
        {
            InitializeComponent();
            Text = Form;
            //textoLabel.Text = Label;
            textoTextEdit.Text = Textbox;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            result = textoTextEdit.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
