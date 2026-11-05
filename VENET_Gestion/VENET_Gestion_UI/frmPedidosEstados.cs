namespace VENET_Gestion_UI
{
    using DevExpress.XtraSplashScreen;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Gestion_BL;

    public partial class frmPedidosEstados : MultiForm
    {
        int _Id_Pedido;
        PedidosEstadosManager manager;

        public frmPedidosEstados(int Id_Pedido)
        {
            InitializeComponent();
            _Id_Pedido = Id_Pedido;
            manager = new PedidosEstadosManager(Id_Pedido);
        }

        private void frmPedidosEstados_Load(object sender, EventArgs e)
        {
            try
            {
                //pedidosEstadosManager_SearchResultBindingSource.DataSource = PedidosEstadosManager.Buscar(_Id_Pedido);
                pedidosEstadosManager_SearchResultBindingSource.DataSource = manager.PedidosList;

                repositoryItemLookUpEditPersonal.DataSource = manager.Personal;
                repositoryItemLookUpEditPersonal.DisplayMember = "Descripcion";
                repositoryItemLookUpEditPersonal.ValueMember = "Id";

                if (manager.PedidosList.Where(t => t.UserDel == null && t.FechaEntregado == null).Count() == 0)
                {
                    barSubItemOperaciones.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnAsignaPersonal.Enabled = false;
                    btnCumplimiento.Enabled = false;
                    btnEntregar.Enabled = false;
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

        private void ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                (sender as DevExpress.XtraEditors.LookUpEdit).CancelPopup();
                ((DevExpress.XtraEditors.LookUpEdit)sender).EditValue = null;
            }
        }

        private void ButtonPressedFecha(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((DevExpress.XtraEditors.DateEdit)sender).EditValue = null;
            }
        }

        private void Guardar()
        {
            try
            {
                Validate();

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Validando y Almacenando los cambios...");

                manager.Save();

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

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PedidosEstados", Enums.Accion.Modificar)) return;

                Guardar();
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

        private void btnAsignaPersonal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PedidosEstados", Enums.Accion.Modificar)) return;

                frmPedidosEstadosPersonal f = new frmPedidosEstadosPersonal(_Id_Pedido);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    manager = new PedidosEstadosManager(_Id_Pedido);
                    pedidosEstadosManager_SearchResultBindingSource.DataSource = manager.PedidosList;
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

        private void btnCumplimiento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PedidosEstados", Enums.Accion.Modificar)) return;

                frmPedidoEstadoCumplimiento f = new frmPedidoEstadoCumplimiento();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    PedidosEstadosManager.Cumplimiento(_Id_Pedido, f.Avance);

                    manager = new PedidosEstadosManager(_Id_Pedido);
                    pedidosEstadosManager_SearchResultBindingSource.DataSource = manager.PedidosList;
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

        private void btnEntregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Gestion, "PedidosEstados", Enums.Accion.Operaciones, "Entregar Pedido")) return;

                DateTime Fecha = Sistema.ObtenerFecha();
                frmFecha f = new frmFecha(Fecha, null, Fecha);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    PedidosEstadosManager.Entregar(_Id_Pedido, f.Fecha);

                    manager = new PedidosEstadosManager(_Id_Pedido);
                    pedidosEstadosManager_SearchResultBindingSource.DataSource = manager.PedidosList;
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

    }
}
