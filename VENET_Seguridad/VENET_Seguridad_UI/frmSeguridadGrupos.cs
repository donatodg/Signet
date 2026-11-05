namespace VENET_Seguridad_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadGrupos : MultiForm
    {
        SeguridadGruposManager.ParametrosBusquedas par = new SeguridadGruposManager.ParametrosBusquedas();

        public frmSeguridadGrupos()
        {
            InitializeComponent();
        }

        private void frmSeguridadGrupos_Load(object sender, EventArgs e)
        {
            seguridadGruposManager_ParametrosBusquedasBindingSource.DataSource = par;
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

        private void btnDuplicaGrupo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuplicaGrupo();
        }
        private void btnUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            VerUsuarios();
        }

        private void btnObjetos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            VerObjetos();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGrupos", Enums.Accion.Imprimir)) return;
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

        private void seguridadGruposManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + seguridadGruposManager_SearchResultBindingSource.Count.ToString();
        }

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGrupos", Enums.Accion.Buscar)) return;

                Validate();
                seguridadGruposManager_SearchResultBindingSource.DataSource = SeguridadGruposManager.Buscar(par);
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
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGrupos", Enums.Accion.Agregar)) return;

                SeguridadGrupos o = new SeguridadGrupos();
                var f = new frmSeguridadGrupos_AddMod(o);
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    seguridadGruposManager_SearchResultBindingSource.Add(SeguridadGruposManager.Buscar(new SeguridadGruposManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
                }
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

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGrupos", Enums.Accion.Modificar)) return;

                if (seguridadGruposManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (SeguridadGruposManager.SearchResult)seguridadGruposManager_SearchResultBindingSource.Current;
                    var f = new frmSeguridadGrupos_AddMod(new SeguridadGrupos() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        seguridadGruposManager_SearchResultBindingSource[seguridadGruposManager_SearchResultBindingSource.Position] = SeguridadGruposManager.Buscar(new SeguridadGruposManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        seguridadGruposManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGrupos", Enums.Accion.Eliminar)) return;

                if (seguridadGruposManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SeguridadGruposManager.Eliminar(new SeguridadGrupos() { Id = ((SeguridadGruposManager.SearchResult)seguridadGruposManager_SearchResultBindingSource.Current).Id });
                    seguridadGruposManager_SearchResultBindingSource.RemoveCurrent();
                    seguridadGruposManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void DuplicaGrupo()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGrupos", Enums.Accion.Operaciones, "Duplicar Grupos")) return;

                if (seguridadGruposManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (SeguridadGruposManager.SearchResult)seguridadGruposManager_SearchResultBindingSource.Current;

                    SeguridadGrupos o = new SeguridadGrupos();
                    var f = new frmSeguridadGrupos_AddMod(o);
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                        SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                        SplashScreenManager.Default.SetWaitFormDescription("Duplicando Permisos...");

                        SeguridadGruposManager.Duplicar(curr.Id, o.Id);
                        seguridadGruposManager_SearchResultBindingSource.Add(SeguridadGruposManager.Buscar(new SeguridadGruposManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());

                        SplashScreenManager.CloseForm(false);
                    }
                    f.Dispose();
                }
            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }

        private void VerUsuarios()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGrupos", Enums.Accion.Ver, "Ver Usuarios Asignados")) return;

                if (seguridadGruposManager_SearchResultBindingSource.Current == null) return;

                var curr = (SeguridadGruposManager.SearchResult)seguridadGruposManager_SearchResultBindingSource.Current;

                frmSeguridadGruposUsuarios f = new frmSeguridadGruposUsuarios(curr.Id, curr.Descripcion);
                f.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void VerObjetos()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGrupos", Enums.Accion.Ver, "Ver Objetos Asignados")) return;

                if (seguridadGruposManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (SeguridadGruposManager.SearchResult)seguridadGruposManager_SearchResultBindingSource.Current;
                    if (curr.EsAdministrador)
                    {
                        Sistema.Mensaje("El grupo es Administrador", "El grupo posee todos los permisos asignados.");
                        return;
                    }
                    var f = new frmSeguridadGruposObjetos(new SeguridadGrupos() { Id = curr.Id });
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
    }
}
