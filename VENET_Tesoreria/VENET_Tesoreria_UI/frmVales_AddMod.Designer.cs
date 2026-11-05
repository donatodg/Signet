namespace VENET_Tesoreria_UI
{
    partial class frmVales_AddMod
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
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label id_CentroCostoLabel;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.id_CentroCostoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.valesManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.id_PersonalLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.lnkPersonal = new System.Windows.Forms.LinkLabel();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            importeLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            id_CentroCostoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_PersonalLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(34, 65);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(49, 13);
            importeLabel.TabIndex = 2;
            importeLabel.Text = "Importe:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(18, 91);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(65, 13);
            descripcionLabel.TabIndex = 4;
            descripcionLabel.Text = "Descripción:";
            // 
            // id_CentroCostoLabel
            // 
            id_CentroCostoLabel.AutoSize = true;
            id_CentroCostoLabel.Location = new System.Drawing.Point(8, 13);
            id_CentroCostoLabel.Name = "id_CentroCostoLabel";
            id_CentroCostoLabel.Size = new System.Drawing.Size(75, 13);
            id_CentroCostoLabel.TabIndex = 12;
            id_CentroCostoLabel.Text = "Centro Costo:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(id_CentroCostoLabel);
            this.groupControl1.Controls.Add(this.id_CentroCostoLookUpEdit);
            this.groupControl1.Controls.Add(this.id_PersonalLookUpEdit);
            this.groupControl1.Controls.Add(this.lnkPersonal);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Controls.Add(importeLabel);
            this.groupControl1.Controls.Add(this.importeTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(400, 120);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // id_CentroCostoLookUpEdit
            // 
            this.id_CentroCostoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManagerBindingSource, "Vale.Id_CentroCosto", true));
            this.id_CentroCostoLookUpEdit.EnterMoveNextControl = true;
            this.id_CentroCostoLookUpEdit.Location = new System.Drawing.Point(88, 10);
            this.id_CentroCostoLookUpEdit.MenuManager = this.barManager1;
            this.id_CentroCostoLookUpEdit.Name = "id_CentroCostoLookUpEdit";
            this.id_CentroCostoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CentroCostoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.id_CentroCostoLookUpEdit.Properties.NullText = "";
            this.id_CentroCostoLookUpEdit.Properties.ShowHeader = false;
            this.id_CentroCostoLookUpEdit.Size = new System.Drawing.Size(291, 20);
            this.id_CentroCostoLookUpEdit.TabIndex = 1;
            // 
            // valesManagerBindingSource
            // 
            this.valesManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ValesManager);
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
            this.btnAceptar.Glyph = global::VENET_Tesoreria_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Id = 0;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(420, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 162);
            this.barDockControlBottom.Size = new System.Drawing.Size(420, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 138);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(420, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 138);
            // 
            // id_PersonalLookUpEdit
            // 
            this.id_PersonalLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManagerBindingSource, "Vale.Id_Personal", true));
            this.id_PersonalLookUpEdit.EnterMoveNextControl = true;
            this.id_PersonalLookUpEdit.Location = new System.Drawing.Point(88, 36);
            this.id_PersonalLookUpEdit.MenuManager = this.barManager1;
            this.id_PersonalLookUpEdit.Name = "id_PersonalLookUpEdit";
            this.id_PersonalLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_PersonalLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Legajo", 5, "Legajo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.id_PersonalLookUpEdit.Properties.NullText = "";
            this.id_PersonalLookUpEdit.Size = new System.Drawing.Size(291, 20);
            this.id_PersonalLookUpEdit.TabIndex = 2;
            // 
            // lnkPersonal
            // 
            this.lnkPersonal.AutoSize = true;
            this.lnkPersonal.Location = new System.Drawing.Point(31, 39);
            this.lnkPersonal.Name = "lnkPersonal";
            this.lnkPersonal.Size = new System.Drawing.Size(52, 13);
            this.lnkPersonal.TabIndex = 12;
            this.lnkPersonal.TabStop = true;
            this.lnkPersonal.Text = "Personal:";
            this.lnkPersonal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPersonal_LinkClicked);
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManagerBindingSource, "Vale.Descripcion", true));
            this.descripcionTextEdit.EnterMoveNextControl = true;
            this.descripcionTextEdit.Location = new System.Drawing.Point(88, 88);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Size = new System.Drawing.Size(291, 20);
            this.descripcionTextEdit.TabIndex = 4;
            this.descripcionTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.valesManagerBindingSource, "Vale.Importe", true));
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(88, 62);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.Mask.EditMask = "n";
            this.importeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.importeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.importeTextEdit.TabIndex = 3;
            this.importeTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmVales_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(420, 162);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(436, 201);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(436, 201);
            this.Name = "frmVales_AddMod";
            this.Text = "Alta/Modificación de Vales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVales_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmVales_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_CentroCostoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valesManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_PersonalLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
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
        private System.Windows.Forms.BindingSource valesManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private System.Windows.Forms.LinkLabel lnkPersonal;
        private DevExpress.XtraEditors.LookUpEdit id_PersonalLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CentroCostoLookUpEdit;
    }
}