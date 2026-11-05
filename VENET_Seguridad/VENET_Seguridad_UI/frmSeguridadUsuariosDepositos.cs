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

    public partial class frmSeguridadUsuariosDepositos : MultiForm, IDisposable
    {
        private SeguridadUsuariosDepositosManager manager;

        public frmSeguridadUsuariosDepositos(SeguridadUsuarios o)
        {
            InitializeComponent();
            manager = new SeguridadUsuariosDepositosManager(o);
            Text = "Depósitos Asignados Usuario: " + manager.Usuario.Id + " - " + manager.Usuario.Apellido + ", " + manager.Usuario.Nombre;
        }

        private void frmSeguridadUsuariosDepositos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                seguridadUsuariosDepositosManager_SearchResultBindingSource.DataSource = manager.Buscar();
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

        private void btnPredeterminado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosDepositos", Enums.Accion.Operaciones, "Setear Default")) return;

                if (seguridadUsuariosDepositosManager_SearchResultBindingSource.Current == null) return;

                SeguridadUsuariosDepositosManager.SetDefault(((SeguridadUsuariosDepositosManager.SearchResult)seguridadUsuariosDepositosManager_SearchResultBindingSource.Current).Id_Deposito, manager.Usuario.Id);
                seguridadUsuariosDepositosManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosDepositos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void seguridadUsuariosDepositosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosDepositosManager_SearchResultBindingSource.Count.ToString();
        }

        private void frmSeguridadUsuariosDepositos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosDepositos", Enums.Accion.Agregar)) return;

            SeguridadUsuarios o = new SeguridadUsuarios() { Id = manager.Usuario.Id };
            var f = new frmSeguridadUsuariosDepositos_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                seguridadUsuariosDepositosManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosDepositos", Enums.Accion.Eliminar)) return;

                if (seguridadUsuariosDepositosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SeguridadUsuariosDepositosManager.Eliminar(new SeguridadUsuariosDepositos() { Id = ((SeguridadUsuariosDepositosManager.SearchResult)seguridadUsuariosDepositosManager_SearchResultBindingSource.Current).Id });
                    seguridadUsuariosDepositosManager_SearchResultBindingSource.RemoveCurrent();
                    seguridadUsuariosDepositosManager_SearchResultBindingSource.ResetBindings(false);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuariosDepositos", Enums.Accion.Operaciones, "Setear Default")) return;

                if (seguridadUsuariosDepositosManager_SearchResultBindingSource.Current == null) return;

                SeguridadUsuariosDepositosManager.SetDefault(((SeguridadUsuariosDepositosManager.SearchResult)seguridadUsuariosDepositosManager_SearchResultBindingSource.Current).Id_Deposito, manager.Usuario.Id);
                seguridadUsuariosDepositosManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }
    }
}
