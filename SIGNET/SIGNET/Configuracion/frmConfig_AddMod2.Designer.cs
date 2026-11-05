namespace SitNET
{
    partial class frmConfig_AddMod2
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
            System.Windows.Forms.Label localidadLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig_AddMod2));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.fechadateEdit = new DevExpress.XtraEditors.DateEdit();
            this.webtextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nombreTextEdit = new DevExpress.XtraEditors.TextEdit();
            localidadLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechadateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechadateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webtextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // localidadLabel
            // 
            localidadLabel.AutoSize = true;
            localidadLabel.Location = new System.Drawing.Point(15, 31);
            localidadLabel.Name = "localidadLabel";
            localidadLabel.Size = new System.Drawing.Size(48, 13);
            localidadLabel.TabIndex = 4;
            localidadLabel.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 57);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 13);
            label1.TabIndex = 6;
            label1.Text = "Web:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 83);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 13);
            label2.TabIndex = 8;
            label2.Text = "Fecha:";
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
            this.btnAceptar});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Glyph")));
            this.btnAceptar.Id = 0;
            this.btnAceptar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAceptar.LargeGlyph")));
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(284, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 152);
            this.barDockControlBottom.Size = new System.Drawing.Size(284, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 128);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(284, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 128);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.fechadateEdit);
            this.groupControl1.Controls.Add(label2);
            this.groupControl1.Controls.Add(label1);
            this.groupControl1.Controls.Add(this.webtextEdit);
            this.groupControl1.Controls.Add(localidadLabel);
            this.groupControl1.Controls.Add(this.nombreTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(260, 114);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Datos";
            // 
            // fechadateEdit
            // 
            this.fechadateEdit.EditValue = null;
            this.fechadateEdit.Location = new System.Drawing.Point(69, 80);
            this.fechadateEdit.MenuManager = this.barManager1;
            this.fechadateEdit.Name = "fechadateEdit";
            this.fechadateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechadateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechadateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechadateEdit.TabIndex = 9;
            // 
            // webtextEdit
            // 
            this.webtextEdit.EnterMoveNextControl = true;
            this.webtextEdit.Location = new System.Drawing.Point(69, 54);
            this.webtextEdit.MenuManager = this.barManager1;
            this.webtextEdit.Name = "webtextEdit";
            this.webtextEdit.Size = new System.Drawing.Size(175, 20);
            this.webtextEdit.TabIndex = 7;
            // 
            // nombreTextEdit
            // 
            this.nombreTextEdit.EnterMoveNextControl = true;
            this.nombreTextEdit.Location = new System.Drawing.Point(69, 28);
            this.nombreTextEdit.MenuManager = this.barManager1;
            this.nombreTextEdit.Name = "nombreTextEdit";
            this.nombreTextEdit.Size = new System.Drawing.Size(175, 20);
            this.nombreTextEdit.TabIndex = 5;
            // 
            // frmConfig_AddMod2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 152);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 191);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 191);
            this.Name = "frmConfig_AddMod2";
            this.Text = "Alta\\Modificación de Configuración";
            this.Load += new System.EventHandler(this.frmConfig_AddMod2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechadateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechadateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webtextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraEditors.DateEdit fechadateEdit;
        private DevExpress.XtraEditors.TextEdit webtextEdit;
        private DevExpress.XtraEditors.TextEdit nombreTextEdit;
    }
}