namespace SitNET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using VENET_Common;

    public partial class frmPass : Form
    {
        public frmPass()
        {
            InitializeComponent();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            if (txtPass.Text == ((char)86).ToString() + ((char)97).ToString() + ((char)99).ToString() + ((char)101).ToString() + ((char)115).ToString())
                DialogResult = DialogResult.OK;
            else
            {
                Sistema.Mensaje("La clave es incorrecta.");
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Aceptar();
            }
        }
    }
}
