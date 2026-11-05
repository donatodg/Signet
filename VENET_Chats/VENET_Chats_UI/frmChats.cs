namespace VENET_Chats_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VENET_Chats_BL;
    using VENET_Common;

    public partial class frmChats : MultiForm
    {
        int? Estado = null;

        public frmChats()
        {
            InitializeComponent();
        }

        private void frmChats_Load(object sender, EventArgs e)
        {
            try
            {
                barListItem1.Caption = "Estado: Todos";
                CargarGrilla(Estado);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void barListItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {
            barListItem1.Caption = "Estado: " + ((DevExpress.XtraBars.BarCustomContainerItem)e.Item).ItemLinks[e.Index].Caption;
            if (e.Index == 0) Estado = null;
            if (e.Index == 1) Estado = 1;
            if (e.Index == 2) Estado = 0;
            CargarGrilla(Estado);
        }

        private void CargarGrilla(int? Estado)
        {
            try
            {
                chatsManager_ContactosBindingSource.DataSource = ChatsManager.ObtenerContactos(Estado);
                gridView1.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void chatsManager_ContactosBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Contactos: " + chatsManager_ContactosBindingSource.Count;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Enter))
                Modificar();
        }

        private void Modificar()
        {
            try
            {
                if (chatsManager_ContactosBindingSource.Current == null) return;

                var curr = (ChatsManager.Contactos)chatsManager_ContactosBindingSource.Current;
                curr.Mensajes = 0;
                var f = new frmChats_AddMod(curr.Id_User, curr.Contacto);
                f.Show(Owner);
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

    }
}
