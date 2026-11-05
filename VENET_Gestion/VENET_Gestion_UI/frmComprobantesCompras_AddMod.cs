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

    public partial class frmComprobantesCompras_AddMod : MultiForm, IDisposable
    {
        private ComprobantesComprasManager manager;
        public List<ComprobantesComprasDetalle> DetalleList = new List<ComprobantesComprasDetalle>();
        private bool load;

        public frmComprobantesCompras_AddMod()
        {
            InitializeComponent();
            manager = new ComprobantesComprasManager(new ComprobantesCompras() { Id = Convert.ToInt32(ConfigurationManager.AppSettings["ParametroId"]) });
        }

        public frmComprobantesCompras_AddMod(ComprobantesCompras o, string NombreComprobante = "")
        {
            InitializeComponent();
            manager = new ComprobantesComprasManager(o);
            if (NombreComprobante != "") Text += " - " + NombreComprobante;
        }

        private void frmComprobantesCompras_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                load = true;

                fechaDateEdit.Enabled = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesGestion_ModificarFechaCreacion));

                id_TipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
                id_TipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
                id_TipoEntidadLookUpEdit.Properties.ValueMember = "Key";

                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
                id_EntidadLookUpEdit.Properties.ValueMember = "Key";

                id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
                id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
                id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

                id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
                id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
                id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

                id_DepositoLookUpEdit.Properties.DataSource = Sistema.Depositos;
                id_DepositoLookUpEdit.Properties.DisplayMember = "Name";
                id_DepositoLookUpEdit.Properties.ValueMember = "Key";

                //id_VendedorLookUpEdit.Properties.DataSource = manager.Vendedores;
                //id_VendedorLookUpEdit.Properties.DisplayMember = "Name";
                //id_VendedorLookUpEdit.Properties.ValueMember = "Key";

                //id_TalonariosComprobantesLookUpEdit.Properties.DataSource = manager.Letra;
                //id_TalonariosComprobantesLookUpEdit.Properties.DisplayMember = "Name";
                //id_TalonariosComprobantesLookUpEdit.Properties.ValueMember = "Key";

                id_FormaPagoLookUpEdit.Properties.DataSource = Sistema.FormasPagos;
                id_FormaPagoLookUpEdit.Properties.DisplayMember = "Name";
                id_FormaPagoLookUpEdit.Properties.ValueMember = "Key";

                comprobantesComprasManagerBindingSource.DataSource = manager;

                //if (manager.Letra.Count > 0)
                //    id_TalonariosComprobantesLookUpEdit.ItemIndex = 0;

                string IdTipoComprobantes = "," + Convert.ToString(Parametro.ObtenerValor(Parametro.Param.ComprobantesCompras_UtilizaColorIds)) + ",";

                if (IdTipoComprobantes.Contains("," + manager.Comprobante.Id_TipoComprobante + ","))
                    tpGeneral.BackColor = System.Drawing.Color.Red;

                    DetalleList.Clear();

                if (manager.Comprobante.Detalle != null)
                {
                    foreach (ComprobantesComprasDetalle o in manager.Comprobante.Detalle)
                    {
                        ComprobantesComprasDetalle x = new ComprobantesComprasDetalle()
                        {
                            Id = o.Id,
                            Cantidad = o.Cantidad,
                            Descripcion = o.Descripcion,
                            Id_AlicuotaIva = o.Id_AlicuotaIva,
                            Id_ComprobanteCompra = o.Id_ComprobanteCompra,
                            Id_Producto = o.Id_Producto,
                            //ImporteCosto = o.ImporteCosto,
                            Especie = o.Especie,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            Id_Especie = o.Id_Especie,
                            Importe = o.Importe,
                            ImporteIVA = o.ImporteIVA,
                            ImporteUnitario = o.ImporteUnitario,
                            PorcDescuento = o.PorcDescuento,
                            ComprobanteCompra = o.ComprobanteCompra,
                            CantidadStock = o.CantidadStock,
                          // Visible_Cantidad_Stock = o.Visible_Cantidad_Stock,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        DetalleList.Add(x);
                    }
                }

                if (manager.Comprobante.Detalle.Count > 0)
                {
                    id_SucursalLookUpEdit.Enabled = false;
                    id_EntidadLookUpEdit.Enabled = false;
                    id_TipoEntidadLookUpEdit.Enabled = false;
                }

                detalleBindingSource.DataSource = DetalleList;

                //if (manager.Comprobante.Id > 0)
                //    id_TalonariosComprobantesLookUpEdit.Enabled = false;


                if (manager.Comprobante.FechaLiquidacion != null)
                {
                    btnAceptar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }

                load = false;

                CalculaTotal();

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
                ConfigurationManager.AppSettings["RetornoId"] = manager.Comprobante.Id.ToString();
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

        private void id_TipoEntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!load && manager.Comprobante != null && id_TipoEntidadLookUpEdit.ItemIndex != -1)
            {
                manager.Comprobante.Id_TipoEntidad = (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.EditValue = manager.Comprobante.Id_Entidad = null;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Agregar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras_AddMod", Enums.Accion.Agregar)) return;

                //if (manager.Comprobante.Id_TalonariosComprobantes == 0)
                //{
                //    Sistema.Mensaje("No se ha cargado ningún talonario para el comprobante.");
                //    return;
                //}

                if (manager.Comprobante.Id_Entidad == null)
                {
                    Sistema.Mensaje("Debe selecciona una entidad.");
                    return;
                }

                ComprobantesComprasDetalle o = new ComprobantesComprasDetalle();
                var f = new frmComprobantesComprasDetalle_AddMod(o, manager.Comprobante.Id_Sucursal);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    manager.Comprobante.Detalle.Add(o);
                    DetalleList.Add(o);

                    gridControl1.RefreshDataSource();
                    id_SucursalLookUpEdit.Enabled = false;
                    id_EntidadLookUpEdit.Enabled = false;
                    id_TipoEntidadLookUpEdit.Enabled = false;
                }
                f.Dispose();

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

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras_AddMod", Enums.Accion.Modificar)) return;

                if (detalleBindingSource.Current == null || !btnModificar.Enabled) return;
                {
                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    ComprobantesComprasDetalle o = new ComprobantesComprasDetalle();

                    foreach (ComprobantesComprasDetalle rd in manager.Comprobante.Detalle.Where(t => t.Borrado == false))
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    var f = new frmComprobantesComprasDetalle_AddMod(o, manager.Comprobante.Id_Sucursal);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {

                        detalleBindingSource[detalleBindingSource.Position] = o;

                        gridView1.RefreshData();
                        gridControl1.RefreshDataSource();

                        detalleBindingSource.EndEdit();
                    }

                    f.Dispose();

                    CalculaTotal();
                }
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

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras_AddMod", Enums.Accion.Eliminar)) return;

                if (detalleBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    //if (DetalleList[detalleBindingSource.Position].Id != 0)
                    //    ComprobantesComprasDetalleManager.Eliminar(new ComprobantesComprasDetalle() { Id = ((ComprobantesComprasDetalle)detalleBindingSource[detalleBindingSource.Position]).Id });

                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    //ComprobantesComprasDetalle o = new ComprobantesComprasDetalle();

                    foreach (ComprobantesComprasDetalle rd in manager.Comprobante.Detalle.Where(t => t.Borrado == false))
                    {
                        if (ii == i)
                        {
                            //o = rd;
                            rd.Borrado = true;
                            break;
                        }
                        i++;
                    }

                    //if (DetalleList[detalleBindingSource.Position].Id == 0)
                    //    o.Borrado = true;

                    detalleBindingSource.RemoveAt(detalleBindingSource.Position);
                    //DetalleList.Remove(DetalleList[detalleBindingSource.Position]);
                    gridView1.RefreshData();

                    CalculaTotal();

                }
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

        private void frmComprobantesCompras_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager.Comprobante.Detalle.Count == 0 && manager.Comprobante.Id > 0)
            {
                ComprobantesComprasManager.Eliminar(new ComprobantesCompras { Id = manager.Comprobante.Id });
                DialogResult = DialogResult.Cancel;
            }
            if (manager != null) manager.Dispose();
        }

        private void id_SucursalLookUpEdit_TextChanged(object sender, EventArgs e)
        {
            Validate();
        }

        private void TextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!load && otrosImpuestosTextEdit.Text != "" && retencionesTextEdit.Text != "" && percepcionIvaTextEdit.Text != "" & percepcionIIBBTextEdit.Text != "")
            {
                Validate();

                manager.Comprobante.OtrosImpuestos = (decimal)otrosImpuestosTextEdit.EditValue;
                manager.Comprobante.PercepcionGanancias = (decimal)retencionesTextEdit.EditValue;
                manager.Comprobante.PercepcionIIBB = (decimal)percepcionIIBBTextEdit.EditValue;
                manager.Comprobante.PercepcionIva = (decimal)percepcionIvaTextEdit.EditValue;
                manager.Comprobante.Descuento = (decimal)descuentoTextEdit.EditValue;
                manager.Comprobante.ITC = (decimal)iTCTextEdit.EditValue;
                manager.Comprobante.ImpuestoNoGravado = (decimal)impuestoNoGravadoTextEdit.EditValue;
                manager.Comprobante.PercepcionIIBBCapital = (decimal)percepcionIIBBCapitalTextEdit.EditValue;

                CalculaTotal();
            }
        }

        private void TextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Validate();

            manager.Comprobante.OtrosImpuestos = (decimal)otrosImpuestosTextEdit.EditValue;
            manager.Comprobante.PercepcionGanancias = (decimal)retencionesTextEdit.EditValue;
            manager.Comprobante.PercepcionIIBB = (decimal)percepcionIIBBTextEdit.EditValue;
            manager.Comprobante.PercepcionIva = (decimal)percepcionIvaTextEdit.EditValue;
            manager.Comprobante.Descuento = (decimal)descuentoTextEdit.EditValue;
            manager.Comprobante.ITC = (decimal)iTCTextEdit.EditValue;
            manager.Comprobante.ImpuestoNoGravado = (decimal)impuestoNoGravadoTextEdit.EditValue;
            manager.Comprobante.PercepcionIIBBCapital = (decimal)percepcionIIBBCapitalTextEdit.EditValue;

            CalculaTotal();
        }

        private void CalculaTotal()
        {
            try
            {
                decimal i = 0;
                foreach (ComprobantesComprasDetalle d in manager.Comprobante.Detalle)
                {
                    if (!d.Borrado)
                        i += d.Importe;//* d.Cotizacion 

                    txtTotal.EditValue = i + manager.Comprobante.OtrosImpuestos + manager.Comprobante.PercepcionIIBB + manager.Comprobante.PercepcionIva + manager.Comprobante.PercepcionGanancias + manager.Comprobante.ImpuestoNoGravado + manager.Comprobante.ITC + manager.Comprobante.PercepcionIIBBCapital - manager.Comprobante.Descuento;
                }
            }
            catch (Exception) { }
        }

    }
}
