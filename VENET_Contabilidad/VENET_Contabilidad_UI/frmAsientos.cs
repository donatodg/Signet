namespace VENET_Contabilidad_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Contabilidad_BL;

    public partial class frmAsientos : MultiForm
    {
        AsientosManager.ParametrosBusquedas par = new AsientosManager.ParametrosBusquedas();

        public frmAsientos()
        {
            InitializeComponent();
        }

        private void frmAsientos_Load(object sender, EventArgs e)
        {
            try
            {
                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";

                asientosManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Asientos", Enums.Accion.Imprimir)) return;
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

        private void asientosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + asientosManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Asientos", Enums.Accion.Buscar)) return;

                Validate();
                asientosManager_SearchResultBindingSource.DataSource = AsientosManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Asientos", Enums.Accion.Agregar)) return;

            Asientos o = new Asientos();
            var f = new frmAsientos_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                asientosManager_SearchResultBindingSource.Add(AsientosManager.Buscar(new AsientosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Asientos", Enums.Accion.Modificar)) return;

                if (asientosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (AsientosManager.SearchResult)asientosManager_SearchResultBindingSource.Current;
                    var f = new frmAsientos_AddMod(new Asientos() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        asientosManager_SearchResultBindingSource[asientosManager_SearchResultBindingSource.Position] = AsientosManager.Buscar(new AsientosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        asientosManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "Asientos", Enums.Accion.Eliminar)) return;

                if (asientosManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    AsientosManager.Eliminar(new Asientos() { Id = ((AsientosManager.SearchResult)asientosManager_SearchResultBindingSource.Current).Id });
                    asientosManager_SearchResultBindingSource.RemoveCurrent();
                    asientosManager_SearchResultBindingSource.ResetBindings(false);
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

    }
}
