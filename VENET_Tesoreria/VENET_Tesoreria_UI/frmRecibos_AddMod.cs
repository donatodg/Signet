namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmRecibos_AddMod : MultiForm, IDisposable
    {
        private RecibosManager manager;
        public List<RecibosDetalle> DetalleList = new List<RecibosDetalle>();
        public List<ChequesTerceros> DetalleListCheques = new List<ChequesTerceros>();
        public List<RecibosComprobantes> ComprobantesList = new List<RecibosComprobantes>();
        private bool load;
        private bool _EliminaCmp = false;
        private enum TipoMovimiento
        {
            Efectivo = 1,
            ChequeTercero = 2,
            TarjetaDebito = 3,
            TarjetaCredito = 4,
            CtaCte = 5,
            Percepcion = 6
        };

        public frmRecibos_AddMod(Recibos o)
        {
            InitializeComponent();
            manager = new RecibosManager(o);
        }

        public frmRecibos_AddMod(Recibos o, bool EliminaCmp)
        {
            InitializeComponent();
            manager = new RecibosManager(o);
            _EliminaCmp = EliminaCmp;
        }

        public frmRecibos_AddMod(RecibosManager o)
        {
            InitializeComponent();
            manager = o;
        }

        private void frmRecibos_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                load = true;

                tipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
                tipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
                tipoEntidadLookUpEdit.Properties.ValueMember = "Key";

                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
                id_EntidadLookUpEdit.Properties.ValueMember = "Key";

                id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
                id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
                id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

                id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
                id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
                id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

                letraTextEdit.Properties.DataSource = manager.Letra;
                letraTextEdit.Properties.DisplayMember = "Name";
                letraTextEdit.Properties.ValueMember = "Key";

                recibosManagerBindingSource.DataSource = manager;

                if (manager.Letra.Count > 0)
                    letraTextEdit.ItemIndex = 0;

                DetalleList.Clear();

                if (manager.Recibo.Detalle != null)
                {
                    foreach (RecibosDetalle o in manager.Recibo.Detalle)
                    {
                        RecibosDetalle x = new RecibosDetalle()
                        {
                            Id = o.Id,
                            Cotizacion = o.Cotizacion,
                            Detalle = o.Detalle,
                            Especie = o.Especie,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            Id_Documento = o.Id_Documento,
                            Id_Especie = o.Id_Especie,
                            Id_Recibo = o.Id_Recibo,
                            Importe = o.Importe,
                            Recibo = o.Recibo,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Id_Entidad = o.Id_Entidad,
                            Id_TipoPercepcion = o.Id_TipoPercepcion,
                            TarjetaCredito = o.TarjetaCredito,
                            TarjetaDebito = o.TarjetaDebito,    
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        if (x.Id_TipoEntidad > 0)
                            x.NombreEntidad = Sistema.GetNombreEntidad(x.Id_TipoEntidad.Value, x.Id_Entidad.Value);

                        DetalleList.Add(x);
                    }
                }

                //*********************************************
                ComprobantesList.Clear();

                if (manager.Recibo.Comprobantes != null)
                    foreach (RecibosComprobantes o in manager.Recibo.Comprobantes)
                    {
                        RecibosComprobantes x = new RecibosComprobantes()
                        {
                            Id = o.Id,
                            Id_Recibo = o.Id_Recibo,
                            Recibo = o.Recibo,
                            Id_ComprobantesVentas = o.Id_ComprobantesVentas,
                            ImporteAdeudado = o.ImporteAdeudado,
                            ImportePago = o.ImportePago,
                            Importe = o.Importe,
                            Borrado = o.Borrado,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        ComprobantesVentas cc = manager.GetComprobanteVenta(x.Id_ComprobantesVentas);
                        x.Comprobante = cc.Comprobante;
                        x.Fecha = cc.Fecha;
                        x.Importe = cc.Importe.Value;


                        ComprobantesList.Add(x);
                    }

                comprobantesBindingSource.DataSource = ComprobantesList;
                //*********************************************

                if (manager.Recibo.Detalle.Count > 0)
                    id_SucursalLookUpEdit.Enabled = false;

                detalleBindingSource.DataSource = DetalleList;

                if (manager.Recibo.Id > 0)
                    letraTextEdit.Enabled = false;

                nroComprobanteSpinEdit.Enabled = false;

                if (manager.Recibo.Fecha_Liquidacion != null)
                {
                    btnAceptar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAgregaCmp.Enabled = false;
                    btnEliminaCmp.Enabled = false;
                }

                //txtTotalRec.EditValue = manager.Recibo.Importe - (from d in ImpuestosList where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum();

                if (_EliminaCmp)
                {
                    btnAceptar.Enabled = true;
                    btnAgregaCmp.Enabled = true;
                    btnEliminaCmp.Enabled = true;

                    fechaDateEdit.Enabled = false;
                    id_SucursalLookUpEdit.Enabled = false;
                    id_CentroCostoLookUpEdit.Enabled = false;
                    tipoEntidadLookUpEdit.Enabled = false;
                    id_EntidadLookUpEdit.Enabled = false;
                    letraTextEdit.Enabled = false;
                    nroComprobanteSpinEdit.Enabled = false;
                    conceptoTextEdit.Enabled = false;
                    observacionesTextEdit.Enabled = false;
                    importeTextEdit.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }

                load = false;

                if (manager.Recibo.Id == 0 && manager.Recibo.Id_Entidad != null)
                {
                    id_EntidadLookUpEdit_EditValueChanged(null, null);
                    //importeTextEdit_EditValueChanged(null, null);
                }
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
                string IdsCheques = manager.Save();

                if (IdsCheques != "")
                    Sistema.Mensaje("Se agregaron los cheques Ids: " + IdsCheques);

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

        private void recibosManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.Exception != null && e.Exception is ValidationException)
            {
                Sistema.Mensaje(e.Exception.Message, "Atención", e.Exception);
            }
        }

        private void detalleBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError(e.Exception);
        }

        private void tipoEntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!load && manager.Recibo != null && tipoEntidadLookUpEdit.ItemIndex != -1)
            {
                manager.Recibo.TipoEntidad = (Enums.TipoEntidad)tipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.EditValue = manager.Recibo.Id_Entidad = null;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Agregar(TipoMovimiento e)
        {
            try
            {
                switch (e)
                {
                    case TipoMovimiento.Efectivo:
                        {
                            RecibosDetalle o = new RecibosDetalle();
                            o.Detalle = "Efectivo";
                            var f = new frmReciboDetalle_AddMod(o, manager.Recibo.Id_Sucursal);
                            if (f.ShowDialog(this) == DialogResult.OK)
                            {
                                manager.Recibo.Detalle.Add(o);
                                DetalleList.Add(o);

                                gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;
                            }
                            f.Dispose();
                            break;
                        }
                    case TipoMovimiento.TarjetaDebito:
                        {
                            RecibosDetalle o = new RecibosDetalle();
                            o.TarjetaDebito = true;
                            o.Detalle = "Tarjeta Débito";
                            var f = new frmReciboDetalle_AddMod(o, manager.Recibo.Id_Sucursal);
                            if (f.ShowDialog(this) == DialogResult.OK)
                            {
                                manager.Recibo.Detalle.Add(o);
                                DetalleList.Add(o);

                                gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;
                            }
                            f.Dispose();
                            break;
                        }
                    case TipoMovimiento.TarjetaCredito:
                        {
                            RecibosDetalle o = new RecibosDetalle();
                            o.TarjetaCredito = true;
                            o.Detalle = "Tarjeta Crédito";
                            var f = new frmReciboDetalle_AddMod(o, manager.Recibo.Id_Sucursal);
                            if (f.ShowDialog(this) == DialogResult.OK)
                            {
                                manager.Recibo.Detalle.Add(o);
                                DetalleList.Add(o);

                                gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;
                            }
                            f.Dispose();
                            break;
                        }
                    case TipoMovimiento.ChequeTercero:
                        {
                            RecibosDetalle o = new RecibosDetalle();
                            ChequesTerceros c = new ChequesTerceros();

                            var f = new frmChequeTerceros_AddMod(c);
                            if (f.ShowDialog(this) == DialogResult.OK)
                            {
                                o.Id_Documento = c.Id;
                                //************************
                                o.Id_Especie = c.Id_Especie;
                                o.Especie = RecibosManager.GetEspecie(c.Id_Especie);
                                o.Cotizacion = RecibosManager.GetCotizacion(c.Id_Especie);
                                //************************
                                o.Importe = c.Importe;
                                o.Detalle = "Ch." + c.NroCheque.ToString();
                                o.UserAdd = c.UserAdd;
                                o.FechaAdd = c.FechaAdd;

                                manager.Recibo.Detalle.Add(o);
                                DetalleList.Add(o);
                                DetalleListCheques.Add(c);

                                gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;
                            }
                            f.Dispose();
                            break;
                        }
                    case TipoMovimiento.CtaCte:
                        {
                            RecibosDetalle o = new RecibosDetalle() { Id_TipoEntidad = Enums.TipoEntidad.Proveedor_Financiero };
                            o.Detalle = "Cta.Cte.";
                            var f = new frmReciboDetallePF_AddMod(o, manager.Recibo.Id_Sucursal);
                            if (f.ShowDialog(this) == DialogResult.OK)
                            {
                                manager.Recibo.Detalle.Add(o);
                                DetalleList.Add(o);

                                gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;

                                o.NombreEntidad = Sistema.GetNombreEntidad(o.Id_TipoEntidad.Value, o.Id_Entidad.Value);
                            }
                            f.Dispose();
                            break;
                        }
                    case TipoMovimiento.Percepcion:
                        {
                            RecibosDetalle o = new RecibosDetalle() { };
                            o.Detalle = "Percepción";
                            var f = new frmReciboDetallePercep_AddMod(o, manager.Recibo.Id_Sucursal);
                            if (f.ShowDialog(this) == DialogResult.OK)
                            
                            {
                                manager.Recibo.Detalle.Add(o);
                                DetalleList.Add(o);

                                gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;

                                // o.NombreEntidad = Sistema.GetNombreEntidad(o.Id_TipoEntidad.Value, o.Id_Entidad.Value);
                            }
                            f.Dispose();
                            break;
                        }
                }
                detalleBindingSource_ListChanged(null, null);
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
                if (detalleBindingSource.Current == null || !btnModificar.Enabled) return;
                {
                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    RecibosDetalle o = new RecibosDetalle();

                    foreach (RecibosDetalle rd in manager.Recibo.Detalle.Where(t => t.Borrado == false))
                    {
                        if (ii == i)
                        {
                            o = rd;
                            break;
                        }
                        i++;
                    }

                    if (o.Id_Documento != null)
                    {
                        ChequesTerceros c = new ChequesTerceros() { Id = (int)o.Id_Documento };
                        var f = new frmChequeTerceros_AddMod(c);
                        if (f.ShowDialog(this) == DialogResult.OK)
                        {
                            o.Id_Documento = c.Id;
                            //************************
                            o.Id_Especie = c.Id_Especie;
                            o.Especie = RecibosManager.GetEspecie(c.Id_Especie);
                            o.Cotizacion = RecibosManager.GetCotizacion(c.Id_Especie);
                            //************************
                            o.Importe = c.Importe;
                            o.Detalle = "Ch." + c.NroCheque.ToString();
                            o.UserAdd = c.UserAdd;
                            o.FechaAdd = c.FechaAdd;

                            detalleBindingSource[detalleBindingSource.Position] = o;

                            gridView1.RefreshData();
                            gridControl1.RefreshDataSource();

                            detalleBindingSource.EndEdit();
                        }
                        f.Dispose();
                    }

                    if (o.Id_Entidad != null)
                    {
                        var f = new frmReciboDetallePF_AddMod(o, manager.Recibo.Id_Sucursal);
                        if (f.ShowDialog(this) == DialogResult.OK)
                        {
                            detalleBindingSource[detalleBindingSource.Position] = o;
                            o.NombreEntidad = Sistema.GetNombreEntidad(o.Id_TipoEntidad.Value, o.Id_Entidad.Value);

                            gridView1.RefreshData();
                            gridControl1.RefreshDataSource();

                            detalleBindingSource.EndEdit();
                        }

                        f.Dispose();
                    }

                    if (o.Id_TipoPercepcion != null)
                    {
                        var f = new frmReciboDetallePercep_AddMod(o, manager.Recibo.Id_Sucursal);
                        if (f.ShowDialog(this) == DialogResult.OK)
                        {
                            detalleBindingSource[detalleBindingSource.Position] = o;

                            gridView1.RefreshData();
                            gridControl1.RefreshDataSource();

                            detalleBindingSource.EndEdit();
                        }

                        f.Dispose();
                    }

                    if (o.Id_Documento == null  && o.Id_Entidad == null && o.Id_TipoPercepcion == null)
                    {
                        var f = new frmReciboDetalle_AddMod(o, manager.Recibo.Id_Sucursal);
                        if (f.ShowDialog(this) == DialogResult.OK)
                        {
                            detalleBindingSource[detalleBindingSource.Position] = o;

                            gridView1.RefreshData();
                            gridControl1.RefreshDataSource();

                            detalleBindingSource.EndEdit();
                        }

                        f.Dispose();
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

        private void Eliminar()
        {
            try
            {
                if (detalleBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    //if (DetalleList[detalleBindingSource.Position].Id != 0)
                    //    ReciboDetalleManager.Eliminar(new RecibosDetalle() { Id = ((RecibosDetalle)detalleBindingSource[detalleBindingSource.Position]).Id });

                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    //RecibosDetalle o = new RecibosDetalle();

                    foreach (RecibosDetalle rd in manager.Recibo.Detalle.Where(t => t.Borrado == false))
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

        private void recibosDetalleGridControl_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void lnkEntidad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tipoEntidadLookUpEdit.Text == "") return;

            switch ((Enums.TipoEntidad)tipoEntidadLookUpEdit.EditValue)
            {
                case Enums.TipoEntidad.Cliente:
                    Sistema.AbrirForm(this, "frmClientes", "VENET_Clientes_UI", "VENET_Clientes_UI", true);
                    break;

                case Enums.TipoEntidad.Personal:
                    Sistema.AbrirForm(this, "frmPersonal", "VENET_Personal_UI", "VENET_Personal_UI", true);
                    break;

                case Enums.TipoEntidad.Proveedor:
                    Sistema.AbrirForm(this, "frmProveedores", "VENET_Proveedores_UI", "VENET_Proveedores_UI", true);
                    break;

                case Enums.TipoEntidad.Proveedor_Financiero:
                    Sistema.AbrirForm(this, "frmProvFinancieros", "VENET_ProvFinancieros_UI", "VENET_ProvFinancieros_UI", true);
                    break;

                default: break;
            }
        }

        private void frmRecibos_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && DetalleListCheques.Count > 0)
            {
                foreach (ChequesTerceros o in DetalleListCheques)
                {
                    //o.FechaDel = Sistema.ObtenerFechaHora();
                    //o.UserDel = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CurrentUserId"]);
                    ChequeTercerosManager.Eliminar(o);
                }
            }
            if (manager.Recibo.Detalle.Count == 0 && manager.Recibo.Id > 0)
            {
                RecibosManager.Eliminar(new Recibos { Id = manager.Recibo.Id });
                DialogResult = DialogResult.Cancel;
            }
            if (manager != null) manager.Dispose();
        }

        private void id_SucursalLookUpEdit_TextChanged(object sender, EventArgs e)
        {
            Validate();
            letraTextEdit.Properties.DataSource = manager.Letra;

            if (manager.Letra.Count > 0)
            {
                letraTextEdit.ItemIndex = 0;
                manager.Recibo.Id_TalonariosComprobantes = Convert.ToInt32(letraTextEdit.EditValue);
            }
        }

        private void btnEfectivo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.Efectivo);
        }

        private void btnCheque_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.ChequeTercero);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar(TipoMovimiento.Efectivo);
        }

        private void id_EntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (manager.Recibo != null && tipoEntidadLookUpEdit.ItemIndex != -1 && id_EntidadLookUpEdit.ItemIndex != -1)
            {
                Validate();
                manager.Recibo.Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;
            }
        }

        private void btnCtaCte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.CtaCte);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        //private void importeTextEdit_EditValueChanged(object sender, EventArgs e)
        //{

        //}

        private void btnAgregaCmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.Recibo.Id_Entidad == null)
                {
                    Sistema.Mensaje("Debe ingresar una entidad.");
                    return;
                }

                var f = new frmRecibosComprobantes_AddMod(manager.Recibo.TipoEntidad, manager.Recibo.Id_Entidad.Value, ComprobantesList);
                if (f.ShowDialog(this) == DialogResult.OK)
                {

                    foreach (RecibosComprobantes x in f._ListaComprobantesSeleccionados)
                    {
                        RecibosComprobantes xx = new RecibosComprobantes()
                        {
                            Borrado = x.Borrado,
                            Fecha = x.Fecha,
                            FechaAdd = x.FechaAdd,
                            FechaMod = x.FechaMod,
                            Id = x.Id,
                            Id_ComprobantesVentas = x.Id_ComprobantesVentas,
                            Id_Recibo = x.Id_Recibo,
                            ImporteAdeudado = x.ImporteAdeudado,
                            Importe = x.Importe,
                            ImportePago = x.ImportePago,
                            Recibo = x.Recibo,
                            Comprobante = x.Comprobante,
                            UserAdd = x.UserAdd,
                            UserMod = x.UserMod
                        };

                        manager.Recibo.Comprobantes.Add(xx);
                        ComprobantesList.Add(xx);
                    }
                    gridControl3.RefreshDataSource();
                    id_SucursalLookUpEdit.Enabled = false;
                    id_EntidadLookUpEdit.Enabled = false;
                    tipoEntidadLookUpEdit.Enabled = false;
                }
                f.Dispose();

                detalleBindingSource_ListChanged(null, null);
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
  
        private void btnEliminaCmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (comprobantesBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    //if (ComprobantesList[comprobantesBindingSource.Position].Id != 0)
                    //    OrdenesPagoComprobantesManager.Eliminar(new OrdenesPagoComprobantes() { Id = ((OrdenesPagoComprobantes)comprobantesBindingSource[comprobantesBindingSource.Position]).Id });

                    int i = 0;
                    int ii = comprobantesBindingSource.Position;

                    //OrdenesPagoComprobantes o = new OrdenesPagoComprobantes();

                    foreach (RecibosComprobantes rd in manager.Recibo.Comprobantes.Where(t => t.Borrado == false))
                    {
                        if (ii == i)
                        {
                            //o = rd;
                            rd.Borrado = true;
                            break;
                        }
                        i++;
                    }

                    //if (ComprobantesList[comprobantesBindingSource.Position].Id == 0)
                    //o.Borrado = true;

                    ComprobantesList.Remove(ComprobantesList[comprobantesBindingSource.Position]);
                    gridView3.RefreshData();
                }

                detalleBindingSource_ListChanged(null, null);
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

        private void detalleBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                //if (!load && !_EliminaCmp && manager != null)
                if (!load && manager != null)
                {
                    Validate();

                    decimal TotalPagos = (from d in ComprobantesList where d.Borrado == false select d.ImportePago).DefaultIfEmpty(0).Sum();

                    if (TotalPagos == 0)
                        TotalPagos = (from d in DetalleList where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum();

                    importeTextEdit.EditValue = TotalPagos;
                    manager.Recibo.Importe = TotalPagos;
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnTarjetaCredito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.TarjetaCredito);
        }

        private void btnTarjetaDebito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.TarjetaDebito);
        }

        private void btnPercepcion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.Percepcion);
        }
    }
}
