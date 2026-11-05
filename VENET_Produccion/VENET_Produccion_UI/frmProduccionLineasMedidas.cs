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

    public partial class frmProduccionLineasMedidas : MultiForm
    {
        private ProduccionLineasMedidasManager manager;

        public frmProduccionLineasMedidas(Produccion_Lineas o)
        {
            InitializeComponent();
            manager = new ProduccionLineasMedidasManager(o);
            Text = "Medidas asignadas a la línea: " + manager.Linea.Descripcion;
        }

        private void frmProduccionLineasMedidas_Load(object sender, EventArgs e)
        {
            try
            {
                produccionLineasMedidasManager_SearchResultBindingSource.DataSource = manager.Buscar();
                
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

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineasMedidas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void produccionLineasMedidasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionLineasMedidasManager_SearchResultBindingSource.Count.ToString();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineasMedidas", Enums.Accion.Agregar)) return;

            Produccion_Lineas o = new Produccion_Lineas() { Id = manager.Linea.Id };
            var f = new frmProduccionLineasMedidas_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                produccionLineasMedidasManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionLineasMedidas", Enums.Accion.Eliminar)) return;

                if (produccionLineasMedidasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionLineasMedidasManager.Eliminar(new Produccion_LineasMedidas() { Id = ((ProduccionLineasMedidasManager.SearchResult)produccionLineasMedidasManager_SearchResultBindingSource.Current).Id });
                    produccionLineasMedidasManager_SearchResultBindingSource.RemoveCurrent();
                    produccionLineasMedidasManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}
