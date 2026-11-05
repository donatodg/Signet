namespace VENET_Tesoreria_UI
{
    partial class frmEspeciesCtaCte_AddMod
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
            System.Windows.Forms.Label conceptoLabel;
            System.Windows.Forms.Label creditoLabel;
            System.Windows.Forms.Label debitoLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label Id_TipoComprobanteLabel;
            System.Windows.Forms.Label id_CentroCostoLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_CentroCostoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.especiesCtaCteManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conceptoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.creditoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.debitoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fechaDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.Id_TipoComprobanteLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            conceptoLabel = new System.Windows.Forms.Label();
            creditoLabel = new System.Windows.Forms.Label();
            debitoLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            Id_TipoComprobanteLabel = new System.Windows.Forms.Label();
            id_CentroCostoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesCtaCteManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debitoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Id_TipoComprobanteLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // conceptoLabel
            // 
            conceptoLabel.AutoSize = true;
            conceptoLabel.Location = new System.Drawing.Point(44, 94);
            conceptoLabel.Name = "conceptoLabel";
            conceptoLabel.Size = new System.Drawing.Size(57, 13);
            conceptoLabel.TabIndex = 0;
            conceptoLabel.Text = "Concepto:";
            // 
            // creditoLabel
            // 
            creditoLabel.AutoSize = true;
            creditoLabel.Location = new System.Drawing.Point(56, 146);
            creditoLabel.Name = "creditoLabel";
            creditoLabel.Size = new System.Drawing.Size(44, 13);
            creditoLabel.TabIndex = 2;
            creditoLabel.Text = "Egreso:";
            // 
            // debitoLabel
            // 
            debitoLabel.AutoSize = true;
            debitoLabel.Location = new System.Drawing.Point(52, 120);
            debitoLabel.Name = "debitoLabel";
            debitoLabel.Size = new System.Drawing.Size(48, 13);
            debitoLabel.TabIndex = 4;
            debitoLabel.Text = "Ingreso:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(60, 16);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(40, 13);
            fechaLabel.TabIndex = 6;
            fechaLabel.Text = "Fecha:";
            // 
            // Id_TipoComprobanteLabel
            // 
            Id_TipoComprobanteLabel.AutoSize = true;
            Id_TipoComprobanteLabel.Location = new System.Drawing.Point(12, 68);
            Id_TipoComprobanteLabel.Name = "Id_TipoComprobanteLabel";
            Id_TipoComprobanteLabel.Size = new System.Drawing.Size(88, 13);
            Id_TipoComprobanteLabel.TabIndex = 14;
            Id_TipoComprobanteLabel.Text = "Tipo Movimiento:";
            // 
            // id_CentroCostoLabel
            // 
            id_CentroCostoLabel.AutoSize = true;
            id_CentroCostoLabel.Location = new System.Drawing.Point(14, 42);
            id_CentroCostoLabel.Name = "id_CentroCostoLabel";
            id_CentroCostoLabel.Size = new System.Drawing.Size(90, 13);
            id_CentroCostoLabel.TabIndex = 14;
            id_CentroCostoLabel.Text = "Centro de Costo:";
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
            this.btnAgregar});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAgregar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Aceptar";
            this.btnAgregar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.save_16x16;
            this.btnAgregar.Id = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(376, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 220);
            this.barDockControlBottom.Size = new System.Drawing.Size(376, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 196);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(376, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 196);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(id_CentroCostoLabel);
            this.groupControl1.Controls.Add(this.id_CentroCostoLookUpEdit);
            this.groupControl1.Controls.Add(conceptoLabel);
            this.groupControl1.Controls.Add(this.conceptoTextEdit);
            this.groupControl1.Controls.Add(creditoLabel);
            this.groupControl1.Controls.Add(this.creditoTextEdit);
            this.groupControl1.Controls.Add(debitoLabel);
            this.groupControl1.Controls.Add(this.debitoTextEdit);
            this.groupControl1.Controls.Add(fechaLabel);
            this.groupControl1.Controls.Add(this.fechaDateEdit);
            this.groupControl1.Controls.Add(Id_TipoComprobanteLabel);
            this.groupControl1.Controls.Add(this.Id_TipoComprobanteLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(352, 180);
            this.groupControl1.TabIndex = 0;
            // 
            // id_CentroCostoLookUpEdit
            // 
            this.id_CentroCostoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManagerBindingSource, "EspecieCtaCte.Id_CentroCosto", true));
            this.id_CentroCostoLookUpEdit.EnterMoveNextControl = true;
            this.id_CentroCostoLookUpEdit.Location = new System.Drawing.Point(106, 39);
            this.id_CentroCostoLookUpEdit.MenuManager = this.barManager1;
            this.id_CentroCostoLookUpEdit.Name = "id_CentroCostoLookUpEdit";
            this.id_CentroCostoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CentroCostoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Valor")});
            this.id_CentroCostoLookUpEdit.Properties.DisplayMember = "Name";
            this.id_CentroCostoLookUpEdit.Properties.NullText = "";
            this.id_CentroCostoLookUpEdit.Properties.ShowHeader = false;
            this.id_CentroCostoLookUpEdit.Properties.ValueMember = "Key";
            this.id_CentroCostoLookUpEdit.Size = new System.Drawing.Size(226, 20);
            this.id_CentroCostoLookUpEdit.TabIndex = 2;
            // 
            // especiesCtaCteManagerBindingSource
            // 
            this.especiesCtaCteManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.EspeciesCtaCteManager);
            this.especiesCtaCteManagerBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.especiesCtaCteManagerBindingSource_BindingComplete);
            // 
            // conceptoTextEdit
            // 
            this.conceptoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManagerBindingSource, "EspecieCtaCte.Concepto", true));
            this.conceptoTextEdit.EnterMoveNextControl = true;
            this.conceptoTextEdit.Location = new System.Drawing.Point(106, 91);
            this.conceptoTextEdit.MenuManager = this.barManager1;
            this.conceptoTextEdit.Name = "conceptoTextEdit";
            this.conceptoTextEdit.Properties.MaxLength = 200;
            this.conceptoTextEdit.Size = new System.Drawing.Size(226, 20);
            this.conceptoTextEdit.TabIndex = 4;
            this.conceptoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // creditoTextEdit
            // 
            this.creditoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManagerBindingSource, "EspecieCtaCte.Credito", true));
            this.creditoTextEdit.EnterMoveNextControl = true;
            this.creditoTextEdit.Location = new System.Drawing.Point(106, 143);
            this.creditoTextEdit.MenuManager = this.barManager1;
            this.creditoTextEdit.Name = "creditoTextEdit";
            this.creditoTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.creditoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.creditoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.creditoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.creditoTextEdit.TabIndex = 6;
            this.creditoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            this.creditoTextEdit.Leave += new System.EventHandler(this.creditoTextEdit_Leave);
            // 
            // debitoTextEdit
            // 
            this.debitoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManagerBindingSource, "EspecieCtaCte.Debito", true));
            this.debitoTextEdit.EnterMoveNextControl = true;
            this.debitoTextEdit.Location = new System.Drawing.Point(106, 117);
            this.debitoTextEdit.MenuManager = this.barManager1;
            this.debitoTextEdit.Name = "debitoTextEdit";
            this.debitoTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.debitoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.debitoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.debitoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.debitoTextEdit.TabIndex = 5;
            this.debitoTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            this.debitoTextEdit.Leave += new System.EventHandler(this.debitoTextEdit_Leave);
            // 
            // fechaDateEdit
            // 
            this.fechaDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManagerBindingSource, "EspecieCtaCte.Fecha", true));
            this.fechaDateEdit.EditValue = null;
            this.fechaDateEdit.Enabled = false;
            this.fechaDateEdit.EnterMoveNextControl = true;
            this.fechaDateEdit.Location = new System.Drawing.Point(106, 13);
            this.fechaDateEdit.MenuManager = this.barManager1;
            this.fechaDateEdit.Name = "fechaDateEdit";
            this.fechaDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDateEdit.Size = new System.Drawing.Size(100, 20);
            this.fechaDateEdit.TabIndex = 0;
            // 
            // Id_TipoComprobanteLookUpEdit
            // 
            this.Id_TipoComprobanteLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.especiesCtaCteManagerBindingSource, "EspecieCtaCte.Id_TipoComprobante", true));
            this.Id_TipoComprobanteLookUpEdit.EnterMoveNextControl = true;
            this.Id_TipoComprobanteLookUpEdit.Location = new System.Drawing.Point(106, 65);
            this.Id_TipoComprobanteLookUpEdit.MenuManager = this.barManager1;
            this.Id_TipoComprobanteLookUpEdit.Name = "Id_TipoComprobanteLookUpEdit";
            this.Id_TipoComprobanteLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Id_TipoComprobanteLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Valor")});
            this.Id_TipoComprobanteLookUpEdit.Properties.NullText = "";
            this.Id_TipoComprobanteLookUpEdit.Properties.ShowHeader = false;
            this.Id_TipoComprobanteLookUpEdit.Size = new System.Drawing.Size(226, 20);
            this.Id_TipoComprobanteLookUpEdit.TabIndex = 3;
            // 
            // frmEspeciesCtaCte_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 220);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(392, 259);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(392, 259);
            this.Name = "frmEspeciesCtaCte_AddMod";
            this.Text = "Alta/Modificación de Cta Cte de Especies";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEspeciesCtaCte_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmEspeciesCtaCte_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especiesCtaCteManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debitoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Id_TipoComprobanteLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit conceptoTextEdit;
        private System.Windows.Forms.BindingSource especiesCtaCteManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit creditoTextEdit;
        private DevExpress.XtraEditors.TextEdit debitoTextEdit;
        private DevExpress.XtraEditors.DateEdit fechaDateEdit;
        private DevExpress.XtraEditors.LookUpEdit Id_TipoComprobanteLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CentroCostoLookUpEdit;
    }
}