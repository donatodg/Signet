namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Gestion_BL;

    public partial class frmComprobanteVentaAsociado : MultiForm
    {
        public int Id_Comprobante;
        public string Tipo_Comprobante;
        private ComprobanteVentaAsociadoManager manager;

        public frmComprobanteVentaAsociado(Int32 Id_Comprobante)
        {
            InitializeComponent();
            manager = new ComprobanteVentaAsociadoManager(Id_Comprobante);
        }

        private void frmCotizacionesComprobante_Load(object sender, EventArgs e)
        {
            try
            {
                comprobanteVentaAsociadoManagerBindingSource.DataSource = manager;

                id_ComprobanteVenta_AsociadoLookUpEdit.Properties.DataSource = manager.ComprobantesLista;
                id_ComprobanteVenta_AsociadoLookUpEdit.Properties.DisplayMember = "Name";
                id_ComprobanteVenta_AsociadoLookUpEdit.Properties.ValueMember = "Key";
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
            manager.Save();
            DialogResult = DialogResult.OK;
        }

        private void id_ComprobanteVenta_AsociadoLookUpEdit_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
                id_ComprobanteVenta_AsociadoLookUpEdit.EditValue = manager.Comprobante.Id_ComprobanteVenta_Asociado = null;
            }
        }
    }
}
