namespace VENET_Clientes_UI
{
    partial class frmClientesDescuentos_AddMod
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
            System.Windows.Forms.Label id_Categoria2Label;
            System.Windows.Forms.Label descuentoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientesDescuentos_AddMod));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.descuentoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.clientesDescuentosManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_Categoria2LookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_Categoria2Label = new System.Windows.Forms.Label();
            descuentoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDescuentosManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_Categoria2LookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_Categoria2Label
            // 
            id_Categoria2Label.AutoSize = true;
            id_Categoria2Label.Location = new System.Drawing.Point(13, 12);
            id_Categoria2Label.Name = "id_Categoria2Label";
            id_Categoria2Label.Size = new System.Drawing.Size(67, 13);
            id_Categoria2Label.TabIndex = 0;
            id_Categoria2Label.Text = "Categoría 2:";
            // 
            // descuentoLabel
            // 
            descuentoLabel.AutoSize = true;
            descuentoLabel.Location = new System.Drawing.Point(18, 38);
            descuentoLabel.Name = "descuentoLabel";
            descuentoLabel.Size = new System.Drawing.Size(62, 13);
            descuentoLabel.TabIndex = 2;
            descuentoLabel.Text = "Descuento:";
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
            this.btnAceptar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Glyph")));
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 104);
            this.barDockControlBottom.Size = new System.Drawing.Size(338, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(338, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 80);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(descuentoLabel);
            this.groupControl1.Controls.Add(this.descuentoTextEdit);
            this.groupControl1.Controls.Add(id_Categoria2Label);
            this.groupControl1.Controls.Add(this.id_Categoria2LookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(314, 64);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // descuentoTextEdit
            // 
            this.descuentoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesDescuentosManagerBindingSource, "Descuento.Descuento", true));
            this.descuentoTextEdit.EnterMoveNextControl = true;
            this.descuentoTextEdit.Location = new System.Drawing.Point(86, 35);
            this.descuentoTextEdit.MenuManager = this.barManager1;
            this.descuentoTextEdit.Name = "descuentoTextEdit";
            this.descuentoTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.descuentoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.descuentoTextEdit.Properties.EditFormat.FormatString = "n";
            this.descuentoTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.descuentoTextEdit.Properties.Mask.EditMask = "n";
            this.descuentoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.descuentoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.descuentoTextEdit.TabIndex = 3;
            // 
            // clientesDescuentosManagerBindingSource
            // 
            this.clientesDescuentosManagerBindingSource.DataSource = typeof(VENET_Clientes_BL.ClientesDescuentosManager);
            // 
            // id_Categoria2LookUpEdit
            // 
            this.id_Categoria2LookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.clientesDescuentosManagerBindingSource, "Descuento.Id_Categoria2", true));
            this.id_Categoria2LookUpEdit.EnterMoveNextControl = true;
            this.id_Categoria2LookUpEdit.Location = new System.Drawing.Point(86, 9);
            this.id_Categoria2LookUpEdit.MenuManager = this.barManager1;
            this.id_Categoria2LookUpEdit.Name = "id_Categoria2LookUpEdit";
            this.id_Categoria2LookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.id_Categoria2LookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.id_Categoria2LookUpEdit.Properties.NullText = "TODAS";
            this.id_Categoria2LookUpEdit.Properties.ShowHeader = false;
            this.id_Categoria2LookUpEdit.Size = new System.Drawing.Size(211, 20);
            this.id_Categoria2LookUpEdit.TabIndex = 1;
            this.id_Categoria2LookUpEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.id_Categoria2LookUpEdit_ButtonPressed);
            // 
            // frmClientesDescuentos_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 104);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(354, 143);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(354, 143);
            this.Name = "frmClientesDescuentos_AddMod";
            this.Text = "Alta/Modificación de Descuentos";
            this.Load += new System.EventHandler(this.frmClientesDescuentos_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDescuentosManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_Categoria2LookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit descuentoTextEdit;
        private System.Windows.Forms.BindingSource clientesDescuentosManagerBindingSource;
        private DevExpress.XtraEditors.LookUpEdit id_Categoria2LookUpEdit;
    }
}