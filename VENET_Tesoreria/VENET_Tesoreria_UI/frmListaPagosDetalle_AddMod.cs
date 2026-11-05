namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmListaPagosDetalle_AddMod : MultiForm, IDisposable
    {
        private ListaPagosDetalleManager manager;
        public ListaPagosDetalle ListaDetalle;
        private Enums.TipoEntidad Tipo;

        public frmListaPagosDetalle_AddMod(ListaPagosDetalle o, Enums.TipoEntidad TipoEntidad)
        {
            InitializeComponent();
            ListaDetalle = o;
            Tipo = TipoEntidad;

            manager = new ListaPagosDetalleManager(o, Tipo);
        }

        private void frmReciboDetalle_AddMod_Load(object sender, EventArgs e)
        {
            listaPagosDetalleManagerBindingSource.DataSource = manager;

            id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
            id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
            id_EntidadLookUpEdit.Properties.ValueMember = "Key";
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

                string m = "";

                if (ListaDetalle.Id_Entidad == 0) m += "Debe ingresar una entidad" + Environment.NewLine;
                if (ListaDetalle.Importe <= 0) m += "Debe ingresar un importe valido.";

                if (m != "")
                {
                    Sistema.Mensaje(m);
                    return;
                }

                ListaDetalle.Entidad = id_EntidadLookUpEdit.Text;
                ListaDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                ListaDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

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

    }
}
