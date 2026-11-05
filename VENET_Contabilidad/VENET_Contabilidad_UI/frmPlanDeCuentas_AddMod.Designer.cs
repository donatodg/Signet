namespace VENET_Contabilidad_UI
{
    partial class frmPlanDeCuentas_AddMod
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
            System.Windows.Forms.Label tituloLabel;
            System.Windows.Forms.Label capituloLabel;
            System.Windows.Forms.Label rubroLabel;
            System.Windows.Forms.Label cuentaLabel;
            System.Windows.Forms.Label subcuentaLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.lblRubro = new System.Windows.Forms.Label();
            this.lblCapitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.descripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.planDeCuentasManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subcuentaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cuentaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.rubroTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.capituloTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tituloTextEdit = new DevExpress.XtraEditors.TextEdit();
            tituloLabel = new System.Windows.Forms.Label();
            capituloLabel = new System.Windows.Forms.Label();
            rubroLabel = new System.Windows.Forms.Label();
            cuentaLabel = new System.Windows.Forms.Label();
            subcuentaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planDeCuentasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcuentaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubroTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capituloTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tituloTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tituloLabel
            // 
            tituloLabel.AutoSize = true;
            tituloLabel.Location = new System.Drawing.Point(38, 11);
            tituloLabel.Name = "tituloLabel";
            tituloLabel.Size = new System.Drawing.Size(37, 13);
            tituloLabel.TabIndex = 0;
            tituloLabel.Text = "Título:";
            // 
            // capituloLabel
            // 
            capituloLabel.AutoSize = true;
            capituloLabel.Location = new System.Drawing.Point(25, 37);
            capituloLabel.Name = "capituloLabel";
            capituloLabel.Size = new System.Drawing.Size(50, 13);
            capituloLabel.TabIndex = 2;
            capituloLabel.Text = "Capítulo:";
            // 
            // rubroLabel
            // 
            rubroLabel.AutoSize = true;
            rubroLabel.Location = new System.Drawing.Point(35, 63);
            rubroLabel.Name = "rubroLabel";
            rubroLabel.Size = new System.Drawing.Size(40, 13);
            rubroLabel.TabIndex = 4;
            rubroLabel.Text = "Rubro:";
            // 
            // cuentaLabel
            // 
            cuentaLabel.AutoSize = true;
            cuentaLabel.Location = new System.Drawing.Point(29, 89);
            cuentaLabel.Name = "cuentaLabel";
            cuentaLabel.Size = new System.Drawing.Size(46, 13);
            cuentaLabel.TabIndex = 6;
            cuentaLabel.Text = "Cuenta:";
            // 
            // subcuentaLabel
            // 
            subcuentaLabel.AutoSize = true;
            subcuentaLabel.Location = new System.Drawing.Point(13, 115);
            subcuentaLabel.Name = "subcuentaLabel";
            subcuentaLabel.Size = new System.Drawing.Size(62, 13);
            subcuentaLabel.TabIndex = 8;
            subcuentaLabel.Text = "Subcuenta:";
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
           // this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(500, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 181);
            //this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(500, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            //this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 157);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(500, 24);
            //this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 157);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.lblCuenta);
            this.groupControl1.Controls.Add(this.lblRubro);
            this.groupControl1.Controls.Add(this.lblCapitulo);
            this.groupControl1.Controls.Add(this.lblTitulo);
            this.groupControl1.Controls.Add(this.descripcionTextEdit);
            this.groupControl1.Controls.Add(subcuentaLabel);
            this.groupControl1.Controls.Add(this.subcuentaTextEdit);
            this.groupControl1.Controls.Add(cuentaLabel);
            this.groupControl1.Controls.Add(this.cuentaTextEdit);
            this.groupControl1.Controls.Add(rubroLabel);
            this.groupControl1.Controls.Add(this.rubroTextEdit);
            this.groupControl1.Controls.Add(capituloLabel);
            this.groupControl1.Controls.Add(this.capituloTextEdit);
            this.groupControl1.Controls.Add(tituloLabel);
            this.groupControl1.Controls.Add(this.tituloTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(476, 143);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // lblCuenta
            // 
            this.lblCuenta.Location = new System.Drawing.Point(136, 89);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(322, 18);
            this.lblCuenta.TabIndex = 14;
            // 
            // lblRubro
            // 
            this.lblRubro.Location = new System.Drawing.Point(136, 63);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(322, 18);
            this.lblRubro.TabIndex = 13;
            // 
            // lblCapitulo
            // 
            this.lblCapitulo.Location = new System.Drawing.Point(136, 37);
            this.lblCapitulo.Name = "lblCapitulo";
            this.lblCapitulo.Size = new System.Drawing.Size(322, 18);
            this.lblCapitulo.TabIndex = 12;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Location = new System.Drawing.Point(136, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(322, 18);
            this.lblTitulo.TabIndex = 11;
            // 
            // descripcionTextEdit
            // 
            this.descripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planDeCuentasManagerBindingSource, "CuentaContable.Descripcion", true));
            this.descripcionTextEdit.Location = new System.Drawing.Point(137, 112);
            this.descripcionTextEdit.MenuManager = this.barManager1;
            this.descripcionTextEdit.Name = "descripcionTextEdit";
            this.descripcionTextEdit.Properties.MaxLength = 500;
            this.descripcionTextEdit.Size = new System.Drawing.Size(321, 20);
            this.descripcionTextEdit.TabIndex = 5;
            this.descripcionTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descripcionTextEdit_KeyPress);
            // 
            // planDeCuentasManagerBindingSource
            // 
            this.planDeCuentasManagerBindingSource.DataSource = typeof(VENET_Contabilidad_BL.PlanDeCuentasManager);
            // 
            // subcuentaTextEdit
            // 
            this.subcuentaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planDeCuentasManagerBindingSource, "CuentaContable.Subcuenta", true));
            this.subcuentaTextEdit.EditValue = "";
            this.subcuentaTextEdit.EnterMoveNextControl = true;
            this.subcuentaTextEdit.Location = new System.Drawing.Point(81, 112);
            this.subcuentaTextEdit.MenuManager = this.barManager1;
            this.subcuentaTextEdit.Name = "subcuentaTextEdit";
            this.subcuentaTextEdit.Properties.DisplayFormat.FormatString = "000000";
            this.subcuentaTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.subcuentaTextEdit.Properties.Mask.EditMask = "\\d?\\d?\\d?\\d?\\d?\\d?";
            this.subcuentaTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.subcuentaTextEdit.Properties.MaxLength = 6;
            this.subcuentaTextEdit.Size = new System.Drawing.Size(50, 20);
            this.subcuentaTextEdit.TabIndex = 4;
            this.subcuentaTextEdit.Leave += new System.EventHandler(this.subcuentaTextEdit_Leave);
            // 
            // cuentaTextEdit
            // 
            this.cuentaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planDeCuentasManagerBindingSource, "CuentaContable.Cuenta", true));
            this.cuentaTextEdit.EnterMoveNextControl = true;
            this.cuentaTextEdit.Location = new System.Drawing.Point(81, 86);
            this.cuentaTextEdit.MenuManager = this.barManager1;
            this.cuentaTextEdit.Name = "cuentaTextEdit";
            this.cuentaTextEdit.Properties.DisplayFormat.FormatString = "00";
            this.cuentaTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cuentaTextEdit.Properties.Mask.EditMask = "\\d?\\d?";
            this.cuentaTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.cuentaTextEdit.Properties.MaxLength = 2;
            this.cuentaTextEdit.Size = new System.Drawing.Size(26, 20);
            this.cuentaTextEdit.TabIndex = 3;
            this.cuentaTextEdit.EditValueChanged += new System.EventHandler(this.cuentaTextEdit_EditValueChanged);
            this.cuentaTextEdit.Leave += new System.EventHandler(this.cuentaTextEdit_Leave);
            // 
            // rubroTextEdit
            // 
            this.rubroTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planDeCuentasManagerBindingSource, "CuentaContable.Rubro", true));
            this.rubroTextEdit.EnterMoveNextControl = true;
            this.rubroTextEdit.Location = new System.Drawing.Point(81, 60);
            this.rubroTextEdit.MenuManager = this.barManager1;
            this.rubroTextEdit.Name = "rubroTextEdit";
            this.rubroTextEdit.Properties.DisplayFormat.FormatString = "00";
            this.rubroTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rubroTextEdit.Properties.Mask.EditMask = "\\d?\\d?";
            this.rubroTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.rubroTextEdit.Properties.MaxLength = 2;
            this.rubroTextEdit.Size = new System.Drawing.Size(26, 20);
            this.rubroTextEdit.TabIndex = 2;
            this.rubroTextEdit.EditValueChanged += new System.EventHandler(this.rubroTextEdit_EditValueChanged);
            this.rubroTextEdit.Leave += new System.EventHandler(this.rubroTextEdit_Leave);
            // 
            // capituloTextEdit
            // 
            this.capituloTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planDeCuentasManagerBindingSource, "CuentaContable.Capitulo", true));
            this.capituloTextEdit.EnterMoveNextControl = true;
            this.capituloTextEdit.Location = new System.Drawing.Point(81, 34);
            this.capituloTextEdit.MenuManager = this.barManager1;
            this.capituloTextEdit.Name = "capituloTextEdit";
            this.capituloTextEdit.Properties.DisplayFormat.FormatString = "00";
            this.capituloTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.capituloTextEdit.Properties.Mask.EditMask = "\\d?\\d?";
            this.capituloTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.capituloTextEdit.Properties.MaxLength = 2;
            this.capituloTextEdit.Size = new System.Drawing.Size(26, 20);
            this.capituloTextEdit.TabIndex = 1;
            this.capituloTextEdit.EditValueChanged += new System.EventHandler(this.capituloTextEdit_EditValueChanged);
            this.capituloTextEdit.Leave += new System.EventHandler(this.capituloTextEdit_Leave);
            // 
            // tituloTextEdit
            // 
            this.tituloTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.planDeCuentasManagerBindingSource, "CuentaContable.Titulo", true));
            this.tituloTextEdit.EditValue = "";
            this.tituloTextEdit.EnterMoveNextControl = true;
            this.tituloTextEdit.Location = new System.Drawing.Point(81, 8);
            this.tituloTextEdit.MenuManager = this.barManager1;
            this.tituloTextEdit.Name = "tituloTextEdit";
            this.tituloTextEdit.Properties.DisplayFormat.FormatString = "00";
            this.tituloTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tituloTextEdit.Properties.EditFormat.FormatString = "00";
            this.tituloTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tituloTextEdit.Properties.Mask.EditMask = "\\d?\\d?";
            this.tituloTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.tituloTextEdit.Properties.MaxLength = 2;
            this.tituloTextEdit.Size = new System.Drawing.Size(26, 20);
            this.tituloTextEdit.TabIndex = 0;
            this.tituloTextEdit.EditValueChanged += new System.EventHandler(this.tituloTextEdit_EditValueChanged);
            this.tituloTextEdit.Leave += new System.EventHandler(this.tituloTextEdit_Leave);
            // 
            // frmPlanDeCuentas_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 181);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(516, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(516, 220);
            this.Name = "frmPlanDeCuentas_AddMod";
            this.Text = "Alta/Modificación de Cuentas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlanDeCuentas_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmPlanDeCuentas_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planDeCuentasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcuentaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubroTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capituloTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tituloTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit descripcionTextEdit;
        private System.Windows.Forms.BindingSource planDeCuentasManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit subcuentaTextEdit;
        private DevExpress.XtraEditors.TextEdit cuentaTextEdit;
        private DevExpress.XtraEditors.TextEdit rubroTextEdit;
        private DevExpress.XtraEditors.TextEdit capituloTextEdit;
        private DevExpress.XtraEditors.TextEdit tituloTextEdit;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.Label lblCapitulo;
        private System.Windows.Forms.Label lblTitulo;
    }
}