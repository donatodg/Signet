namespace SitNET
{
    using DevExpress.Skins;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors.Repository;
    using System;
    using System.Configuration;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using VENET_Common;
    using VENET_DataEntity;

    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Thread thread;
        private DevExpress.XtraEditors.TileItem TileItemSelect;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if ((ConfigurationManager.AppSettings["TileConfig"]) != null)
                {
                    MemoryStream stream = new MemoryStream();
                    XDocument doc = XDocument.Parse((ConfigurationManager.AppSettings["TileConfig"]).ToString());
                    doc.Save(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    TileControlPrincipal.RestoreLayoutFromStream(stream);
                }

                //*************************************************************************************
                // Skins
                //*************************************************************************************
                RepositoryItemComboBox combo = new RepositoryItemComboBox();
                foreach (SkinContainer cnt in SkinManager.Default.Skins)
                    combo.Items.Add(cnt.SkinName);

                barEditItemTema.Edit = combo;
                barEditItemTema.EditValue = MultiForm.SkinName = ConfigurationManager.AppSettings["CurrentUserTema"];
                //*************************************************************************************

                barStaticItemEmpresa.Caption = "Empresa: " + ConfigurationManager.AppSettings["CurrentEmpresa"];
                barStaticItemUser.Caption = "Usuario: " + ConfigurationManager.AppSettings["CurrentUserName"];

                thread = new Thread(new ThreadStart(new FuncionesLog(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]), 1).GrabarLog));
                thread.Start();

                if (ConfigurationManager.AppSettings["CurrentUserBackColor"] != null)
                    TileControlPrincipal.BackColor = Color.FromArgb(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserBackColor"]));

                if (Convert.ToBoolean(ConfigurationManager.AppSettings["TileMostrarTitulos"]))
                {
                    TileControlPrincipal.ShowGroupText = true;
                    mostrarTítulosToolStripMenuItem.Visible = false;
                    ocultarTítulosToolStripMenuItem.Visible = true;
                }
                else
                {
                    TileControlPrincipal.ShowGroupText = false;
                    mostrarTítulosToolStripMenuItem.Visible = true;
                    ocultarTítulosToolStripMenuItem.Visible = false;
                }

                //Habilito todos los Tile
                foreach (DevExpress.XtraEditors.TileGroup g in TileControlPrincipal.Groups)
                    foreach (DevExpress.XtraEditors.TileItem i in g.Items)
                        i.Enabled = true;

                foreach (SeguridadUsuariosConfiguracion c in TilePrincipal.ConfiguracionUsuario())
                {
                    DevExpress.XtraEditors.TileItem t = new DevExpress.XtraEditors.TileItem();

                    switch (c.Id_Tile)
                    {
                        case 1: t = tileItemCtaCteEspecies; break;
                        case 2: t = tileItemCtaCteEntidades; break;

                        case 11: t = tileItemRecibos; break;
                        case 12: t = tileItemVales; break;
                        case 13: t = tileItemRendiciones; break;
                        case 14: t = tileItemOrdenesPagos; break;
                        case 15: t = tileItemListaPago; break;
                        case 16: t = tileItemCotizaciones; break;

                        case 21: t = tileItemChequeTercero; break;
                        case 22: t = tileItemDepostito; break;
                        case 23: t = tileItemDescuento; break;
                        case 24: t = tileItemChequesPropios; break;

                        case 31: t = tileItemComprobantesVentas; break;
                        case 32: t = tileItemComprobantesCompras; break;
                        case 33: t = tileItemProductos; break;
                        case 34: t = tileItemPedidos; break;
                        case 35: t = tileItemListasPrecios; break;

                        case 41: t = tileItemProduccion; break;
                        case 42: t = tileItemLineas; break;
                        case 43: t = tileItemVariantes; break;
                        case 44: t = tileItemTareas; break;
                        case 45: t = tileItemMedidas; break;
                        case 46: t = tileItemListaPrecios; break;

                        case 51: t = tileItemPProductos; break;
                        case 52: t = tileItemPProdDerivado; break;

                    }

                    if (c.Color1 != null) t.AppearanceItem.Normal.BackColor = Color.FromArgb(Convert.ToInt32(c.Color1));
                    if (c.Color2 != null) t.AppearanceItem.Normal.BackColor2 = Color.FromArgb(Convert.ToInt32(c.Color2));
                    if (c.ColorFuente != null) t.AppearanceItem.Normal.ForeColor = Color.FromArgb(Convert.ToInt32(c.ColorFuente));
                    if (!c.Visible) t.Visible = false;
                }

                ribbon.Minimized = Convert.ToBoolean(ConfigurationManager.AppSettings["RibbonMinimizado"]);

                //CHAT
                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Chats)))
                    btnChat.Visibility = BarItemVisibility.Never;
                else
                {
                    timerChat.Enabled = true;
                    timerChat.Start();
                }

                //ASISTENTE IA: visible si el menú está habilitado en Parámetros y el usuario tiene el permiso Sistema / AsistenteIA / Ingresar
                try
                {
                    btnAsistenteIA.Glyph = VENET_IA_UI.AsistenteIAIconos.Imagen(16);
                    btnAsistenteIA.LargeGlyph = VENET_IA_UI.AsistenteIAIconos.Imagen(32);
                    if (!VENET_IA_BL.AsistenteIASeguridad.MenuHabilitado() || !VENET_IA_BL.AsistenteIASeguridad.TienePermiso())
                        btnAsistenteIA.Visibility = BarItemVisibility.Never;
                }
                catch (Exception)
                {
                    btnAsistenteIA.Visibility = BarItemVisibility.Never;
                }

                ////GRABA TODOS LOS PARAMETROS
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.GrabaTodosLosParametros)))
                    foreach (Parametro.Param s in Enum.GetValues(typeof(Parametro.Param)))
                    {
                        Parametro.ObtenerValor(s);
                    }

                foreach (Parametros p in Parametro.ObtenerParamterosMenuPrincipalDeshabilitados())
                {
                    switch (p.Nombre)
                    {
                        case "Menu_Tesoreria_CuentaCorrienteEspecies": btnEspeciesCtaCte.Visibility = BarItemVisibility.Never; tileItemCtaCteEspecies.Visible = false; tileItemCtaCteEspecies.Enabled = false; break;
                        case "Menu_Tesoreria_CuentaCorrienteEntidades": btnEntidadesCtaCte.Visibility = BarItemVisibility.Never; tileItemCtaCteEntidades.Visible = false; tileItemCtaCteEntidades.Enabled = false; break;
                        case "Menu_Tesoreria_Recibos": btnRecibos.Visibility = BarItemVisibility.Never; tileItemRecibos.Visible = false; tileItemRecibos.Enabled = false; break;
                        case "Menu_Tesoreria_OrdenesDePago": btnOrdenesPago.Visibility = BarItemVisibility.Never; tileItemOrdenesPagos.Visible = false; tileItemOrdenesPagos.Enabled = false; break;
                        case "Menu_Tesoreria_Vales": btnVales.Visibility = BarItemVisibility.Never; tileItemVales.Visible = false; tileItemVales.Enabled = false; break;
                        case "Menu_Tesoreria_Rendiciones": btnRendiciones.Visibility = BarItemVisibility.Never; tileItemRendiciones.Visible = false; tileItemRendiciones.Enabled = false; break;
                        case "Menu_Tesoreria_ListaDePagos": btnListaPagos.Visibility = BarItemVisibility.Never; tileItemListaPago.Visible = false; tileItemListaPago.Enabled = false; break;
                        case "Menu_Tesoreria_Cotizaciones": btnCotizaciones.Visibility = BarItemVisibility.Never; tileItemCotizaciones.Visible = false; tileItemCotizaciones.Enabled = false; break;
                        case "Menu_Tesoreria_ChequesDeTerceros": btnChequeTercero.Visibility = BarItemVisibility.Never; tileItemChequeTercero.Visible = false; tileItemChequeTercero.Enabled = false; break;
                        case "Menu_Tesoreria_ChequesPropios": btnChequePropio.Visibility = BarItemVisibility.Never; tileItemChequesPropios.Visible = false; tileItemChequesPropios.Enabled = false; break;
                        case "Menu_Tesoreria_BoletasDeDepositos": btnBoletasDeposito.Visibility = BarItemVisibility.Never; tileItemDepostito.Visible = false; tileItemDepostito.Enabled = false; break;
                        case "Menu_Tesoreria_DescuentoDeCheques": btnDescuento.Visibility = BarItemVisibility.Never; tileItemDescuento.Visible = false; tileItemDescuento.Enabled = false; break;
                        case "Menu_Tesoreria_Pedidos": btnPedidos.Visibility = BarItemVisibility.Never; tileItemPedidos.Visible = false; tileItemPedidos.Enabled = false; break;
                        case "Menu_Configuracion_ProductosListasPrecios": btnListasPrecios.Visibility = BarItemVisibility.Never; tileItemListasPrecios.Visible = false; ; tileItemListasPrecios.Enabled = false; break;
                        case "Menu_Tesoreria_ComprobantesDeVentas": btnComprobantesVentas.Visibility = BarItemVisibility.Never; tileItemComprobantesVentas.Visible = false; tileItemComprobantesVentas.Enabled = false; break;
                        case "Menu_Tesoreria_ComprobantesDeCompras": btnComprobantesCompras.Visibility = BarItemVisibility.Never; tileItemComprobantesCompras.Visible = false; tileItemComprobantesCompras.Enabled = false; break;
                        case "Menu_Tesoreria_Control": btnControlGestion.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Entidades_Personal": btnPersonal.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Entidades_TiposDePersonal": btnPersonalTipos.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Entidades_JerarquiasDePersonal": btnJerarquias.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Entidades_Clientes": btnClientes.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Entidades_Proveedores": btnProveedores.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Entidades_ProveedorFinanciero": btnProvFinanciero.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Empresas": btnEmpresas.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Sucursales": btnSucursales.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_PuntosDeVentas": btnPuntosVentas.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_CentrosDeCostos": btnCentrosCostos.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Localidades": btnLocalidades.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Cajas": btnCajas.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_TiposDeComprobantes": btnTipoComprobante.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Especies": btnEspecies.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Talonarios": btnTalonarios.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_EntidadesBancarias": btnEntidades.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Firmantes": btnFirmantes.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_FormasDePagos": btnFormasPagos.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_TiposDeIva": btnTipoIva.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_AlicuotasDeIva": btnIvaAlicuotas.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_CategoriasDeProductos": btnProductosCategoria.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Categorias2DeProductos": btnCategoria2.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_UnidadDeVentaDeProductos": btnProductosUnidadVenta.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Productos": btnProductos.Visibility = BarItemVisibility.Never; tileItemProductos.Visible = false; break;
                        case "Menu_Configuracion_Vendedores": btnVendedores.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Depositos": btnDepositos.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Feriados": btnFeriados.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Parametros": btnParametros.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Usuarios": btnUsuarios.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_GrupoDeUsuarios": btnGruposUsuarios.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_CambioDeClave": btnCambioClave.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_Tema": barEditItemTema.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Configuracion_TiposImpuestos": btnTiposImpuestos.Visibility = BarItemVisibility.Never; btnIIBB.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Produccion_Produccion": btnProducción.Visibility = BarItemVisibility.Never; tileItemProduccion.Visible = false; break;
                        case "Menu_Produccion_Lineas": btnLineas.Visibility = BarItemVisibility.Never; tileItemLineas.Visible = false; break;
                        case "Menu_Produccion_Variantes": btnVariantes.Visibility = BarItemVisibility.Never; tileItemVariantes.Visible = false; break;
                        case "Menu_Produccion_Tareas": btnTareas.Visibility = BarItemVisibility.Never; tileItemTareas.Visible = false; break;
                        case "Menu_Produccion_ListaPrecios": btnListaPrecios.Visibility = BarItemVisibility.Never; tileItemListaPrecios.Visible = false; break;
                        case "Menu_Produccion_Medidas": btnMedidas.Visibility = BarItemVisibility.Never; tileItemMedidas.Visible = false; break;
                        case "Menu_Produccion_ManoObra": btnManoDeObra.Visibility = BarItemVisibility.Never; break;
                        case "Menu_Produccion_PProductos": btnPProductos.Visibility = BarItemVisibility.Never; tileItemPProductos.Visible = false; break;
                        case "Menu_Produccion_PProdDerivado": btnManoDeObra.Visibility = BarItemVisibility.Never; tileItemPProdDerivado.Visible = false; break;
                        case "Menu_Sistema_AsistenteIA": btnAsistenteIA.Visibility = BarItemVisibility.Never; break;
                    }
                }

                if (btnEspeciesCtaCte.Visibility == BarItemVisibility.Never && btnEntidadesCtaCte.Visibility == BarItemVisibility.Never)
                    rpgCuentasCorrientes.Visible = false;

                if (btnRecibos.Visibility == BarItemVisibility.Never && btnOrdenesPago.Visibility == BarItemVisibility.Never && btnVales.Visibility == BarItemVisibility.Never && btnRendiciones.Visibility == BarItemVisibility.Never && btnListaPagos.Visibility == BarItemVisibility.Never && btnCotizaciones.Visibility == BarItemVisibility.Never)
                    rpgMovimientos.Visible = false;

                if (btnChequeTercero.Visibility == BarItemVisibility.Never && btnBoletasDeposito.Visibility == BarItemVisibility.Never && btnDescuento.Visibility == BarItemVisibility.Never && btnChequePropio.Visibility == BarItemVisibility.Never)
                    rpgCheques.Visible = false;

                if (btnPedidos.Visibility == BarItemVisibility.Never && btnComprobantesVentas.Visibility == BarItemVisibility.Never && btnComprobantesVentas.Visibility == BarItemVisibility.Never)
                    rpgGestion.Visible = false;

                if (btnControlGestion.Visibility == BarItemVisibility.Never)
                    rpgControl.Visible = false;

                if (btnPersonal.Visibility == BarItemVisibility.Never && btnPersonalTipos.Visibility == BarItemVisibility.Never && btnJerarquias.Visibility == BarItemVisibility.Never)
                    rpgPersonal.Visible = false;

                if (btnClientes.Visibility == BarItemVisibility.Never)
                    rpgClientes.Visible = false;

                if (btnProveedores.Visibility == BarItemVisibility.Never)
                    rpgProveedores.Visible = false;

                if (btnProvFinanciero.Visibility == BarItemVisibility.Never)
                    rpgProvFinanciero.Visible = false;

                if (btnEmpresas.Visibility == BarItemVisibility.Never && btnSucursales.Visibility == BarItemVisibility.Never && btnPuntosVentas.Visibility == BarItemVisibility.Never && btnCentrosCostos.Visibility == BarItemVisibility.Never && btnLocalidades.Visibility == BarItemVisibility.Never && btnCajas.Visibility == BarItemVisibility.Never)
                    rpgEmpresa.Visible = false;

                if (btnTipoComprobante.Visibility == BarItemVisibility.Never && btnEspecies.Visibility == BarItemVisibility.Never && btnTalonarios.Visibility == BarItemVisibility.Never)
                    rpgComprobantes.Visible = false;

                if (btnEntidades.Visibility == BarItemVisibility.Never && btnFirmantes.Visibility == BarItemVisibility.Never && btnFormasPagos.Visibility == BarItemVisibility.Never && btnTipoIva.Visibility == BarItemVisibility.Never && btnIvaAlicuotas.Visibility == BarItemVisibility.Never && btnProductosCategoria.Visibility == BarItemVisibility.Never && btnProductosUnidadVenta.Visibility == BarItemVisibility.Never && btnProductos.Visibility == BarItemVisibility.Never && btnVendedores.Visibility == BarItemVisibility.Never && btnDepositos.Visibility == BarItemVisibility.Never && btnTiposImpuestos.Visibility == BarItemVisibility.Never && btnIIBB.Visibility == BarItemVisibility.Never)
                    rpgGestionConfig.Visible = false;

                if (btnFeriados.Visibility == BarItemVisibility.Never && btnParametros.Visibility == BarItemVisibility.Never)
                    rpgGeneral.Visible = false;

                if (btnUsuarios.Visibility == BarItemVisibility.Never && btnGruposUsuarios.Visibility == BarItemVisibility.Never && btnCambioClave.Visibility == BarItemVisibility.Never && barEditItemTema.Visibility == BarItemVisibility.Never)
                    rpgUsuarios.Visible = false;

                if (btnProducción.Visibility == BarItemVisibility.Never && btnLineas.Visibility == BarItemVisibility.Never && btnVariantes.Visibility == BarItemVisibility.Never && btnTareas.Visibility == BarItemVisibility.Never)
                    rpgPGeneral.Visible = false;

                if (btnListaPrecios.Visibility == BarItemVisibility.Never)
                    rpgPPrecios.Visible = false;

                if (btnMedidas.Visibility == BarItemVisibility.Never && btnManoDeObra.Visibility == BarItemVisibility.Never)
                    rpgPConfiguracion.Visible = false;

                if (btnPProductos.Visibility == BarItemVisibility.Never && btnProdDerivados.Visibility == BarItemVisibility.Never)
                    rpgPProductos.Visible = false;

                if (rpgCuentasCorrientes.Visible == false && rpgMovimientos.Visible == false && rpgCheques.Visible == false && rpgGestion.Visible == false && rpgControl.Visible == false)
                    rpTesoreria.Visible = false;

                if (rpgPersonal.Visible == false && rpgClientes.Visible == false && rpgProveedores.Visible == false && rpgProvFinanciero.Visible == false && rpgControl.Visible == false)
                    rpEntidades.Visible = false;

                if (rpgPGeneral.Visible == false && rpgPPrecios.Visible == false && rpgPConfiguracion.Visible == false)
                    rpProduccion.Visible = false;

                if (btnAsistenteIA.Visibility == BarItemVisibility.Never)
                    rpAsistenteIA.Visible = false;

                string vtoCert = VENET_General_BL.EmpresasManager.EmpresasVencimiento();
                if (vtoCert != "")
                    Sistema.Mensaje(vtoCert);

            }
            catch (Exception ex)
            {
                Sistema.Mensaje(ex.Message, "Inicio", ex);
                Application.Exit();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Visible = false;
                Application.DoEvents();

                Thread threadBackup;
                if (Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Genera_Backup_Al_Salir_Sistema)))
                {
                    threadBackup = new Thread(new ThreadStart(new LoginManager().Backup));
                    threadBackup.Start();
                    threadBackup.Join();
                }

                if (ConfigurationManager.AppSettings["GuardarConfiguracion"].ToString() == "1")
                {
                    TilePrincipal.ItemOculto(tileItemCtaCteEspecies.Visible, tileItemCtaCteEspecies.Id);
                    tileItemCtaCteEspecies.Visible = true;
                    TilePrincipal.ItemOculto(tileItemCtaCteEntidades.Visible, tileItemCtaCteEntidades.Id);
                    tileItemCtaCteEntidades.Visible = true;

                    TilePrincipal.ItemOculto(tileItemRecibos.Visible, tileItemRecibos.Id);
                    tileItemRecibos.Visible = true;
                    TilePrincipal.ItemOculto(tileItemOrdenesPagos.Visible, tileItemOrdenesPagos.Id);
                    tileItemOrdenesPagos.Visible = true;
                    TilePrincipal.ItemOculto(tileItemVales.Visible, tileItemVales.Id);
                    tileItemVales.Visible = true;
                    TilePrincipal.ItemOculto(tileItemRendiciones.Visible, tileItemRendiciones.Id);
                    tileItemRendiciones.Visible = true;
                    TilePrincipal.ItemOculto(tileItemListaPago.Visible, tileItemListaPago.Id);
                    tileItemListaPago.Visible = true;
                    TilePrincipal.ItemOculto(tileItemCotizaciones.Visible, tileItemCotizaciones.Id);
                    tileItemCotizaciones.Visible = true;

                    TilePrincipal.ItemOculto(tileItemChequeTercero.Visible, tileItemChequeTercero.Id);
                    tileItemChequeTercero.Visible = true;
                    TilePrincipal.ItemOculto(tileItemDepostito.Visible, tileItemDepostito.Id);
                    tileItemDepostito.Visible = true;
                    TilePrincipal.ItemOculto(tileItemDescuento.Visible, tileItemDescuento.Id);
                    tileItemDescuento.Visible = true;
                    TilePrincipal.ItemOculto(tileItemChequesPropios.Visible, tileItemChequesPropios.Id);
                    tileItemChequesPropios.Visible = true;

                    TilePrincipal.ItemOculto(tileItemPedidos.Visible, tileItemPedidos.Id);
                    tileItemPedidos.Visible = true;
                    TilePrincipal.ItemOculto(tileItemComprobantesCompras.Visible, tileItemComprobantesCompras.Id);
                    tileItemComprobantesCompras.Visible = true;
                    TilePrincipal.ItemOculto(tileItemComprobantesVentas.Visible, tileItemComprobantesVentas.Id);
                    tileItemComprobantesVentas.Visible = true;
                    TilePrincipal.ItemOculto(tileItemProductos.Visible, tileItemProductos.Id);
                    tileItemProductos.Visible = true;
                    TilePrincipal.ItemOculto(tileItemListasPrecios.Visible, tileItemListasPrecios.Id);
                    tileItemListasPrecios.Visible = true;

                    TilePrincipal.ItemOculto(tileItemProduccion.Visible, tileItemProduccion.Id);
                    tileItemProduccion.Visible = true;
                    TilePrincipal.ItemOculto(tileItemLineas.Visible, tileItemLineas.Id);
                    tileItemLineas.Visible = true;
                    TilePrincipal.ItemOculto(tileItemVariantes.Visible, tileItemVariantes.Id);
                    tileItemVariantes.Visible = true;
                    TilePrincipal.ItemOculto(tileItemTareas.Visible, tileItemTareas.Id);
                    tileItemTareas.Visible = true;
                    TilePrincipal.ItemOculto(tileItemMedidas.Visible, tileItemMedidas.Id);
                    tileItemMedidas.Visible = true;
                    TilePrincipal.ItemOculto(tileItemListaPrecios.Visible, tileItemListaPrecios.Id);
                    tileItemListaPrecios.Visible = true;

                    TilePrincipal.ItemOculto(tileItemPProductos.Visible, tileItemPProductos.Id);
                    tileItemPProductos.Visible = true;
                    TilePrincipal.ItemOculto(tileItemPProdDerivado.Visible, tileItemPProdDerivado.Id);
                    tileItemPProdDerivado.Visible = true;

                    MemoryStream ms = new MemoryStream();
                    TileControlPrincipal.SaveLayoutToStream(ms);
                    TilePrincipal.TileConfig(ms);
                }

                new FuncionesLog(Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]), 0).GrabarLog();
            }
            catch (Exception)
            {
            }
        }

        #region Menú Principal
        private void btnManual_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string Doc = Parametro.ObtenerValor(Parametro.Param.RutaManualesSistema);
                System.Diagnostics.Process.Start(Doc);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnVersiones_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBrowser f = new frmBrowser(Parametro.ObtenerValor(Parametro.Param.DocumentoVersionesSistema), VENET_Comun.Enums.ContenidoBrowser.DireccionURL, "Historial de Versiones");
            f.ShowDialog(this);
        }

        private void btnSoporte_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.Mensaje("Comunicarse por mail a " + Parametro.ObtenerValor(Parametro.Param.MailSoporteSistemas));
        }

        private void btnSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
        #endregion

        #region Tesoreria

        #region Cuentas Corrientes
        private void tileItemCtaCteEspecies_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmEspeciesCtaCte", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnEspeciesCtaCte_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmEspeciesCtaCte", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnEntidadesCtaCte_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmEntidadesCtaCte", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void tileItemCtaCteEntidades_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmEntidadesCtaCte", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }
        #endregion

        #region Movimientos
        private void btnRecibos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmRecibos", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void tileItemRecibos_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmRecibos", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void tileItemOrdenesPagos_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmOrdenesPago", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnOrdenesPago_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmOrdenesPago", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnVales_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmVales", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void tileItemVales_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmVales", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnRendiciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmRendiciones", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void tileItemRendiciones_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmRendiciones", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnListaPagos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmListaPagos", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void tileItemListaPago_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmListaPagos", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnCotizaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmCotizaciones", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void tileItemCotizaciones_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmCotizaciones", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }
        #endregion

        #region Gestion
        private void btnPedidos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPedidos", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void tileItemPedidos_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPedidos", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnComprobantesVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmComprobantesVentas", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void tileItemComprobantesVentas_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmComprobantesVentas", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void tileItemComprobantesCompras_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmComprobantesCompras", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnComprobantesCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmComprobantesCompras", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnIIBB_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPadronIIBB", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }
        #endregion

        #region Cheques
        private void btnChequeTercero_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmChequeTerceros", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void tileItemChequeTercero_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmChequeTerceros", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnBoletasDeposito_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmBoletasDepositos", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void tileItemDepostito_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmBoletasDepositos", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnDescuento_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmChequeDescuento", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void tileItemDescuento_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmChequeDescuento", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }
        private void tileItemChequesPropios_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm((Form)this, "frmChequesPropios", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false, false, false);
        }

        private void btnChequePropio_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm((Form)this, "frmChequesPropios", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false, false, false);
        }

        #endregion

        #region Control
        private void btnControlGestion_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmControlGestion", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }
        #endregion

        #endregion

        #region Entidades
        private void btnPersonal_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPersonal", "VENET_Personal_UI", "VENET_Personal_UI", false);
        }

        private void btnPersonalTipos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPersonalTipos", "VENET_Personal_UI", "VENET_Personal_UI", false);
        }

        private void btnJerarquias_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPersonalJerarquias", "VENET_Personal_UI", "VENET_Personal_UI", false);
        }

        private void btnClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmClientes", "VENET_Clientes_UI", "VENET_Clientes_UI", false);
        }

        private void btnProveedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProveedores", "VENET_Proveedores_UI", "VENET_Proveedores_UI", false);
        }

        private void btnProvFinanciero_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProvFinancieros", "VENET_ProvFinancieros_UI", "VENET_ProvFinancieros_UI", false);
        }

        #endregion

        #region Configuración
        #region Empresa
        private void btnEmpresas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmEmpresas", "VENET_General_UI", "VENET_General_UI", false);
        }

        private void btnSucursales_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmSucursales", "VENET_General_UI", "VENET_General_UI", false);
        }

        private void btnPuntosVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPuntosVentas", "VENET_General_UI", "VENET_General_UI", false);
        }

        private void btnCentrosCostos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmCentroCostos", "VENET_General_UI", "VENET_General_UI", false);
        }

        private void btnLocalidades_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmLocalidades", "VENET_General_UI", "VENET_General_UI", false);
        }

        private void btnCajas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmCajas", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }
        #endregion

        #region Comprobantes
        private void btnTipoComprobante_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmTipoComprobante", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnEspecies_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmEspecies", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnTalonarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmTalonariosComprobantes", "VENET_General_UI", "VENET_General_UI", false);
        }
        #endregion

        #region Gestión
        private void btnEntidades_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmEntidadesBancarias", "VENET_General_UI", "VENET_General_UI", false);
        }

        private void btnFirmantes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmFirmantes", "VENET_Tesoreria_UI", "VENET_Tesoreria_UI", false);
        }

        private void btnFormasPagos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmFormasPagos", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnTipoIva_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmTipoIva", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnIvaAlicuotas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmIvaAlicuota", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnProductosCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductosCategorias", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnCategoria2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductosCategorias2", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnProductosUnidadVenta_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductosUnidadVenta", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductos", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void tileItemProductos_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductos", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnListasPrecios_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductosListasPrecios", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }
        private void tileItemListasPrecios_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductosListasPrecios", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnVendedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmVendedores", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnDepositos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmDepositos", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnTiposImpuestos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmTipoImpuestos", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        #endregion

        #region General
        private void btnFeriados_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmFeriados", "VENET_General_UI", "VENET_General_UI", false);
        }

        private void btnParametros_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmParametros", "VENET_General_UI", "VENET_General_UI", false);
        }
        #endregion

        #region Usuarios

        private void btnUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmSeguridadUsuarios", "VENET_Seguridad_UI", "VENET_Seguridad_UI", false);
        }

        private void btnGruposUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmSeguridadGrupos", "VENET_Seguridad_UI", "VENET_Seguridad_UI", false);
        }

        private void btnCambioClave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmSeguridadUsuariosCambioPassword", "VENET_Seguridad_UI", "VENET_Seguridad_UI", false);
        }

        private void barEditItemTema_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                String s = ((DevExpress.XtraBars.BarEditItem)(sender)).EditValue.ToString();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = s;
                MultiForm.SkinName = s;
            }
            catch (Exception)
            {
            }
        }
        #endregion
        #endregion

        //private void btnReportes_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
        //    DevExpress.XtraReports.UI.ReportDesignTool dt = new DevExpress.XtraReports.UI.ReportDesignTool(report);

        //    if (!Seguridad.ObtenerPermiso(VENET_Comun.Enums.Modulos.General, "Diseñador de Reportes", VENET_Comun.Enums.Accion.Ingresar)) return;

        //    DevExpress.XtraReports.UserDesigner.XRDesignRibbonForm form = new DevExpress.XtraReports.UserDesigner.XRDesignRibbonForm();
        //    form.ShowDialog();
        //}

        #region TILE

        private void colorDeFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog a = new ColorDialog();

                if (a.ShowDialog() == DialogResult.OK)
                {
                    TileControlPrincipal.BackgroundImage = null;
                    TileControlPrincipal.BackColor = a.Color;
                    TilePrincipal.BackColor(a.Color.ToArgb());
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void imagenDeFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog a = new OpenFileDialog();

                if (a.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(a.FileName);
                    TileControlPrincipal.BackgroundImage = img;

                    TilePrincipal.BackImage(img);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void TileControlPrincipal_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                TileItemSelect = e.Item;

                pequeñoToolStripMenuItem.Image = null;
                medianoToolStripMenuItem.Image = null;
                largoToolStripMenuItem.Image = null;
                grandeToolStripMenuItem.Image = null;

                switch (e.Item.ItemSize)
                {
                    case DevExpress.XtraEditors.TileItemSize.Small:
                        pequeñoToolStripMenuItem.Image = global::SIGNET.Properties.Resources.apply_16x16;
                        break;
                    case DevExpress.XtraEditors.TileItemSize.Medium:
                        medianoToolStripMenuItem.Image = global::SIGNET.Properties.Resources.apply_16x16;
                        break;
                    case DevExpress.XtraEditors.TileItemSize.Wide:
                        largoToolStripMenuItem.Image = global::SIGNET.Properties.Resources.apply_16x16;
                        break;
                    case DevExpress.XtraEditors.TileItemSize.Large:
                        grandeToolStripMenuItem.Image = global::SIGNET.Properties.Resources.apply_16x16;
                        break;
                }

                ContextMenuStripTileControl.Show(PointToScreen(Cursor.Position));
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void pequeñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TileItemSelect.ItemSize = DevExpress.XtraEditors.TileItemSize.Small;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void medianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TileItemSelect.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void largoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TileItemSelect.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void grandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TileItemSelect.ItemSize = DevExpress.XtraEditors.TileItemSize.Large;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void color1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog a = new ColorDialog();
                if (a.ShowDialog() == DialogResult.OK)
                {
                    TileItemSelect.AppearanceItem.Normal.BackColor = a.Color;
                    TilePrincipal.TileColor1(a.Color.ToArgb(), TileItemSelect.Id);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void color2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog a = new ColorDialog();
                if (a.ShowDialog() == DialogResult.OK)
                {
                    TileItemSelect.AppearanceItem.Normal.BackColor2 = a.Color;
                    TilePrincipal.TileColor2(a.Color.ToArgb(), TileItemSelect.Id);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void colorFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog a = new ColorDialog();
                if (a.ShowDialog() == DialogResult.OK)
                {
                    TileItemSelect.AppearanceItem.Normal.ForeColor = a.Color;
                    TilePrincipal.ForeColor(a.Color.ToArgb(), TileItemSelect.Id);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void ribbon_MinimizedChanged(object sender, EventArgs e)
        {
            try
            {
                TilePrincipal.RibbonMinimized(((DevExpress.XtraBars.Ribbon.RibbonControl)(sender)).Minimized);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TileItemSelect.Visible = false;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void AgregarItem(object sender, EventArgs e)
        {
            try
            {
                foreach (DevExpress.XtraEditors.TileGroup g in TileControlPrincipal.Groups)
                    foreach (DevExpress.XtraEditors.TileItem i in g.Items)
                        if (i.Name == ((ToolStripItem)sender).Name)
                            i.Visible = true;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                agregarToolStripMenuItem.DropDownItems.Clear();

                foreach (DevExpress.XtraEditors.TileGroup g in TileControlPrincipal.Groups)
                    foreach (DevExpress.XtraEditors.TileItem i in g.Items)
                        if (!i.Visible && i.Enabled == true)
                        {
                            ToolStripMenuItem item = new ToolStripMenuItem();
                            item.Name = i.Name;
                            item.Text = i.Text;

                            item.Click += new EventHandler(AgregarItem);
                            agregarToolStripMenuItem.DropDownItems.Add(item);
                        }

                if (agregarToolStripMenuItem.DropDownItems.Count == 0)
                {
                    toolStripMenuItem2.Visible = false;
                    agregarToolStripMenuItem.Visible = false;
                }
                else
                {
                    toolStripMenuItem2.Visible = true;
                    agregarToolStripMenuItem.Visible = true;
                }

            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void textoGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTexto f = new frmTexto("Ingrese el Nombre", "", TileItemSelect.Group.Text);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    TileItemSelect.Group.Text = f.result;
                    TileControlPrincipal.ShowGroupText = true;
                    mostrarTítulosToolStripMenuItem.Visible = false;
                    ocultarTítulosToolStripMenuItem.Visible = true;
                    TilePrincipal.TileTitulo(true);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void mostrarTítulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TileControlPrincipal.ShowGroupText = true;
            mostrarTítulosToolStripMenuItem.Visible = false;
            ocultarTítulosToolStripMenuItem.Visible = true;
            TilePrincipal.TileTitulo(true);
        }

        private void ocultarTítulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TileControlPrincipal.ShowGroupText = false;
            mostrarTítulosToolStripMenuItem.Visible = true;
            ocultarTítulosToolStripMenuItem.Visible = false;
            TilePrincipal.TileTitulo(false);
        }


        #endregion

        #region Chat
        private void btnChat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmChats", "VENET_Chats_UI", "VENET_Chats_UI", false, true, true);
        }

        private void timerChat_Tick(object sender, EventArgs e)
        {
            if (VENET_Chats_BL.ChatsManager.PoseeChatsNuevos() > 0)
                Sistema.AbrirForm(this, "frmNotificacion", "VENET_Chats_UI", "VENET_Chats_UI", false, true, true);
        }

        private void btnAsistenteIA_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmAsistenteIA", "VENET_IA_UI", "VENET_IA_UI", false, false, true);
        }
        #endregion

        #region Contabilidad

        #region General  
        private void btnPlanDeCuentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmPlanDeCuentas", "VENET_Contabilidad_UI", "VENET_Contabilidad_UI", false);
        }

        private void btnEjerciciosContables_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmEjerciciosContables", "VENET_Contabilidad_UI", "VENET_Contabilidad_UI", false);
        }

        private void btnAsientos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmAsientos", "VENET_Contabilidad_UI", "VENET_Contabilidad_UI", false);
        }
        #endregion

        #region Configuración
        private void btnTiposAsientos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmTipoAsientos", "VENET_Contabilidad_UI", "VENET_Contabilidad_UI", false);
        }

        #endregion

        #endregion

        #region Producción
        #region General
        private void btnLineas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionLineas", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void tileItemLineas_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionLineas", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void btnVariantes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionVariantes", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void tileItemVariantes_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionVariantes", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void btnTareas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionTareas", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void tileItemTareas_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionTareas", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void tileItemProduccion_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccion", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void btnProducción_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccion", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        #endregion

        #region Lista De Precios
        private void btnListaPrecios_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionListaPrecios", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void tileItemListaPrecios_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionListaPrecios", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }
        #endregion

        #region Configuración
        private void btnMedidas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionMedidas", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void tileItemMedidas_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionMedidas", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }

        private void btnManoDeObra_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProduccionManoDeObra", "VENET_Produccion_UI", "VENET_Produccion_UI", false);
        }


        #endregion

        #region Productos
        private void btnPProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductos", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void tileItemPProductos_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductos", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void btnProdDerivados_ItemClick(object sender, ItemClickEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductosDerivados", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }

        private void tileItemPProdDerivado_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Sistema.AbrirForm(this, "frmProductosDerivados", "VENET_Gestion_UI", "VENET_Gestion_UI", false);
        }




        #endregion

        #endregion


    }
}