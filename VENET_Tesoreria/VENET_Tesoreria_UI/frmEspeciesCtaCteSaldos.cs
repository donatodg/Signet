namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Tesoreria_BL;

    public partial class frmEspeciesCtaCteSaldos : MultiForm
    {
        private EspeciesCtaCteSaldosManager.ParametrosBusquedas par = new EspeciesCtaCteSaldosManager.ParametrosBusquedas();

        public frmEspeciesCtaCteSaldos()
        {
            InitializeComponent();
        }

        private void frmEspeciesCtaCteSaldos_Load(object sender, EventArgs e)
        {
            especiesCtaCteSaldosManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void especiesCtaCteSaldosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + especiesCtaCteSaldosManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCteSaldos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCteSaldos", Enums.Accion.Buscar)) return;

                Validate();
                especiesCtaCteSaldosManager_SearchResultBindingSource.DataSource = new EspeciesCtaCteSaldosManager().Buscar(par);
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
