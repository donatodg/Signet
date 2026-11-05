namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmEntidadesBancarias : MultiForm, IDisposable
    {
        private EntidadesBancariasManager.ParametrosBusquedas par = new EntidadesBancariasManager.ParametrosBusquedas();

        public frmEntidadesBancarias()
        {
            InitializeComponent();
        }

        private void frmEntidadesBancarias_Load(object sender, EventArgs e)
        {
            entidadesBancariasManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "EntidadesBancarias", Enums.Accion.Imprimir)) return;
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "EntidadesBancarias", Enums.Accion.Buscar)) return;

                Validate();
                entidadesBancariasManager_SearchResultBindingSource.DataSource = EntidadesBancariasManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "EntidadesBancarias", Enums.Accion.Agregar)) return;

            EntidadesBancarias o = new EntidadesBancarias();
            var f = new frmEntidadesBancariasAddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                entidadesBancariasManager_SearchResultBindingSource.Add(EntidadesBancariasManager.Buscar(new EntidadesBancariasManager.ParametrosBusquedas() { Codigo = o.Codigo }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "EntidadesBancarias", Enums.Accion.Modificar)) return;

                if (entidadesBancariasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EntidadesBancariasManager.SearchResult)entidadesBancariasManager_SearchResultBindingSource.Current;
                    var f = new frmEntidadesBancariasAddMod(new EntidadesBancarias() { Codigo = curr.Codigo });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        entidadesBancariasManager_SearchResultBindingSource[entidadesBancariasManager_SearchResultBindingSource.Position] = EntidadesBancariasManager.Buscar(new EntidadesBancariasManager.ParametrosBusquedas() { Codigo = curr.Codigo }).SingleOrDefault();
                        entidadesBancariasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "EntidadesBancarias", Enums.Accion.Eliminar)) return;

                if (entidadesBancariasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    EntidadesBancariasManager.Eliminar(new EntidadesBancarias() { Codigo = ((EntidadesBancariasManager.SearchResult)entidadesBancariasManager_SearchResultBindingSource.Current).Codigo });
                    entidadesBancariasManager_SearchResultBindingSource.RemoveCurrent();
                    entidadesBancariasManager_SearchResultBindingSource.ResetBindings(false);
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

        private void entidadesBancariasManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + entidadesBancariasManager_SearchResultBindingSource.Count.ToString();
        }
    }
}
