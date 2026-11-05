namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmPadronIIBB : MultiForm
    {
        PadronIIBBManager.ParametrosBusquedas par = new PadronIIBBManager.ParametrosBusquedas();

        public frmPadronIIBB()
        {
            InitializeComponent();
        }

        private void frmPadronIIBB_Load(object sender, EventArgs e)
        {
            padronIIBBManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void btnImportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PadronIIBB", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void padronIIBBManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + padronIIBBManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PadronIIBB", Enums.Accion.Buscar)) return;

                Validate();
                padronIIBBManager_SearchResultBindingSource.DataSource = PadronIIBBManager.Buscar(par);
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

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PadronIIBB", Enums.Accion.Modificar)) return;

                if (padronIIBBManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (PadronIIBBManager.SearchResult)padronIIBBManager_SearchResultBindingSource.Current;
                    var f = new frmPadronIIBB_Detalle(curr.Id);
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        padronIIBBManager_SearchResultBindingSource[padronIIBBManager_SearchResultBindingSource.Position] = PadronIIBBManager.Buscar(new PadronIIBBManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        padronIIBBManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PadronIIBB", Enums.Accion.Eliminar)) return;

                if (padronIIBBManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    PadronIIBBManager.Eliminar(new PadronIIBB() { Id = ((PadronIIBBManager.SearchResult)padronIIBBManager_SearchResultBindingSource.Current).Id });
                    padronIIBBManager_SearchResultBindingSource.RemoveCurrent();
                    padronIIBBManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}
