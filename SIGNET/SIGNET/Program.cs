namespace SitNET
{
    using DevExpress.Skins;
    using System;
    //using System.Configuration;
    using System.Windows.Forms;
    
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
         {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.UserSkins.BonusSkins.Register();
            SkinManager.EnableFormSkins(); 
            
            Form f = new VENET_Common.frmLogin();
            if (f.ShowDialog() == DialogResult.OK)
                Application.Run(new frmMain());
        }
    }
}
