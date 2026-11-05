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
    using VENET_Tesoreria_BL;

    public partial class frmComprobantesVentas_AddMod : MultiForm, IDisposable
    {
        private ComprobantesVentasManager manager;
        public List<ComprobantesVentasDetalle> DetalleList = new List<ComprobantesVentasDetalle>();
        //public List<ComprobantesVentasImpuestos> ImpuestosList = new List<ComprobantesVentasImpuestos>();
        public bool UtilizaImpuestos;
        private bool load;
        private bool desdeAsistente;

        public frmComprobantesVentas_AddMod()
        {
            InitializeComponent();
            manager = new ComprobantesVentasManager(new ComprobantesVentas() { Id = Convert.ToInt32(ConfigurationManager.AppSettings["ParametroId"]) });
        }

        public frmComprobantesVentas_AddMod(ComprobantesVentas o, string NombreComprobante = "")
        {
            InitializeComponent();
            manager = new ComprobantesVentasManager(o);
            if (NombreComprobante != "") Text += " - " + NombreComprobante;
        }

        public frmComprobantesVentas_AddMod(ComprobantesVentas borrador, string nombreComprobante, bool precargado)
            : this(new ComprobantesVentas(), nombreComprobante)
        {
            if (!precargado || borrador == null || borrador.Id != 0)
                throw new ArgumentException("Se requiere una venta nueva sin guardar.", "borrador");
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ComprobantesVentas", Enums.Accion.Agregar))
                throw new ValidationException("No tiene permiso para agregar comprobantes de ventas.");
            desdeAsistente = true;
            foreach (var p in typeof(ComprobantesVentas).GetProperties().Where(p => p.CanRead && p.CanWrite
                && (p.PropertyType.IsValueType || p.PropertyType == typeof(string))
                && p.Name != "Id" && !p.Name.StartsWith("User") && p.Name != "FechaAdd" && p.Name != "FechaMod" && p.Name != "FechaDel"))
                p.SetValue(manager.Comprobante, p.GetValue(borrador));
            manager.Comprobante.Detalle = borrador.Detalle;
            manager.Comprobante.Impuestos = borrador.Impuestos;
        }

        private void frmComprobantesVentas_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                load = true;
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVentas_UtilizaDeposito)))
                {
                    id_EntidadDomicilioEntregaLookUpEdit.Visible = false;
                    id_EntidadDomicilioEntregaLabel.Visible = false;

                    id_DepositoLookUpEdit.Visible = true;
                    id_DepositoLabel.Visible = true;
                }

                if (manager.EsElectronico() && Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVentas_UtilizaColor)))
                    tpGeneral.BackColor = System.Drawing.Color.Red;
                else
                {
                    if (manager.Comprobante.Id_TipoComprobante == 116 || manager.Comprobante.Id_TipoComprobante == 117)
                        tpGeneral.BackColor = System.Drawing.Color.GreenYellow;
                }

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Ventas_UtilizaSugerencias)))
                    tabControl1.TabPages.Remove(tpSugerencias);


                //if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Impuestos_UtilizaConfiguracionPorEntidad)))
                if (ComprobantesVentasManager.UtilizaImpuesto(manager.Comprobante.Id_TipoComprobante))
                {
                    UtilizaImpuestos = true;
                    tabControl1.TabPages.Remove(tpImpuestosGeneral);
                }
                else
                {
                    UtilizaImpuestos = false;
                    tabControl1.TabPages.Remove(tpImpuestos);
                }

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

                id_VendedorLookUpEdit.Properties.DataSource = manager.Vendedores;
                id_VendedorLookUpEdit.Properties.DisplayMember = "Name";
                id_VendedorLookUpEdit.Properties.ValueMember = "Key";

                id_TalonariosComprobantesLookUpEdit.Properties.DisplayMember = "Name";
                id_TalonariosComprobantesLookUpEdit.Properties.ValueMember = "Key";

                id_FormaPagoLookUpEdit.Properties.DataSource = Sistema.FormasPagos;
                id_FormaPagoLookUpEdit.Properties.DisplayMember = "Name";
                id_FormaPagoLookUpEdit.Properties.ValueMember = "Key";

                id_DepositoLookUpEdit.Properties.DataSource = Sistema.Depositos;
                id_DepositoLookUpEdit.Properties.DisplayMember = "Name";
                id_DepositoLookUpEdit.Properties.ValueMember = "Key";

                id_EntidadDomicilioEntregaLookUpEdit.Properties.DisplayMember = "Name";
                id_EntidadDomicilioEntregaLookUpEdit.Properties.ValueMember = "Key";

                if (desdeAsistente)
                {
                    id_TalonariosComprobantesLookUpEdit.Properties.DataSource = Sistema.ObtenerTalonario(
                        manager.Comprobante.Id_Sucursal, manager.Comprobante.Id_TipoComprobante,
                        manager.Comprobante.Id_TipoEntidad, manager.Comprobante.Id_Entidad.Value);
                    id_EntidadDomicilioEntregaLookUpEdit.Properties.DataSource = manager.ClienteEntrega;
                }

                comprobantesVentasManagerBindingSource.DataSource = manager;

                DetalleList.Clear();

                if (manager.Comprobante.Detalle != null)
                {
                    foreach (ComprobantesVentasDetalle o in manager.Comprobante.Detalle)
                    {
                        ComprobantesVentasDetalle x = new ComprobantesVentasDetalle()
                        {
                            Id = o.Id,
                            Cantidad = o.Cantidad,
                            Descripcion = o.Descripcion,
                            Id_AlicuotaIva = o.Id_AlicuotaIva,
                            Id_ComprobanteVenta = o.Id_ComprobanteVenta,
                            Id_Producto = o.Id_Producto,
                            ImporteCosto = o.ImporteCosto,
                            Especie = o.Especie,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            Id_Especie = o.Id_Especie,
                            Importe = o.Importe,
                            ImporteIVA = o.ImporteIVA,
                            ImporteUnitario = o.ImporteUnitario,
                            PorcDescuento = o.PorcDescuento,
                            ComprobanteVenta = o.ComprobanteVenta,
                            CantidadStock = o.CantidadStock,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        DetalleList.Add(x);
                    }

                    ////*********************************************
                    if (UtilizaImpuestos)
                    {
                        //    ImpuestosList.Clear();

                        //    if (manager.Comprobante.Impuestos != null)
                        //        foreach (ComprobantesVentasImpuestos o in manager.Comprobante.Impuestos)
                        //        {
                        //            ComprobantesVentasImpuestos x = new ComprobantesVentasImpuestos()
                        //            {
                        //                Id = o.Id,
                        //                Alicuota = o.Alicuota,
                        //                BaseImponible = o.BaseImponible,
                        //                Impuesto = o.Impuesto,
                        //                Id_Impuesto = o.Id_Impuesto,
                        //                AplicaSobre = o.AplicaSobre,
                        //                ImporteBaseImponible = o.ImporteBaseImponible,
                        //                ImporteMinimo = o.ImporteMinimo,
                        //                Importe = o.Importe,
                        //                Id_ComprobanteVenta = o.Id_ComprobanteVenta,
                        //                Id_Provincia = o.Id_Provincia,
                        //                ComprobanteVenta = o.ComprobanteVenta,
                        //                FechaAdd = o.FechaAdd,
                        //                FechaMod = o.FechaMod,
                        //                UserAdd = o.UserAdd,
                        //                UserMod = o.UserMod
                        //            };
                        //            x.Impuesto = OrdenesPagoManager.NombreImpuesto(x.Id_Impuesto);

                        //            ImpuestosList.Add(x);
                        //        }

                        //    impuestosBindingSource.DataSource = ImpuestosList;

                        foreach (ComprobantesVentasImpuestos o in manager.Comprobante.Impuestos)
                            o.Impuesto = OrdenesPagoManager.NombreImpuesto(o.Id_Impuesto);

                        impuestosBindingSource.DataSource = manager.Comprobante.Impuestos;
                    }
                    ////*********************************************
                }

                if (manager.Comprobante.Detalle.Count > 0)
                {
                    id_SucursalLookUpEdit.Enabled = false;
                    id_EntidadLookUpEdit.Enabled = false;
                    id_TipoEntidadLookUpEdit.Enabled = false;
                }

                detalleBindingSource.DataSource = DetalleList;

                if (manager.Comprobante.Id > 0)
                    id_TalonariosComprobantesLookUpEdit.Enabled = false;

                if (manager.Comprobante.FechaLiquidacion != null)
                {
                    btnAceptar.Enabled = false;
                    btnAgregar1.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAgregarEntidad.Enabled = false;
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
                if (desdeAsistente && !Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ComprobantesVentas", Enums.Accion.Agregar))
                    throw new ValidationException("No tiene permiso para agregar comprobantes de ventas.");
                Validate();
                if (desdeAsistente)
                {
                    var fecha = Sistema.ObtenerFechaHora();
                    var usuario = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                    foreach (var renglon in manager.Comprobante.Detalle.Cast<ClaseBase>().Concat(manager.Comprobante.Impuestos)
                        .Where(r => r.Id == 0))
                    {
                        renglon.FechaAdd = fecha;
                        renglon.UserAdd = usuario;
                        renglon.FechaMod = renglon.FechaDel = null;
                        renglon.UserMod = renglon.UserDel = null;
                    }
                }
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
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

        private void DetalleGridControl_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Agregar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas_AddMod", Enums.Accion.Agregar)) return;

                if (manager.Comprobante.Id_TalonariosComprobantes == 0)
                {
                    Sistema.Mensaje("No se ha cargado ningún talonario para el comprobante.");
                    return;
                }
                if (manager.Comprobante.Id_Entidad == null)
                {
                    Sistema.Mensaje("Debe selecciona una entidad.");
                    return;
                }

                bool UtilizaPorcDescuento = false;

                if (manager.Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Cliente)
                {
                    UtilizaPorcDescuento = true;

                    if (manager.EsElectronico())
                        UtilizaPorcDescuento = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVenta_DescuentoPorClienteEnElectronico));
                }

                ComprobantesVentasDetalle o = new ComprobantesVentasDetalle();
                var f = new frmComprobantesVentasDetalle_AddMod(o, manager.Comprobante.Id_Sucursal, Convert.ToInt32(manager.Comprobante.Id_Entidad), UtilizaPorcDescuento);
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

        private void AgregarMultiple()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas_AddMod", Enums.Accion.Agregar)) return;

                if (manager.Comprobante.Id_TalonariosComprobantes == 0)
                {
                    Sistema.Mensaje("No se ha cargado ningún talonario para el comprobante.");
                    return;
                }
                if (manager.Comprobante.Id_Entidad == null)
                {
                    Sistema.Mensaje("Debe selecciona una entidad.");
                    return;
                }

                bool UtilizaPorcDescuento = false;

                if (manager.Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Cliente)
                {
                    UtilizaPorcDescuento = true;

                    if (manager.EsElectronico())
                        UtilizaPorcDescuento = Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.ComprobantesVenta_DescuentoPorClienteEnElectronico));
                }


                var f = new frmComprobantesVentasDetalleMultiple_Add(manager.Comprobante.Id_TipoEntidad, Convert.ToInt32(manager.Comprobante.Id_Entidad));
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (ComprobantesVentasDetalle o in f.Detalle.Where(t => t.Seleccionado == true))
                    {

                        ComprobantesVentasDetalle o1 = new ComprobantesVentasDetalle();
                        o1.AlicuotaIva = o.AlicuotaIva;
                        o1.Borrado = o.Borrado;
                        o1.Cantidad = o.Cantidad;
                        o1.CantidadStock = o.CantidadStock;
                        o1.ComprobanteVenta = o.ComprobanteVenta;
                        o1.Cotizacion = o.Cotizacion;
                        o1.Descripcion = o.Descripcion;
                        o1.Especie = o.Especie;
                        o1.FechaDel = o.FechaDel;
                        o1.FechaMod = o.FechaMod;
                        o1.Id = o.Id;
                        o1.Id_AlicuotaIva = o.Id_AlicuotaIva;
                        o1.Id_ComprobanteVenta = o.Id_ComprobanteVenta;
                        o1.Id_Especie = o.Id_Especie;
                        o1.Id_Producto = o.Id_Producto;
                        o1.Id_ProductoCompuesto = o.Id_ProductoCompuesto;
                        o1.Importe = o.Importe;
                        o1.ImporteCosto = o.ImporteCosto;
                        o1.ImporteIVA = o.ImporteIVA;
                        o1.ImporteUnitario = o.ImporteUnitario;
                        o1.PorcDescuento = o.PorcDescuento;
                        o1.Unidad_Stock = o.Unidad_Stock;
                        o1.Unidad_Venta = o.Unidad_Venta;
                        o1.UserMod = o.UserMod;
                        o1.UserDel = o.UserDel;
                        o1.Visible_Cantidad_Stock = o.Visible_Cantidad_Stock;
                        o1.FechaAdd = Sistema.ObtenerFechaHora();
                        o1.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        manager.Comprobante.Detalle.Add(o1);
                        DetalleList.Add(o1);
                    }

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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas_AddMod", Enums.Accion.Modificar)) return;

                if (detalleBindingSource.Current == null)//|| !Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.UtilizaProductoCompuesto)))
                    return;

                int i = 0;
                int ii = detalleBindingSource.Position;

                ComprobantesVentasDetalle o = new ComprobantesVentasDetalle();

                foreach (ComprobantesVentasDetalle rd in manager.Comprobante.Detalle.Where(t => t.Borrado == false))
                {
                    if (ii == i)
                    {
                        o = rd;
                        break;
                    }
                    i++;
                }

                bool UtilizaPorcDescuento = false;

                if (manager.EsElectronico())
                    UtilizaPorcDescuento = false;
                else if (manager.Comprobante.Id_TipoEntidad == Enums.TipoEntidad.Cliente)
                    UtilizaPorcDescuento = true;

                var f = new frmComprobantesVentasDetalle_AddMod(o, manager.Comprobante.Id_Sucursal, Convert.ToInt32(manager.Comprobante.Id_Entidad), UtilizaPorcDescuento);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentas_AddMod", Enums.Accion.Eliminar)) return;

                if (detalleBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    foreach (ComprobantesVentasDetalle rd in manager.Comprobante.Detalle.Where(t => t.Borrado == false))
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

        private void frmComprobantesVentas_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager.Comprobante.Detalle.Count == 0 && manager.Comprobante.Id > 0)
            {
                ComprobantesVentasManager.Eliminar(new ComprobantesVentas { Id = manager.Comprobante.Id });
                DialogResult = DialogResult.Cancel;
            }
            if (manager != null) manager.Dispose();
        }

        private void id_SucursalLookUpEdit_TextChanged(object sender, EventArgs e)
        {
            Validate();
        }

        private void id_EntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (manager.Comprobante != null && id_TipoEntidadLookUpEdit.ItemIndex != -1 && id_EntidadLookUpEdit.ItemIndex != -1 && id_SucursalLookUpEdit.ItemIndex != -1)
            {
                Validate();
                manager.Comprobante.Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;
                manager.Comprobante.Id_Sucursal = (int)id_SucursalLookUpEdit.EditValue;

                if (!load)
                {
                    ////*********************************************
                    if (UtilizaImpuestos)
                    {
                        //ImpuestosList.Clear();

                        manager.Comprobante.Impuestos = new List<ComprobantesVentasImpuestos>();

                        foreach (ComprobantesVentasImpuestos o in manager.EntidadesAlicuotas())
                        {
                            ComprobantesVentasImpuestos x = new ComprobantesVentasImpuestos()
                            {
                                Id = o.Id,
                                AplicaSobre = o.AplicaSobre,
                                Alicuota = o.Alicuota,
                                BaseImponible = o.BaseImponible,
                                ImporteBaseImponible = o.ImporteBaseImponible,
                                ImporteMinimo = o.ImporteMinimo,
                                Impuesto = o.Impuesto,
                                Id_Impuesto = o.Id_Impuesto,
                                Id_ComprobanteVenta = o.Id_ComprobanteVenta,
                                Provincia = o.Provincia,
                                Id_Provincia = o.Id_Provincia,
                                ComprobanteVenta = o.ComprobanteVenta,
                                FechaAdd = o.FechaAdd,
                                FechaMod = o.FechaMod,
                                UserAdd = o.UserAdd,
                                UserMod = o.UserMod
                            };
                            //ImpuestosList.Add(x);
                            manager.Comprobante.Impuestos.Add(x);
                        }

                        impuestosBindingSource.DataSource = manager.Comprobante.Impuestos;
                        //impuestosBindingSource.DataSource = ImpuestosList;
                    }
                    //*********************************************
                    //}

                    try
                    {
                        id_TalonariosComprobantesLookUpEdit.Properties.DataSource = Sistema.ObtenerTalonario(manager.Comprobante.Id_Sucursal, manager.Comprobante.Id_TipoComprobante, manager.Comprobante.Id_TipoEntidad, manager.Comprobante.Id_Entidad.Value);
                        id_TalonariosComprobantesLookUpEdit.ItemIndex = 0;
                        manager.Comprobante.Id_TalonariosComprobantes = Convert.ToInt32(id_TalonariosComprobantesLookUpEdit.EditValue);

                        int? fp = manager.FormaPagocliente;
                        if (fp > 0)
                            manager.Comprobante.Id_FormaPago = fp.Value;
                        else
                            manager.Comprobante.Id_FormaPago = 1;

                        id_EntidadDomicilioEntregaLookUpEdit.Properties.DataSource = manager.ClienteEntrega;
                    }
                    catch (ValidationException ex)
                    {
                        id_TalonariosComprobantesLookUpEdit.Properties.DataSource = null;
                        id_TalonariosComprobantesLookUpEdit.ItemIndex = -1;
                        Sistema.Mensaje(ex.Message);
                    }
                    catch (Exception ex1)
                    {
                    }
                }
            }
        }

        private void TextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!load && otrosImpuestosTextEdit.Text != "" && retencionesTextEdit.Text != "" && percepcionIvaTextEdit.Text != "" & percepcionIIBBTextEdit.Text != "")
            {
                Validate();

                manager.Comprobante.OtrosImpuestos = (decimal)otrosImpuestosTextEdit.EditValue;
                manager.Comprobante.Retenciones = (decimal)retencionesTextEdit.EditValue;
                manager.Comprobante.PercepcionIIBB = (decimal)percepcionIIBBTextEdit.EditValue;
                manager.Comprobante.PercepcionIva = (decimal)percepcionIvaTextEdit.EditValue;

                CalculaTotal();
            }
        }

        private void TextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Validate();

            manager.Comprobante.OtrosImpuestos = (decimal)otrosImpuestosTextEdit.EditValue;
            manager.Comprobante.Retenciones = (decimal)retencionesTextEdit.EditValue;
            manager.Comprobante.PercepcionIIBB = (decimal)percepcionIIBBTextEdit.EditValue;
            manager.Comprobante.PercepcionIva = (decimal)percepcionIvaTextEdit.EditValue;

            CalculaTotal();
        }

        private void CalculaTotal()
        {
            decimal TotalGravado = 0;
            decimal TotalNoGravado = 0;
            decimal TotalIva = 0;
            decimal TotalComprobante = 0;

            foreach (ComprobantesVentasDetalle d in manager.Comprobante.Detalle)
            {
                if (!d.Borrado)
                {
                    if (d.AlicuotaIva > 0)
                        TotalGravado += d.Importe - d.ImporteIVA;
                    else
                        TotalNoGravado += d.Importe;

                    TotalIva += d.ImporteIVA;
                    TotalComprobante += d.Importe;
                }
            }

            ////********************************************************************
            if (UtilizaImpuestos)
            {
                decimal ImporteImpuestoSobreBruto = 0;

                //Calcula Sobre el Bruto
                foreach (var x in manager.Comprobante.Impuestos.Where(t => t.AplicaSobre == Enums.AplicaSobre.Bruto))
                {
                    x.Importe = 0;

                    if (TotalGravado >= x.BaseImponible)
                    {
                        //esta bien /100
                        x.Importe = decimal.Round((TotalGravado * x.Alicuota / 100), 2, MidpointRounding.AwayFromZero);
                        x.ImporteBaseImponible = TotalGravado;
                    }

                    //Minimo
                    if (TotalGravado > 0 && x.Importe < x.ImporteMinimo)
                        x.Importe = x.ImporteMinimo;

                    ImporteImpuestoSobreBruto += x.Importe;
                }

                //Calcula Sobre el Bruto + Impuestos 
                foreach (var x in manager.Comprobante.Impuestos.Where(t => t.AplicaSobre == Enums.AplicaSobre.Neto))
                {
                    x.Importe = 0;

                    //Incluir TotalNoGravado??
                    if (TotalGravado + TotalNoGravado + ImporteImpuestoSobreBruto >= x.BaseImponible)
                    {
                        //esta bien /100
                        x.Importe = decimal.Round(((TotalGravado + TotalNoGravado + ImporteImpuestoSobreBruto) * x.Alicuota / 100), 2, MidpointRounding.AwayFromZero);
                        x.ImporteBaseImponible = TotalGravado + ImporteImpuestoSobreBruto;
                    }

                    //Minimo
                    if (TotalGravado > 0 && x.Importe + ImporteImpuestoSobreBruto < x.ImporteMinimo)
                        x.Importe = x.ImporteMinimo;

                }
                gridControl2.DataSource = manager.Comprobante.Impuestos;

                gridView2.RefreshData();
                gridControl2.RefreshDataSource();

                impuestosBindingSource.EndEdit();

                txtTotal.EditValue = TotalComprobante + (from d in manager.Comprobante.Impuestos where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum();
                //txtTotal.EditValue = TotalSinImpuestos + (from d in ImpuestosList where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum();
            }
            ////********************************************************************
            else
                txtTotal.EditValue = TotalComprobante + manager.Comprobante.OtrosImpuestos + manager.Comprobante.PercepcionIIBB + manager.Comprobante.PercepcionIva + manager.Comprobante.Retenciones;

            txtTotal.EditValue = decimal.Round(Convert.ToDecimal(txtTotal.EditValue), 2, MidpointRounding.AwayFromZero);
        }

        private void id_TalonariosComprobantesLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (id_TalonariosComprobantesLookUpEdit.ItemIndex > -1)
            //    {
            //        id_DepositoLookUpEdit.EditValue = ((List<Key2NamePair>)id_TalonariosComprobantesLookUpEdit.Properties.DataSource)[id_TalonariosComprobantesLookUpEdit.ItemIndex].Key2;
            //        manager.Comprobante.Id_Deposito = Convert.ToInt32(id_DepositoLookUpEdit.EditValue);
            //    }
            //}
            //catch (Exception) { }
        }

        private void btnAgregarEntidad_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationManager.AppSettings["ParametroId"] = "0";
                ConfigurationManager.AppSettings["RetornoId"] = "0";

                if (id_TipoEntidadLookUpEdit.ItemIndex != -1)
                {
                    switch ((Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue)
                    {
                        case Enums.TipoEntidad.Cliente:
                            Sistema.AbrirForm(this, "frmClientes_AddMod", "VENET_Clientes_UI", "VENET_Clientes_UI", true, false, false);
                            break;
                        case Enums.TipoEntidad.Personal:
                            throw new ValidationException("No está permitido el ingreso para este tipo de entidad.");
                        //Sistema.AbrirForm(this, "frmPersonal_AddMod", "VENET_Personal_UI", "VENET_Personal_UI", true, false, false);
                        //break;
                        case Enums.TipoEntidad.Proveedor:
                            Sistema.AbrirForm(this, "frmProveedores_AddMod", "VENET_Proveedores_UI", "VENET_Proveedores_UI", true, false, false);
                            break;
                        case Enums.TipoEntidad.Proveedor_Financiero:
                            throw new ValidationException("No está permitido el ingreso para este tipo de entidad.");
                            //Sistema.AbrirForm(this, "frmProvFinancieros_AddMod", "VENET_ProvFinancieros_UI", "VENET_ProvFinancieros_UI", true, false, false);
                            //break;
                    }

                    int Id = Convert.ToInt32(ConfigurationManager.AppSettings["RetornoId"]);
                    if (Id > 0)
                    {
                        id_TipoEntidadLookUpEdit_EditValueChanged(null, null);
                        id_EntidadLookUpEdit.EditValue = manager.Comprobante.Id_Entidad = Id;
                    }
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

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnAgregarProducto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnAgregarMultipleProd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AgregarMultiple();
        }
    }
}
