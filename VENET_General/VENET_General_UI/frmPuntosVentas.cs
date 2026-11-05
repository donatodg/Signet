namespace VENET_General_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmPuntosVentas : MultiForm
    {
        PuntosVentaManager.ParametrosBusquedas par = new PuntosVentaManager.ParametrosBusquedas();

        public frmPuntosVentas()
        {
            InitializeComponent();
        }

        public frmPuntosVentas(Int32 IdEmpresa, Int32 IdSucursal)
        {
            InitializeComponent();
            par.Id_Empresa = IdEmpresa;
            par.Id_Sucursal = IdSucursal;
            Buscar();
        }

        private void frmPuntosVentas_Load(object sender, EventArgs e)
        {
            puntosVentaManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_EmpresaLookUpEdit.Properties.DataSource = Sistema.Empresas;
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

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "PuntosVentas", Enums.Accion.Imprimir)) return;

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

        private void puntosVentaManager_SearchResultBindingSource_ListChanged_1(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + puntosVentaManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "PuntosVentas", Enums.Accion.Buscar)) return;

                Validate();
                puntosVentaManager_SearchResultBindingSource.DataSource = PuntosVentaManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "PuntosVentas", Enums.Accion.Agregar)) return;

            PuntosVentas o = new PuntosVentas();
            var f = new frmPuntosVentas_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                puntosVentaManager_SearchResultBindingSource.Add(PuntosVentaManager.Buscar(new PuntosVentaManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "PuntosVentas", Enums.Accion.Modificar)) return;

                if (puntosVentaManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (PuntosVentaManager.SearchResult)puntosVentaManager_SearchResultBindingSource.Current;
                    var f = new frmPuntosVentas_AddMod(new PuntosVentas() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        puntosVentaManager_SearchResultBindingSource[puntosVentaManager_SearchResultBindingSource.Position] = PuntosVentaManager.Buscar(new PuntosVentaManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        puntosVentaManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "PuntosVentas", Enums.Accion.Eliminar)) return;

                if (puntosVentaManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    PuntosVentaManager.Eliminar(new PuntosVentas() { Id = ((PuntosVentaManager.SearchResult)puntosVentaManager_SearchResultBindingSource.Current).Id });
                    puntosVentaManager_SearchResultBindingSource.RemoveCurrent();
                    puntosVentaManager_SearchResultBindingSource.ResetBindings(false);
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
