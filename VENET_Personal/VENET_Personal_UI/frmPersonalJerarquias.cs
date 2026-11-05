namespace VENET_Personal_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Personal_BL;

    public partial class frmPersonalJerarquias : MultiForm
    {
        private PersonalJerarquiasManager.ParametrosBusquedas par = new PersonalJerarquiasManager.ParametrosBusquedas();

        public frmPersonalJerarquias()
        {
            InitializeComponent();
        }

        private void frmPersonalJerarquias_Load(object sender, EventArgs e)
        {
            personalJerarquiasManager_ParametrosBusquedasBindingSource.DataSource = par;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalJerarquias", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalJerarquias", Enums.Accion.Buscar)) return;

                Validate();
                personalJerarquiasManager_SearchResultBindingSource.DataSource = PersonalJerarquiasManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalJerarquias", Enums.Accion.Agregar)) return;

            PersonalJerarquias o = new PersonalJerarquias();
            var f = new frmPersonalJerarquias_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                personalJerarquiasManager_SearchResultBindingSource.Add(PersonalJerarquiasManager.Buscar(new PersonalJerarquiasManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalJerarquias", Enums.Accion.Modificar)) return;

                if (personalJerarquiasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (PersonalJerarquiasManager.SearchResult)personalJerarquiasManager_SearchResultBindingSource.Current;
                    var f = new frmPersonalJerarquias_AddMod(new PersonalJerarquias() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        personalJerarquiasManager_SearchResultBindingSource[personalJerarquiasManager_SearchResultBindingSource.Position] = PersonalJerarquiasManager.Buscar(new PersonalJerarquiasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        personalJerarquiasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalJerarquias", Enums.Accion.Eliminar)) return;

                if (personalJerarquiasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    PersonalJerarquiasManager.Eliminar(new PersonalJerarquias() { Id = ((PersonalJerarquiasManager.SearchResult)personalJerarquiasManager_SearchResultBindingSource.Current).Id });
                    personalJerarquiasManager_SearchResultBindingSource.RemoveCurrent();
                    personalJerarquiasManager_SearchResultBindingSource.ResetBindings(false);
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

        private void personalJerarquiasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + personalJerarquiasManager_SearchResultBindingSource.Count.ToString();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }
    }
}
