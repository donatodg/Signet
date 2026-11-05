namespace SitNET
{
    partial class frmConfig_AddMod
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
            System.Windows.Forms.Label dataBaseLabel;
            System.Windows.Forms.Label dataSourceLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label passLabel;
            System.Windows.Forms.Label providerLabel;
            System.Windows.Forms.Label userLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig_AddMod));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAceptar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dataBaseTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dataSourceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.passTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.providerComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.userTextEdit = new DevExpress.XtraEditors.TextEdit();
            dataBaseLabel = new System.Windows.Forms.Label();
            dataSourceLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            passLabel = new System.Windows.Forms.Label();
            providerLabel = new System.Windows.Forms.Label();
            userLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataBaseLabel
            // 
            dataBaseLabel.AutoSize = true;
            dataBaseLabel.Location = new System.Drawing.Point(14, 57);
            dataBaseLabel.Name = "dataBaseLabel";
            dataBaseLabel.Size = new System.Drawing.Size(80, 13);
            dataBaseLabel.TabIndex = 1;
            dataBaseLabel.Text = "Base de Datos:";
            // 
            // dataSourceLabel
            // 
            dataSourceLabel.AutoSize = true;
            dataSourceLabel.Location = new System.Drawing.Point(24, 83);
            dataSourceLabel.Name = "dataSourceLabel";
            dataSourceLabel.Size = new System.Drawing.Size(70, 13);
            dataSourceLabel.TabIndex = 3;
            dataSourceLabel.Text = "Data Source:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(43, 31);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(52, 13);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Empresa:";
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new System.Drawing.Point(38, 135);
            passLabel.Name = "passLabel";
            passLabel.Size = new System.Drawing.Size(57, 13);
            passLabel.TabIndex = 7;
            passLabel.Text = "Password:";
            // 
            // providerLabel
            // 
            providerLabel.AutoSize = true;
            providerLabel.Location = new System.Drawing.Point(35, 161);
            providerLabel.Name = "providerLabel";
            providerLabel.Size = new System.Drawing.Size(61, 13);
            providerLabel.TabIndex = 9;
            providerLabel.Text = "Proveedor:";
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Location = new System.Drawing.Point(48, 109);
            userLabel.Name = "userLabel";
            userLabel.Size = new System.Drawing.Size(47, 13);
            userLabel.TabIndex = 11;
            userLabel.Text = "Usuario:";
            // 
            // barManager1
            // 
            this.barManager1.AllowQuickCustomization = false;
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
            this.btnAceptar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAceptar.LargeGlyph")));
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAceptar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(344, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 236);
            this.barDockControlBottom.Size = new System.Drawing.Size(344, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 212);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(344, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 212);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.dataBaseTextEdit);
            this.groupControl1.Controls.Add(this.dataSourceTextEdit);
            this.groupControl1.Controls.Add(this.nameTextEdit);
            this.groupControl1.Controls.Add(this.passTextEdit);
            this.groupControl1.Controls.Add(this.providerComboBoxEdit);
            this.groupControl1.Controls.Add(this.userTextEdit);
            this.groupControl1.Controls.Add(dataBaseLabel);
            this.groupControl1.Controls.Add(passLabel);
            this.groupControl1.Controls.Add(userLabel);
            this.groupControl1.Controls.Add(dataSourceLabel);
            this.groupControl1.Controls.Add(nameLabel);
            this.groupControl1.Controls.Add(providerLabel);
            this.groupControl1.Location = new System.Drawing.Point(12, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(320, 194);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Datos";
            // 
            // dataBaseTextEdit
            // 
            this.dataBaseTextEdit.EnterMoveNextControl = true;
            this.dataBaseTextEdit.Location = new System.Drawing.Point(100, 54);
            this.dataBaseTextEdit.MenuManager = this.barManager1;
            this.dataBaseTextEdit.Name = "dataBaseTextEdit";
            this.dataBaseTextEdit.Size = new System.Drawing.Size(195, 20);
            this.dataBaseTextEdit.TabIndex = 1;
            // 
            // dataSourceTextEdit
            // 
            this.dataSourceTextEdit.EnterMoveNextControl = true;
            this.dataSourceTextEdit.Location = new System.Drawing.Point(100, 80);
            this.dataSourceTextEdit.MenuManager = this.barManager1;
            this.dataSourceTextEdit.Name = "dataSourceTextEdit";
            this.dataSourceTextEdit.Size = new System.Drawing.Size(195, 20);
            this.dataSourceTextEdit.TabIndex = 2;
            // 
            // nameTextEdit
            // 
            this.nameTextEdit.EnterMoveNextControl = true;
            this.nameTextEdit.Location = new System.Drawing.Point(100, 28);
            this.nameTextEdit.MenuManager = this.barManager1;
            this.nameTextEdit.Name = "nameTextEdit";
            this.nameTextEdit.Size = new System.Drawing.Size(195, 20);
            this.nameTextEdit.TabIndex = 0;
            // 
            // passTextEdit
            // 
            this.passTextEdit.EnterMoveNextControl = true;
            this.passTextEdit.Location = new System.Drawing.Point(101, 132);
            this.passTextEdit.MenuManager = this.barManager1;
            this.passTextEdit.Name = "passTextEdit";
            this.passTextEdit.Properties.PasswordChar = '*';
            this.passTextEdit.Size = new System.Drawing.Size(195, 20);
            this.passTextEdit.TabIndex = 4;
            // 
            // providerComboBoxEdit
            // 
            this.providerComboBoxEdit.EnterMoveNextControl = true;
            this.providerComboBoxEdit.Location = new System.Drawing.Point(100, 158);
            this.providerComboBoxEdit.MenuManager = this.barManager1;
            this.providerComboBoxEdit.Name = "providerComboBoxEdit";
            this.providerComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.providerComboBoxEdit.Properties.Items.AddRange(new object[] {
            "System.Data.SqlClient"});
            this.providerComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.providerComboBoxEdit.Size = new System.Drawing.Size(195, 20);
            this.providerComboBoxEdit.TabIndex = 5;
            // 
            // userTextEdit
            // 
            this.userTextEdit.EnterMoveNextControl = true;
            this.userTextEdit.Location = new System.Drawing.Point(100, 106);
            this.userTextEdit.MenuManager = this.barManager1;
            this.userTextEdit.Name = "userTextEdit";
            this.userTextEdit.Size = new System.Drawing.Size(195, 20);
            this.userTextEdit.TabIndex = 3;
            // 
            // frmConfig_AddMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 236);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "";
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 275);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 275);
            this.Name = "frmConfig_AddMod";
            this.Text = "Alta\\Modificación de Configuración";
            this.Load += new System.EventHandler(this.frmConfig_AddMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit dataBaseTextEdit;
        private DevExpress.XtraEditors.TextEdit dataSourceTextEdit;
        private DevExpress.XtraEditors.TextEdit nameTextEdit;
        private DevExpress.XtraEditors.TextEdit passTextEdit;
        private DevExpress.XtraEditors.ComboBoxEdit providerComboBoxEdit;
        private DevExpress.XtraEditors.TextEdit userTextEdit;
    }
}