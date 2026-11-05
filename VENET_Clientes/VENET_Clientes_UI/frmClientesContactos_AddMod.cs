namespace VENET_Clientes_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Clientes_BL;

    public partial class frmClientesContactos_AddMod : MultiForm, IDisposable
    {
        private ClientesContactosManager manager;
        public ClientesContactos Contacto;

        public frmClientesContactos_AddMod(ClientesContactos o)
        {
            InitializeComponent();
            Contacto = o;
            manager = new ClientesContactosManager(o);
        }

        private void frmClientesContactos_AddMod_Load(object sender, EventArgs e)
        {
            clientesContactosManagerBindingSource.DataSource = manager;
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

                if (string.IsNullOrEmpty(Contacto.Nombre))
                {
                    Sistema.Mensaje("Debe indicar el nombre del contacto.");
                    return;
                }

                Contacto.FechaAdd = Sistema.ObtenerFechaHora();
                Contacto.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

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
