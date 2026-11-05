namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmTipoIva_Configuracion_AddMod : MultiForm, IDisposable
    {
        private TipoIvaConfiguracionManager manager;

        public frmTipoIva_Configuracion_AddMod(TipoIva_Configuracion o)
        {
            InitializeComponent();
            manager = new TipoIvaConfiguracionManager(o);
        }

        private void frmTipoIva_Configuracion_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                List<KeyNamePair> Lista = new List<KeyNamePair>();
                Lista = Sistema.TipoComprobanteVentas;

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Cotizaciones_GeneraPedido)))
                    Lista.Add(new KeyNamePair() { Key = 12, Name = "Pedidos" });

                id_TipoComprobanteLookUpEdit.Properties.DataSource = Lista;
                id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";
                id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";

                id_TipoIvaOrigenLookUpEdit.Properties.DataSource = Sistema.TiposIva;
                id_TipoIvaOrigenLookUpEdit.Properties.DisplayMember = "Name";
                id_TipoIvaOrigenLookUpEdit.Properties.ValueMember = "Key";

                id_TipoIvaDestinoLookUpEdit.Properties.DataSource = Sistema.TiposIva;
                id_TipoIvaDestinoLookUpEdit.Properties.DisplayMember = "Name";
                id_TipoIvaDestinoLookUpEdit.Properties.ValueMember = "Key";

                tipoIvaConfiguracionManagerBindingSource.DataSource = manager;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                Validate();
                manager.Save();
                DialogResult = DialogResult.OK;
                Close();
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
