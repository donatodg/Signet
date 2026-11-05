namespace VENET_Produccion_UI
{
    partial class frmProduccionMedidas_AddMod
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
            System.Windows.Forms.Label anchoLabel;
            System.Windows.Forms.Label altoLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.produccionMedidasManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.altoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.anchoTextEdit = new DevExpress.XtraEditors.TextEdit();
            anchoLabel = new System.Windows.Forms.Label();
            altoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produccionMedidasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.altoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anchoTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // anchoLabel
            // 
            anchoLabel.AutoSize = true;
            anchoLabel.Location = new System.Drawing.Point(25, 14);
            anchoLabel.Name = "anchoLabel";
            anchoLabel.Size = new System.Drawing.Size(41, 13);
            anchoLabel.TabIndex = 0;
            anchoLabel.Text = "Ancho:";
            // 
            // altoLabel
            // 
            altoLabel.AutoSize = true;
            altoLabel.Location = new System.Drawing.Point(36, 40);
            altoLabel.Name = "altoLabel";
            altoLabel.Size = new System.Drawing.Size(30, 13);
            altoLabel.TabIndex = 2;
            altoLabel.Text = "Alto:";
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
            this.btnAceptar.Glyph = global::VENET_Produccion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(233, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 106);
            this.barDockControlBottom.Size = new System.Drawing.Size(233, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 82);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(233, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 82);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(altoLabel);
            this.groupControl1.Controls.Add(this.altoTextEdit);
            this.groupControl1.Controls.Add(anchoLabel);
            this.groupControl1.Controls.Add(this.anchoTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(209, 72);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // produccionMedidasManagerBindingSource
            // 
            this.produccionMedidasManagerBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionMedidasManager);
            // 
            // altoTextEdit
            // 
            this.altoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionMedidasManagerBindingSource, "Medida.Alto", true));
            this.altoTextEdit.Location = new System.Drawing.Point(72, 37);
            this.altoTextEdit.MenuManager = this.barManager1;
            this.altoTextEdit.Name = "altoTextEdit";
            this.altoTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.altoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.altoTextEdit.Properties.EditFormat.FormatString = "n2";
            this.altoTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.altoTextEdit.Properties.Mask.EditMask = "n2";
            this.altoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.altoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.altoTextEdit.TabIndex = 1;
            this.altoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            this.altoTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.largoTextEdit_KeyPress);
            // 
            // anchoTextEdit
            // 
            this.anchoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionMedidasManagerBindingSource, "Medida.Ancho", true));
            this.anchoTextEdit.EnterMoveNextControl = true;
            this.anchoTextEdit.Location = new System.Drawing.Point(72, 11);
            this.anchoTextEdit.MenuManager = this.barManager1;
            this.anchoTextEdit.Name = "anchoTextEdit";
            this.anchoTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.anchoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.anchoTextEdit.Properties.EditFormat.FormatString = "n2";
            this.anchoTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.anchoTextEdit.Properties.Mask.EditMask = "n2";
            this.anchoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.anchoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.anchoTextEdit.TabIndex = 0;
            this.anchoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmProduccionMedidas_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(233, 106);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(249, 145);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(249, 145);
            this.Name = "frmProduccionMedidas_AddMod";
            this.Text = "Alta/Modificación de Medidas";
            this.Load += new System.EventHandler(this.frmProduccionMedidas_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produccionMedidasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.altoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anchoTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit altoTextEdit;
        private System.Windows.Forms.BindingSource produccionMedidasManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit anchoTextEdit;
    }
}