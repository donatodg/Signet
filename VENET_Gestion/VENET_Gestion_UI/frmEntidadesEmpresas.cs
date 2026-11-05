namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmEntidadesEmpresas : MultiForm, IDisposable
    {
        private EntidadesEmpresasManager manager;
        private Enums.TipoEntidad _TipoEntidad;
        private int _Id_Entidad;

        public frmEntidadesEmpresas(Enums.TipoEntidad TipoEntidad, int Id_Entidad)
        {
            InitializeComponent();
            _Id_Entidad = Id_Entidad;
            _TipoEntidad = TipoEntidad;
            manager = new EntidadesEmpresasManager(TipoEntidad, Id_Entidad);
            Text = "Empresas Asignadas a la Entidad";
        }

        private void frmEntidadesEmpresas_Load(object sender, EventArgs e)
        {
            try
            {
                entidadesEmpresasManager_SearchResultBindingSource.DataSource = manager.Buscar();
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

        private void entidadesEmpresasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + entidadesEmpresasManager_SearchResultBindingSource.Count.ToString();
        }

        private void frmEntidadesEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "EntidadesEmpresas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "EntidadesEmpresas", Enums.Accion.Agregar)) return;

            var f = new frmEntidadesEmpresas_AddMod(_TipoEntidad, _Id_Entidad);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                entidadesEmpresasManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "EntidadesEmpresas", Enums.Accion.Eliminar)) return;

                if (entidadesEmpresasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    EntidadesEmpresasManager.Eliminar(new EntidadesEmpresas() { Id = ((EntidadesEmpresasManager.SearchResult)entidadesEmpresasManager_SearchResultBindingSource.Current).Id });
                    entidadesEmpresasManager_SearchResultBindingSource.RemoveCurrent();
                    entidadesEmpresasManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}
