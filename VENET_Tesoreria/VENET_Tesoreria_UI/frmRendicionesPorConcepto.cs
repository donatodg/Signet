namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Tesoreria_BL;

    public partial class frmRendicionesPorConcepto : MultiForm
    {
        private RendicionesPorConceptoManager.ParametrosBusquedas par = new RendicionesPorConceptoManager.ParametrosBusquedas();

        public frmRendicionesPorConcepto()
        {
            InitializeComponent();
        }

        private void frmRendicionesPorConcepto_Load(object sender, EventArgs e)
        {
            try
            {
                id_CuentaLookUpEdit.Properties.DataSource = par.Cuentas;
                id_CuentaLookUpEdit.Properties.DisplayMember = "Name";
                id_CuentaLookUpEdit.Properties.ValueMember = "Key";

                rendicionesPorConceptoManager_ParametrosBusquedasBindingSource.DataSource = par;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "RendicionesPorConcepto", Enums.Accion.Buscar)) return;
                Validate();
                rendicionesPorConceptoManager_SearchResultBindingSource.DataSource = RendicionesPorConceptoManager.Buscar(par);
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

        private void rendicionesPorConceptoManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + rendicionesPorConceptoManager_SearchResultBindingSource.Count.ToString();
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "RendicionesPorConcepto", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }
    }
}
