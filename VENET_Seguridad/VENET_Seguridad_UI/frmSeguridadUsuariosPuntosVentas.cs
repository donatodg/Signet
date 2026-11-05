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

    public partial class frmSeguridadUsuariosPuntosVentas : MultiForm, IDisposable
    {
        private SeguridadUsuariosPuntosVentasManager manager;

        public frmSeguridadUsuariosPuntosVentas(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosPuntosVentasManager(o);
            Text = "Puntos de Venta Asignados Usuario: " + manager.Usuario.Id + " - " + manager.Usuario.Apellido + ", " + manager.Usuario.Nombre;
        }

        private void frmSeguridadUsuariosPuntosVentas_Load(object sender, EventArgs e)
        {
            try
            {
                seguridadUsuariosPuntosVentasManager_SearchResultBindingSource.DataSource = manager.Buscar();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosPuntosVentas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void seguridadUsuariosPuntosVentasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosPuntosVentasManager_SearchResultBindingSource.Count.ToString();
        }

        private void frmSeguridadUsuariosPuntosVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosPuntosVentas", Enums.Accion.Agregar)) return;

            SeguridadUsuarios o = new SeguridadUsuarios() { Id = manager.Usuario.Id };
            var f = new frmSeguridadUsuariosPuntosVentas_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                seguridadUsuariosPuntosVentasManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosPuntosVentas", Enums.Accion.Eliminar)) return;

                if (seguridadUsuariosPuntosVentasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SeguridadUsuariosPuntosVentasManager.Eliminar(new SeguridadUsuariosPuntosVentas () { Id = ((SeguridadUsuariosPuntosVentasManager.SearchResult)seguridadUsuariosPuntosVentasManager_SearchResultBindingSource.Current).Id });
                    seguridadUsuariosPuntosVentasManager_SearchResultBindingSource.RemoveCurrent();
                    seguridadUsuariosPuntosVentasManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }
    }
}
