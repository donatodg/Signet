namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmVendedores : MultiForm
    {
        private VendedoresManager.ParametrosBusquedas par = new VendedoresManager.ParametrosBusquedas();

        public frmVendedores()
        {
            InitializeComponent();
        }

        private void frmVendedores_Load(object sender, EventArgs e)
        {
            try
            {
                vendedoresManager_ParametrosBusquedasBindingSource.DataSource = par;
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Vendedores", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void vendedoresManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + vendedoresManager_SearchResultBindingSource.Count.ToString();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Vendedores", Enums.Accion.Buscar)) return;
                Validate();
                vendedoresManager_SearchResultBindingSource.DataSource = VendedoresManager.Buscar(par);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Vendedores", Enums.Accion.Agregar)) return;

                Vendedores o = new Vendedores();
                var f = new frmVendedores_AddMod(o);
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    vendedoresManager_SearchResultBindingSource.Add(VendedoresManager.Buscar(new VendedoresManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Vendedores", Enums.Accion.Modificar)) return;

                if (vendedoresManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (VendedoresManager.SearchResult)vendedoresManager_SearchResultBindingSource.Current;
                    var f = new frmVendedores_AddMod(new Vendedores() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        vendedoresManager_SearchResultBindingSource[vendedoresManager_SearchResultBindingSource.Position] = VendedoresManager.Buscar(new VendedoresManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        vendedoresManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Vendedores", Enums.Accion.Eliminar)) return;

                if (vendedoresManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    VendedoresManager.Eliminar(new Vendedores() { Id = ((VendedoresManager.SearchResult)vendedoresManager_SearchResultBindingSource.Current).Id });
                    vendedoresManager_SearchResultBindingSource.RemoveCurrent();
                    vendedoresManager_SearchResultBindingSource.ResetBindings(false);
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
    }
}
