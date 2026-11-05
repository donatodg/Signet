namespace VENET_Common
{
    using System;

    public partial class frmError : MultiForm
    {
        public frmError(string Error)
        {
            InitializeComponent();
            memoEditError.Text = Error;
        }

        private void frmError_Load(object sender, EventArgs e)
        {
            memoEditError.DeselectAll();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
         
    }
}
