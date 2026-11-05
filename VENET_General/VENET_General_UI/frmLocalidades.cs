namespace VENET_General_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmLocalidades : MultiForm, IDisposable
    {
        LocalidadesManager.ParametrosBusquedas par = new LocalidadesManager.ParametrosBusquedas();

        public frmLocalidades()
        {
            InitializeComponent();
        }

        private void frmLocalidades_Load(object sender, EventArgs e)
        {
            localidadesManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_ProvinciaLookUpEdit.Properties.DataSource = Sistema.Provincias;
            id_ProvinciaLookUpEdit.Properties.DisplayMember = "Name";
            id_ProvinciaLookUpEdit.Properties.ValueMember = "Key";
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Localidades", Enums.Accion.Imprimir)) return;
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

        private void localidadesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + localidadesManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Localidades", Enums.Accion.Buscar)) return;

                Validate();
                localidadesManager_SearchResultBindingSource.DataSource = LocalidadesManager.Buscar(par);
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
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Localidades", Enums.Accion.Agregar)) return;

                    Validate();

                    var o = new Localidades();
                    var frm = new frmLocalidades_AddMod(o);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        localidadesManager_SearchResultBindingSource.Add(LocalidadesManager.Buscar(new LocalidadesManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Localidades", Enums.Accion.Modificar)) return;

                if (localidadesManager_SearchResultBindingSource.Current == null) return;

                var curr = (LocalidadesManager.SearchResult)localidadesManager_SearchResultBindingSource.Current;
                var frm = new frmLocalidades_AddMod(new Localidades() { Id = curr.Id });
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    localidadesManager_SearchResultBindingSource[localidadesManager_SearchResultBindingSource.Position] = LocalidadesManager.Buscar(new LocalidadesManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    localidadesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Localidades", Enums.Accion.Eliminar)) return;

                if (localidadesManager_SearchResultBindingSource.Current == null) return;


                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    LocalidadesManager.Eliminar(new Localidades() { Id = ((LocalidadesManager.SearchResult)localidadesManager_SearchResultBindingSource.Current).Id });
                    localidadesManager_SearchResultBindingSource.RemoveCurrent();
                    localidadesManager_SearchResultBindingSource.ResetBindings(false);
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
        }

    }
}
