namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmComprobantesComprasDetalle_AddMod : MultiForm, IDisposable
    {
        private ComprobantesComprasDetalleManager manager;
        public ComprobantesComprasDetalle ComprobanteDetalle;
        private int IdSucursal;

        public frmComprobantesComprasDetalle_AddMod(ComprobantesComprasDetalle o, int Id_Sucursal)
        {
            InitializeComponent();
            ComprobanteDetalle = o;
            IdSucursal = Id_Sucursal;

            manager = new ComprobantesComprasDetalleManager(o, IdSucursal);
        }

        private void frmComprobantesComprasDetalle_AddMod_Load(object sender, EventArgs e)
        {
            int Ancho = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.ComprobantesVentas_AnchoPantalla));
            if (Ancho > 424 && Ancho < 1025)
                this.Width = Ancho;

            id_EspecieLookUpEdit.Properties.DataSource = Sistema.EspeciesTodas;
            //id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
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

            decimal cant = manager.Detalle.Cantidad;
            comprobantesComprasDetalleManagerBindingSource.DataSource = manager;
            manager.Detalle.Cantidad = cant;
            cantidadTextEdit.EditValue = manager.Detalle.Cantidad;

            FiltroBusquedaLookUpEdit.ItemIndex = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.GestionBusquedaProductosDefecto)) - 1;
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
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
                    manager.Detalle.Id_Producto = (int?)id_ProductoLookUpEdit.EditValue;
                }
                else
                    manager.Detalle.Id_Producto = null;

                descripcionTextEdit.Enabled = Habilitado;

                id_EspecieLookUpEdit.Enabled = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVentas_CambiaEspecie));


                id_AlicuotaIvaLookUpEdit.EditValue = manager.Detalle.Id_AlicuotaIva;
                importeUnitarioTextEdit.EditValue = manager.Detalle.ImporteUnitario;
                id_EspecieLookUpEdit.EditValue = manager.Detalle.Id_Especie;

                if (manager.Detalle.Visible_Cantidad_Stock)
                    cantidadStockSpinEdit.Visible = cantidadStockLabel.Visible = true;
                else
                {
                    cantidadStockSpinEdit.Visible = cantidadStockLabel.Visible = false;
                    cantidadStockSpinEdit.EditValue = manager.Detalle.CantidadStock = 0;
                }

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

        private void FiltroBusquedaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            id_ProductoLookUpEdit.Properties.DisplayMember = FiltroBusquedaLookUpEdit.EditValue.ToString();

            switch (FiltroBusquedaLookUpEdit.ItemIndex)
            {
                case 0:
                    id_ProductoLookUpEdit.Properties.Columns[1].Visible = true;
                    id_ProductoLookUpEdit.Properties.Columns[2].Visible = false;
                    id_ProductoLookUpEdit.Properties.Columns[3].Visible = false;
                    break;

                case 1:
                    id_ProductoLookUpEdit.Properties.Columns[1].Visible = false;
                    id_ProductoLookUpEdit.Properties.Columns[2].Visible = true;
                    id_ProductoLookUpEdit.Properties.Columns[3].Visible = false;
                    break;

                case 2:
                    id_ProductoLookUpEdit.Properties.Columns[1].Visible = false;
                    id_ProductoLookUpEdit.Properties.Columns[2].Visible = false;
                    id_ProductoLookUpEdit.Properties.Columns[3].Visible = true;
                    break;
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                manager.Detalle.Visible_Cantidad_Stock = false;
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
            }
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

        private void CalculaTotal()
        {
            Validate();

            decimal AlicuotaIva = id_AlicuotaIvaLookUpEdit.Text == "" ? 0 : Convert.ToDecimal(id_AlicuotaIvaLookUpEdit.Text);
            decimal PorcDesc = (porcDescuentoTextEdit.Text == "" || porcDescuentoTextEdit.Text == "0,00") ? 0 : Convert.ToDecimal(porcDescuentoTextEdit.Text);
            decimal Importe = (importeUnitarioTextEdit.Text == "" || importeUnitarioTextEdit.Text == "0,00") ? 0 : Convert.ToDecimal(importeUnitarioTextEdit.Text);
            decimal Cantidad = Convert.ToDecimal(cantidadTextEdit.Text);
            manager.Detalle.Cantidad = Cantidad;

            decimal ImporteDesc = Importe * PorcDesc / 100;

            manager.Detalle.ImporteIVA = Math.Round(Convert.ToDecimal(((Importe - ImporteDesc) * AlicuotaIva / 100) * Cantidad), 2);

            decimal Subtotal = (Importe - ImporteDesc + ((Importe - ImporteDesc) * AlicuotaIva / 100)) * Cantidad;
            manager.Detalle.Importe = Math.Round(Subtotal, 2);

            importeIVATextEdit.EditValue = manager.Detalle.ImporteIVA;
            importeTextEdit.EditValue = manager.Detalle.Importe;

            Validate();
        }

        private void Guardar()
        {
            try
            {
                Validate();

                if (ComprobanteDetalle.Importe <= 0)
                {
                    Sistema.Mensaje("Debe ingresar un importe válido.");
                    return;
                }
                if (ComprobanteDetalle.PorcDescuento > 100 || ComprobanteDetalle.PorcDescuento < 0)
                {
                    Sistema.Mensaje("Debe ingresar un porcentaje de descuento válido.");
                    return;
                }
                if (ComprobanteDetalle.Descripcion == "" || ComprobanteDetalle.Descripcion == null)
                {
                    Sistema.Mensaje("Debe ingresar un producto");
                    return;
                }
                if (ComprobanteDetalle.Visible_Cantidad_Stock && ComprobanteDetalle.CantidadStock <= 0)
                {
                    Sistema.Mensaje("Debe ingresar un cantidad de stock válida.");
                    return;
                }

                ComprobanteDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                ComprobanteDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                ComprobanteDetalle.Especie = id_EspecieLookUpEdit.Text;
                ComprobanteDetalle.Cotizacion = manager.Detalle.Cotizacion;
                ComprobanteDetalle.AlicuotaIva = Convert.ToDecimal(id_AlicuotaIvaLookUpEdit.Text);
                ComprobanteDetalle.Id_AlicuotaIva = Convert.ToInt32(id_AlicuotaIvaLookUpEdit.EditValue);

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

        private void id_ProductoLookUpEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void porcDescuentoTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Guardar();
        }
    }
}
