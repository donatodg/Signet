namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmTipoIva_Configuracion : MultiForm, IDisposable
    {
        private TipoIvaConfiguracionManager manager;
        int _Id_TipoIva;

        public frmTipoIva_Configuracion(string TipoIva, int Id_TipoIva)
        {
            InitializeComponent();
            Text = "Configuración para el destino " + TipoIva;
            _Id_TipoIva = Id_TipoIva;
            manager = new TipoIvaConfiguracionManager(Id_TipoIva);
        }

        private void frmTipoIva_Configuracion_Load(object sender, EventArgs e)
        {
            tipoIvaConfiguracionManager_SearchResultBindingSource.DataSource = manager.ListConfig;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoIva_Configuracion", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void tipoIvaConfiguracionManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + tipoIvaConfiguracionManager_SearchResultBindingSource.Count.ToString();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoIva_Configuracion", Enums.Accion.Agregar)) return;

            TipoIva_Configuracion o = new TipoIva_Configuracion() {Id_TipoIvaDestino = _Id_TipoIva };
            var f = new frmTipoIva_Configuracion_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                tipoIvaConfiguracionManager_SearchResultBindingSource.Add(TipoIvaConfiguracionManager.Buscar(new TipoIvaConfiguracionManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoIva_Configuracion", Enums.Accion.Modificar)) return;

                if (tipoIvaConfiguracionManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (TipoIvaConfiguracionManager.SearchResult)tipoIvaConfiguracionManager_SearchResultBindingSource.Current;
                    var f = new frmTipoIva_Configuracion_AddMod(new TipoIva_Configuracion() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        tipoIvaConfiguracionManager_SearchResultBindingSource[tipoIvaConfiguracionManager_SearchResultBindingSource.Position] = TipoIvaConfiguracionManager.Buscar(new TipoIvaConfiguracionManager.ParametrosBusquedas() { Id = curr.Id   }).SingleOrDefault();
                        tipoIvaConfiguracionManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoIva_Configuracion", Enums.Accion.Eliminar)) return;

                if (tipoIvaConfiguracionManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    TipoIvaConfiguracionManager.Eliminar(new TipoIva_Configuracion() { Id = ((TipoIvaConfiguracionManager.SearchResult)tipoIvaConfiguracionManager_SearchResultBindingSource.Current).Id });
                    tipoIvaConfiguracionManager_SearchResultBindingSource.RemoveCurrent();
                    tipoIvaConfiguracionManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }
    }
}
