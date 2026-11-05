namespace VENET_Tesoreria_UI
{
    using System;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Tesoreria_BL;

    public partial class frmEspeciesCotizaciones : MultiForm, IDisposable
    {
        private EspeciesCotizacionesManager.ParametrosBusquedas par = new EspeciesCotizacionesManager.ParametrosBusquedas();
        private EspeciesCotizacionesManager manager;
        public int Id_Especie;

        public frmEspeciesCotizaciones(int IdEspecie, string Especie)
        {
            InitializeComponent();
            par.Id_Especie = Id_Especie = IdEspecie;
            Text = "Historial de Cotizaciones de: " + Especie;
        }

        private void frmEspeciesCotizaciones_Load(object sender, EventArgs e)
        {
            especiesCotizacionesManager_ParametrosBusquedasBindingSource.DataSource = par;
            Buscar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmEspeciesCotizaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (fechaDesdeDateEdit.Text == "") return;
            par.FechaDesde = Convert.ToDateTime(fechaDesdeDateEdit.EditValue);
            manager = new EspeciesCotizacionesManager(par);
            cotizacionesBindingSource.DataSource = manager.Cotizaciones;
        }


    }
}
