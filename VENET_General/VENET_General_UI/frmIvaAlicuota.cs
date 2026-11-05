namespace VENET_General_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmIvaAlicuota : MultiForm
    {
        IvaAlicuotaManager.ParametrosBusquedas par = new IvaAlicuotaManager.ParametrosBusquedas();

        public frmIvaAlicuota()
        {
            InitializeComponent();
        }

        private void frmIvaAlicuota_Load(object sender, EventArgs e)
        {
            ivaAlicuotaManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "AlicuotaIva", Enums.Accion.Imprimir)) return;
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

        private void ivaAlicuotaManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + ivaAlicuotaManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "IvaAlicuota", Enums.Accion.Buscar)) return;

                Validate();
                ivaAlicuotaManager_SearchResultBindingSource.DataSource = IvaAlicuotaManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "IvaAlicuota", Enums.Accion.Agregar)) return;

            IvaAlicuotas o = new IvaAlicuotas();
            var f = new frmIvaAlicuota_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ivaAlicuotaManager_SearchResultBindingSource.Add(IvaAlicuotaManager.Buscar(new IvaAlicuotaManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "IvaAlicuota", Enums.Accion.Modificar)) return;

                if (ivaAlicuotaManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (IvaAlicuotaManager.SearchResult)ivaAlicuotaManager_SearchResultBindingSource.Current;
                    var f = new frmIvaAlicuota_AddMod(new IvaAlicuotas() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        ivaAlicuotaManager_SearchResultBindingSource[ivaAlicuotaManager_SearchResultBindingSource.Position] = IvaAlicuotaManager.Buscar(new IvaAlicuotaManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        ivaAlicuotaManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "IvaAlicuota", Enums.Accion.Eliminar)) return;

                if (ivaAlicuotaManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    IvaAlicuotaManager.Eliminar(new IvaAlicuotas() { Id = ((IvaAlicuotaManager.SearchResult)ivaAlicuotaManager_SearchResultBindingSource.Current).Id });
                    ivaAlicuotaManager_SearchResultBindingSource.RemoveCurrent();
                    ivaAlicuotaManager_SearchResultBindingSource.ResetBindings(false);
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

       
    }
}
