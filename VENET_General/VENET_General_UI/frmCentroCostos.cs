namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmCentroCostos : MultiForm
    {
        private CentroCostosMananger.ParametrosBusquedas par = new CentroCostosMananger.ParametrosBusquedas();

        public frmCentroCostos()
        {
            InitializeComponent();
        }

        private void frmCentroCostos_Load(object sender, EventArgs e)
        {
            centroCostosMananger_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "CentroCostos", Enums.Accion.Imprimir)) return;

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

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "CentroCostos", Enums.Accion.Buscar)) return;

                Validate();
                centroCostosMananger_SearchResultBindingSource.DataSource = CentroCostosMananger.Buscar(par);
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }
        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "CentroCostos", Enums.Accion.Agregar)) return;

            CentrosCostos o = new CentrosCostos();
            var f = new frmCentroCostos_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                centroCostosMananger_SearchResultBindingSource.Add(CentroCostosMananger.Buscar(new CentroCostosMananger.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "CentroCostos", Enums.Accion.Modificar)) return;

                if (centroCostosMananger_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (CentroCostosMananger.SearchResult)centroCostosMananger_SearchResultBindingSource.Current;
                    var f = new frmCentroCostos_AddMod(new CentrosCostos() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        centroCostosMananger_SearchResultBindingSource[centroCostosMananger_SearchResultBindingSource.Position] = CentroCostosMananger.Buscar(new CentroCostosMananger.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        centroCostosMananger_SearchResultBindingSource.ResetCurrentItem();
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
                Sistema.MensajeError( ex);
            }
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "CentroCostos", Enums.Accion.Eliminar)) return;

                if (centroCostosMananger_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    CentroCostosMananger.Eliminar(new CentrosCostos() { Id = ((CentroCostosMananger.SearchResult)centroCostosMananger_SearchResultBindingSource.Current).Id });
                    centroCostosMananger_SearchResultBindingSource.RemoveCurrent();
                    centroCostosMananger_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
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

        private void centroCostosMananger_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + centroCostosMananger_SearchResultBindingSource.Count.ToString();
        }

    }
}
