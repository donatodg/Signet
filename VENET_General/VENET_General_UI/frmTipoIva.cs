namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmTipoIva : MultiForm
    {
        TipoIvaManager.ParametrosBusquedas par = new TipoIvaManager.ParametrosBusquedas();

        public frmTipoIva()
        {
            InitializeComponent();
        }

        private void frmTipoIva_Load(object sender, EventArgs e)
        {
            tipoIvaManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoIva", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void tipoIvaManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + tipoIvaManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoIva", Enums.Accion.Buscar)) return;

                Validate();
                tipoIvaManager_SearchResultBindingSource.DataSource = TipoIvaManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoIva", Enums.Accion.Agregar)) return;

            TipoIva o = new TipoIva();
            var f = new frmTipoIva_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                tipoIvaManager_SearchResultBindingSource.Add(TipoIvaManager.Buscar(new TipoIvaManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoIva", Enums.Accion.Modificar)) return;

                if (tipoIvaManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (TipoIvaManager.SearchResult)tipoIvaManager_SearchResultBindingSource.Current;
                    var f = new frmTipoIva_AddMod(new TipoIva() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        tipoIvaManager_SearchResultBindingSource[tipoIvaManager_SearchResultBindingSource.Position] = TipoIvaManager.Buscar(new TipoIvaManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        tipoIvaManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TipoIva", Enums.Accion.Eliminar)) return;

                if (tipoIvaManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    TipoIvaManager.Eliminar(new TipoIva() { Id = ((TipoIvaManager.SearchResult)tipoIvaManager_SearchResultBindingSource.Current).Id });
                    tipoIvaManager_SearchResultBindingSource.RemoveCurrent();
                    tipoIvaManager_SearchResultBindingSource.ResetBindings(false);
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
