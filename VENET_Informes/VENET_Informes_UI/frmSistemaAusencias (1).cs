namespace VENET_Informes_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Informes_BL;
    using VENET_Personal_UI;

    public partial class frmSistemaAusencias : MultiForm
    {
        private SistemaAusenciaManager.ParametrosBusquedas par = new SistemaAusenciaManager.ParametrosBusquedas();

        public frmSistemaAusencias()
        {
            InitializeComponent();
            DateTime Fecha = Sistema.ObtenerFecha();
            par.FechaDesde = par.FechaHasta = Fecha;
        }

        private void frmSistemaAusencias_Load(object sender, EventArgs e)
        {
            sistemaAusenciaManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnInformeCompleto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Informes, "SistemaAusencias", Enums.Accion.Ver, "Ver Informe Completo")) return;

            if (sistemaAusenciaManager_ReporteBindingSource.Current == null) return;

            frmBrowser f = new frmBrowser("http://ersa01.dyndns.org:1133/SistAusencias/pages/reportes/comprobante.php?i=" + ((SistemaAusenciaManager.Reporte)sistemaAusenciaManager_ReporteBindingSource.Current).Id, Enums.ContenidoBrowser.DireccionURL, "Informe Sistema Ausencia");
            f.ShowDialog();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Informes, "SistemaAusencias", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Preparando Informe...");

                sistemaAusenciaManager_ReporteBindingSource.DataSource = new SistemaAusenciaManager().Buscar(par);

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

        private void sistemaAusenciaManager_ReporteBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + sistemaAusenciaManager_ReporteBindingSource.Count.ToString();
        }

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value != null && e.Value.Equals(string.Empty))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void btnPersonal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Informes, "SistemaAusencias", Enums.Accion.Ver, "Ver Ficha Personal")) return;

                if (sistemaAusenciaManager_ReporteBindingSource.Current == null) return;

                frmPersonal_AddMod f = new frmPersonal_AddMod(new Personal() { Id = ((SistemaAusenciaManager.Reporte)sistemaAusenciaManager_ReporteBindingSource.Current).Id_Personal });
                f.ShowDialog();

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
