namespace VENET_Contabilidad_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Contabilidad_BL;

    public partial class frmTipoAsientos : MultiForm
    {
        TipoAsientosManager.ParametrosBusquedas par = new TipoAsientosManager.ParametrosBusquedas();

        public frmTipoAsientos()
        {
            InitializeComponent();
        }

        private void frmTipoAsientos_Load(object sender, EventArgs e)
        {
            tipoAsientosManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoAsientos", Enums.Accion.Imprimir)) return;
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

        private void tipoAsientosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + tipoAsientosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoAsientos", Enums.Accion.Buscar)) return;

                Validate();
                tipoAsientosManager_SearchResultBindingSource.DataSource = TipoAsientosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoAsientos", Enums.Accion.Agregar)) return;

            TipoAsientos o = new TipoAsientos();
            var f = new frmTipoAsientos_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                tipoAsientosManager_SearchResultBindingSource.Add(TipoAsientosManager.Buscar(new TipoAsientosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoAsientos", Enums.Accion.Modificar)) return;

                if (tipoAsientosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (TipoAsientosManager.SearchResult)tipoAsientosManager_SearchResultBindingSource.Current;
                    var f = new frmTipoAsientos_AddMod(new TipoAsientos() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        tipoAsientosManager_SearchResultBindingSource[tipoAsientosManager_SearchResultBindingSource.Position] = TipoAsientosManager.Buscar(new TipoAsientosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        tipoAsientosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoAsientos", Enums.Accion.Eliminar)) return;

                if (tipoAsientosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    TipoAsientosManager.Eliminar(new TipoAsientos() { Id = ((TipoAsientosManager.SearchResult)tipoAsientosManager_SearchResultBindingSource.Current).Id });
                    tipoAsientosManager_SearchResultBindingSource.RemoveCurrent();
                    tipoAsientosManager_SearchResultBindingSource.ResetBindings(false);
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

    }
}
