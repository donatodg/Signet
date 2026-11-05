namespace VENET_Produccion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Produccion_BL;

    public partial class frmProduccionManoDeObraHistorial : MultiForm
    {
        private ProduccionManoDeObraHistorialManager.ParametrosBusquedas par = new ProduccionManoDeObraHistorialManager.ParametrosBusquedas();

        public frmProduccionManoDeObraHistorial(int Id_ManoObra)
        {
            InitializeComponent();
            par.Id_ManoObra = Id_ManoObra;
        }

        private void frmProduccionManoDeObraHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                produccionManoDeObraHistorialManager_ParametrosBusquedasBindingSource.DataSource = par;
                Buscar();
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionManoDeObraHistorial", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void produccionManoDeObraHistorialManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + produccionManoDeObraHistorialManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Produccion, "ProduccionManoDeObraHistorial", Enums.Accion.Buscar)) return;

                Validate();
                produccionManoDeObraHistorialManager_SearchResultBindingSource.DataSource = ProduccionManoDeObraHistorialManager.Buscar(par);
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
