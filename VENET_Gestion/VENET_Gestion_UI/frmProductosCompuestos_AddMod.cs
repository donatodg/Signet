namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Windows.Forms;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmProductosCompuestos_AddMod : MultiForm
    {
        public ProductosCompuestosManager manager;
        private Productos p = new Productos();
        private List<ProductosCompuestosDetalle> DetalleList = new List<ProductosCompuestosDetalle>();
        private bool Calcula = true;
        private string UltimaMedida = "";

        public frmProductosCompuestos_AddMod(ProductosCompuestos o)
        {
            InitializeComponent();
            manager = new ProductosCompuestosManager(o);
        }

        private void frmProductosCompuestos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                //id_TipoProduccionLookUpEdit.Properties.DataSource = manager.Tipo;
                //id_TipoProduccionLookUpEdit.Properties.DisplayMember = "Name";
                //id_TipoProduccionLookUpEdit.Properties.ValueMember = "Key";

                id_LineaLookUpEdit.Properties.DataSource = manager.Lineas;
                id_LineaLookUpEdit.Properties.DisplayMember = "Name";
                id_LineaLookUpEdit.Properties.ValueMember = "Key";

                id_VarianteLookUpEdit.Properties.DisplayMember = "Name";
                id_VarianteLookUpEdit.Properties.ValueMember = "Key";

                id_MedidaLookUpEdit.Properties.DisplayMember = "Name";
                id_MedidaLookUpEdit.Properties.ValueMember = "Key";

                id_AlicuotaIvaLookUpEdit.Properties.DataSource = manager.Alicuotas;
                id_AlicuotaIvaLookUpEdit.Properties.DisplayMember = "Name";
                id_AlicuotaIvaLookUpEdit.Properties.ValueMember = "Key";

                //id_TipoProduccionLookUpEdit.EditValue = manager.Tipo.ElementAt(0).Key;

                productosCompuestosManagerBindingSource.DataSource = manager;


                DetalleList.Clear();

                if (manager.ProductoCompuesto.Detalle != null)
                {
                    foreach (ProductosCompuestosDetalle o in manager.ProductoCompuesto.Detalle)
                    {
                        ProductosCompuestosDetalle x = new ProductosCompuestosDetalle()
                        {
                            Id = o.Id,
                            Cantidad = o.Cantidad,
                            Id_AlicuotaIva = o.Id_AlicuotaIva,
                            Id_Producto = o.Id_Producto,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            Importe = o.Importe,
                            ImporteIVA = o.ImporteIVA,
                            ImporteUnitario = o.ImporteUnitario,
                            Producto = o.Producto,
                            AlicuotaIva = o.AlicuotaIva,
                            Id_ProductoCompuesto = o.Id_ProductoCompuesto,
                            ProductoCompuesto = o.ProductoCompuesto,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        DetalleList.Add(x);
                    }
                }

                detalleBindingSource.DataSource = DetalleList;
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

        private void id_LineaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (manager != null && id_LineaLookUpEdit.ItemIndex != -1)
                {
                    manager.Id_Linea = (int)id_LineaLookUpEdit.EditValue;

                    id_MedidaLookUpEdit.Properties.DataSource = manager.Medidas;
                    if (UltimaMedida == "")
                        id_MedidaLookUpEdit.EditValue = manager.Id_Medida = manager.Medidas.ElementAt(0).Key;
                    else
                    {
                        try
                        {
                            id_MedidaLookUpEdit.EditValue = manager.Id_Medida = manager.Medidas.Where(t => t.Name == UltimaMedida).Select(t => t.Key).FirstOrDefault();
                        }
                        catch (Exception)
                        {
                            id_MedidaLookUpEdit.EditValue = manager.Id_Medida = manager.Medidas.ElementAt(0).Key;
                        }
                    }

                    id_VarianteLookUpEdit.Properties.DataSource = manager.Variantes;
                    id_VarianteLookUpEdit.EditValue = manager.Id_Variante = manager.Variantes.ElementAt(0).Key;
                }
            }
            catch (ValidationException exv)
            {
                id_VarianteLookUpEdit.Properties.DataSource = null;
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void id_MedidaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Validate();

                manager.Id_Medida = (int)id_MedidaLookUpEdit.EditValue;

                if (manager != null && id_MedidaLookUpEdit.ItemIndex != -1)
                    BuscaProducto();
            }
            catch (ValidationException exv)
            {
                id_VarianteLookUpEdit.Properties.DataSource = null;
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void id_VarianteLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Validate();

                manager.Id_Variante = (int)id_VarianteLookUpEdit.EditValue;

                id_MedidaLookUpEdit.Properties.DataSource = manager.Medidas;
                if (UltimaMedida == "")
                    id_MedidaLookUpEdit.EditValue = manager.Id_Medida = manager.Medidas.ElementAt(0).Key;
                else
                {
                    try
                    {
                        id_MedidaLookUpEdit.EditValue = manager.Id_Medida = manager.Medidas.Where(t => t.Name == UltimaMedida).Select(t => t.Key).FirstOrDefault();
                    }
                    catch (Exception)
                    {
                        id_MedidaLookUpEdit.EditValue = manager.Id_Medida = manager.Medidas.ElementAt(0).Key;
                    }
                }

                if (manager != null && id_VarianteLookUpEdit.ItemIndex != -1)
                    BuscaProducto();
            }
            catch (ValidationException exv)
            {
                id_VarianteLookUpEdit.Properties.DataSource = null;
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void BuscaProducto()
        {
            try
            {
                Calcula = false;
                p = null;
                if (manager != null && id_LineaLookUpEdit.ItemIndex != -1 && id_MedidaLookUpEdit.ItemIndex != -1 && id_VarianteLookUpEdit.ItemIndex != -1)
                {
                    string Linea = id_LineaLookUpEdit.Text.Split('-')[0];
                    string Variante = id_VarianteLookUpEdit.Text.Split('-')[0];
                    string Medida = id_MedidaLookUpEdit.Text.Split('-')[0];

                    if (Convert.ToInt32(Parametro.ObtenerValor(Parametro.Param.ProduccionProductoComposicion)) == 1)
                        p = manager.BuscarProducto(Linea + '-' + Medida.Replace("x", "") + '-' + Variante);
                    else
                        p = manager.BuscarProducto(Linea + Variante + Medida.Replace("x", ""));

                    if (p == null)
                    {
                        descripcionTextEdit.EditValue = "";
                        importeUnitarioTextEdit.EditValue = 0;
                        cantidadTextEdit.EditValue = Convert.ToDecimal(1);
                        id_AlicuotaIvaLookUpEdit.EditValue = 0;
                    }
                    else
                    {
                        descripcionTextEdit.EditValue = p.Descripcion;
                        importeUnitarioTextEdit.EditValue = Convert.ToDecimal(p.Importe);
                        cantidadTextEdit.EditValue = Convert.ToDecimal(1);
                        id_AlicuotaIvaLookUpEdit.EditValue = p.Id_IvaAlicuota;
                    }
                    Validate();
                }
                txtCompProducto.EditValue = "";
                txtCompManoObra.EditValue = "";
                txtCompUtilidad.EditValue = "";

                Calcula = true;
                CalculaTotal();
            }
            catch (Exception) { }
        }

        private void CalculaTotal()
        {
            Validate();

            if (!Calcula) return;

            decimal AlicuotaIva = id_AlicuotaIvaLookUpEdit.Text == "" ? 0 : Convert.ToDecimal(id_AlicuotaIvaLookUpEdit.Text);
            decimal Importe = (importeUnitarioTextEdit.Text == "" || importeUnitarioTextEdit.Text == "0,00") ? 0 : Convert.ToDecimal(importeUnitarioTextEdit.Text);

            if (cantidadTextEdit.Text == "")
                cantidadTextEdit.EditValue = Convert.ToDecimal(1);

            decimal Cantidad = Convert.ToDecimal(cantidadTextEdit.Text);

            decimal ImporteIVA = Math.Round(Convert.ToDecimal(((Importe) * AlicuotaIva / 100) * Cantidad), 2);

            decimal Subtotal = (Importe + ((Importe) * AlicuotaIva / 100)) * Cantidad;
            Importe = Math.Round(Subtotal, 2);

            importeIVATextEdit.EditValue = ImporteIVA;
            importeTextEdit.EditValue = Importe;

            Validate();
            Calcula = true;
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void importeUnitarioTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void cantidadTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductosCompuestosDetalle o = new ProductosCompuestosDetalle();
                o.AlicuotaIva = Convert.ToDecimal(id_AlicuotaIvaLookUpEdit.EditValue);
                o.FechaAdd = Sistema.ObtenerFechaHora();
                o.Id_AlicuotaIva = Convert.ToInt32(id_AlicuotaIvaLookUpEdit.EditValue);
                if (p != null) o.Id_Producto = p.Id;
                o.Cantidad = Convert.ToDecimal(cantidadTextEdit.EditValue);
                o.Importe = Convert.ToDecimal(importeTextEdit.EditValue);
                o.ImporteUnitario = Convert.ToDecimal(importeUnitarioTextEdit.EditValue);
                o.ImporteIVA = Convert.ToDecimal(importeIVATextEdit.EditValue);
                o.Producto = descripcionTextEdit.Text;
                o.ImporteSinIva = Convert.ToDecimal(importeTextEdit.EditValue) - Convert.ToDecimal(importeIVATextEdit.EditValue);
                o.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);

                manager.ProductoCompuesto.Detalle.Add(o);
                DetalleList.Add(o);

                gridControl1.RefreshDataSource();

                UltimaMedida = id_MedidaLookUpEdit.Text;
                //CreaDescripcion();
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

        private void CreaDescripcion()
        {
            try
            {
                try
                {
                    if (id_LineaLookUpEdit.Text != "" && id_MedidaLookUpEdit.Text != "")
                        productoFinalTextEdit.Text = id_LineaLookUpEdit.Text.Split('-')[1] + " " + id_MedidaLookUpEdit.Text.Substring(0, 3) + "X" + id_MedidaLookUpEdit.Text.Substring(3, 3) + " ";
                    //else
                    //    productoFinalTextEdit.Text = productoFinalTextEdit.Text.Split('X')[0] + "X" + productoFinalTextEdit.Text.Split('X')[1].Substring(0, 5);
                }
                catch (Exception) { }

                foreach (ProductosCompuestosDetalle d in manager.ProductoCompuesto.Detalle.Where(t => t.Borrado == false))
                {
                    int Largo = d.Producto.Length;
                    try
                    {
                        int Indice = 0;
                        if (id_MedidaLookUpEdit.Text != "")
                            Indice = d.Producto.IndexOf(id_MedidaLookUpEdit.Text.Substring(0, 3) + "X" + id_MedidaLookUpEdit.Text.Substring(3, 3)) + 7;
                        //else
                        //    Indice = d.Producto.IndexOf(productoFinalTextEdit.Text.Substring(0, 3) + "X" + productoFinalTextEdit.Text.Substring(3, 3)) + 7;


                        productoFinalTextEdit.Text += d.Producto.Substring(Indice, Largo - Indice);
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCompuestos_AddMod", Enums.Accion.Eliminar)) return;

                if (detalleBindingSource.Current == null) return;

                int i = 0;
                int ii = detalleBindingSource.Position;

                foreach (ProductosCompuestosDetalle rd in manager.ProductoCompuesto.Detalle.Where(t => t.Borrado == false))
                {
                    if (ii == i)
                    {
                        rd.Borrado = true;
                        break;
                    }
                    i++;
                }

                detalleBindingSource.RemoveAt(detalleBindingSource.Position);
                gridView1.RefreshData();

                //CreaDescripcion();
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

                if (productoFinalTextEdit.Text == "")
                    throw new ValidationException("Debe ingresar una leyenda para el producto final");

                manager.ProductoCompuesto.ProductoFinal = productoFinalTextEdit.Text;
                manager.ProductoCompuesto.ImporteTotal = manager.ProductoCompuesto.Detalle.Where(t => t.Borrado == false).Select(t => t.Importe).Sum();
                manager.ProductoCompuesto.ImporteSinIvaTotal = manager.ProductoCompuesto.Detalle.Where(t => t.Borrado == false).Select(t => t.ImporteSinIva).Sum();
                manager.ProductoCompuesto.Adicional = "";
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

        private void id_AlicuotaIvaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();

                if (Convert.ToDecimal(txtAncho.EditValue) <= 0 && Convert.ToDecimal(txtAlto.EditValue) <= 0 && Convert.ToDecimal(txtFijo.EditValue) <= 0)
                {
                    txtAncho.EditValue = Convert.ToDecimal(0);
                    txtAlto.EditValue = Convert.ToDecimal(0);
                    txtFijo.EditValue = Convert.ToDecimal(0);

                    BuscaProducto();
                    return;
                }

                //CAMBIAR LA DESCRIPCION
                string Linea = id_LineaLookUpEdit.Text.Split('-')[1].ToUpper();
                if (id_LineaLookUpEdit.Text.Split('-').Count() > 2)
                    Linea = id_LineaLookUpEdit.Text.Split('-')[1].ToUpper() + "-" + id_LineaLookUpEdit.Text.Split('-')[2].ToUpper();


                if (Convert.ToDecimal(txtFijo.EditValue) > 0)
                {
                    BuscaProducto();

                    importeUnitarioTextEdit.EditValue = Convert.ToDecimal(importeUnitarioTextEdit.EditValue) * Convert.ToDecimal(txtFijo.EditValue);

                }
                else
                 {
                    //VALIDAR QUE ESTE ANCHO Y ALTO
                    if (Convert.ToDecimal(txtAncho.EditValue) <= 0)
                        throw new ValidationException("Debe ingresar un ancho válido.");
                    if (Convert.ToDecimal(txtAlto.EditValue) <= 0)
                        throw new ValidationException("Debe ingresar un alto válido.");

                    descripcionTextEdit.Text = Linea + " - " + id_VarianteLookUpEdit.Text.Split('-')[1].ToUpper() + " - " + txtAncho.Text.Replace(",", "") + "X" + txtAlto.Text.Replace(",", "");

                    manager.Calcular();

                    txtCompProducto.EditValue = manager.ResultCalulo.Producto;
                    txtCompManoObra.EditValue = manager.ResultCalulo.ManoObra;
                    if (Convert.ToDecimal(manager.ResultCalulo.UtilidadAdicional.ToString()) > 0)
                        txtCompUtilidad.EditValue = manager.ResultCalulo.Utilidad.ToString() + "% + " + manager.ResultCalulo.UtilidadAdicional.ToString() + "%";
                    else
                        txtCompUtilidad.EditValue = manager.ResultCalulo.Utilidad.ToString() + "%";


                    importeUnitarioTextEdit.EditValue = Convert.ToDecimal(manager.ResultCalulo.TotalSinIva);

                }

                CalculaTotal();


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

        private void txtAncho_EditValueChanged(object sender, EventArgs e)
        {
            checkBox_ML.Checked = false;
            checkBox_M2.Checked = false;

            //if (CambioMedida)
            //    CambiaValor(false);
        }

        private void txtAlto_EditValueChanged(object sender, EventArgs e)
        {
            checkBox_ML.Checked = false;
            checkBox_M2.Checked = false;

            //if (CambioMedida)
            //    CambiaValor(false);
        }

        private void txtFijo_EditValueChanged(object sender, EventArgs e)
        {
            //if (CambioMedida)
            //    CambiaValor(true);
        }

        //private void CambiaValor(bool Fijo)
        //{
        //    try
        //    {
        //        CambioMedida = false;

        //        if (Fijo)
        //        {
        //            txtAncho.EditValue = Convert.ToDecimal(0);
        //            txtAlto.EditValue = Convert.ToDecimal(0);
        //        }
        //        else
        //        {
        //            txtFijo.EditValue = Convert.ToDecimal(0);
        //        }
        //        CambioMedida = true;
        //    }
        //    catch
        //    {
        //        CambioMedida = true;
        //    }
        //}

        private void checkBox_ML_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_ML.Checked)
                {
                    checkBox_M2.Checked = false;
                    txtFijo.EditValue = Convert.ToDecimal(txtAncho.EditValue) * 2 + Convert.ToDecimal(txtAlto.EditValue) * 2;
                }
                else
                {
                    txtFijo.EditValue = Convert.ToDecimal(0);
                }

            }
            catch { }
        }

        private void checkBox_M2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox_M2.Checked)
                {
                    checkBox_ML.Checked = false;
                    txtFijo.EditValue = Convert.ToDecimal(txtAncho.EditValue) * Convert.ToDecimal(txtAlto.EditValue);
                }
                else
                {
                    txtFijo.EditValue = Convert.ToDecimal(0);
                }
            }
            catch { }
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ProductosCompuestos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }
    }
}
