namespace VENET_ProvFinancieros_UI
{
    partial class frmProvFinancierosCuentas_AddMod
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
            System.Windows.Forms.Label id_EntidadBancariaLabel;
            System.Windows.Forms.Label nroCuentaLabel;
            System.Windows.Forms.Label nroSucursalLabel;
            System.Windows.Forms.Label cBULabel;
            System.Windows.Forms.Label id_EspecieLabel;
            System.Windows.Forms.Label codPostalLabel;
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.codPostalTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.provFinancierosCuentasManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.id_EspecieLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.cBUTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nroSucursalTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nroCuentaTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.id_EntidadBancariaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            id_EntidadBancariaLabel = new System.Windows.Forms.Label();
            nroCuentaLabel = new System.Windows.Forms.Label();
            nroSucursalLabel = new System.Windows.Forms.Label();
            cBULabel = new System.Windows.Forms.Label();
            id_EspecieLabel = new System.Windows.Forms.Label();
            codPostalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codPostalTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provFinancierosCuentasManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBUTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroSucursalTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCuentaTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadBancariaLookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // id_EntidadBancariaLabel
            // 
            id_EntidadBancariaLabel.AutoSize = true;
            id_EntidadBancariaLabel.Location = new System.Drawing.Point(8, 37);
            id_EntidadBancariaLabel.Name = "id_EntidadBancariaLabel";
            id_EntidadBancariaLabel.Size = new System.Drawing.Size(91, 13);
            id_EntidadBancariaLabel.TabIndex = 0;
            id_EntidadBancariaLabel.Text = "Entidad Bancaria:";
            // 
            // nroCuentaLabel
            // 
            nroCuentaLabel.AutoSize = true;
            nroCuentaLabel.Location = new System.Drawing.Point(33, 63);
            nroCuentaLabel.Name = "nroCuentaLabel";
            nroCuentaLabel.Size = new System.Drawing.Size(66, 13);
            nroCuentaLabel.TabIndex = 4;
            nroCuentaLabel.Text = "Nro Cuenta:";
            // 
            // nroSucursalLabel
            // 
            nroSucursalLabel.AutoSize = true;
            nroSucursalLabel.Location = new System.Drawing.Point(28, 89);
            nroSucursalLabel.Name = "nroSucursalLabel";
            nroSucursalLabel.Size = new System.Drawing.Size(71, 13);
            nroSucursalLabel.TabIndex = 6;
            nroSucursalLabel.Text = "Nro Sucursal:";
            // 
            // cBULabel
            // 
            cBULabel.AutoSize = true;
            cBULabel.Location = new System.Drawing.Point(68, 141);
            cBULabel.Name = "cBULabel";
            cBULabel.Size = new System.Drawing.Size(31, 13);
            cBULabel.TabIndex = 8;
            cBULabel.Text = "CBU:";
            // 
            // id_EspecieLabel
            // 
            id_EspecieLabel.AutoSize = true;
            id_EspecieLabel.Location = new System.Drawing.Point(52, 11);
            id_EspecieLabel.Name = "id_EspecieLabel";
            id_EspecieLabel.Size = new System.Drawing.Size(47, 13);
            id_EspecieLabel.TabIndex = 9;
            id_EspecieLabel.Text = "Especie:";
            // 
            // codPostalLabel
            // 
            codPostalLabel.AutoSize = true;
            codPostalLabel.Location = new System.Drawing.Point(37, 115);
            codPostalLabel.Name = "codPostalLabel";
            codPostalLabel.Size = new System.Drawing.Size(62, 13);
            codPostalLabel.TabIndex = 10;
            codPostalLabel.Text = "Cod Postal:";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(codPostalLabel);
            this.groupControl1.Controls.Add(this.codPostalTextEdit);
            this.groupControl1.Controls.Add(id_EspecieLabel);
            this.groupControl1.Controls.Add(this.id_EspecieLookUpEdit);
            this.groupControl1.Controls.Add(cBULabel);
            this.groupControl1.Controls.Add(this.cBUTextEdit);
            this.groupControl1.Controls.Add(nroSucursalLabel);
            this.groupControl1.Controls.Add(this.nroSucursalTextEdit);
            this.groupControl1.Controls.Add(nroCuentaLabel);
            this.groupControl1.Controls.Add(this.nroCuentaTextEdit);
            this.groupControl1.Controls.Add(id_EntidadBancariaLabel);
            this.groupControl1.Controls.Add(this.id_EntidadBancariaLookUpEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 28);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(316, 168);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // codPostalTextEdit
            // 
            this.codPostalTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.provFinancierosCuentasManagerBindingSource, "Cuenta.CodPostal", true));
            this.codPostalTextEdit.EnterMoveNextControl = true;
            this.codPostalTextEdit.Location = new System.Drawing.Point(105, 112);
            this.codPostalTextEdit.MenuManager = this.barManager1;
            this.codPostalTextEdit.Name = "codPostalTextEdit";
            this.codPostalTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codPostalTextEdit.TabIndex = 4;
            // 
            // provFinancierosCuentasManagerBindingSource
            // 
            this.provFinancierosCuentasManagerBindingSource.DataSource = typeof(VENET_ProvFinancieros_BL.ProvFinancierosCuentasManager);
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
            this.btnAceptar.ImageOptions.Image = global::VENET_ProvFinancieros_UI.Properties.Resources.save_16x16;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(340, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 208);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(340, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 184);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(340, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 184);
            // 
            // id_EspecieLookUpEdit
            // 
            this.id_EspecieLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.provFinancierosCuentasManagerBindingSource, "Cuenta.Id_Especie", true));
            this.id_EspecieLookUpEdit.Location = new System.Drawing.Point(105, 8);
            this.id_EspecieLookUpEdit.MenuManager = this.barManager1;
            this.id_EspecieLookUpEdit.Name = "id_EspecieLookUpEdit";
            this.id_EspecieLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EspecieLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.id_EspecieLookUpEdit.Properties.NullText = "";
            this.id_EspecieLookUpEdit.Properties.ShowHeader = false;
            this.id_EspecieLookUpEdit.Size = new System.Drawing.Size(185, 20);
            this.id_EspecieLookUpEdit.TabIndex = 0;
            // 
            // cBUTextEdit
            // 
            this.cBUTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.provFinancierosCuentasManagerBindingSource, "Cuenta.CBU", true));
            this.cBUTextEdit.EnterMoveNextControl = true;
            this.cBUTextEdit.Location = new System.Drawing.Point(105, 138);
            this.cBUTextEdit.MenuManager = this.barManager1;
            this.cBUTextEdit.Name = "cBUTextEdit";
            this.cBUTextEdit.Properties.MaxLength = 22;
            this.cBUTextEdit.Size = new System.Drawing.Size(185, 20);
            this.cBUTextEdit.TabIndex = 5;
            this.cBUTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // nroSucursalTextEdit
            // 
            this.nroSucursalTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.provFinancierosCuentasManagerBindingSource, "Cuenta.NroSucursal", true));
            this.nroSucursalTextEdit.EnterMoveNextControl = true;
            this.nroSucursalTextEdit.Location = new System.Drawing.Point(105, 86);
            this.nroSucursalTextEdit.MenuManager = this.barManager1;
            this.nroSucursalTextEdit.Name = "nroSucursalTextEdit";
            this.nroSucursalTextEdit.Size = new System.Drawing.Size(100, 20);
            this.nroSucursalTextEdit.TabIndex = 3;
            this.nroSucursalTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // nroCuentaTextEdit
            // 
            this.nroCuentaTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.provFinancierosCuentasManagerBindingSource, "Cuenta.NroCuenta", true));
            this.nroCuentaTextEdit.EnterMoveNextControl = true;
            this.nroCuentaTextEdit.Location = new System.Drawing.Point(105, 60);
            this.nroCuentaTextEdit.MenuManager = this.barManager1;
            this.nroCuentaTextEdit.Name = "nroCuentaTextEdit";
            this.nroCuentaTextEdit.Size = new System.Drawing.Size(100, 20);
            this.nroCuentaTextEdit.TabIndex = 2;
            this.nroCuentaTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.ParseEditValue);
            // 
            // id_EntidadBancariaLookUpEdit
            // 
            this.id_EntidadBancariaLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.provFinancierosCuentasManagerBindingSource, "Cuenta.Id_EntidadBancaria", true));
            this.id_EntidadBancariaLookUpEdit.EnterMoveNextControl = true;
            this.id_EntidadBancariaLookUpEdit.Location = new System.Drawing.Point(105, 34);
            this.id_EntidadBancariaLookUpEdit.MenuManager = this.barManager1;
            this.id_EntidadBancariaLookUpEdit.Name = "id_EntidadBancariaLookUpEdit";
            this.id_EntidadBancariaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.id_EntidadBancariaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre1")});
            this.id_EntidadBancariaLookUpEdit.Properties.NullText = "";
            this.id_EntidadBancariaLookUpEdit.Properties.ShowHeader = false;
            this.id_EntidadBancariaLookUpEdit.Size = new System.Drawing.Size(185, 20);
            this.id_EntidadBancariaLookUpEdit.TabIndex = 1;
            // 
            // frmProvFinancierosCuentas_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 208);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(356, 247);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 240);
            this.Name = "frmProvFinancierosCuentas_AddMod";
            this.Text = "Alta/Modificación de Cuentas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProvFinancierosCuentas_AddMod_FormClosing);
            this.Load += new System.EventHandler(this.frmProvFinancierosCuentas_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codPostalTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provFinancierosCuentasManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EspecieLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBUTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroSucursalTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCuentaTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_EntidadBancariaLookUpEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit cBUTextEdit;
        private System.Windows.Forms.BindingSource provFinancierosCuentasManagerBindingSource;
        private DevExpress.XtraEditors.TextEdit nroSucursalTextEdit;
        private DevExpress.XtraEditors.TextEdit nroCuentaTextEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EntidadBancariaLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit id_EspecieLookUpEdit;
        private DevExpress.XtraEditors.TextEdit codPostalTextEdit;
    }
}