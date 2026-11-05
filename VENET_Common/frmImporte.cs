namespace VENET_Common
{
    using System.Windows.Forms;

    public partial class frmImporte : MultiForm
    {
        public decimal result;
        public int resultEntero;
        private bool _IngresoNumero = false;
        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == 256)
            {
                if ((Keys)m.WParam == Keys.Escape) { DialogResult = DialogResult.Cancel; Close(); }
                if ((Keys)m.WParam == Keys.Enter) { btnAceptar_ItemClick(null, null); }
            }
            return base.ProcessKeyPreview(ref m);
        }

        public frmImporte(bool IngresoNumero, int Numero)
        {
            InitializeComponent();
            _IngresoNumero = true;
            ImportetextEdit.EditValue = Numero;
            Text = "Ingrese Número";
            textoLabel.Text = "Número:";
            ImportetextEdit.Properties.DisplayFormat.FormatString = "d";
            ImportetextEdit.Properties.EditFormat.FormatString = "d";
            ImportetextEdit.Properties.Mask.EditMask = "d";
        }

        public frmImporte(decimal Importe)
        {
            InitializeComponent();
            ImportetextEdit.EditValue = Importe;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_IngresoNumero)
                resultEntero = (int)ImportetextEdit.EditValue;
            else
                result = (decimal)ImportetextEdit.EditValue;

            DialogResult = DialogResult.OK;
        }
    }
}
