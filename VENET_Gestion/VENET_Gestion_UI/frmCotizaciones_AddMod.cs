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

    public partial class frmCotizaciones_AddMod : MultiForm, IDisposable
    {
        private CotizacionesManager manager;
        public List<CotizacionesDetalle> DetalleList = new List<CotizacionesDetalle>();
        private bool load;

        public frmCotizaciones_AddMod(Cotizaciones o)
        {
            InitializeComponent();
            manager = new CotizacionesManager(o);
        }

        private void frmCotizaciones_AddMod_Load(object sender, EventArgs e)
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

                //id_TalonariosComprobantesLookUpEdit.Properties.DisplayMember = "Name";
                //id_TalonariosComprobantesLookUpEdit.Properties.ValueMember = "Key";

                id_FormaPagoLookUpEdit.Properties.DataSource = Sistema.FormasPagos;
                id_FormaPagoLookUpEdit.Properties.DisplayMember = "Name";
                id_FormaPagoLookUpEdit.Properties.ValueMember = "Key";

                cotizacionesManagerBindingSource.DataSource = manager;

                id_TalonariosComprobantesLookUpEdit.Properties.DataSource = manager.Letra;
                id_TalonariosComprobantesLookUpEdit.Properties.DisplayMember = "Name";
                id_TalonariosComprobantesLookUpEdit.Properties.ValueMember = "Key";

                if (manager.Letra.Count > 0)
                {
                    id_TalonariosComprobantesLookUpEdit.ItemIndex = 0;
                    manager.Cotiza.Id_TalonariosComprobantes = Convert.ToInt32(id_TalonariosComprobantesLookUpEdit.EditValue);
                }

                DetalleList.Clear();

                if (manager.Cotiza.Detalle != null)
                {
                    foreach (CotizacionesDetalle o in manager.Cotiza.Detalle)
                    {
                        CotizacionesDetalle x = new CotizacionesDetalle()
                        {
                            Id = o.Id,
                            Cantidad = o.Cantidad,
                            Descripcion = o.Descripcion,
                            Id_AlicuotaIva = o.Id_AlicuotaIva,
                            Id_Cotizacion = o.Id_Cotizacion,
                            Id_Producto = o.Id_Producto,
                            Id_ProductoCompuesto = o.Id_ProductoCompuesto,
                            ImporteCosto = o.ImporteCosto,
                            Especie = o.Especie,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            Id_Especie = o.Id_Especie,
                            Importe = o.Importe,
                            ImporteIVA = o.ImporteIVA,
                            ImporteUnitario = o.ImporteUnitario,
                            PorcDescuento = o.PorcDescuento,
                            Cotiza = o.Cotiza,
                            AlicuotaIva = o.AlicuotaIva,
                            Cotizacion = o.Cotizacion,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod,
                            CantidadStock = o.CantidadStock,
                            Visible_Cantidad_Stock = o.Visible_Cantidad_Stock
                        };
                        DetalleList.Add(x);
                    }
                }

                if (manager.Cotiza.Fecha_Liquidacion != null)
                {
                    fechaDateEdit.Enabled = false;
                    id_SucursalLookUpEdit.Enabled = false;
                    id_EntidadLookUpEdit.Enabled = false;
                    id_TipoEntidadLookUpEdit.Enabled = false;
                    id_FormaPagoLookUpEdit.Enabled = false;
                    id_TalonariosComprobantesLookUpEdit.Enabled = false;
                    observacionesTextEdit.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnAgregar1.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAgregarEntidad.Enabled = false;
                }

                detalleBindingSource.DataSource = DetalleList;

                if (manager.Cotiza.Id > 0)
                    id_TalonariosComprobantesLookUpEdit.Enabled = false;

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
            if (!load && manager.Cotiza != null && id_TipoEntidadLookUpEdit.ItemIndex != -1)
            {
                manager.Cotiza.Id_TipoEntidad = (Enums.TipoEntidad)id_TipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.EditValue = manager.Cotiza.Id_Entidad = null;
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones_AddMod", Enums.Accion.Agregar)) return;

                //if (manager.Cotiza.Id_TalonariosComprobantes == 0)
                //{
                //    Sistema.Mensaje("No se ha cargado ningún talonario para el comprobante.");
                //    return;
                //}
                if (manager.Cotiza.Id_Entidad == null)
                {
                    Sistema.Mensaje("Debe selecciona una entidad.");
                    return;
                }

                CotizacionesDetalle o = new CotizacionesDetalle();
                ComprobantesVentasDetalle o1 = new ComprobantesVentasDetalle();

                bool UtilizaDescuento = false;

                if (manager.Cotiza.Id_TipoEntidad == Enums.TipoEntidad.Cliente)
                    UtilizaDescuento = true;

                var f = new frmComprobantesVentasDetalle_AddMod(o1, manager.Cotiza.Id_Sucursal, Convert.ToInt32(manager.Cotiza.Id_Entidad), UtilizaDescuento);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    //o.Cotiza = o1.ComprobanteVenta;
                    o.Id_Cotizacion = o1.Id_ComprobanteVenta;

                    o.AlicuotaIva = o1.AlicuotaIva;
                    o.Borrado = o1.Borrado;
                    o.Cantidad = o1.Cantidad;
                    o.Cotizacion = o1.Cotizacion;
                    o.Descripcion = o1.Descripcion;
                    o.Especie = o1.Especie;
                    o.FechaAdd = o1.FechaAdd;
                    o.FechaDel = o1.FechaDel;
                    o.FechaMod = o1.FechaMod;
                    o.Id = o1.Id;
                    o.Id_AlicuotaIva = o1.Id_AlicuotaIva;
                    o.Id_Especie = o1.Id_Especie;
                    o.Id_Producto = o1.Id_Producto;
                    o.Id_ProductoCompuesto = o1.Id_ProductoCompuesto;
                    o.Importe = o1.Importe;
                    o.ImporteCosto = o1.ImporteCosto;
                    o.ImporteIVA = o1.ImporteIVA;
                    o.ImporteUnitario = o1.ImporteUnitario;
                    o.PorcDescuento = o1.PorcDescuento;
                    o.UserAdd = o1.UserAdd;
                    o.UserDel = o1.UserDel;
                    o.UserMod = o1.UserMod;
                    o.CantidadStock = o1.CantidadStock;
                    o.Visible_Cantidad_Stock = o1.Visible_Cantidad_Stock;

                    manager.Cotiza.Detalle.Add(o);
                    DetalleList.Add(o);

                    gridControl1.RefreshDataSource();
                    //id_SucursalLookUpEdit.Enabled = false;
                    //id_EntidadLookUpEdit.Enabled = false;
                    //id_TipoEntidadLookUpEdit.Enabled = false;
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones_AddMod", Enums.Accion.Agregar)) return;

                if (manager.Cotiza.Id_Entidad == null)
                {
                    Sistema.Mensaje("Debe selecciona una entidad.");
                    return;
                }

                // ComprobantesVentasDetalle o1 = new ComprobantesVentasDetalle();

                //bool UtilizaDescuento = false;

                //if (manager.Cotiza.Id_TipoEntidad == Enums.TipoEntidad.Cliente)
                //    UtilizaDescuento = true;

                var f = new frmComprobantesVentasDetalleMultiple_Add(manager.Cotiza.Id_TipoEntidad, Convert.ToInt32(manager.Cotiza.Id_Entidad));
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (ComprobantesVentasDetalle o1 in f.Detalle.Where(t => t.Seleccionado == true))
                    {
                        CotizacionesDetalle o = new CotizacionesDetalle();
                        //o.Cotiza = o1.ComprobanteVenta;
                        o.Id_Cotizacion = o1.Id_ComprobanteVenta;

                        o.AlicuotaIva = o1.AlicuotaIva;
                        o.Borrado = o1.Borrado;
                        o.Cantidad = o1.Cantidad;
                        o.Cotizacion = o1.Cotizacion;
                        o.Descripcion = o1.Descripcion;
                        o.Especie = o1.Especie;
                        o.FechaAdd = Sistema.ObtenerFechaHora();
                        o.FechaDel = o1.FechaDel;
                        o.FechaMod = o1.FechaMod;
                        o.Id = o1.Id;
                        o.Id_AlicuotaIva = o1.Id_AlicuotaIva;
                        o.Id_Especie = o1.Id_Especie;
                        o.Id_Producto = o1.Id_Producto;
                        o.Id_ProductoCompuesto = o1.Id_ProductoCompuesto;
                        o.Importe = o1.Importe;
                        o.ImporteCosto = o1.ImporteCosto;
                        o.ImporteIVA = o1.ImporteIVA;
                        o.ImporteUnitario = o1.ImporteUnitario;
                        o.PorcDescuento = o1.PorcDescuento;
                        o.UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                        o.UserDel = o1.UserDel;
                        o.UserMod = o1.UserMod;
                        o.CantidadStock = o1.CantidadStock;
                        o.Visible_Cantidad_Stock = o1.Visible_Cantidad_Stock;

                        manager.Cotiza.Detalle.Add(o);
                        DetalleList.Add(o);

                        gridControl1.RefreshDataSource();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones_AddMod", Enums.Accion.Modificar)) return;

                if (detalleBindingSource.Current == null || !btnModificar.Enabled) return;
                {
                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    CotizacionesDetalle o = new CotizacionesDetalle();
                    ComprobantesVentasDetalle o1 = new ComprobantesVentasDetalle();

                    foreach (CotizacionesDetalle rd in manager.Cotiza.Detalle.Where(t => t.Borrado == false))
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    o1.Id_ComprobanteVenta = o.Id_Cotizacion;
                    o1.AlicuotaIva = o.AlicuotaIva;
                    o1.Borrado = o.Borrado;
                    o1.Cantidad = o.Cantidad;
                    o1.Cotizacion = o.Cotizacion;
                    o1.Descripcion = o.Descripcion;
                    o1.Especie = o.Especie;
                    o1.FechaAdd = o.FechaAdd;
                    o1.FechaDel = o.FechaDel;
                    o1.FechaMod = o.FechaMod;
                    o1.Id = o.Id;
                    o1.Id_AlicuotaIva = o.Id_AlicuotaIva;
                    o1.Id_Especie = o.Id_Especie;
                    o1.Id_Producto = o.Id_Producto;
                    o1.Id_ProductoCompuesto = o.Id_ProductoCompuesto;
                    o1.Importe = o.Importe;
                    o1.ImporteCosto = o.ImporteCosto;
                    o1.ImporteIVA = o.ImporteIVA;
                    o1.ImporteUnitario = o.ImporteUnitario;
                    o1.PorcDescuento = o.PorcDescuento;
                    o1.CantidadStock = o.CantidadStock;
                    o1.Visible_Cantidad_Stock = o.Visible_Cantidad_Stock;
                    o1.UserAdd = o.UserAdd;
                    o1.UserDel = o.UserDel;
                    o1.UserMod = o.UserMod;

                    bool UtilizaDescuento = false;

                    if (manager.Cotiza.Id_TipoEntidad == Enums.TipoEntidad.Cliente)
                        UtilizaDescuento = true;

                    var f = new frmComprobantesVentasDetalle_AddMod(o1, manager.Cotiza.Id_Sucursal, Convert.ToInt32(manager.Cotiza.Id_Entidad), UtilizaDescuento);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        //o.Cotiza = o1.ComprobanteVenta;
                        o.Id_Cotizacion = o1.Id_ComprobanteVenta;

                        o.AlicuotaIva = o1.AlicuotaIva;
                        o.Borrado = o1.Borrado;
                        o.Cantidad = o1.Cantidad;
                        o.CantidadStock = o1.CantidadStock;
                        o.Visible_Cantidad_Stock = o1.Visible_Cantidad_Stock;
                        o.Cotizacion = o1.Cotizacion;
                        o.Descripcion = o1.Descripcion;
                        o.Especie = o1.Especie;
                        o.FechaAdd = o1.FechaAdd;
                        o.FechaDel = o1.FechaDel;
                        o.FechaMod = o1.FechaMod;
                        o.Id = o1.Id;
                        o.Id_AlicuotaIva = o1.Id_AlicuotaIva;
                        o.Id_Especie = o1.Id_Especie;
                        o.Id_Producto = o1.Id_Producto;
                        o.Id_ProductoCompuesto = o1.Id_ProductoCompuesto;
                        o.Importe = o1.Importe;
                        o.ImporteCosto = o1.ImporteCosto;
                        o.ImporteIVA = o1.ImporteIVA;
                        o.ImporteUnitario = o1.ImporteUnitario;
                        o.PorcDescuento = o1.PorcDescuento;
                        o.UserAdd = o1.UserAdd;
                        o.UserDel = o1.UserDel;
                        o.UserMod = o1.UserMod;

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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Cotizaciones_AddMod", Enums.Accion.Eliminar)) return;

                if (detalleBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    //if (DetalleList[detalleBindingSource.Position].Id != 0)
                    //    ComprobantesVentasDetalleManager.Eliminar(new ComprobantesVentasDetalle() { Id = ((ComprobantesVentasDetalle)detalleBindingSource[detalleBindingSource.Position]).Id });

                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    //ComprobantesVentasDetalle o = new ComprobantesVentasDetalle();

                    foreach (CotizacionesDetalle rd in manager.Cotiza.Detalle.Where(t => t.Borrado == false))
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

        private void frmCotizaciones_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager.Cotiza.Detalle.Count == 0 && manager.Cotiza.Id > 0)
            {
                CotizacionesManager.Eliminar(new Cotizaciones { Id = manager.Cotiza.Id });
                DialogResult = DialogResult.Cancel;
            }
            if (manager != null) manager.Dispose();
        }

        private void id_SucursalLookUpEdit_TextChanged(object sender, EventArgs e)
        {
            Validate();
            if (!load)
            {
                id_TalonariosComprobantesLookUpEdit.Properties.DataSource = manager.Letra;

                if (manager.Letra.Count > 0)
                {
                    id_TalonariosComprobantesLookUpEdit.ItemIndex = 0;
                    manager.Cotiza.Id_TalonariosComprobantes = Convert.ToInt32(id_TalonariosComprobantesLookUpEdit.EditValue);
                }
            }
        }

        private void id_EntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (manager.Cotiza != null && id_TipoEntidadLookUpEdit.ItemIndex != -1 && id_EntidadLookUpEdit.ItemIndex != -1 && id_SucursalLookUpEdit.ItemIndex != -1)
            {
                Validate();
                manager.Cotiza.Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;
                manager.Cotiza.Id_Sucursal = (int)id_SucursalLookUpEdit.EditValue;

                //try
                //{
                //    id_TalonariosComprobantesLookUpEdit.Properties.DataSource = Sistema.ObtenerTalonario(manager.Cotiza.Id_Sucursal, 11, manager.Cotiza.Id_TipoEntidad, manager.Cotiza.Id_Entidad.Value);
                //    id_TalonariosComprobantesLookUpEdit.ItemIndex = 0;
                //    manager.Cotiza.Id_TalonariosComprobantes = Convert.ToInt32(id_TalonariosComprobantesLookUpEdit.EditValue);
                //}
                //catch (ValidationException ex)
                //{
                //    id_TalonariosComprobantesLookUpEdit.Properties.DataSource = null;
                //    id_TalonariosComprobantesLookUpEdit.ItemIndex = -1;
                //    Sistema.Mensaje(ex.Message);
                //}
                //catch (Exception)
                //{
                //}
            }
        }

        private void CalculaTotal()
        {
            decimal i = 0;
            foreach (CotizacionesDetalle d in manager.Cotiza.Detalle)
            {
                if (!d.Borrado)
                    i += d.Importe;//* d.Cotizacion 

                txtTotal.EditValue = i;
            }
        }

        private void id_TalonariosComprobantesLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (id_TalonariosComprobantesLookUpEdit.ItemIndex > -1)
            //    {
            //        id_DepositoLookUpEdit.EditValue = ((List<Key2NamePair>)id_TalonariosComprobantesLookUpEdit.Properties.DataSource)[id_TalonariosComprobantesLookUpEdit.ItemIndex].Key2;
            //        manager.Cotiza.Id_Deposito = Convert.ToInt32(id_DepositoLookUpEdit.EditValue);
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
                        id_EntidadLookUpEdit.EditValue = manager.Cotiza.Id_Entidad = Id;
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

        private void btnAgregarProd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnAgregarMultipleProd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AgregarMultiple();
        }

    }
}
