namespace VENET_Clientes_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Clientes_BL;

    public partial class frmClientesEntregas_AddMod : MultiForm, IDisposable
    {
        private ClientesEntregasManager manager;
        public ClientesEntregas Entrega;

        public frmClientesEntregas_AddMod(ClientesEntregas o)
        {
            InitializeComponent();
            Entrega = o;
            manager = new ClientesEntregasManager(o);
        }

        private void frmClientesDescuentos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                clientesEntregasManagerBindingSource.DataSource = manager;
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

        private void Guardar()
        {
            try
            {
                Validate();

                //if (Descuento.Descuento <= 0 || Descuento.Descuento > 100)
                //{
                //    Sistema.Mensaje("Debe indicar un descuento válido.");
                //    return;
                //}
                //Descuento.Categoria = id_Categoria2LookUpEdit.Text;
                Entrega.FechaAdd = Sistema.ObtenerFechaHora();
                Entrega.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

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
