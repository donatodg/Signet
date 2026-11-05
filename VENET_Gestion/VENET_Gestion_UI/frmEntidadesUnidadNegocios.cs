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

    public partial class frmEntidadesUnidadNegocios : MultiForm, IDisposable
    {
        private EntidadesUnidadNegociosManager manager;
        private Enums.TipoEntidad _TipoEntidad;
        private int _Id_Entidad;

        public frmEntidadesUnidadNegocios(Enums.TipoEntidad TipoEntidad, int Id_Entidad)
        {
            InitializeComponent();
            _Id_Entidad = Id_Entidad;
            _TipoEntidad = TipoEntidad;
            manager = new EntidadesUnidadNegociosManager(TipoEntidad, Id_Entidad);
            Text = "Unidades Negocios Asignadas a la Entidad";
        }

        private void frmEntidadesUnidadNegocios_Load(object sender, EventArgs e)
        {
            try
            {
                entidadesUnidadNegociosManager_SearchResultBindingSource.DataSource = manager.Buscar();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "EntidadesUnidadNegocios", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "EntidadesUnidadNegocios", Enums.Accion.Agregar)) return;

            var f = new frmEntidadesUnidadNegocios_AddMod(_TipoEntidad, _Id_Entidad);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                entidadesUnidadNegociosManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "EntidadesUnidadNegocios", Enums.Accion.Eliminar)) return;

                if (entidadesUnidadNegociosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    EntidadesUnidadNegociosManager.Eliminar(new EntidadesUnidadNegocios() { Id = ((EntidadesUnidadNegociosManager.SearchResult)entidadesUnidadNegociosManager_SearchResultBindingSource.Current).Id });
                    entidadesUnidadNegociosManager_SearchResultBindingSource.RemoveCurrent();
                    entidadesUnidadNegociosManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void frmEntidadesUnidadNegocios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void entidadesUnidadNegociosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + entidadesUnidadNegociosManager_SearchResultBindingSource.Count.ToString();
        }
    }
}
