namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmComprobantesCompras_ReporteCompleto : MultiForm
    {
        private ComprobantesCompras_ReporteCompletoManager.ParametrosBusquedas par = new ComprobantesCompras_ReporteCompletoManager.ParametrosBusquedas();

        public frmComprobantesCompras_ReporteCompleto()
        {
            InitializeComponent();
        }

        private void frmComprobantesCompras_ReporteCompleto_Load(object sender, EventArgs e)
        {
            id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
            id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
            id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

            id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobanteCompras;
            id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";

            comprobantesCompras_ReporteCompletoManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void id_TipoComprobanteLookUpEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras_ReporteCompleto", Enums.Accion.Buscar)) return;
                Validate();
                comprobantesCompras_ReporteCompletoManager_SearchResultBindingSource.DataSource = ComprobantesCompras_ReporteCompletoManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras_ReporteCompleto", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void comprobantesCompras_ReporteCompletoManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + comprobantesCompras_ReporteCompletoManager_SearchResultBindingSource.Count.ToString();
        }

        private void soloGeneraDeudaCheckEdit_CheckStateChanged(object sender, EventArgs e)
        {
            Validate();
            if (soloGeneraDeudaCheckEdit.Checked)
            {
                par.Id_TipoComprobante = null;
                id_TipoComprobanteLookUpEdit.Enabled = false;
            }
            else
            {
                id_TipoComprobanteLookUpEdit.Enabled = true;
            }

        }
    }
}
