namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmComprobantesVentasAProcesar_AddMod : MultiForm, IDisposable
    {
        private ComprobantesVentasAProcesarManager manager;
        private bool ImporteHabilitado;
        private bool IvaHabilitado;
        private bool load;

        public frmComprobantesVentasAProcesar_AddMod(ComprobantesVentasAProcesar o)
        {
            InitializeComponent();
            manager = new ComprobantesVentasAProcesarManager(o);
        }

        private void frmComprobantesVentasAProcesar_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                load = true;

                ImporteHabilitado = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.GestionModificaImporteProductosEnVenta));
                IvaHabilitado = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.GestionModificaIvaProductosEnVenta));

                id_TipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
                id_TipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
                id_TipoEntidadLookUpEdit.Properties.ValueMember = "Key";

                id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
                id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
                id_EspecieLookUpEdit.Properties.ValueMember = "Key";

                id_AlicuotaIvaLookUpEdit.Properties.DataSource = manager.Alicuotas;
                id_AlicuotaIvaLookUpEdit.Properties.DisplayMember = "Name";
                id_AlicuotaIvaLookUpEdit.Properties.ValueMember = "Key";

                FiltroBusquedaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ProductosFiltroBusquedas));
                FiltroBusquedaLookUpEdit.Properties.DisplayMember = "Value";
                FiltroBusquedaLookUpEdit.Properties.ValueMember = "Key";

                id_ProductoLookUpEdit.Properties.DataSource = manager.Productos;
                id_ProductoLookUpEdit.Properties.ValueMember = "Id";

                comprobantesVentasAProcesarManagerBindingSource.DataSource = manager;

                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
                id_EntidadLookUpEdit.Properties.ValueMember = "Key";

                FiltroBusquedaLookUpEdit.ItemIndex = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.GestionBusquedaProductosDefecto)) - 1;

                load = false;

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

        private void id_TipoEntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (load) return;

                manager.AProcesar.Id_TipoEntidad = (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.EditValue = manager.AProcesar.Id_Entidad = null;
            }
            catch { }
        }

        private void id_ProductoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Validate();

                bool Habilitado = true;

                if (id_ProductoLookUpEdit.ItemIndex > -1)
                {
                    Habilitado = false;
                    manager.AProcesar.Id_Producto = (int?)id_ProductoLookUpEdit.EditValue;
                }
                else
                    manager.AProcesar.Id_Producto = null;

                descripcionTextEdit.Enabled = Habilitado;
                id_EspecieLookUpEdit.Enabled = Habilitado;
                id_AlicuotaIvaLookUpEdit.Enabled = IvaHabilitado;
                importeUnitarioTextEdit.Enabled = ImporteHabilitado;

                id_AlicuotaIvaLookUpEdit.EditValue = manager.AProcesar.Id_AlicuotaIva;
                importeUnitarioTextEdit.EditValue = manager.AProcesar.ImporteUnitario;
                id_EspecieLookUpEdit.EditValue = manager.AProcesar.Id_Especie;

                CalculaTotal();

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

            decimal AlicuotaIva = id_AlicuotaIvaLookUpEdit.Text == "" ? 0 : Convert.ToDecimal(id_AlicuotaIvaLookUpEdit.Text);
            decimal PorcDesc = (porcDescuentoTextEdit.Text == "" || porcDescuentoTextEdit.Text == "0,00") ? 0 : Convert.ToDecimal(porcDescuentoTextEdit.Text);
            decimal Importe = (importeUnitarioTextEdit.Text == "" || importeUnitarioTextEdit.Text == "0,00") ? 0 : Convert.ToDecimal(importeUnitarioTextEdit.Text);
            decimal Cantidad = Convert.ToDecimal(cantidadTextEdit.Text);
            manager.AProcesar.Cantidad = Cantidad;

            decimal ImporteDesc = Importe * PorcDesc / 100;

            manager.AProcesar.ImporteIVA = ((Importe - ImporteDesc) * AlicuotaIva / 100) * Cantidad;

            decimal Subtotal = (Importe - ImporteDesc + ((Importe - ImporteDesc) * AlicuotaIva / 100)) * Cantidad;
            manager.AProcesar.Importe = Subtotal;

            importeIVATextEdit.EditValue = manager.AProcesar.ImporteIVA;
            importeTextEdit.EditValue = manager.AProcesar.Importe;

            Validate();
        }

        private void Guardar()
        {
            try
            {
                Validate();

                if (manager.AProcesar.Importe <= 0)
                {
                    Sistema.Mensaje("Debe ingresar un importe válido.");
                    return;
                }
                if (manager.AProcesar.PorcDescuento > 100 || manager.AProcesar.PorcDescuento < 0)
                {
                    Sistema.Mensaje("Debe ingresar un porcentaje de descuento válido.");
                    return;
                }

                manager.Save();

                //manager.AProcesar.FechaAdd = Sistema.ObtenerFechaHora();
                //manager.AProcesar.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                //manager.AProcesar.Especie = id_EspecieLookUpEdit.Text;
                //ComprobanteDetalle.Cotizacion = manager.Detalle.Cotizacion;
                //ComprobanteDetalle.AlicuotaIva = Convert.ToDecimal(id_AlicuotaIvaLookUpEdit.Text);

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

        private void FiltroBusquedaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            id_ProductoLookUpEdit.Properties.DisplayMember = FiltroBusquedaLookUpEdit.EditValue.ToString();
        }

        private void id_ProductoLookUpEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void cantidadTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void importeUnitarioTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void id_AlicuotaIvaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void porcDescuentoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void porcDescuentoTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Guardar();
            //  SelectNextControl((Control)sender, true, true, true, true);
        }

    }
}
