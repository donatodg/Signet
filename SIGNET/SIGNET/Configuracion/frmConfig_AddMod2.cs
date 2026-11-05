namespace SitNET
{
    using ClassSitNET;
    using System;
    using System.Windows.Forms;
    using VENET_Common;

    public partial class frmConfig_AddMod2 : MultiForm, IDisposable
    {
        //private ConfigManager manager;
        public Config _Config;

        public frmConfig_AddMod2(Config o)
        {
            InitializeComponent();
            _Config = o;
            //manager = new ConfigManager(o);
        }

        private void frmConfig_AddMod2_Load(object sender, EventArgs e)
        {
            nombreTextEdit.EditValue = _Config.Sistema;
            webtextEdit.EditValue = _Config.Web;
            fechadateEdit.EditValue = _Config.Fecha;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Validate();
            //oConfig = manager.Conf;
            _Config.Sistema = nombreTextEdit.EditValue.ToString();
            _Config.Web = webtextEdit.EditValue.ToString();
            _Config.Fecha = Convert.ToDateTime(fechadateEdit.EditValue);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
