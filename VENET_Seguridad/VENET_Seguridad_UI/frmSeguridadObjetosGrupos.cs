namespace VENET_Seguridad_UI
{
    using System.ComponentModel;
    using VENET_Common;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadObjetosGrupos : MultiForm
    {
        public frmSeguridadObjetosGrupos(int Id_Objeto, string Nombre)
        {
            InitializeComponent();
            Text = "Grupos Asignados con el Objeto: " + Id_Objeto + " - " + Nombre;
            seguridadObjetoGrupoManager_SearchResultBindingSource.DataSource = SeguridadObjetoGrupoManager.Buscar(Id_Objeto);
        }

        private void seguridadObjetoGrupoManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadObjetoGrupoManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
