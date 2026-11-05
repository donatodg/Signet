namespace VENET_Chats_UI
{
    using System;
    using VENET_Common;
    using VENET_Chats_BL;
    
    public partial class frmNotificacion : MultiForm
    {
        int _Id_User;
        string _User;

        public frmNotificacion()
        {
            InitializeComponent();
        }

        private void frmNotificacion_Load(object sender, EventArgs e)
        {
            _Id_User = ChatsManager.PoseeChatsNuevos();
            _User = ChatsManager.ObtenerNombreContacto(_Id_User);
            lblNotificacion.Text = string.Format("Ha recibido un mensaje nuevo de {0}", _User);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Close();
            frmChats_AddMod f = new frmChats_AddMod(_Id_User, _User);
            f.Show(Owner);
        }

    }
}
