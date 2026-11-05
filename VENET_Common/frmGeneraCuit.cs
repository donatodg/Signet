using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace VENET_Common
{
    public partial class frmGeneraCuit : MultiForm
    {
        private bool Generado = false;
        public string Cuit = "";

        public frmGeneraCuit()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumento.Text.Length < 7)
                    Sistema.Mensaje("El largo del documento debe ser mayor a 6.");

                if (GenerarCuit())
                    txtCuit.Text = Cuit;
                else
                    txtCuit.Text = "";
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

        private bool GenerarCuit()
        {
            try
            {
                int x = 0;
                int y = 0;
                int z = 0;
                int Resultado = 0;
                int Resultado2 = 0;
                int Resultado3 = 0;

                if (rbHombre.Checked) { x = 2; y = 0; }
                if (rbMujer.Checked) { x = 2; y = 7; }
                if (rbSociedad.Checked) { x = 3; y = 0; }

                string Documento;

                if (txtDocumento.Text.Length == 7)
                    Documento = "0" + txtDocumento.Text;
                else
                    Documento = txtDocumento.Text;

                Resultado = x * 5;
                Resultado += y * 4;
                Resultado += Convert.ToInt32(Documento.Substring(0, 1)) * 3;
                Resultado += Convert.ToInt32(Documento.Substring(1, 1)) * 2;
                Resultado += Convert.ToInt32(Documento.Substring(2, 1)) * 7;
                Resultado += Convert.ToInt32(Documento.Substring(3, 1)) * 6;
                Resultado += Convert.ToInt32(Documento.Substring(4, 1)) * 5;
                Resultado += Convert.ToInt32(Documento.Substring(5, 1)) * 4;
                Resultado += Convert.ToInt32(Documento.Substring(6, 1)) * 3;
                Resultado += Convert.ToInt32(Documento.Substring(7, 1)) * 2;

                // Resultado2 = Convert.ToInt32(Math.Truncate(Convert.ToDecimal(Resultado / 11)));
                Resultado2 = Resultado % 11;

                //Resultado3 = Resultado - (Resultado2 * 11);
                Resultado3 = 11 - Resultado2;

                z = Resultado3;

                if (Resultado3 == 11)
                    z = 0;
                if (Resultado3 == 10)
                {
                    if (rbHombre.Checked) { y = 3; z = 9; }
                    if (rbMujer.Checked) { y = 3; z = 4; }
                    if (rbSociedad.Checked) { y = 3; z = 9; }
                }

                Cuit = x.ToString() + y.ToString() + "-" + Documento + "-" + z.ToString();

                return true;

            }
            catch (Exception)
            {
                Cuit = "";
                return false;
            }
        }

        private void btnAceptar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Cuit != "")
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

    }
}
