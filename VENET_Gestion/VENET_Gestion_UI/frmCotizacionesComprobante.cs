namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using System.Linq;
    using System.Collections.Generic;

    public partial class frmCotizacionesComprobante : MultiForm
    {
        public int Id_Comprobante;
        public string Tipo_Comprobante;
        //private bool _SoloPedidos;

        public frmCotizacionesComprobante()//bool SoloPedidos)
        {
            InitializeComponent();
            //_SoloPedidos = SoloPedidos;
        }

        private void frmCotizacionesComprobante_Load(object sender, EventArgs e)
        {
            try
            {
                //if (_SoloPedidos)
                //{
                //    List<KeyNamePair> Lista = new List<KeyNamePair>();
                //    Lista.Add(new KeyNamePair() { Key = 12, Name = "Pedidos" });

                //    id_TipoComprobanteLookUpEdit.Properties.DataSource = Lista;
                //    id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";
                //    id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";
                //    id_TipoComprobanteLookUpEdit.ItemIndex = 0;
                //    Id_Comprobante = (int)id_TipoComprobanteLookUpEdit.EditValue;
                //}
                //else
                //{
                    id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobanteVentas;
                    id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";
                    id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";

                    if (Sistema.TipoComprobanteVentas.Count() > 0)
                    {
                        id_TipoComprobanteLookUpEdit.ItemIndex = 0;
                        Id_Comprobante = (int)id_TipoComprobanteLookUpEdit.EditValue;
                    }
                    else
                    {
                        Sistema.Mensaje("No hay declarados comprobantes de Ventas.");
                        return;
                    }
                //}
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

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Validate();
            Id_Comprobante = (int)id_TipoComprobanteLookUpEdit.EditValue;
            Tipo_Comprobante = id_TipoComprobanteLookUpEdit.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
