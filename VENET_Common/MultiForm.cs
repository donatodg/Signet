namespace VENET_Common
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class MultiForm : DevExpress.XtraEditors.XtraForm
    {
        public new Form Owner { get; set; }
        public static Image ImagenFondo { get; set; }

        private static string _SkinName;
        public static string SkinName
        {
            get { return _SkinName; }
            set
            {
                if (value == "" || value == null) _SkinName = "Visual Studio 2013 Blue"; else _SkinName = value;
                Sistema.ActualizarTema(_SkinName);
            }
        }

        private List<string> ExcepcionEscape = new List<string>() { "Detalle de Planificación de Servicios", "Planificación Mensual Larga Distancia", "Equipos en Mapa" , "Historial de equipos en Mapa" };

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == 256)
                if ((Keys)m.WParam == Keys.Escape && !ExcepcionEscape.Contains((this).Text)) { Close(); }
            return base.ProcessKeyPreview(ref m);
        }

        public MultiForm()
        {
            InitializeComponent();
            LookAndFeel.SkinName = SkinName;
        }

        private void MultiForm_Load(object sender, EventArgs e)
        {
            try
            {
                //DevExpress.XtraEditors.WindowsFormsSettings.DefaultSettingsCompatibilityMode = DevExpress.XtraEditors.SettingsCompatibilityMode.v16;

                DevExpress.XtraGrid.GridControl gridView1 = Controls.Find("gridControl1", true).FirstOrDefault() as DevExpress.XtraGrid.GridControl;

                if (gridView1 != null)
                {
                    //((DevExpress.XtraGrid.Views.Grid.GridView)gridView1.Views[0]).OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;

                    

                    if (Text.Contains(":"))
                        gridView1.Views[0].RestoreLayoutFromRegistry("HKEY_CURRENT_USER\\Software\\" + Parametro.ObtenerValor(Parametro.Param.NombreRegedit) + "\\" + Text.Split(':')[0]);
                    else
                        gridView1.Views[0].RestoreLayoutFromRegistry("HKEY_CURRENT_USER\\Software\\" + Parametro.ObtenerValor(Parametro.Param.NombreRegedit) + "\\" + Text);
                }
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

        private void MultiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.GridControl gridView1 = Controls.Find("gridControl1", true).FirstOrDefault() as DevExpress.XtraGrid.GridControl;

                if (gridView1 != null)
                    if (Text.Contains(":"))
                        gridView1.Views[0].SaveLayoutToRegistry("HKEY_CURRENT_USER\\Software\\" + Parametro.ObtenerValor(Parametro.Param.NombreRegedit) + "\\" + Text.Split(':')[0]);
                    else
                        gridView1.Views[0].SaveLayoutToRegistry("HKEY_CURRENT_USER\\Software\\" + Parametro.ObtenerValor(Parametro.Param.NombreRegedit) + "\\" + Text);
            }
            catch (Exception ex)
            {
                Sistema.MensajeError(ex);
            }
        }

    }
}