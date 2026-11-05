namespace VENET_Tesoreria_UI
{
    using System;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Tesoreria_BL;

    public partial class frmInicioTurnos : MultiForm, IDisposable
    {
        private InicioTurnoManager manager = new InicioTurnoManager(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"].ToString()));

        public frmInicioTurnos()
        {
            InitializeComponent();
        }

        private void frmInicioTurnos_Load(object sender, EventArgs e)
        {
            inicioTurnoManagerBindingSource.DataSource = manager;
            if (manager.Turno.Id != 0) btnAceptar.Text = "Continuar";

            if (manager.Turno.Id_Usuario != Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"].ToString()))
            {
                Sistema.Mensaje("Existe un turno abierto por otro usuario.", "Inicio de Turno");
                //btnAceptar.Text = "Cerrar Turno";
                btnAceptar.Visible = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.Turno.Id_Usuario != Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"].ToString()))
                {
                    manager.Turno.FechaFin = Sistema.ObtenerFechaHora();
                    manager.Save();
                    Application.Exit();
                }
                else
                {
                    manager.Save();

                    ConfigurationManager.AppSettings["Turno"] = manager.Turno.Id.ToString();
                    ConfigurationManager.AppSettings["InicioTurno"] = manager.Turno.FechaInicio.ToString();

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Sistema.Mensaje(ex.Message, "Inicio de Turno", ex);
            }
        }
    }
}
