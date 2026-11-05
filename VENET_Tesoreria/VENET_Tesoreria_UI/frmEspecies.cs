namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmEspecies : MultiForm
    {
        private EspeciesManager.ParametrosBusquedas par = new EspeciesManager.ParametrosBusquedas();

        public frmEspecies()
        {
            InitializeComponent();
        }

        private void fmEspecies_Load(object sender, EventArgs e)
        {
            especiesManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Especies", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Especies", Enums.Accion.Buscar)) return;

                Validate();
                especiesManager_SearchResultBindingSource.DataSource = EspeciesManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Especies", Enums.Accion.Agregar)) return;

            Especies o = new Especies();
            var f = new frmEspecies_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                especiesManager_SearchResultBindingSource.Add(EspeciesManager.Buscar(new EspeciesManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Especies", Enums.Accion.Modificar)) return;

                if (especiesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EspeciesManager.SearchResult)especiesManager_SearchResultBindingSource.Current;
                    var f = new frmEspecies_AddMod(new Especies() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        especiesManager_SearchResultBindingSource[especiesManager_SearchResultBindingSource.Position] = EspeciesManager.Buscar(new EspeciesManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        especiesManager_SearchResultBindingSource.ResetCurrentItem();
                        ActualizarPrecios();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Especies", Enums.Accion.Eliminar)) return;

                if (especiesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    EspeciesManager.Eliminar(new Especies() { Id = ((EspeciesManager.SearchResult)especiesManager_SearchResultBindingSource.Current).Id });
                    especiesManager_SearchResultBindingSource.RemoveCurrent();
                    especiesManager_SearchResultBindingSource.ResetBindings(false);
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

        private void especiesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + especiesManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnHistorial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Especies", Enums.Accion.Ver, "Ver Historial de Cotización")) return;

                if (especiesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EspeciesManager.SearchResult)especiesManager_SearchResultBindingSource.Current;
                    var f = new frmEspeciesCotizaciones(curr.Id, curr.Descripcion);
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

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modificar();
        }

        private void btnActualizaPrecioCotizacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActualizarPrecios();
        }

        private void ActualizarPrecios()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Especies", Enums.Accion.Operaciones, "Actualizar Precios Según Cotización")) return;

                if (especiesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Actualizar los Precios de los Productos?", "Atención..."))
                {
                    var curr = (EspeciesManager.SearchResult)especiesManager_SearchResultBindingSource.Current;

                    VENET_Gestion_BL.ProductosManager.ActualizarImporteSeguncotizacion(curr.Id, curr.Cotizacion);
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
