namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using System.Linq;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmDuplicaComprobante : MultiForm
    {
        private DuplicaComprobanteManager manager;
        public int Id_Comprobante;
        public string Tipo_Comprobante;
        public Enums.TipoEntidad Id_TipoEntidad;
        public int Id_Entidad;


        public frmDuplicaComprobante()
        {
            InitializeComponent();
        }

        private void frmCotizacionesComprobante_Load(object sender, EventArgs e)
        {
            try
            {
                manager = new DuplicaComprobanteManager();

                id_TipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
                id_TipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
                id_TipoEntidadLookUpEdit.Properties.ValueMember = "Key";

                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades(Enums.TipoEntidad.Cliente);
                id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
                id_EntidadLookUpEdit.Properties.ValueMember = "Key";

                id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobanteVentas;
                id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";
                id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";

                if (Sistema.TipoComprobanteVentas.Count() > 0)
                {
                    id_TipoComprobanteLookUpEdit.ItemIndex = 0;
                    Id_Comprobante = (int)id_TipoComprobanteLookUpEdit.EditValue;

                    id_TipoEntidadLookUpEdit.ItemIndex = 0;
                    
                }
                else
                {
                    Sistema.Mensaje("No hay declarados comprobantes de Ventas.");
                    return;
                }
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
            Guardar();
        }

        private void id_TipoComprobanteLookUpEdit_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Guardar();
        }

        private void Guardar()
        {
            try
            {
                Validate();

                if (id_EntidadLookUpEdit.EditValue == null) throw new ValidationException("Debe seleccionar una entidad");

                Id_Comprobante = (int)id_TipoComprobanteLookUpEdit.EditValue;
                Tipo_Comprobante = id_TipoComprobanteLookUpEdit.Text;
                Id_TipoEntidad = (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue;
                Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;

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

        private void id_TipoEntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

            if (id_TipoEntidadLookUpEdit.ItemIndex != -1)
            {
                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades((Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue);
                id_EntidadLookUpEdit.EditValue = null;
            }
        }
    }
}
