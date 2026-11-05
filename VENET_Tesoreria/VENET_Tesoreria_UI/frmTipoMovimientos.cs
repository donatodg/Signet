using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using VENET_Common;
using VENET_DataEntity;
using VENET_Tesoreria_BL;

namespace VENET_Tesoreria_UI
{
    public partial class frmTipoMovimientos : Form
    {
        private TipoMovimientosManager.ParametrosBusquedas par = new TipoMovimientosManager.ParametrosBusquedas();

        public frmTipoMovimientos()
        {
            InitializeComponent();
        }

        private void frmTipoMovimientos_Load(object sender, EventArgs e)
        {
            tipoMovimientosManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                this.Validate();
                tipoMovimientosManager_SearchResultBindingSource.DataSource = TipoMovimientosManager.Buscar(par);
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message, "Error en Tipo de Movimientos");
            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", "Atención", ex);
            }
        }
        private void Agregar()
        {
            TipoMovimiento o = new TipoMovimiento();
            var f = new frmTipoMovimientos_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                tipoMovimientosManager_SearchResultBindingSource.Add(TipoMovimientosManager.Buscar(new TipoMovimientosManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (tipoMovimientosManager_SearchResultBindingSource.Current == null) return;
                //  if (VPNET_Common_UI.Sistema.clsSeguridad.IsAllowedObject(ref Usuario, ".Modificar", "Permite Modificar", "Archivos."))
                {
                    var curr = (TipoMovimientosManager.SearchResult)tipoMovimientosManager_SearchResultBindingSource.Current;
                    var f = new frmTipoMovimientos_AddMod(new TipoMovimiento() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        tipoMovimientosManager_SearchResultBindingSource[tipoMovimientosManager_SearchResultBindingSource.Position] = TipoMovimientosManager.Buscar(new TipoMovimientosManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        tipoMovimientosManager_SearchResultBindingSource.ResetCurrentItem();
                    }
                    f.Dispose();
                }
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message, "Error en Tipo de Movimientos");
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
                if (tipoMovimientosManager_SearchResultBindingSource.Current == null) return;

                //if (VPNET_Common_UI.Sistema.clsSeguridad.IsAllowedObject(ref Usuario, "Beneficios.Nichos.Eliminar", "Permite Eliminar Nichos", "Archivos.Nichos"))
                //{

                if (Sistema.MensajeSiNo("Desea Eliminar el Item Seleccionado?", "Atención..."))
                // if (MessageBox.Show(this, "Desea Eliminar el Item Seleccionado?", "Atención...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TipoMovimientosManager.Eliminar(new TipoMovimiento() { Id = ((TipoMovimientosManager.SearchResult)tipoMovimientosManager_SearchResultBindingSource.Current).Id });
                    tipoMovimientosManager_SearchResultBindingSource.RemoveCurrent();
                    tipoMovimientosManager_SearchResultBindingSource.ResetBindings(false);
                }
                //}
            }
            catch (Exception ex)
            {
                Sistema.Mensaje("Se ha Producido un Error en la Aplicación. Avisar a Sistemas...", "Atención", ex);
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void tipoMovimientosManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + tipoMovimientosManager_SearchResultBindingSource.Count.ToString();
        }

    }
}
