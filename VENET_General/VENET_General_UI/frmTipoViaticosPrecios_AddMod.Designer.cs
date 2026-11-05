namespace VENET_General_UI
{
    partial class frmTipoViaticosPrecios_AddMod
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
            System.Windows.Forms.Label importeLabel;
            System.Windows.Forms.Label vigenciaDesdeLabel;
            System.Windows.Forms.Label vigenciaHastaLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.vigenciaHastaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.tipoViaticosPreciosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vigenciaDesdeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            importeLabel = new System.Windows.Forms.Label();
            vigenciaDesdeLabel = new System.Windows.Forms.Label();
            vigenciaHastaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaHastaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaHastaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoViaticosPreciosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaDesdeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaDesdeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(48, 10);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(49, 13);
            importeLabel.TabIndex = 0;
            importeLabel.Text = "Importe:";
            // 
            // vigenciaDesdeLabel
            // 
            vigenciaDesdeLabel.AutoSize = true;
            vigenciaDesdeLabel.Location = new System.Drawing.Point(14, 36);
            vigenciaDesdeLabel.Name = "vigenciaDesdeLabel";
            vigenciaDesdeLabel.Size = new System.Drawing.Size(83, 13);
            vigenciaDesdeLabel.TabIndex = 2;
            vigenciaDesdeLabel.Text = "Vigencia Desde:";
            // 
            // vigenciaHastaLabel
            // 
            vigenciaHastaLabel.AutoSize = true;
            vigenciaHastaLabel.Location = new System.Drawing.Point(16, 62);
            vigenciaHastaLabel.Name = "vigenciaHastaLabel";
            vigenciaHastaLabel.Size = new System.Drawing.Size(81, 13);
            vigenciaHastaLabel.TabIndex = 4;
            vigenciaHastaLabel.Text = "Vigencia Hasta:";
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
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAceptar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Caption = "Aceptar";
            this.btnAceptar.Glyph = global::VENET_General_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(253, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 129);
            this.barDockControlBottom.Size = new System.Drawing.Size(253, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 105);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(253, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 105);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(vigenciaHastaLabel);
            this.groupControl1.Controls.Add(this.vigenciaHastaDateEdit);
            this.groupControl1.Controls.Add(vigenciaDesdeLabel);
            this.groupControl1.Controls.Add(this.vigenciaDesdeDateEdit);
            this.groupControl1.Controls.Add(importeLabel);
            this.groupControl1.Controls.Add(this.importeTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(229, 89);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // vigenciaHastaDateEdit
            // 
            this.vigenciaHastaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoViaticosPreciosManagerBindingSource, "Precio.VigenciaHasta", true));
            this.vigenciaHastaDateEdit.EditValue = null;
            this.vigenciaHastaDateEdit.EnterMoveNextControl = true;
            this.vigenciaHastaDateEdit.Location = new System.Drawing.Point(103, 59);
            this.vigenciaHastaDateEdit.MenuManager = this.barManager1;
            this.vigenciaHastaDateEdit.Name = "vigenciaHastaDateEdit";
            this.vigenciaHastaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenciaHastaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenciaHastaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.vigenciaHastaDateEdit.TabIndex = 5;
            // 
            // tipoViaticosPreciosManagerBindingSource
            // 
            this.tipoViaticosPreciosManagerBindingSource.DataSource = typeof(VENET_General_BL.TipoViaticosPreciosManager);
            // 
            // vigenciaDesdeDateEdit
            // 
            this.vigenciaDesdeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoViaticosPreciosManagerBindingSource, "Precio.VigenciaDesde", true));
            this.vigenciaDesdeDateEdit.EditValue = null;
            this.vigenciaDesdeDateEdit.EnterMoveNextControl = true;
            this.vigenciaDesdeDateEdit.Location = new System.Drawing.Point(103, 33);
            this.vigenciaDesdeDateEdit.MenuManager = this.barManager1;
            this.vigenciaDesdeDateEdit.Name = "vigenciaDesdeDateEdit";
            this.vigenciaDesdeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenciaDesdeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.vigenciaDesdeDateEdit.Size = new System.Drawing.Size(100, 20);
            this.vigenciaDesdeDateEdit.TabIndex = 3;
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoViaticosPreciosManagerBindingSource, "Precio.Importe", true));
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(103, 7);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.Mask.EditMask = "n";
            this.importeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.importeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.importeTextEdit.TabIndex = 1;
            // 
            // frmTipoViaticosPrecios_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 129);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(269, 168);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(269, 168);
            this.Name = "frmTipoViaticosPrecios_AddMod";
            this.Text = "Alta/Modificación de Precios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTipoViaticosPrecios_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmTipoViaticosPrecios_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaHastaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaHastaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoViaticosPreciosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaDesdeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vigenciaDesdeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.DateEdit vigenciaHastaDateEdit;
        private System.Windows.Forms.BindingSource tipoViaticosPreciosManagerBindingSource;
        private DevExpress.XtraEditors.DateEdit vigenciaDesdeDateEdit;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
    }
}