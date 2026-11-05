namespace VENET_ProvFinancieros_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_ProvFinancieros_BL;

    public partial class frmProvFinancieros : MultiForm
    {
        private ProvFinancierosManager.ParametrosBusquedas par = new ProvFinancierosManager.ParametrosBusquedas();

        public frmProvFinancieros()
        {
            InitializeComponent();
        }

        private void frmProvFinancieros_Load(object sender, EventArgs e)
        {
            ProvFinancierosManager_ParametrosBusquedasBindingSource.DataSource = par;

            if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Menu_Configuracion_TiposImpuestos)))
                btnImpuestos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieros", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            IForm formInterface = Owner as IForm;

            if (formInterface != null)
            {
                formInterface.IdSeleccionado(((ProvFinancierosManager.SearchResult)ProvFinancierosManager_SearchResultBindingSource.Current).Id);
                Close();
            }
            else Modificar();
        }

        private void ProvFinancierosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de registros: " + ProvFinancierosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieros", Enums.Accion.Buscar)) return;
                Validate();
                ProvFinancierosManager_SearchResultBindingSource.DataSource = ProvFinancierosManager.Buscar(par);
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
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieros", Enums.Accion.Agregar)) return;
                {
                    var o = new ProvFinancieros();
                    var frm = new frmProvFinancieros_AddMod(o);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        ProvFinancierosManager_SearchResultBindingSource.Add(ProvFinancierosManager.Buscar(new ProvFinancierosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
                    }
                    frm.Dispose();
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

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieros", Enums.Accion.Modificar)) return;

                if (ProvFinancierosManager_SearchResultBindingSource.Current == null) return;

                var curr = (ProvFinancierosManager.SearchResult)ProvFinancierosManager_SearchResultBindingSource.Current;
                var frm = new frmProvFinancieros_AddMod(new ProvFinancieros() { Id = curr.Id });
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ProvFinancierosManager_SearchResultBindingSource[ProvFinancierosManager_SearchResultBindingSource.Position] = ProvFinancierosManager.Buscar(new ProvFinancierosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    ProvFinancierosManager_SearchResultBindingSource.ResetCurrentItem();
                }
                frm.Dispose();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieros", Enums.Accion.Eliminar)) return;

                if (ProvFinancierosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProvFinancierosManager.Eliminar(new ProvFinancieros() { Id = ((ProvFinancierosManager.SearchResult)ProvFinancierosManager_SearchResultBindingSource.Current).Id });
                    ProvFinancierosManager_SearchResultBindingSource.RemoveCurrent();
                    ProvFinancierosManager_SearchResultBindingSource.ResetBindings(false);
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
            if (e.Value != null && e.Value.Equals(string.Empty))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void btnCuentas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieros", Enums.Accion.Ver, "Ver Cuentas")) return;

                if (ProvFinancierosManager_SearchResultBindingSource.Current == null) return;

                frmProvFinancierosCuentas f = new frmProvFinancierosCuentas(((ProvFinancierosManager.SearchResult)ProvFinancierosManager_SearchResultBindingSource.Current).Id);
                f.ShowDialog();
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

        private void btnEmpresasAsignadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieros", Enums.Accion.Ver, "Ver Empresas Asignadas")) return;

                if (ProvFinancierosManager_SearchResultBindingSource.Current == null) return;

                var frm = new VENET_Gestion_UI.frmEntidadesEmpresas(Enums.TipoEntidad.Proveedor_Financiero, ((ProvFinancierosManager.SearchResult)ProvFinancierosManager_SearchResultBindingSource.Current).Id);
                frm.ShowDialog(this);
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

        private void btnImpuestos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieros", Enums.Accion.Ver, "Ver Impuestos Asignadas")) return;

                if (ProvFinancierosManager_SearchResultBindingSource.Current == null) return;

                var frm = new VENET_Gestion_UI.frmEntidadesImpuestosAlicuotas(new EntidadesImpuestoAlicuotas() { Id_TipoEntidad = Enums.TipoEntidad.Proveedor_Financiero, Id_Entidad = ((ProvFinancierosManager.SearchResult)ProvFinancierosManager_SearchResultBindingSource.Current).Id });
                frm.ShowDialog(this);
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

        private void btnUNAsignadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieros", Enums.Accion.Ver, "Ver Unidades de Negocios Asignadas")) return;

                if (ProvFinancierosManager_SearchResultBindingSource.Current == null) return;

                var frm = new VENET_Gestion_UI.frmEntidadesUnidadNegocios(Enums.TipoEntidad.Proveedor_Financiero, ((ProvFinancierosManager.SearchResult)ProvFinancierosManager_SearchResultBindingSource.Current).Id);
                frm.ShowDialog(this);
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
