namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel;
    using VENET_Common;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadGruposUsuarios : MultiForm
    {
        public frmSeguridadGruposUsuarios(int Id_Grupo, string Nombre)
        {
            InitializeComponent();
            Text = "Usuarios Asignados al Grupo: " + Id_Grupo + " - " + Nombre;
            seguridadGruposUsuariosManager_SearchResultBindingSource.DataSource = SeguridadGruposUsuariosManager.Buscar(Id_Grupo);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void seguridadGruposUsuariosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadGruposUsuariosManager_SearchResultBindingSource.Count.ToString();
        }

    }
}
