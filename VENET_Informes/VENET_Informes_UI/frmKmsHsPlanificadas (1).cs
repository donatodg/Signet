namespace VENET_Informes_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Informes_BL;

    public partial class frmKmsHsPlanificadas : MultiForm
    {
        private KmsHsPlanificadasManager.ParametrosBusquedas par = new KmsHsPlanificadasManager.ParametrosBusquedas();

        public frmKmsHsPlanificadas()
        {
            InitializeComponent();
            DateTime Fecha = Sistema.ObtenerFecha();

            id_UnidadNegocioLookUpEdit.Properties.DataSource = par.UnidadesNegocios;
            id_UnidadNegocioLookUpEdit.Properties.DisplayMember = "Name";
            id_UnidadNegocioLookUpEdit.Properties.ValueMember = "Key";

            par.FechaDesde = par.FechaHasta = Fecha;
        }

        private void frmKmsHsPlanificadas_Load(object sender, EventArgs e)
        {
            kmsHsPlanificadasManager_ParametrosBusquedasBindingSource.DataSource = par;

            //planificadoLookUpEdit.Properties.DataSource = par.PlanificadoList;
            //planificadoLookUpEdit.Properties.DisplayMember = "Name";
            //planificadoLookUpEdit.Properties.ValueMember = "Key";

          //  gridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
          //  // gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
          //  // Create and setup the first summary item.
          //  GridGroupSummaryItem item = new GridGroupSummaryItem();
          //  item.FieldName = "Kms";
          //  item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
          //  item .ShowInGroupColumnFooter = colKms;
          //  gridView1.GroupSummary.Add(item);
          //  // Create and setup the second summary item.
          //  GridGroupSummaryItem item1 = new GridGroupSummaryItem();
          //  item1.FieldName = "Hora";
          //  item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
          // // item1.DisplayFormat = "Total {0:d}";
          //  item1.ShowInGroupColumnFooter = colHora;
          //  gridView1.GroupSummary.Add(item1);
          //  GridGroupSummaryItem item2 = new GridGroupSummaryItem();
          //  item2.FieldName = "Minuto";
          //  item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
         
          //  // item2.DisplayFormat = "Total {0:d}";
          //  item2.ShowInGroupColumnFooter = colMinuto;
          //  gridView1.GroupSummary.Add(item2);
          // GridGroupSummaryItem item3 = new GridGroupSummaryItem();
          ////   item3.Collection.


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Preparando Informe...");

                kmsHsPlanificadasManager_ReporteBindingSource.DataSource = new KmsHsPlanificadasManager().Buscar(par);

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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Informes, "KmsHsPlanificadas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void kmsHsPlanificadasManager_ReporteBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + kmsHsPlanificadasManager_ReporteBindingSource.Count.ToString();
        }

    }
}
