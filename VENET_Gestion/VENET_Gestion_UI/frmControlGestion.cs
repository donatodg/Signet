namespace VENET_Gestion_UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using DevExpress.XtraSplashScreen;
    using System.Drawing;
    using System.Windows.Forms;
    using VENET_Common;
    using VENET_Gestion_BL;

    public partial class frmControlGestion : MultiForm
    {
        ControlGestionManager.ParametrosBusquedas par = new ControlGestionManager.ParametrosBusquedas();

        public frmControlGestion()
        {
            InitializeComponent();
        }

        private void frmControlGestion_Load(object sender, EventArgs e)
        {
            try
            {
                controlGestionManager_ParametrosBusquedasBindingSource.DataSource = par;
                this.listBox1.DrawMode = DrawMode.OwnerDrawVariable;
                this.listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();

                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Por Favor Espere");
                SplashScreenManager.Default.SetWaitFormDescription("Buscando Información");

                DataSet d = ControlGestionManager.Buscar(par);
                int i = 0;

                listBox1.Items.Clear();

                foreach (DataTable dt in d.Tables)
                {
                    i += 1;
                    switch (i)
                    {
                        //Comprobantes con iva = 0
                        case 1:
                            gridControl1.DataSource = dt;
                            listBox1.Items.Add("Comprobantes con IVA en 0: ");
                            listBox1.Items.Add("Se han encontrado " + dt.Rows.Count.ToString() + " registros.");
                            break;
                        //recibos sin liquidar
                        case 2:
                            gridControl2.DataSource = dt;
                            listBox1.Items.Add("");
                            listBox1.Items.Add("Recibos sin liquidar: ");
                            listBox1.Items.Add("Se han encontrado " + dt.Rows.Count.ToString() + " registros.");
                            break;
                        //OP sin liquidar
                        case 3:
                            gridControl3.DataSource = dt;
                            listBox1.Items.Add("");
                            listBox1.Items.Add("OP sin liquidar: ");
                            listBox1.Items.Add("Se han encontrado " + dt.Rows.Count.ToString() + " registros.");
                            break;
                        //Compras sin liquidar
                        case 4:
                            gridControl4.DataSource = dt;
                            listBox1.Items.Add("");
                            listBox1.Items.Add("Compras sin liquidar: ");
                            listBox1.Items.Add("Se han encontrado " + dt.Rows.Count.ToString() + " registros.");
                            break;
                        //Cheques vencidos
                        case 5:
                            gridControl5.DataSource = dt;
                            listBox1.Items.Add("");
                            listBox1.Items.Add("Cheques vencidos: ");
                            listBox1.Items.Add("Se han encontrado " + dt.Rows.Count.ToString() + " registros.");
                            break;
                        //Clientes Diferencias en Descuentos Configurados
                        case 6:
                            gridControl6.DataSource = dt;
                            listBox1.Items.Add("");
                            listBox1.Items.Add("Clientes Diferencias en Descuentos Configurados: ");
                            listBox1.Items.Add("Se han encontrado " + dt.Rows.Count.ToString() + " registros.");
                            break;
                        //Modificacion de Saldos Iniciales
                        case 7:
                            gridControl7.DataSource = dt;
                            listBox1.Items.Add("");
                            listBox1.Items.Add("Modificación de Saldos Iniciales: ");
                            listBox1.Items.Add("Se han encontrado " + dt.Rows.Count.ToString() + " registros.");
                            break;
                        //Electronicos en deposito 2
                        case 8:
                            gridControl8.DataSource = dt;
                            listBox1.Items.Add("");
                            listBox1.Items.Add("Electrónicos en otro depósito: ");
                            listBox1.Items.Add("Se han encontrado " + dt.Rows.Count.ToString() + " registros.");
                            break;
                    }
                }
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

        void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            Color c = Color.Pink;
            if (this.listBox1.Items[e.Index].ToString().Contains("registros"))
            {
                c = Color.Black;
                e.Graphics.DrawString(this.listBox1.Items[e.Index].ToString(), new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular), new SolidBrush(c), e.Bounds);
            }
            else
            {
                c = Color.Blue;
                e.Graphics.DrawString(this.listBox1.Items[e.Index].ToString(), new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold), new SolidBrush(c), e.Bounds);
            }


        }
    }
}
