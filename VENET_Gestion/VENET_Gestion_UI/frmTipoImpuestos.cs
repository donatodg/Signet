namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmTipoImpuestos : MultiForm
    {
        TipoImpuestosManager.ParametrosBusquedas par = new TipoImpuestosManager.ParametrosBusquedas();

        public frmTipoImpuestos()
        {
            InitializeComponent();
        }

        private void frmTipoImpuestos_Load(object sender, EventArgs e)
        {
            tipoImpuestosManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoImpuestos", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnAlicuotas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoImpuestos", Enums.Accion.Modificar)) return;

                if (tipoImpuestosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (TipoImpuestosManager.SearchResult)tipoImpuestosManager_SearchResultBindingSource.Current;

                    var f = new frmImpuestosAlicuotas(curr.Id, curr.Descripcion);
                    f.ShowDialog(this);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void tipoImpuestosManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + tipoImpuestosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoImpuestos", Enums.Accion.Buscar)) return;

                Validate();
                tipoImpuestosManager_SearchResultBindingSource.DataSource = TipoImpuestosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoImpuestos", Enums.Accion.Agregar)) return;

            TipoImpuestos o = new TipoImpuestos();
            var f = new frmTipoImpuestos_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                tipoImpuestosManager_SearchResultBindingSource.Add(TipoImpuestosManager.Buscar(new TipoImpuestosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoImpuestos", Enums.Accion.Modificar)) return;

                if (tipoImpuestosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (TipoImpuestosManager.SearchResult)tipoImpuestosManager_SearchResultBindingSource.Current;
                    var f = new frmTipoImpuestos_AddMod(new TipoImpuestos() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        tipoImpuestosManager_SearchResultBindingSource[tipoImpuestosManager_SearchResultBindingSource.Position] = TipoImpuestosManager.Buscar(new TipoImpuestosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        tipoImpuestosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "TipoImpuestos", Enums.Accion.Eliminar)) return;

                if (tipoImpuestosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    TipoImpuestosManager.Eliminar(new TipoImpuestos() { Id = ((TipoImpuestosManager.SearchResult)tipoImpuestosManager_SearchResultBindingSource.Current).Id });
                    tipoImpuestosManager_SearchResultBindingSource.RemoveCurrent();
                    tipoImpuestosManager_SearchResultBindingSource.ResetBindings(false);
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
