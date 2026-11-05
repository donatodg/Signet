namespace SitNET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Threading;
    using System.Windows.Forms;
    using ClassSitNET;
    using VENET_Common;

    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private Config _Config;
        private Thread thread;
        private Thread threadContext;
        private Thread threadLogError;
        private Int16 Intentos = 0;

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == 256)
            {
                if ((Keys)m.WParam == Keys.Escape)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            return base.ProcessKeyPreview(ref m);
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                lblVersion.Text = "Versión " + Application.ProductVersion;
                Cargar_Grilla_Bases();

                //**********************************
                if ((ConfigBases)comboBoxBases.GetSelectedDataRow() == null) return;
                ConfigBases objLogin = (ConfigBases)comboBoxBases.GetSelectedDataRow();
                DbConexion s = new DbConexion(objLogin.DataSource, objLogin.DataBase, objLogin.Pass, objLogin.User, objLogin.Provider, objLogin.Name);
                thread = new Thread(new ThreadStart(new LoginManager("", "").ObtenerFechaHora));
                thread.Start();

                threadContext = new Thread(new ThreadStart(new LoginManager("", "").InicializarContextos));
                threadContext.Start();

                threadLogError = new Thread(new ThreadStart(new LoginManager("", "").VerificaLogError));
                threadLogError.Start();
                //**********************************
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Cargar_Grilla_Bases()
        {
            try
            {
                _Config = Config.ObtenerConfiguracion(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Setup.xml");
                comboBoxBases.Properties.DataSource = _Config.Bases;
                comboBoxBases.Properties.ValueMember = "Name";
                comboBoxBases.Properties.DisplayMember = "Name";

                comboBoxBases.ItemIndex = 0;

                lnkWeb.Text = _Config.Web;
                lnkWeb.Links.Add(0, _Config.Web.Length, _Config.Web);

                lblNombre.Text = _Config.Sistema;
            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Ha ocurrido un error al cargar las empresas.", "Atención", ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            try
            {
                txtMensaje.Text = "Conectando...";

                usernameTextBox.Enabled = false;
                claveTextBox.Enabled = false;
                comboBoxBases.Enabled = false;
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
                btnConfig.Enabled = false;

                Application.DoEvents();

                ConfigBases objLogin = (ConfigBases)comboBoxBases.GetSelectedDataRow();
                DbConexion s = new DbConexion(objLogin.DataSource, objLogin.DataBase, objLogin.Pass, objLogin.User, objLogin.Provider, objLogin.Name);
                LoginManager manager = new LoginManager(usernameTextBox.Text, claveTextBox.Text); if (_Config.Fecha < Sistema.ObtenerFecha()) Application.Exit();

                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.SistemaEnMantenimiento)))
                {
                    Sistema.Mensaje(Convert.ToString(Parametro.ObtenerValor(Parametro.Param.MensajeAlIniciarSistema)));
                    DialogResult = DialogResult.Abort;
                    return;
                }

                //**********************************
                thread.Join();
                //**********************************

                if (manager.VerificaUsuario())
                {
                    ConfigurationManager.AppSettings["CurrentEmpresa"] = comboBoxBases.Text.ToString();
                    ConfigurationManager.AppSettings["CurrentComputerName"] = Environment.MachineName;
                    ConfigurationManager.AppSettings["CurrentUserId"] = manager.Usuario.Id.ToString();
                    ConfigurationManager.AppSettings["CurrentUserName"] = manager.Usuario.Username.ToString().ToUpper();
                    ConfigurationManager.AppSettings["CurrentUserEsAdministrador"] = manager.EsAdministrador.ToString();
                    ConfigurationManager.AppSettings["CurrentUserTema"] = manager.Usuario.Tema;
                    ConfigurationManager.AppSettings["CurrentUserBackColor"] = manager.Usuario.BackColor;
                    ConfigurationManager.AppSettings["RibbonMinimizado"] = manager.Usuario.RibbonMinimizado.ToString();
                    ConfigurationManager.AppSettings["TileConfig"] = manager.Usuario.TileConfig;
                    ConfigurationManager.AppSettings["GuardarConfiguracion"] = "1";
                    ConfigurationManager.AppSettings["TileMostrarTitulos"] = manager.Usuario.TituloTile.ToString();
                    ConfigurationManager.AppSettings["CurrentVersion"] = ProductVersion;

                    VENET_Common.Seguridad.Reload();

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    Sistema.Mensaje("Los datos ingresados son incorrectos.");
                    Intentos += 1;
                    if (Intentos == 3)
                    {
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                }
            }

            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Los datos ingresados son incorrectos.", "Atención", ex);
            }
            finally
            {
                Liberar();
            }
        }

        private void Liberar()
        {
            usernameTextBox.Text = claveTextBox.Text = "";
            txtMensaje.Text = "";
            usernameTextBox.Enabled = true;
            claveTextBox.Enabled = true;
            comboBoxBases.Enabled = true;
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            btnConfig.Enabled = true;

            usernameTextBox.Focus();
            Application.DoEvents();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Form f = new frmPass();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                f = new frmConfig(_Config);
                f.ShowDialog();
            }
        }

        private void usernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) { claveTextBox.Focus(); }
        }

        private void claveTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) { Aceptar(); }
        }

        private void usernameTextBox_Enter(object sender, EventArgs e)
        {
            usernameTextBox.SelectAll();
        }

        private void claveTextBox_Enter(object sender, EventArgs e)
        {
            claveTextBox.SelectAll();
        }

        private void lnkWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            }
            catch { }
        }
    }
}