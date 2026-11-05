namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionListaPreciosDetalle : MultiForm
    {
        ProduccionListaPreciosDetalleManager.ParametrosBusquedas par = new ProduccionListaPreciosDetalleManager.ParametrosBusquedas();

        public frmProduccionListaPreciosDetalle(int Id_ListaPrecio)
        {
            InitializeComponent();
            par.Id_ListaPrecios = Id_ListaPrecio;
        }

        private void ProduccionListaPreciosDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void Buscar()
        {
            try
            {
                produccionListaPreciosDetalleManager_SearchResultBindingSource.DataSource = ProduccionListaPreciosDetalleManager.Buscar(par);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPreciosDetalle", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void produccionListaPreciosDetalleManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionListaPreciosDetalleManager_SearchResultBindingSource.Count.ToString();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPreciosDetalle", Enums.Accion.Modificar)) return;

                if (produccionListaPreciosDetalleManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProduccionListaPreciosDetalleManager.SearchResult)produccionListaPreciosDetalleManager_SearchResultBindingSource.Current;
                    var f = new frmProduccionListaPreciosDetalle_AddMod(new Produccion_ListaPreciosDetalle() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        produccionListaPreciosDetalleManager_SearchResultBindingSource[produccionListaPreciosDetalleManager_SearchResultBindingSource.Position] = ProduccionListaPreciosDetalleManager.Buscar(new ProduccionListaPreciosDetalleManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        produccionListaPreciosDetalleManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPreciosDetalle", Enums.Accion.Eliminar)) return;

                if (produccionListaPreciosDetalleManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionListaPreciosDetalleManager.Eliminar(new Produccion_ListaPreciosDetalle() { Id = ((ProduccionListaPreciosDetalleManager.SearchResult)produccionListaPreciosDetalleManager_SearchResultBindingSource.Current).Id });
                    produccionListaPreciosDetalleManager_SearchResultBindingSource.RemoveCurrent();
                    produccionListaPreciosDetalleManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnActualizarUtilidad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionListaPreciosDetalle", Enums.Accion.Operaciones, "Actualizar Utilidad por Variante")) return;

                if (produccionListaPreciosDetalleManager_SearchResultBindingSource.Current == null) return;

                var curr = (ProduccionListaPreciosDetalleManager.SearchResult)produccionListaPreciosDetalleManager_SearchResultBindingSource.Current;

                var f = new frmProduccionActualizarUtilidad(curr.Id_ListaPrecios);
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    Buscar();

                f.Dispose();


            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}
