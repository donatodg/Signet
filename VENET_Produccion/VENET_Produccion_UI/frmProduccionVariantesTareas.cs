namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccionVariantesTareas : MultiForm
    {
        private ProduccionVariantesTareasManager manager;
        //int _Id_Variante;

        public frmProduccionVariantesTareas(Produccion_VariantesTareas o)
        {
            InitializeComponent();
            //_Id_Variante = Id_Variante;
            manager = new ProduccionVariantesTareasManager(o);
            //Text = "Tareas asignadas a la Variante: " + manager.Variante.Descripcion;
        }

        private void frmProduccionVariantesTareas_Load(object sender, EventArgs e)
        {
            try
            {
                produccionVariantesTareasManager_SearchResultBindingSource.DataSource = manager.Buscar();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantesTareas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void produccionVariantesTareasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionVariantesTareasManager_SearchResultBindingSource.Count.ToString();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantesTareas", Enums.Accion.Agregar)) return;

            //Produccion_Variantes o = new Produccion_Variantes() { Id = manager.Variante.Id };
            Produccion_VariantesTareas o = new Produccion_VariantesTareas() { Id_Variante = manager.VarianteTareas.Id_Variante };
            var f = new frmProduccionVariantesTareas_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                produccionVariantesTareasManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantesTareas", Enums.Accion.Modificar)) return;

                if (produccionVariantesTareasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProduccionManager.SearchResult)produccionVariantesTareasManager_SearchResultBindingSource.Current;
                    var f = new frmProduccionVariantesTareas_AddMod(new Produccion_VariantesTareas() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        produccionVariantesTareasManager_SearchResultBindingSource.DataSource = manager.Buscar();

                        //produccionLineasManager_SearchResultBindingSource[produccionLineasManager_SearchResultBindingSource.Position] = ProduccionLineasManager.Buscar(new ProduccionLineasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        //produccionLineasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantesTareas", Enums.Accion.Eliminar)) return;

                if (produccionVariantesTareasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionVariantesTareasManager.Eliminar(new Produccion_VariantesTareas() { Id = ((ProduccionVariantesTareasManager.SearchResult)produccionVariantesTareasManager_SearchResultBindingSource.Current).Id });
                    produccionVariantesTareasManager_SearchResultBindingSource.RemoveCurrent();
                    produccionVariantesTareasManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }
    }
}
