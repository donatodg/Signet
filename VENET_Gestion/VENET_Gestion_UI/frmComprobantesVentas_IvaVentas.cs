namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmComprobantesVentas_IvaVentas : MultiForm
    {
        private ComprobantesVentas_IvaVentasManager.ParametrosBusquedas par = new ComprobantesVentas_IvaVentasManager.ParametrosBusquedas();

        public frmComprobantesVentas_IvaVentas()
        {
            InitializeComponent();
        }

        private void frmComprobantesVentas_IvaVentas_Load(object sender, EventArgs e)
        {
            id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
            id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
            id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

            mesLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.Meses));
            mesLookUpEdit.Properties.DisplayMember = "Value";
            mesLookUpEdit.Properties.ValueMember = "Key";

            comprobantesVentas_IvaVentasManager_ParametrosBusquedasBindingSource.DataSource = par;

            mesLookUpEdit.ItemIndex = par.Mes - 1;
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas_IvaVentas", Enums.Accion.Buscar)) return;
                Validate();

                par.Mes = mesLookUpEdit.ItemIndex + 1;

                comprobantesVentas_IvaVentasManager_SearchResultDetalleBindingSource.DataSource = ComprobantesVentas_IvaVentasManager.BuscarIvaDetalle(par);
                comprobantesVentas_IvaVentasManager_SearchResultIVABindingSource.DataSource = ComprobantesVentas_IvaVentasManager.BuscarIva(par);
                comprobantesVentas_IvaVentasManager_SearchResultAlicuotaBindingSource.DataSource = ComprobantesVentas_IvaVentasManager.BuscarAlicuotaIva(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas_IvaVentas", Enums.Accion.Imprimir)) return;
            gridControl3.ShowRibbonPrintPreview();
        }

        private void comprobantesVentas_IvaVentasManager_SearchResultIVABindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + comprobantesVentas_IvaVentasManager_SearchResultIVABindingSource.Count.ToString();
        }


        private void btnGeneraArchivo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas_GeneraArchivo", Enums.Accion.Operaciones)) return;

            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Seleccione el directorio donde se guardarán los archivos de libro Iva Ventas.";

                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string ruta = fbd.SelectedPath + "\\ComprobantesVentas.txt";

                        File.Delete(ruta);
                        using (StreamWriter file = new StreamWriter(ruta, true))
                        {
                            foreach (ComprobantesVentas_IvaVentasManager.SearchResultIVA r in (List<ComprobantesVentas_IvaVentasManager.SearchResultIVA>)comprobantesVentas_IvaVentasManager_SearchResultIVABindingSource.DataSource)
                            {
                                file.WriteLine(r.IVA_VENTAS);
                            }
                        }

                        ruta = fbd.SelectedPath + "\\AlicuotasVentas.txt";
                        File.Delete(ruta);
                        using (StreamWriter file = new StreamWriter(ruta, true))
                        {
                            foreach (ComprobantesVentas_IvaVentasManager.SearchResultAlicuota r in (List<ComprobantesVentas_IvaVentasManager.SearchResultAlicuota>)comprobantesVentas_IvaVentasManager_SearchResultAlicuotaBindingSource.DataSource)
                            {
                                file.WriteLine(r.ALICUOTAS);
                            }
                        }

                        ruta = fbd.SelectedPath + "\\ComprobantesVentasDetalle.xlsx";
                        File.Delete(ruta);
                        gridControl3.ExportToXlsx(ruta);
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}
