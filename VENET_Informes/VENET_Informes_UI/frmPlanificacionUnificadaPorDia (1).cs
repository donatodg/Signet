namespace VENET_Informes_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Informes_BL;

    public partial class frmPlanificacionUnificadaPorDia : MultiForm
    {
        PlanificacionUnificadaPorDiaManager.ParametrosBusquedas par = new PlanificacionUnificadaPorDiaManager.ParametrosBusquedas();

        public frmPlanificacionUnificadaPorDia()
        {
            InitializeComponent();
        }

        private void frmPlanificacionUnificadaPorDia_Load(object sender, EventArgs e)
        {
            planificacionUnificadaPorDiaManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Preparando Informe...");

                planificacionUnificadaPorDiaManager_ReporteBindingSource.DataSource = new PlanificacionUnificadaPorDiaManager().Buscar(par);

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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Informes, "PlanificacionUnificadaPorDia", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();

        }

        private void planificacionUnificadaPorDiaManager_ReporteBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + planificacionUnificadaPorDiaManager_ReporteBindingSource.Count.ToString();
        }
    }
}
