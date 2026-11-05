namespace VENET_Personal_UI
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
    using VENET_Personal_BL;

    public partial class frmPersonal : MultiForm
    {
        private PersonalManager.ParametrosBusquedas par = new PersonalManager.ParametrosBusquedas();
        public frmPersonal()
        {
            InitializeComponent();
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            try
            {
                personalManager_ParametrosBusquedasBindingSource.DataSource = par;

                id_EmpresaLookUpEdit.Properties.DataSource = par.Empresas;
                id_EmpresaLookUpEdit.Properties.DisplayMember = "Name";
                id_EmpresaLookUpEdit.Properties.ValueMember = "Key";

                id_TipoDocLookUpEdit.Properties.DataSource = par.TipoDoc;
                id_TipoDocLookUpEdit.Properties.DisplayMember = "Name";
                id_TipoDocLookUpEdit.Properties.ValueMember = "Key";

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Personal_VerMenuOperaciones)))
                    MnuOperaciones.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Menu_Configuracion_TiposImpuestos)))
                    btnImpuestos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (!Convert.ToBoolean(Parametro.ObtenerValor(Parametro.Param.Personal_VerImportacionSisorg)))
                {
                    btnPersonalSisorg.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnActualizaDesdeSisorg.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Modalidad();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modalidad();
        }

        private void personalManager_SearchResultBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            barStaticItemFooter.Caption = "Cantidad de Registros: " + personalManager_SearchResultBindingSource.Count.ToString();
        }

        private void Modalidad()
        {
            if (personalManager_SearchResultBindingSource.Current == null) return;

            IForm formInterface = Owner as IForm;

            if (formInterface != null)
            {
                formInterface.IdSeleccionado(((PersonalManager.SearchResult)personalManager_SearchResultBindingSource.Current).Id);
                Close();
            }
            else
                Modificar();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Buscar)) return;

                Validate();

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Buscando registros...");

                personalManager_SearchResultBindingSource.DataSource = PersonalManager.Buscar(par);

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

        private void Agregar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Agregar)) return;

                Validate();

                if (par.Id_Empresa == 0) throw new ValidationException("Debe selccionar una empresa.");

                var o = new Personal() { Id_Empresa = par.Id_Empresa };
                var frm = new frmPersonal_AddMod(o);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    personalManager_SearchResultBindingSource.Add(PersonalManager.Buscar(new PersonalManager.ParametrosBusquedas() { Id = o.Id }).SingleOrDefault());
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

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Modificar)) return;

                if (personalManager_SearchResultBindingSource.Current == null) return;

                var curr = (PersonalManager.SearchResult)personalManager_SearchResultBindingSource.Current;
                var frm = new frmPersonal_AddMod(new Personal() { Id = curr.Id });
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    personalManager_SearchResultBindingSource[personalManager_SearchResultBindingSource.Position] = PersonalManager.Buscar(new PersonalManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    personalManager_SearchResultBindingSource.ResetCurrentItem();
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
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Eliminar)) return;

                if (personalManager_SearchResultBindingSource.Current == null) return;

                if (Sistema.MensajeSiNo("¿Desea Eliminar el Item Seleccionado?", "Atención..."))
                {
                    PersonalManager.Eliminar(new Personal() { Id = ((PersonalManager.SearchResult)personalManager_SearchResultBindingSource.Current).Id });
                    personalManager_SearchResultBindingSource.RemoveCurrent();
                    personalManager_SearchResultBindingSource.ResetBindings(false);
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

        private void personalManager_SearchResultBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
                Sistema.MensajeError(e.Exception);
        }

        private void btnDireccionMapa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Ver, "Ver Dirección en Mapa")) return;

                if (personalManager_SearchResultBindingSource.Current == null) return;

                var curr = (PersonalManager.SearchResult)personalManager_SearchResultBindingSource.Current;

                if (string.IsNullOrEmpty(curr.DomicilioCalle))
                    Sistema.Mensaje("No posee una dirección cargada");
                else
                {
                    string Direccion = "https://maps.google.com.ar/maps?q=" + curr.DomicilioCalle.Trim() + " " + curr.DomicilioNro + ", " + curr.DomicilioProvincia;
                    System.Diagnostics.Process.Start(Direccion);
                }
                //frmBrowser f = new frmBrowser(Direccion, Enums.ContenidoBrowser.Direccion);
                //f.ShowDialog(this);

            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void btnImportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Operaciones, "Importar Excel con Configuración")) return;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Excel|*.xlsx";
                openFileDialog1.Title = "Seleccione el archivo con la configuración";
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Importando Configuración desde Excel");

                    PersonalManager.ImportarExcel(openFileDialog1.FileName);

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

        private void btnGenerarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Operaciones, "Generar Plantilla Excel con Configuración")) return;

                PersonalManager.GenerarModeloExcel();
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

        private void btnImpuestos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "Personal", Enums.Accion.Ver, "Ver Impuestos Asignadas")) return;

                if (personalManager_SearchResultBindingSource.Current == null) return;

                //var frm = new VENET_Gestion_UI.frmEntidadesImpuestosAlicuotas(new EntidadesImpuestoAlicuotas() { Id_TipoEntidad = Enums.TipoEntidad.Personal, Id_Entidad = ((PersonalManager.SearchResult)personalManager_SearchResultBindingSource.Current).Id });
                //frm.ShowDialog(this);
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

        private void btnCambioEmpresa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Operaciones, "Cambio de Empresa")) return;

                if (personalManager_SearchResultBindingSource.Current == null) return;

                var curr = (PersonalManager.SearchResult)personalManager_SearchResultBindingSource.Current;
                var frm = new frmPersonalEmpresas(new Personal() { Id = curr.Id });
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    personalManager_SearchResultBindingSource[personalManager_SearchResultBindingSource.Position] = PersonalManager.Buscar(new PersonalManager.ParametrosBusquedas() { Id = curr.Id }).SingleOrDefault();
                    personalManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnPersonalSisorg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Operaciones, "Importar Personal a Sisorg")) return;

                //var frm = new VENET_Personal_Sisorg.frmWebServicesSisorg();
                //frm.ShowDialog(this);
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

        private void btnActualizaDesdeSisorg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Operaciones, "Actualizar Legajos Personal desde Sisorg")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Actualizando Legajos de Sisorg.");

                VENET_Personal_Sisorg.WebServicesSisorg.ActualizarIdsEmpleados();

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

        private void btnImportarExcelLicencias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Operaciones, "Importar Excel con Configuración Vencimientos")) return;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Excel|*.xlsx";
                openFileDialog1.Title = "Seleccione el archivo con la configuración";
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Importando Configuración desde Excel");

                    PersonalManager.ImportarExcelVencimientos(openFileDialog1.FileName);

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

        private void btnGenerarExcelLicencias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Personal, "Personal", Enums.Accion.Operaciones, "Generar Plantilla Excel con Configuración Vencimientos")) return;

                PersonalManager.GenerarModeloExcelVencimientos();
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
