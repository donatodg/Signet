namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmTipoComprobante_AddMod : MultiForm, IDisposable
    {
        private TipoComprobanteManager manager;
        private bool Loading;

        public frmTipoComprobante_AddMod(TipoComprobante o)
        {
            InitializeComponent();
            manager = new TipoComprobanteManager(o);
        }

        private void frmTipoMovimientos_AddMod_Load(object sender, EventArgs e)
        {
            Loading = true;

            tipoMovimientosManagerBindingSource.DataSource = manager;

            id_AreaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ComprobanteArea));
            id_AreaLookUpEdit.Properties.DisplayMember = "Value";
            id_AreaLookUpEdit.Properties.ValueMember = "Key";

            id_TipoCompProcesaLookUpEdit.Properties.DataSource = manager.TiposComprobantes;
            id_TipoCompProcesaLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoCompProcesaLookUpEdit.Properties.ValueMember = "Key";

            id_TipoCompAnulaLookUpEdit.Properties.DataSource = manager.TiposComprobantes;
            id_TipoCompAnulaLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoCompAnulaLookUpEdit.Properties.ValueMember = "Key";

            id_MovimientoCajaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoMovimiento));
            id_MovimientoCajaLookUpEdit.Properties.DisplayMember = "Value";
            id_MovimientoCajaLookUpEdit.Properties.ValueMember = "Key";

            id_MovimientoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoMovimientoDebitoCredito));
            id_MovimientoEntidadLookUpEdit.Properties.DisplayMember = "Value";
            id_MovimientoEntidadLookUpEdit.Properties.ValueMember = "Key";

            Loading = false;
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
                manager.Save();
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void tipoMovimientosManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError(e.Exception);
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void frmTipoComprobante_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void id_AreaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Loading)
            {
                switch ((Enums.ComprobanteArea)id_AreaLookUpEdit.EditValue)
                {
                    case Enums.ComprobanteArea.Compras:
                        ordenSpinEdit.Enabled = true;
                        id_TipoCompProcesaLookUpEdit.Enabled = false;
                        id_TipoCompAnulaLookUpEdit.Enabled = false;
                        mueveStockCheckEdit.Enabled = true;
                        restaStockCheckEdit.Enabled = true;
                        id_MovimientoCajaLookUpEdit.Enabled = true;
                        id_MovimientoEntidadLookUpEdit.Enabled = true;
                        sePagaConOPCheckEdit.Enabled = true;
                        break;

                    case Enums.ComprobanteArea.Ventas:
                        ordenSpinEdit.Enabled = true;
                        id_TipoCompProcesaLookUpEdit.Enabled = true;
                        id_TipoCompAnulaLookUpEdit.Enabled = true;
                        mueveStockCheckEdit.Enabled = true;
                        restaStockCheckEdit.Enabled = true;
                        id_MovimientoCajaLookUpEdit.Enabled = true;
                        id_MovimientoEntidadLookUpEdit.Enabled = true;
                        sePagaConOPCheckEdit.Enabled = true;
                        break;

                    case Enums.ComprobanteArea.Libre:
                        ordenSpinEdit.Enabled = false;
                        id_TipoCompProcesaLookUpEdit.Enabled = false;
                        id_TipoCompAnulaLookUpEdit.Enabled = false;
                        mueveStockCheckEdit.Enabled = false;
                        restaStockCheckEdit.Enabled = false;
                        id_MovimientoCajaLookUpEdit.Enabled = false;
                        id_MovimientoEntidadLookUpEdit.Enabled = false;
                        sePagaConOPCheckEdit.Enabled = false;
                        break;
                }
            }
            else
            {
                id_TipoCompProcesaLookUpEdit.Properties.DataSource = manager.TiposComprobantes;
                id_TipoCompAnulaLookUpEdit.Properties.DataSource = manager.TiposComprobantes;

                switch ((Enums.ComprobanteArea)id_AreaLookUpEdit.EditValue)
                {
                    case Enums.ComprobanteArea.Compras:
                        ordenSpinEdit.Enabled = true;
                        id_TipoCompProcesaLookUpEdit.Enabled = false;
                        id_TipoCompAnulaLookUpEdit.Enabled = false;
                        mueveStockCheckEdit.Enabled = true;
                        restaStockCheckEdit.Enabled = true;
                        id_MovimientoCajaLookUpEdit.Enabled = true;
                        id_MovimientoEntidadLookUpEdit.Enabled = true;
                        sePagaConOPCheckEdit.Enabled = true;

                        id_TipoCompProcesaLookUpEdit.EditValue = manager.TipoComp.Id_TipoCompProcesa = null;
                        id_TipoCompAnulaLookUpEdit.EditValue = manager.TipoComp.Id_TipoCompAnula = null;
                        mueveStockCheckEdit.EditValue = manager.TipoComp.MueveStock = false;
                        restaStockCheckEdit.Enabled = manager.TipoComp.RestaStock = false;
                        id_MovimientoCajaLookUpEdit.EditValue = manager.TipoComp.Id_MovimientoCaja = null;
                        id_MovimientoEntidadLookUpEdit.EditValue = manager.TipoComp.Id_MovimientoEntidad = null;
                        break;

                    case Enums.ComprobanteArea.Ventas:
                        ordenSpinEdit.Enabled = true;
                        id_TipoCompProcesaLookUpEdit.Enabled = true;
                        id_TipoCompAnulaLookUpEdit.Enabled = true;
                        mueveStockCheckEdit.Enabled = true;
                        restaStockCheckEdit.Enabled = true;
                        id_MovimientoCajaLookUpEdit.Enabled = true;
                        id_MovimientoEntidadLookUpEdit.Enabled = true;
                        sePagaConOPCheckEdit.Enabled = true;

                        id_TipoCompProcesaLookUpEdit.EditValue = manager.TipoComp.Id_TipoCompProcesa = null;
                        id_TipoCompAnulaLookUpEdit.EditValue = manager.TipoComp.Id_TipoCompAnula = null;
                        mueveStockCheckEdit.EditValue = manager.TipoComp.MueveStock = false;
                        restaStockCheckEdit.EditValue = manager.TipoComp.RestaStock = false;
                        id_MovimientoCajaLookUpEdit.EditValue = manager.TipoComp.Id_MovimientoCaja = null;
                        id_MovimientoEntidadLookUpEdit.EditValue = manager.TipoComp.Id_MovimientoEntidad = null;
                        break;

                    case Enums.ComprobanteArea.Libre:
                        ordenSpinEdit.Enabled = false;
                        id_TipoCompProcesaLookUpEdit.Enabled = false;
                        id_TipoCompAnulaLookUpEdit.Enabled = false;
                        mueveStockCheckEdit.Enabled = false;
                        restaStockCheckEdit.Enabled = false;
                        id_MovimientoCajaLookUpEdit.Enabled = false;
                        id_MovimientoEntidadLookUpEdit.Enabled = false;
                        sePagaConOPCheckEdit.Enabled = false;

                        ordenSpinEdit.EditValue = 1; manager.TipoComp.Orden = 1;
                        id_TipoCompProcesaLookUpEdit.EditValue = manager.TipoComp.Id_TipoCompProcesa = null;
                        id_TipoCompAnulaLookUpEdit.EditValue = manager.TipoComp.Id_TipoCompAnula = null;
                        mueveStockCheckEdit.EditValue = manager.TipoComp.MueveStock = false;
                        restaStockCheckEdit.EditValue = manager.TipoComp.RestaStock = false;
                        id_MovimientoCajaLookUpEdit.EditValue = manager.TipoComp.Id_MovimientoCaja = null;
                        id_MovimientoEntidadLookUpEdit.EditValue = manager.TipoComp.Id_MovimientoEntidad = null;
                        break;
                }
            }

        }

            }
}
