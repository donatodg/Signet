namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmPedidosConfirmacionParcial : MultiForm
    {
        private int _Id_Pedido;
        public List<PedidosDetalleProcesados> ListaAProcesar;
        public bool TodoProcesado = true;

        public frmPedidosConfirmacionParcial(int Id_Pedido)
        {
            InitializeComponent();
            _Id_Pedido = Id_Pedido;
        }

        private void frmPedidosConfirmacionParcial_Load(object sender, EventArgs e)
        {
            try
            {
                pedidosConfirmacionParcialManager_SearchResultBindingSource.DataSource = PedidosConfirmacionParcialManager.Buscar(_Id_Pedido);
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
            barStaticItemFooter.Caption = "Cantidad de Registros: " + pedidosConfirmacionParcialManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Validate();
                ListaAProcesar = new List<PedidosDetalleProcesados>();

                string Errores = "";

                foreach (PedidosConfirmacionParcialManager.SearchResult r in (List<PedidosConfirmacionParcialManager.SearchResult>)pedidosConfirmacionParcialManager_SearchResultBindingSource.DataSource)
                {
                    if (r.CantidadAProcesar > (r.Cantidad - r.CantidadProcesada))
                        Errores += "La cantidad procesada es mayor a la pendiente en " + r.Producto + "\r\n";
                    else
                    {
                        if (TodoProcesado && r.Cantidad != (r.CantidadAProcesar + r.CantidadProcesada))
                            TodoProcesado = false;

                        if (r.CantidadAProcesar > 0)
                            ListaAProcesar.Add(new PedidosDetalleProcesados()
                            {
                                Id_PedidoDetalle = r.Id_PedidoDetalle,
                                Cantidad = r.CantidadAProcesar,
                                Id_PedidoOriginal = r.Id_PedidoOriginal,
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
