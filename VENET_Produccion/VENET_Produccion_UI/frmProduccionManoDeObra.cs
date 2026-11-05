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

    public partial class frmProduccionManoDeObra : MultiForm
    {
        private ProduccionManoDeObraManager.ParametrosBusquedas par = new ProduccionManoDeObraManager.ParametrosBusquedas();

        public frmProduccionManoDeObra()
        {
            InitializeComponent();
        }

        private void frmManoDeObra_Load(object sender, EventArgs e)
        {
            try
            {
                produccionManoDeObraManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionManoDeObra", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void produccionManoDeObraManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionManoDeObraManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionManoDeObra", Enums.Accion.Buscar)) return;

                Validate();
                produccionManoDeObraManager_SearchResultBindingSource.DataSource = ProduccionManoDeObraManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionManoDeObra", Enums.Accion.Agregar)) return;

            Produccion_ManoDeObra o = new Produccion_ManoDeObra();
            var f = new frmProduccionManoDeObra_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                produccionManoDeObraManager_SearchResultBindingSource.Add(ProduccionManoDeObraManager.Buscar(new ProduccionManoDeObraManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionManoDeObra", Enums.Accion.Modificar)) return;

                if (produccionManoDeObraManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProduccionManoDeObraManager.SearchResult)produccionManoDeObraManager_SearchResultBindingSource.Current;
                    var f = new frmProduccionManoDeObra_AddMod(new Produccion_ManoDeObra() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        produccionManoDeObraManager_SearchResultBindingSource[produccionManoDeObraManager_SearchResultBindingSource.Position] = ProduccionManoDeObraManager.Buscar(new ProduccionManoDeObraManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        produccionManoDeObraManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionManoDeObra", Enums.Accion.Eliminar)) return;

                if (produccionManoDeObraManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProduccionManoDeObraManager.Eliminar(new Produccion_ManoDeObra() { Id = ((ProduccionManoDeObraManager.SearchResult)produccionManoDeObraManager_SearchResultBindingSource.Current).Id });
                    produccionManoDeObraManager_SearchResultBindingSource.RemoveCurrent();
                    produccionManoDeObraManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnHistorial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionManoDeObra", Enums.Accion.Ver, "Historial de Precios")) return;

                if (produccionManoDeObraManager_SearchResultBindingSource.Current == null) return;
                {
                    var f = new frmProduccionManoDeObraHistorial(((ProduccionManoDeObraManager.SearchResult)produccionManoDeObraManager_SearchResultBindingSource.Current).Id);
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
    }
}
