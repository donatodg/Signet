namespace VENET_Tesoreria_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_Tesoreria_BL;

    public partial class frmValesMasivo_AddMod : MultiForm, IDisposable
    {
        //private ValesManager manager;
        public List<Vales> ListaVales = new List<Vales>();
        private int _Id_Caja;

        public frmValesMasivo_AddMod(int Id_Caja)
        {
            InitializeComponent();
            _Id_Caja = Id_Caja;
            //manager = new ValesManager(new Vales());
        }

        private void frmValesMasivo_AddMod_Load(object sender, EventArgs e)
        {
            try
            {
                id_CentroCostoLookUpEdit.Properties.DataSource = Sistema.CentrosCostos;
                id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
                id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";

                id_CentroCostoLookUpEdit.ItemIndex = 0;
                //valesManagerBindingSource.DataSource = manager;
            }
            catch
            {
                Sistema.Mensaje("El usuario no posee centro de costos asignados.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Tesoreria, "ValesMasivo", Enums.Accion.Operaciones, "Importar Excel con Vales")) return;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Excel|*.xlsx";
                openFileDialog1.Title = "Seleccione el archivo con la configuración";
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                    SplashScreenManager.Default.SetWaitFormDescription("Importando Listado desde Excel");

                    ListaVales.Clear();
                    List<Vales> l = ValesManager.ImportarExcel(openFileDialog1.FileName);

                    foreach (Vales o in l)
                    {
                        ListaVales.Add(o);

                        gridControl1.DataSource = ListaVales;
                        gridControl1.RefreshDataSource();
                    }

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

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (id_CentroCostoLookUpEdit.EditValue == null)
                {
                    Sistema.Mensaje("Debe seleccionar un centro de costo.");
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Alamacenando Vales Pendientes");

                foreach (Vales o in ListaVales)
                {
                    ValesManager m = new ValesManager(o);

                    o.Id_CentroCosto = (int)id_CentroCostoLookUpEdit.EditValue;
                    o.Id_Caja = _Id_Caja;

                    m.Save();
                }

                SplashScreenManager.CloseForm(false);
                DialogResult = DialogResult.OK;
                Close();
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
    }
}
