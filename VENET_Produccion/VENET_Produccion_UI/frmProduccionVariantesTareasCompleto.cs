namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Produccion_BL;

    public partial class frmProduccionVariantesTareasCompleto : MultiForm
    {
        public frmProduccionVariantesTareasCompleto()
        {
            InitializeComponent();
        }

        private void frmProduccionVariantesTareasCompleto_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantesTareasCompleto", Enums.Accion.Buscar)) return;

                produccionVariantesManager_SearchResultCompletoBindingSource.DataSource = ProduccionVariantesManager.BuscarCompleto();
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

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionVariantesTareasCompleto", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void produccionVariantesManager_SearchResultCompletoBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionVariantesManager_SearchResultCompletoBindingSource.Count.ToString();
        }
    }
}
