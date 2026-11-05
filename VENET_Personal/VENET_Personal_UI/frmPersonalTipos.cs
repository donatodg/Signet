namespace VENET_Personal_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Personal_BL;

    public partial class frmPersonalTipos : MultiForm
    {
        private PersonalTiposManager.ParametrosBusquedas par = new PersonalTiposManager.ParametrosBusquedas();

        public frmPersonalTipos()
        {
            InitializeComponent();
        }

        private void frmPersonalTipos_Load(object sender, EventArgs e)
        {
            personalTiposManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalTipos", Enums.Accion.Imprimir)) return;
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalTipos", Enums.Accion.Buscar)) return;

                Validate();
                personalTiposManager_SearchResultBindingSource.DataSource = PersonalTiposManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalTipos", Enums.Accion.Agregar)) return;

            PersonalTipos o = new PersonalTipos();
            var f = new frmPersonalTipos_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                personalTiposManager_SearchResultBindingSource.Add(PersonalTiposManager.Buscar(new PersonalTiposManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalTipos", Enums.Accion.Modificar)) return;

                if (personalTiposManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (PersonalTiposManager.SearchResult)personalTiposManager_SearchResultBindingSource.Current;
                    var f = new frmPersonalTipos_AddMod(new PersonalTipos() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        personalTiposManager_SearchResultBindingSource[personalTiposManager_SearchResultBindingSource.Position] = PersonalTiposManager.Buscar(new PersonalTiposManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        personalTiposManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalTipos", Enums.Accion.Eliminar)) return;

                if (personalTiposManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    PersonalTiposManager.Eliminar(new PersonalTipos() { Id = ((PersonalTiposManager.SearchResult)personalTiposManager_SearchResultBindingSource.Current).Id });
                    personalTiposManager_SearchResultBindingSource.RemoveCurrent();
                    personalTiposManager_SearchResultBindingSource.ResetBindings(false);
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

        private void personalTiposManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + personalTiposManager_SearchResultBindingSource.Count.ToString();
        }

    }
}
