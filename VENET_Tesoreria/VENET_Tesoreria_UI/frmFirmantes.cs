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

    public partial class frmFirmantes : MultiForm 
    {
        private FirmantesManager.ParametrosBusquedas par = new FirmantesManager.ParametrosBusquedas();

        public frmFirmantes()
        {
            InitializeComponent();
        }

        private void frmFirmantes_Load(object sender, EventArgs e)
        {
            firmantesManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Firmantes", Enums.Accion.Imprimir)) return;
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

        private void firmantesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + firmantesManager_SearchResultBindingSource.Count.ToString();
        }
   
        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Firmantes", Enums.Accion.Buscar)) return;
                Validate();
                firmantesManager_SearchResultBindingSource.DataSource = FirmantesManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Firmantes", Enums.Accion.Agregar)) return;

            Firmantes o = new Firmantes();
            var f = new frmFirmantes_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                firmantesManager_SearchResultBindingSource.Add(FirmantesManager.Buscar(new FirmantesManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Firmantes", Enums.Accion.Modificar)) return;

                if (firmantesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (FirmantesManager.SearchResult)firmantesManager_SearchResultBindingSource.Current;
                    var f = new frmFirmantes_AddMod(new Firmantes() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        firmantesManager_SearchResultBindingSource[firmantesManager_SearchResultBindingSource.Position] = FirmantesManager.Buscar(new FirmantesManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        firmantesManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Firmantes", Enums.Accion.Eliminar)) return;

                if (firmantesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    FirmantesManager.Eliminar(new Firmantes() { Id = ((FirmantesManager.SearchResult)firmantesManager_SearchResultBindingSource.Current).Id });
                    firmantesManager_SearchResultBindingSource.RemoveCurrent();
                    firmantesManager_SearchResultBindingSource.ResetBindings(false);
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

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modificar();
        }
    }
}
