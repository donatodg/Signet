namespace VENET_Informes_UI
{
    partial class frmReporteLibreta
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label id_EmpresaLabel;
            System.Windows.Forms.Label añoLabel;
            System.Windows.Forms.Label legajoHastaLabel;
            System.Windows.Forms.Label legajoDesdeLabel;
            System.Windows.Forms.Label mesLabel1;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.mesLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.reporteLibretaManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.legajoDesdeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.legajoHastaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.añoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_EmpresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_EmpresaLabel = new System.Windows.Forms.Label();
            añoLabel = new System.Windows.Forms.Label();
            legajoHastaLabel = new System.Windows.Forms.Label();
            legajoDesdeLabel = new System.Windows.Forms.Label();
            mesLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mesLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteLibretaManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.legajoDesdeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.legajoHastaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.añoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_EmpresaLabel
            // 
            id_EmpresaLabel.AutoSize = true;
            id_EmpresaLabel.Location = new System.Drawing.Point(33, 13);
            id_EmpresaLabel.Name = "id_EmpresaLabel";
            id_EmpresaLabel.Size = new System.Drawing.Size(52, 13);
            id_EmpresaLabel.TabIndex = 0;
            id_EmpresaLabel.Text = "Empresa:";
            // 
            // añoLabel
            // 
            añoLabel.AutoSize = true;
            añoLabel.Location = new System.Drawing.Point(55, 65);
            añoLabel.Name = "añoLabel";
            añoLabel.Size = new System.Drawing.Size(30, 13);
            añoLabel.TabIndex = 4;
            añoLabel.Text = "Año:";
            // 
            // legajoHastaLabel
            // 
            legajoHastaLabel.AutoSize = true;
            legajoHastaLabel.Location = new System.Drawing.Point(11, 117);
            legajoHastaLabel.Name = "legajoHastaLabel";
            legajoHastaLabel.Size = new System.Drawing.Size(74, 13);
            legajoHastaLabel.TabIndex = 8;
            legajoHastaLabel.Text = "Legajo Hasta:";
            // 
            // legajoDesdeLabel
            // 
            legajoDesdeLabel.AutoSize = true;
            legajoDesdeLabel.Location = new System.Drawing.Point(9, 91);
            legajoDesdeLabel.Name = "legajoDesdeLabel";
            legajoDesdeLabel.Size = new System.Drawing.Size(76, 13);
            legajoDesdeLabel.TabIndex = 9;
            legajoDesdeLabel.Text = "Legajo Desde:";
            // 
            // mesLabel1
            // 
            mesLabel1.AutoSize = true;
            mesLabel1.Location = new System.Drawing.Point(55, 39);
            mesLabel1.Name = "mesLabel1";
            mesLabel1.Size = new System.Drawing.Size(30, 13);
            mesLabel1.TabIndex = 10;
            mesLabel1.Text = "Mes:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnImprimir});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImprimir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Glyph = global::VENET_Informes_UI.Properties.Resources.print_16x16;
            this.btnImprimir.Id = 0;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(368, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 192);
            this.barDockControlBottom.Size = new System.Drawing.Size(368, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 168);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(368, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 168);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(mesLabel1);
            this.groupControl1.Controls.Add(this.mesLookUpEdit);
            this.groupControl1.Controls.Add(legajoDesdeLabel);
            this.groupControl1.Controls.Add(this.legajoDesdeTextEdit);
            this.groupControl1.Controls.Add(legajoHastaLabel);
            this.groupControl1.Controls.Add(this.legajoHastaTextEdit);
            this.groupControl1.Controls.Add(añoLabel);
            this.groupControl1.Controls.Add(this.añoTextEdit);
            this.groupControl1.Controls.Add(id_EmpresaLabel);
            this.groupControl1.Controls.Add(this.id_EmpresaLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(344, 154);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // mesLookUpEdit
            // 
            this.mesLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reporteLibretaManagerBindingSource, "Mes", true));
            this.mesLookUpEdit.Location = new System.Drawing.Point(91, 36);
            this.mesLookUpEdit.MenuManager = this.barManager1;
            this.mesLookUpEdit.Name = "mesLookUpEdit";
            this.mesLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mesLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name2")});
            this.mesLookUpEdit.Properties.NullText = "";
            this.mesLookUpEdit.Properties.ShowHeader = false;
            this.mesLookUpEdit.Size = new System.Drawing.Size(156, 20);
            this.mesLookUpEdit.TabIndex = 1;
            // 
            // reporteLibretaManagerBindingSource
            // 
            this.reporteLibretaManagerBindingSource.DataSource = typeof(VENET_Informes_BL.ReporteLibretaManager);
            // 
            // legajoDesdeTextEdit
            // 
            this.legajoDesdeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reporteLibretaManagerBindingSource, "LegajoDesde", true));
            this.legajoDesdeTextEdit.Location = new System.Drawing.Point(91, 88);
            this.legajoDesdeTextEdit.MenuManager = this.barManager1;
            this.legajoDesdeTextEdit.Name = "legajoDesdeTextEdit";
            this.legajoDesdeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.legajoDesdeTextEdit.TabIndex = 3;
            // 
            // legajoHastaTextEdit
            // 
            this.legajoHastaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reporteLibretaManagerBindingSource, "LegajoHasta", true));
            this.legajoHastaTextEdit.Location = new System.Drawing.Point(91, 114);
            this.legajoHastaTextEdit.MenuManager = this.barManager1;
            this.legajoHastaTextEdit.Name = "legajoHastaTextEdit";
            this.legajoHastaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.legajoHastaTextEdit.TabIndex = 4;
            // 
            // añoTextEdit
            // 
            this.añoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reporteLibretaManagerBindingSource, "Año", true));
            this.añoTextEdit.Location = new System.Drawing.Point(91, 62);
            this.añoTextEdit.MenuManager = this.barManager1;
            this.añoTextEdit.Name = "añoTextEdit";
            this.añoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.añoTextEdit.TabIndex = 2;
            // 
            // id_EmpresaLookUpEdit
            // 
            this.id_EmpresaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reporteLibretaManagerBindingSource, "Id_Empresa", true));
            this.id_EmpresaLookUpEdit.Location = new System.Drawing.Point(91, 10);
            this.id_EmpresaLookUpEdit.MenuManager = this.barManager1;
            this.id_EmpresaLookUpEdit.Name = "id_EmpresaLookUpEdit";
            this.id_EmpresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EmpresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_EmpresaLookUpEdit.Properties.NullText = "";
            this.id_EmpresaLookUpEdit.Properties.ShowHeader = false;
            this.id_EmpresaLookUpEdit.Size = new System.Drawing.Size(233, 20);
            this.id_EmpresaLookUpEdit.TabIndex = 0;
            // 
            // frmReporteLibreta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 192);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteLibreta";
            this.Text = "Reporte de Libretas";
            this.Load += new System.EventHandler(this.frmReporteLibreta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mesLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteLibretaManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.legajoDesdeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.legajoHastaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.añoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EmpresaLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraEditors.TextEdit legajoDesdeTextEdit;
        private System.Windows.Forms.BindingSource reporteLibretaManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit legajoHastaTextEdit;
        private DevExpress.XtraEditors.TextEdit añoTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EmpresaLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit mesLookUpEdit;
    }
}