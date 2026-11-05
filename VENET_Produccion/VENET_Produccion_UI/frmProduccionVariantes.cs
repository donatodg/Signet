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

    public partial class frmProduccionVariantes : MultiForm
    {
        private ProduccionVariantesManager.ParametrosBusquedas par = new ProduccionVariantesManager.ParametrosBusquedas();

        public frmProduccionVariantes()
        {
            InitializeComponent();
        }

        private void frmProduccionVariantes_Load(object sender, EventArgs e)
        {
            produccionVariantesManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_LineaLookUpEdit.Properties.DataSource = ProduccionVariantesManager.Lineas;
            id_LineaLookUpEdit.Properties.DisplayMember = "Name";
            id_LineaLookUpEdit.Properties.ValueMember = "Key";

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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantes", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void produccionVariantesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionVariantesManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantes", Enums.Accion.Buscar)) return;

                Validate();
                produccionVariantesManager_SearchResultBindingSource.DataSource = ProduccionVariantesManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantes", Enums.Accion.Agregar)) return;

            Produccion_Variantes o = new Produccion_Variantes();
            var f = new frmProduccionVariantes_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                produccionVariantesManager_SearchResultBindingSource.Add(ProduccionVariantesManager.Buscar(new ProduccionVariantesManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantes", Enums.Accion.Modificar)) return;

                if (produccionVariantesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProduccionVariantesManager.SearchResult)produccionVariantesManager_SearchResultBindingSource.Current;
                    var f = new frmProduccionVariantes_AddMod(new Produccion_Variantes() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        produccionVariantesManager_SearchResultBindingSource[produccionVariantesManager_SearchResultBindingSource.Position] = ProduccionVariantesManager.Buscar(new ProduccionVariantesManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        produccionVariantesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantes", Enums.Accion.Eliminar)) return;

                if (produccionVariantesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionVariantesManager.Eliminar(new Produccion_Variantes() { Id = ((ProduccionVariantesManager.SearchResult)produccionVariantesManager_SearchResultBindingSource.Current).Id });
                    produccionVariantesManager_SearchResultBindingSource.RemoveCurrent();
                    produccionVariantesManager_SearchResultBindingSource.ResetBindings(false);
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void btnTareasAsociadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantes", Enums.Accion.Ver, "Tareas Asociadas")) return;

                if (produccionVariantesManager_SearchResultBindingSource.Current == null) return;
                {
                    var f = new frmProduccionVariantesTareas(new Produccion_VariantesTareas() { Id_Variante = ((ProduccionVariantesManager.SearchResult)produccionVariantesManager_SearchResultBindingSource.Current).Id });
                    //var f = new frmProduccionVariantesTareas(new Produccion_VariantesTareas() { Id_Variante = ((ProduccionVariantesManager.SearchResult)produccionVariantesManager_SearchResultBindingSource.Current).Id });
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

        private void btnCopiaTareas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReporteCompleto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantes", Enums.Accion.Ver, "Reporte Completo")) return;

                var f = new frmProduccionVariantesTareasCompleto();
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

        private void btnModificarUtilidad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantes", Enums.Accion.Operaciones, "Modificar Utilidad")) return;

                var f = new frmProduccionVariantesActualizarUtilidad();
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    Buscar();

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
    }
}
