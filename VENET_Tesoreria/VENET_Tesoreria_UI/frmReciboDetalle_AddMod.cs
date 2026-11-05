namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;
    
    public partial class frmReciboDetalle_AddMod : MultiForm, IDisposable
    {
        private ReciboDetalleManager manager;
        public RecibosDetalle ReciboDetalle;
        private int IdSucursal;

        public frmReciboDetalle_AddMod(RecibosDetalle o, int Id_Sucursal)
        {
            InitializeComponent();
            ReciboDetalle = o;
            IdSucursal = Id_Sucursal;

            manager = new ReciboDetalleManager(o, IdSucursal);
        }

        private void frmReciboDetalle_AddMod_Load(object sender, EventArgs e)
        {
            reciboDetalleManagerBindingSource.DataSource = manager;

            id_EspecieLookUpEdit.Properties.DataSource = manager.Especies; //Sistema.Especies;
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

                if (ReciboDetalle.Importe <= 0)
                {
                    Sistema.Mensaje("Debe ingresar un importe valido.");
                    return;
                }

                ReciboDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                ReciboDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                ReciboDetalle.Especie = id_EspecieLookUpEdit.Text;
                ReciboDetalle.Cotizacion = manager.ReciboDetalle.Cotizacion;

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

        private void frmReciboDetalle_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void detalleTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }
    }
}
