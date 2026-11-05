namespace VENET_General_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmTipoCodigoServicios : MultiForm, IDisposable
    {
        TipoCodigoServicioManager.ParametrosBusquedas par = new TipoCodigoServicioManager.ParametrosBusquedas();

        public frmTipoCodigoServicios()
        {
            InitializeComponent();
        }

        private void frmTipoCodigoServicio_Load(object sender, EventArgs e)
        {
            try
            {
                tipoCodigoServicioManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoCodigoServicio", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void tipoCodigoServicioManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + tipoCodigoServicioManager_SearchResultBindingSource.Count.ToString();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoCodigoServicio", Enums.Accion.Buscar)) return;

                Validate();
                tipoCodigoServicioManager_SearchResultBindingSource.DataSource = TipoCodigoServicioManager.Buscar(par);
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
                {
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoCodigoServicio", Enums.Accion.Agregar)) return;

                    Validate();

                    var o = new TipoCodigoServicio(); ;
                    var frm = new frmTipoCodigoServicio_AddMod(o);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        tipoCodigoServicioManager_SearchResultBindingSource.Add(TipoCodigoServicioManager.Buscar(new TipoCodigoServicioManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoCodigoServicio", Enums.Accion.Modificar)) return;

                if (tipoCodigoServicioManager_SearchResultBindingSource.Current == null) return;

                var curr = (TipoCodigoServicioManager.SearchResult)tipoCodigoServicioManager_SearchResultBindingSource.Current;
                var frm = new frmTipoCodigoServicio_AddMod(new TipoCodigoServicio() { Id = curr.Id });
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    tipoCodigoServicioManager_SearchResultBindingSource[tipoCodigoServicioManager_SearchResultBindingSource.Position] = TipoCodigoServicioManager.Buscar(new TipoCodigoServicioManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    tipoCodigoServicioManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoCodigoServicio", Enums.Accion.Eliminar)) return;

                if (tipoCodigoServicioManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    TipoCodigoServicioManager.Eliminar(new TipoCodigoServicio() { Id = ((TipoCodigoServicioManager.SearchResult)tipoCodigoServicioManager_SearchResultBindingSource.Current).Id });
                    tipoCodigoServicioManager_SearchResultBindingSource.RemoveCurrent();
                    tipoCodigoServicioManager_SearchResultBindingSource.ResetBindings(false);
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
    }
}
