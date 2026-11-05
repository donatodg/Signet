namespace VENET_Personal_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Personal_BL;
    
    public partial class frmPersonalNovedades : MultiForm
    {
        private PersonalNovedadesManager.ParametrosBusquedas par = new PersonalNovedadesManager.ParametrosBusquedas();

        public frmPersonalNovedades()
        {
            InitializeComponent();
        }

        private void frmPersonalNovedades_Load(object sender, EventArgs e)
        {
            personalNovedadesManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_TipoNovedadLookUpEdit.Properties.DataSource = par.TipoNovedad;
            id_TipoNovedadLookUpEdit.Properties.DisplayMember = "Name";
            id_TipoNovedadLookUpEdit.Properties.ValueMember = "Key";

            id_PersonalLookUpEdit.Properties.DataSource = par.Personal;
            id_PersonalLookUpEdit.Properties.DisplayMember = "LegajoNombre";
            id_PersonalLookUpEdit.Properties.ValueMember = "Id";
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalNovedades", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void personalNovedadesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + personalNovedadesManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalNovedades", Enums.Accion.Buscar)) return;

                Validate();
                personalNovedadesManager_SearchResultBindingSource.DataSource = PersonalNovedadesManager.Buscar(par);
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
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalNovedades", Enums.Accion.Agregar)) return;

                    Validate();

                    var o = new PersonalNovedades();
                    var frm = new frmPersonalNovedadesAddMod(o);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        Buscar();
                        //personalNovedadesManager_SearchResultBindingSource.Add(PersonalNovedadesManager.Buscar(new PersonalNovedadesManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalNovedades", Enums.Accion.Modificar)) return;

                if (personalNovedadesManager_SearchResultBindingSource.Current == null) return;

                var curr = (PersonalNovedadesManager.SearchResult)personalNovedadesManager_SearchResultBindingSource.Current;
                var frm = new frmPersonalNovedadesAddMod(new PersonalNovedades() { Id = curr.Id });
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    personalNovedadesManager_SearchResultBindingSource[personalNovedadesManager_SearchResultBindingSource.Position] = PersonalNovedadesManager.Buscar(new PersonalNovedadesManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    personalNovedadesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "PersonalNovedades", Enums.Accion.Eliminar)) return;

                if (personalNovedadesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    PersonalNovedadesManager.Eliminar(new PersonalNovedades() { Id = ((PersonalNovedadesManager.SearchResult)personalNovedadesManager_SearchResultBindingSource.Current).Id });
                    personalNovedadesManager_SearchResultBindingSource.RemoveCurrent();
                    personalNovedadesManager_SearchResultBindingSource.ResetBindings(false);
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }
    
        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

    }
}
