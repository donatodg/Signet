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

    public partial class frmReciboDetallePF_AddMod : MultiForm
    {
        private ReciboDetalleManager manager;
        public RecibosDetalle RecDetalle;
        private int IdSucursal;

        public frmReciboDetallePF_AddMod(RecibosDetalle o, int Id_Sucursal)
        {
            InitializeComponent();
            RecDetalle = o;
            IdSucursal = Id_Sucursal;
            manager = new ReciboDetalleManager(o, Id_Sucursal);
        }

        private void frmReciboDetallePF_AddMod_Load(object sender, EventArgs e)
        {
            reciboDetalleManagerBindingSource.DataSource = manager;

            id_TipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
            id_TipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
            id_TipoEntidadLookUpEdit.Properties.ValueMember = "Key";

            id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
            id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
            id_EntidadLookUpEdit.Properties.ValueMember = "Key";

            idEspecieLookUpEdit.Properties.DataSource = manager.EspeciesPF;
            idEspecieLookUpEdit.Properties.DisplayMember = "Name";
            idEspecieLookUpEdit.Properties.ValueMember = "Key";

            //if (Sistema.Especies.Count > 0)
            //{
            //    idEspecieLookUpEdit.ItemIndex = 0;
            //    manager.ReciboDetalle.Id_Especie = (int)idEspecieLookUpEdit.EditValue;
            //}
            //else
            //{
            //    Sistema.Mensaje("El usuario no posee especies asignadas.");
            //    Close();
            //}

                    
            if (manager.Entidades.Count > 0)
            {
                id_EntidadLookUpEdit.ItemIndex = 0;
                manager.ReciboDetalle.Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;
            }
            else
            {
                Sistema.Mensaje("El usuario no posee entidades asignadas.");
                Close();
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

                if (RecDetalle.Id_Entidad == null || RecDetalle.Id_Entidad == 0)
                {
                    Sistema.Mensaje("Debe ingresar una entidad.");
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

        private void id_TipoEntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (manager.ReciboDetalle != null && id_TipoEntidadLookUpEdit.ItemIndex != -1)
            {
                manager.ReciboDetalle.Id_TipoEntidad = (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.EditValue = manager.ReciboDetalle.Id_Entidad = null;
                if (manager.ReciboDetalle.Id_TipoEntidad != Enums.TipoEntidad.Proveedor_Financiero)
                {
                    idEspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
                    idEspecieLookUpEdit.ItemIndex = 0;
                    manager.ReciboDetalle.Id_Especie = (int)idEspecieLookUpEdit.EditValue;
                }
                else
                {
                    idEspecieLookUpEdit.Properties.DataSource = null;
                    manager.ReciboDetalle.Id_Especie = 0;
                    idEspecieLookUpEdit.ItemIndex = 0;
                }
            }
        }

        private void id_EntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (manager.ReciboDetalle != null && id_TipoEntidadLookUpEdit.ItemIndex != -1 && (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue == Enums.TipoEntidad.Proveedor_Financiero && id_EntidadLookUpEdit.ItemIndex != -1)
            {
                Validate();
                manager.ReciboDetalle.Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;
                idEspecieLookUpEdit.Properties.DataSource = manager.EspeciesPF;
                if (manager.EspeciesPF.Count > 0)
                    idEspecieLookUpEdit.EditValue = manager.ReciboDetalle.Id_Especie = manager.EspeciesPF.ElementAt(0).Key;
                else
                    idEspecieLookUpEdit.EditValue = manager.ReciboDetalle.Id_Especie = 0;
            }
        }

        private void detalleTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Guardar();
        }
    }
}
