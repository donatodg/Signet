namespace VENET_Common
{
    using System;
    using System.Windows.Forms;

    public partial class frmFecha : MultiForm
    {
        public DateTime Fecha = Sistema.ObtenerFechaHora();

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == 256)
            {
                if ((Keys)m.WParam == Keys.Escape) Close();
                if ((Keys)m.WParam == Keys.Enter) Guardar();
            }
            return base.ProcessKeyPreview(ref m);
        }

        public frmFecha(DateTime? FechaDefault = null, DateTime? MinFecha = null, DateTime? MaxFecha = null)
        {
            InitializeComponent();
            if (FechaDefault == null) FechaDefault = Sistema.ObtenerFecha();
            if (FechaDefault >= MinFecha && FechaDefault <= MaxFecha)
            { if (FechaDefault.HasValue) dateEditFecha.EditValue = (DateTime)FechaDefault; }
            else dateEditFecha.EditValue = (DateTime)FechaDefault;

            if (MinFecha.HasValue) dateEditFecha.Properties.MinValue = (DateTime)MinFecha;
            if (MaxFecha.HasValue) dateEditFecha.Properties.MaxValue = (DateTime)MaxFecha;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            //if (Convert.ToDateTime(dateEditFecha.Text) >= dateEditFecha.Properties.MinValue && Convert.ToDateTime(dateEditFecha.Text) <= dateEditFecha.Properties.MaxValue)
            //{
            DialogResult = DialogResult.OK;
            Fecha = Convert.ToDateTime(dateEditFecha.Text);
            //}
            //else
            //{
            //    DialogResult = DialogResult.Cancel;
            //}
            Close();
        }

    }
}
