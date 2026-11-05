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

    public partial class frmNovedadesCoches : MultiForm
    {
        private TipoNovedadesCochesManager.ParametrosBusquedas par = new TipoNovedadesCochesManager.ParametrosBusquedas();

        public frmNovedadesCoches()
        {
            InitializeComponent();
        }

        private void frmNovedades_Load(object sender, EventArgs e)
        {
            tipoNovedadesManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "NovedadesCoches", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void tipoNovedadesManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + tipoNovedadesManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "NovedadesCoches", Enums.Accion.Buscar)) return;

                Validate();
                tipoNovedadesManager_SearchResultBindingSource.DataSource = TipoNovedadesCochesManager.Buscar(par);
            }
            catch (ValidationException exv)
            {
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
            }
        }
        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "NovedadesCoches", Enums.Accion.Agregar)) return;

            TipoNovedadesCoches o = new TipoNovedadesCoches();
            var f = new frmNovedadesCochesAddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                tipoNovedadesManager_SearchResultBindingSource.Add(TipoNovedadesCochesManager.Buscar(new TipoNovedadesCochesManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "NovedadesCoches", Enums.Accion.Modificar)) return;

                if (tipoNovedadesManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (TipoNovedadesCochesManager.SearchResult)tipoNovedadesManager_SearchResultBindingSource.Current;
                    var f = new frmNovedadesCochesAddMod(new TipoNovedadesCoches() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        tipoNovedadesManager_SearchResultBindingSource[tipoNovedadesManager_SearchResultBindingSource.Position] = TipoNovedadesCochesManager.Buscar(new TipoNovedadesCochesManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        tipoNovedadesManager_SearchResultBindingSource.ResetCurrentItem();
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
                Sistema.MensajeError( ex);
            }
        }

        private void Eliminar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "NovedadesCoches", Enums.Accion.Eliminar)) return;

                if (tipoNovedadesManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    TipoNovedadesCochesManager.Eliminar(new TipoNovedadesCoches() { Id = ((TipoNovedadesCochesManager.SearchResult)tipoNovedadesManager_SearchResultBindingSource.Current).Id });
                    tipoNovedadesManager_SearchResultBindingSource.RemoveCurrent();
                    tipoNovedadesManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError( ex);
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
    }
}
