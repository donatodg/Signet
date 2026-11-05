namespace SitNET
{
    using ClassSitNET;
    using System;
    using System.Windows.Forms;
    using VENET_Common;

    public partial class frmConfig_AddMod : MultiForm
    {
        //private ConfigManager manager;
        public ConfigBases _Config;

        public frmConfig_AddMod(ConfigBases o)
        {
            InitializeComponent();
            //manager = new ConfigManager(o);
            _Config = o;
        }

        private void frmConfig_AddMod_Load(object sender, EventArgs e)
        {
            //configManagerBindingSource.DataSource = manager;
            nameTextEdit.EditValue = _Config.Name;
            dataBaseTextEdit.EditValue = _Config.DataBase;
            dataSourceTextEdit.EditValue = _Config.DataSource;
            userTextEdit.EditValue = _Config.User;
            passTextEdit.EditValue = _Config.Pass;
            providerComboBoxEdit.EditValue = _Config.Provider;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Validate();
            //oConfig = manager.Conf;

            _Config.Name = nameTextEdit.EditValue.ToString();
            _Config.DataBase = dataBaseTextEdit.EditValue.ToString();
            _Config.DataSource = dataSourceTextEdit.EditValue.ToString();
            _Config.User = userTextEdit.EditValue.ToString();
            _Config.Pass = passTextEdit.EditValue.ToString();
            _Config.Provider = providerComboBoxEdit.EditValue.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
