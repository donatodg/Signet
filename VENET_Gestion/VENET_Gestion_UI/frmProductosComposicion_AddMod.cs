namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductosComposicion_AddMod : MultiForm, IDisposable
    {
        private ProductosComposicion_AddModManager manager;
        //public ComprobantesVentasDetalle ComprobanteDetalle;
        ////public CotizacionesDetalle CotizacionDetalle;
        //private int IdSucursal;
        //private bool ImporteHabilitado;
        //private bool IvaHabilitado;
        //private int IdCliente;
        //private bool UtilizaDescuento;

        public frmProductosComposicion_AddMod(ProductosComposicion o)
        {
            InitializeComponent();
            manager = new ProductosComposicion_AddModManager(o);
        }

        private void frmProductosComposicion_AddMod_Load(object sender, EventArgs e)
        {
            //id_EspecieLookUpEdit.Properties.DataSource = Sistema.Especies;
            //id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
            //id_EspecieLookUpEdit.Properties.ValueMember = "Key";

            //id_AlicuotaIvaLookUpEdit.Properties.DataSource = manager.Alicuotas;
            //id_AlicuotaIvaLookUpEdit.Properties.DisplayMember = "Name";
            //id_AlicuotaIvaLookUpEdit.Properties.ValueMember = "Key";

            productosComposicion_AddModManagerBindingSource.DataSource = manager;

            FiltroBusquedaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ProductosFiltroBusquedas));
            FiltroBusquedaLookUpEdit.Properties.DisplayMember = "Value";
            FiltroBusquedaLookUpEdit.Properties.ValueMember = "Key";

            id_ProductoLookUpEdit.Properties.DataSource = manager.Productos;
            id_ProductoLookUpEdit.Properties.ValueMember = "Id";

            //decimal cant = manager.ProductoComposicion.Cantidad;
            cantidadTextEdit.EditValue = manager.ProductoComposicion.Cantidad;


            FiltroBusquedaLookUpEdit.ItemIndex = Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.GestionBusquedaProductosDefecto)) - 1;

        }

        private void id_ProductoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Validate();

                //bool Habilitado = true;

                if (id_ProductoLookUpEdit.ItemIndex > -1 )
                //{
                    //Habilitado = false;
                    manager.ProductoComposicion.Id_ProductoComposicion = (int?)id_ProductoLookUpEdit.EditValue;
                //}
                //else
                //    manager.ProductoComposicion.Id_ProductoComposicion = null;

                //descripcionTextEdit.Enabled = Habilitado;
                ////cantidadTextEdit.Enabled = Habilitado;
                //medidaTextEdit.Enabled = Habilitado;
                //importeCostoTextEdit.Enabled = Habilitado;
                //fechaActualizacionCostoDateEdit.Enabled = Habilitado;

                productoTextEdit.EditValue = manager.ProductoComposicion.Producto;
                medidaTextEdit.EditValue = manager.ProductoComposicion.Medida;
                importeCostoTextEdit.EditValue = manager.ProductoComposicion.ImporteCosto;
                fechaActualizacionCostoDateEdit.EditValue = manager.ProductoComposicion.FechaActualizacionCosto;

                //CalculaTotal();

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

        private void id_ProductoLookUpEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void descripcionTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Guardar();
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






    }
}
