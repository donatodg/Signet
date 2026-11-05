namespace VENET_Tesoreria_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmCajas : MultiForm
    {
        private CajasManager.ParametrosBusquedas par = new CajasManager.ParametrosBusquedas();

        public frmCajas()
        {
            InitializeComponent();
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            try
            {
                id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                id_EspecieLookUpEdit.Properties.DataSource = Sistema.EspeciesTodas;
                id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
                id_EspecieLookUpEdit.Properties.ValueMember = "Key";

                cajasManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Caja", Enums.Accion.Imprimir)) return;
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

        private void cajasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + cajasManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Caja", Enums.Accion.Buscar)) return;
                Validate();
                cajasManager_SearchResultBindingSource.DataSource = CajasManager.Buscar(par);
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Cajas", Enums.Accion.Agregar)) return;

                Cajas o = new Cajas();
                var f = new frmCajas_AddMod(o);
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    cajasManager_SearchResultBindingSource.Add(CajasManager.Buscar(new CajasManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Cajas", Enums.Accion.Modificar)) return;

                if (cajasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (CajasManager.SearchResult)cajasManager_SearchResultBindingSource.Current;
                    var f = new frmCajas_AddMod(new Cajas() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        cajasManager_SearchResultBindingSource[cajasManager_SearchResultBindingSource.Position] = CajasManager.Buscar(new CajasManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        cajasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Cajas", Enums.Accion.Eliminar)) return;

                if (cajasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    CajasManager.Eliminar(new Cajas() { Id = ((CajasManager.SearchResult)cajasManager_SearchResultBindingSource.Current).Id });
                    cajasManager_SearchResultBindingSource.RemoveCurrent();
                    cajasManager_SearchResultBindingSource.ResetBindings(false);
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

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modificar();
        }
    }
}
