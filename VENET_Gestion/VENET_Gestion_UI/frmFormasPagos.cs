namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmFormasPagos : MultiForm
    {
        FormasPagosManager.ParametrosBusquedas par = new FormasPagosManager.ParametrosBusquedas();

        public frmFormasPagos()
        {
            InitializeComponent();
        }

        private void frmFormasPagos_Load(object sender, EventArgs e)
        {
            formasPagosManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "FormasPagos", Enums.Accion.Imprimir)) return;
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

        private void formasPagosManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + formasPagosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "FormasPagos", Enums.Accion.Buscar)) return;

                Validate();
                formasPagosManager_SearchResultBindingSource.DataSource = FormasPagosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "FormasPagos", Enums.Accion.Agregar)) return;

            FormasPagos o = new FormasPagos();
            var f = new frmFormasPagos_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                formasPagosManager_SearchResultBindingSource.Add(FormasPagosManager.Buscar(new FormasPagosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "FormasPagos", Enums.Accion.Modificar)) return;

                if (formasPagosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (FormasPagosManager.SearchResult)formasPagosManager_SearchResultBindingSource.Current;
                    var f = new frmFormasPagos_AddMod(new FormasPagos() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        formasPagosManager_SearchResultBindingSource[formasPagosManager_SearchResultBindingSource.Position] = FormasPagosManager.Buscar(new FormasPagosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        formasPagosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "FormasPagos", Enums.Accion.Eliminar)) return;

                if (formasPagosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    FormasPagosManager.Eliminar(new FormasPagos() { Id = ((FormasPagosManager.SearchResult)formasPagosManager_SearchResultBindingSource.Current).Id });
                    formasPagosManager_SearchResultBindingSource.RemoveCurrent();
                    formasPagosManager_SearchResultBindingSource.ResetBindings(false);
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
