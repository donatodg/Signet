namespace VENET_Informes_UI
{
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Informes_BL;
    using VENET_Trafico_Reports;

    public partial class frmEncabezadoLibretas : MultiForm
    {
        private EncabezadoLibretasManager manager;

        public frmEncabezadoLibretas()
        {
            InitializeComponent();
            manager = new EncabezadoLibretasManager();
        }

        private void frmEncabezadoLibretas_Load(object sender, EventArgs e)
        {
            try
            {
                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";

                manager.id_Empresa = Sistema.Empresas.First().Key;
                manager.Desde = 1;
                manager.Hasta = 99;

                encabezadoLibretasManagerBindingSource.DataSource = manager;
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

        private void btnImprime_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Validate();

                if (Convert.ToInt32(hastaTextEdit.EditValue) <= 0 || Convert.ToInt32(desdeTextEdit.EditValue) <= 0)
                    throw new ValidationException("El valor debe ser mayor a 0.");

                if (Convert.ToInt32(hastaTextEdit.EditValue) < Convert.ToInt32(desdeTextEdit.EditValue))
                    throw new ValidationException("El valor hasta debe ser mayor al desde.");

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Imprimiendo Hojas...");

                xrptCabeceraLibreta report = new xrptCabeceraLibreta();

                report.DataSource = manager.Imprimir();

                using (ReportPrintTool printTool = new ReportPrintTool(report))
                {
                    report.RequestParameters = false;
                    report.ShowPrintStatusDialog = false;
                    report.ShowPrintMarginsWarning = false;
                    report.ShowPreviewMarginLines = false;

                    printTool.Print();
                }
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

    }
}
