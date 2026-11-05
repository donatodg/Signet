namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;
    using VENET_WSFE_BL;

    public partial class frmComprobantesVentasPresentacion : MultiForm
    {
        private int Id_Empresa;
        private LoginTicket objTicketRespuesta = new LoginTicket();

        public frmComprobantesVentasPresentacion()
        {
            InitializeComponent();
        }

        private void frmComprobantesVentasPresentacion_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVentasPresentar_Actualizar)))
                    btnActualiza.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.EmpresasCuit;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name2";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                id_EmpresaLookUpEdit.ItemIndex = 0;

                Buscar();
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

        private void btnProcesar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Buscar();

                if (gridView1.DataRowCount == 0) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Presentando Comprobantes");

                ComprobantesVentas objComprobante = new ComprobantesVentas();

                foreach (ComprobantesVentasPresentacionManager.SearchResult r in (List<ComprobantesVentasPresentacionManager.SearchResult>)comprobantesVentasPresentacionManager_SearchResultBindingSource.DataSource)
                {
                    if (objTicketRespuesta.ExpirationTime > DateTime.Now)
                    {
                        objComprobante = objTicketRespuesta.PresentarComprobante(objTicketRespuesta, r.Id);
                    }
                    else
                    {
                        ObtenerTicket();
                        if (objTicketRespuesta.CuitEmisor == 0)
                            return;

                        objComprobante = objTicketRespuesta.PresentarComprobante(objTicketRespuesta, r.Id);
                    }

                    r.AFIPCAE = objComprobante.AFIPCAE;
                    r.FechaVtoCAE = objComprobante.FechaVtoCAE;
                    r.ResultadoCAE = objComprobante.ResultadoCAE;
                    r.ObservacionesCAE = objComprobante.ObservacionesCAE;
                    r.EventosCAE = objComprobante.EventosCAE;

                    gridControl1.RefreshDataSource();
                    gridControl1.Refresh();

                    if (objComprobante.ResultadoCAE != "A")
                        throw new ValidationException("El comprobante no se ha podido procesar.");

                    SplashScreenManager.CloseForm(false);
                }
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

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentasPresentacion", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void comprobantesVentasPresentacionManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + comprobantesVentasPresentacionManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                Validate();
                Id_Empresa = (int)id_EmpresaLookUpEdit.EditValue;

                comprobantesVentasPresentacionManager_SearchResultBindingSource.DataSource = ComprobantesVentasPresentacionManager.Buscar(Id_Empresa);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void ObtenerTicket()
        {
            string strTicketRespuesta = "";

            try
            {
                strTicketRespuesta = objTicketRespuesta.ObtenerTicket((int)id_EmpresaLookUpEdit.EditValue);

                if (strTicketRespuesta == "") throw new ValidationException("Error obteniendo Ticket.");
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


        private void btnActualiza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (comprobantesVentasPresentacionManager_SearchResultBindingSource.Current == null) return;

                ComprobantesVentas objComprobante = new ComprobantesVentas();

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Actualizando Comprobante");

                objComprobante = (ComprobantesVentasPresentacionManager.SearchResult)comprobantesVentasPresentacionManager_SearchResultBindingSource.Current;

                if (objTicketRespuesta.ExpirationTime > DateTime.Now)
                {
                    objComprobante = objTicketRespuesta.ActualizarComprobante(objTicketRespuesta, objComprobante.Id);
                }
                else
                {
                    ObtenerTicket();
                    if (objTicketRespuesta.CuitEmisor == 0)
                        return;

                    objComprobante = objTicketRespuesta.ActualizarComprobante(objTicketRespuesta, objComprobante.Id);
                }


                gridControl1.RefreshDataSource();
                gridControl1.Refresh();

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
