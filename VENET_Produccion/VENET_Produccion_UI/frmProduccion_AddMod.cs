namespace VENET_Produccion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Produccion_BL;

    public partial class frmProduccion_AddMod : MultiForm
    {
        private ProduccionManager manager;

        public frmProduccion_AddMod(Produccion o)
        {
            InitializeComponent();
            manager = new ProduccionManager(o);
        }

        private void frmProduccion_AddMod_Load(object sender, EventArgs e)
        {
            produccionManagerBindingSource.DataSource = manager;

            operacionLookUpEdit.Properties.DataSource = new List<string>() { "*", "+" };
            operacionAltosLookUpEdit.Properties.DataSource = new List<string>() { "-", "+" };
            operacionAnchosLookUpEdit.Properties.DataSource = new List<string>() { "-", "+" };

            //operacionLookUpEdit.ItemIndex = 0;
            //operacionAltosLookUpEdit.ItemIndex = 0;
            //operacionAnchosLookUpEdit.ItemIndex = 0;

            FiltroBusquedaLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.ProductosFiltroBusquedas));
            FiltroBusquedaLookUpEdit.Properties.DisplayMember = "Value";
            FiltroBusquedaLookUpEdit.Properties.ValueMember = "Key";

            id_ProductoLookUpEdit.Properties.DataSource = manager.Productos;
            id_ProductoLookUpEdit.Properties.ValueMember = "Id";

            id_ProductoDerivadoLookUpEdit.Properties.DataSource = manager.ProductosDerivados;
            id_ProductoDerivadoLookUpEdit.Properties.DisplayMember = "Name";
            id_ProductoDerivadoLookUpEdit.Properties.ValueMember = "Key";

            //manager.Produccion.Operacion = operacionLookUpEdit.Text;
            //manager.Produccion.OperacionAltos = operacionAltosLookUpEdit.Text;
            //manager.Produccion.OperacionAnchos = operacionAnchosLookUpEdit.Text;

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

                if (id_ProductoLookUpEdit.ItemIndex > -1)
                {
                    manager.Produccion.Id_Producto = (int)id_ProductoLookUpEdit.EditValue;

                    id_ProductoDerivadoLookUpEdit.Properties.DataSource = manager.ProductosDerivados;
                }
                //else
                //    manager.Produccion.Id_Producto = 0;

                Validate();

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

        private void Guardar()
        {
            try
            {
                Validate();

                if (gridLookUpEdit1View.GetSelectedRows().GetLength(0) == 0)
                {
                    Sistema.Mensaje("No ha seleccionado ninguna medida.", "Seleccione medida");
                    return;
                }

                manager.Produccion.Operacion = operacionLookUpEdit.Text;
                manager.Produccion.OperacionAltos = operacionAltosLookUpEdit.Text;
                manager.Produccion.OperacionAnchos = operacionAnchosLookUpEdit.Text;

                foreach (int Id in gridLookUpEdit1View.GetSelectedRows())
                    manager.Save(((KeyNamePair)gridLookUpEdit1View.GetRow(Id)).Key);

                //****************************************************************
                //guardar por cada medida
                //completar el codigo y la descripcion
                //si existe acualizar
                //validar ingreso de cantidad o medida
                //****************************************************************


                //if (produc.Importe <= 0)
                //{
                //    Sistema.Mensaje("Debe ingresar un importe válido.");
                //    return;
                //}
                //if (ComprobanteDetalle.PorcDescuento > 100 || ComprobanteDetalle.PorcDescuento < 0)
                //{
                //    Sistema.Mensaje("Debe ingresar un porcentaje de descuento válido.");
                //    return;
                //}
                //if (ComprobanteDetalle.Descripcion == "" || ComprobanteDetalle.Descripcion == null)
                //{
                //    Sistema.Mensaje("Debe ingresar un producto");
                //    return;
                //}

                //ComprobanteDetalle.FechaAdd = Sistema.ObtenerFechaHora();
                //ComprobanteDetalle.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                //ComprobanteDetalle.Especie = id_EspecieLookUpEdit.Text;
                //ComprobanteDetalle.Cotizacion = manager.Detalle.Cotizacion;
                //ComprobanteDetalle.AlicuotaIva = Convert.ToDecimal(id_AlicuotaIvaLookUpEdit.Text);
                //ComprobanteDetalle.Id_AlicuotaIva = Convert.ToInt32(id_AlicuotaIvaLookUpEdit.EditValue);

                DialogResult = DialogResult.OK;
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

        private void id_ProductoLookUpEdit_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void id_MedidaLookUpEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Guardar();
        }

        private void gridLookUpEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            int cant = gridLookUpEdit1View.GetSelectedRows().GetLength(0);
            if (cant == 1)
                lblSeleccionados.Text = "1 item seleccionado";
            else
                lblSeleccionados.Text = string.Format("{0} items seleccionados", cant);
        }

        private void cantidadTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(cantidadTextEdit.EditValue) > 0)
            {
                altosTextEdit.EditValue = 0;
                anchosTextEdit.EditValue = 0;
                incidenciaTextEdit.EditValue = 1;

                manager.Produccion.Altos = 0;
                manager.Produccion.Anchos = 0;
                manager.Produccion.Incidencia = 1;
            }
        }

        private void anchosTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(anchosTextEdit.EditValue) > 0)
            {
                cantidadTextEdit.EditValue = 0;
                manager.Produccion.Cantidad = 0;
            }
        }

        private void altosTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(altosTextEdit.EditValue) > 0)
            {
                cantidadTextEdit.EditValue = 0;
                manager.Produccion.Cantidad = 0;
            }
        }
    }
}
