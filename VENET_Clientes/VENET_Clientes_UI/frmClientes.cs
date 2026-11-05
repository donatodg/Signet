namespace VENET_Clientes_UI
{
    using VENET_Clientes_BL;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;

    public partial class frmClientes : MultiForm
    {
        private ClientesManager.ParametrosBusquedas par = new ClientesManager.ParametrosBusquedas();

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            clientesManager_ParametrosBusquedasBindingSource.DataSource = par;

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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Clientes", Enums.Accion.Imprimir)) return;
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
                formInterface.IdSeleccionado(((ClientesManager.SearchResult)clientesManager_SearchResultBindingSource.Current).Id);
                Close();
            }
            else Modificar();
        }

        private void ClientesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + clientesManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Clientes", Enums.Accion.Buscar)) return;
                Validate();
                clientesManager_SearchResultBindingSource.DataSource = ClientesManager.Buscar(par);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Clientes", Enums.Accion.Agregar)) return;
                {
                    var o = new Clientes();
                    var frm = new frmClientes_AddMod(o);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        clientesManager_SearchResultBindingSource.Add(ClientesManager.Buscar(new ClientesManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
                    }
                    frm.Dispose();
                }
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Clientes", Enums.Accion.Modificar)) return;

                if (clientesManager_SearchResultBindingSource.Current == null) return;

                var curr = (ClientesManager.SearchResult)clientesManager_SearchResultBindingSource.Current;
                var frm = new frmClientes_AddMod(new Clientes() { Id = curr.Id });
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    clientesManager_SearchResultBindingSource[clientesManager_SearchResultBindingSource.Position] = ClientesManager.Buscar(new ClientesManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    clientesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Clientes", Enums.Accion.Eliminar)) return;

                if (clientesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ClientesManager.Eliminar(new Clientes() { Id = ((ClientesManager.SearchResult)clientesManager_SearchResultBindingSource.Current).Id });
                    clientesManager_SearchResultBindingSource.RemoveCurrent();
                    clientesManager_SearchResultBindingSource.ResetBindings(false);
                }
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

        private void btnEmpresasAsignadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Clientes", Enums.Accion.Ver, "Ver Empresas Asignadas")) return;

                if (clientesManager_SearchResultBindingSource.Current == null) return;

                var frm = new VENET_Gestion_UI.frmEntidadesEmpresas(Enums.TipoEntidad.Cliente, ((ClientesManager.SearchResult)clientesManager_SearchResultBindingSource.Current).Id);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Clientes", Enums.Accion.Ver, "Ver Impuestos Asignadas")) return;

                if (clientesManager_SearchResultBindingSource.Current == null) return;

                var frm = new VENET_Gestion_UI.frmEntidadesImpuestosAlicuotas(new EntidadesImpuestoAlicuotas() { Id_TipoEntidad = Enums.TipoEntidad.Cliente, Id_Entidad = ((ClientesManager.SearchResult)clientesManager_SearchResultBindingSource.Current).Id });
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Clientes", Enums.Accion.Ver, "Ver Unidades de Negocios Asignadas")) return;

                if (clientesManager_SearchResultBindingSource.Current == null) return;

                var frm = new VENET_Gestion_UI.frmEntidadesUnidadNegocios(Enums.TipoEntidad.Cliente, ((ClientesManager.SearchResult)clientesManager_SearchResultBindingSource.Current).Id);
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
