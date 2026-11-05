namespace VENET_Tesoreria_UI
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraReports.UI;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.IO;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Tesoreria_BL;

    public partial class frmCierreTurno : MultiForm, IDisposable
    {
        private InicioTurnoManager manager = new InicioTurnoManager(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"].ToString()));

        public frmCierreTurno()
        {
            InitializeComponent();
        }

        private void frmCierreTurno_Load(object sender, EventArgs e)
        {
            inicioTurnoManagerBindingSource.DataSource = manager;
            if (manager.Turno.Id == 0) Close();

            if (manager.Turno.Id_Usuario != Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"].ToString()))
            {
                Sistema.Mensaje("Existe un turno abierto por otro usuario.", "Cierre de Turno");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                List<InformeCierre> DatosReporte = manager.Cierre();

                //xrptCierreTurno report = new xrptCierreTurno();
                XtraReport report = new XtraReport();
                report.LoadLayout(Directory.GetCurrentDirectory() + "\\Reportes\\CierreTurno.repx");

                report.DataSource = DatosReporte;

                using (ReportPrintTool printTool = new ReportPrintTool(report))
                {
                    printTool.ShowRibbonPreviewDialog();
                }

                DialogResult = DialogResult.OK;
                Application.Exit();

            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }
    }
}
