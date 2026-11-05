namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmComprobantesVentasConfirmacionParcial : MultiForm
    {
        private int _Id_ComprobanteVenta;
        public List<ComprobantesVentasDetalleProcesados> ListaAProcesar = new List<ComprobantesVentasDetalleProcesados>();
        public bool TodoProcesado = true;

        public frmComprobantesVentasConfirmacionParcial(int Id_ComprobanteVenta)
        {
            InitializeComponent();
            _Id_ComprobanteVenta = Id_ComprobanteVenta;
        }

        private void frmComprobantesVentasConfirmacionParcial_Load(object sender, EventArgs e)
        {
            try
            {
                comprobantesVentasConfirmacionParcialManager_SearchResultBindingSource.DataSource = ComprobantesVentasConfirmacionParcialManager.Buscar(_Id_ComprobanteVenta);
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

        private void comprobantesVentasConfirmacionParcialManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + comprobantesVentasConfirmacionParcialManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Validate();

                string Errores = "";

                foreach (ComprobantesVentasConfirmacionParcialManager.SearchResult r in (List<ComprobantesVentasConfirmacionParcialManager.SearchResult>)comprobantesVentasConfirmacionParcialManager_SearchResultBindingSource.DataSource)
                {
                    if (r.CantidadAProcesar > (r.Cantidad - r.CantidadProcesada))
                        Errores += "La cantidad procesada es mayor a la pendiente en " + r.Producto + "\r\n";
                    else
                    {
                        if (TodoProcesado && r.Cantidad != (r.CantidadAProcesar + r.CantidadProcesada))
                            TodoProcesado = false;

                        if (r.CantidadAProcesar > 0)
                            ListaAProcesar.Add(new ComprobantesVentasDetalleProcesados()
                            {
                                Id_ComprobanteVentaDetalle = r.Id_ComprobanteVentaDetalle,
                                Cantidad = r.CantidadAProcesar,
                                Id_ComprobanteVentaOriginal = r.Id_ComprobanteVentaOriginal,
                                Id_ComprobanteVentaProcesado = r.Id_ComprobanteVentaProcesado
                            });
                    }
                }

                if (Errores != "") throw new ValidationException(Errores);

                DialogResult = System.Windows.Forms.DialogResult.OK;
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

    }
}
