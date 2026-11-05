namespace VENET_Seguridad_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Seguridad_BL;

    public partial class frmSeguridadGruposObjetos : MultiForm
    {
        private SeguridadGruposObjetosManager manager;

        public frmSeguridadGruposObjetos(SeguridadGrupos o)
        {
            InitializeComponent();
            manager = new SeguridadGruposObjetosManager(o);
            Text = "Objetos del Grupo: " + manager.Grupo.Id + " - " + manager.Grupo.Descripcion;
        }

        private void frmSeguridadGruposObjetos_Load(object sender, EventArgs e)
        {
            seguridadGruposObjetosManager_SearchResultBindingSource.DataSource = manager.ListResult;
        }

        private void Guardar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGruposObjetos", Enums.Accion.Modificar)) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Guardando Permisos...");

                Validate();
                manager.Save();

                SplashScreenManager.CloseForm(false);

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

        private void btnMarcar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGruposObjetos", Enums.Accion.Modificar)) return;

            try
            {
                if (seguridadGruposObjetosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (SeguridadGruposObjetosManager.SearchResult)seguridadGruposObjetosManager_SearchResultBindingSource.Current;
                    manager.MarcaGrupo(((SeguridadGruposObjetosManager.SearchResult)seguridadGruposObjetosManager_SearchResultBindingSource.Current).Modulo, true);
                    seguridadGruposObjetosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnDesmarcar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGruposObjetos", Enums.Accion.Modificar)) return;

                if (seguridadGruposObjetosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (SeguridadGruposObjetosManager.SearchResult)seguridadGruposObjetosManager_SearchResultBindingSource.Current;
                    manager.MarcaGrupo(((SeguridadGruposObjetosManager.SearchResult)seguridadGruposObjetosManager_SearchResultBindingSource.Current).Modulo, false);
                    seguridadGruposObjetosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void btnGruposAsignados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Seguridad, "SeguridadGrupos", Enums.Accion.Ver, "Ver Grupos Asignados")) return;

                if (seguridadGruposObjetosManager_SearchResultBindingSource.Current == null) return;

                var curr = (SeguridadGruposObjetosManager.SearchResult)seguridadGruposObjetosManager_SearchResultBindingSource.Current;

                frmSeguridadObjetosGrupos f = new frmSeguridadObjetosGrupos(curr.Id_Objeto, curr.Permiso);
                f.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}
