namespace VENET_Produccion_Reports
{
    partial class xrptListaPrecio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer3 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.gridControlIda = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Empresa = new DevExpress.XtraReports.Parameters.Parameter();
            this.Linea = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer3});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 63.97916F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // winControlContainer3
            // 
            this.winControlContainer3.Dpi = 254F;
            this.winControlContainer3.LocationFloat = new DevExpress.Utils.PointFloat(24.54304F, 0F);
            this.winControlContainer3.Name = "winControlContainer3";
            this.winControlContainer3.SizeF = new System.Drawing.SizeF(1872.998F, 63.97916F);
            this.winControlContainer3.WinControl = this.gridControlIda;
            // 
            // gridControlIda
            // 
            this.gridControlIda.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlIda.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridControlIda.Location = new System.Drawing.Point(0, 0);
            this.gridControlIda.MainView = this.gridView3;
            this.gridControlIda.Name = "gridControlIda";
            this.gridControlIda.Size = new System.Drawing.Size(708, 24);
            this.gridControlIda.TabIndex = 2;
            this.gridControlIda.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControlIda;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView3.OptionsPrint.AutoWidth = false;
            this.gridView3.OptionsPrint.PrintFooter = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ReportHeader.BorderWidth = 1F;
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel27});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 155.34F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Empresa, "Text", "")});
            this.xrLabel27.Dpi = 254F;
            this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(25.58637F, 0F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(1396.164F, 58.42F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.Text = "xrLabel27";
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Dpi = 254F;
            this.topMarginBand1.HeightF = 51F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Dpi = 254F;
            this.bottomMarginBand1.HeightF = 63.49999F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.HeightF = 96.43751F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // Empresa
            // 
            this.Empresa.Name = "Empresa";
            this.Empresa.Visible = false;
            // 
            // Linea
            // 
            this.Linea.Name = "Linea";
            this.Linea.Visible = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Linea, "Text", "")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(25.12807F, 96.92004F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(968.375F, 58.41999F);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrptPlanillaViaje
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.ReportHeader,
            this.topMarginBand1,
            this.bottomMarginBand1,
            this.ReportFooter});
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(101, 101, 51, 63);
            this.PageHeight = 2970;
            this.PageWidth = 2100;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Empresa,
            this.Linea});
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer3;
        public DevExpress.XtraGrid.GridControl gridControlIda;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.Parameters.Parameter Linea;
        private DevExpress.XtraReports.Parameters.Parameter Empresa;
    }
}
