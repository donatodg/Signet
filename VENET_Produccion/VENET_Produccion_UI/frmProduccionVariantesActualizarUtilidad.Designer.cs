namespace VENET_Produccion_UI
{
    partial class frmProduccionVariantesActualizarUtilidad
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
            System.Windows.Forms.Label id_LineaLabel;
            System.Windows.Forms.Label utilidadLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.utilidadTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.produccionVariantesActualizarUtilidadManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_LineaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.lineasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            id_LineaLabel = new System.Windows.Forms.Label();
            utilidadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionVariantesActualizarUtilidadManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_LineaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // id_LineaLabel
            // 
            id_LineaLabel.AutoSize = true;
            id_LineaLabel.Location = new System.Drawing.Point(20, 12);
            id_LineaLabel.Name = "id_LineaLabel";
            id_LineaLabel.Size = new System.Drawing.Size(36, 13);
            id_LineaLabel.TabIndex = 0;
            id_LineaLabel.Text = "Línea:";
            // 
            // utilidadLabel
            // 
            utilidadLabel.AutoSize = true;
            utilidadLabel.Location = new System.Drawing.Point(10, 38);
            utilidadLabel.Name = "utilidadLabel";
            utilidadLabel.Size = new System.Drawing.Size(46, 13);
            utilidadLabel.TabIndex = 2;
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
            this.barDockControlTop.Size = new System.Drawing.Size(340, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 104);
            this.barDockControlBottom.Size = new System.Drawing.Size(340, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 80);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(340, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 80);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(utilidadLabel);
            this.groupControl1.Controls.Add(this.utilidadTextEdit);
            this.groupControl1.Controls.Add(id_LineaLabel);
            this.groupControl1.Controls.Add(this.id_LineaLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(316, 66);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // utilidadTextEdit
            // 
            this.utilidadTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionVariantesActualizarUtilidadManagerBindingSource, "Utilidad", true));
            this.utilidadTextEdit.Location = new System.Drawing.Point(62, 35);
            this.utilidadTextEdit.MenuManager = this.barManager1;
            this.utilidadTextEdit.Name = "utilidadTextEdit";
            this.utilidadTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.utilidadTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.utilidadTextEdit.Properties.EditFormat.FormatString = "n2";
            this.utilidadTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.utilidadTextEdit.Properties.Mask.EditMask = "n2";
            this.utilidadTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.utilidadTextEdit.Size = new System.Drawing.Size(100, 20);
            this.utilidadTextEdit.TabIndex = 3;
            this.utilidadTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.utilidadTextEdit_KeyPress);
            // 
            // produccionVariantesActualizarUtilidadManagerBindingSource
            // 
            this.produccionVariantesActualizarUtilidadManagerBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionVariantesActualizarUtilidadManager);
            // 
            // id_LineaLookUpEdit
            // 
            this.id_LineaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionVariantesActualizarUtilidadManagerBindingSource, "Id_Linea", true));
            this.id_LineaLookUpEdit.EnterMoveNextControl = true;
            this.id_LineaLookUpEdit.Location = new System.Drawing.Point(62, 9);
            this.id_LineaLookUpEdit.MenuManager = this.barManager1;
            this.id_LineaLookUpEdit.Name = "id_LineaLookUpEdit";
            this.id_LineaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_LineaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 50, "Línea"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name2", "Empresa")});
            this.id_LineaLookUpEdit.Properties.DataSource = this.lineasBindingSource;
            this.id_LineaLookUpEdit.Properties.DisplayMember = "Name";
            this.id_LineaLookUpEdit.Properties.NullText = "";
            this.id_LineaLookUpEdit.Properties.ValueMember = "Key";
            this.id_LineaLookUpEdit.Size = new System.Drawing.Size(233, 20);
            this.id_LineaLookUpEdit.TabIndex = 1;
            // 
            // lineasBindingSource
            // 
            this.lineasBindingSource.DataMember = "Lineas";
            this.lineasBindingSource.DataSource = this.produccionVariantesActualizarUtilidadManagerBindingSource;
            // 
            // frmProduccionVariantesActualizarUtilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 104);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProduccionVariantesActualizarUtilidad";
            this.Text = "Actualizar Utilidad por Línea";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccionVariantesActualizarUtilidad_FormClosing);
            this.Load += new System.EventHandler(this.frmProduccionVariantesActualizarUtilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionVariantesActualizarUtilidadManagerBindingSource)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit utilidadTextEdit;
        private System.Windows.Forms.BindingSource produccionVariantesActualizarUtilidadManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_LineaLookUpEdit;
        private System.Windows.Forms.BindingSource lineasBindingSource;
    }
}