namespace VENET_Common
{
    partial class frmGeneraCuit
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.rbHombre = new System.Windows.Forms.RadioButton();
            this.rbMujer = new System.Windows.Forms.RadioButton();
            this.rbSociedad = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocumento = new DevExpress.XtraEditors.TextEdit();
            this.txtCuit = new DevExpress.XtraEditors.TextEdit();
            this.btnCalcular = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnCalcular);
            this.groupControl1.Controls.Add(this.txtCuit);
            this.groupControl1.Controls.Add(this.txtDocumento);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(257, 174);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "groupControl1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número de Documento:";
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(281, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 212);
            this.barDockControlBottom.Size = new System.Drawing.Size(281, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 188);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(281, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 188);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
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
            this.btnAceptar.Glyph = global::VENET_Common.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.rbSociedad);
            this.groupControl2.Controls.Add(this.rbMujer);
            this.groupControl2.Controls.Add(this.rbHombre);
            this.groupControl2.Location = new System.Drawing.Point(5, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(244, 61);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Entidad";
            // 
            // rbHombre
            // 
            this.rbHombre.AutoSize = true;
            this.rbHombre.Checked = true;
            this.rbHombre.Location = new System.Drawing.Point(15, 29);
            this.rbHombre.Name = "rbHombre";
            this.rbHombre.Size = new System.Drawing.Size(62, 17);
            this.rbHombre.TabIndex = 0;
            this.rbHombre.TabStop = true;
            this.rbHombre.Text = "Hombre";
            this.rbHombre.UseVisualStyleBackColor = true;
            // 
            // rbMujer
            // 
            this.rbMujer.AutoSize = true;
            this.rbMujer.Location = new System.Drawing.Point(98, 29);
            this.rbMujer.Name = "rbMujer";
            this.rbMujer.Size = new System.Drawing.Size(52, 17);
            this.rbMujer.TabIndex = 1;
            this.rbMujer.TabStop = true;
            this.rbMujer.Text = "Mujer";
            this.rbMujer.UseVisualStyleBackColor = true;
            // 
            // rbSociedad
            // 
            this.rbSociedad.AutoSize = true;
            this.rbSociedad.Location = new System.Drawing.Point(173, 29);
            this.rbSociedad.Name = "rbSociedad";
            this.rbSociedad.Size = new System.Drawing.Size(68, 17);
            this.rbSociedad.TabIndex = 2;
            this.rbSociedad.TabStop = true;
            this.rbSociedad.Text = "Sociedad";
            this.rbSociedad.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CUIT/CUIL:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(139, 72);
            this.txtDocumento.MenuManager = this.barManager1;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Properties.DisplayFormat.FormatString = "d";
            this.txtDocumento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDocumento.Properties.EditFormat.FormatString = "d";
            this.txtDocumento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDocumento.Properties.Mask.EditMask = "d";
            this.txtDocumento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDocumento.Properties.MaxLength = 8;
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 4;
            // 
            // txtCuit
            // 
            this.txtCuit.Enabled = false;
            this.txtCuit.Location = new System.Drawing.Point(103, 141);
            this.txtCuit.MenuManager = this.barManager1;
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(100, 20);
            this.txtCuit.TabIndex = 5;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(164, 98);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // frmGeneraCuit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 212);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmGeneraCuit";
            this.Text = "Genera Cuit/Cuil";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.Button btnCalcular;
        private DevExpress.XtraEditors.TextEdit txtCuit;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraEditors.TextEdit txtDocumento;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.RadioButton rbSociedad;
        private System.Windows.Forms.RadioButton rbMujer;
        private System.Windows.Forms.RadioButton rbHombre;
    }
}