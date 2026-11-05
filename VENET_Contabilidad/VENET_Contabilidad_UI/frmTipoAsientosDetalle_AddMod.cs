namespace VENET_Contabilidad_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Contabilidad_BL;

    public partial class frmTipoAsientosDetalle_AddMod : MultiForm
    {
        private TipoAsientosDetalleManager manager;
        public TipoAsientosDetalle TipoDetalle;

        public frmTipoAsientosDetalle_AddMod(TipoAsientosDetalle o)
        {
            InitializeComponent();
            TipoDetalle = o;

            manager = new TipoAsientosDetalleManager(o);
        }

        private void frmTipoAsientosDetalle_AddMod_Load(object sender, EventArgs e)
        {
            //id_AlicuotaIvaLookUpEdit.Properties.DataSource = manager.Alicuotas;
            //id_AlicuotaIvaLookUpEdit.Properties.DisplayMember = "Name";
            //id_AlicuotaIvaLookUpEdit.Properties.ValueMember = "Key";

            //FiltroBusquedaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ProductosFiltroBusquedas));
            //FiltroBusquedaLookUpEdit.Properties.DisplayMember = "Value";
            //FiltroBusquedaLookUpEdit.Properties.ValueMember = "Key";

            tipoAsientosDetalleManagerBindingSource.DataSource = manager;
        }

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
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

                //if (ComprobanteDetalle.Importe <= 0)
                //{
                //    Sistema.Mensaje("Debe ingresar un importe válido.");
                //    return;
                //}
                //if (ComprobanteDetalle.PorcDescuento > 100 || ComprobanteDetalle.PorcDescuento < 0)
                //{
                //    Sistema.Mensaje("Debe ingresar un porcentaje de descuento válido.");
                //    return;
                //}
                //if (ComprobanteDetalle.Descripcion == "" || ComprobanteDetalle.Descripcion == null)
                //{
                //    Sistema.Mensaje("Debe ingresar un producto");
                //    return;
                //}

                TipoDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                TipoDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                TipoDetalle.CuentaContable = cuentaContableCheckEdit.Checked;
                TipoDetalle.Debe = debeCheckEdit.Checked;
                TipoDetalle.Id_CuentaContable = Convert.ToInt32(id_CuentaContableLookUpEdit.EditValue);
                TipoDetalle.Id_CuentaImporte = Convert.ToInt32(id_CuentaContableLookUpEdit.EditValue);
              
                //TipoDetalle.Especie = id_EspecieLookUpEdit.Text;
                //TipoDetalle.Cotizacion = manager.Detalle.Cotizacion;
                //TipoDetalle.AlicuotaIva = Convert.ToDecimal(id_AlicuotaIvaLookUpEdit.Text);
                //TipoDetalle.Id_AlicuotaIva = Convert.ToInt32(id_AlicuotaIvaLookUpEdit.EditValue);

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
