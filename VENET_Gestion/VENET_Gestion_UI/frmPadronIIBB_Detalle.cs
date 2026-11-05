namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmPadronIIBB_Detalle : MultiForm
    {
        PadronIIBB_DetalleManager manager;

        public frmPadronIIBB_Detalle(int Id_PadronIIBB)
        {
            InitializeComponent();
            manager = new PadronIIBB_DetalleManager(Id_PadronIIBB);
        }

        private void frmPadronIIBB_Detalle_Load(object sender, EventArgs e)
        {
            try
            {
                padronIIBB_DetalleManager_SearchResultBindingSource.DataSource = manager.Buscar();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PadronIIBB_Detalle", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void padronIIBB_DetalleManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + padronIIBB_DetalleManager_SearchResultBindingSource.Count.ToString();
        }
    }
}
