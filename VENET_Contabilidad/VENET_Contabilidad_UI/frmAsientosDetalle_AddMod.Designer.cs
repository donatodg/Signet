namespace VENET_Contabilidad_UI
{
    partial class frmAsientosDetalle_AddMod
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
            System.Windows.Forms.Label id_CuentaContableLabel;
            System.Windows.Forms.Label debeLabel;
            System.Windows.Forms.Label haberLabel;
            System.Windows.Forms.Label ordenLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ordenTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.asientosDetalleManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.haberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.debeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_CuentaContableLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_CuentaContableLabel = new System.Windows.Forms.Label();
            debeLabel = new System.Windows.Forms.Label();
            haberLabel = new System.Windows.Forms.Label();
            ordenLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordenTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asientosDetalleManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.haberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CuentaContableLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_CuentaContableLabel
            // 
            id_CuentaContableLabel.AutoSize = true;
            id_CuentaContableLabel.Location = new System.Drawing.Point(13, 36);
            id_CuentaContableLabel.Name = "id_CuentaContableLabel";
            id_CuentaContableLabel.Size = new System.Drawing.Size(92, 13);
            id_CuentaContableLabel.TabIndex = 0;
            id_CuentaContableLabel.Text = "Cuenta Contable:";
            // 
            // debeLabel
            // 
            debeLabel.AutoSize = true;
            debeLabel.Location = new System.Drawing.Point(69, 62);
            debeLabel.Name = "debeLabel";
            debeLabel.Size = new System.Drawing.Size(36, 13);
            debeLabel.TabIndex = 2;
            debeLabel.Text = "Debe:";
            // 
            // haberLabel
            // 
            haberLabel.AutoSize = true;
            haberLabel.Location = new System.Drawing.Point(66, 88);
            haberLabel.Name = "haberLabel";
            haberLabel.Size = new System.Drawing.Size(40, 13);
            haberLabel.TabIndex = 4;
            haberLabel.Text = "Haber:";
            // 
            // ordenLabel
            // 
            ordenLabel.AutoSize = true;
            ordenLabel.Location = new System.Drawing.Point(64, 10);
            ordenLabel.Name = "ordenLabel";
            ordenLabel.Size = new System.Drawing.Size(41, 13);
            ordenLabel.TabIndex = 6;
            ordenLabel.Text = "Orden:";
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
            this.btnAceptar.Id = 0;
            this.btnAceptar.Glyph = global::VENET_Contabilidad_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            //this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(411, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 156);
            ////this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(411, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            ////this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 132);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(411, 24);
            ////this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 132);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(ordenLabel);
            this.groupControl1.Controls.Add(this.ordenTextEdit);
            this.groupControl1.Controls.Add(haberLabel);
            this.groupControl1.Controls.Add(this.haberTextEdit);
            this.groupControl1.Controls.Add(debeLabel);
            this.groupControl1.Controls.Add(this.debeTextEdit);
            this.groupControl1.Controls.Add(id_CuentaContableLabel);
            this.groupControl1.Controls.Add(this.id_CuentaContableLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(387, 116);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // ordenTextEdit
            // 
            this.ordenTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.asientosDetalleManagerBindingSource, "Detalle.Orden", true));
            this.ordenTextEdit.EnterMoveNextControl = true;
            this.ordenTextEdit.Location = new System.Drawing.Point(111, 7);
            this.ordenTextEdit.MenuManager = this.barManager1;
            this.ordenTextEdit.Name = "ordenTextEdit";
            this.ordenTextEdit.Size = new System.Drawing.Size(100, 20);
            this.ordenTextEdit.TabIndex = 0;
            // 
            // asientosDetalleManagerBindingSource
            // 
            this.asientosDetalleManagerBindingSource.DataSource = typeof(VENET_Contabilidad_BL.AsientosDetalleManager);
            // 
            // haberTextEdit
            // 
            this.haberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.asientosDetalleManagerBindingSource, "Detalle.Haber", true));
            this.haberTextEdit.Location = new System.Drawing.Point(112, 85);
            this.haberTextEdit.MenuManager = this.barManager1;
            this.haberTextEdit.Name = "haberTextEdit";
            this.haberTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.haberTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.haberTextEdit.Properties.EditFormat.FormatString = "n";
            this.haberTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.haberTextEdit.Properties.Mask.EditMask = "n";
            this.haberTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.haberTextEdit.Size = new System.Drawing.Size(100, 20);
            this.haberTextEdit.TabIndex = 3;
            this.haberTextEdit.EditValueChanged += new System.EventHandler(this.haberTextEdit_EditValueChanged);
            this.haberTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.haberTextEdit_KeyPress);
            // 
            // debeTextEdit
            // 
            this.debeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.asientosDetalleManagerBindingSource, "Detalle.Debe", true));
            this.debeTextEdit.EnterMoveNextControl = true;
            this.debeTextEdit.Location = new System.Drawing.Point(111, 59);
            this.debeTextEdit.MenuManager = this.barManager1;
            this.debeTextEdit.Name = "debeTextEdit";
            this.debeTextEdit.Properties.DisplayFormat.FormatString = "n";
            this.debeTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.debeTextEdit.Properties.EditFormat.FormatString = "n";
            this.debeTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.debeTextEdit.Properties.Mask.EditMask = "n";
            this.debeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.debeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.debeTextEdit.TabIndex = 2;
            this.debeTextEdit.EditValueChanged += new System.EventHandler(this.debeTextEdit_EditValueChanged);
            // 
            // id_CuentaContableLookUpEdit
            // 
            this.id_CuentaContableLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.asientosDetalleManagerBindingSource, "Detalle.Id_CuentaContable", true));
            this.id_CuentaContableLookUpEdit.EnterMoveNextControl = true;
            this.id_CuentaContableLookUpEdit.Location = new System.Drawing.Point(111, 33);
            this.id_CuentaContableLookUpEdit.MenuManager = this.barManager1;
            this.id_CuentaContableLookUpEdit.Name = "id_CuentaContableLookUpEdit";
            this.id_CuentaContableLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_CuentaContableLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name2", 15, "Nro. Cuenta"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Cuenta")});
            this.id_CuentaContableLookUpEdit.Properties.NullText = "";
            this.id_CuentaContableLookUpEdit.Properties.PopupWidth = 350;
            this.id_CuentaContableLookUpEdit.Size = new System.Drawing.Size(264, 20);
            this.id_CuentaContableLookUpEdit.TabIndex = 1;
            // 
            // frmAsientosDetalle_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 156);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(427, 195);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(427, 195);
            this.Name = "frmAsientosDetalle_AddMod";
            this.Text = "Alta/Modificación de Detalle";
            this.Load += new System.EventHandler(this.frmAsientosDetalle_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordenTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asientosDetalleManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.haberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_CuentaContableLookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAceptar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit haberTextEdit;
        private System.Windows.Forms.BindingSource asientosDetalleManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit debeTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_CuentaContableLookUpEdit;
        private DevExpress.XtraEditors.TextEdit ordenTextEdit;
    }
}