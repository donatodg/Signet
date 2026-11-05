namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Tesoreria_BL;

    public partial class frmEntidadesCtaCteSaldos : MultiForm
    {
        private EntidadesCtaCteSaldosManager.ParametrosBusquedas par = new EntidadesCtaCteSaldosManager.ParametrosBusquedas();

        public frmEntidadesCtaCteSaldos()
        {
            InitializeComponent();
        }

        private void frmEntidadesCtaCteSaldos_Load(object sender, EventArgs e)
        {
            id_TipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidadTodos));
            id_TipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
            id_TipoEntidadLookUpEdit.Properties.ValueMember = "Key";

            entidadesCtaCteSaldosManager_ParametrosBusquedasBindingSource.DataSource = par;
            //id_TipoEntidadLookUpEdit.ItemIndex = 0;
            //par.Id_TipoEntidad = 0;// (int)id_TipoEntidadLookUpEdit.EditValue;
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCteSaldos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void entidadesCtaCteSaldosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + entidadesCtaCteSaldosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EntidadesCtaCteSaldos", Enums.Accion.Buscar)) return;

                Validate();
                entidadesCtaCteSaldosManager_SearchResultBindingSource.DataSource = new EntidadesCtaCteSaldosManager().Buscar(par);
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
