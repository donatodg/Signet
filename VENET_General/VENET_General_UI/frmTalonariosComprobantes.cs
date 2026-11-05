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

    public partial class frmTalonariosComprobantes : MultiForm, IDisposable
    {
        TalonariosComprobantesManager.ParametrosBusquedas par = new TalonariosComprobantesManager.ParametrosBusquedas();

        public frmTalonariosComprobantes()
        {
            InitializeComponent();
        }

        private void frmTalonariosComprobantes_Load(object sender, EventArgs e)
        {
            try
            {
                talonariosComprobantesManager_ParametrosBusquedasBindingSource.DataSource = par;

                id_ComprobanteLookUpEdit.Properties.DataSource = Sistema.TipoComprobanteConTalonarios;
                id_ComprobanteLookUpEdit.Properties.DisplayMember = "Name";
                id_ComprobanteLookUpEdit.Properties.ValueMember = "Key";

                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                if (Sistema.Empresas.Count() > 0)
                {
                    id_EmpresaLookUpEdit.ItemIndex = 0;
                    par.Id_Empresa = (Int32)id_EmpresaLookUpEdit.EditValue;
                }
                else
                {
                    Sistema.Mensaje("El usuario no posee empresas asignadas.");
                    Close();
                }

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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TalonariosComprobantes", Enums.Accion.Imprimir)) return;
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

        private void talonariosComprobantesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + talonariosComprobantesManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TalonariosComprobantes", Enums.Accion.Buscar)) return;

                Validate();
                talonariosComprobantesManager_SearchResultBindingSource.DataSource = TalonariosComprobantesManager.Buscar(par);
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
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TalonariosComprobantes", Enums.Accion.Agregar)) return;

                    Validate();

                    var o = new TalonariosComprobantes();//{ Id_Empresa = (Int32)par.Id_Empresa };
                    var frm = new frmTalonariosComprobantes_AddMod(o, (Int32)par.Id_Empresa);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        talonariosComprobantesManager_SearchResultBindingSource.Add(TalonariosComprobantesManager.Buscar(new TalonariosComprobantesManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TalonariosComprobantes", Enums.Accion.Modificar)) return;

                if (talonariosComprobantesManager_SearchResultBindingSource.Current == null) return;

                var curr = (TalonariosComprobantesManager.SearchResult)talonariosComprobantesManager_SearchResultBindingSource.Current;
                var frm = new frmTalonariosComprobantes_AddMod(new TalonariosComprobantes() { Id = curr.Id }, (Int32)par.Id_Empresa);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    talonariosComprobantesManager_SearchResultBindingSource[talonariosComprobantesManager_SearchResultBindingSource.Position] = TalonariosComprobantesManager.Buscar(new TalonariosComprobantesManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    talonariosComprobantesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "TalonariosComprobantes", Enums.Accion.Eliminar)) return;

                if (talonariosComprobantesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    TalonariosComprobantesManager.Eliminar(new TalonariosComprobantes() { Id = ((TalonariosComprobantesManager.SearchResult)talonariosComprobantesManager_SearchResultBindingSource.Current).Id });
                    talonariosComprobantesManager_SearchResultBindingSource.RemoveCurrent();
                    talonariosComprobantesManager_SearchResultBindingSource.ResetBindings(false);
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
