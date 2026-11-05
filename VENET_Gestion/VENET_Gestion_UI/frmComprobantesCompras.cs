namespace VENET_Gestion_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;
    using VENET_Tesoreria_BL;
    using VENET_Tesoreria_UI;

    public partial class frmComprobantesCompras : MultiForm
    {
        private ComprobantesComprasManager.ParametrosBusquedas par = new ComprobantesComprasManager.ParametrosBusquedas();

        public frmComprobantesCompras()
        {
            InitializeComponent();
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
            if (Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Ingresar)
                && Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Agregar))
            {
                var documentos = new DevExpress.XtraBars.BarButtonItem(barManager1, "Compra desde foto / PDF");
                documentos.ItemClick += (s, e) =>
                {
                    try { using (var formulario = new frmComprasDocumentos()) formulario.ShowDialog(this); }
                    catch (Exception ex) { Sistema.Mensaje(ex.Message); }
                };
                bar2.AddItem(documentos);
            }
        }

        private void frmComprobantesCompras_Load(object sender, EventArgs e)
        {
            id_TipoComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobanteCompras;
            id_TipoComprobanteLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoComprobanteLookUpEdit.Properties.ValueMember = "Key";

            tipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
            tipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
            tipoEntidadLookUpEdit.Properties.ValueMember = "Key";

            id_EntidadLookUpEdit.Properties.DataSource = par.Entidades;
            id_EntidadLookUpEdit.Properties.DisplayMember = "Name";
            id_EntidadLookUpEdit.Properties.ValueMember = "Key";

            id_SucursalLookUpEdit.Properties.DataSource = Sistema.Sucursales;
            id_SucursalLookUpEdit.Properties.ValueMember = "Id_Sucursal";
            id_SucursalLookUpEdit.Properties.DisplayMember = "Sucursal";

            comprobantesComprasManager_ParametrosBusquedasBindingSource.DataSource = par;

            //if (Sistema.Sucursales.Count() > 0)
            //{
            //    id_SucursalLookUpEdit.ItemIndex = 0;
            //    par.Id_Sucursal = (int)id_SucursalLookUpEdit.EditValue;
            //}

            if (Sistema.TipoComprobanteCompras.Count() > 0)
            {
                id_TipoComprobanteLookUpEdit.ItemIndex = 0;
                par.Id_TipoComprobante = (int)id_TipoComprobanteLookUpEdit.EditValue;
            }
            else
            {
                Sistema.Mensaje("No hay declarados comprobantes de Compras.");
                return;
            }

            Validate();
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnConfirmar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Confirmar();
        }

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Anular();
        }

        private void btnAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            gcBusquedaAvanzada.Visible = btnAvanzada.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void comprobantesComprasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + comprobantesComprasManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                gcBusquedaAvanzada.Visible = btnAvanzada.Checked = false;
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Buscar)) return;
                Validate();
                comprobantesComprasManager_SearchResultBindingSource.DataSource = ComprobantesComprasManager.Buscar(par);
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
            Validate();
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Agregar)) return;
            if (Convert.ToInt32(par.Id_Sucursal) == 0)
            {
                Sistema.Mensaje("Debe seleccionar una Sucursal.");
                return;
            }
            ComprobantesCompras o = new ComprobantesCompras() { Id_Sucursal = par.Id_Sucursal, Id_TipoComprobante = par.Id_TipoComprobante };
            var f = new frmComprobantesCompras_AddMod(o, id_TipoComprobanteLookUpEdit.Text);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                comprobantesComprasManager_SearchResultBindingSource.Add(ComprobantesComprasManager.Buscar(new ComprobantesComprasManager.ParametrosBusquedas() { Id = o.Id, Id_Sucursal = o.Id_Sucursal, Id_TipoComprobante = o.Id_TipoComprobante }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Modificar)) return;
                if (comprobantesComprasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ComprobantesComprasManager.SearchResult)comprobantesComprasManager_SearchResultBindingSource.Current;
                    var f = new frmComprobantesCompras_AddMod(new ComprobantesCompras() { Id = curr.Id }, id_TipoComprobanteLookUpEdit.Text);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        comprobantesComprasManager_SearchResultBindingSource[comprobantesComprasManager_SearchResultBindingSource.Position] = ComprobantesComprasManager.Buscar(new ComprobantesComprasManager.ParametrosBusquedas() { Id = curr.Id, Id_Sucursal = curr.Id_Sucursal, Id_TipoComprobante = curr.Id_TipoComprobante }).FirstOrDefault();
                        comprobantesComprasManager_SearchResultBindingSource.ResetCurrentItem();
                    }
                    f.Dispose();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Eliminar)) return;
                if (comprobantesComprasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ComprobantesComprasManager.Eliminar(new ComprobantesCompras() { Id = ((ComprobantesComprasManager.SearchResult)comprobantesComprasManager_SearchResultBindingSource.Current).Id });
                    comprobantesComprasManager_SearchResultBindingSource.RemoveCurrent();
                    comprobantesComprasManager_SearchResultBindingSource.ResetBindings(false);
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

        private void ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (string.Empty.Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
                id_EntidadLookUpEdit.EditValue = par.Id_Entidad = null;
            }
        }

        private void Confirmar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Operaciones, "Confirmar Comprobante de Compra")) return;

                if (comprobantesComprasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Confirmar el Item Seleccionado?", "Atención..."))
                {
                    var curr = (ComprobantesComprasManager.SearchResult)comprobantesComprasManager_SearchResultBindingSource.Current;
                    string r = ComprobantesComprasManager.Confirmar(new ComprobantesCompras() { Id = curr.Id });

                    if (r != "") Sistema.Mensaje(r);

                    comprobantesComprasManager_SearchResultBindingSource[comprobantesComprasManager_SearchResultBindingSource.Position] = ComprobantesComprasManager.Buscar(new ComprobantesComprasManager.ParametrosBusquedas() { Id = curr.Id, Id_Sucursal = curr.Id_Sucursal, Id_TipoComprobante = curr.Id_TipoComprobante }).FirstOrDefault();
                    comprobantesComprasManager_SearchResultBindingSource.ResetCurrentItem();

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

        private void Anular()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Operaciones, "Anular Comprobante de Compra")) return;

                if (comprobantesComprasManager_SearchResultBindingSource.Current == null) return;

                var curr = (ComprobantesComprasManager.SearchResult)comprobantesComprasManager_SearchResultBindingSource.Current;
                if (curr.FechaAnulacion != null) throw new ValidationException("El comprobante ya se encuentra anulada.");
                if (ComprobantesComprasManager.ComprobanteEnOP(curr.Id)) throw new ValidationException("El comprobante se encuentra en una Orden de Pago.");

                if (Sistema.MensajeSiNo("¿Desea Anular el Item Seleccionado?", "Atención..."))
                {
                    frmTexto f = new frmTexto("Motivo Anulación", "", "");
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        string r = ComprobantesComprasManager.Anular(new ComprobantesCompras() { Id = curr.Id }, f.result);

                        if (r != "") Sistema.Mensaje(r);

                        comprobantesComprasManager_SearchResultBindingSource[comprobantesComprasManager_SearchResultBindingSource.Position] = ComprobantesComprasManager.Buscar(new ComprobantesComprasManager.ParametrosBusquedas() { Id = curr.Id, Id_Sucursal = curr.Id_Sucursal, Id_TipoComprobante = curr.Id_TipoComprobante }).FirstOrDefault();
                        comprobantesComprasManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void tipoEntidadLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (tipoEntidadLookUpEdit.ItemIndex != -1)
            {
                par.TipoEntidad = (Enums.TipoEntidad)tipoEntidadLookUpEdit.EditValue;
                id_EntidadLookUpEdit.Properties.DataSource = par.Entidades;
                id_EntidadLookUpEdit.EditValue = par.Id_Entidad = null;
            }
            if (par.TipoEntidad == null)
                id_EntidadLookUpEdit.EditValue = par.Id_Entidad = null;
        }

        private void btnGeneraOP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Operaciones, "Generar Orden de Pago")) return;

                if (comprobantesComprasManager_SearchResultBindingSource.Current == null) return;

                var curr = (ComprobantesComprasManager.SearchResult)comprobantesComprasManager_SearchResultBindingSource.Current;

                if (!TipoComprobanteManager.GeneraDeuda(curr.Id_TipoComprobante)) throw new ValidationException("El comprobante no genera deuda y no se puede asignar una orden de pago.");

                if (curr.FechaAnulacion != null) throw new ValidationException("El comprobante se encuentra anulado.");
                if (curr.FechaLiquidacion == null) throw new ValidationException("El comprobante se encuentra pendiente.");

                decimal ImportePago = ComprobantesComprasManager.GetImportePagoComprobante(curr.Id);

                if (ImportePago >= curr.Importe) throw new ValidationException("El comprobante ya se ha abonado.");

                if (Sistema.MensajeSiNo("¿Desea Generar la Orden de Pago del Item Seleccionado?", "Atención..."))
                {
                    OrdenesPago o = new OrdenesPago()
                    {
                        Concepto = ComprobantesComprasManager.GetNombreComprobante(curr.Id_TipoComprobante) + " " + curr.Comprobante,
                        Fecha = Sistema.ObtenerFecha(),
                        Id_Entidad = curr.Id_Entidad,
                        Id_CentroCosto = curr.Id_CentroCosto,
                        Id_Sucursal = curr.Id_Sucursal,
                        TipoEntidad = curr.Id_TipoEntidad,
                        Observaciones = "-",
                        Comprobantes = new List<OrdenesPagoComprobantes>(),
                        Detalle = new List<OrdenesPagoDetalle>(),
                        Impuestos = new List<OrdenesPagoImpuestos>(),
                        Importe = curr.Importe.Value - ImportePago
                        //FechaAdd = Sistema.ObtenerFechaHora(),
                        //UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"])
                    };

                    OrdenesPagoManager opm = new OrdenesPagoManager(o);

                    OrdenesPagoComprobantes x = new OrdenesPagoComprobantes()
                    {
                        Borrado = false,
                        Fecha = curr.Fecha,
                        FechaAdd = Sistema.ObtenerFechaHora(),
                        UserAdd = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentUserId"]),

                        Id_ComprobantesCompras = curr.Id,
                        ImporteAdeudado = curr.Importe.Value - ImportePago,
                        ImportePago = curr.Importe.Value - ImportePago,
                        Comprobante = curr.Comprobante
                    };
                    opm.OP.Comprobantes.Add(x);

                    frmOrdenesPago_AddMod f = new frmOrdenesPago_AddMod(opm);
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "OrdenesPago", Enums.Accion.Operaciones, "Confirmar Ordenes de Pago")) return;

                        if (Sistema.MensajeSiNo("¿Desea confirmar la orden de pago ingresada?", "Confirmar") == true)
                        {
                            OrdenesPagoManager.Confirmar(o);
                        }
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

        private void btnReporteCompleto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Ver, "Reporte Completo")) return;

                new frmComprobantesCompras_ReporteCompleto().ShowDialog(this);
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

        private void btnVerCtaCte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Ver, "Cuenta Corriente de la Entidad")) return;

            if (comprobantesComprasManager_SearchResultBindingSource.Current == null) return;

            var curr = (ComprobantesComprasManager.SearchResult)comprobantesComprasManager_SearchResultBindingSource.Current;

            frmEntidadesCtaCte f = new frmEntidadesCtaCte(curr.Id_TipoEntidad, Convert.ToInt32(curr.Id_Entidad), true);
            f.ShowDialog(this);
        }

        private void btnIvaCompras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Ver, "Iva Compras")) return;

                new frmComprobantesCompras_IvaCompras().ShowDialog(this);
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

        private void btnModificaFecha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesCompras", Enums.Accion.Operaciones, "Modificar Fecha Comprobante")) return;

                if (comprobantesComprasManager_SearchResultBindingSource.Current == null) return;

                var curr = (ComprobantesComprasManager.SearchResult)comprobantesComprasManager_SearchResultBindingSource.Current;

                frmFecha f = new frmFecha(curr.Fecha);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    ComprobantesComprasManager.CambiarFecha(new ComprobantesCompras() { Id = curr.Id }, f.Fecha);
                    comprobantesComprasManager_SearchResultBindingSource[comprobantesComprasManager_SearchResultBindingSource.Position] = ComprobantesComprasManager.Buscar(new ComprobantesComprasManager.ParametrosBusquedas() { Id = curr.Id, Id_Sucursal = curr.Id_Sucursal, Id_TipoComprobante = curr.Id_TipoComprobante }).FirstOrDefault();
                    comprobantesComprasManager_SearchResultBindingSource.ResetCurrentItem();
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
    }
}
