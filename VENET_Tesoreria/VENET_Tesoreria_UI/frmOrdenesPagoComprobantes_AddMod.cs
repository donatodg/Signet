namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmOrdenesPagoComprobantes_AddMod : MultiForm
    {
        Enums.TipoEntidad _TipoEntidad;
        int _Id_Entidad;
        List<OrdenesPagoComprobantes> _ListaComprobantes = new List<OrdenesPagoComprobantes>();
        public List<OrdenesPagoComprobantes> _ListaComprobantesSeleccionados = new List<OrdenesPagoComprobantes>();
        int _IdOP = 0;
        OrdenesPagoComprobantesManager manager = new OrdenesPagoComprobantesManager();

        public frmOrdenesPagoComprobantes_AddMod(Enums.TipoEntidad TipoEntidad, int Id_Entidad, List<OrdenesPagoComprobantes> ListaComprobantes)
        {
            InitializeComponent();
            _TipoEntidad = TipoEntidad;
            _Id_Entidad = Id_Entidad;
            _ListaComprobantes = ListaComprobantes;
        }

        public frmOrdenesPagoComprobantes_AddMod(Enums.TipoEntidad TipoEntidad, int Id_Entidad, int IdOP)
        {
            InitializeComponent();
            _TipoEntidad = TipoEntidad;
            _Id_Entidad = Id_Entidad;
            _IdOP = IdOP;
            if (_IdOP <= 0) return;
        }

        private void frmOrdenesPagoComprobantes_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                ordenesPagoComprobantesManager_SearchResultBindingSource.DataSource = manager.Buscar(_TipoEntidad, _Id_Entidad, _ListaComprobantes);
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

        private void ordenesPagoComprobantesManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + ordenesPagoComprobantesManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPagoComprobantes", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
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

                _ListaComprobantesSeleccionados.Clear();

                foreach (OrdenesPagoComprobantesManager.SearchResult o in (List<OrdenesPagoComprobantesManager.SearchResult>)((BindingSource)(gridControl1.DataSource)).List)
                {
                    if (o.ImportePago > o.ImporteAdeudado)
                    {
                        Sistema.Mensaje("El importe ingresado es mayor al adeudado.");
                        return;
                    }

                    if (o.Seleccionado == true && o.ImportePago > 0)
                    {
                        o.FechaAdd = Sistema.ObtenerFechaHora();
                        o.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        _ListaComprobantesSeleccionados.Add(o);
                    }
                }

                if (_IdOP > 0)
                    OrdenesPagoComprobantesManager.AsociarComprobantes(_IdOP, _ListaComprobantesSeleccionados);

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

        //private void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e)
        //{
        //    CalculaPago();
        //}

        //private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        //{
        //    CalculaPago();
        //}

        //private void CalculaPago()
        //{
        //    Validate();
        //    //txtPago.EditValue = 0;

        //    //foreach (OrdenesPagoComprobantesManager.SearchResult o in (List<OrdenesPagoComprobantesManager.SearchResult>)((BindingSource)(gridControl1.DataSource)).List)
        //    //{
        //    //    if (o.Seleccionado == true && o.ImportePago > 0)
        //    //        txtPago.EditValue = Convert.ToDecimal(txtPago.EditValue) + o.ImportePago;
        //    //}
        //}

        //private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        //{
        //    Validate();
        //    decimal Importe = 0;

        //    foreach (OrdenesPagoComprobantesManager.SearchResult o in (List<OrdenesPagoComprobantesManager.SearchResult>)((BindingSource)(gridControl1.DataSource)).List)
        //    {
        //        if (o.Seleccionado == true && o.ImportePago > 0)
        //            Importe += o.ImportePago;
        //    }

        //    e.TotalValue = Importe;
        //}

        //private void repositoryItemCheckEdit1_CheckStateChanged(object sender, EventArgs e)
        //{
        //    gridView1_CustomSummaryCalculate(null, null);
        //}

        //private void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e)
        //{
        //    gridView1_CustomSummaryCalculate(null, null);
        //}
    }
}
