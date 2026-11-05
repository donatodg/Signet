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

    public partial class frmProduccionMedidas : MultiForm
    {
        private ProduccionMedidasManager.ParametrosBusquedas par = new ProduccionMedidasManager.ParametrosBusquedas();

        public frmProduccionMedidas()
        {
            InitializeComponent();
        }

        private void frmProduccionMedidas_Load(object sender, EventArgs e)
        {
            try
            {
                produccionMedidasManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionMedidas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void produccionMedidasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionMedidasManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionMedidas", Enums.Accion.Buscar)) return;

                Validate();
                produccionMedidasManager_SearchResultBindingSource.DataSource = ProduccionMedidasManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionMedidas", Enums.Accion.Agregar)) return;

            Produccion_Medidas o = new Produccion_Medidas();
            var f = new frmProduccionMedidas_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                produccionMedidasManager_SearchResultBindingSource.Add(ProduccionMedidasManager.Buscar(new ProduccionMedidasManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionMedidas", Enums.Accion.Modificar)) return;

                if (produccionMedidasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProduccionMedidasManager.SearchResult)produccionMedidasManager_SearchResultBindingSource.Current;
                    var f = new frmProduccionMedidas_AddMod(new Produccion_Medidas() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        produccionMedidasManager_SearchResultBindingSource[produccionMedidasManager_SearchResultBindingSource.Position] = ProduccionMedidasManager.Buscar(new ProduccionMedidasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        produccionMedidasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionMedidas", Enums.Accion.Eliminar)) return;

                if (produccionMedidasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionMedidasManager.Eliminar(new Produccion_Medidas() { Id = ((ProduccionMedidasManager.SearchResult)produccionMedidasManager_SearchResultBindingSource.Current).Id });
                    produccionMedidasManager_SearchResultBindingSource.RemoveCurrent();
                    produccionMedidasManager_SearchResultBindingSource.ResetBindings(false);
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
