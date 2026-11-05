namespace VENET_Produccion_UI
{
    partial class frmProduccionVariantes_AddMod
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
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label descripcionCortaLabel;
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
            this.produccionVariantesManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionCortaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.codigoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_LineaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_LineaLabel = new System.Windows.Forms.Label();
            codigoLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            descripcionCortaLabel = new System.Windows.Forms.Label();
            utilidadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionVariantesManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionCortaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_LineaLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_LineaLabel
            // 
            id_LineaLabel.AutoSize = true;
            id_LineaLabel.Location = new System.Drawing.Point(68, 14);
            id_LineaLabel.Name = "id_LineaLabel";
            id_LineaLabel.Size = new System.Drawing.Size(36, 13);
            id_LineaLabel.TabIndex = 0;
            id_LineaLabel.Text = "Línea:";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(60, 92);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(44, 13);
            codigoLabel.TabIndex = 2;
            codigoLabel.Text = "Código:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(39, 40);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 4;
            descripcionLabel.Text = "Descripción:";
            // 
            // descripcionCortaLabel
            // 
            descripcionCortaLabel.AutoSize = true;
            descripcionCortaLabel.Location = new System.Drawing.Point(9, 66);
            descripcionCortaLabel.Name = "descripcionCortaLabel";
            descripcionCortaLabel.Size = new System.Drawing.Size(95, 13);
            descripcionCortaLabel.TabIndex = 6;
            descripcionCortaLabel.Text = "Descripción Corta:";
            // 
            // utilidadLabel
            // 
            utilidadLabel.AutoSize = true;
            utilidadLabel.Location = new System.Drawing.Point(58, 118);
            utilidadLabel.Name = "utilidadLabel";
            utilidadLabel.Size = new System.Drawing.Size(46, 13);
            utilidadLabel.TabIndex = 8;
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
            this.barDockControlTop.Size = new System.Drawing.Size(378, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 186);
            this.barDockControlBottom.Size = new System.Drawing.Size(378, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 162);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(378, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 162);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(utilidadLabel);
            this.groupControl1.Controls.Add(this.utilidadTextEdit);
            this.groupControl1.Controls.Add(descripcionCortaLabel);
            this.groupControl1.Controls.Add(this.descripcionCortaTextEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Controls.Add(codigoLabel);
            this.groupControl1.Controls.Add(this.codigoTextEdit);
            this.groupControl1.Controls.Add(id_LineaLabel);
            this.groupControl1.Controls.Add(this.id_LineaLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(354, 148);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // utilidadTextEdit
            // 
            this.utilidadTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionVariantesManagerBindingSource, "Variante.Utilidad", true));
            this.utilidadTextEdit.Location = new System.Drawing.Point(110, 115);
            this.utilidadTextEdit.MenuManager = this.barManager1;
            this.utilidadTextEdit.Name = "utilidadTextEdit";
            this.utilidadTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.utilidadTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.utilidadTextEdit.Properties.EditFormat.FormatString = "n2";
            this.utilidadTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.utilidadTextEdit.Properties.Mask.EditMask = "n2";
            this.utilidadTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.utilidadTextEdit.Size = new System.Drawing.Size(100, 20);
            this.utilidadTextEdit.TabIndex = 9;
            this.utilidadTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.utilidadTextEdit_KeyPress);
            // 
            // produccionVariantesManagerBindingSource
            // 
            this.produccionVariantesManagerBindingSource.DataSource = typeof(VENET_Produccion_BL.ProduccionVariantesManager);
            // 
            // descripcionCortaTextEdit
            // 
            this.descripcionCortaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionVariantesManagerBindingSource, "Variante.DescripcionCorta", true));
            this.descripcionCortaTextEdit.EnterMoveNextControl = true;
            this.descripcionCortaTextEdit.Location = new System.Drawing.Point(110, 63);
            this.descripcionCortaTextEdit.MenuManager = this.barManager1;
            this.descripcionCortaTextEdit.Name = "descripcionCortaTextEdit";
            this.descripcionCortaTextEdit.Properties.MaxLength = 10;
            this.descripcionCortaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.descripcionCortaTextEdit.TabIndex = 2;
            this.descripcionCortaTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionVariantesManagerBindingSource, "Variante.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(110, 37);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(231, 20);
            this.descripcionTextEdit.TabIndex = 1;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // codigoTextEdit
            // 
            this.codigoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionVariantesManagerBindingSource, "Variante.Codigo", true));
            this.codigoTextEdit.EnterMoveNextControl = true;
            this.codigoTextEdit.Location = new System.Drawing.Point(110, 89);
            this.codigoTextEdit.MenuManager = this.barManager1;
            this.codigoTextEdit.Name = "codigoTextEdit";
            this.codigoTextEdit.Properties.MaxLength = 10;
            this.codigoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigoTextEdit.TabIndex = 3;
            this.codigoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // id_LineaLookUpEdit
            // 
            this.id_LineaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.produccionVariantesManagerBindingSource, "Variante.Id_Linea", true));
            this.id_LineaLookUpEdit.EnterMoveNextControl = true;
            this.id_LineaLookUpEdit.Location = new System.Drawing.Point(110, 11);
            this.id_LineaLookUpEdit.MenuManager = this.barManager1;
            this.id_LineaLookUpEdit.Name = "id_LineaLookUpEdit";
            this.id_LineaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_LineaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 50, "Línea"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name2", "Empresa")});
            this.id_LineaLookUpEdit.Properties.NullText = "";
            this.id_LineaLookUpEdit.Properties.PopupWidth = 336;
            this.id_LineaLookUpEdit.Size = new System.Drawing.Size(231, 20);
            this.id_LineaLookUpEdit.TabIndex = 0;
            // 
            // frmProduccionVariantes_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(378, 186);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(394, 225);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(394, 225);
            this.Name = "frmProduccionVariantes_AddMod";
            this.Text = "Alta/Modificación de Variantes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccionVariantes_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmProduccionVariantes_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utilidadTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionVariantesManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionCortaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_LineaLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit descripcionCortaTextEdit;
        private System.Windows.Forms.BindingSource produccionVariantesManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private DevExpress.XtraEditors.TextEdit codigoTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_LineaLookUpEdit;
        private DevExpress.XtraEditors.TextEdit utilidadTextEdit;
    }
}