namespace VENET_Common
{
    using System;
    using System.Data;
    using VENET_Common;

    public partial class frmGrillaMensaje : MultiForm
    {
        private DataTable _Dt;
        public frmGrillaMensaje(DataTable dt, string Titulo)
        {
            InitializeComponent();
            _Dt = dt;
            if (Titulo != "") Text = Titulo;
        }

        private void frmMensaje_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _Dt;
            barStaticItemFooter.Caption = "Cantidad de Registros: " + _Dt.Rows.Count.ToString();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }
    }
}
