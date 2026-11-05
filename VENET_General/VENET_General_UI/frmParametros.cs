namespace VENET_General_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_DataEntity;
    using VENET_General_BL;

    public partial class frmParametros : MultiForm
    {
        public frmParametros()
        {
            InitializeComponent();
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                parametrosManager_SearchResultBindingSource.DataSource = ParametrosManager.Buscar(new ParametrosManager.ParametrosBusquedas());
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Parametros", Enums.Accion.Modificar)) return;

                if (parametrosManager_SearchResultBindingSource.Current == null) return;
                {
                    var curr = (ParametrosManager.SearchResult)parametrosManager_SearchResultBindingSource.Current;
                    var f = new frmParametros_AddMod(new Parametros() { Nombre = curr.Nombre, Descripcion = curr.Descripcion, TipoDato = curr.TipoDato, Valor = curr.Valor });
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        parametrosManager_SearchResultBindingSource[parametrosManager_SearchResultBindingSource.Position] = ParametrosManager.Buscar(new ParametrosManager.ParametrosBusquedas() { Nombre = curr.Nombre }).SingleOrDefault();
                        parametrosManager_SearchResultBindingSource.ResetCurrentItem();
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

        private void btnGrabaTodos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.General, "Parametros", Enums.Accion.Operaciones, "Grabar Todos los Parámetros")) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Grabando Parametros");

                //GRABA TODOS LOS PARAMETROS
                foreach (Parametro.Param s in Enum.GetValues(typeof(Parametro.Param)))
                    Parametro.ObtenerValor(s);

                SplashScreenManager.CloseForm(false);

                Parametro.Reload();
                Buscar();
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
