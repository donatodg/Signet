namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmEntidadesImpuestosAlicuotas : MultiForm, IDisposable
    {
        private EntidadesImpuestosAlicuotasManager manager;

        public frmEntidadesImpuestosAlicuotas(EntidadesImpuestoAlicuotas o)
        {
            InitializeComponent();
            manager = new EntidadesImpuestosAlicuotasManager(o);
            Text = string.Format("Alicuotas Entidad: {0} - {1}", o.Id_Entidad, Sistema.GetNombreEntidad(o.Id_TipoEntidad, o.Id_Entidad));
        }

        private void frmEntidadesImpuestosAlicuotas_Load(object sender, EventArgs e)
        {
            try
            {
                entidadesImpuestosAlicuotasManager_SearchResultBindingSource.DataSource = manager.Buscar();
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

        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Agregar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Eliminar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "EntidadesImpuestosAlicuotas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void entidadesImpuestosAlicuotasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + entidadesImpuestosAlicuotasManager_SearchResultBindingSource.Count.ToString();
        }

        private void frmEntidadesImpuestosAlicuotas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (manager != null) manager.Dispose();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "EntidadesImpuestosAlicuotas", Enums.Accion.Agregar)) return;

            EntidadesImpuestoAlicuotas o = new EntidadesImpuestoAlicuotas() { Id_TipoEntidad = manager.EntidadAlicuota.Id_TipoEntidad, Id_Entidad = manager.EntidadAlicuota.Id_Entidad };
            var f = new frmEntidadesImpuestosAlicuotas_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                entidadesImpuestosAlicuotasManager_SearchResultBindingSource.DataSource = manager.Buscar();
            }
            f.Dispose();
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "EntidadesImpuestosAlicuotas", Enums.Accion.Eliminar)) return;

                if (entidadesImpuestosAlicuotasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    EntidadesImpuestosAlicuotasManager.Eliminar(new EntidadesImpuestoAlicuotas() { Id = ((EntidadesImpuestosAlicuotasManager.SearchResult)entidadesImpuestosAlicuotasManager_SearchResultBindingSource.Current).Id });
                    entidadesImpuestosAlicuotasManager_SearchResultBindingSource.RemoveCurrent();
                    entidadesImpuestosAlicuotasManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}
