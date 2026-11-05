namespace VENET_Tesoreria_UI
{
    partial class frmReciboDetalle_AddMod
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
            System.Windows.Forms.Label id_EspecieLabel;
            System.Windows.Forms.Label importeLabel;
            System.Windows.Forms.Label detalleLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReciboDetalle_AddMod));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.detalleTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.reciboDetalleManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.importeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_EspecieLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_EspecieLabel = new System.Windows.Forms.Label();
            importeLabel = new System.Windows.Forms.Label();
            detalleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detalleTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboDetalleManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_EspecieLabel
            // 
            id_EspecieLabel.AutoSize = true;
            id_EspecieLabel.Location = new System.Drawing.Point(32, 17);
            id_EspecieLabel.Name = "id_EspecieLabel";
            id_EspecieLabel.Size = new System.Drawing.Size(47, 13);
            id_EspecieLabel.TabIndex = 0;
            id_EspecieLabel.Text = "Especie:";
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(30, 43);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(49, 13);
            importeLabel.TabIndex = 2;
            importeLabel.Text = "Importe:";
            // 
            // detalleLabel
            // 
            detalleLabel.AutoSize = true;
            detalleLabel.Location = new System.Drawing.Point(35, 69);
            detalleLabel.Name = "detalleLabel";
            detalleLabel.Size = new System.Drawing.Size(44, 13);
            detalleLabel.TabIndex = 4;
            detalleLabel.Text = "Detalle:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(423, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 139);
            this.barDockControlBottom.Size = new System.Drawing.Size(423, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 115);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(423, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 115);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(detalleLabel);
            this.groupControl1.Controls.Add(this.detalleTextEdit);
            this.groupControl1.Controls.Add(importeLabel);
            this.groupControl1.Controls.Add(this.importeTextEdit);
            this.groupControl1.Controls.Add(id_EspecieLabel);
            this.groupControl1.Controls.Add(this.id_EspecieLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(399, 97);
            this.groupControl1.TabIndex = 4;
            // 
            // detalleTextEdit
            // 
            this.detalleTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reciboDetalleManagerBindingSource, "ReciboDetalle.Detalle", true));
            this.detalleTextEdit.EnterMoveNextControl = true;
            this.detalleTextEdit.Location = new System.Drawing.Point(85, 66);
            this.detalleTextEdit.MenuManager = this.barManager1;
            this.detalleTextEdit.Name = "detalleTextEdit";
            this.detalleTextEdit.Size = new System.Drawing.Size(297, 20);
            this.detalleTextEdit.TabIndex = 5;
            this.detalleTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            this.detalleTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.detalleTextEdit_KeyPress);
            // 
            // reciboDetalleManagerBindingSource
            // 
            this.reciboDetalleManagerBindingSource.DataSource = typeof(VENET_Tesoreria_BL.ReciboDetalleManager);
            // 
            // importeTextEdit
            // 
            this.importeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reciboDetalleManagerBindingSource, "ReciboDetalle.Importe", true));
            this.importeTextEdit.EnterMoveNextControl = true;
            this.importeTextEdit.Location = new System.Drawing.Point(85, 40);
            this.importeTextEdit.MenuManager = this.barManager1;
            this.importeTextEdit.Name = "importeTextEdit";
            this.importeTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.importeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.importeTextEdit.Properties.Mask.EditMask = "n";
            this.importeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.importeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.importeTextEdit.TabIndex = 3;
            this.importeTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // id_EspecieLookUpEdit
            // 
            this.id_EspecieLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.reciboDetalleManagerBindingSource, "IdEspecie", true));
            this.id_EspecieLookUpEdit.EnterMoveNextControl = true;
            this.id_EspecieLookUpEdit.Location = new System.Drawing.Point(85, 14);
            this.id_EspecieLookUpEdit.MenuManager = this.barManager1;
            this.id_EspecieLookUpEdit.Name = "id_EspecieLookUpEdit";
            this.id_EspecieLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EspecieLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Valor")});
            this.id_EspecieLookUpEdit.Properties.DisplayMember = "Name";
            this.id_EspecieLookUpEdit.Properties.NullText = "";
            this.id_EspecieLookUpEdit.Properties.ShowHeader = false;
            this.id_EspecieLookUpEdit.Properties.ValueMember = "Key";
            this.id_EspecieLookUpEdit.Size = new System.Drawing.Size(142, 20);
            this.id_EspecieLookUpEdit.TabIndex = 1;
            this.id_EspecieLookUpEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // frmReciboDetalle_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 139);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(439, 178);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(439, 178);
            this.Name = "frmReciboDetalle_AddMod";
            this.Text = "Alta/Modificación de Detalle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReciboDetalle_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmReciboDetalle_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detalleTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboDetalleManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit detalleTextEdit;
        private DevExpress.XtraEditors.TextEdit importeTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EspecieLookUpEdit;
        private System.Windows.Forms.BindingSource reciboDetalleManagerBindingSource;
    }
}