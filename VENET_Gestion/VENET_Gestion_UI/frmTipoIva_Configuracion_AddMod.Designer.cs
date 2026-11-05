namespace VENET_Gestion_UI
{
    partial class frmTipoIva_Configuracion_AddMod
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
            System.Windows.Forms.Label id_TipoComprobanteLabel;
            System.Windows.Forms.Label id_TipoIvaOrigenLabel;
            System.Windows.Forms.Label id_TipoIvaDestinoLabel;
            System.Windows.Forms.Label letraLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.letraTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tipoIvaConfiguracionManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_TipoIvaDestinoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_TipoIvaOrigenLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_TipoComprobanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_TipoComprobanteLabel = new System.Windows.Forms.Label();
            id_TipoIvaOrigenLabel = new System.Windows.Forms.Label();
            id_TipoIvaDestinoLabel = new System.Windows.Forms.Label();
            letraLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoIvaConfiguracionManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoIvaDestinoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoIvaOrigenLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_TipoComprobanteLabel
            // 
            id_TipoComprobanteLabel.AutoSize = true;
            id_TipoComprobanteLabel.Location = new System.Drawing.Point(21, 11);
            id_TipoComprobanteLabel.Name = "id_TipoComprobanteLabel";
            id_TipoComprobanteLabel.Size = new System.Drawing.Size(76, 13);
            id_TipoComprobanteLabel.TabIndex = 0;
            id_TipoComprobanteLabel.Text = "Comprobante:";
            // 
            // id_TipoIvaOrigenLabel
            // 
            id_TipoIvaOrigenLabel.AutoSize = true;
            id_TipoIvaOrigenLabel.Location = new System.Drawing.Point(12, 37);
            id_TipoIvaOrigenLabel.Name = "id_TipoIvaOrigenLabel";
            id_TipoIvaOrigenLabel.Size = new System.Drawing.Size(85, 13);
            id_TipoIvaOrigenLabel.TabIndex = 2;
            id_TipoIvaOrigenLabel.Text = "Tipo Iva Origen:";
            // 
            // id_TipoIvaDestinoLabel
            // 
            id_TipoIvaDestinoLabel.AutoSize = true;
            id_TipoIvaDestinoLabel.Location = new System.Drawing.Point(8, 63);
            id_TipoIvaDestinoLabel.Name = "id_TipoIvaDestinoLabel";
            id_TipoIvaDestinoLabel.Size = new System.Drawing.Size(89, 13);
            id_TipoIvaDestinoLabel.TabIndex = 4;
            id_TipoIvaDestinoLabel.Text = "Tipo Iva Destino:";
            // 
            // letraLabel
            // 
            letraLabel.AutoSize = true;
            letraLabel.Location = new System.Drawing.Point(61, 89);
            letraLabel.Name = "letraLabel";
            letraLabel.Size = new System.Drawing.Size(36, 13);
            letraLabel.TabIndex = 6;
            letraLabel.Text = "Letra:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(336, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 154);
            this.barDockControlBottom.Size = new System.Drawing.Size(336, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 130);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(336, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 130);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(letraLabel);
            this.groupControl1.Controls.Add(this.letraTextEdit);
            this.groupControl1.Controls.Add(id_TipoIvaDestinoLabel);
            this.groupControl1.Controls.Add(this.id_TipoIvaDestinoLookUpEdit);
            this.groupControl1.Controls.Add(id_TipoIvaOrigenLabel);
            this.groupControl1.Controls.Add(this.id_TipoIvaOrigenLookUpEdit);
            this.groupControl1.Controls.Add(id_TipoComprobanteLabel);
            this.groupControl1.Controls.Add(this.id_TipoComprobanteLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(312, 116);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // letraTextEdit
            // 
            this.letraTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoIvaConfiguracionManagerBindingSource, "Config.Letra", true));
            this.letraTextEdit.Location = new System.Drawing.Point(103, 86);
            this.letraTextEdit.MenuManager = this.barManager1;
            this.letraTextEdit.Name = "letraTextEdit";
            this.letraTextEdit.Properties.Mask.EditMask = "\\p{Lu}+";
            this.letraTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.letraTextEdit.Properties.MaxLength = 1;
            this.letraTextEdit.Size = new System.Drawing.Size(32, 20);
            this.letraTextEdit.TabIndex = 7;
            // 
            // tipoIvaConfiguracionManagerBindingSource
            // 
            this.tipoIvaConfiguracionManagerBindingSource.DataSource = typeof(VENET_Gestion_BL.TipoIvaConfiguracionManager);
            // 
            // id_TipoIvaDestinoLookUpEdit
            // 
            this.id_TipoIvaDestinoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoIvaConfiguracionManagerBindingSource, "Config.Id_TipoIvaDestino", true));
            this.id_TipoIvaDestinoLookUpEdit.Location = new System.Drawing.Point(103, 60);
            this.id_TipoIvaDestinoLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoIvaDestinoLookUpEdit.Name = "id_TipoIvaDestinoLookUpEdit";
            this.id_TipoIvaDestinoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoIvaDestinoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name3")});
            this.id_TipoIvaDestinoLookUpEdit.Properties.NullText = "";
            this.id_TipoIvaDestinoLookUpEdit.Properties.ReadOnly = true;
            this.id_TipoIvaDestinoLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoIvaDestinoLookUpEdit.Size = new System.Drawing.Size(194, 20);
            this.id_TipoIvaDestinoLookUpEdit.TabIndex = 5;
            // 
            // id_TipoIvaOrigenLookUpEdit
            // 
            this.id_TipoIvaOrigenLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoIvaConfiguracionManagerBindingSource, "Config.Id_TipoIvaOrigen", true));
            this.id_TipoIvaOrigenLookUpEdit.Location = new System.Drawing.Point(103, 34);
            this.id_TipoIvaOrigenLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoIvaOrigenLookUpEdit.Name = "id_TipoIvaOrigenLookUpEdit";
            this.id_TipoIvaOrigenLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoIvaOrigenLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.id_TipoIvaOrigenLookUpEdit.Properties.NullText = "";
            this.id_TipoIvaOrigenLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoIvaOrigenLookUpEdit.Size = new System.Drawing.Size(194, 20);
            this.id_TipoIvaOrigenLookUpEdit.TabIndex = 3;
            // 
            // id_TipoComprobanteLookUpEdit
            // 
            this.id_TipoComprobanteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoIvaConfiguracionManagerBindingSource, "Config.Id_TipoComprobante", true));
            this.id_TipoComprobanteLookUpEdit.Location = new System.Drawing.Point(103, 8);
            this.id_TipoComprobanteLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoComprobanteLookUpEdit.Name = "id_TipoComprobanteLookUpEdit";
            this.id_TipoComprobanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoComprobanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_TipoComprobanteLookUpEdit.Properties.NullText = "";
            this.id_TipoComprobanteLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoComprobanteLookUpEdit.Size = new System.Drawing.Size(194, 20);
            this.id_TipoComprobanteLookUpEdit.TabIndex = 1;
            // 
            // frmTipoIva_Configuracion_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 154);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(352, 193);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(352, 193);
            this.Name = "frmTipoIva_Configuracion_AddMod";
            this.Text = "Alta/Modificación de Configuración";
            this.Load += new System.EventHandler(this.frmTipoIva_Configuracion_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.letraTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoIvaConfiguracionManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoIvaDestinoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoIvaOrigenLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoComprobanteLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit letraTextEdit;
        private System.Windows.Forms.BindingSource tipoIvaConfiguracionManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_TipoIvaDestinoLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoIvaOrigenLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoComprobanteLookUpEdit;
    }
}