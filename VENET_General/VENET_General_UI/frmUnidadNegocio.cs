namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmUnidadNegocio : MultiForm
    {
        private UnidadNegocioManager.ParametrosBusquedas par = new UnidadNegocioManager.ParametrosBusquedas();

        public frmUnidadNegocio()
        {
            InitializeComponent();
        }

        private void frmUnidadNegocio_Load(object sender, EventArgs e)
        {
            unidadNegocioManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "UnidadNegocio", Enums.Accion.Imprimir)) return;
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "UnidadNegocio", Enums.Accion.Buscar)) return;

                Validate();
                unidadNegocioManager_SearchResultBindingSource.DataSource = UnidadNegocioManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "UnidadNegocio", Enums.Accion.Agregar)) return;

            UnidadNegocios o = new UnidadNegocios();
            var f = new frmUnidadNegocio_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                unidadNegocioManager_SearchResultBindingSource.Add(UnidadNegocioManager.Buscar(new UnidadNegocioManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "UnidadNegocio", Enums.Accion.Modificar)) return;

                if (unidadNegocioManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (UnidadNegocioManager.SearchResult)unidadNegocioManager_SearchResultBindingSource.Current;
                    var f = new frmUnidadNegocio_AddMod(new UnidadNegocios() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        unidadNegocioManager_SearchResultBindingSource[unidadNegocioManager_SearchResultBindingSource.Position] = UnidadNegocioManager.Buscar(new UnidadNegocioManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        unidadNegocioManager_SearchResultBindingSource.ResetCurrentItem();
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
                Sistema.MensajeError( ex);
            }
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "UnidadNegocio", Enums.Accion.Eliminar)) return;

                if (unidadNegocioManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    UnidadNegocioManager.Eliminar(new UnidadNegocios() { Id = ((UnidadNegocioManager.SearchResult)unidadNegocioManager_SearchResultBindingSource.Current).Id });
                    unidadNegocioManager_SearchResultBindingSource.RemoveCurrent();
                    unidadNegocioManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
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

        private void unidadNegocioManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + unidadNegocioManager_SearchResultBindingSource.Count.ToString();
        }

    }
}
