namespace VENET_Contabilidad_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Contabilidad_BL;

    public partial class frmPlanDeCuentas : MultiForm
    {
        PlanDeCuentasManager.ParametrosBusquedas par = new PlanDeCuentasManager.ParametrosBusquedas();

        public frmPlanDeCuentas()
        {
            InitializeComponent();
            var centroContable = new System.Windows.Forms.Button { Text = "Contabilidad parametrizable", AutoSize = true, Dock = System.Windows.Forms.DockStyle.Bottom };
            centroContable.Click += (s, e) =>
            {
                try { new frmContabilidad().Show(this); }
                catch (ValidationException ex) { Sistema.Mensaje(ex.Message); }
                catch (Exception ex) { Sistema.MensajeError(ex); }
            };
            Controls.Add(centroContable);
        }

        private void frmPlanDeCuentas_Load(object sender, EventArgs e)
        {
            planDeCuentasManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PlanDeCuentas", Enums.Accion.Imprimir)) return;
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

        private void planDeCuentasManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + planDeCuentasManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PlanDeCuentas", Enums.Accion.Buscar)) return;

                Validate();
                planDeCuentasManager_SearchResultBindingSource.DataSource = PlanDeCuentasManager.Buscar(par);
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PlanDeCuentas", Enums.Accion.Agregar)) return;

            CuentasContables o = new CuentasContables();
            var f = new frmPlanDeCuentas_AddMod(o);
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                planDeCuentasManager_SearchResultBindingSource.Add(PlanDeCuentasManager.Buscar(new PlanDeCuentasManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
            }
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PlanDeCuentas", Enums.Accion.Modificar)) return;

                if (planDeCuentasManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (PlanDeCuentasManager.SearchResult)planDeCuentasManager_SearchResultBindingSource.Current;
                    var f = new frmPlanDeCuentas_AddMod(new CuentasContables() { Id = curr.Id });
                    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        planDeCuentasManager_SearchResultBindingSource[planDeCuentasManager_SearchResultBindingSource.Position] = PlanDeCuentasManager.Buscar(new PlanDeCuentasManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                        planDeCuentasManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PlanDeCuentas", Enums.Accion.Eliminar)) return;

                if (planDeCuentasManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    PlanDeCuentasManager.Eliminar(new CuentasContables() { Id = ((PlanDeCuentasManager.SearchResult)planDeCuentasManager_SearchResultBindingSource.Current).Id });
                    planDeCuentasManager_SearchResultBindingSource.RemoveCurrent();
                    planDeCuentasManager_SearchResultBindingSource.ResetBindings(false);
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
