namespace VENET_Chats_UI
{
    using System;
    using VENET_Chats_BL;
    using VENET_Common;

    public partial class frmHistorial : MultiForm
    {
        int _Id_User;
        string _User;

        public frmHistorial(int Id_User, string User)
        {
            InitializeComponent();
            _Id_User = Id_User;
            _User = User;
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Historial de Conversación: " + _User;
                listBoxControlMensajes.Items.AddRange(ChatsManager.VerHistorial(_Id_User).ToArray());
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void listBoxControlMensajes_DrawItem(object sender, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e)
        {
            if (e.Item.ToString().Substring(0, 2) == "YO")
                e.Appearance.ForeColor = System.Drawing.Color.Blue;
        }

    }
}
