namespace VENET_Informes_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Informes_BL;
    public partial class frmReporteServiciosPorDia : MultiForm
    {
        ReporteServiciosPorDiaManager.ParametrosBusquedas par = new ReporteServiciosPorDiaManager.ParametrosBusquedas();

        public frmReporteServiciosPorDia()
        {
            InitializeComponent();
        }

        private void frmReporteServiciosPorDia_Load(object sender, EventArgs e)
        {
            id_UnidadNegocioLookUpEdit.Properties.DataSource = Sistema.UnidadesNegociosTrafico;
            id_UnidadNegocioLookUpEdit.Properties.DisplayMember = "Name";
            id_UnidadNegocioLookUpEdit.Properties.ValueMember = "Key";

            reporteServiciosPorDiaManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_UnidadNegocioLookUpEdit.ItemIndex = 0;
            par.Id_UnidadNegocio = (int)id_UnidadNegocioLookUpEdit.EditValue;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Preparando Informe...");

                reporteServiciosPorDiaManager_ReporteBindingSource.DataSource = new ReporteServiciosPorDiaManager().Buscar(par);

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
        private void reporteServiciosPorDiaManager_ReporteBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + reporteServiciosPorDiaManager_ReporteBindingSource.Count.ToString();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Informes, "ReporteServiciosPorDia", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }
    }
}
