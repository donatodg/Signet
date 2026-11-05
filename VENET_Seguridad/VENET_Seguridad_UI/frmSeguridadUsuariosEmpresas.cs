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

    public partial class frmSeguridadUsuariosEmpresas : MultiForm, IDisposable
    {
        private SeguridadUsuariosEmpresasManager manager;

        public frmSeguridadUsuariosEmpresas(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosEmpresasManager(o);
            Text = "Empresas Asignadas Usuario: " + manager.Usuario.Id + " - " + manager.Usuario.Apellido + ", " + manager.Usuario.Nombre;
        }

        private void frmSeguridadUsuariosEmpresas_Load(object sender, EventArgs e)
        {
            try
            {
                seguridadUsuariosEmpresasManager_SearchResultBindingSource.DataSource = manager.Buscar();
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

        private void frmSeguridadUsuariosEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void seguridadUsuariosEmpresasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosEmpresasManager_SearchResultBindingSource.Count.ToString();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosEmpresas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosEmpresas", Enums.Accion.Agregar)) return;

            SeguridadUsuarios o = new SeguridadUsuarios() { Id = manager.Usuario.Id };
            var f = new frmSeguridadUsuariosEmpresas_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                seguridadUsuariosEmpresasManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }


        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosEmpresas", Enums.Accion.Eliminar)) return;

                if (seguridadUsuariosEmpresasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SeguridadUsuariosEmpresasManager.Eliminar(new SeguridadUsuariosEmpresas() { Id = ((SeguridadUsuariosEmpresasManager.SearchResult)seguridadUsuariosEmpresasManager_SearchResultBindingSource.Current).Id });
                    seguridadUsuariosEmpresasManager_SearchResultBindingSource.RemoveCurrent();
                    seguridadUsuariosEmpresasManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }

    }
}
