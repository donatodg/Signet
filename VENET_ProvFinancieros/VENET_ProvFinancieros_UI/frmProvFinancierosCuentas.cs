namespace VENET_ProvFinancieros_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_ProvFinancieros_BL;

    public partial class frmProvFinancierosCuentas : MultiForm, IDisposable
    {
        private ProvFinancierosCuentasManager manager;
        int IdProveedorF;

        public frmProvFinancierosCuentas(int Id_ProveedorF)
        {
            InitializeComponent();
            manager = new ProvFinancierosCuentasManager(Id_ProveedorF);
            IdProveedorF = Id_ProveedorF;
        }

        private void frmProvFinancierosCuentas_Load(object sender, EventArgs e)
        {
            provFinancierosCuentasManager_SearchResultBindingSource.DataSource = manager.ListProvFinancieros;
        }

        private void provFinancierosCuentasManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + provFinancierosCuentasManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnModificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }
        
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }
        
        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieroCuentas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Agregar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieroCuentas", Enums.Accion.Agregar)) return;

                ProvFinancierosCuentas o = new ProvFinancierosCuentas() { Id_ProvFinanciero = IdProveedorF };
                var f = new frmProvFinancierosCuentas_AddMod(o);
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    provFinancierosCuentasManager_SearchResultBindingSource.Add(ProvFinancierosCuentasManager.Buscar(new ProvFinancierosCuentasManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
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

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieroCuentas", Enums.Accion.Modificar)) return;

                if (provFinancierosCuentasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ProvFinancierosCuentasManager.SearchResult)provFinancierosCuentasManager_SearchResultBindingSource.Current;
                    var f = new frmProvFinancierosCuentas_AddMod(new ProvFinancierosCuentas() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        provFinancierosCuentasManager_SearchResultBindingSource[provFinancierosCuentasManager_SearchResultBindingSource.Position] = ProvFinancierosCuentasManager.Buscar(new ProvFinancierosCuentasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        provFinancierosCuentasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ProvFinancieroCuentas", Enums.Accion.Eliminar)) return;

                if (provFinancierosCuentasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ProvFinancierosCuentasManager.Eliminar(new ProvFinancierosCuentas() { Id = ((ProvFinancierosCuentasManager.SearchResult)provFinancierosCuentasManager_SearchResultBindingSource.Current).Id });
                    provFinancierosCuentasManager_SearchResultBindingSource.RemoveCurrent();
                    provFinancierosCuentasManager_SearchResultBindingSource.ResetBindings(false);
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
