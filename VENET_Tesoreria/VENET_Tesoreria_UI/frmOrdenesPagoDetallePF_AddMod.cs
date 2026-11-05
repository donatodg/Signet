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

    public partial class frmOrdenesPagoDetallePF_AddMod : MultiForm
    {
        private OrdenesPagoDetalleManager manager;
        public OrdenesPagoDetalle OPDetalle;
        private int IdSucursal;

        public frmOrdenesPagoDetallePF_AddMod(OrdenesPagoDetalle o, int Id_Sucursal)
        {
            InitializeComponent();
            OPDetalle = o;
            IdSucursal = Id_Sucursal;
            manager = new OrdenesPagoDetalleManager(o, IdSucursal);
        }

        private void frmOrdenesPagoDetallePF_AddMod_Load(object sender, EventArgs e)
        {
            ordenesPagoDetalleManagerBindingSource.DataSource = manager;

            id_TipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
            id_TipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
            id_TipoEntidadLookUpEdit.Properties.ValueMember = "Key";

            id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
            id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
            id_EntidadLookUpEdit.Properties.ValueMember = "Key";

            idEspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
            idEspecieLookUpEdit.Properties.DisplayMember = "Name";
            idEspecieLookUpEdit.Properties.ValueMember = "Key";

            if (Sistema.Especies.Count > 0)
            {
                idEspecieLookUpEdit.ItemIndex = 0;
                manager.OPDetalle.Id_Especie = (int)idEspecieLookUpEdit.EditValue;
            }
            else
            {
                Sistema.Mensaje("El usuario no posee especies asignadas.");
                Close();
            }


            //if (manager.OPDetalle.Id_TipoEntidad == 0)
            //    id_TipoEntidadLookUpEdit.EditValue = manager.OPDetalle.Id_TipoEntidad = Enums.TipoEntidad.Proveedor_Financiero;

            Validate();
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

                if (OPDetalle.Id_Entidad == null)
                {
                    Sistema.Mensaje("Debe ingresar una entidad.");
                    return;
                }

                OPDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                OPDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                OPDetalle.Especie = idEspecieLookUpEdit.Text;
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

        private void id_TipoEntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (manager.OPDetalle != null && id_TipoEntidadLookUpEdit.ItemIndex != -1)
            {
                manager.OPDetalle.Id_TipoEntidad = (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.EditValue = manager.OPDetalle.Id_Entidad = null;
                if (manager.OPDetalle.Id_TipoEntidad != Enums.TipoEntidad.Proveedor_Financiero)
                {
                    idEspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
                    idEspecieLookUpEdit.ItemIndex = 0;
                    manager.OPDetalle.Id_Especie = (int)idEspecieLookUpEdit.EditValue;
                }
                else
                {
                    idEspecieLookUpEdit.Properties.DataSource = null;
                    manager.OPDetalle.Id_Especie = 0;
                    idEspecieLookUpEdit.ItemIndex = 0;
                }
            }
        }

        private void id_EntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (manager.OPDetalle != null && id_TipoEntidadLookUpEdit.ItemIndex != -1 && (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue == Enums.TipoEntidad.Proveedor_Financiero && id_EntidadLookUpEdit.ItemIndex != -1)
            {
                Validate();
                manager.OPDetalle.Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;
                idEspecieLookUpEdit.Properties.DataSource = manager.EspeciesPF;
                if (manager.EspeciesPF.Count > 0)
                    idEspecieLookUpEdit.EditValue = manager.OPDetalle.Id_Especie = manager.EspeciesPF.ElementAt(0).Key;
                else
                    idEspecieLookUpEdit.EditValue = manager.OPDetalle.Id_Especie = 0;
            }
        }

        private void detalleTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }
    }
}

