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

    public partial class frmComprobantesCompras_IvaCompras : MultiForm
    {
        private ComprobantesCompras_IvaComprasManager.ParametrosBusquedas par = new ComprobantesCompras_IvaComprasManager.ParametrosBusquedas();

        public frmComprobantesCompras_IvaCompras()
        {
            InitializeComponent();
        }

        private void frmComprobantesCompras_IvaCompras_Load(object sender, EventArgs e)
        {
            id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
            id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
            id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

            mesLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.Meses));
            mesLookUpEdit.Properties.DisplayMember = "Value";
            mesLookUpEdit.Properties.ValueMember = "Key";

            comprobantesCompras_IvaComprasManager_ParametrosBusquedasBindingSource.DataSource = par;

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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras_IvaCompras", Enums.Accion.Buscar)) return;
                Validate();

                par.Mes = mesLookUpEdit.ItemIndex + 1;

                comprobantesCompras_IvaComprasManager_SearchResultDetalleBindingSource.DataSource = ComprobantesCompras_IvaComprasManager.BuscarIvaDetalle(par);
                comprobantesCompras_IvaComprasManager_SearchResultIVABindingSource.DataSource = ComprobantesCompras_IvaComprasManager.BuscarIva(par);
                comprobantesCompras_IvaComprasManager_SearchResultAlicuotaBindingSource.DataSource = ComprobantesCompras_IvaComprasManager.BuscarAlicuotaIva(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras_IvaCompras", Enums.Accion.Imprimir)) return;
            gridControl3.ShowRibbonPrintPreview();
        }

        private void comprobantesCompras_IvaComprasManager_SearchResultIVABindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + comprobantesCompras_IvaComprasManager_SearchResultIVABindingSource.Count.ToString();
        }


        private void btnGeneraArchivo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras_GeneraArchivo", Enums.Accion.Operaciones)) return;

            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Seleccione el directorio donde se guardarán los archivos de libro Iva Compras.";

                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string ruta = fbd.SelectedPath + "\\ComprobantesCompras.txt";

                        File.Delete(ruta);
                        using (StreamWriter file = new StreamWriter(ruta, true))
                        {
                            foreach (ComprobantesCompras_IvaComprasManager.SearchResultIVA r in (List<ComprobantesCompras_IvaComprasManager.SearchResultIVA>)comprobantesCompras_IvaComprasManager_SearchResultIVABindingSource.DataSource)
                            {
                                file.WriteLine(r.IVA_COMPRAS);
                            }
                        }

                        ruta = fbd.SelectedPath + "\\AlicuotasCompras.txt";
                        File.Delete(ruta);
                        using (StreamWriter file = new StreamWriter(ruta, true))
                        {
                            foreach (ComprobantesCompras_IvaComprasManager.SearchResultAlicuota r in (List<ComprobantesCompras_IvaComprasManager.SearchResultAlicuota>)comprobantesCompras_IvaComprasManager_SearchResultAlicuotaBindingSource.DataSource)
                            {
                                file.WriteLine(r.ALICUOTAS);
                            }
                        }

                        ruta = fbd.SelectedPath + "\\ComprobantesComprasDetalle.xlsx";
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
