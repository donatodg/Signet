namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadUsuarios : MultiForm
    {
        private SeguridadUsuariosManager.ParametrosBusquedas par = new SeguridadUsuariosManager.ParametrosBusquedas();

        public frmSeguridadUsuarios()
        {
            InitializeComponent();
        }

        private void frmSeguridadUsuarios_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_VerCajas)))
                btnCajas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_VerCentrosCostos)))
                btnCentrosCostos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_VerPuntosDeVentas)))
                btnPuntosVentas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_VerUnidadesDeNegocios)))
                btnUN.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_VerSucursales)))
                btnSucursales.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Usuarios_VerDepositos)))
                btnDepositos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            seguridadUsuariosManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void seguridadUsuariosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadUsuariosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Buscar)) return;

                Validate();
                seguridadUsuariosManager_SearchResultBindingSource.DataSource = SeguridadUsuariosManager.Buscar(par);
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
        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Agregar)) return;

            SeguridadUsuarios o = new SeguridadUsuarios();
            var f = new frmSeguridadUsuarios_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                seguridadUsuariosManager_SearchResultBindingSource.Add(SeguridadUsuariosManager.Buscar(new SeguridadUsuariosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Modificar)) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current;
                    var f = new frmSeguridadUsuarios_AddMod(new SeguridadUsuarios() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        seguridadUsuariosManager_SearchResultBindingSource[seguridadUsuariosManager_SearchResultBindingSource.Position] = SeguridadUsuariosManager.Buscar(new SeguridadUsuariosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        seguridadUsuariosManager_SearchResultBindingSource.ResetCurrentItem();
                    }
                    f.Dispose();
                }
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

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Eliminar)) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SeguridadUsuariosManager.Eliminar(new SeguridadUsuarios() { Id = ((SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current).Id });
                    seguridadUsuariosManager_SearchResultBindingSource.RemoveCurrent();
                    seguridadUsuariosManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void btnEmpresas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Ver, "Ver Empresas Asignadas")) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;
                {
                    var f = new frmSeguridadUsuariosEmpresas(new SeguridadUsuarios() { Id = ((SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current).Id });
                    f.ShowDialog(this);
                    f.Dispose();
                }
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

        private void btnCentrosCostos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Ver, "Ver Centros de Costos Asignados")) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;
                {
                    var f = new frmSeguridadUsuariosCentrosCostos(new SeguridadUsuarios() { Id = ((SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current).Id });
                    f.ShowDialog(this);
                    f.Dispose();
                }
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

        private void btnCajas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Ver, "Ver Cajas Asignados")) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;
                {
                    var f = new frmSeguridadUsuariosCajas(new SeguridadUsuarios() { Id = ((SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current).Id });
                    f.ShowDialog(this);
                    f.Dispose();
                }
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

        private void btnPuntosVentas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Ver, "Ver Puntos de Ventas Asignados")) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;
                {
                    var f = new frmSeguridadUsuariosPuntosVentas(new SeguridadUsuarios() { Id = ((SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current).Id });
                    f.ShowDialog(this);
                    f.Dispose();
                }
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

        private void btnUN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Ver, "Ver Unidades de Negocio Asignadas")) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;
                {
                    var f = new frmSeguridadUsuariosUnidadNegocios(new SeguridadUsuarios() { Id = ((SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current).Id });
                    f.ShowDialog(this);
                    f.Dispose();
                }
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

        private void btnSucursales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Ver, "Ver Sucursales Asignadas")) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;

                var f = new frmSeguridadUsuariosSucursales(new SeguridadUsuarios() { Id = ((SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current).Id });
                f.ShowDialog(this);
                f.Dispose();
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

        private void btnRestablecer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Operaciones, "Restablecer Visualización")) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;

                SeguridadUsuariosManager.Restablecer(((SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current).Id);
                Sistema.Mensaje("Debe cerrar el sistema y volverlo a abrir para que los cambios tengan efectos.");
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

        private void btnDepositos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Ver, "Ver Depósitos Asignados")) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;
                {
                    var f = new frmSeguridadUsuariosDepositos(new SeguridadUsuarios() { Id = ((SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current).Id });
                    f.ShowDialog(this);
                    f.Dispose();
                }
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

        private void btnUsuariosActivos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Ver, "Ver Usuarios Activos")) return;

                new frmSeguridadUsuariosActivos().ShowDialog(this);
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

        private void btnReporteLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadUsuarios", Enums.Accion.Ver, "Ver Reporte de Log")) return;

                if (seguridadUsuariosManager_SearchResultBindingSource.Current == null) return;
                var curr = (SeguridadUsuariosManager.SearchResult)seguridadUsuariosManager_SearchResultBindingSource.Current;
                new frmSeguridadUsuariosUltimoLog(curr.Id, curr.Username).ShowDialog(this);
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
    }
}
