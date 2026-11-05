using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace VENET_Gestion_Reports
{
    public partial class xrptComprobanteVenta : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptComprobanteVenta()
        {
            InitializeComponent();
        }
         
        private void xrLabel33_BeforePrint(object sender, CancelEventArgs e)
        {
            if (xrLabel1.Text != "A")
            {

                xrRichText6.Visible = false;
                xrLabel32.Visible = false;

                xrLabel15.Visible = false;
                xrLabel34.Visible = false;

                xrLabel20.Visible = false;
                xrLabel35.Visible = false;

                xrLabel36.Visible = false;
                xrLabel37.Visible = false;

                xrLabel38.Visible = false;
                xrLabel39.Visible = false;

                xrLabel40.Visible = false;
                xrLabel41.Visible = false;
            }

            //if (xrLabel8.Text.Trim() == "")
            //{
            //    xrLabel8.Visible = false;
            //    xrRichText8.Visible = false;
            //    xrRichText9.Visible = false;
            //    xrBarCode1.Visible = false;
            //}
        }
    }
}
