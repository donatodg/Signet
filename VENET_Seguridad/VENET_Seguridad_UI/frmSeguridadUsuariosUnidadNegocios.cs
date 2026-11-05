namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadUsuariosUnidadNegocios : MultiForm, IDisposable
    {
        private SeguridadUsuariosUnidadNegociosManager manager;

        public frmSeguridadUsuariosUnidadNegocios(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosUnidadNegociosManager(o);
            Text = "Unidades de Negocios Asignadas Usuario: " + manager.Usuario.Id + " - " + manager.Usuario.Apellido + ", " + manager.Usuario.Nombre;
        }

        private void frmSeguridadUsuariosUnidadNegocios_Load(object sender, EventArgs e)
        {
            try
            {
                seguridadUsuariosUnidadNegociosManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }

        private void seguridadUsuariosUnidadNegociosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosUnidadNegociosManager_SearchResultBindingSource.Count.ToString();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosUnidadNegocios", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosUnidadNegocios", Enums.Accion.Agregar)) return;

            SeguridadUsuarios o = new SeguridadUsuarios() { Id = manager.Usuario.Id };
            var f = new frmSeguridadUsuariosUnidadNegocios_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                seguridadUsuariosUnidadNegociosManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosUnidadNegocios", Enums.Accion.Eliminar)) return;

                if (seguridadUsuariosUnidadNegociosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SeguridadUsuariosUnidadNegociosManager.Eliminar(new SeguridadUsuariosUnidadNegocios() { Id = ((SeguridadUsuariosUnidadNegociosManager.SearchResult)seguridadUsuariosUnidadNegociosManager_SearchResultBindingSource.Current).Id });
                    seguridadUsuariosUnidadNegociosManager_SearchResultBindingSource.RemoveCurrent();
                    seguridadUsuariosUnidadNegociosManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }
    }
}
