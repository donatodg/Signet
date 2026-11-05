namespace VENET_Informes_UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.XtraSplashScreen;
    using VENET_Common;
    using VENET_Comun;
    using VENET_Informes_BL;

    public partial class frmReporteCochesComparativo : MultiForm
    {
        ReporteCochesComparativoManager.ParametrosBusquedas par = new ReporteCochesComparativoManager.ParametrosBusquedas();

        public frmReporteCochesComparativo()
        {
            InitializeComponent();
        }

        private void frmReporteCochesComparativo_Load(object sender, EventArgs e)
        {
            reporteCochesComparativoManager_ParametrosBusquedasBindingSource.DataSource = par;

            id_UnidadNegocioLookUpEdit.Properties.DataSource = par.UnidadesNegocios;
            id_UnidadNegocioLookUpEdit.Properties.DisplayMember = "Name";
            id_UnidadNegocioLookUpEdit.Properties.ValueMember = "Key";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnResultado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Seguridad.ObtenerPermiso(Enums.Modulos.Informes, "ReporteCochesComparativo", Enums.Accion.Imprimir)) return;
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Buscar()
        {
            try
            {
                if (!Seguridad.ObtenerPermiso(Enums.Modulos.Informes, "ReporteCochesComparativo", Enums.Accion.Buscar)) return;

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Preparando Informe...");

                List<ReporteCochesComparativoManager.Reporte> r = new ReporteCochesComparativoManager().Buscar(par);

                foreach (ReporteCochesComparativoManager.Reporte x in r)
                {
                    btnFlota.Text = "Flota\r\n" + x.TotalCoches;
                    btnPlanificados.Text = "Planificados\r\n" + x.CochesPlanificadosUtilizados;
                    btnParados.Text = "Parados\r\n" + x.CochesPlanificadosNoUtilizados;
                    btnEjecutados.Text = "Ejecutados\r\n" + x.Ejecutados;
                    btnTaller.Text = "Taller\r\n" + x.Taller;
                }

                btnFlota_Click(null, null);

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

        private void btnFlota_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = "Flota Completa";
                CambiaColorBotones(btnFlota);
                gridView1.Columns.Clear();
                gridControl1.DataSource = new ReporteCochesComparativoManager().BuscarFlota(par);
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

        private void btnPlanificados_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = "Flota Planificada";
                CambiaColorBotones(btnPlanificados);
                gridView1.Columns.Clear();
                gridControl1.DataSource = new ReporteCochesComparativoManager().BuscarPlanificados(par);
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

        private void btnParados_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = "Flota Planificada Sin Usar";
                CambiaColorBotones(btnParados);
                gridView1.Columns.Clear();
                gridControl1.DataSource = new ReporteCochesComparativoManager().BuscarParados(par);
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

        private void btnEjecutados_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = "Flota de Servicios Ejecutados";
                CambiaColorBotones(btnEjecutados);
                gridView1.Columns.Clear();
                gridControl1.DataSource = new ReporteCochesComparativoManager().BuscarEjecutados(par);
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

        private void btnTaller_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = "Flota En Taller";
                CambiaColorBotones(btnTaller);
                gridView1.Columns.Clear();
                gridControl1.DataSource = new ReporteCochesComparativoManager().BuscarTaller(par);
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

        private void CambiaColorBotones(System.Windows.Forms.Button btnPresionado)
        {
            btnFlota.BackColor = System.Drawing.Color.White;
            btnFlota.ForeColor = System.Drawing.Color.Black;

            btnPlanificados.BackColor = System.Drawing.Color.White;
            btnPlanificados.ForeColor = System.Drawing.Color.Black;

            btnParados.BackColor = System.Drawing.Color.White;
            btnParados.ForeColor = System.Drawing.Color.Black;

            btnEjecutados.BackColor = System.Drawing.Color.White;
            btnEjecutados.ForeColor = System.Drawing.Color.Black;

            btnTaller.BackColor = System.Drawing.Color.White;
            btnTaller.ForeColor = System.Drawing.Color.Black;

            btnPresionado.BackColor = System.Drawing.Color.MediumBlue;
            btnPresionado.ForeColor = System.Drawing.Color.WhiteSmoke;
        }

    }
}
