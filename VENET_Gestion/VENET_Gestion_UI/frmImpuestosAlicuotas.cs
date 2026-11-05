namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmImpuestosAlicuotas : MultiForm
    {
        private int _Id_Impuesto;

        public frmImpuestosAlicuotas(int Id_Impuesto, string Impuesto)
        {
            InitializeComponent();
            _Id_Impuesto = Id_Impuesto;
            Text = "Alícuotas de Iva: " + _Id_Impuesto + " - " + Impuesto;
        }

        private void frmImpuestosAlicuotas_Load(object sender, EventArgs e)
        {
            try
            {
                impuestosAlicuotasManager_SearchResultBindingSource.DataSource = ImpuestosAlicuotasManager.Buscar(new ImpuestosAlicuotasManager.ParametrosBusquedas() { Id_Impuesto = _Id_Impuesto });
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ImpuestosAlicuotas", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Agregar()
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ImpuestosAlicuotas", Enums.Accion.Agregar)) return;

            ImpuestosAlicuotas o = new ImpuestosAlicuotas() { Id_Impuesto = _Id_Impuesto };
            var f = new frmImpuestosAlicuotas_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                impuestosAlicuotasManager_SearchResultBindingSource.Add(ImpuestosAlicuotasManager.Buscar(new ImpuestosAlicuotasManager.ParametrosBusquedas() { Id = o.Id, Id_Impuesto = _Id_Impuesto }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ImpuestosAlicuotas", Enums.Accion.Modificar)) return;

                if (impuestosAlicuotasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ImpuestosAlicuotasManager.SearchResult)impuestosAlicuotasManager_SearchResultBindingSource.Current;
                    var f = new frmImpuestosAlicuotas_AddMod(new ImpuestosAlicuotas() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        impuestosAlicuotasManager_SearchResultBindingSource[impuestosAlicuotasManager_SearchResultBindingSource.Position] = ImpuestosAlicuotasManager.Buscar(new ImpuestosAlicuotasManager.ParametrosBusquedas() { Id = curr.Id, Id_Impuesto = curr.Id_Impuesto }).SingleOrDefault();
                        impuestosAlicuotasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ImpuestosAlicuotas", Enums.Accion.Eliminar)) return;

                if (impuestosAlicuotasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ImpuestosAlicuotasManager.Eliminar(new ImpuestosAlicuotas() { Id = ((ImpuestosAlicuotasManager.SearchResult)impuestosAlicuotasManager_SearchResultBindingSource.Current).Id });
                    impuestosAlicuotasManager_SearchResultBindingSource.RemoveCurrent();
                    impuestosAlicuotasManager_SearchResultBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void impuestosAlicuotasManager_SearchResultBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + impuestosAlicuotasManager_SearchResultBindingSource.Count.ToString();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }
    }
}
