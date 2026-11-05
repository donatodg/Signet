namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmReciboDetallePercep_AddMod : MultiForm
    {
        private ReciboDetalleManager manager;
        public RecibosDetalle RecDetalle;
        private int IdSucursal;

        public frmReciboDetallePercep_AddMod(RecibosDetalle o, int Id_Sucursal)
        {
            InitializeComponent();
            RecDetalle = o;
            IdSucursal = Id_Sucursal;
            manager = new ReciboDetalleManager(o, Id_Sucursal);
        }

        private void frmReciboDetallePF_AddMod_Load(object sender, EventArgs e)
        {
            reciboDetalleManagerBindingSource.DataSource = manager;

            id_TipoPercepcionLookUpEdit.Properties.DataSource = manager.TipoPercepciones;
            id_TipoPercepcionLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoPercepcionLookUpEdit.Properties.ValueMember = "Key";

            idEspecieLookUpEdit.Properties.DataSource = manager.Especies;
            idEspecieLookUpEdit.Properties.DisplayMember = "Name";
            idEspecieLookUpEdit.Properties.ValueMember = "Key";

            if (manager.ReciboDetalle.Id_TipoPercepcion == 0 || manager.ReciboDetalle.Id_TipoPercepcion == null)
            {
                id_TipoPercepcionLookUpEdit.EditValue = manager.ReciboDetalle.Id_TipoPercepcion = manager.TipoPercepciones.First().Key;
            }

            Validate();
        }

        private void Guardar()
        {
            try
            {
                Validate();

                if (RecDetalle.Importe <= 0)
                {
                    Sistema.Mensaje("Debe ingresar un importe valido.");
                    return;
                }

                if (RecDetalle.Id_TipoPercepcion == null || RecDetalle.Id_TipoPercepcion == 0)
                {
                    Sistema.Mensaje("Debe ingresar una percepción.");
                    return;
                }

                RecDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                RecDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                RecDetalle.Especie = idEspecieLookUpEdit.Text;
                RecDetalle.Cotizacion = manager.ReciboDetalle.Cotizacion;

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

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void detalleTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }
    }
}
