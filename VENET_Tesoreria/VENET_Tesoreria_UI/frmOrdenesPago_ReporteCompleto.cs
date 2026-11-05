namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Tesoreria_BL;

    public partial class frmOrdenesPago_ReporteCompleto : MultiForm
    {
        private OrdenesPago_ReporteCompletoManager.ParametrosBusquedas par = new OrdenesPago_ReporteCompletoManager.ParametrosBusquedas();

        public frmOrdenesPago_ReporteCompleto()
        {
            InitializeComponent();
        }

        private void frmOrdenesPago_ReporteCompleto_Load(object sender, EventArgs e)
        {
            id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
            id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

            ordenesPago_ReporteCompletoManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void id_SucursalLookUpEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "OrdenesPago_ReporteCompleto", Enums.Accion.Buscar)) return;
                Validate();
                ordenesPago_ReporteCompletoManager_SearchResultBindingSource.DataSource = OrdenesPago_ReporteCompletoManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "OrdenesPago_ReporteCompleto", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void ordenesPago_ReporteCompletoManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + ordenesPago_ReporteCompletoManager_SearchResultBindingSource.Count.ToString();
        }


    }
}
