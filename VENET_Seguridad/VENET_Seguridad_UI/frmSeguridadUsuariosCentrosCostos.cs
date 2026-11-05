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

    public partial class frmSeguridadUsuariosCentrosCostos : MultiForm, IDisposable
    {
        private SeguridadUsuariosCentrosCostosManager manager;

        public frmSeguridadUsuariosCentrosCostos(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosCentrosCostosManager(o);
            Text = "Centros Costos Asignados Usuario: " + manager.Usuario.Id + " - " + manager.Usuario.Apellido + ", " + manager.Usuario.Nombre;
        }

        private void frmSeguridadUsuariosCentrosCostos_Load(object sender, EventArgs e)
        {
            try
            {
                seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.DataSource = manager.Buscar();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosCentrosCostos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void seguridadUsuariosCentrosCostosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.Count.ToString();
        }

        private void frmSeguridadUsuariosCentrosCostos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosCentrosCostos", Enums.Accion.Agregar)) return;

            SeguridadUsuarios o = new SeguridadUsuarios() { Id = manager.Usuario.Id };
            var f = new frmSeguridadUsuariosCentrosCostos_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosCentrosCostos", Enums.Accion.Eliminar)) return;

                if (seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SeguridadUsuariosCentrosCostosManager.Eliminar(new SeguridadUsuariosCentrosCostos() { Id = ((SeguridadUsuariosCentrosCostosManager.SearchResult)seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.Current).Id });
                    seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.RemoveCurrent();
                    seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.ResetBindings(false);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosCentrosCostos", Enums.Accion.Operaciones, "Setear Default")) return;

                if (seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.Current == null) return;

                SeguridadUsuariosCentrosCostosManager.SetDefault(((SeguridadUsuariosCentrosCostosManager.SearchResult)seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.Current).Id_CentroCosto, manager.Usuario.Id);
                seguridadUsuariosCentrosCostosManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}
