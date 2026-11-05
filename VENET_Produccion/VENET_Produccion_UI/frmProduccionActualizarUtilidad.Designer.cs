namespace VENET_Produccion_UI
{
    partial class frmProduccionActualizarUtilidad
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
            System.Windows.Forms.Label id_LineaLabel;
            System.Windows.Forms.Label id_VarianteLabel;
            System.Windows.Forms.Label utilidadLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.utilidadTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.produccionActualizarUtilidadManagerBindingSource = new System.Windows.Forms.BindingSource();
            this.id_VarianteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.variantesBindingSource = new System.Windows.Forms.BindingSource();
            this.id_LineaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.lineasBindingSource = new System.Windows.Forms.BindingSource();
            id_LineaLabel = new System.Windows.Forms.Label();
            id_VarianteLabel = new System.Windows.Forms.Label();
            utilidadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionActualizarUtilidadManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_VarianteLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_LineaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // id_LineaLabel
            // 
            id_LineaLabel.AutoSize = true;
            id_LineaLabel.Location = new System.Drawing.Point(25, 12);
            id_LineaLabel.Name = "id_LineaLabel";
            id_LineaLabel.Size = new System.Drawing.Size(36, 13);
            id_LineaLabel.TabIndex = 0;
            id_LineaLabel.Text = "Línea:";
            // 
            // id_VarianteLabel
            // 
            id_VarianteLabel.AutoSize = true;
            id_VarianteLabel.Location = new System.Drawing.Point(10, 38);
            id_VarianteLabel.Name = "id_VarianteLabel";
            id_VarianteLabel.Size = new System.Drawing.Size(51, 13);
            id_VarianteLabel.TabIndex = 2;
            id_VarianteLabel.Text = "Variante:";
            // 
            // utilidadLabel
            // 
            utilidadLabel.AutoSize = true;
            utilidadLabel.Location = new System.Drawing.Point(15, 64);
            utilidadLabel.Name = "utilidadLabel";
            utilidadLabel.Size = new System.Drawing.Size(46, 13);
            utilidadLabel.TabIndex = 4;
            utilidadLabel.Text = "Utilidad:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(338, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 131);
            this.barDockControlBottom.Size = new System.Drawing.Size(338, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 107);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(338, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 107);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(utilidadLabel);
            this.groupControl1.Controls.Add(this.utilidadTextEdit);
            this.groupControl1.Controls.Add(id_VarianteLabel);
            this.groupControl1.Controls.Add(this.id_VarianteLookUpEdit);
            this.groupControl1.Controls.Add(id_LineaLabel);
            this.groupControl1.Controls.Add(this.id_LineaLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(314, 93);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // utilidadTextEdit
            // 
            this.utilidadTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionActualizarUtilidadManagerBindingSource, "Utilidad", true));
            this.utilidadTextEdit.Location = new System.Drawing.Point(67, 61);
            this.utilidadTextEdit.MenuManager = this.barManager1;
            this.utilidadTextEdit.Name = "utilidadTextEdit";
            this.utilidadTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.utilidadTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.utilidadTextEdit.Properties.EditFormat.FormatString = "n2";
            this.utilidadTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.utilidadTextEdit.Properties.Mask.EditMask = "n2";
            this.utilidadTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.utilidadTextEdit.Size = new System.Drawing.Size(100, 20);
            this.utilidadTextEdit.TabIndex = 2;
            this.utilidadTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.utilidadTextEdit_KeyPress);
            // 
            // produccionActualizarUtilidadManagerBindingSource
            // 
            this.produccionActualizarUtilidadManagerBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionActualizarUtilidadManager);
            // 
            // id_VarianteLookUpEdit
            // 
            this.id_VarianteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionActualizarUtilidadManagerBindingSource, "Id_Variante", true));
            this.id_VarianteLookUpEdit.EnterMoveNextControl = true;
            this.id_VarianteLookUpEdit.Location = new System.Drawing.Point(67, 35);
            this.id_VarianteLookUpEdit.MenuManager = this.barManager1;
            this.id_VarianteLookUpEdit.Name = "id_VarianteLookUpEdit";
            this.id_VarianteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_VarianteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name3")});
            this.id_VarianteLookUpEdit.Properties.DataSource = this.variantesBindingSource;
            this.id_VarianteLookUpEdit.Properties.DisplayMember = "Name";
            this.id_VarianteLookUpEdit.Properties.NullText = "";
            this.id_VarianteLookUpEdit.Properties.ShowHeader = false;
            this.id_VarianteLookUpEdit.Properties.ValueMember = "Key";
            this.id_VarianteLookUpEdit.Size = new System.Drawing.Size(232, 20);
            this.id_VarianteLookUpEdit.TabIndex = 1;
            this.id_VarianteLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // variantesBindingSource
            // 
            this.variantesBindingSource.DataMember = "Variantes";
            this.variantesBindingSource.DataSource = this.produccionActualizarUtilidadManagerBindingSource;
            // 
            // id_LineaLookUpEdit
            // 
            this.id_LineaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionActualizarUtilidadManagerBindingSource, "Id_Linea", true));
            this.id_LineaLookUpEdit.EnterMoveNextControl = true;
            this.id_LineaLookUpEdit.Location = new System.Drawing.Point(67, 9);
            this.id_LineaLookUpEdit.MenuManager = this.barManager1;
            this.id_LineaLookUpEdit.Name = "id_LineaLookUpEdit";
            this.id_LineaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_LineaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.id_LineaLookUpEdit.Properties.DataSource = this.lineasBindingSource;
            this.id_LineaLookUpEdit.Properties.DisplayMember = "Name";
            this.id_LineaLookUpEdit.Properties.NullText = "";
            this.id_LineaLookUpEdit.Properties.ShowHeader = false;
            this.id_LineaLookUpEdit.Properties.ValueMember = "Key";
            this.id_LineaLookUpEdit.Size = new System.Drawing.Size(232, 20);
            this.id_LineaLookUpEdit.TabIndex = 0;
            this.id_LineaLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            this.id_LineaLookUpEdit.EditValueChanged += new System.EventHandler(this.id_LineaLookUpEdit_EditValueChanged);
            // 
            // lineasBindingSource
            // 
            this.lineasBindingSource.DataMember = "Lineas";
            this.lineasBindingSource.DataSource = this.produccionActualizarUtilidadManagerBindingSource;
            // 
            // frmProduccionActualizarUtilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 131);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProduccionActualizarUtilidad";
            this.Text = "Actualizar Utilidad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccionActualizarUtilidad_FormClosing);
            this.Load += new System.EventHandler(this.frmProduccionActualizarUtilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionActualizarUtilidadManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_VarianteLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_LineaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineasBindingSource)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit utilidadTextEdit;
        private System.Windows.Forms.BindingSource produccionActualizarUtilidadManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_VarianteLookUpEdit;
        private System.Windows.Forms.BindingSource variantesBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_LineaLookUpEdit;
        private System.Windows.Forms.BindingSource lineasBindingSource;
    }
}