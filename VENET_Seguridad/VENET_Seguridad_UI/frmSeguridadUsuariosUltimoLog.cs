namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadUsuariosUltimoLog : MultiForm
    {
        private SeguridadUsuariosUltimoLogManager manager = new SeguridadUsuariosUltimoLogManager();

        public frmSeguridadUsuariosUltimoLog(int IdUser, string User)
        {
            InitializeComponent();
            Text += User;
            seguridadUsuariosUltimoLogManager_SearchResultBindingSource.DataSource = manager.Buscar(IdUser);
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosUltimoLog", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void seguridadUsuariosUltimoLogManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosUltimoLogManager_SearchResultBindingSource.Count.ToString();
        }
    }
}
