namespace VENET_Personal_Sisorg
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;

    public partial class frmWebServiceSisorgViajes : MultiForm
    {
        public frmWebServiceSisorgViajes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                webServicesSisorg_resultViajesBindingSource.DataSource = WebServicesSisorg.GetHabilitados(Convert.ToDateTime(fecha_HastaDateEdit.EditValue));
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void frmWebServiceSisorgViajes_Load(object sender, EventArgs e)
        {
            try
            {
                fecha_HastaDateEdit.EditValue = Sistema.ObtenerFecha();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void webServicesSisorg_resultViajesBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + webServicesSisorg_resultViajesBindingSource.Count.ToString();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "WebServiceSisorgViajes", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnProcesar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Trafico, "WebServicesSisorg", Enums.Accion.Operaciones, "Enturnar viajes en Sisorg")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Enrutando Viajes...");

                Validate();

                foreach (WebServicesSisorg.resultViajes row in webServicesSisorg_resultViajesBindingSource)
                    if (row.Seleccionado)
                    {
                        row.Resultado = WebServicesSisorg.Enturnar(row);
                        gridControl1.RefreshDataSource();
                        gridControl1.Refresh();
                    }

                //Buscar();

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

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

    }
}