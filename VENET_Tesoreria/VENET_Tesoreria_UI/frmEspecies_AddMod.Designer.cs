namespace VENET_Tesoreria_UI
{
    partial class frmEspecies_AddMod
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
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label siglaLabel;
            System.Windows.Forms.Label cotizacionLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.siglaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.especiesManagerBindingSource = new System.Windows.Forms.BindingSource();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cotizacionSpinEdit = new DevExpress.XtraEditors.TextEdit();
            descripcionLabel = new System.Windows.Forms.Label();
            siglaLabel = new System.Windows.Forms.Label();
            cotizacionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siglaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cotizacionSpinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(21, 17);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 0;
            descripcionLabel.Text = "Descripción:";
            // 
            // siglaLabel
            // 
            siglaLabel.AutoSize = true;
            siglaLabel.Location = new System.Drawing.Point(54, 43);
            siglaLabel.Name = "siglaLabel";
            siglaLabel.Size = new System.Drawing.Size(33, 13);
            siglaLabel.TabIndex = 2;
            siglaLabel.Text = "Sigla:";
            // 
            // cotizacionLabel
            // 
            cotizacionLabel.AutoSize = true;
            cotizacionLabel.Location = new System.Drawing.Point(28, 69);
            cotizacionLabel.Name = "cotizacionLabel";
            cotizacionLabel.Size = new System.Drawing.Size(60, 13);
            cotizacionLabel.TabIndex = 4;
            cotizacionLabel.Text = "Cotización:";
            // 
            // barManager1
            // 
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnGuardar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGuardar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Aceptar";
            this.btnGuardar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.save_16x16;
            this.btnGuardar.Id = 0;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(360, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 141);
            this.barDockControlBottom.Size = new System.Drawing.Size(360, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 117);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(360, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 117);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(cotizacionLabel);
            this.groupControl1.Controls.Add(siglaLabel);
            this.groupControl1.Controls.Add(this.siglaTextEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Controls.Add(this.cotizacionSpinEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(336, 101);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // siglaTextEdit
            // 
            this.siglaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesManagerBindingSource, "Especie.Sigla", true));
            this.siglaTextEdit.Location = new System.Drawing.Point(93, 40);
            this.siglaTextEdit.MenuManager = this.barManager1;
            this.siglaTextEdit.Name = "siglaTextEdit";
            this.siglaTextEdit.Properties.MaxLength = 3;
            this.siglaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.siglaTextEdit.TabIndex = 3;
            this.siglaTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // especiesManagerBindingSource
            // 
            this.especiesManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.EspeciesManager);
            this.especiesManagerBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.especiesManagerBindingSource_BindingComplete);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesManagerBindingSource, "Especie.Descripcion", true));
            this.descripcionTextEdit.Location = new System.Drawing.Point(93, 14);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Properties.MaxLength = 50;
            this.descripcionTextEdit.Size = new System.Drawing.Size(221, 20);
            this.descripcionTextEdit.TabIndex = 1;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // cotizacionSpinEdit
            // 
            this.cotizacionSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesManagerBindingSource, "Especie.Cotizacion", true));
            this.cotizacionSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cotizacionSpinEdit.Location = new System.Drawing.Point(93, 66);
            this.cotizacionSpinEdit.MenuManager = this.barManager1;
            this.cotizacionSpinEdit.Name = "cotizacionSpinEdit";
            this.cotizacionSpinEdit.Properties.EditFormat.FormatString = "n";
            this.cotizacionSpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cotizacionSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.cotizacionSpinEdit.Properties.Mask.EditMask = "n";
            this.cotizacionSpinEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.cotizacionSpinEdit.Size = new System.Drawing.Size(100, 20);
            this.cotizacionSpinEdit.TabIndex = 5;
            this.cotizacionSpinEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmEspecies_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 141);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(376, 180);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(376, 180);
            this.Name = "frmEspecies_AddMod";
            this.Text = "Alta/Modificación de Especies";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEspecies_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmEspecies_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siglaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cotizacionSpinEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit siglaTextEdit;
        private System.Windows.Forms.BindingSource especiesManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private DevExpress.XtraEditors.TextEdit cotizacionSpinEdit;
    }
}