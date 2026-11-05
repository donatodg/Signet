namespace VENET_Tesoreria_UI
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;
    using System.Configuration;

    public partial class frmOrdenesPago_AddMod : MultiForm, IDisposable, IForm
    {
        private OrdenesPagoManager manager;
        public List<OrdenesPagoDetalle> DetalleList = new List<OrdenesPagoDetalle>();
        //public List<OrdenesPagoImpuestos> ImpuestosList = new List<OrdenesPagoImpuestos>();
        public List<ChequesTerceros> DetalleListCheques = new List<ChequesTerceros>();
        public List<ChequesPropios> DetalleListChequesPropios = new List<ChequesPropios>();
        public List<OrdenesPagoComprobantes> ComprobantesList = new List<OrdenesPagoComprobantes>();
        private bool load = true;
        private bool _EliminaCmp = false;

        private enum TipoMovimiento
        {
            Efectivo = 1,
            ChequeTercero = 2,
            CtaCte = 3,
            ChequePropio = 4
        };

        public frmOrdenesPago_AddMod(OrdenesPago o)
        {
            InitializeComponent();
            manager = new OrdenesPagoManager(o);
        }

        public frmOrdenesPago_AddMod(OrdenesPago o, bool EliminaCmp)
        {
            InitializeComponent();
            manager = new OrdenesPagoManager(o);
            _EliminaCmp = EliminaCmp;
        }

        public frmOrdenesPago_AddMod(OrdenesPagoManager o)
        {
            InitializeComponent();
            manager = o;
        }

        private void frmOrdenesPago_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                load = true;

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Menu_Configuracion_TiposImpuestos)))
                    tpImpuestos.PageVisible = false;

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

                ordenesPagoManagerBindingSource.DataSource = manager;

                if (manager.Letra.Count > 0)
                    letraTextEdit.ItemIndex = 0;

                DetalleList.Clear();

                if (manager.OP.Detalle != null)
                    foreach (OrdenesPagoDetalle o in manager.OP.Detalle)
                    {
                        OrdenesPagoDetalle x = new OrdenesPagoDetalle()
                        {
                            Id = o.Id,
                            Cotizacion = o.Cotizacion,
                            Detalle = o.Detalle,
                            Especie = o.Especie,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            Id_Documento = o.Id_Documento,
                            Id_TipoEntidad = o.Id_TipoEntidad,
                            Id_Entidad = o.Id_Entidad,
                            Id_Especie = o.Id_Especie,
                            Id_OrdenPago = o.Id_OrdenPago,
                            Importe = o.Importe,
                            OrdenPago = o.OrdenPago,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        if (x.Id_TipoEntidad > 0)
                            x.NombreEntidad = Sistema.GetNombreEntidad(x.Id_TipoEntidad.Value, x.Id_Entidad.Value);

                        DetalleList.Add(x);
                    }

                //*********************************************
                //ImpuestosList.Clear();

                //if (manager.OP.Impuestos != null)
                //    foreach (OrdenesPagoImpuestos o in manager.OP.Impuestos)
                //    {
                //        OrdenesPagoImpuestos x = new OrdenesPagoImpuestos()
                //        {
                //            Id = o.Id,
                //            Alicuota = o.Alicuota,
                //            BaseImponible = o.BaseImponible,
                //            //Cotizacion = o.Cotizacion,
                //            Impuesto = o.Impuesto,
                //            //Especie = o.Especie,
                //            //Id_Especie = o.Id_Especie,
                //            Id_Impuesto = o.Id_Impuesto,
                //            AplicaSobre = o.AplicaSobre,
                //            ImporteBaseImponible = o.ImporteBaseImponible,
                //            ImporteMinimo = o.ImporteMinimo,
                //            Importe = o.Importe,
                //            Id_OrdenPago = o.Id_OrdenPago,
                //            Id_Provincia = o.Id_Provincia,
                //            OrdenPago = o.OrdenPago,
                //            FechaAdd = o.FechaAdd,
                //            FechaMod = o.FechaMod,
                //            UserAdd = o.UserAdd,
                //            UserMod = o.UserMod
                //        };
                //        x.Impuesto = OrdenesPagoManager.NombreImpuesto(x.Id_Impuesto);

                //        ImpuestosList.Add(x);
                //    }

                //impuestosBindingSource.DataSource = ImpuestosList;
                foreach (OrdenesPagoImpuestos o in manager.OP.Impuestos)
                    o.Impuesto = OrdenesPagoManager.NombreImpuesto(o.Id_Impuesto);

                impuestosBindingSource.DataSource = manager.OP.Impuestos;

                //*********************************************


                //*********************************************
                ComprobantesList.Clear();

                if (manager.OP.Comprobantes != null)
                    foreach (OrdenesPagoComprobantes o in manager.OP.Comprobantes)
                    {
                        OrdenesPagoComprobantes x = new OrdenesPagoComprobantes()
                        {
                            Id = o.Id,
                            Id_OrdenPago = o.Id_OrdenPago,
                            OrdenPago = o.OrdenPago,
                            Id_ComprobantesCompras = o.Id_ComprobantesCompras,
                            ImporteAdeudado = o.ImporteAdeudado,
                            ImportePago = o.ImportePago,
                            Importe = o.Importe,
                            Borrado = o.Borrado,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        ComprobantesCompras cc = OrdenesPagoManager.GetComprobanteCompra(x.Id_ComprobantesCompras);
                        x.Comprobante = cc.Comprobante;
                        x.Fecha = cc.Fecha;
                        x.Importe = cc.Importe.Value;


                        ComprobantesList.Add(x);
                    }

                comprobantesBindingSource.DataSource = ComprobantesList;
                //*********************************************

                if (manager.OP.Detalle.Count > 0)
                {
                    id_SucursalLookUpEdit.Enabled = false;
                    id_EntidadLookUpEdit.Enabled = false;
                    tipoEntidadLookUpEdit.Enabled = false;
                }

                detalleBindingSource.DataSource = DetalleList;

                if (manager.OP.Id > 0)
                    letraTextEdit.Enabled = false;

                nroComprobanteSpinEdit.Enabled = false;

                if (manager.OP.Fecha_Liquidacion != null)
                {
                    btnAceptar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAgregaCmp.Enabled = false;
                    btnEliminaCmp.Enabled = false;
                }

                //decimal TotalPagos = (from d in DetalleList where d.Borrado == false select d.Importe).Sum();
                //decimal TotalImp = (from d in ImpuestosList where d.Borrado == false select d.Importe).Sum();

                //txtTotalOP.EditValue = TotalPagos - TotalImp;

                txtTotalOP.EditValue = manager.OP.Importe;// + (from d in manager.OP.Impuestos where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum();

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

                if (manager.OP.Id == 0 && manager.OP.Id_Entidad != null)
                {
                    id_EntidadLookUpEdit_EditValueChanged(null, null);
                    //importeTextEdit_EditValueChanged(null, null);
                    CalcularImpuestos();
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
                manager.Save();
                ConfigurationManager.AppSettings["RetornoId"] = manager.OP.Id.ToString();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar(TipoMovimiento.Efectivo);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void OPDetalleGridControl_DoubleClick(object sender, EventArgs e)
        {
            //Modificar();
        }

        private void ordenesPagoManagerBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
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
            if (!load && manager.OP != null && tipoEntidadLookUpEdit.ItemIndex != -1)
            {
                manager.OP.TipoEntidad = (Enums.TipoEntidad)tipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = manager.Entidades;
                id_EntidadLookUpEdit.EditValue = manager.OP.Id_Entidad = null;
            }
        }

        private void Agregar(TipoMovimiento e)
        {
            try
            {
                if (manager.OP.Id_Entidad == null)
                {
                    Sistema.Mensaje("Debe ingresar una entidad.");
                    return;
                }

                switch (e)
                {
                    case TipoMovimiento.Efectivo:
                        {
                            OrdenesPagoDetalle o = new OrdenesPagoDetalle();
                            var f = new frmOrdenesPagoDetalle_AddMod(o, manager.OP.Id_Sucursal);
                            if (f.ShowDialog(this) == DialogResult.OK)
                            {
                                manager.OP.Detalle.Add(o);
                                DetalleList.Add(o);

                                gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;
                                id_EntidadLookUpEdit.Enabled = false;
                                tipoEntidadLookUpEdit.Enabled = false;
                            }
                            f.Dispose();
                            break;
                        }

                    case TipoMovimiento.ChequeTercero:
                        {
                            ChequeTercerosManager.ParametrosBusquedas p = new ChequeTercerosManager.ParametrosBusquedas() { Id_Sucursal = manager.OP.Id_Sucursal, Estado = Enums.ChequesEstados.Cartera };
                            frmChequeTerceros f = new frmChequeTerceros(p, true);
                            f.Owner = this;
                            if (f.ShowDialog(this) == DialogResult.OK)
                            {
                                //OrdenesPagoDetalle o = new OrdenesPagoDetalle();
                                //ChequesTerceros c = new ChequesTerceros();

                                //o.Id_Documento = c.Id;
                                ////************************
                                //o.Id_Especie = c.Id_Especie;
                                //o.Especie = RecibosManager.GetEspecie(c.Id_Especie);
                                //o.Cotizacion = RecibosManager.GetCotizacion(c.Id_Especie);
                                ////************************
                                //o.Importe = c.Importe;
                                //o.Detalle = "Ch." + c.NroCheque.ToString();
                                //o.UserAdd = c.UserAdd;
                                //o.FechaAdd = c.FechaAdd;

                                //manager.OP.Detalle.Add(o);
                                //DetalleList.Add(o);
                                //DetalleListCheques.Add(c);

                                //gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;
                                id_EntidadLookUpEdit.Enabled = false;
                                tipoEntidadLookUpEdit.Enabled = false;
                            }
                            f.Dispose();
                            break;
                        }

                    case TipoMovimiento.CtaCte:
                        {
                            OrdenesPagoDetalle o = new OrdenesPagoDetalle() { Id_TipoEntidad = Enums.TipoEntidad.Proveedor_Financiero };
                            var f = new frmOrdenesPagoDetallePF_AddMod(o, manager.OP.Id_Sucursal);
                            if (f.ShowDialog(this) == DialogResult.OK)
                            {
                                manager.OP.Detalle.Add(o);
                                DetalleList.Add(o);

                                gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;
                                id_EntidadLookUpEdit.Enabled = false;
                                tipoEntidadLookUpEdit.Enabled = false;

                                o.NombreEntidad = Sistema.GetNombreEntidad(o.Id_TipoEntidad.Value, o.Id_Entidad.Value);
                            }
                            f.Dispose();
                            break;
                        }
                    case TipoMovimiento.ChequePropio:
                        {
                            ChequesPropios c = new ChequesPropios();
                            var f = new frmChequesPropios_AddMod(c, manager.OP.Id_Sucursal);
                            if (f.ShowDialog(this) == DialogResult.OK)
                            {
                                OrdenesPagoDetalle o = new OrdenesPagoDetalle()
                                {
                                    Id_DocumentoPropio = c.Id,
                                    Id_Especie = ChequePropiosManager.GetId_Especie(c.Id_ProvFinancierosCuenta),
                                    Especie = ChequePropiosManager.GetEspecie(c.Id_ProvFinancierosCuenta),
                                    Cotizacion = ChequePropiosManager.GetCotizacion(c.Id_ProvFinancierosCuenta),
                                    Detalle = "Ch." + c.NroCheque.ToString(),
                                    Importe = c.Importe,
                                    FechaAdd = c.FechaAdd,
                                    UserAdd = c.UserAdd
                                };

                                manager.OP.Detalle.Add(o);
                                DetalleList.Add(o);
                                DetalleListChequesPropios.Add(c);

                                gridControl1.RefreshDataSource();
                                id_SucursalLookUpEdit.Enabled = false;
                                id_EntidadLookUpEdit.Enabled = false;
                                tipoEntidadLookUpEdit.Enabled = false;
                            }
                            f.Dispose();
                            break;
                        }
                }
                comprobantesBindingSource_ListChanged(null, null);
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

                    OrdenesPagoDetalle o = new OrdenesPagoDetalle();

                    foreach (OrdenesPagoDetalle rd in manager.OP.Detalle.Where(t => t.Borrado == false))
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

                    if (o.Id_DocumentoPropio != null)
                    {
                        ChequesPropios c = new ChequesPropios() { Id = (int)o.Id_DocumentoPropio };
                        var f = new frmChequesPropios_AddMod(c);
                        if (f.ShowDialog(this) == DialogResult.OK)
                        {
                            o.Id_DocumentoPropio = c.Id;
                            o.Id_Especie = ChequePropiosManager.GetId_Especie(c.Id_ProvFinancierosCuenta);
                            o.Especie = ChequePropiosManager.GetEspecie(c.Id_ProvFinancierosCuenta);
                            o.Cotizacion = ChequePropiosManager.GetCotizacion(c.Id_ProvFinancierosCuenta);
                            o.Importe = c.Importe;
                            o.FechaAdd = c.FechaAdd;
                            o.UserAdd = c.UserAdd;
                            o.Detalle = "Ch." + c.NroCheque.ToString();

                            detalleBindingSource[detalleBindingSource.Position] = o;

                            gridView1.RefreshData();
                            gridControl1.RefreshDataSource();

                            detalleBindingSource.EndEdit();
                        }
                        f.Dispose();
                    }

                    if (o.Id_Entidad != null)
                    {
                        var f = new frmOrdenesPagoDetallePF_AddMod(o, manager.OP.Id_Sucursal);
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

                    if (o.Id_Documento == null && o.Id_DocumentoPropio == null && o.Id_Entidad == null)
                    {
                        var f = new frmOrdenesPagoDetalle_AddMod(o, manager.OP.Id_Sucursal);
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
                comprobantesBindingSource_ListChanged(null, null);
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
                    //    OrdenesPagoDetalleManager.Eliminar(new OrdenesPagoDetalle() { Id = ((OrdenesPagoDetalle)detalleBindingSource[detalleBindingSource.Position]).Id });

                    int i = 0;
                    int ii = detalleBindingSource.Position;

                    //OrdenesPagoDetalle o = new OrdenesPagoDetalle();

                    foreach (OrdenesPagoDetalle rd in manager.OP.Detalle.Where(t => t.Borrado == false))
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
                    //o.Borrado = true;

                    detalleBindingSource.RemoveAt(detalleBindingSource.Position);
                    //DetalleList.Remove(DetalleList[detalleBindingSource.Position]);
                    gridView1.RefreshData();
                }

                comprobantesBindingSource_ListChanged(null, null);
                //detalleBindingSource_ListChanged(null, null);
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

        private void frmOrdenesPago_AddMod_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && DetalleListCheques.Count > 0)
            {
                foreach (ChequesTerceros o in DetalleListCheques)
                {
                    o.FechaDel = Sistema.ObtenerFechaHora();
                    o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                }
            }

            if (DialogResult != DialogResult.OK && DetalleListChequesPropios.Count > 0)
            {
                foreach (ChequesPropios o in DetalleListChequesPropios)
                {
                    o.FechaDel = Sistema.ObtenerFechaHora();
                    o.UserDel = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]);
                }
            }

            if (manager.OP.Detalle.Count == 0 && manager.OP.Id > 0)
            {
                OrdenesPagoManager.Eliminar(new OrdenesPago { Id = manager.OP.Id });
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
                manager.OP.Id_TalonariosComprobantes = Convert.ToInt32(letraTextEdit.EditValue);
            }
        }

        private void btnChequeTercero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.ChequeTercero);
        }

        private void btnEfectivo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.Efectivo);
        }

        private void btnProvFinanciero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.CtaCte);
        }

        private void btnCtaCte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.CtaCte);
        }

        private void id_EntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (manager.OP != null && tipoEntidadLookUpEdit.ItemIndex != -1 && id_EntidadLookUpEdit.ItemIndex != -1)
            {
                Validate();
                manager.OP.Id_Entidad = (int)id_EntidadLookUpEdit.EditValue;

                if (!load)
                {
                    //*********************************************
                    //ImpuestosList.Clear();

                    manager.OP.Impuestos = new List<OrdenesPagoImpuestos>();

                    //if (manager.OP.Impuestos == null)
                    foreach (OrdenesPagoImpuestos o in manager.EntidadesAlicuotas())
                    {
                        OrdenesPagoImpuestos x = new OrdenesPagoImpuestos()
                        {
                            Id = o.Id,
                            Alicuota = o.Alicuota,
                            BaseImponible = o.BaseImponible,
                            //Cotizacion = o.Cotizacion,
                            Impuesto = o.Impuesto,
                            //Especie = o.Especie,
                            //Id_Especie = o.Id_Especie,
                            AplicaSobre = o.AplicaSobre,
                            ImporteBaseImponible = o.ImporteBaseImponible,
                            ImporteMinimo = o.ImporteMinimo,
                            Id_Impuesto = o.Id_Impuesto,
                            Id_OrdenPago = o.Id_OrdenPago,
                            Provincia = o.Provincia,
                            Id_Provincia = o.Id_Provincia,
                            OrdenPago = o.OrdenPago,
                            FechaAdd = o.FechaAdd,
                            FechaMod = o.FechaMod,
                            UserAdd = o.UserAdd,
                            UserMod = o.UserMod
                        };
                        //ImpuestosList.Add(x);
                        manager.OP.Impuestos.Add(x);
                    }

                    impuestosBindingSource.DataSource = manager.OP.Impuestos;
                    //*********************************************
                }
            }
        }

        public void IdSeleccionado(int Id)
        {
            try
            {
                OrdenesPagoDetalle o = new OrdenesPagoDetalle();
                ChequesTerceros c = new ChequesTerceros() { Id = Id };
                ChequeTercerosManager.Reload(c);

                if (DetalleListCheques.Exists(t => t.Id == Id))
                {
                    Sistema.Mensaje(string.Format("El Documento {0} ya se encuentra en el detalle.", c.NroCheque));
                    return;
                }

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

                manager.OP.Detalle.Add(o);
                DetalleList.Add(o);
                DetalleListCheques.Add(c);

                gridControl1.RefreshDataSource();
                id_SucursalLookUpEdit.Enabled = false;
                //}
                //f.Dispose();

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

        public void IdsSeleccionados(List<int> Ids)
        {
            try
            {
                foreach (int i in Ids)
                    IdSeleccionado(i);
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

        //private void detalleBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        //{
        //try
        //{
        //    if (!load)
        //    {
        //             Validate();

        //        decimal TotalPagos = (from d in DetalleList where d.Borrado == false select d.Importe).Sum();

        //        foreach (var i in ImpuestosList)
        //        {
        //            i.Importe = 0;

        //            if (manager.TotalMesAnterior >= i.BaseImponible)
        //                i.Importe = TotalPagos * i.Alicuota / 100;

        //            if (manager.TotalMesAnterior < i.BaseImponible)
        //                if (manager.TotalMesAnterior + TotalPagos > i.BaseImponible)
        //                    i.Importe = ((manager.TotalMesAnterior + TotalPagos) - i.BaseImponible) * i.Alicuota / 100;
        //        }

        //        gridControl2.DataSource = ImpuestosList;

        //        gridView2.RefreshData();
        //        gridControl2.RefreshDataSource();

        //        impuestosBindingSource.EndEdit();

        //        decimal TotalImp = (from d in ImpuestosList where d.Borrado == false select d.Importe).Sum();

        //        txtTotalOP.EditValue = TotalPagos - TotalImp;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Sistema.MensajeError(ex);
        //}
        //}

        private void btnAgregaCmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.OP.Id_Entidad == null)
                {
                    Sistema.Mensaje("Debe ingresar una entidad.");
                    return;
                }

                var f = new frmOrdenesPagoComprobantes_AddMod(manager.OP.TipoEntidad, manager.OP.Id_Entidad.Value, ComprobantesList);
                if (f.ShowDialog(this) == DialogResult.OK)
                {

                    foreach (OrdenesPagoComprobantes x in f._ListaComprobantesSeleccionados)
                    {
                        OrdenesPagoComprobantes xx = new OrdenesPagoComprobantes()
                        {
                            Borrado = x.Borrado,
                            Fecha = x.Fecha,
                            FechaAdd = x.FechaAdd,
                            FechaMod = x.FechaMod,
                            Id = x.Id,
                            Id_ComprobantesCompras = x.Id_ComprobantesCompras,
                            Id_OrdenPago = x.Id_OrdenPago,
                            ImporteAdeudado = x.ImporteAdeudado,
                            Importe = x.Importe,
                            ImportePago = x.ImportePago,
                            OrdenPago = x.OrdenPago,
                            Comprobante = x.Comprobante,
                            UserAdd = x.UserAdd,
                            UserMod = x.UserMod
                        };

                        manager.OP.Comprobantes.Add(xx);
                        ComprobantesList.Add(xx);
                    }
                    gridControl3.RefreshDataSource();
                    id_SucursalLookUpEdit.Enabled = false;
                    id_EntidadLookUpEdit.Enabled = false;
                    tipoEntidadLookUpEdit.Enabled = false;
                }
                f.Dispose();

                comprobantesBindingSource_ListChanged(null, null);
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

                    foreach (OrdenesPagoComprobantes rd in manager.OP.Comprobantes.Where(t => t.Borrado == false))
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

                comprobantesBindingSource_ListChanged(null, null);
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

        //private void importeTextEdit_EditValueChanged(object sender, EventArgs e)
        private void CalcularImpuestos()
        {
            try
            {
                if (!load)
                {
                    Validate();

                    decimal TotalPagos = 0;// (from d in ComprobantesList where d.Borrado == false select d.ImportePago).DefaultIfEmpty(0).Sum();

                    if (TotalPagos == 0)
                        TotalPagos = (from d in DetalleList where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum();

                    //importeTextEdit.EditValue = TotalPagos;

                    if (TotalPagos < 0)
                    {
                        Sistema.Mensaje("Debe ingresar un importe mayor a 0.");
                        return;
                    }

                    decimal ImporteImpuestoSobreBruto = 0;

                    //Calcula Sobre el Bruto
                    foreach (var x in manager.OP.Impuestos.Where(t => t.AplicaSobre == Enums.AplicaSobre.Bruto))
                    {
                        //x.Importe = 0;

                        if (TotalPagos >= x.BaseImponible)
                        {
                            x.Importe = decimal.Round((TotalPagos * x.Alicuota), 2, MidpointRounding.AwayFromZero);
                            x.ImporteBaseImponible = TotalPagos;
                        }

                        //Minimo
                        if (x.Importe < x.ImporteMinimo)
                            x.Importe = x.ImporteMinimo;

                        ImporteImpuestoSobreBruto += x.Importe;
                    }

                    //Calcula Sobre el Bruto + Impuestos 
                    foreach (var x in manager.OP.Impuestos.Where(t => t.AplicaSobre == Enums.AplicaSobre.Neto))
                    {
                        x.Importe = 0;

                        if (TotalPagos >= x.BaseImponible)
                        {
                            x.Importe = decimal.Round(((TotalPagos + ImporteImpuestoSobreBruto) * x.Alicuota), 2, MidpointRounding.AwayFromZero);
                            x.ImporteBaseImponible = TotalPagos + ImporteImpuestoSobreBruto;
                        }

                        //Minimo
                        if (x.Importe + ImporteImpuestoSobreBruto < x.ImporteMinimo)
                            x.Importe = x.ImporteMinimo;

                    }
                    gridControl2.DataSource = manager.OP.Impuestos;

                    gridView2.RefreshData();
                    gridControl2.RefreshDataSource();

                    impuestosBindingSource.EndEdit();

                    TotalPagos += (from d in manager.OP.Impuestos where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum();
                    txtTotalOP.EditValue = decimal.Round(TotalPagos, 2, MidpointRounding.AwayFromZero);
                    importeTextEdit.EditValue = TotalPagos;
                    manager.OP.Importe = TotalPagos;
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void comprobantesBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                //if (!load && !_EliminaCmp)
                if (!load && manager != null)
                {
                    Validate();

                    CalcularImpuestos();
                    //decimal TotalPagos = (from d in ComprobantesList where d.Borrado == false select d.ImportePago).DefaultIfEmpty(0).Sum();

                    //if (TotalPagos == 0)
                    //    TotalPagos = (from d in DetalleList where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum();

                    //importeTextEdit.EditValue = TotalPagos;


                    ////Sumo Impuestos
                    //TotalPagos += (from d in manager.OP.Impuestos where d.Borrado == false select d.Importe).DefaultIfEmpty(0).Sum();
                    //importeTextEdit.EditValue = TotalPagos;
                    //manager.OP.Importe = TotalPagos;
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnChequePropio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar(TipoMovimiento.ChequePropio);
        }
    }
}
