namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmTipoViaticos : MultiForm
    {
        TipoViaticosManager.ParametrosBusquedas par = new TipoViaticosManager.ParametrosBusquedas();

        public frmTipoViaticos()
        {
            InitializeComponent();
        }

        private void frmTipoViaticos_Load(object sender, EventArgs e)
        {
            tipoViaticosManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoViaticos", Enums.Accion.Imprimir)) return;
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoViaticos", Enums.Accion.Buscar)) return;

                Validate();
                tipoViaticosManager_SearchResultBindingSource.DataSource = TipoViaticosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoViaticos", Enums.Accion.Agregar)) return;

            TipoViaticos o = new TipoViaticos();
            var f = new frmTipoViaticos_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                tipoViaticosManager_SearchResultBindingSource.Add(TipoViaticosManager.Buscar(new TipoViaticosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoViaticos", Enums.Accion.Modificar)) return;

                if (tipoViaticosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (TipoViaticosManager.SearchResult)tipoViaticosManager_SearchResultBindingSource.Current;
                    var f = new frmTipoViaticos_AddMod(new TipoViaticos() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        tipoViaticosManager_SearchResultBindingSource[tipoViaticosManager_SearchResultBindingSource.Position] = TipoViaticosManager.Buscar(new TipoViaticosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        tipoViaticosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoViaticos", Enums.Accion.Eliminar)) return;

                if (tipoViaticosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    TipoViaticosManager.Eliminar(new TipoViaticos() { Id = ((TipoViaticosManager.SearchResult)tipoViaticosManager_SearchResultBindingSource.Current).Id });
                    tipoViaticosManager_SearchResultBindingSource.RemoveCurrent();
                    tipoViaticosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void tipoViaticosManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + tipoViaticosManager_SearchResultBindingSource.Count.ToString();
        }
    }
}
