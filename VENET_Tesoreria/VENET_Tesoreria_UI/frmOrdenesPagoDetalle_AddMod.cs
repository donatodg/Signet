namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmOrdenesPagoDetalle_AddMod : MultiForm, IDisposable
    {
        private OrdenesPagoDetalleManager manager;
        public OrdenesPagoDetalle OPDetalle;
        private int IdSucursal;

        public frmOrdenesPagoDetalle_AddMod(OrdenesPagoDetalle o, int Id_Sucursal)
        {
            InitializeComponent();
            OPDetalle = o;
            IdSucursal = Id_Sucursal;
            manager = new OrdenesPagoDetalleManager(o, IdSucursal);
        }

        private void frmOrdenesPagoDetalle_AddMod_Load(object sender, EventArgs e)
        {
            ordenesPagoDetalleManagerBindingSource.DataSource = manager;

            id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
            id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
            id_EspecieLookUpEdit.Properties.ValueMember = "Key";
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

                if (OPDetalle.Importe <= 0)
                {
                    Sistema.Mensaje("Debe ingresar un importe valido.");
                    return;
                }

                OPDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                OPDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                OPDetalle.Especie = id_EspecieLookUpEdit.Text;
                OPDetalle.Cotizacion = manager.OPDetalle.Cotizacion;

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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void frmOrdenesPagoDetalle_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void detalleTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }
    }
}
