using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using VENET_Common;
using VENET_DataEntity;
using VENET_General_BL;

namespace VENET_General_UI
{
    public partial class frmSucursales : MultiForm
    {
        SucursalesManager.ParametrosBusquedas par = new SucursalesManager.ParametrosBusquedas();

        public frmSucursales()
        {
            InitializeComponent();
        }

        public frmSucursales(Int32 Id_Empresa)
        {
            InitializeComponent();
            par.Id_Empresa = Id_Empresa;
            Buscar();
        }

        private void frmSucursales_Load(object sender, EventArgs e)
        {
            sucursalesManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_EmpresaLookUpEdit.Properties.DataSource = par.Empresas;
            id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
            id_EmpresaLookUpEdit.Properties.ValueMember = "Key";
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                this.Validate();
                sucursalesManager_SearchResultBindingSource.DataSource = SucursalesManager.Buscar(par);
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message, "Error en Sucursales");
            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", "Atención", ex);
            }
        }

        private void Agregar()
        {
            try
            {
                {
                    this.Validate();

                    var o = new Sucursales();
                    var frm = new frmSucursales_AddMod(o);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        sucursalesManager_SearchResultBindingSource.Add(SucursalesManager.Buscar(new SucursalesManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
                    }
                    frm.Dispose();
                }
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message, "Error en Sucursales");
            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", "Atención", ex);
            }
        }

        private void Modificar()
        {
            try
            {
                if (sucursalesManager_SearchResultBindingSource.Current == null) return;

                var curr = (SucursalesManager.SearchResult)sucursalesManager_SearchResultBindingSource.Current;
                var frm = new frmSucursales_AddMod(new Sucursales() { Id = curr.Id });
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    sucursalesManager_SearchResultBindingSource[sucursalesManager_SearchResultBindingSource.Position] = SucursalesManager.Buscar(new SucursalesManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    sucursalesManager_SearchResultBindingSource.ResetCurrentItem();
                }
                frm.Dispose();

            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message, "Error en Sucursales");
            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", "Atención", ex);
            }
        }

        private void Eliminar()
        {
            try
            {
                if (sucursalesManager_SearchResultBindingSource.Current == null) return;


                if (Sistema.MensajeSiNo("Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SucursalesManager.Eliminar(new Sucursales() { Id = ((SucursalesManager.SearchResult)sucursalesManager_SearchResultBindingSource.Current).Id });
                    sucursalesManager_SearchResultBindingSource.RemoveCurrent();
                    sucursalesManager_SearchResultBindingSource.ResetBindings(false);
                }

            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", "Atención", ex);
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

        private void sucursalesManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de registros: " + sucursalesManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnPuntosVentas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (sucursalesManager_SearchResultBindingSource.Current == null) return;

            var f = new frmPuntosVentas(((SucursalesManager.SearchResult)sucursalesManager_SearchResultBindingSource.Current).Id_Empresa, ((SucursalesManager.SearchResult)sucursalesManager_SearchResultBindingSource.Current).Id);
            f.Show(this);
        }

    }
}
