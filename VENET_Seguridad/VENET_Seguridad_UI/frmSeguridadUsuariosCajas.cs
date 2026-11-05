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

    public partial class frmSeguridadUsuariosCajas : MultiForm, IDisposable
    {
        private SeguridadUsuariosCajasManager manager;

        public frmSeguridadUsuariosCajas(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosCajasManager(o);
            Text = "Cajas Asignados Usuario: " + manager.Usuario.Id + " - " + manager.Usuario.Apellido + ", " + manager.Usuario.Nombre;
        }

        private void frmSeguridadUsuariosCajas_Load(object sender, EventArgs e)
        {
            try
            {
                seguridadUsuariosCajasManager_SearchResultBindingSource.DataSource = manager.Buscar();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosCajas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void seguridadUsuariosCajasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosCajasManager_SearchResultBindingSource.Count.ToString();
        }

        private void frmSeguridadUsuariosCajas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosCajas", Enums.Accion.Agregar)) return;

            SeguridadUsuarios o = new SeguridadUsuarios() { Id = manager.Usuario.Id };
            var f = new frmSeguridadUsuariosCajas_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                seguridadUsuariosCajasManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosCajas", Enums.Accion.Eliminar)) return;

                if (seguridadUsuariosCajasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SeguridadUsuariosCajasManager.Eliminar(new SeguridadUsuariosCajas() { Id = ((SeguridadUsuariosCajasManager.SearchResult)seguridadUsuariosCajasManager_SearchResultBindingSource.Current).Id });
                    seguridadUsuariosCajasManager_SearchResultBindingSource.RemoveCurrent();
                    seguridadUsuariosCajasManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnPredeterminada_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosCajas", Enums.Accion.Operaciones, "Setear Default")) return;

                if (seguridadUsuariosCajasManager_SearchResultBindingSource.Current == null) return;

                SeguridadUsuariosCajasManager.SetDefault(((SeguridadUsuariosCajasManager.SearchResult)seguridadUsuariosCajasManager_SearchResultBindingSource.Current).Id_Caja, manager.Usuario.Id);
                seguridadUsuariosCajasManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}
