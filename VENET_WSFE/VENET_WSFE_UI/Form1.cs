using System;
using System.Windows.Forms;
using VENET_Common;
using VENET_DataEntity;
using VENET_WSFE_BL;

namespace VENET_WSFE_UI
{
    public partial class Form1 : Form
    {
        LoginTicket objTicketRespuesta = new LoginTicket();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ObtenerTicket();
        }

        private void ObtenerTicket()
        {
            //Conexion
            DbConexion s = new DbConexion("localhost", "Ersa", "Ersa2015", "sa", "System.Data.SqlClient", "Local");


            string strTicketRespuesta = "";

            try
            {
                strTicketRespuesta = objTicketRespuesta.ObtenerTicket(8);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //bool Respuesta;
                ComprobantesVentas Respuesta;

                //Presentación
                //WSFEv1
                //testing: https://wswhomo.afip.gov.ar/wsfev1/service.asmx
                //producción: https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL

                //string strUrlWsfeWsdl = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx";

                if (objTicketRespuesta.ExpirationTime > DateTime.Now)
                {
                    Respuesta = objTicketRespuesta.PresentarComprobante(objTicketRespuesta, 35);
                }
                else
                {
                    ObtenerTicket();
                    Respuesta = objTicketRespuesta.PresentarComprobante(objTicketRespuesta, 35);
                }

                if (Respuesta.ResultadoCAE == "A")
                    Sistema.Mensaje(":) - TODO OK -- " + Respuesta.ResultadoCAE);
                else
                    Sistema.Mensaje(":( - ERROR -- " + Respuesta.ObservacionesCAE);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
