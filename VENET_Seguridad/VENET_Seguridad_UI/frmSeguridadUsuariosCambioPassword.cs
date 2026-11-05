namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_DataEntity;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadUsuariosCambioPassword : MultiForm, IDisposable
    {
        private SeguridadUsuariosCambioPasswordManager manager;

        public frmSeguridadUsuariosCambioPassword()
        {
            InitializeComponent();
            manager = new SeguridadUsuariosCambioPasswordManager();
            Text = "Cambio de Clave Usuario: " + ConfigurationManager.AppSettings["CurrentUserName"];
        }

        private void frmSeguridadUsuariosCambioPassword_Load(object sender, EventArgs e)
        {
            seguridadUsuariosCambioPasswordManagerBindingSource.DataSource = manager;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Validate();
                manager.Save();
                Sistema.Mensaje("Se cambió con exito la clave del usuario.", "Cambio de clave");
                Close();
            }
            catch (ValidationException exv)
            {
                passAnteriorTextEdit.Text = passNuevaTextEdit.Text = passNueva2TextEdit.Text = "";
                manager.CambioClave.PassAnterior = manager.CambioClave.PassNueva = manager.CambioClave.PassNueva2 = "";
                passAnteriorTextEdit.Focus();
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }
    }
}
