namespace VENET_Gestion_UI
{
    using DevExpress.XtraGrid;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Gestion_BL;
    using static VENET_Comun.Enums;

    public partial class frmComprobantesVentasDetalleMultiple_Add : MultiForm
    {
        private ComprobantesVentasDetalleMultipleManager manager = new ComprobantesVentasDetalleMultipleManager();
        private ComprobantesVentasDetalleMultipleManager.ParametrosBusquedas parametros = new ComprobantesVentasDetalleMultipleManager.ParametrosBusquedas();
        public List<ComprobantesVentasDetalleMultipleManager.SearchResult> Detalle = new List<ComprobantesVentasDetalleMultipleManager.SearchResult>();
        Decimal Cantidad = 0;
        Decimal Importe = 0;

        public frmComprobantesVentasDetalleMultiple_Add(TipoEntidad TipoEntidad, int Id_Entidad)
        {
            InitializeComponent();
            parametros.Id_TipoEntidad = TipoEntidad;
            parametros.Id_Entidad = Id_Entidad;
        }

        private void frmComprobantesVentasDetalleMultiple_Add_Load(object sender, EventArgs e)
        {
            try
            {
                Detalle = manager.Buscar(parametros);
                comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.DataSource = Detalle;// manager.Buscar(parametros);
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

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                Validate();
                DialogResult = DialogResult.OK;
                Close();
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

        private void CalculaTotal()
        {
            Validate();

            int Posicion = comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.Position;
            ComprobantesVentasDetalleMultipleManager.SearchResult item = Detalle[Posicion];

            decimal ImporteDesc = item.ImporteUnitario * item.PorcDescuento / 100;
            Detalle[Posicion].ImporteIVA = Math.Round(Convert.ToDecimal(((item.ImporteUnitario - ImporteDesc) * item.AlicuotaIva / 100) * item.Cantidad), 2);
            decimal Subtotal = (item.ImporteUnitario - ImporteDesc + ((item.ImporteUnitario - ImporteDesc) * item.AlicuotaIva / 100)) * item.Cantidad;
            Detalle[Posicion].Importe = Math.Round(Subtotal, 2);

            Cantidad = Detalle.Where(t => t.Seleccionado == true).Sum(t => t.Cantidad);
            Importe = Detalle.Where(t => t.Seleccionado == true).Sum(t => t.Importe);

            Validate();
            gridView1.RefreshData();
        }

        private void comprobantesVentasDetalleMultipleManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.Count.ToString();
        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            string summaryInfo = "";
            //Decimal Cantidad = 0;
            //Decimal Importe = 0;

            //Cantidad = Detalle.Where(t => t.Seleccionado == true).Sum(t => t.Cantidad);
            //Importe = Detalle.Where(t => t.Seleccionado == true).Sum(t => t.Importe);

            if (e.Item is GridGroupSummaryItem)
                summaryInfo = ((GridGroupSummaryItem)e.Item).Tag.ToString();
            if (e.IsTotalSummary)
                summaryInfo = ((GridSummaryItem)e.Item).Tag.ToString();

            if (summaryInfo == "Cantidad")
                e.TotalValue = Cantidad.ToString("N2");

            if (summaryInfo == "Importe")
                e.TotalValue = Importe.ToString("N2");
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            Detalle[comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.Position].Seleccionado = Convert.ToBoolean(((DevExpress.XtraEditors.CheckEdit)sender).CheckState);
            CalculaTotal();
        }

        //private void repositoryItemSpinEdit1_EditValueChanged(object sender, EventArgs e)
        //{
        //    Detalle[comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.Position].Cantidad = ((DevExpress.XtraEditors.SpinEdit)sender).Value;
        //    CalculaTotal();
        //}

        //private void repositoryItemSpinEdit2_EditValueChanged(object sender, EventArgs e)
        //{
        //    Detalle[comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.Position].PorcDescuento = ((DevExpress.XtraEditors.SpinEdit)sender).Value;
        //    CalculaTotal();
        //}

        private void repositoryItemSpinEdit1_Leave(object sender, EventArgs e)
        {
            Detalle[comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.Position].Cantidad = ((DevExpress.XtraEditors.SpinEdit)sender).Value;
            CalculaTotal();
        }


        private void repositoryItemSpinEdit2_Leave(object sender, EventArgs e)
        {
            Detalle[comprobantesVentasDetalleMultipleManager_SearchResultBindingSource.Position].PorcDescuento = ((DevExpress.XtraEditors.SpinEdit)sender).Value;
            CalculaTotal();
        }

    }
}