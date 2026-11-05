namespace VENET_Informes_UI
{
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraSplashScreen;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Informes_BL;
    using VENET_Trafico_Reports;

    public partial class frmReporteLibreta : MultiForm
    {
        private ReporteLibretaManager manager;

        public frmReporteLibreta()
        {
            InitializeComponent();
            manager = new ReporteLibretaManager();
        }

        private void frmReporteLibreta_Load(object sender, EventArgs e)
        {
            try
            {
                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";

                mesLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.Meses));
                mesLookUpEdit.Properties.DisplayMember = "Value";
                mesLookUpEdit.Properties.ValueMember = "Key";

                manager.Id_Empresa = Sistema.Empresas.First().Key;

                DateTime f = Sistema.ObtenerFecha();
                manager.Mes = (Enums.Meses)f.Month - 1;
                manager.Año = f.Year;
                manager.LegajoDesde = 70000;
                manager.LegajoHasta = 79999;

                reporteLibretaManagerBindingSource.DataSource = manager;
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

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Validate();

                if (Convert.ToInt32(legajoHastaTextEdit.EditValue) <= 0 || Convert.ToInt32(legajoDesdeTextEdit.EditValue) <= 0)
                    throw new ValidationException("El legajo debe ser mayor a 0.");

                if (Convert.ToInt32(legajoHastaTextEdit.EditValue) < Convert.ToInt32(legajoDesdeTextEdit.EditValue))
                    throw new ValidationException("El legajo hasta debe ser mayor al desde.");

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Imprimiendo Hojas...");

                xrptReporteLibreta report = new xrptReporteLibreta();

                report.DataSource = manager.Imprimir();

                using (ReportPrintTool printTool = new ReportPrintTool(report))
                {
                    report.RequestParameters = false;
                    report.ShowPrintStatusDialog = false;
                    report.ShowPrintMarginsWarning = false;
                    report.ShowPreviewMarginLines = false;

                    printTool.ShowPreviewDialog();
                    //printTool.Print();
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
