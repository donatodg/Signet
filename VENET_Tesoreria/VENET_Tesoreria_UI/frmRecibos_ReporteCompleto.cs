namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Tesoreria_BL;

    public partial class frmRecibos_ReporteCompleto : MultiForm
    {
        private Recibos_ReporteCompletoManager.ParametrosBusquedas par = new Recibos_ReporteCompletoManager.ParametrosBusquedas();

        public frmRecibos_ReporteCompleto(bool soloPercepciones = false)
        {
            InitializeComponent();
            par.SoloPercepciones = soloPercepciones; 
            if (soloPercepciones)
            {
                this.Text = "Reporte de Percepciones recibidas";
            }
        }

        private void frmRecibos_ReporteCompleto_Load(object sender, EventArgs e)
        {
            id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
            id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

            recibos_ReporteCompletoManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Recibos_ReporteCompleto", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Recibos_ReporteCompleto", Enums.Accion.Buscar)) return;
                Validate();
                recibos_ReporteCompletoManager_SearchResultBindingSource.DataSource = Recibos_ReporteCompletoManager.Buscar(par);
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

        private void recibos_ReporteCompletoManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + recibos_ReporteCompletoManager_SearchResultBindingSource.Count.ToString();
        }

        private void id_SucursalLookUpEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

    }
}
