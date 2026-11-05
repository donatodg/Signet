namespace VENET_Proveedores_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Proveedores_BL;

    public partial class frmProveedores : MultiForm
    {
        private ProveedoresManager.ParametrosBusquedas par = new ProveedoresManager.ParametrosBusquedas();

        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            ProveedoresManager_ParametrosBusquedasBindingSource.DataSource = par;

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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Proveedores", Enums.Accion.Imprimir)) return;
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
                formInterface.IdSeleccionado(((ProveedoresManager.SearchResult)ProveedoresManager_SearchResultBindingSource.Current).Id);
                Close();
            }
            else Modificar();
        }

        private void ProveedoresManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de registros: " + ProveedoresManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Proveedores", Enums.Accion.Buscar)) return;
                Validate();
                ProveedoresManager_SearchResultBindingSource.DataSource = ProveedoresManager.Buscar(par);
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }

        private void Agregar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Proveedores", Enums.Accion.Agregar)) return;
                {
                    var o = new Proveedores();
                    var frm = new frmProveedores_AddMod(o);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        ProveedoresManager_SearchResultBindingSource.Add(ProveedoresManager.Buscar(new ProveedoresManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
                    }
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Proveedores", Enums.Accion.Modificar)) return;

                if (ProveedoresManager_SearchResultBindingSource.Current == null) return;

                var curr = (ProveedoresManager.SearchResult)ProveedoresManager_SearchResultBindingSource.Current;
                var frm = new frmProveedores_AddMod(new Proveedores() { Id = curr.Id });
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    ProveedoresManager_SearchResultBindingSource[ProveedoresManager_SearchResultBindingSource.Position] = ProveedoresManager.Buscar(new ProveedoresManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    ProveedoresManager_SearchResultBindingSource.ResetCurrentItem();
                }
                frm.Dispose();
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Proveedores", Enums.Accion.Eliminar)) return;

                if (ProveedoresManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProveedoresManager.Eliminar(new Proveedores() { Id = ((ProveedoresManager.SearchResult)ProveedoresManager_SearchResultBindingSource.Current).Id });
                    ProveedoresManager_SearchResultBindingSource.RemoveCurrent();
                    ProveedoresManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
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

        private void btnEmpresasAsignadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Proveedores", Enums.Accion.Ver, "Ver Empresas Asignadas")) return;

                if (ProveedoresManager_SearchResultBindingSource.Current == null) return;

                var frm = new VENET_Gestion_UI.frmEntidadesEmpresas(Enums.TipoEntidad.Proveedor, ((ProveedoresManager.SearchResult)ProveedoresManager_SearchResultBindingSource.Current).Id);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Proveedores", Enums.Accion.Ver, "Ver Impuestos Asignadas")) return;

                if (ProveedoresManager_SearchResultBindingSource.Current == null) return;

                var frm = new VENET_Gestion_UI.frmEntidadesImpuestosAlicuotas(new EntidadesImpuestoAlicuotas() { Id_TipoEntidad = Enums.TipoEntidad.Proveedor, Id_Entidad = ((ProveedoresManager.SearchResult)ProveedoresManager_SearchResultBindingSource.Current).Id });
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Proveedores", Enums.Accion.Ver, "Ver Unidades de Negocios Asignadas")) return;

                if (ProveedoresManager_SearchResultBindingSource.Current == null) return;

                var frm = new VENET_Gestion_UI.frmEntidadesUnidadNegocios(Enums.TipoEntidad.Proveedor, ((ProveedoresManager.SearchResult)ProveedoresManager_SearchResultBindingSource.Current).Id);
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
