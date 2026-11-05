namespace VENET_Common
{
    using System;
    using System.Windows.Forms;

    public partial class frmConfig_AddMod2 : Form, IDisposable
    {
        public Config _Config;

        public frmConfig_AddMod2(Config o)
        {
            InitializeComponent();
            _Config = o;
        }

        private void frmConfig_AddMod2_Load(object sender, EventArgs e)
        {
            nombreTextEdit.EditValue = _Config.Sistema;
            webtextEdit.EditValue = _Config.Web;
            linkDatatextEdit.EditValue = _Config.LinkData;
            fechadateEdit.EditValue = _Config.Fecha;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Validate();
            _Config.Sistema = nombreTextEdit.EditValue.ToString();
            _Config.Web = webtextEdit.EditValue.ToString();
            _Config.LinkData = linkDatatextEdit.EditValue.ToString();
            _Config.Fecha = Convert.ToDateTime(fechadateEdit.EditValue);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
