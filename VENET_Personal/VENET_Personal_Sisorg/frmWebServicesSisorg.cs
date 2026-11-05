namespace VENET_Personal_Sisorg
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;

    public partial class frmWebServicesSisorg : MultiForm
    {
        public frmWebServicesSisorg()
        {
            InitializeComponent();
        }

        private void frmWebServicesSisorg_Load(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Buscando Personal...");

                webServicesSisorg_resultInsertBindingSource.DataSource = WebServicesSisorg.BuscarPendientes();

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

        private void webServicesSisorg_resultInsertBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + webServicesSisorg_resultInsertBindingSource.Count.ToString();
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "WebServicesSisorg", Enums.Accion.Agregar)) return;
                //if (webServicesSisorg_resultInsertBindingSource.Current == null) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Importando Personal...");

                Validate();

                foreach (WebServicesSisorg.resultInsert row in webServicesSisorg_resultInsertBindingSource)
                    if (row.Seleccionado)
                        WebServicesSisorg.InsertPersonal(row);

                //Ver mensaje retorno InsertPersonal.

                //Actualiza Grilla
                webServicesSisorg_resultInsertBindingSource.DataSource = WebServicesSisorg.BuscarPendientes();

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
            //try
            //{
            //    var s = new x.SWMonitorizacionSoapClient().InsertarActualizarDespacho("LINEA19", "WEBLINEA19269", 97, 269, "19", "UNICO", "1", 2004522, 2297, "2297", "JUY221", new DateTime(2017, 09, 19), "70915", "FIANDACA(70915)", "Fiandaca", "Gustavo", "70915", "DNI", 0, 2, new DateTime(2017, 09, 19),
            //        "COID", "9", 190, new DateTime(2017, 07, 25, 15, 00, 00), new DateTime(2017, 07, 25, 18, 10, 00), "05;08;08;05;06;06;06;08;05;05;04;05;05;04;04;06;10;05;07;04;03;04;05;07;07;07;07;05;06;05;04;05;05;04",
            //        "COID", "9", 190, new DateTime(2017, 07, 25, 19, 00, 00), new DateTime(2017, 07, 25, 22, 10, 00), "05;08;08;05;06;06;06;08;05;05;04;05;05;04;04;06;10;05;07;04;03;04;05;07;07;07;07;05;06;05;04;05;05;04");
            //    Sistema.Mensaje(s);
            //    s = "";
            //}
            //catch (Exception cc)
            //{
            //    Sistema.Mensaje(cc.Message);
            //}
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "WebServicesSisorg", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

    }
}
