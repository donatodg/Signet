namespace VENET_Contabilidad_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Contabilidad_BL;

    public partial class frmEjerciciosContables : MultiForm
    {
        private EjerciciosContablesManager.ParametrosBusquedas par = new EjerciciosContablesManager.ParametrosBusquedas();

        public frmEjerciciosContables()
        {
            InitializeComponent();
        }

        private void frmEjerciciosContables_Load(object sender, EventArgs e)
        {
            try
            {
                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";

                ejerciciosContablesManager_ParametrosBusquedasBindingSource.DataSource = par;

                Validate();
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void ejerciciosContablesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + ejerciciosContablesManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "EjerciciosContables", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "EjerciciosContables", Enums.Accion.Buscar)) return;
                Validate();
                ejerciciosContablesManager_SearchResultBindingSource.DataSource = EjerciciosContablesManager.Buscar(par);
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
                Validate();
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "EjerciciosContables", Enums.Accion.Agregar)) return;

                EjerciciosContables o = new EjerciciosContables() { };
                var f = new frmEjerciciosContables_AddMod(o);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    ejerciciosContablesManager_SearchResultBindingSource.Add(EjerciciosContablesManager.Buscar(new EjerciciosContablesManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "EjerciciosContables", Enums.Accion.Modificar)) return;

                if (ejerciciosContablesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (EjerciciosContablesManager.SearchResult)ejerciciosContablesManager_SearchResultBindingSource.Current;
                    var f = new frmEjerciciosContables_AddMod(new EjerciciosContables() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        ejerciciosContablesManager_SearchResultBindingSource[ejerciciosContablesManager_SearchResultBindingSource.Position] = EjerciciosContablesManager.Buscar(new EjerciciosContablesManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        ejerciciosContablesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "EjerciciosContables", Enums.Accion.Eliminar)) return;

                if (ejerciciosContablesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    EjerciciosContablesManager.Eliminar(new EjerciciosContables() { Id = ((EjerciciosContablesManager.SearchResult)ejerciciosContablesManager_SearchResultBindingSource.Current).Id });
                    ejerciciosContablesManager_SearchResultBindingSource.RemoveCurrent();
                    ejerciciosContablesManager_SearchResultBindingSource.ResetBindings(false);
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
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
            }
        }

    }
}
