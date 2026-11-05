namespace VENET_Chats_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using VENET_Chats_BL;
    using VENET_Common;

    public partial class frmChats_AddMod : MultiForm
    {
        int _Id_User;
        string _User;

        public frmChats_AddMod(int Id_User, string User)
        {
            InitializeComponent();
            _Id_User = Id_User;
            _User = User;
        }

        private void frmChats_AddMod_Load(object sender, EventArgs e)
        {
            Text = "Conversación con " + _User;

            listBoxControlMensajes.Items.AddRange(ChatsManager.RecibirMensajes(_Id_User).ToArray());

            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //buscar los mensajes nuevos
            //moverlos como leidos
            List<string> ls = ChatsManager.RecibirMensajes(_Id_User);
            if (ls.Count > 0)
            {
                listBoxControlMensajes.Items.AddRange(ls.ToArray());
                listBoxControlMensajes.SelectedIndex = listBoxControlMensajes.ItemCount;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Enviar();
        }

        private void Enviar()
        {
            try
            {
                if (txtMensaje.Text == "") return;

                //Enviar Mensaje al usuario
                DateTime f = Sistema.ObtenerFechaHora();
                if (ChatsManager.EnviarMensaje(_Id_User, txtMensaje.Text, f))
                {
                    listBoxControlMensajes.Items.Add(string.Format("YO - {0}: \n\r{1}\n\r", f.ToString("dd/MM/yyyy HH:mm:ss"), txtMensaje.Text));
                    txtMensaje.Text = "";
                    txtMensaje.Focus();
                }
                listBoxControlMensajes.SelectedIndex = listBoxControlMensajes.ItemCount;
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

        private void btnHistorial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHistorial f = new frmHistorial(_Id_User, _User);
            f.ShowDialog(Owner);
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txtMensaje_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Enter))
            {
                Enviar();
                e.Handled = true;
            }
        }

        private void listBoxControlMensajes_DrawItem(object sender, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e)
        {
            if (e.Item.ToString().Substring(0, 2) == "YO")
                e.Appearance.ForeColor = System.Drawing.Color.Blue;
        }

    }
}
