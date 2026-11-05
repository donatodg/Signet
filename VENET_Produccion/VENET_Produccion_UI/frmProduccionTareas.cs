namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionTareas : MultiForm
    {
        private ProduccionTareasManager.ParametrosBusquedas par = new ProduccionTareasManager.ParametrosBusquedas();

        public frmProduccionTareas()
        {
            InitializeComponent();
        }

        private void frmProduccionTareas_Load(object sender, EventArgs e)
        {
            try
            {
                produccionTareasManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionTareas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void produccionTareasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionTareasManager_SearchResultBindingSource.Count.ToString();
        }
        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionTareas", Enums.Accion.Buscar)) return;

                Validate();
                produccionTareasManager_SearchResultBindingSource.DataSource = ProduccionTareasManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionTareas", Enums.Accion.Agregar)) return;

            Produccion_Tareas o = new Produccion_Tareas();
            var f = new frmProduccionTareas_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                produccionTareasManager_SearchResultBindingSource.Add(ProduccionTareasManager.Buscar(new ProduccionTareasManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionTareas", Enums.Accion.Modificar)) return;

                if (produccionTareasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProduccionTareasManager.SearchResult)produccionTareasManager_SearchResultBindingSource.Current;
                    var f = new frmProduccionTareas_AddMod(new Produccion_Tareas() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        produccionTareasManager_SearchResultBindingSource[produccionTareasManager_SearchResultBindingSource.Position] = ProduccionTareasManager.Buscar(new ProduccionTareasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        produccionTareasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionTareas", Enums.Accion.Eliminar)) return;

                if (produccionTareasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionTareasManager.Eliminar(new Produccion_Tareas() { Id = ((ProduccionTareasManager.SearchResult)produccionTareasManager_SearchResultBindingSource.Current).Id });
                    produccionTareasManager_SearchResultBindingSource.RemoveCurrent();
                    produccionTareasManager_SearchResultBindingSource.ResetBindings(false);
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
