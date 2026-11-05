namespace VENET_Gestion_UI
{
    partial class frmTipoImpuestos_AddMod
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
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label id_TipoImpuestoLabel;
            System.Windows.Forms.Label aplicaSobreLabel;
            System.Windows.Forms.Label id_AFIP_TributosLabel;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_AFIP_TributosLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tipoImpuestosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.aplicaSobreLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.id_TipoImpuestoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            descripcionLabel = new System.Windows.Forms.Label();
            id_TipoImpuestoLabel = new System.Windows.Forms.Label();
            aplicaSobreLabel = new System.Windows.Forms.Label();
            id_AFIP_TributosLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_AFIP_TributosLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplicaSobreLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoImpuestoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(14, 13);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 0;
            descripcionLabel.Text = "Descripción:";
            // 
            // id_TipoImpuestoLabel
            // 
            id_TipoImpuestoLabel.AutoSize = true;
            id_TipoImpuestoLabel.Location = new System.Drawing.Point(48, 39);
            id_TipoImpuestoLabel.Name = "id_TipoImpuestoLabel";
            id_TipoImpuestoLabel.Size = new System.Drawing.Size(31, 13);
            id_TipoImpuestoLabel.TabIndex = 2;
            id_TipoImpuestoLabel.Text = "Tipo:";
            // 
            // aplicaSobreLabel
            // 
            aplicaSobreLabel.AutoSize = true;
            aplicaSobreLabel.Location = new System.Drawing.Point(9, 65);
            aplicaSobreLabel.Name = "aplicaSobreLabel";
            aplicaSobreLabel.Size = new System.Drawing.Size(70, 13);
            aplicaSobreLabel.TabIndex = 4;
            aplicaSobreLabel.Text = "Aplica Sobre:";
            // 
            // id_AFIP_TributosLabel
            // 
            id_AFIP_TributosLabel.AutoSize = true;
            id_AFIP_TributosLabel.Location = new System.Drawing.Point(8, 91);
            id_AFIP_TributosLabel.Name = "id_AFIP_TributosLabel";
            id_AFIP_TributosLabel.Size = new System.Drawing.Size(71, 13);
            id_AFIP_TributosLabel.TabIndex = 6;
            id_AFIP_TributosLabel.Text = "AFIP Tributo:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(id_AFIP_TributosLabel);
            this.groupControl1.Controls.Add(this.id_AFIP_TributosLookUpEdit);
            this.groupControl1.Controls.Add(aplicaSobreLabel);
            this.groupControl1.Controls.Add(this.aplicaSobreLookUpEdit);
            this.groupControl1.Controls.Add(id_TipoImpuestoLabel);
            this.groupControl1.Controls.Add(this.id_TipoImpuestoLookUpEdit);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(336, 123);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_AFIP_TributosLookUpEdit
            // 
            this.id_AFIP_TributosLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoImpuestosManagerBindingSource, "Impuesto.Id_AFIP_Tributos", true));
            this.id_AFIP_TributosLookUpEdit.EnterMoveNextControl = true;
            this.id_AFIP_TributosLookUpEdit.Location = new System.Drawing.Point(85, 88);
            this.id_AFIP_TributosLookUpEdit.MenuManager = this.barManager1;
            this.id_AFIP_TributosLookUpEdit.Name = "id_AFIP_TributosLookUpEdit";
            this.id_AFIP_TributosLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_AFIP_TributosLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_AFIP_TributosLookUpEdit.Properties.NullText = "";
            this.id_AFIP_TributosLookUpEdit.Properties.ShowHeader = false;
            this.id_AFIP_TributosLookUpEdit.Size = new System.Drawing.Size(233, 20);
            this.id_AFIP_TributosLookUpEdit.TabIndex = 7;
            this.id_AFIP_TributosLookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonPressed);
            // 
            // tipoImpuestosManagerBindingSource
            // 
            this.tipoImpuestosManagerBindingSource.DataSource = typeof(VENET_Gestion_BL.TipoImpuestosManager);
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
            this.barDockControlTop.Size = new System.Drawing.Size(360, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 161);
            this.barDockControlBottom.Size = new System.Drawing.Size(360, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 137);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(360, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 137);
            // 
            // aplicaSobreLookUpEdit
            // 
            this.aplicaSobreLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoImpuestosManagerBindingSource, "Impuesto.AplicaSobre", true));
            this.aplicaSobreLookUpEdit.EnterMoveNextControl = true;
            this.aplicaSobreLookUpEdit.Location = new System.Drawing.Point(85, 62);
            this.aplicaSobreLookUpEdit.MenuManager = this.barManager1;
            this.aplicaSobreLookUpEdit.Name = "aplicaSobreLookUpEdit";
            this.aplicaSobreLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.aplicaSobreLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name2")});
            this.aplicaSobreLookUpEdit.Properties.NullText = "";
            this.aplicaSobreLookUpEdit.Properties.ShowHeader = false;
            this.aplicaSobreLookUpEdit.Size = new System.Drawing.Size(233, 20);
            this.aplicaSobreLookUpEdit.TabIndex = 2;
            // 
            // id_TipoImpuestoLookUpEdit
            // 
            this.id_TipoImpuestoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoImpuestosManagerBindingSource, "Impuesto.Id_TipoImpuesto", true));
            this.id_TipoImpuestoLookUpEdit.EnterMoveNextControl = true;
            this.id_TipoImpuestoLookUpEdit.Location = new System.Drawing.Point(85, 36);
            this.id_TipoImpuestoLookUpEdit.MenuManager = this.barManager1;
            this.id_TipoImpuestoLookUpEdit.Name = "id_TipoImpuestoLookUpEdit";
            this.id_TipoImpuestoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_TipoImpuestoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Name1")});
            this.id_TipoImpuestoLookUpEdit.Properties.NullText = "";
            this.id_TipoImpuestoLookUpEdit.Properties.ShowHeader = false;
            this.id_TipoImpuestoLookUpEdit.Size = new System.Drawing.Size(233, 20);
            this.id_TipoImpuestoLookUpEdit.TabIndex = 1;
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tipoImpuestosManagerBindingSource, "Impuesto.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(85, 10);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Properties.MaxLength = 100;
            this.descripcionTextEdit.Size = new System.Drawing.Size(233, 20);
            this.descripcionTextEdit.TabIndex = 0;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmTipoImpuestos_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(360, 161);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(376, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(376, 200);
            this.Name = "frmTipoImpuestos_AddMod";
            this.Text = "Alta/Modificación de Tipos de Impuestos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTipoImpuestos_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmTipoImpuestos_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_AFIP_TributosLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplicaSobreLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_TipoImpuestoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private System.Windows.Forms.BindingSource tipoImpuestosManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit aplicaSobreLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_TipoImpuestoLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_AFIP_TributosLookUpEdit;
    }
}