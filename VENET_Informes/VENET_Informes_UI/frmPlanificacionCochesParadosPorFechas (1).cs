namespace VENET_Informes_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Informes_BL;

    public partial class frmPlanificacionCochesParadosPorFechas : MultiForm
    {
        PlanificacionCochesParadosPorFechasManager.ParametrosBusquedas par = new PlanificacionCochesParadosPorFechasManager.ParametrosBusquedas();

        public frmPlanificacionCochesParadosPorFechas()
        {
            InitializeComponent();
        }

        private void frmPlanificacionCochesParadosPorFechas_Load(object sender, EventArgs e)
        {
            id_UnidadNegocioLookUpEdit.Properties.DataSource = par.UnidadesNegocios;
            id_UnidadNegocioLookUpEdit.Properties.DisplayMember = "Name";
            id_UnidadNegocioLookUpEdit.Properties.ValueMember = "Key";

            planificacionCochesParadosPorFechasManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Preparando Informe...");

                gridView1.Columns.Clear();
                gridControl1.DataSource = new PlanificacionCochesParadosPorFechasManager().Buscar(par);

                barStaticItemFooter.Caption = "Cantidad de Registros: " + ((System.Data.DataTable)(gridControl1.DataSource)).Rows.Count;

                SplashScreenManager.CloseForm(false);
            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Informes, "PlanificacionCochesParadosPorFechas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }
    }
}
