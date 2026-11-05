namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    //using VENET_Gestion_UI;
    using VENET_Tesoreria_BL;

    public partial class frmEspeciesCtaCte : MultiForm
    {
        private EspeciesCtaCteManager.ParametrosBusquedas par = new EspeciesCtaCteManager.ParametrosBusquedas();

        public frmEspeciesCtaCte()
        {
            InitializeComponent();
        }

        private void frmEspeciesCtaCte_Load(object sender, EventArgs e)
        {
            try
            {
                especiesCtaCteManager_ParametrosBusquedasBindingSource.DataSource = par;

                id_CajaLookUpEdit.Properties.DataSource = Sistema.Cajas;
                id_CajaLookUpEdit.Properties.ValueMember = "Id_Caja";
                id_CajaLookUpEdit.Properties.DisplayMember = "Caja";

                Id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobante;
                Id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";
                Id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";

                if (Sistema.Cajas.Count > 0)
                {
                    id_CajaLookUpEdit.ItemIndex = 0;
                    par.Id_Caja = (int)id_CajaLookUpEdit.EditValue;
                }
                else
                {
                    Sistema.Mensaje("El usuario no posee cajas asignadas.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void barSubItemAgregar_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Buscar)) return;
                Validate();
                especiesCtaCteManager_SearchResultBindingSource.DataSource = EspeciesCtaCteManager.Buscar(par);
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

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Agregar)) return;

            EspeciesCtaCte o = new EspeciesCtaCte() { Id_Caja = (int)id_CajaLookUpEdit.EditValue };
            var f = new frmEspeciesCtaCte_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // especiesCtaCteManager_SearchResultBindingSource.Add(EspeciesCtaCteManager.Buscar(new EspeciesCtaCteManager.ParametrosBusquedas() { Id = o.Id, Id_Especie = o.Id_Especie }).FirstOrDefault());
                Buscar();
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Modificar)) return;

                if (especiesCtaCteManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EspeciesCtaCteManager.SearchResult)especiesCtaCteManager_SearchResultBindingSource.Current;

                    if (curr.InternoSistema == true || curr.Id_Comprobante > 0)
                        Sistema.Mensaje("No se puede modificar el registro debido a que el tipo de movimiento está bloqueado.");
                    else
                    {
                        var f = new frmEspeciesCtaCte_AddMod(new EspeciesCtaCte() { Id = curr.Id });
                        if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            //especiesCtaCteManager_SearchResultBindingSource[especiesCtaCteManager_SearchResultBindingSource.Position] = EspeciesCtaCteManager.Buscar(new EspeciesCtaCteManager.ParametrosBusquedas() { Id = curr.Id, Id_Especie = curr.Id_Especie }).FirstOrDefault();
                            //especiesCtaCteManager_SearchResultBindingSource.ResetCurrentItem();
                            Buscar();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Eliminar)) return;

                if (especiesCtaCteManager_SearchResultBindingSource.Current == null) return;

                var curr = (EspeciesCtaCteManager.SearchResult)especiesCtaCteManager_SearchResultBindingSource.Current;

                if (curr.InternoSistema == true || curr.Id_Comprobante > 0)
                    //if (((EspeciesCtaCteManager.SearchResult)especiesCtaCteManager_SearchResultBindingSource.Current).InternoSistema == true)
                    Sistema.Mensaje("No se puede eliminar el registro debido a que el tipo de movimiento está bloqueado.");
                else
                {
                    if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                    {
                        EspeciesCtaCteManager.Eliminar(new EspeciesCtaCte() { Id = ((EspeciesCtaCteManager.SearchResult)especiesCtaCteManager_SearchResultBindingSource.Current).Id });
                        especiesCtaCteManager_SearchResultBindingSource.RemoveCurrent();
                        especiesCtaCteManager_SearchResultBindingSource.ResetBindings(false);
                    }
                }
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

        private void especiesCtaCteManager_SearchResultBindingSource_ListChanged_1(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + especiesCtaCteManager_SearchResultBindingSource.Count.ToString();
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

        private void barSubItemAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnMovimiento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnRecibo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Agregar)) return;

                Validate();

                Recibos o = new Recibos() { Id_Sucursal = EspeciesCtaCteManager.ObtenerIdSucursal(par.Id_Caja) };
                frmRecibos_AddMod f = new frmRecibos_AddMod(o);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Recibos", Enums.Accion.Operaciones, "Confirmar Recibo")) return;

                    if (Sistema.MensajeSiNo("¿Desea confirmar el recibo ingresado?", "Confirmar") == true)
                    {
                        RecibosManager.Confirmar(o);
                        Buscar();
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

        private void btnOP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Agregar)) return;

                Validate();

                OrdenesPago o = new OrdenesPago() { Id_Sucursal = EspeciesCtaCteManager.ObtenerIdSucursal(par.Id_Caja) };
                frmOrdenesPago_AddMod f = new frmOrdenesPago_AddMod(o);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Operaciones, "Confirmar Ordenes de Pago")) return;

                    if (Sistema.MensajeSiNo("¿Desea confirmar la orden de pago ingresada?", "Confirmar") == true)
                    {
                        OrdenesPagoManager.Confirmar(o);
                        Buscar();
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

        private void btnVale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Agregar)) return;

                Vales o = new Vales() { Id_Caja = par.Id_Caja };
                frmVales_AddMod f = new frmVales_AddMod(o);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Vales", Enums.Accion.Operaciones, "Confirmar Vale")) return;

                    if (Sistema.MensajeSiNo("¿Desea confirmar el vale ingresado?", "Confirmar") == true)
                    {
                        ValesManager.Confirmar(o);
                        Buscar();
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

        private void btnDeposito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Agregar)) return;

                BoletasDepositos o = new BoletasDepositos();
                frmBoletasDepositos_AddMod f = new frmBoletasDepositos_AddMod(o);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "BoletasDepositos", Enums.Accion.Operaciones, "Confirmar Boleta de Depósito")) return;

                    if (Sistema.MensajeSiNo("¿Desea confirmar la boleta de depósito ingresada?", "Confirmar") == true)
                    {
                        BoletasDepositosManager.Confirmar(o);
                        Buscar();
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

        private void btnTransferencia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Agregar)) return;

                Transferencias o = new Transferencias() { Id_Caja_Origen = par.Id_Caja };
                frmTransferencias f = new frmTransferencias(o);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // especiesCtaCteManager_SearchResultBindingSource.Add(EspeciesCtaCteManager.Buscar(new EspeciesCtaCteManager.ParametrosBusquedas() { Id = o.Id, Id_Especie = o.Id_Especie }).FirstOrDefault());
                    Buscar();
                }
                f.Dispose();

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

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modificar();
        }

        private void btnVerComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Ver, "Ver Comprobante")) return;

                if (especiesCtaCteManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EspeciesCtaCteManager.SearchResult)especiesCtaCteManager_SearchResultBindingSource.Current;

                    if (curr.InternoSistema == true)
                        switch (curr.Id_TipoComprobante)
                        {
                            //case (int)Enums.TipoComprobante.Remitos:
                            //    break;

                            case (int)Enums.TipoComprobante.Recibos:
                                Recibos o2 = new Recibos() { Id = curr.Id_Comprobante };
                                frmRecibos_AddMod f2 = new frmRecibos_AddMod(o2);
                                f2.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.Vales:
                                Vales o3 = new Vales() { Id = curr.Id_Comprobante };
                                frmVales_AddMod f3 = new frmVales_AddMod(o3);
                                f3.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.Rendiciones:
                                Rendiciones o4 = new Rendiciones() { Id = curr.Id_Comprobante };
                                frmRendiciones_AddMod f4 = new frmRendiciones_AddMod(o4);
                                f4.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.BoletasDeposito:
                                BoletasDepositos o5 = new BoletasDepositos() { Id = curr.Id_Comprobante };
                                frmBoletasDepositos_AddMod f5 = new frmBoletasDepositos_AddMod(o5);
                                f5.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.Transferencia:
                                Transferencias o6 = new Transferencias() { Id = curr.Id_Comprobante };
                                frmTransferencias f6 = new frmTransferencias(o6);
                                f6.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.OrdenesPago:
                                OrdenesPago o7 = new OrdenesPago() { Id = curr.Id_Comprobante };
                                frmOrdenesPago_AddMod f7 = new frmOrdenesPago_AddMod(o7);
                                f7.ShowDialog();
                                break;

                            case (int)Enums.TipoComprobante.ListaPago:
                                ListaPagos o8 = new ListaPagos() { Id = curr.Id_Comprobante };
                                frmListaPagos_AddMod f8 = new frmListaPagos_AddMod(o8);
                                f8.ShowDialog();
                                break;
                        }

                    if (curr.InternoSistema == false && curr.Id_Area == Enums.ComprobanteArea.Compras && curr.Id_Comprobante > 0)
                    {
                        ConfigurationManager.AppSettings["ParametroId"] = curr.Id_Comprobante.ToString();
                        ConfigurationManager.AppSettings["RetornoId"] = "0";

                        Sistema.AbrirForm(this, "frmComprobantesCompras_AddMod", "VENET_Gestion_UI", "VENET_Gestion_UI", true, false, false);
                        //frmComprobantesCompras_AddMod f = new frmComprobantesCompras_AddMod(new ComprobantesCompras() { Id = curr.Id_Comprobante });
                        //f.ShowDialog();
                    }

                    if (curr.InternoSistema == false && curr.Id_Area == Enums.ComprobanteArea.Ventas && curr.Id_Comprobante > 0)
                    {
                        ConfigurationManager.AppSettings["ParametroId"] = curr.Id_Comprobante.ToString();
                        ConfigurationManager.AppSettings["RetornoId"] = "0";

                        Sistema.AbrirForm(this, "frmComprobantesVentas_AddMod", "VENET_Gestion_UI", "VENET_Gestion_UI", true, false, false);
                        //frmComprobantesVentas_AddMod f = new frmComprobantesVentas_AddMod(new ComprobantesVentas() { Id = curr.Id_Comprobante });
                        //f.ShowDialog();
                    }

                    if (curr.InternoSistema == false && curr.Id_Comprobante == 0)
                        Modificar();
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

        private void btnImprimeComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Ver, "Imprimir Comprobante")) return;

                if (especiesCtaCteManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EspeciesCtaCteManager.SearchResult)especiesCtaCteManager_SearchResultBindingSource.Current;

                    if (curr.InternoSistema == true)
                        switch (curr.Id_TipoComprobante)
                        {
                            //case (int)Enums.TipoComprobante.Remitos:
                            //    break;

                            case (int)Enums.TipoComprobante.Recibos:
                                new frmRecibos().Imprime(curr.Id_Comprobante);
                                break;

                            case (int)Enums.TipoComprobante.Vales:
                                new frmVales().Imprime(curr.Id_Comprobante);
                                break;

                            case (int)Enums.TipoComprobante.Rendiciones:
                                new frmRendiciones().Imprime(curr.Id_Comprobante);
                                break;

                            case (int)Enums.TipoComprobante.BoletasDeposito:
                                break;

                            case (int)Enums.TipoComprobante.Transferencia:
                                break;

                            case (int)Enums.TipoComprobante.OrdenesPago:
                                new frmOrdenesPago().Imprime(curr.Id_Comprobante);
                                break;

                            case (int)Enums.TipoComprobante.ListaPago:
                                new frmListaPagos().Imprime(curr.Id_Comprobante);
                                break;
                        }

                    if (curr.InternoSistema == false && curr.Id_Area == Enums.ComprobanteArea.Ventas && curr.Id_Comprobante > 0)
                    {
                        //new frmComprobantesVentas().Imprime(curr.Id_Comprobante, false, false);
                        new frmEntidadesCtaCte().ImprimeComprobanteVentas(curr.Id_Comprobante, false, false);
                    }

                    //else
                    //{
                    //hacer impresion genérica;
                    //}
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

        private void btnReporteSaldos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "EspeciesCtaCte", Enums.Accion.Ver, "Ver Reporte de Saldos de Cta Cte")) return;

                frmEspeciesCtaCteSaldos f = new frmEspeciesCtaCteSaldos();
                f.ShowDialog(this);
                f.Dispose();

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

    }
}
