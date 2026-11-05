namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmSucursales : MultiForm
    {
        // SucursalesManager.ParametrosBusquedas par = new SucursalesManager.ParametrosBusquedas();
        SucursalesManager manager = new SucursalesManager();

        public frmSucursales()
        {
            InitializeComponent();
        }

        public frmSucursales(Int32 Id_Empresa)
        {
            InitializeComponent();
            manager.Parametros.Id_Empresa = Id_Empresa;
            Buscar();
        }

        private void frmSucursales_Load(object sender, EventArgs e)
        {
            sucursalesManager_ParametrosBusquedasBindingSource.DataSource = manager.Parametros;

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Sucursales", Enums.Accion.Buscar)) return;

                Validate();
                manager.Buscar();
                sucursalesManager_SearchResultBindingSource.DataSource = manager.Resultado;
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
                    if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Sucursales", Enums.Accion.Agregar)) return;

                    Validate();

                    var o = new Sucursales();
                    var frm = new frmSucursales_AddMod(o);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        //sucursalesManager_SearchResultBindingSource.Add(SucursalesManager.Buscar(new SucursalesManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());

                        // manager.Parametros = new SucursalesManager.ParametrosBusquedas() { Id = o.Id };
                        manager.Buscar(o.Id);
                        //manager.Parametros = new SucursalesManager.ParametrosBusquedas();
                        sucursalesManager_SearchResultBindingSource.Add(manager.Resultado.SingleOrDefault());
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Sucursales", Enums.Accion.Modificar)) return;

                if (sucursalesManager_SearchResultBindingSource.Current == null) return;
                
                var curr = (SucursalesManager.SearchResult)sucursalesManager_SearchResultBindingSource.Current;
                var frm = new frmSucursales_AddMod(new Sucursales() { Id = curr.Id });
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    //sucursalesManager_SearchResultBindingSource[sucursalesManager_SearchResultBindingSource.Position] = SucursalesManager.Buscar(new SucursalesManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();

                    //manager.Parametros = new SucursalesManager.ParametrosBusquedas() { Id = curr.Id };
                    manager.Buscar(curr.Id);
                    sucursalesManager_SearchResultBindingSource[sucursalesManager_SearchResultBindingSource.Position] = manager.Resultado.SingleOrDefault();

                    sucursalesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Sucursales", Enums.Accion.Eliminar)) return;

                if (sucursalesManager_SearchResultBindingSource.Current == null) return;


                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    SucursalesManager.Eliminar(new Sucursales() { Id = ((SucursalesManager.SearchResult)sucursalesManager_SearchResultBindingSource.Current).Id });
                    sucursalesManager_SearchResultBindingSource.RemoveCurrent();
                    sucursalesManager_SearchResultBindingSource.ResetBindings(false);
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

        private void sucursalesManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + sucursalesManager_SearchResultBindingSource.Count.ToString();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Sucursales", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnPuntosVentas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Sucursales", Enums.Accion.Ver, "Ver Puntos de Ventas")) return;
            if (sucursalesManager_SearchResultBindingSource.Current == null) return;

            var f = new frmPuntosVentas(((SucursalesManager.SearchResult)sucursalesManager_SearchResultBindingSource.Current).Id_Empresa, ((SucursalesManager.SearchResult)sucursalesManager_SearchResultBindingSource.Current).Id);
            f.Show(this);
        }

    }
}
