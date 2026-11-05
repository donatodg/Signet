namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Gestion_BL;

    public partial class frmComprobantesVentasAProcesar : MultiForm
    {
        private ComprobantesVentasAProcesarManager.ParametrosBusquedas par = new ComprobantesVentasAProcesarManager.ParametrosBusquedas();

        public frmComprobantesVentasAProcesar()
        {
            InitializeComponent();
        }

        private void frmComprobantesVentasAProcesar_Load(object sender, EventArgs e)
        {
            tipoEntidadLookUpEdit.Properties.DataSource = Enums.ToList(typeof(Enums.TipoEntidad));
            tipoEntidadLookUpEdit.Properties.DisplayMember = "Value";
            tipoEntidadLookUpEdit.Properties.ValueMember = "Key";

            comprobantesVentasAProcesarManager_ParametrosBusquedasBindingSource.DataSource = par;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentasAProcesar", Enums.Accion.Imprimir)) return;
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

        private void comprobantesVentasAProcesarManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + comprobantesVentasAProcesarManager_SearchResultBindingSource.Count.ToString();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentasAProcesar", Enums.Accion.Buscar)) return;
                Validate();
                comprobantesVentasAProcesarManager_SearchResultBindingSource.DataSource = ComprobantesVentasAProcesarManager.Buscar(par);
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
            Validate();
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentasAProcesar", Enums.Accion.Agregar)) return;

            ComprobantesVentasAProcesar o = new ComprobantesVentasAProcesar() { };
            var f = new frmComprobantesVentasAProcesar_AddMod(o);
            if (f.ShowDialog(this) == DialogResult.OK)
                comprobantesVentasAProcesarManager_SearchResultBindingSource.Add(ComprobantesVentasAProcesarManager.Buscar(new ComprobantesVentasAProcesarManager.ParametrosBusquedas() { Id = o.Id }).FirstOrDefault());
            f.Dispose();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentasAProcesar", Enums.Accion.Modificar)) return;
                if (comprobantesVentasAProcesarManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ComprobantesVentasAProcesarManager.SearchResult)comprobantesVentasAProcesarManager_SearchResultBindingSource.Current;
                    var f = new frmComprobantesVentasAProcesar_AddMod(new ComprobantesVentasAProcesar() { Id = curr.Id });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        comprobantesVentasAProcesarManager_SearchResultBindingSource[comprobantesVentasAProcesarManager_SearchResultBindingSource.Position] = ComprobantesVentasAProcesarManager.Buscar(new ComprobantesVentasAProcesarManager.ParametrosBusquedas() { Id = curr.Id }).FirstOrDefault();
                        comprobantesVentasAProcesarManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "ComprobantesVentasAProcesar", Enums.Accion.Eliminar)) return;
                if (comprobantesVentasAProcesarManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    ComprobantesVentasAProcesarManager.Eliminar(new ComprobantesVentasAProcesar() { Id = ((ComprobantesVentasAProcesarManager.SearchResult)comprobantesVentasAProcesarManager_SearchResultBindingSource.Current).Id });
                    comprobantesVentasAProcesarManager_SearchResultBindingSource.RemoveCurrent();
                    comprobantesVentasAProcesarManager_SearchResultBindingSource.ResetBindings(false);
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

        private void btnProcesarPendientes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "ComprobantesVentasAProcesar", Enums.Accion.Operaciones, "Procesar pendientes")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Procesando pendientes hasta la fecha");

                ComprobantesVentasAProcesarManager.ProcesarPendientes();

                Buscar();

                SplashScreenManager.CloseForm(false);
            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }

        private void btnImportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "ComprobantesVentasAProcesar", Enums.Accion.Operaciones, "Importar Excel con Configuración")) return;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Excel|*.xlsx";
                openFileDialog1.Title = "Seleccione el archivo con la configuración";
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Importando Configuración desde Excel");

                    ComprobantesVentasAProcesarManager.ImportarExcel(openFileDialog1.FileName);

                    Buscar();

                    SplashScreenManager.CloseForm(false);
                }
            }
            catch (ValidationException exv)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.Mensaje(exv.Message);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Sistema.MensajeError(ex);
            }
        }

        private void btnGenerar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "ComprobantesVentasAProcesar", Enums.Accion.Operaciones, "Generar Plantilla Excel con Configuración")) return;

                ComprobantesVentasAProcesarManager.GenerarModeloExcel();
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

      
    }
}
