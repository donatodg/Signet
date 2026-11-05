namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadUsuariosActivos : MultiForm
    {
        private SeguridadUsuariosActivosManager manager = new SeguridadUsuariosActivosManager();

        public frmSeguridadUsuariosActivos()
        {
            InitializeComponent();
        }

        private void frmSeguridadUsuariosActivos_Load(object sender, EventArgs e)
        {
            seguridadUsuariosActivosManager_SearchResultBindingSource.DataSource = manager.Buscar();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosActivos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void seguridadUsuariosActivosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosActivosManager_SearchResultBindingSource.Count.ToString();
        }

    }
}
