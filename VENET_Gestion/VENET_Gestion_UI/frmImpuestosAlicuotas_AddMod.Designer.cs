namespace VENET_Gestion_UI
{
    partial class frmImpuestosAlicuotas_AddMod
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
            System.Windows.Forms.Label alicuotaLabel;
            System.Windows.Forms.Label baseImponibleLabel;
            System.Windows.Forms.Label id_ProvinciaLabel;
            System.Windows.Forms.Label impoteMinimoLabel;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.impuestosAlicuotasManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.impoteMinimoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_ProvinciaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.baseImponibleTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.alicuotaTextEdit = new DevExpress.XtraEditors.TextEdit();
            alicuotaLabel = new System.Windows.Forms.Label();
            baseImponibleLabel = new System.Windows.Forms.Label();
            id_ProvinciaLabel = new System.Windows.Forms.Label();
            impoteMinimoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.impuestosAlicuotasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.impoteMinimoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvinciaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseImponibleTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alicuotaTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // alicuotaLabel
            // 
            alicuotaLabel.AutoSize = true;
            alicuotaLabel.Location = new System.Drawing.Point(61, 10);
            alicuotaLabel.Name = "alicuotaLabel";
            alicuotaLabel.Size = new System.Drawing.Size(49, 13);
            alicuotaLabel.TabIndex = 0;
            alicuotaLabel.Text = "Alícuota:";
            // 
            // baseImponibleLabel
            // 
            baseImponibleLabel.AutoSize = true;
            baseImponibleLabel.Location = new System.Drawing.Point(27, 36);
            baseImponibleLabel.Name = "baseImponibleLabel";
            baseImponibleLabel.Size = new System.Drawing.Size(83, 13);
            baseImponibleLabel.TabIndex = 2;
            baseImponibleLabel.Text = "Base Imponible:";
            // 
            // id_ProvinciaLabel
            // 
            id_ProvinciaLabel.AutoSize = true;
            id_ProvinciaLabel.Location = new System.Drawing.Point(56, 88);
            id_ProvinciaLabel.Name = "id_ProvinciaLabel";
            id_ProvinciaLabel.Size = new System.Drawing.Size(54, 13);
            id_ProvinciaLabel.TabIndex = 4;
            id_ProvinciaLabel.Text = "Provincia:";
            // 
            // impoteMinimoLabel
            // 
            impoteMinimoLabel.AutoSize = true;
            impoteMinimoLabel.Location = new System.Drawing.Point(30, 62);
            impoteMinimoLabel.Name = "impoteMinimoLabel";
            impoteMinimoLabel.Size = new System.Drawing.Size(80, 13);
            impoteMinimoLabel.TabIndex = 6;
            impoteMinimoLabel.Text = "Impote Mínimo:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(impoteMinimoLabel);
            this.groupControl1.Controls.Add(this.impoteMinimoTextEdit);
            this.groupControl1.Controls.Add(id_ProvinciaLabel);
            this.groupControl1.Controls.Add(this.id_ProvinciaLookUpEdit);
            this.groupControl1.Controls.Add(baseImponibleLabel);
            this.groupControl1.Controls.Add(this.baseImponibleTextEdit);
            this.groupControl1.Controls.Add(alicuotaLabel);
            this.groupControl1.Controls.Add(this.alicuotaTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(309, 117);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // impuestosAlicuotasManagerBindingSource
            // 
            this.impuestosAlicuotasManagerBindingSource.DataSource = typeof(VENET_Gestion_BL.ImpuestosAlicuotasManager);
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
            this.btnAceptar.Glyph = global::VENET_Gestion_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(333, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 155);
            this.barDockControlBottom.Size = new System.Drawing.Size(333, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 131);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(333, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 131);
            // 
            // impoteMinimoTextEdit
            // 
            this.impoteMinimoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.impuestosAlicuotasManagerBindingSource, "Alicuota.ImporteMinimo", true));
            this.impoteMinimoTextEdit.EnterMoveNextControl = true;
            this.impoteMinimoTextEdit.Location = new System.Drawing.Point(116, 59);
            this.impoteMinimoTextEdit.MenuManager = this.barManager1;
            this.impoteMinimoTextEdit.Name = "impoteMinimoTextEdit";
            this.impoteMinimoTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.impoteMinimoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.impoteMinimoTextEdit.Properties.EditFormat.FormatString = "n2";
            this.impoteMinimoTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.impoteMinimoTextEdit.Properties.Mask.EditMask = "n2";
            this.impoteMinimoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.impoteMinimoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.impoteMinimoTextEdit.TabIndex = 3;
            // 
            // id_ProvinciaLookUpEdit
            // 
            this.id_ProvinciaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.impuestosAlicuotasManagerBindingSource, "Alicuota.Id_Provincia", true));
            this.id_ProvinciaLookUpEdit.EnterMoveNextControl = true;
            this.id_ProvinciaLookUpEdit.Location = new System.Drawing.Point(116, 85);
            this.id_ProvinciaLookUpEdit.MenuManager = this.barManager1;
            this.id_ProvinciaLookUpEdit.Name = "id_ProvinciaLookUpEdit";
            this.id_ProvinciaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_ProvinciaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_ProvinciaLookUpEdit.Properties.NullText = "";
            this.id_ProvinciaLookUpEdit.Properties.ShowHeader = false;
            this.id_ProvinciaLookUpEdit.Size = new System.Drawing.Size(172, 20);
            this.id_ProvinciaLookUpEdit.TabIndex = 4;
            this.id_ProvinciaLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // baseImponibleTextEdit
            // 
            this.baseImponibleTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.impuestosAlicuotasManagerBindingSource, "Alicuota.BaseImponible", true));
            this.baseImponibleTextEdit.EnterMoveNextControl = true;
            this.baseImponibleTextEdit.Location = new System.Drawing.Point(116, 33);
            this.baseImponibleTextEdit.MenuManager = this.barManager1;
            this.baseImponibleTextEdit.Name = "baseImponibleTextEdit";
            this.baseImponibleTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.baseImponibleTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.baseImponibleTextEdit.Properties.EditFormat.FormatString = "n2";
            this.baseImponibleTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.baseImponibleTextEdit.Properties.Mask.EditMask = "n";
            this.baseImponibleTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.baseImponibleTextEdit.Size = new System.Drawing.Size(100, 20);
            this.baseImponibleTextEdit.TabIndex = 1;
            // 
            // alicuotaTextEdit
            // 
            this.alicuotaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.impuestosAlicuotasManagerBindingSource, "Alicuota.Alicuota", true));
            this.alicuotaTextEdit.EnterMoveNextControl = true;
            this.alicuotaTextEdit.Location = new System.Drawing.Point(116, 7);
            this.alicuotaTextEdit.MenuManager = this.barManager1;
            this.alicuotaTextEdit.Name = "alicuotaTextEdit";
            this.alicuotaTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.alicuotaTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.alicuotaTextEdit.Properties.Mask.EditMask = "n";
            this.alicuotaTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.alicuotaTextEdit.Properties.MaxLength = 6;
            this.alicuotaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.alicuotaTextEdit.TabIndex = 0;
            // 
            // frmImpuestosAlicuotas_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 155);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(349, 194);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(349, 194);
            this.Name = "frmImpuestosAlicuotas_AddMod";
            this.Text = "Alta/Modificación de Alícuotas";
            this.Load += new System.EventHandler(this.frmImpuestosAlicuotas_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.impuestosAlicuotasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.impoteMinimoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_ProvinciaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseImponibleTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alicuotaTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit id_ProvinciaLookUpEdit;
        private System.Windows.Forms.BindingSource impuestosAlicuotasManagerBindingSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.TextEdit baseImponibleTextEdit;
        private DevExpress.XtraEditors.TextEdit alicuotaTextEdit;
        private DevExpress.XtraEditors.TextEdit impoteMinimoTextEdit;
    }
}