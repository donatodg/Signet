namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmTipoComprobante : MultiForm
    {
        private TipoComprobanteManager.ParametrosBusquedas par = new TipoComprobanteManager.ParametrosBusquedas();

        public frmTipoComprobante()
        {
            InitializeComponent();
        }

        private void frmTipoMovimientos_Load(object sender, EventArgs e)
        {
            tipoComprobantesManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "TipoComprobante", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "TipoComprobante", Enums.Accion.Buscar)) return;
                Validate();
                tipoComprobanteManager_SearchResultBindingSource.DataSource = TipoComprobanteManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "TipoComprobante", Enums.Accion.Agregar)) return;

            TipoComprobante o = new TipoComprobante();
            var f = new frmTipoComprobante_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                tipoComprobanteManager_SearchResultBindingSource.Add(TipoComprobanteManager.Buscar(new TipoComprobanteManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "TipoComprobante", Enums.Accion.Modificar)) return;

                if (tipoComprobanteManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (TipoComprobanteManager.SearchResult)tipoComprobanteManager_SearchResultBindingSource.Current;

                    if (curr.InternoSistema)
                    {
                        Sistema.Mensaje("El tipo de comprobante es interno y no puede modificarse.");
                        return;
                    }

                    var f = new frmTipoComprobante_AddMod(new TipoComprobante() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        tipoComprobanteManager_SearchResultBindingSource[tipoComprobanteManager_SearchResultBindingSource.Position] = TipoComprobanteManager.Buscar(new TipoComprobanteManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        tipoComprobanteManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "TipoComprobante", Enums.Accion.Eliminar)) return;

                if (tipoComprobanteManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    TipoComprobanteManager.Eliminar(new TipoComprobante() { Id = ((TipoComprobanteManager.SearchResult)tipoComprobanteManager_SearchResultBindingSource.Current).Id });
                    tipoComprobanteManager_SearchResultBindingSource.RemoveCurrent();
                    tipoComprobanteManager_SearchResultBindingSource.ResetBindings(false);
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void tipoComprobanteManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + tipoComprobanteManager_SearchResultBindingSource.Count.ToString();
        }

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modificar();
        }

    }
}
