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

    public partial class frmSeguridadUsuariosSucursales : MultiForm, IDisposable
    {
        private SeguridadUsuariosSucursalesManager manager;

        public frmSeguridadUsuariosSucursales(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosSucursalesManager(o);
            Text = "Sucursales Asignadas Usuario: " + manager.Usuario.Id + " - " + manager.Usuario.Apellido + ", " + manager.Usuario.Nombre;
        }

        private void frmSeguridadUsuariosSucursales_Load(object sender, EventArgs e)
        {
            try
            {
                seguridadUsuariosSucursalesManager_SearchResultBindingSource.DataSource = manager.Buscar();
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

        private void frmSeguridadUsuariosSucursales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void seguridadUsuariosSucursalesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosSucursalesManager_SearchResultBindingSource.Count.ToString();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosSucursales", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosSucursales", Enums.Accion.Agregar)) return;

            SeguridadUsuarios o = new SeguridadUsuarios() { Id = manager.Usuario.Id };
            var f = new frmSeguridadUsuariosSucursales_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                seguridadUsuariosSucursalesManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosSucursales", Enums.Accion.Eliminar)) return;

                if (seguridadUsuariosSucursalesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SeguridadUsuariosSucursalesManager.Eliminar(new SeguridadUsuariosSucursales() { Id = ((SeguridadUsuariosSucursalesManager.SearchResult)seguridadUsuariosSucursalesManager_SearchResultBindingSource.Current).Id });
                    seguridadUsuariosSucursalesManager_SearchResultBindingSource.RemoveCurrent();
                    seguridadUsuariosSucursalesManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }

        private void btnPredeterminada_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosSucursales", Enums.Accion.Operaciones, "Setear Default")) return;

                if (seguridadUsuariosSucursalesManager_SearchResultBindingSource.Current == null) return;

                SeguridadUsuariosSucursalesManager.SetDefault(((SeguridadUsuariosSucursalesManager.SearchResult)seguridadUsuariosSucursalesManager_SearchResultBindingSource.Current).Id_Sucursal, manager.Usuario.Id);
                seguridadUsuariosSucursalesManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }
    }
}
